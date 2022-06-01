//Front Page
$(function () {
    $('#txtTransferMonth').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    getDepartment();
    // $('#txtTransferDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    $("#txtTransferMonth").change(function () {
        if ($(this).val() == "" || $('#ddlTDepartment').val() == '-1' || $('.Tprovince').val() == '-1') {
            $('#dvTblTransfItems').html('');
        } else {
            showTransferedIssuedItems($('.Tprovince').val(), $('#ddlTDepartment').val(), $('#txtTransferMonth').val());
        }
    });
    $("#ddlTDepartment").change(function () {
        if ($(this).val() == "" || $('#txtTransferMonth').val() == '' || $('.Tprovince').val() == '-1') {
            $('#dvTblTransfItems').html('');
        } else {
            showTransferedIssuedItems($('.Tprovince').val(), $('#ddlTDepartment').val(), $('#txtTransferMonth').val());
        }
    });
    $(".Tprovince").change(function () {
        if ($(this).val() == "" || $('#txtTransferMonth').val() == '' || $('#ddlTDepartment').val() == '-1') {
            $('#dvTblTransfItems').html('');
        } else {
            showTransferedIssuedItems($('.Tprovince').val(), $('#ddlTDepartment').val(), $('#txtTransferMonth').val());
        }
    });
    //btn Save
    $("#btnApprove").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Approve_transfer_items();
        }
    }); 
    //btn update
    $("#btnReject").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Reject();
        }
    });
});
//Jscode
function SelectAllCheckboxes(chk) {
    $('#TblTransfItems').find("input:checkbox").each(function () {
        if (this != chk) {
            this.checked = chk.checked;
        }
    });
}
function showTransferedIssuedItems(Tprov, TDept, TMonth) {
  
    var ParmJson = JSON.stringify({TProv:Tprov,TDept:TDept,TMonth:TMonth});
        $.ajax({
            type: "POST",
            url: "tansfer_items_w_app.aspx/getTranIssuedItemsList",
            data:ParmJson,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var $table = "<table id='TblTransfItems'  class='table table-xs nowrap table-striped ' width='100%' cellspacing='0'>";
                var header = "<thead><tr class='bg-lighten-blue' ><th>All<br/><input type='checkbox' name='checkAll' onclick='javascript:SelectAllCheckboxes(this);'/></th><th>SN</th><th >Items (Code)</th><th >Quantity</th><th >Issued Dept</th><th >Issued Province</th><th >Issued Date</th><th >Recieved Dept</th><th >Recieved Province</th></tr></thead>";
                $table += header;
                var count = 1;
                $.each(data.d, function (i, x) {
                    var row = "<tr ><td><input type='checkbox' name='record' /></td>"+
                    "<td >" + count + "</td>" +
                   "<td ><span style='display:none;'>" + x.ItemID + "</span><span style='display:none;'>" + x.BCode + "</span>" + x.Name + "</td>" +
                   "<td ><span>" + x.Quantity + "</span></td>" +
                   "<td ><span>" + x.IsDept + "</span></td>" +
                    "<td ><span>" + x.IsProv + "</span></td>" +
                   "<td ><span>" + x.TDate + "</span></td>" +
                   "<td ><span>" + x.RDept + "</span></td>" +
                   "<td ><span>" + x.RProv + "</span></td>" +
                "</tr>";
                    $table += row;
                    count++;
                });
                $('#dvTblTransfItems').html($table);
                $table += "</table>";
                $('#TblTransfItems').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: true });

            },
            error: function (data) {
                alert("error found");
            }

        });
}
function DeleteTD(obj) {
    if (confirm("Are You Sure To Delete the Selected Transfered Items ?")) {
        var tr = $(obj).closest('tr');
        var jsObj = JSON.stringify({ bCode: $($(tr).find('span:eq(0)')).html(), Qunatity: $($(tr).find('span:eq(1)')).html(), IsDept: $($(tr).find('span:eq(2)')).html(), IsProv: $($(tr).find('span:eq(3)')).html(), RDept: $($(tr).find('span:eq(5)')).html(), TDate: $($(tr).find('span:eq(4)')).html() });

        // console.log(tr);
        $.ajax({
            type: "POST",
            url: "transfer_items_w.aspx/SetToFalse",
            data: jsObj,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == false)
                    toastr.success("Sent Transfer Items Are Deleted !", "INV-MIS: Items Transfer Deletion !", { progressBar: !0 });
                else
                    toastr.warning("Can NoT be Deleted,Transfer Items Are Already Approved in the Transfered Location.", "INV-MIS: Items Transfer Deletion !", { progressBar: !0 });
                //large modal
                $('#MDSearch').modal('hide');
            },
            error: function (data) {
                alert("error found");
            }

        });
    }
}

