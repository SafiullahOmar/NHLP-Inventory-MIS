//Front Page
$(function () {

    $('#txtRecievedDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    $('#txtInspectionDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    $("#btnUpdate").hide();
    $("#delete").hide();
    $("#btnSave").show();
    getDepartment();
    getClass();
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
    //btn Save
    $("#btnSave").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Save();
        }
    });
    //btn update
    $("#btnUpdate").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Update();
        }
    });
    //btn Delete
    $("#delete").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Delete();
        }
    });
    //lnk Item Insert
    $('#lnkShowItemInsertModal').click(function (e) {
        $('#MDItemInsert').modal('show');
        clearModal();
        e.preventDefault();

    });
    $('#btnAddtoItemList').click(function (e) {
        e.preventDefault();

        var flag = true;
        if ($('#ddlReviecedItemClass').val() == '-1') {
            $('#ddlReviecedItemClass').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#ddlReviecedItemClass').css('background-color', '#ffff'); }

        if ($('#ddlReviecedItemSubClass').val() == '-1') {
            $('#ddlReviecedItemSubClass').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#ddlReviecedItemSubClass').css('background-color', '#ffff'); }

        if ($('#ddlReviecedItems').val() == '-1') {
            $('#ddlReviecedItems').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#ddlReviecedItems').css('background-color', '#ffff'); }

        if ($('#txtQuantity').val() == '') {
            $('#txtQuantity').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtQuantity').css('background-color', '#ffff'); }

        if ($('#txtUnitPrice').val() == '') {
            $('#txtUnitPrice').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtUnitPrice').css('background-color', '#ffff'); }

        if ($('#txtTotalPrice').val() == '') {
            $('#txtTotalPrice').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtTotalPrice').css('background-color', '#ffff'); }

        var count = $('#tblItemInsertion tbody tr').length;
        if (flag) {
            var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + (parseInt(count) + 1) + "</td><td><span id='Item' style='display:none'>" + $('#ddlReviecedItems').val() + "</span>" + $('#ddlReviecedItems').find('option:selected').text() + "</td><td><span id='Quantity'>" + $('#txtQuantity').val() + "</span></td><td><span>" + $('#txtInvoiceQuantity').val() + "</span></td><td><span id='Modal' >" + $('#txtModal').val() + "</span></td><td><span id='Serial'>" + $('#txtSerial').val() + "</span></td><td><span  style='display:none'>" + $('#txtUnitPrice').val() + "</span><span style='display:none'>" + $('#txtItemRemarks').val() + "</span> <span>" + $('#txtTotalPrice').val() + "</span></td></tr>";
            $("#tblItemInsertion tbody").append(markup);
            $('#MDItemInsert').modal('hide');
            if (parseInt(count) == 0) {
                $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: true });
            }
            SumTAmount();
            clearModal();
        } else {

        }
    });
    $("#lnkShowItemRemove").click(function (e) {
        e.preventDefault();
        $("#tblItemInsertion tbody").find('input[name="record"]').each(function () {
            if ($(this).is(":checked")) {
                $(this).parents("tr").remove();
                SumTAmount();
            }
        });
    });
    var mtotal = 0;
    $('#txtQuantity').keyup(function () {
        if ($(this).val() != "") {
            mtotal = parseFloat($(this).val()) * parseFloat($('#txtUnitPrice').val());
            $('#txtTotalPrice').val(mtotal.toString());
        }
    });
    var mtotal2 = 0;
    $('#txtUnitPrice').keyup(function () {
        if ($(this).val() != "") {
            mtotal2 = parseFloat($(this).val()) * parseFloat($('#txtQuantity').val());
            $('#txtTotalPrice').val(mtotal2.toString());
        }
    });

    //inspection
    $('#lnkAddInpector').click(function (e) {
        e.preventDefault();
        var flag = true;

        if ($('#txtPosition').val() == '') {
            $('#txtPosition').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtPosition').css('background-color', '#ffff'); }

        if ($('#txtInspector').val() == '') {
            $('#txtInspector').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtInspector').css('background-color', '#ffff'); }

        var countInspector = $('#tblInspectors tbody tr').length;
        if (flag) {
            var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + (parseInt(countInspector) + 1) + "</td><td><span>" + $('#txtInspector').val() + "</span></td><td><span>" + $('#txtPosition').val() + "</span></td></tr>";
            $("#tblInspectors tbody").append(markup);
            $('#txtInspector').val(''); $('#txtPosition').val('');
            if (parseInt(countInspector) == 0) {
                $('#tblInspectors').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: true });
            }
        } else {

        }
    });
    $("#lnkDeleteInspector").click(function (e) {
        e.preventDefault();
        $("#tblInspectors tbody").find('input[name="record"]').each(function () {
            if ($(this).is(":checked")) {
                $(this).parents("tr").remove();
            }
        });
    });
    //Search
    $('#lnkSearch').click(function () {
        ShowRVouchersList();
    });

    //Inspection Printing
    $('#lnPrintInspectionD').click(function (e) {
        e.preventDefault();
        if (PrintValidation(e)) {
            printInspectorForm();
        }
    });

    //Download file
    //$('#lnkFile').click(function (e) {
    //    e.preventDefault();
    //    var url = $(this).attr('href');
    //    $('#lnkFile').trigger('change');
    //});
});
//Jscode
function Save2() {
    var formDetails = {};
    formDetails.RecieveDate = $('#txtRecievedDate').val();
    formDetails.Province = $('.province').val();
    formDetails.Department = $('#ddlDepartment').val();
    formDetails.Invoice = $('#txtInvoice').val();
    formDetails.PurchaseRef = $('#txtPurchaseRef').val();

    formDetails.Supplier = $('#txtSupplier').val();
    formDetails.InspectedBy = $('#txtInspectedBy').val();
    formDetails.InspectionDate = $('#txtInspectionDate').val();
    formDetails.Remarks = $('#txtRemarks').val();
    var lst = new Array();
    $('#tblItemInsertion tbody tr').each(function () {
        var detail = {};
        var tr = $(this).closest('tr');
        var Item = $(tr).find('span:eq(0)');
        var Quantity = $(tr).find('span:eq(1)');;
        var InvQuantity = $(tr).find('span:eq(2)');
        var Modal = $(tr).find('span:eq(3)');
        var Serial = $(tr).find('span:eq(4)');
        var Price = $(tr).find('span:eq(5)');
        var Remarks = $(tr).find('span:eq(6)');

        detail.ItemID = $(Item).html();
        detail.Quantity = $(Quantity).html();
        detail.InvoiceQuantity = $(InvQuantity).html();
        detail.Modal = $(Modal).html();
        detail.Serial = $(Serial).html();
        detail.Price = $(Price).html();
        detail.ItemRemarks = $(Remarks).html();
        lst.push(detail);
    });
    formDetails.ItemsList = lst;
    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "items_receiving_v.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Items are Successfully Saved !", "INV-MIS: GOODS VOUCHER RECIEVED !", { progressBar: !0 });
            //Clear components
            ClearForm();

        },
        error: function (data) {
            alert("error found");
        }

    });
}
function formValidation(e) {
    var flag = true;

    //if ($('#txtRecievedDate').val() == '') {
    //    $('#txtRecievedDate').css('background-color', '#FFAAAA');
    //    flag = false;
    //}
    //else { $('#txtRecievedDate').css('background-color', '#ffff'); }

    if ($('.province').val() == '-1') {
        $('.province').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('.province').css('background-color', '#ffff'); }
    if ($('#ddlDepartment').val() == '-1') {
        $('#ddlDepartment').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlDepartment').css('background-color', '#ffff'); }
    if ($('#txtInvoice').val() == '') {
        $('#txtInvoice').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtInvoice').css('background-color', '#ffff'); }
    if ($('#txtPurchaseRef').val() == '') {
        $('#txtPurchaseRef').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtPurchaseRef').css('background-color', '#ffff'); }
    if ($('#txtSupplier').val() == '') {
        $('#txtSupplier').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtSupplier').css('background-color', '#ffff'); }

    if ($('#txtInspectedBy').val() == '') {
        $('#txtInspectedBy').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtInspectedBy').css('background-color', '#ffff'); }

    if ($('#txtInspectionDate').val() == '') {
        $('#txtInspectionDate').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtInspectionDate').css('background-color', '#ffff'); }

    var count = $('#tblItemInsertion tbody tr').length;
    if (parseInt(count) == 0) {
        flag = false;
    }

    count = $('#tblInspectors tbody tr').length;
    if (parseInt(count) == 0) {
        flag = false;
    }

   // var fileUpload = $("#FileUpload1").get(0);
   // var files = fileUpload.files;
   // if (files.length == 0) {
    //    flag = false;
   // }
    if (flag) { return true } else {
        toastr.warning("Please enter informations in red background !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function PrintValidation(e) {
    var flag = true;

    if ($('#txtRecievedDate').val() == '') {
        $('#txtRecievedDate').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtRecievedDate').css('background-color', '#ffff'); }

    if ($('.province').val() == '-1') {
        $('.province').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('.province').css('background-color', '#ffff'); }
    if ($('#ddlDepartment').val() == '-1') {
        $('#ddlDepartment').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlDepartment').css('background-color', '#ffff'); }
    if ($('#txtInvoice').val() == '') {
        $('#txtInvoice').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtInvoice').css('background-color', '#ffff'); }
    if ($('#txtPurchaseRef').val() == '') {
        $('#txtPurchaseRef').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtPurchaseRef').css('background-color', '#ffff'); }
    if ($('#txtSupplier').val() == '') {
        $('#txtSupplier').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtSupplier').css('background-color', '#ffff'); }


    if ($('#txtInspectionDate').val() == '') {
        $('#txtInspectionDate').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtInspectionDate').css('background-color', '#ffff'); }


    if (flag) { return true } else {
        toastr.warning("Please enter informations in red background !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {
    $('#ddlDepartment').val('-1');
    $('#txtInvoice').val('');
    $('#txtPurchaseRef').val('');
    $('#txtSupplier').val('');
    $('#txtInspectedBy').val('');
    $('#txtInspectionDate').val('');
    $('#txtRemarks').val('');
    $('#tblItemInsertion tbody tr').remove();
    $('#tblInspectors tbody tr').remove();
    $('#cTotalAmount').html('');
   // document.getElementById('FileUpload1').value = null;
}
function EditDetail(obj) {
    var td = obj.parentNode;
    row = obj.parentNode.parentNode;
    var span = $(td).find('span:eq(0)');
    var SrSpan = $(td).find('span:eq(1)');
    var ID = span.html();
    var Sr = SrSpan.html();
    $('#hdnRVoucherItemID').val(ID);
    $('#hdnRVoucherSr').val(Sr);
    var obj = JSON.stringify({ GRVID: ID, Sr: Sr });
    $.ajax({
        type: "POST",
        url: "items_receiving_v.aspx/GetRVDetailByID",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            $("#tblItemInsertion tbody tr").remove();
            $("#tblInspectors tbody tr").remove();
            var count = $('#tblItemInsertion tbody tr').length;
            $.each(r.d.ItemsList, function (i, x) {
                var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + (parseInt(count) + 1) + "</td><td><span id='Item' style='display:none'>" + x.ItemID + "</span>" + x.ItemName + "</td><td><span id='Quantity'>" + x.Quantity + "</span></td><td><span>" + x.InvoiceQuantity + "</span></td><td><span id='Modal' >" + x.Modal + "</span></td><td><span id='Serial'>" + x.Serial + "</span></td><td><span  style='display:none'>" + x.Price + "</span><span style='display:none'>x.remarks</span> <span>" + (parseFloat(x.Price) * parseFloat(x.Quantity)) + "</span></td></tr>";
                $("#tblItemInsertion tbody").append(markup);
                count++;
               // if (parseInt(count) == 0) {
                   
                //}
            });
            //$("#tblItemInsertion").DataTable().destroy()
            $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false, scrollX: !0 });
            $('#MDSearch').modal('hide');
            SumTAmount();
            count = 0;
            $.each(r.d.InspectosList, function (i, x) {
                var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + (parseInt(count) + 1) + "</td><td><span>" + x.Name + "</span></td><td><span>" + x.Position + "</span></td></tr>";
                $("#tblInspectors tbody").append(markup);
                count++;
                //if (parseInt(count) == 0) {
                    
                //}
            });
            //$("#tblInspectors").DataTable().destroy()
            $('#tblInspectors').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false, "bSort": false, "bInfo": false, "bAutoWidth": false });

            $('#txtRecievedDate').val(r.d.RecieveDate);
            $('.province').val(r.d.Province);
            $('#ddlDepartment').val(r.d.Department);
            $('#txtInvoice').val(r.d.Invoice);
            $('#txtPurchaseRef').val(r.d.PurchaseRef);

            $('#txtSupplier').val(r.d.Supplier);
            $('#hdnSerialNumber').val(r.d.SerialNumber);
            // $('#txtInspectedBy').val(r.d.InspectedBy);
            $('#txtInspectionDate').val(r.d.InspectionDate);
            $('#txtRemarks').val(r.d.Remarks);
           // $('#lnkFile').attr('href', "FormDownload.aspx?RvfilePath=" + r.d.Path);
           // $('#lnkFile').attr('target', '_blank');
           // $('#lnkFile').text('Downoald');

            $('#btnSave').hide();
            $('#btnUpdate').show();
            // $('.delete').show();

            toastr.info("Please enter correct information !", "INV-MIS: Edit Alert !", { progressBar: !0 });
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function Update2() {
    var formDetails = {};
    formDetails.GRVID = $('#hdnRVoucherItemID').val();
    formDetails.RecieveDate = $('#txtRecievedDate').val();
    formDetails.Province = $('.province').val();
    formDetails.Department = $('#ddlDepartment').val();
    formDetails.Invoice = $('#txtInvoice').val();
    formDetails.PurchaseRef = $('#txtPurchaseRef').val();

    formDetails.Supplier = $('#txtSupplier').val();
    formDetails.InspectedBy = $('#txtInspectedBy').val();
    formDetails.InspectionDate = $('#txtInspectionDate').val();
    formDetails.Remarks = $('#txtRemarks').val();
    formDetails.Sr = $('#hdnRVoucherSr').val();
    var lst = new Array();
    $('#tblItemInsertion tbody tr').each(function () {
        var detail = {};
        var tr = $(this).closest('tr');
        var Item = $(tr).find('span:eq(0)');
        var Quantity = $(tr).find('span:eq(1)');;
        var InvQuantity = $(tr).find('span:eq(2)');
        var Modal = $(tr).find('span:eq(3)');
        var Serial = $(tr).find('span:eq(4)');
        var Price = $(tr).find('span:eq(5)');
        var Remarks = $(tr).find('span:eq(6)');

        detail.ItemID = $(Item).html();
        detail.Quantity = $(Quantity).html();
        detail.InvoiceQuantity = $(InvQuantity).html();
        detail.Modal = $(Modal).html();
        detail.Serial = $(Serial).html();
        detail.Price = $(Price).html();
        detail.ItemRemarks = $(Remarks).html();
        lst.push(detail);
    });
    formDetails.ItemsList = lst;
    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "items_receiving_v.aspx/UpdateFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Items are Successfully Updated !", "INV-MIS: VOUCHER UPDATATION !", { progressBar: !0 });
            $('#btnSave').show();
            $('#btnUpdate').hide();
            //Clear components

            ClearForm();

        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getClass() {
    $.ajax({
        type: "POST",
        url: "items_receiving_v.aspx/GetClass",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlReviecedItemClass').empty();
            $.each(data.d, function (key, value) {
                $('#ddlReviecedItemClass').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlReviecedItemClass').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlReviecedItemClass option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getSubClass(obj) {
    $.ajax({
        type: "POST",
        url: "items_receiving_v.aspx/GetSubClass",
        data: '{ClassID:' + $(obj).val() + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlReviecedItemSubClass').empty();
            $.each(data.d, function (key, value) {
                $('#ddlReviecedItemSubClass').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlReviecedItemSubClass').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlReviecedItemSubClass option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getDepartment() {
    $.ajax({
        type: "POST",
        url: "items_receiving_v.aspx/GetDepartment",
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
function GetRecievedItems(obj) {
    $.ajax({
        type: "POST",
        url: "items_receiving_v.aspx/GetRecievedItems",
        data: JSON.stringify({ SubClassID: $(obj).val() }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlReviecedItems').empty();
            $.each(data.d, function (key, value) {
                $('#ddlReviecedItems').append($("<option></option>").val(value.ID).html(value.Item));
            });
            $('#ddlReviecedItems').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlReviecedItems option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function clearModal() {
    $('#ddlReviecedItems').val("-1");
    $('#txtQuantity').val("");
    $('#txtInvoiceQuantity').val("");
    $('#txtModal').val("");
    $('#txtSerial').val("");
    $('#txtUnitPrice').val("");
    $('#txtTotalPrice').val("");
    $('#txtItemRemarks').val("");
}
function SumTAmount() {
    var ktotal = 0;
    $('#tblItemInsertion tbody tr').each(function () {
        var tr = $(this).closest('tr');
        var Amount = $(tr).find('span:eq(7)');
        ktotal += parseFloat($(Amount).html());
    });
    var count = $('#tblItemInsertion tbody tr').length;
    if (ktotal != '') {
        $("#cTotalAmount").html('');
        var markup2 = "Total Amount  for <code> " + (parseInt(count)) + "</code> items are : <code>" + ktotal.toString() + "</code>";
        $("#cTotalAmount").html(markup2);
    } else { $("#cTotalAmount").html(''); }
}
var row = null;
function ShowRVouchersList() {
    $.ajax({
        type: "POST",
        url: "items_receiving_v.aspx/GetReceivingVoucherList",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table id='tblreceivingVoucher'  class='table table-xs nowrap table-striped scroll-horizontal'>";
            var header = "<thead><tr class='bg-lighten-blue' ><th>SN</th><th >Department</th><th >Province</th><th >Invoice</th><th >Supplier</th><th >Recieved Date</th><th >Total Items</th><th>Total Cost</th><th >Edit</th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td >" + count + "</td>" +
                   "<td ><span>" + x.Department + "  </span></td>" +
                   "<td ><span>" + x.Province + "</span></td>" +
                    "<td ><span>" + x.Invoice + "</span></td>" +
                     "<td ><span>" + x.Supplier + "</span></td>" +
                      "<td><span>" + x.RecieveDate + "</span></td>" +
                       "<td ><span>" + x.TotalItems + "</span></td>" +
                      "<td  ><span>" + x.TotalCost + "</span></td>" +
                   (x.Edit==1?"<td><a onclick='EditDetail(this)' class='btn-sm btn-green edit' href='#'><i class='icon-edit2'></i></a><span id='' style='display:none'>" + x.GRVID + "</span><span id='' style='display:none'>" + x.Sr + "</span></td>":"<td></td>") +
                "</tr>";
                $table += row;
                count++;
            });
            $('#tblSearch').html($table);
            $table += "</table>";
            $('#tblreceivingVoucher').DataTable({ scrollX: true });
            $('#MDSearch').modal('show');
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function printInspectorForm() {
    var formDetails;
    formDetails = "RDate=" + $('#txtRecievedDate').val();
    formDetails += "&Province=" + $('.province').find("option:selected").text();
    formDetails += "&Dept=" + $('#ddlDepartment').find("option:selected").text();
    formDetails += "&Invoice=" + $('#txtInvoice').val();
    formDetails += "&Contract=" + $('#txtPurchaseRef').val();
    formDetails += "&Supplier=" + $('#txtSupplier').val();
    formDetails += "&IDate=" + $('#txtInspectionDate').val();
    var countLoop = 0;
    $('#tblInspectors tbody tr').each(function () {
        var detail = {};
        var tr = $(this).closest('tr');
        var Name = $(tr).find('span:eq(0)');
        var Pos = $(tr).find('span:eq(1)');
        countLoop += 1;
        formDetails += "&name" + countLoop + "=" + $(Name).html();
        formDetails += "&pos" + countLoop + "=" + $(Pos).html();
    });
    formDetails += "&LoopCount=" + countLoop;
    window.open('FormDownload.aspx?' + formDetails);

}
function Save() {
    if (window.FormData !== undefined) {
        //var fileUpload = $("#FileUpload1").get(0);
        //var files = fileUpload.files;
        //if (files.length > 0) { }
            var formDetails = new FormData();
            formDetails.append("RecieveDate", $('#txtRecievedDate').val());
            formDetails.append("Province", $('.province').val());
            formDetails.append("Department", $('#ddlDepartment').val());
            formDetails.append("Invoice", $('#txtInvoice').val());
            formDetails.append("PurchaseRef", $('#txtPurchaseRef').val());

            formDetails.append("Supplier", $('#txtSupplier').val());
            //formDetails.InspectedBy = $('#txtInspectedBy').val();
            formDetails.append("InspectionDate", $('#txtInspectionDate').val());
            formDetails.append("Remarks", $('#txtRemarks').val());
            var lst = new Array();
            var countItemsLoop = 0;
            $('#tblItemInsertion tbody tr').each(function () {
                var detail = {};
                var tr = $(this).closest('tr');
                var Item = $(tr).find('span:eq(0)');
                var Quantity = $(tr).find('span:eq(1)');;
                var InvQuantity = $(tr).find('span:eq(2)');
                var Modal = $(tr).find('span:eq(3)');
                var Serial = $(tr).find('span:eq(4)');
                var Price = $(tr).find('span:eq(5)');
                var Remarks = $(tr).find('span:eq(6)');
                countItemsLoop += 1;
                formDetails.append("ItemID" + countItemsLoop, $(Item).html());
                formDetails.append("Quantity" + countItemsLoop, $(Quantity).html());
                formDetails.append("InvoiceQuantity" + countItemsLoop, $(InvQuantity).html());
                formDetails.append("Modal" + countItemsLoop, $(Modal).html());
                formDetails.append("Serial" + countItemsLoop, $(Serial).html());
                formDetails.append("Price" + countItemsLoop, $(Price).html());
                formDetails.append("ItemRemarks" + countItemsLoop, $(Remarks).html());
                // lst.push(detail);
            });
            formDetails.append("ItemsLoopCount", countItemsLoop);
            var InspcountLoop = 0;
            $('#tblInspectors tbody tr').each(function () {
                var detail = {};
                var tr = $(this).closest('tr');
                var Name = $(tr).find('span:eq(0)');
                var Pos = $(tr).find('span:eq(1)');
                InspcountLoop += 1;
                formDetails.append("InspN" + InspcountLoop, $(Name).html());
                formDetails.append("Pos" + InspcountLoop, $(Pos).html());
            });
            formDetails.append("InspLoopCount", InspcountLoop);
           // for (var i = 0; i < files.length; i++) {
              //  formDetails.append(files[i].name, files[i]);
            //}
            formDetails.append("action", "SAVE");
            //formDetails.ItemsList = lst;
            // var jsonObject = JSON.stringify({ formDetails: formDetails });
            $.ajax({
                url: '../RF/Recieved_Items.ashx',
                data: formDetails,
                processData: false,
                contentType: false,
                type: 'POST',
                success: function (data) {
                    var grvid=data.substr(0, data.indexOf(',', 1));
                    var sr=data.substr(data.indexOf(',', 1) + 1, data.length);
                    
                    toastr.success("Items are Successfully Saved !", "INV-MIS: GOODS VOUCHER RECIEVED !", { progressBar: !0 });
                    //Clear components
                    ClearForm();
                    window.open('FormDownload.aspx?' + 'fRecVoucher=Yes&grvid=' +grvid + '&sr='+sr+'');
                },
                error: function (data) {
                    alert("error found");
                }

            });
        
    }
}
function Update() {
    if (window.FormData !== undefined) {
        //var fileUpload = $("#FileUpload1").get(0);
        //var files = fileUpload.files;
       // if (files.length > 0) { }
            var formDetails = new FormData();
            formDetails.append("RecieveDate", $('#txtRecievedDate').val());
            formDetails.append("Province", $('.province').val());
            formDetails.append("Department", $('#ddlDepartment').val());
            formDetails.append("Invoice", $('#txtInvoice').val());
            formDetails.append("PurchaseRef", $('#txtPurchaseRef').val());

            formDetails.append("Supplier", $('#txtSupplier').val());
            formDetails.append("SerialNumber", $('#hdnSerialNumber').val());
            //formDetails.InspectedBy = $('#txtInspectedBy').val();
            formDetails.append("InspectionDate", $('#txtInspectionDate').val());
            formDetails.append("Remarks", $('#txtRemarks').val());
            var lst = new Array();
            var countItemsLoop = 0;
            $('#tblItemInsertion tbody tr').each(function () {
                var detail = {};
                var tr = $(this).closest('tr');
                var Item = $(tr).find('span:eq(0)');
                var Quantity = $(tr).find('span:eq(1)');;
                var InvQuantity = $(tr).find('span:eq(2)');
                var Modal = $(tr).find('span:eq(3)');
                var Serial = $(tr).find('span:eq(4)');
                var Price = $(tr).find('span:eq(5)');
                var Remarks = $(tr).find('span:eq(6)');
                countItemsLoop += 1;
                formDetails.append("ItemID" + countItemsLoop, $(Item).html());
                formDetails.append("Quantity" + countItemsLoop, $(Quantity).html());
                formDetails.append("InvoiceQuantity" + countItemsLoop, $(InvQuantity).html());
                formDetails.append("Modal" + countItemsLoop, $(Modal).html());
                formDetails.append("Serial" + countItemsLoop, $(Serial).html());
                formDetails.append("Price" + countItemsLoop, $(Price).html());
                formDetails.append("ItemRemarks" + countItemsLoop, $(Remarks).html());
                // lst.push(detail);
            });
            formDetails.append("ItemsLoopCount", countItemsLoop);
            var InspcountLoop = 0;
            $('#tblInspectors tbody tr').each(function () {
                var detail = {};
                var tr = $(this).closest('tr');
                var Name = $(tr).find('span:eq(0)');
                var Pos = $(tr).find('span:eq(1)');
                InspcountLoop += 1;
                formDetails.append("InspN" + InspcountLoop, $(Name).html());
                formDetails.append("Pos" + InspcountLoop, $(Pos).html());
            });
            formDetails.append("InspLoopCount", InspcountLoop);
           // for (var i = 0; i < files.length; i++) {
            //    formDetails.append(files[i].name, files[i]);
           // }
            formDetails.append("Sr", $('#hdnRVoucherSr').val());
            formDetails.append("GRVID", $('#hdnRVoucherItemID').val());
            formDetails.append("action", "UPDATE");
            $.ajax({
                url: '../RF/Recieved_Items.ashx',
                data: formDetails,
                processData: false,
                contentType: false,
                type: 'POST',
                success: function (data) {
                    toastr.success("Changes are Successfully Saved !", "INV-MIS: GOODS Recieved Vouchers Changed !", { progressBar: !0 });
                    //Clear components
                    ClearForm();
                    $('#btnSave').show();
                    $('#btnUpdate').hide();

                },
                error: function (data) {
                    alert("error found");
                }

            });
        
    }
}

//delete

//function Delete() {
//    var formDetails = {};

//    formDetails.ID = $('#hdnPcId').val();
//    var jsonObject = JSON.stringify({ formDetails: formDetails });

//    $.ajax({
//        type: "POST",
//        url: "Class.aspx/DeletePC",
//        data: jsonObject,
//        dataType: "json",
//        async: false,
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            if (data.d == true) {

//                $('.save').show();
//                $('.update').hide();
//                $('.delete').hide();
//                ClearForm();
//                // call function
//                ShowList();
//                $.alert({
//                    icon: 'glyphicon glyphicon-saved',
//                    closeIcon: true,
//                    title: 'Alert!',
//                    animation: 'news',
//                    closeAnimation: 'news',
//                    theme: 'light',
//                    type: 'green',
//                    typeAnimated: true,
//                    content: 'You can not delete this record unless you delete child record.'
//                });
//            }
//            else {

//                $.alert({
//                    icon: 'glyphicon glyphicon-saved',
//                    closeIcon: true,
//                    title: 'Form Delete Alert!',
//                    animation: 'news',
//                    closeAnimation: 'news',
//                    theme: 'dark',
//                    type: 'green',
//                    typeAnimated: true,
//                    content: '<strong><font style="color:white;">Information Has been Deleted from system!</font></strong>'
//                });

//                //Clear components
//                ClearForm();
//                $('.save').show();
//                $('.update').hide();
//                $('.delete').hide();
//                // call function
//                ShowList();

//            }


//        },
//        error: function (data) {
//            alert("error found");
//        }

//    });
//}

