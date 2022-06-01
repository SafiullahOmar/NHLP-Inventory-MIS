//Front Page
$(function () {
    $('#pnlCode').hide();
    $("#btnUpdate").hide();
    $("#delete").hide();
    $("#btnSave").show();
    $('#txtIssueDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    //getClass();
    getSubDepartment();
    //$("#ddlClass").change(function () {
    //    if ($(this).val() == "-1") {
    //        $('#ddlSubCategory').empty();
    //        $('#ddlSubCategory').attr("disabled", "disabled");
    //    } else {
    //        $.ajax({
    //            type: "POST",
    //            url: "COFID.aspx/GetSubClassLists",
    //            data: '{ClassID:' + $('#ddlClass').val() + '}',
    //            dataType: "json",
    //            contentType: "application/json; charset=utf-8",
    //            success: function (data) {
    //                $('#ddlSubCategory').attr("disabled", false);
    //                $('#ddlSubCategory').empty();
    //                $.each(data.d, function (key, value) {
    //                    $('#ddlSubCategory').append($("<option></option>").val(value.ID).html(value.Name));
    //                });
    //                $('#ddlSubCategory').prepend("<option value='-1' selected='true'>-Select-</option>");
    //                $('#ddlSubCategory option:first').attr("selected", "selected");
    //            },
    //            error: function (data) {
    //                alert("error found");
    //            }

    //        });

    //    }
    ////});

    //$("#ddlSubCategory").change(function () {
    //    if ($(this).val() == "-1") {
    //        $('#ddlItem').empty();
    //        $('#ddlItem').attr("disabled", "disabled");
    //    } else {
    //        GetItemsD($(this));
    //    }
    //});
    $(".province").change(function () {

        $('#lblAsset').text('');
        $('#lblQuantity').text('');
        $('#txtQuantity').val('');
        $('#txtBarcodeNumber').val('');
        if ($(this).val() != "-1") {
              ShowCOFIList($(this).val());

        } else {
            $('#dtTableDetail').html('');
        }
    });
    //$("#ddlDepartment").change(function () {
    //    if ($(this).val() != "-1" && $(".province").val() != "-1") {
    //        ShowCOFIList( $(this).val(),$('.province').val());

    //    } else {
    //        $('#dtTableDetail').html('');
    //    }
    //});
    //btn Save
    $("#txtBarcodeNumber").change(function () {
        if ($(this).val() != "" && $(".province").val() != "-1") {
            GetItemStockByCode($(".province").val(), $(this).val());
        } else {

        }
    });

    $('#txtQuantity').change(function (e) {
        if ($(this).val() > parseFloat($('#lblQuantity').text())) {
            $(this).css('background-color', '#FFAAAA');
            alert("The Quantity is More than Stocked Quantity");
            $(this).val('');
        }
        else if (parseFloat($(this).val()) == 0) {
            alert("The Quantity Can't be Zero");
            $(this).css('background-color', '#FFAAAA');
            $(this).val('');
        }
        else if ($(this).val() == "") {
            $(this).css('background-color', '#ffff');
            alert("The Asset Quantity Can't be Zero");
            $(this).val('');
        }
        else if ($('#lblQuantity').text() == "") {
            $('#txtQuantity').css('background-color', '#FFAAAA');
            alert("The Asset Quantity Can't be Zero");
            $(this).val('');
        }

    });

    $("#btnSave").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {
            if ($('#lblQuantity').text() != "") {
                Save();
            } else {
                toastr.warning("NO Asset Quantity is Present !", "INV-MIS: Validation Alert !", { progressBar: !0 });
            }
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


});
//Jscode
function Save() {

    var formDetails = {};
    formDetails.Department = $('#ddlSubComponent').val();
    formDetails.Province = $('.province').val();
    formDetails.bC = $('#txtBarcodeNumber').val();
    formDetails.Quantity = $('#txtQuantity').val();
    formDetails.IssueDate = $('#txtIssueDate').val();
    formDetails.Issuer = $('#txtIssuer').val();
    formDetails.Position = $('#txtPosition').val();
    formDetails.Reciever = $('#txtReciever').val();
    formDetails.Remarks = $('#txtRemarks').val();

    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "COFID.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Asset is Issued to the system !", "INV-MIS: Successfully Saved !", { progressBar: !0 });
            //Clear components
            ClearForm();
            //call function
            //  ShowCOFIList($('#ddlDepartment').val(), $('.province').val());

        },
        error: function (data) {
            alert("error found");
        }

    });
}
var row = null;
function ShowCOFIList( Prov) {
    $.ajax({
        type: "POST",
        url: "COFID.aspx/GetCOFILists",
        data: '{Prov:' + Prov + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table id='tblD'  width='98%' class='table table-striped table-bordered  table-hover'>";
            var header = "<thead><tr ><th>SN</th><th style='text-align:center;'>Item</th><th style='text-align:center;'>Serial #</th><th style='text-align:center;'>Code</th><th style='text-align:center;'>Quantity</th><th style='text-align:center;'>Reciever</th><th style='text-align:center;'>Sub Component</th><th style='text-align:center;'>Position</th><th style='text-align:center;'>Edit</th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td style='text-align:center;'>" + count + "<span  style='display:none'>" + x.Id + "</span><span  style='display:none'>" + x.ItemId + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.Item + "  </span></td>" +
                    "<td style='text-align:center;'><span>" + x.Serial + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.bC + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.Quantity + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.Reciever + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.Department + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.Position + "</span></td>" +
                    (x.Edit == true ? "<td><a onclick='DeleteD(this)' class='btn-sm btn-danger edit' href='#'>Delete</a><span id='spID' style='display:none'>" + x.ItemId + "</span><span id='spID' style='display:none'>" + x.bC + "</span><span id='spID' style='display:none'>" + x.Reciever + "</span></td>" : "<td></td>") +
                    "</tr>";
                $table += row;
                count++;
            });
            $('#dtTableDetail').html($table);
            $table += "</table>";
            $('#tblD').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: true });
            $('#dtTableDetail').show();
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function GetItemStockByCode(Prov, Code) {
    $.ajax({
        type: "POST",
        url: "COFID.aspx/GetItemStockByCode",
        data: JSON.stringify({ ProvId: Prov, Code: Code }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d != '') {

                $('#lblQuantity').text(data.d.Quantity);
                $('#lblAsset').text(data.d.Item);

            }
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function formValidation(e) {
    var flag = true;

    if ($('#txtQuantity').val() == '') {
        $('#txtQuantity').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtQuantity').css('background-color', '#ffff'); }

    if ($('#txtPosition').val() == '') {
        $('#txtPosition').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtPosition').css('background-color', '#ffff'); }

    if ($('#txtReciever').val() == '') {
        $('#txtReciever').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtReciever').css('background-color', '#ffff'); }


    if ($('#ddlDepartment').val() == '-1') {
        $('#ddlDepartment').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlDepartment').css('background-color', '#ffff'); }
    if ($('#ddlItem').val() == '-1') {
        $('#ddlItem').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlItem').css('background-color', '#ffff'); }
    if ($('#ddlSubCategory').val() == '-1') {
        $('#ddlSubCategory').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlSubCategory').css('background-color', '#ffff'); }
    if ($('#ddlClass').val() == '-1') {
        $('#ddlClass').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlClass').css('background-color', '#ffff'); }
    if ($('.province').val() == '-1') {
        $('.province').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('.province').css('background-color', '#ffff'); }


    if ($('#txtIssueDate').val() == '') {
        $('#txtIssueDate').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtIssueDate').css('background-color', '#ffff'); }

    if ($('#txtIssuer').val() == '') {
        $('#txtIssuer').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtIssuer').css('background-color', '#ffff'); }

    if ($('#txtBarcodeNumber').val() == '') {
        $('#txtBarcodeNumber').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtBarcodeNumber').css('background-color', '#ffff'); }

    if (flag) { return true } else {
        toastr.warning("Please enter informations in red backhground !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {
    $('#txtQuantity').val('');
    $('#txtPrice').val('');
    $('#txtModal').val('');
    $('#txtSerial').val('');
    $('#txtPosition').val('');
    $('#txtReciever').val('');
    $('#txtRemarks').val('');

    $('#lblAsset').text('');
    $('#lblQuantity').text('');
    $('#txtBarcodeNumber').val('');
}
function EditDetail(obj) {
    var td = obj.parentNode;
    row = obj.parentNode.parentNode;
    var span = $(td).find('span');
    var ID = span.html();
    $('#hdnItemID').val(ID);
    var obj = JSON.stringify({ ItemID: ID });
    $.ajax({
        type: "POST",
        url: "Products_Items.aspx/GetDetailByID",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (r) {

            $('#ddlSubCategory').val(r.d.SubClassID);
            $('#ddlUnit').val(r.d.UnitID);
            $('#ddlAssetsType').val(r.d.AssetType);
            $('#ddlKeepingType').val(r.d.KeepingType);
            $('#txtName').val(r.d.Name);
            $('#btnSave').hide();
            $('#btnUpdate').show();
            // $('.delete').show();

            toastr.info("Please enter correct information !", "INV-MIS:  Alert !", { progressBar: !0 });
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function Update() {
    var formDetails = {};
    formDetails.Name = $('#txtName').val();
    formDetails.SubClassID = $('#ddlSubCategory').val();
    formDetails.UnitID = $('#ddlUnit').val();
    formDetails.AssetType = $('#ddlAssetsType').val();
    formDetails.KeepingType = $('#ddlKeepingType').val();
    formDetails.ItemID = $('#hdnItemID').val();
    var jsonObject = JSON.stringify({ formDetails: formDetails });

    $.ajax({
        type: "POST",
        url: "Products_Items.aspx/UpdateFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Information in the system are updated!", "INV-MIS: Successfully Updated  !", { progressBar: !0 });
            //Clear components
            ClearForm();
            $('#btnSave').show();
            $('#btnUpdate').hide();
            //$('.delete').hide();
            // call function
            ShowList();
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getClass() {
    $.ajax({
        type: "POST",
        url: "COFID.aspx/GetClass",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlClass').empty();
            $.each(data.d, function (key, value) {
                $('#ddlClass').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlClass').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlClass option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getSubDepartment() {
    $.ajax({
        type: "POST",
        url: "COFID.aspx/GetSubDepartment",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlSubComponent').empty();
            $.each(data.d, function (key, value) {
                $('#ddlSubComponent').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlSubComponent').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlSubComponent option:first').attr("selected", "selected");


        },
        error: function (data) {
            alert("error found");
        }

    });
}
function generateBarcode(brcd) {

    var value = brcd.toString();
    var btype = "code39";
    var renderer = "css";

    //var quietZone = false;
    //if ($("#quietzone").is(':checked') || $("#quietzone").attr('checked')) {
    //    quietZone = true;
    //}

    var settings = {
        output: renderer,
        bgColor: "#FFFFFF",
        color: "#000000",
        barWidth: 2,
        barHeight: 50,
        moduleSize: 5,
        posX: 10,
        posY: 20,
    };
    //if ($("#rectangular").is(':checked') || $("#rectangular").attr('checked')) {
    //    value = { code: value, rect: true };
    //}
    //if (renderer == 'canvas') {
    //    clearCanvas();
    //    $("#barcodeTarget").hide();
    //    $("#canvasTarget").show().barcode(value, btype, settings);
    //} else {
    //   $("#canvasTarget").hide();
    $("#pnlCode").barcode(value, btype, settings);
    // }

    var panel = document.getElementById("pnlCode");
    var PWindow = window.open('', '', 'height=200,width=330');
    PWindow.document.write('<html><head><title>Item Barcode</title>');
    PWindow.document.write('</head><body>');
    PWindow.document.write(panel.innerHTML);
    PWindow.document.write('</body></html>');
    PWindow.document.close();
    setTimeout(function () { PWindow.print(); }, 500);
    return false;
}
function DeleteD(obj) {
    if (confirm("Are You Sure To Delete the Selected Fix Asset Items ?")) {
        var tr = $(obj).closest('td');
        var jsObj = JSON.stringify({ Id: $($(tr).find('span:eq(1)')).html(), ItmId: $($(tr).find('span:eq(0)')).html(), Reciever: $($(tr).find('span:eq(2)')).html() });

        // console.log(tr);
        $.ajax({
            type: "POST",
            url: "COFID.aspx/SetToFalse",
            data: jsObj,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                toastr.success(" Items Are Deleted !", "INV-MIS: Items Transfer Deletion !", { progressBar: !0 });
                //large modal
                ShowCOFIList( $('.province').val());
            },
            error: function (data) {
                alert("error found");
            }

        });
    }
}

