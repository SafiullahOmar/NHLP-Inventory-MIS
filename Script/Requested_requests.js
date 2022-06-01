//Front Page
$(function () {
    getDepartment();    
    $("#txtCode").change(function () {
        if (($(this).val() == "" )) {
            $('#dvTblRequests').html('');
        } else {
            GetReqDetailList($(this).val(),null,null);
        }
    });
    $("#ddlDepartment").change(function () {
        if (($(this).val() == "" || $('.province').val() == '' || $('.province').val() == '-1') && $('#txtCode').val() == '') {
            $('#dvTblRequests').html('');
        } else {
            alert('d');
            GetReqDetailList(null, $('.province').val(), $(this).val());
        }
    });
    $(".province").change(function () {
        if (($(this).val() == "" || $('#ddlDepartment').val() == '' || $('#ddlDepartment').val() == '-1') && $('#txtCode').val() == '') {
            $('#dvTblRequests').html('');
        } else {
            alert('hi');
            GetReqDetailList(null, $(this).val(), $('#ddlDepartment').val());
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
function GetReqDetailList(code, prov, Dep) {
  
        $.ajax({
            type: "POST",
            url: "requested_requests.aspx/getReqRequestD",
            data: '{Code:' + code + ',Prov:' + prov + ',Dep:' + Dep + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var $table = "<table id='tblRequestsD'  class='table table-xs nowrap table-striped ' width='100%' cellspacing='0'>";
                var header = "<thead><tr class='bg-lighten-blue' ><th>SN</th><th >(Code)</th><th >Request By</th><th >Duty Station</th><th >Department</th><th >Type</th><th >Position</th><th># Items Requested</th><th>Date</th><th>Downoald</th></tr></thead>";
                $table += header;
                var count = 1;
                $.each(data.d, function (i, x) {
                    var row = "<tr ><td >" + count + "</td>" +
                   "<td ><span>NHLP-Req-" + x.BCode + "</span></td>" +
                   "<td ><span>" + x.Name + "</span></td>" +
                   "<td ><span>" + x.Prov + "</span></td>" +
                    "<td ><span>" + x.Dept + "</span></td>" +
                   "<td ><span>" + x.RType + "</span></td>" +
                   "<td ><span>" + x.Pos + "</span></td>" +
                   "<td ><span>" + x.TItems + "</span></td>" +
                   "<td ><span>" + x.RDate + "</span></td>" +
                   "<td ><a id=\"aExample\" target='_blank' href='FormDownload.aspx?fRdetailAll=" + x.BCode + "'  runat=\"server\">Download</a></td>" +
                "</tr>";
                    $table += row;
                    count++;
                });
                $('#dvTblRequests').html($table);
                $table += "</table>";
                $('#tblRequestsD').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: true });

            },
            error: function (data) {
                alert("error found");
            }

        });
}
function Approve_transfer_items() {
    if ( confirm('Are You Sure to Approve the Selected Transfered Items ? Once You Approved Then You Are Not Able To ROLLBACK')) {
        var lst = new Array();
        $('#TblTransfItems tbody tr').each(function () {
            var detail = {};
            var tr = $(this).closest('tr');
            if ($(this).find("input:checkbox[name^='record']").is(":checked")) {

                detail.BCode = $($(tr).find('span:eq(0)')).html();
                detail.Quantity = $($(tr).find('span:eq(1)')).html();
                detail.IsDept = $($(tr).find('span:eq(2)')).html();
                detail.IsProv = $($(tr).find('span:eq(3)')).html();
                detail.TDate = $($(tr).find('span:eq(4)')).html();
                detail.RDept = $($(tr).find('span:eq(5)')).html();
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
        url: "requested_requests.aspx/GetDepartment",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlDepartment').empty();
            $.each(data.d, function (key, value) {
                $('#ddlDepartment').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlDepartment').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlDepartment option:first').attr("selected", "selected");

           
        },
        error: function (data) {
            alert("error found");
        }

    });
}




