//Front Page
$(function () {
    
   // $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: !0 });
    GetRequestedDetail();
    getSubClass();
    $('#txtIssueDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    $("#ddlItemSubClass").change(function () {
        if ($(this).val() == "-1") {
            $('#ddlItem').empty();
            $('#ddlItem').attr("disabled", "disabled");
        } else {
            GetIssueItems($(this));
        }
    });
    $("#ddlItem").change(function () {
        if ($(this).val() == "-1") {
            $('#dvNumberInStocked').html('');
        } else {
            GetItemNumberInStock($(this).val());
        }
    });
    //btn Save
    $("#btnIssue").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            IssueItemsList();
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
        if ($('#ddlItemSubClass').val() == '-1') {
            $('#ddlItemSubClass').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#ddlItemSubClass').css('background-color', '#ffff'); }

        if ($('#ddlItem').val() == '-1') {
            $('#ddlItem').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#ddlItem').css('background-color', '#ffff'); }

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
            var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + (parseInt(count) + 1) + "</td><td>" + $('#ddlItemSubClass').find('option:selected').text() + "</td><td><span id='Item' style='display:none'>" + $('#ddlItem').val() + "</span>" + $('#ddlItem').find('option:selected').text() + "</td><td><span id='Quantity'>" + $('#txtItemQuantity').val() + "</span></td></tr>";
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

  
});
//Jscode
function GetRequestedDetail() {
    $.ajax({
        type: "POST",
        url: "Issue_Admin.aspx/GetOfficeSupplyReqDetail",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#tblItemInsertion tbody tr").remove();            
            $.each(data.d, function (i, x) {
                var count = $('#tblItemInsertion tbody tr').length;
                var markup = "<tr class='far'><td><a onclick='MDReqIssueItemsDetail(this)' class='' href='#'>ISSUE</a><span id='REQId' style='display:none;' >" + x.RID + "</span><span   style='display:none;'>" + x.DeptId + "</span><span style='display:none;'  >" + x.ProId + "</span></td><td>" + (parseInt(count) + 1) + "</td><td>" + x.RID + "</td><td>" + x.RBY + "</td><td><span>" + x.Position + "</span></td><td>" + x.Dept + "</td><td><span id='Modal' > <a onclick='showMDReqItemsDetail(this)' class='' href='#'>" + x.TItems + "</a></span></td><td><span>" + x.DaysLast + "</span></td></tr>";
                $("#tblItemInsertion tbody").append(markup);
                if (parseInt(count) == 0) {
                   
                }
            });
            $("#tblItemInsertion").DataTable().destroy()
            $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX:true });

        },
        error: function (data) {
            alert("error found");
        }

    });
}
function showMDReqItemsDetail(obj) {
    var tr = $(obj).closest('tr');
    // console.log(tr);
    $.ajax({
        type: "POST",
        url: "Issue_Admin.aspx/GetReqItemDetail",
        data: '{ReqId:' + $($(tr).find('span:eq(0)')).html() + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table  class='table table-xs nowrap table-striped scroll-horizontal'>";
            var header = "<thead><tr class='bg-lighten-blue' ><th>SN</th><th >Items</th><th >Quantity</th><th >Remarks</th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td >" + count + "</td>" +
                   "<td ><span>" + x.Item + "  </span></td>" +
                   "<td ><span>" + x.Quantity + "</span></td>" +
                   "<td ><span>" + x.Remarks + "</span></td>" +
                "</tr>";
                $table += row;
                count++;
            });
            $('#tblReqItemDetail').html($table);
            $table += "</table>";
            $('#MDReqItemsD').modal('show');
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function MDReqIssueItemsDetail(obj) {
    var tr = $(obj).closest('tr');
    $('#hdnDeptId').val($($(tr).find('span:eq(1)')).html());
    $('#hdnProvId').val($($(tr).find('span:eq(2)')).html());
    $('#hdnReqId').val($($(tr).find('span:eq(0)')).html());
    // console.log(tr);
    $.ajax({
        type: "POST",
        url: "Issue_Admin.aspx/GetReqItemDetail",
        data: '{ReqId:' + $($(tr).find('span:eq(0)')).html() + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table  class='table  scroll-horizontal'>";
            var header = "<thead><tr class='bg-lighten-blue' ><th>SN</th><th >Items</th><th >Quantity</th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td >" + count + "</td>" +
                   "<td ><span>" + x.Item + "  </span></td>" +
                   "<td ><span>" + x.Quantity + "</span></td>" +
                "</tr>";
                $table += row;
                count++;
            });
            $('#DivLeftReqItemDetail').html($table);
            $table += "</table>";

            //large modal
            $('#MDItemIssueDetail').modal('show');
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getSubClass() {
    $.ajax({
        type: "POST",
        url: "Issue_Admin.aspx/GetSubClass",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlItemSubClass').empty();
            $.each(data.d, function (key, value) {
                $('#ddlItemSubClass').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlItemSubClass').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlItemSubClass option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function GetIssueItems(obj) {
    $.ajax({
        type: "POST",
        url: "Issue_Admin.aspx/GetStoreItems",
        data: JSON.stringify({ SubClassID: $(obj).val() }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlItem').empty();
            $.each(data.d, function (key, value) {
                $('#ddlItem').append($("<option></option>").val(value.ID).html(value.Item));
            });
            $('#ddlItem').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlItem option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function IssueItemsList() {
    var formDetails = {};
   // formDetails.IS_By = $('#txtIssuedBy').val();
    formDetails.RC_By = $('#txtRecievedBy').val();
    formDetails.DeptId = $('#hdnDeptId').val();
    formDetails.ProId = $('#hdnProvId').val();
    formDetails.Remarks = $('#txtRemarks').val();
    formDetails.Req_Id = $('#hdnReqId').val();
    formDetails.IS_D = $('#txtIssueDate').val();

    var lst = new Array();
    $('#tblIssuedItems tbody tr').each(function () {
        var detail = {};
        var tr = $(this).closest('tr');
        var Item = $(tr).find('span:eq(0)');
        var Quantity = $(tr).find('span:eq(1)');

        detail.ID = $(Item).html();
        detail.Quantity = $(Quantity).html();
        lst.push(detail);
    });
    formDetails.IList = lst;
    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "Issue_Admin.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Items are Successfully Saved !", "INV-MIS: GOODS VOUCHER RECIEVED !", { progressBar: !0 });
            //Clear components
            ClearForm();
            $('#MDItemIssueDetail').modal('hide');
            GetRequestedDetail();
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function GetItemNumberInStock(obj) {
    $.ajax({
        type: "POST",
        url: "Issue_Admin.aspx/GeItemsNumbersInStock",
        data: JSON.stringify({ ItmID:obj }),
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
    if ($('#txtRecievedBy').val() == '') {
        $('#txtRecievedBy').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtRecievedBy').css('background-color', '#ffff'); }
    if ($('#txtIssuedBy').val() == '') {
        $('#txtIssuedBy').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtIssuedBy').css('background-color', '#ffff'); }
    if ($('#txtIssueDate').val() == '') {
        $('#txtIssueDate').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtIssueDate').css('background-color', '#ffff'); }


    if (flag) { return true } else {
        toastr.warning("Please Check below Rows from the table ,Enter valid informations  !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {

    $('#ddlItem').val('-1');
    $('#txtItemQuantity').val('');
    $('#txtRecievedBy').val('');
    $('#txtRemarks').val('');
    $('#tblIssuedItems tbody tr').remove();
    $("#dvIssueTotalItems").html('');
    $("#DivLeftReqItemDetail").html('');
}
function SumTAmount() {
    var count = $('#tblIssuedItems tbody tr').length;
    $("#dvIssueTotalItems").html('');
    var markup2 = "Total Issued Items in the List are  <code class='bold'> " + (parseInt(count)) + "</code> ";
    $("#dvIssueTotalItems").html(markup2);
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



