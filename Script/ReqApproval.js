//Front Page
$(function () {
    // $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: !0 });
    GetRequestedDetail();
    var count = $('#tblItemInsertion tbody tr').length;
    if (parseInt(count) == 0) {
        //  $('#tblItemInsertion').hide();
        // $('#btnReject').hide();
        // $('#btnApprove').hide();
    }
    // $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: true });
    $("#ddlReviecedItemClass").change(function () {
        if ($(this).val() == "-1") {
            $('#ddlReviecedItemSubClass').empty();
            $('#ddlReviecedItemSubClass').attr("disabled", "disabled");
        } else {
            getSubClass($(this));
        }
    });
    $("#ddlReviecedItemSubClass").change(function () {
        if ($(this).val() == "-1") {
            $('#ddlReviecedItems').empty();
            $('#ddlReviecedItems').attr("disabled", "disabled");
        } else {
            GetRecievedItems($(this));
        }
    });
    $("#ddlProvince").change(function () {
        if ($(this).val() == "-1") {
        }
        else {
            getSupervisors();
        }
    });
    $("#ddlDepartment").change(function () {
        if ($(this).val() == "-1") { }
        else {
            getSupervisors();
        }
    });
    //btn Save
    $("#btnApprove").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            if (confirm("Are You Sure To Confirm The Requested Requisitions ? ")) {
                Accept();
            }
        }
    });

    //btn update
    $("#btnReject").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            if (confirm("Are You Sure To Reject The Requested Requisitions ? ")) {
                Reject();
            }
        }
    });


});
//Jscode
function GetRequestedDetail() {
    $.ajax({
        type: "POST",
        url: "ReqApproval.aspx/GetRequestedDetail",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#tblItemInsertion tbody tr").remove();
            $.each(data.d, function (i, x) {
                var count = $('#tblItemInsertion tbody tr').length;
                var markup = "<tr class='far text-md-center'><td><input type='checkbox' name='record'><span id='REQId' style='display:none;' >" + x.RID + "</span><span style='display:none;'>" + x.RType + "</span><span style='display:none;'>" + x.Email + "</span></td><td>" + (parseInt(count) + 1) + "</td><td>" + x.RID + "</td><td>" + x.RBY + "</td><td><span id='Quantity'>" + x.RType + "</span></td><td><span>" + x.Position + "</span></td><td><span>" + x.prov + "</span></td><td>" + x.Dept + "</td><td><span id='Modal' > <a onclick='ItemsDetail(this)' class='' href='#'>" + x.TItems + "</a></span></td><td><span id='Serial'>" + x.DaysLast + "</span></td>" +
                     "<td ><a id=\"aExample\" target='_blank' href='FormDownload.aspx?fRdetailAll=" + x.RID + "'  runat=\"server\">Download</a></td></tr>";
                $("#tblItemInsertion tbody").append(markup);
                if (parseInt(count) == 0) {

                }
            });

            var count = $('#tblItemInsertion tbody tr').length;
            if (parseInt(count) == 0) {
                $('#btnReject').hide();
                $('#btnApprove').hide();
            } else {
                $('#tblItemInsertion').show();
                $('#btnReject').show();
                $('#btnApprove').show();
            }
           // $("#tblItemInsertion").DataTable().destroy();
            $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: !0 });

            getNoOfReq4rmTable();
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function Accept() {
    var formDetails = {};
    var lst = new Array();
    $('#tblItemInsertion tbody tr').each(function () {
        var detail = {};
        var tr = $(this).closest('tr');
        if ($(this).find("input:checkbox[name^='record']").is(":checked")) {
            var RID = $(tr).find('span:eq(0)');
            var RType = $(tr).find('span:eq(3)');
            var REmail = $(tr).find('span:eq(2)');
            detail.RID = $(RID).html();
            detail.RType = $(RType).html();
            detail.Email = $(REmail).html();
            lst.push(detail);
        }
    });
    var jsonObject = JSON.stringify({ lst: lst });
    $.ajax({
        type: "POST",
        url: "ReqApproval.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("The Selected Requisition forms Are Accepted and Forwarded to their other CHANNELS !", "INV-MIS: Requisition Forms ARE APPROVED !", { progressBar: !0, timeOut: 10e3 });
            //Clear components
            ClearForm();
            GetRequestedDetail();


        },
        error: function (data) {
            alert("error found");
        }

    });
}
function ItemsDetail(obj) {
    var tr = $(obj).closest('tr');
    // console.log(tr);
    $.ajax({
        type: "POST",
        url: "ReqApproval.aspx/GetItemDetail",
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
                   "<td ><span>" + x.Name + "  </span></td>" +
                   "<td ><span>" + x.Quantity + "</span></td>" +
                    "<td ><span>" + x.Remarks + "</span></td>" +

                "</tr>";
                $table += row;
                count++;
            });
            $('#tblItemDetail').html($table);
            $table += "</table>";
            $('#MDItemsD').modal('show');
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
            getNoOfReq4rmTable();



        },
        error: function (data) {
            alert("error found");
        }

    });
}
function formValidation(e) {
    var flag = true;
    var count = $('#tblItemInsertion tbody tr').length;
    if (parseInt(count) == 0) {
        flag = false;
    }
    var check = 0;
    $('#tblItemInsertion tbody tr').each(function () {
        if ($(this).find("input:checkbox[name^='record']").is(":checked")) {
            check++;
        }
    });

    if (check == 0)
        flag = false;
    if (flag) { return true } else {
        toastr.warning("Please Check Rows in the Table to Approve or Reject Items Requesitions !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {
    $('#ddlDepartment').val('-1');
    $('#ddlProvince').val('-1');
    $('#ddlSupervisor').val('-1');
    $('#txtRequester').val('');
    $('#txtPosition').val('');
    $('#txtEmail').val('');
    // $('#tblItemInsertion tbody tr').remove();
    // $("#cTotalAmount").html('');
}
function clearModal() {
    $('#ddlUnit').val("-1");
    $('#txtRemarks').val("");
    $('#txtReqQunatity').val("");
    $('#txtItems').val("");
}
function SumTAmount() {
    var count = $('#tblItemInsertion tbody tr').length;
    $("#cTotalAmount").html('');
    var markup2 = "Total Requested Items in the List are  <code class='bold'> " + (parseInt(count)) + "</code> ";
    $("#cTotalAmount").html(markup2);
}
function getNoOfReq4rmTable() {
    var count = $('#tblItemInsertion tbody tr').length;
    if (parseInt(count) > 0) {
        var content = $(".noOfsReq");
        $(content).html('');
        $(content).append("<div id='divMsg' class='alert bg-warning black alert-icon-left alert-arrow-left alert-dismissible fade in mb-2' role='alert'>" +
             " <strong> ( " + count + " ) User Requests </strong> , are waiting for your permission . Please follow below instructions.</p></div>");


    } else {
        var content = $(".noOfsReq");
        $(content).html('');
        $(content).append("<div id='divMsg' class='alert bg-warning black alert-icon-left alert-arrow-left alert-dismissible fade in mb-2' role='alert'>" +
             " <strong> ( " + count + " ) User Requests </strong> , are waiting for your permission . Please follow below instructions.</p></div>");

        $('#btnReject').hide();
        $('#btnApprove').hide();
    }
}

