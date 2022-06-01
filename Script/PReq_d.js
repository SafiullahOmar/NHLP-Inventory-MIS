//Front Page
$(function () {
    
   // $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: !0 });
    GetRequestedDetail();

  
});
//Jscode
function GetRequestedDetail() {
    $.ajax({
        type: "POST",
        url: "PReq_d.aspx/GetPReqDetail",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //var $table = "<table id='tblItemInsertion'  width='98%' class='table table-xs nowrap table-striped'>";
            //var header = "<thead><tr ><th>SN</th><th style='text-align:center;'>Req #</th><th style='text-align:center;'>Req Type</th><th style='text-align:center;'>Requested By</th><th style='text-align:center;'>Position</th><th style='text-align:center;'>Location</th><th style='text-align:center;'>Unit</th><th style='text-align:center;'>(#)T Items Req</th><th style='text-align:center;'>(#)T Items Issued</th><th style='text-align:center;'>Issue #</th><th style='text-align:center;'>Downoald</th><th style='text-align:center;'></th></tr></thead>";
            //$table += header;
            if (!jQuery.isEmptyObject(data.d)) {
                $.each(data.d, function (i, x) {
                    var count = $('#tblItemInsertion tbody tr').length;
                    var markup = "<tr class='far'><td><span id='REQId' style='display:none;' >" + x.RID + "</span><span style='display:none;'>" + x.ISID + "</span><span   style='display:none;'>" + x.DeptId + "</span><span style='display:none;'  >" + x.ProId + "</span><span style='display:none;'>" + x.ReqTypeId + "</span>" + (parseInt(count) + 1) + "</td><td>" + x.RID + "</td><td>" + x.RType + "</td><td>" + x.RBY + "</td><td><span>" + x.Position + "</span></td><td>" + x.Prov + "</td><td>" + x.Dept + "</td><td><span id='Modal' > <a onclick='showMDReqItemsDetail(this)' class='' href='#'>" + x.TReqItems + "</a></span></td><td><span id='Modal' > <a onclick='showMDIssuedItemsDetail(this)' class='' href='#'>" + x.TIssuedItems + "</a></span></td><td><span>" + x.ISID + "</span></td><td> <a id=\"aExample\" target='_blank' href='FormDownload.aspx?fdetailDWstore=" + x.ISID + "&RTypeId=" + x.ReqTypeId + "'  runat=\"server\">Issue Voucher</a></td>" + (x.Edit == 1 ? "<td><a onclick='ConfirmD(this)' class='btn-sm btn-danger ' href='#'>Delete</a></td>" : "<td></td>") + "</tr>";
                   // $table += markup;
                    $("#tblItemInsertion").append(markup);
                   
                });
            } 
            //else {
            //    $("#tblItemInsertion").DataTable().destroy()
            //    $('#tblItemInsertion').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: true });
            //}

            $("#tblItemInsertion").DataTable().destroy()
            $('#tblItemInsertion').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: true });
            //$('#dvIssuetbl').html($table);
            //$table += "</table>";
            //$('#tblItemInsertion').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: true });

        },
        error: function (data) {
            alert("error found");
        }

    });
}
function ConfirmD(obj) {
    var tr = $(obj).closest('tr');
    if (confirm('Area you Sure to Delete the Mention Record ?'))
        $.ajax({
            type: "POST",
            url: "PReq_d.aspx/SetToFalseIssuedReq",
            data: '{ReqId:' + $($(tr).find('span:eq(0)')).html() + ',IssueId:' + $($(tr).find('span:eq(1)')).html() + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //Toast Message
                toastr.success("ISSUE VOUCHER is successfully removed from the system !", "INV-MIS: ISSUE VOUCHER !", { progressBar: !0 });
                GetRequestedDetail();
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
        url: "PReq_d.aspx/GetReqItemDetail",
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
function showMDIssuedItemsDetail(obj) {
    var tr = $(obj).closest('tr');
    // console.log(tr);
    $.ajax({
        type: "POST",
        url: "PReq_d.aspx/GetIssuedItemDetail",
        data: '{ReqId:' + $($(tr).find('span:eq(0)')).html() + ',IssueId:' + $($(tr).find('span:eq(1)')).html() + '}',
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



