//Front Page
$(function () {
    getDepartment();
    getItems();
    $('#ddlItems').select2({ containerCssClass: "select-xs" });
    $('#txtTransferDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    //$("#txtBrcd").change(function () {
    //    if ($(this).val() == "-1") {
    //        $('#txtItemInfo').val('');
    //        $('#txtItemQuantity').val('');
    //    } else {
    //        GetWItems($(this).val());
    //    }
    //});
    //$("#txtItemInfo").change(function () {
    //    if ($(this).val() == "") {
    //        $('#dvNumberInStocked').html('');
    //    } else {
    //        GetItemNumberInStock($(this).prop('title'), $('.Tprovince').val(), $('#ddlTDepartment').val());
    //    }
    //});
    $("#ddlItems").change(function () {
        if ($(this).val() == "-1") {
            $('#dvNumberInStocked').html('');
        } else {
            GetItemNumberInStock($(this).val(), $('.Tprovince').val(), $('#ddlTDepartment').val());
        }
    });
    //btn Save
    $("#btnSave").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Save_transfer_items();
        }
    });
    //btn update
    $("#btnReject").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Reject();
        }
    });
    
    $('#lnkIssueItemInsert').click(function (e) {
        e.preventDefault();

        var flag = true;
        //if ($('#txtBrcd').val() == '') {
        //    $('#txtBrcd').css('background-color', '#FFAAAA'); flag = false;
        //} else { $('#txtBrcd').css('background-color', '#ffff'); }

        if ($('#ddlItems').val() == '-1') {
            $('#ddlItems').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#ddlItems').css('background-color', '#ffff'); }

        if ($('#txtItemQuantity').val() == '') {
            $('#txtItemQuantity').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtItemQuantity').css('background-color', '#ffff'); }

        if (parseFloat($('#txtItemQuantity').val())<=0) {
            $('#txtItemQuantity').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtItemQuantity').css('background-color', '#ffff'); }

        if (parseFloat($('#txtItemQuantity').val()) > parseFloat($('#itmCountNumber').html()) || parseFloat($('#itmCountNumber').html()) <= 0 ) {
            $('#txtItemQuantity').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtItemQuantity').css('background-color', '#ffff'); }


        var count = $('#tblIssuedItems tbody tr').length;

        if (flag) {
            var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + (parseInt(count) + 1) + "</td><td><span  style='display:none'>" + $('#ddlItems').val() + "</span><span  style='display:none'>" + $('#ddlItems').val() + "</span>" + $('#ddlItems option:selected').text() + "</td><td><span id='Quantity'>" + $('#txtItemQuantity').val() + "</span></td></tr>";
            $("#tblIssuedItems tbody").append(markup);
            if (parseInt(count) == 0) {
                $('#tblIssuedItems').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: !0 });
            }
            SumTAmount();
          // clearModal();
        } else {

        }
    });
    $("#lnkIssueItemRemove").click(function (e) {
        e.preventDefault();
        $("#tblIssuedItems tbody").find('input[name="record"]').each(function () {
            if ($(this).is(":checked")) {
                $(this).parents("tr").remove();
                SumTAmount();
            }
        });
    });

    $('#lnkSearch').click(function () {
        if ($('.Tprovince').val() != "-1" && $('#ddlTDepartment').val() != "-1") {
            showMDTransferItemsDetail($('.Tprovince').val(), $('#ddlTDepartment').val());
        }
    });
});
//Jscode
function showMDTransferItemsDetail(Tprov,TDept) {
    $.ajax({
        type: "POST",
        url: "transfer_items_w.aspx/GetWTransferItemsList",
        data: '{TProv:' +Tprov+ ',TDept:'+TDept+'}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table id='tblSearch'  class='table table-xs nowrap table-striped ' width='100%' cellspacing='0'>";
            var header = "<thead><tr class='bg-lighten-blue' ><th>SN</th><th >Items (Code)</th><th >Quantity</th><th >Issued Dept</th><th >Issued Province</th><th >Issued Date</th><th >Recieved Dept</th><th>Edit Options</th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td >" + count + "</td>" +
                   "<td ><span style='display:none;'>" + x.ItemId + "</span>"+x.Name+"</td>" +
                   "<td ><span>" + x.Quantity + "</span></td>" +
                   "<td ><span>" + x.IsDept + "</span></td>" +
                    "<td ><span>" + x.IsProv + "</span></td>" +
                   "<td ><span>" + x.TDate + "</span></td>" +
                   "<td ><span>" + x.RDept + "</span></td>" +
                       (x.Edit == true ? "<td><a onclick='DeleteTD(this)'  class='icon-bin' href='#'></a></td>" : "<td></td>") +
                "</tr>";
                $table += row;
                count++;
            });
            $('#dvSearch').html($table);
            $table += "</table>";
            $('#tblSearch').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true,scrollX:true});
            $('#MDSearch').modal('show');
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

