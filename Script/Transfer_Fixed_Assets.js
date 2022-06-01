//Front Page
$(function () {
    getDepartment();
    $('#ddlItems').select2({ containerCssClass: "select-xs" });
    $('#txtTransferDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    $("#txtBrcd").change(function () {
        if ($('.province').val() == "-1") {
            $('#txtItemQuantity').val('');
        } else {
            GetStockedItemsByCode($(this).val(), $('.Tprovince').val());
        }
    });
 
    //btn Save
    $("#btnSave").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            Save_transfer_items();
        }
    });
  
    
    $('#lnkIssueItemInsert').click(function (e) {
        e.preventDefault();

        var flag = true;
        //if ($('#txtBrcd').val() == '') {
        //    $('#txtBrcd').css('background-color', '#FFAAAA'); flag = false;
        //} else { $('#txtBrcd').css('background-color', '#ffff'); }

        if ($('#txtBrcd').val() == '') {
            $('#txtBrcd').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtBrcd').css('background-color', '#ffff'); }

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
            var markup = "<tr><td><input type='checkbox' name='record'></td><td>" + (parseInt(count) + 1) + "</td><td><span  style='display:none'>" + $('#txtBrcd').val() + "</span><span  style='display:none'>" + $('#lblAssetID').html() + "</span>" + $('#lblItemName').html() + "</td><td><span id='Quantity'>" + $('#txtItemQuantity').val() + "</span></td></tr>";
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
        url: "Transfer_Fixed_Assets.aspx/GetWTransferItemsList",
        data: '{TProv:' +Tprov+ ',TDept:'+TDept+'}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table id='tblSearch'  class='table table-xs nowrap table-striped ' width='100%' cellspacing='0'>";
            var header = "<thead><tr class='bg-lighten-blue' ><th>SN</th><th >Items (Code)</th><th>Asset Name</th><th >Quantity</th><th >Issued Dept</th><th >Issued Province</th><th >Issued Date</th><th >Recieved Dept</th><th>Edit Options</th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td >" + count + "</td>" +
                   "<td ><span>" + x.BCode + "</span></td>" +
                   "<td ><span>" + x.AssetName + "</span></td>" +
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
        var jsObj = JSON.stringify({ bCode: $($(tr).find('span:eq(0)')).html(), Qunatity: $($(tr).find('span:eq(2)')).html(), IsDept: $($(tr).find('span:eq(3)')).html(), IsProv: $($(tr).find('span:eq(4)')).html(), RDept: $($(tr).find('span:eq(6)')).html(), TDate: $($(tr).find('span:eq(5)')).html() });

        // console.log(tr);
        $.ajax({
            type: "POST",
            url: "Transfer_Fixed_Assets.aspx/SetToFalse",
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

function GetStockedItemsByCode(obj,prov) {
    var obj = JSON.stringify({ ProvId: prov, Code: obj });
    $.ajax({
        type: "POST",
        url: "Transfer_Fixed_Assets.aspx/GetItemStockByCode",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#dvNumberInStocked').html("<span><strong>Asset Quantity In Store :</strong></span><span id='itmCountNumber'>" + data.d.Quantity + "</span> <br/> Asset Name : <span id='lblItemName'><strong>" + data.d.Item + " </strong></span><br/>AssetID :<span id='lblAssetID'>" + data.d.ID + " </span></div>");
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
        url: "Transfer_Fixed_Assets.aspx/SaveFormDetail",
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

    $('#txtBrcd').val('');
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
        url: "Transfer_Fixed_Assets.aspx/GetDepartment",
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