function Approve_transfer_items() {
    if ( confirm('Are You Sure to Approve the Selected Transfered Items ? Once You Approved Then You Are Not Able To ROLLBACK')) {
        var lst = new Array();
        $('#TblTransfItems tbody tr').each(function () {
            var detail = {};
            var tr = $(this).closest('tr');
            if ($(this).find("input:checkbox[name^='record']").is(":checked")) {
                detail.ItemID = $($(tr).find('span:eq(0)')).html();
                detail.BCode = $($(tr).find('span:eq(1)')).html();
                detail.Quantity = $($(tr).find('span:eq(2)')).html();
                detail.IsDept = $($(tr).find('span:eq(3)')).html();
                detail.IsProv = $($(tr).find('span:eq(4)')).html();
                detail.TDate = $($(tr).find('span:eq(5)')).html();
                detail.RDept = $($(tr).find('span:eq(6)')).html();
                detail.RProv = $($(tr).find('span:eq(7)')).html();
                lst.push(detail);
            }
        });
        var jsonObject = JSON.stringify({ lst: lst });
        $.ajax({
            type: "POST",
            url: "tansfer_items_w_app.aspx/ApproveTransferedItems",
            data: jsonObject,
            dataType: "json",
            async: false,
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                toastr.success("The selected Transfered Items are Approved !", "INV-MIS: Transfered Items !", { progressBar: !0, timeOut: 10e3 });
                //Clear components
                $("#ddlTDepartment").trigger('change');
                ClearForm();
                setTimeout(function () {
                    $('#divMsg').hide();
                }, 30000);



            },
            error: function (data) {
                alert("error found");
            }

        });
    }
}
function formValidation(e) {
    var flag = true;
    var count = $('#TblTransfItems tbody tr').length;
    if (parseInt(count) == 0) {
        flag = false;
    }

    if ($('#txtTransferMonth').val() == '') {
        $('#txtTransferMonth').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtTransferMonth').css('background-color', '#ffff'); }
    if ($('.Tprovince').val() == '-1') {
        $('.Tprovince').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('.Tprovince').css('background-color', '#ffff'); }
    if ($('#ddlTDepartment').val() == '-1') {
        $('#ddlTDepartment').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlTDepartment').css('background-color', '#ffff'); }
   


    if (flag) { return true } else {
        toastr.warning("Please Check below Rows from the table ,Enter valid informations  !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {

    $('#ddlTDepartment').val('-1');
    $('.Tprovince').val('-1');
    $('#TblTransfItems tbody tr').remove();
    $("#dvTblTransfItems").html('');
}

function getDepartment() {
    $.ajax({
        type: "POST",
        url: "transfer_items_w.aspx/GetDepartment",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlTDepartment').empty();
            $.each(data.d, function (key, value) {
                $('#ddlTDepartment').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlTDepartment').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlTDepartment option:first').attr("selected", "selected");

            $('#ddRlDepartment').empty();
            $.each(data.d, function (key, value) {
                $('#ddlRDepartment').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlRDepartment').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlRDepartment option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}


function Reject() {
    var formDetails = {};
    var lst = new Array();
    $('#tblItemInsertion tbody tr').each(function () {
        var detail = {};
        var tr = $(this).closest('tr');
        if ($(this).find("input:checkbox[name^='record']").is(":checked")) {
            var RID = $(tr).find('span:eq(0)');
            var RType = $(tr).find('span:eq(2)');
            detail.RID = $(RID).html();
            detail.RType = $(RType).html();
            lst.push(detail);
        }
    });
    var jsonObject = JSON.stringify({ lst: lst });
    $.ajax({
        type: "POST",
        url: "ReqApproval.aspx/RejectFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var content = $(".lead");
            $(content).append("<div id='divMsg' class='alert bg-success alert-icon-left alert-arrow-left alert-dismissible fade in mb-2' role='alert'>" +
                 "<button class='close'  aria-label='Close' type='button' data-dismiss='alert'><span aria-hidden='true'>×</span></button> <strong> Req #: NHLP-Rq-" + data.d + "</strong> ,<p class='font-size-small'> Note your request number . This Message will be deleted after 30 seconds OR click on the (x) button.</p></div>");
            toastr.success("Requisition form and thier items detail are sent to your Supervisor !", "INV-MIS: Requisition Form is Sent !", { progressBar: !0, timeOut: 10e3 });
            //Clear components
            ClearForm();
            setTimeout(function () {
                $('#divMsg').hide();
            }, 30000);



        },
        error: function (data) {
            alert("error found");
        }

    });
}



