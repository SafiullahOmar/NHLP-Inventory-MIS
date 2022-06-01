//Front Page
$(function () {
    $('#dvTblVouchers').hide();
    getDepartment();
    $("#ddlDepartment").change(function () {
        if (($(this).val() == "-1") || ($('.province').val() == "-1")) {
            $('#dvTblVouchers').hide();
        } else {
            getVoucher($(this).val(), $('.province').val());
        }
    });
    $("#ddlSr").change(function () {
        if (($(this).val() == "-1")) {
            $('#dvTblVouchers').hide();
        } else {
            $('#dvTblVouchers').show();
            GetRequestedDetail($(this).val());
        }
    });
    $(".province").change(function () {
        if (($(this).val() == "-1") || ($('#ddlDepartment').val() == "-1")) {
            $('#dvTblVouchers').hide();
        } else {
            // getVoucher($('#ddlDepartment').val(), $(this).val());
        }
    });
    //btn Save
    $("#btnSave").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Save()
        }
    });
});
//Jscode
function GetRequestedDetail(obj) {
    var json = JSON.stringify({ id: obj });
    $.ajax({
        type: "POST",
        url: "recReq-upload.aspx/GetVoucherDetail",
        data: json,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //var $table = "<table id='tblItemInsertion'  width='98%' class='table table-xs nowrap table-striped'>";
            //var header = "<thead><tr ><th>SN</th><th style='text-align:center;'>Req #</th><th style='text-align:center;'>Req Type</th><th style='text-align:center;'>Requested By</th><th style='text-align:center;'>Position</th><th style='text-align:center;'>Location</th><th style='text-align:center;'>Unit</th><th style='text-align:center;'>(#)T Items Req</th><th style='text-align:center;'>(#)T Items Issued</th><th style='text-align:center;'>Issue #</th><th style='text-align:center;'>Downoald</th><th style='text-align:center;'></th></tr></thead>";
            //$table += header;
            $('#tblItemInsertion').DataTable().clear().draw();
            $("#tblItemInsertion").DataTable().destroy();
            if (!jQuery.isEmptyObject(data.d)) {
                $.each(data.d, function (i, x) {
                    var count = $('#tblItemInsertion tbody tr').length;
                    var markup = "<tr class='far'><td>" + x.SNo + "</td><td>" + x.Province + "</td><td>" + x.Department + "</td><td>" + x.RDate + "</td><td>" + x.RBY + "</td><td>" + x.Invoice + "</td><td><span>" + x.Ref + "</span></td><td>" + x.Supplier + "</td><td>" + x.InspDate + "</td>" +
                        "<td> <a id=\"aExample\" target='_blank' href='FormDownload.aspx?fRecVoucher=Yes&grvid=" + x.GRVID + "&sr=" + x.Sr + "'  runat=\"server\">Recieve Voucher</a></td>" +
                        (x.Scanfile == "Exist" ? "<td> <a id=\"aExample2\" target='_blank' href='FormDownload.aspx?RecVoucherScanFile=Yes&grvid=" + x.GRVID + "&P=" + x.Path + "' runat=\"server\">Uploaded Scan File</a></td>" : "<td>Not Uploaded</td>") +
                        "</tr>";
                    // $table += markup;
                    $("#tblItemInsertion").append(markup);

                });
            }
            //else {
            //    $("#tblItemInsertion").DataTable().destroy()
            //    $('#tblItemInsertion').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: true });
            //}


            $('#tblItemInsertion').DataTable({
                "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth":
                    false, scrollX: true
            });
            //$('#dvIssuetbl').html($table);
            //$table += "</table>";
            //$('#tblItemInsertion').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: true });

        },
        error: function (data) {
            alert("error found");
        }

    });
}
function Approve_transfer_items() {
    if (confirm('Are You Sure to Approve the Selected Transfered Items ? Once You Approved Then You Are Not Able To ROLLBACK')) {
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
    var count = $('#tblItemInsertion tbody tr').length;
    if (parseInt(count) == 0) {
        flag = false;
    }

    if ($('.ddProvince').val() == '-1') {
        $('.ddProvince').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('.ddProvince').css('background-color', '#ffff'); }
    if ($('#ddlDepartment').val() == '-1') {
        $('#ddlDepartment').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlDepartment').css('background-color', '#ffff'); }
    if ($('#ddlSr').val() == '-1') {
        $('#ddlSr').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlSr').css('background-color', '#ffff'); }


    if (flag) { return true } else {
        toastr.warning("Please Check below Rows from the table ,Enter valid informations  !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {
    $('#dvTblVouchers').hide();
    $('#ddlSr').val('-1');
    document.getElementById('FileUpload1').value = null;
}
function getDepartment() {
    $.ajax({
        type: "POST",
        url: "recReq-upload.aspx/GetDepartment",
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
function getVoucher(dept, prov) {
    $.ajax({
        type: "POST",
        url: "recReq-upload.aspx/GetVouchers",
        data: '{Dept:' + dept + ',Prov:' + prov + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlSr').empty();
            $.each(data.d, function (key, value) {
                $('#ddlSr').append($("<option></option>").val(value.GRVID).html(value.Serial));
            });
            $('#ddlSr').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlSr option:first').attr("selected", "selected");


        },
        error: function (data) {
            alert("error found");
        }

    });
}
function Save() {
    if (window.FormData !== undefined) {
        var fileUpload = $("#FileUpload1").get(0);
        var files = fileUpload.files;
        if (files.length > 0) {
            var formDetails = new FormData();
            formDetails.append("GRVID", $('#ddlSr').val());
            for (var i = 0; i < files.length; i++) {
                formDetails.append(files[i].name, files[i]);
            }
            formDetails.append("action", "SAVEFILE");
            //formDetails.ItemsList = lst;
            // var jsonObject = JSON.stringify({ formDetails: formDetails });
            $.ajax({
                url: '../RF/Recieved_Items.ashx',
                data: formDetails,
                processData: false,
                contentType: false,
                type: 'POST',
                success: function (data) {
                    if (data == 'True')

                        toastr.warning("File is NOT UPLOADED ! The file is already added in system", "INV-MIS: GOODS RECIEVE VOUCHER !", { progressBar: !0 });
                    else if (data == 'False')
                        toastr.success("File is Successfully Uploaded !", "INV-MIS: GOODS RECIEVE VOUCHER !", { progressBar: !0 });
                    //Clear components
                    ClearForm();
                },
                error: function (data) {
                    alert("error found");
                }

            });

        }
    }
}



