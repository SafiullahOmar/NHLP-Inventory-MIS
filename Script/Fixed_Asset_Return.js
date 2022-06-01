//Front Page
$(function () {
    $('#pnlCode').hide();
    $("#btnUpdate").hide();
    $("#delete").hide();
    $("#btnSave").show();
    $('#txtRDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    getSubDepartment();
    $(".province").change(function () {
        if ($(this).val() != "-1" && $("#ddlSubComponent").val() != "-1") {
            getRecivers($(this).val(), $("#ddlSubComponent").val());

        } else {
            $('#lblQuantiy').text('');
        }
    });
    $("#ddlSubComponent").change(function () {
        if ($(this).val() != "-1" && $(".province").val() != "-1") {
            getRecivers($('.province').val(), $(this).val());

        } else {
            $('#lblQuantiy').text('');
        }
    });
    $("#ddlReciever").change(function () {
        if ($(this).val() != "-1" && $(".province").val() != "-1" && $("#ddlSubComponent").val() != "-1") {
            getAssets($('.province').val(), $(this).val(), $('#ddlSubComponent').val());

        } else {
            $('#lblQuantiy').text('');
        }
    });
    $("#ddlAsset").change(function () {
        if ($(this).val() != "-1" && $(".province").val() != "-1" && $("#ddlSubComponent").val() != "-1" && $("#ddlReciever").val() != "-1") {
            getAssetsQuantity($('.province').val(),$('#ddlReciever').val(), $('#ddlSubComponent').val(), $(this).val());

        } else {
            $('#lblQuantiy').text('');
        }
    });
    
    $('#txtReturnQuantity').change(function (e) {
        if ($(this).val() > parseFloat($('#lblQuantiy').text())) {
            $(this).css('background-color', '#FFAAAA');
            alert("The Quantity is More than Issued Quantity");
            $(this).val('');
        } else {
            $(this).css('background-color', '#ffff');
        }

    });
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


});
//Jscode
function Save() {
 
    if ($('#lblQuantiy').text() != "" && $('#lblCOFID').text() != "") {
        var formDetails = {};
        formDetails.COFID = $('#lblCOFID').text();
        formDetails.Quality = $('#ddlStatus').val();
        formDetails.Code = $('#ddlAsset').val();
        formDetails.Remarks = $('#txtRemarks').val();
        formDetails.Quantity = $('#txtReturnQuantity').val();
        formDetails.Rdate = $('#txtRDate').val();
        var jsonObject = JSON.stringify({ formDetails: formDetails });
        $.ajax({
            type: "POST",
            url: "Fixed_Asset_Return.aspx/SaveFormDetail",
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
}
var row = null;
function ShowCOFIList(Dept, Prov) {
    $.ajax({
        type: "POST",
        url: "COFID.aspx/GetCOFILists",
        data: '{Dept:' + Dept + ',Prov:' + Prov + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table id='tblD'  width='98%' class='table table-striped table-bordered  table-hover'>";
            var header = "<thead><tr ><th>SN</th><th style='text-align:center;'>Item</th><th style='text-align:center;'>Unit</th><th style='text-align:center;'>Quantity</th><th style='text-align:center;'>Reciever</th><th style='text-align:center;'>Modal</th><th style='text-align:center;'>BarCode</th><th style='text-align:center;'>Edit</th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td style='text-align:center;'>" + count + "<span  style='display:none'>" + x.Id + "</span><span  style='display:none'>" + x.ItemId + "</span></td>" +
                   "<td style='text-align:center;'><span>" + x.Item + "  </span></td>" +
                   "<td style='text-align:center;'><span>" + x.Unit + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.Quantity + "</span></td>" +
                     "<td style='text-align:center;'><span>" + x.Reciever + "</span></td>" +
                      "<td style='text-align:center;'><span>" + x.Modal + "</span></td>" +
                      "<td style='text-align:center;'><a onclick='generateBarcode(" + x.bC + ")' class='btn-sm btn-blue edit' href='#'>Print</a></td>" +
                   (x.Edit == true ? "<td><a onclick='DeleteD(this)' class='btn-sm btn-danger edit' href='#'>Delete</a><span id='spID' style='display:none'>" + x.ItemID + "</span></td>" : "<td></td>") +
                "</tr>";
                $table += row;
                count++;
            });
            $('#dtTableDetail').html($table);
            $table += "</table>";
            $('#tblD').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, });
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
                $('#lblQuantiy').text(data.d);
            }
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function formValidation(e) {
    var flag = true;

    if ($('#txtReturnQuantity').val() == '') {
        $('#txtReturnQuantity').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtReturnQuantity').css('background-color', '#ffff'); }

    if ($('#txtRDate').val() == '') {
        $('#txtRDate').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtRDate').css('background-color', '#ffff'); }
   


    if ($('#ddlSubComponent').val() == '-1') {
        $('#ddlSubComponent').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlSubComponent').css('background-color', '#ffff'); }
    if ($('#ddlReciever').val() == '-1') {
        $('#ddlReciever').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlReciever').css('background-color', '#ffff'); }
    if ($('#ddlAsset').val() == '-1') {
        $('#ddlAsset').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlAsset').css('background-color', '#ffff'); }
    if ($('#ddlStatus').val() == '-1') {
        $('#ddlStatus').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlStatus').css('background-color', '#ffff'); }
    if ($('.province').val() == '-1') {
        $('.province').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('.province').css('background-color', '#ffff'); }

    if (flag) { return true } else {
        toastr.warning("Please enter informations in red backhground !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {
    $('#ddlSubComponent').val('-1');
    $('#ddlReciever').val('-1');
    $('#ddlAsset').val('-1');
    $('#lblQuantiy').text('');
    $('#lblCOFID').text('');
    $('#txtReturnQuantity').val('');
    $('#txtRemarks').val('');
    $('#txtRDate').val('');
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

function getSubDepartment() {
    $.ajax({
        type: "POST",
        url: "Fixed_Asset_Return.aspx/GetSubDepartment",
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
function getRecivers(prov,subComp) {
    $.ajax({
        type: "POST",
        url: "Fixed_Asset_Return.aspx/GetRecievers",
        data: JSON.stringify({ ProvId: prov, SubCompId: subComp }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlReciever').empty();
            $.each(data.d, function (key, value) {
               
                $('#ddlReciever').append($("<option></option>").val(value).html(value));
            });
            $('#ddlReciever').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlReciever option:first').attr("selected", "selected");


        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getAssets(prov,Reciever, subComp) {
    $.ajax({
        type: "POST",
        url: "Fixed_Asset_Return.aspx/GetIssuedItemDetail",
        data: JSON.stringify({ ProvId: prov, Reciever:Reciever,SubCompId: subComp }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlAsset').empty();
            $.each(data.d, function (key, value) {

                $('#ddlAsset').append($("<option></option>").val(value.ID).html(value.Name+"-"+value.ID));
            });
            $('#ddlAsset').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlAsset option:first').attr("selected", "selected");


        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getAssetsQuantity(prov, Reciever, subComp,code) {
    $.ajax({
        type: "POST",
        url: "Fixed_Asset_Return.aspx/GetIssuedItemQuantity",
        data: JSON.stringify({ ProvId: prov, Reciever: Reciever, SubCompId: subComp,Code:code }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $.each(data.d, function (key, value) {
                if (key == 0)
                    $('#lblQuantiy').text(value);
                else if(key==1)
                    $('#lblCOFID').text(value);
            });
            
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function DeleteD(obj) {
    if (confirm("Are You Sure To Delete the Selected Fix Items ?")) {
        var tr = $(obj).closest('tr');
        var jsObj = JSON.stringify({ Id: $($(tr).find('span:eq(0)')).html(), ItmId: $($(tr).find('span:eq(1)')).html(), Dept: $('#ddlDepartment').val(), Prov: $('.province').val() });

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
                ShowCOFIList($('#ddlDepartment').val(), $('.province').val());
            },
            error: function (data) {
                alert("error found");
            }

        });
    }
}

