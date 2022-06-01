//Front Page
$(function () {
    
   // $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: !0 });
    GetRequestedDetail();

  
});
//Jscode
function GetRequestedDetail() {
    $.ajax({
        type: "POST",
        url: "recReq_d.aspx/GetRecItemsReqDetail",
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
                    var markup = "<tr class='far'><td>" + x.SNo + "</td><td>" + x.Province + "</td><td>" + x.Department + "</td><td>" + x.RDate + "</td><td>" + x.RBY + "</td><td>" + x.Invoice + "</td><td><span>" + x.Ref + "</span></td><td>" + x.Supplier + "</td><td>" + x.InspDate + "</td><td> <a id=\"aExample\" target='_blank' href='FormDownload.aspx?fRecVoucher=Yes&grvid=" + x.GRVID + "&sr=" + x.Sr + "'  runat=\"server\">Recieve Voucher</a></td></tr>";
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