function GetWItems(obj) {
    alert(obj);
    $.ajax({
        type: "POST",
        url: "transfer_items_w.aspx/GetWItems",
        data: '{Code:' + obj + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#txtItemInfo').val(data.d.Item);
            $('#txtItemInfo').attr('title', data.d.ID);
            $('#txtItemInfo').trigger('change');
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getItems() {
    $.ajax({
        type: "POST",
        url: "transfer_items_w.aspx/GetItems",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlItems').empty();
            $.each(data.d, function (key, value) {
                $('#ddlItems').append($("<option></option>").val(value.ID).html(value.Item));
            });
            $('#ddlItems').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlItems option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function Save_transfer_items() {
    var formDetails = {};
    formDetails.TDate = $('#txtTransferDate').val();
    formDetails.IsProv = $('.Tprovince').val();
    formDetails.IsDept = $('#ddlTDepartment').val();
    formDetails.RProv = $('.Rprovince').val();
    formDetails.RDept = $('#ddlRDepartment').val();
    formDetails.TransferedBy = $('#txtIssuer').val();
    formDetails.Remarks = $('#txtRemarks').val();

    var lst = new Array();
    $('#tblIssuedItems tbody tr').each(function () {
        var detail = {};
        var tr = $(this).closest('tr');
        var Code = $(tr).find('span:eq(0)');
        var Item = $(tr).find('span:eq(1)');
        var Quantity = $(tr).find('span:eq(2)');

        detail.Code = $(Code).html();
        detail.ID = $(Item).html();
        detail.Quantity = $(Quantity).html();
        lst.push(detail);
    });
    formDetails.Ilst = lst;
    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "transfer_items_w.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Items are Successfully Transfered !", "INV-MIS: Items Transfer !", { progressBar: !0 });
            //Clear components
            ClearForm();
            $('#MDItemIssueDetail').modal('hide');
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function GetItemNumberInStock(obj,Prov,Dept) {
    $.ajax({
        type: "POST",
        url: "transfer_items_w.aspx/GeItemsNumbersInStock",
        data: JSON.stringify({ ItmID: obj, DeptId: Dept, ProvinceId: Prov }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#dvNumberInStocked').html("Number Of Item In Store :<strong><div clas=' blue' id='itmCountNumber'>" + data.d + "</div></strong>");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function formValidation(e) {
    var flag = true;
    var count = $('#tblIssuedItems tbody tr').length;
    if (parseInt(count) == 0) {
        flag = false;
    }
    if ($('#txtIssuer').val() == '') {
        $('#txtIssuer').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtIssuer').css('background-color', '#ffff'); }
    if ($('#txtTransferDate').val() == '') {
        $('#txtTransferDate').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtTransferDate').css('background-color', '#ffff'); }
    if ($('.Tprovince').val() == '-1') {
        $('.Tprovince').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('.Tprovince').css('background-color', '#ffff'); }
    if ($('.Rprovince').val() == '-1') {
        $('.Rprovince').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('.Rprovince').css('background-color', '#ffff'); }
    if ($('#ddlRDepartment').val() == '-1') {
        $('ddlRDepartment').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlRDepartment').css('background-color', '#ffff'); }
    if ($('#ddlTDepartment').val() == '-1') {
        $('ddlTDepartment').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlTDepartment').css('background-color', '#ffff'); }


    if (flag) { return true } else {
        toastr.warning("Please Check below Rows from the table ,Enter valid informations  !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {

    $('#ddlItem').val('-1');
    $('#txtBrcd').val('');
    $('#txtItemInfo').val('');
    $('#txtItemQuantity').val('');
    $('#txtIssuer').val('');
    $('#txtRemarks').val('');
    $('#tblIssuedItems tbody tr').remove();
    $("#dvIssueTotalItems").html('');
    $('#dvNumberInStocked').html('');
}
function SumTAmount() {
    var count = $('#tblIssuedItems tbody tr').length;
    $("#dvIssueTotalItems").html('');
    var markup2 = "Total Issued Items in the List are  <code class='bold'> " + (parseInt(count)) + "</code> ";
    $("#dvIssueTotalItems").html(markup2);
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



