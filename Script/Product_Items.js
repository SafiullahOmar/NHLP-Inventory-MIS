//Front Page
$(function () {
    $("#btnUpdate").hide();
    $("#btnDelete").hide();
    $("#btnSave").show();
    getClass();
    getUnit();
    $("#ddlClass").change(function () {
        if ($(this).val() == "-1") {
            $('#ddlSubCategory').empty();
            $('#ddlSubCategory').attr("disabled", "disabled");
            $('#dtTableDetail').html('');
        } else {
            $.ajax({
                type: "POST",
                url: "item_d.aspx/GetSubClassLists",
                data: '{ClassID:' + $('#ddlClass').val() + '}',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#ddlSubCategory').attr("disabled",false);
                    $('#ddlSubCategory').empty();
                    $.each(data.d, function (key, value) {
                        $('#ddlSubCategory').append($("<option></option>").val(value.ID).html(value.Name));
                    });
                    $('#ddlSubCategory').prepend("<option value='-1' selected='true'>-Select-</option>");
                    $('#ddlSubCategory option:first').attr("selected", "selected");
                },
                error: function (data) {
                    alert("error found");
                }

            });

            ShowList();
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

    
});
//Jscode
function Save() {
    var formDetails = {};
    formDetails.Name = $('#txtName').val();
    formDetails.SubClassID = $('#ddlSubCategory').val();
    formDetails.UnitID = $('#ddlUnit').val();
    formDetails.AssetType = $('#ddlAssetsType').val();
    formDetails.KeepingType = $('#ddlKeepingType').val();
    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "item_d.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Product or Item  is Added into system !", "INV-MIS: Successfully Saved !", { progressBar: !0 });
            //Clear components
            ClearForm();
            //call function
            ShowList();

        },
        error: function (data) {
            alert("error found");
        }

    });
}
var row = null;
function ShowList() {
    $.ajax({
        type: "POST",
        url: "item_d.aspx/GetItemsLists",
        data: '{ClassID:' + $('#ddlClass').val() + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table id='tbl'  width='98%' class='table table-striped table-bordered  table-hover'>";
            var header = "<thead><tr ><th>SN</th><th style='text-align:center;'>Item</th><th style='text-align:center;'>Asset Type </th><th style='text-align:center;'>Keeping Type </th><th style='text-align:center;'>Unit</th><th style='text-align:center;'>Category</th><th style='text-align:center;'></th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td style='text-align:center;'>" + count + "<span id='spanSeedPlantedId' style='display:none'>" + x.ItemID + "</span></td>" +
                   "<td style='text-align:center;'><span>" + x.Name + "  </span></td>" +
                   "<td style='text-align:center;'><span>" + x.AssetType + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.KeepingType + "</span></td>" +
                     "<td style='text-align:center;'><span>" + x.UnitID + "</span></td>" +
                      "<td style='text-align:center;'><span>" + x.SubClassID + "</span></td>" +
                   (x.Edit == true ? "<td><a onclick='EditDetail(this)' class='btn-sm btn-blue edit' href='#'>Edit</a><span id='spID' style='display:none'>" + x.ItemID + "</span></td>" : "<td></td>") +
                "</tr>";
                $table += row;
                count++;
            });
            $('#dtTableDetail').html($table);
            $table += "</table>";
            $('#tbl').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, });
            $('#dtTableDetail').show();
        },
        error: function (data) {
            alert("error found");
        }

    });
}

function formValidation(e) {
    var flag = true;

    if ($('#txtName').val() == '') {
        $('#txtName').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtName').css('background-color', '#ffff'); }

    if ($('#ddlClass').val() == '-1') {
        $('#ddlClass').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlClass').css('background-color', '#ffff'); }
    if ($('#ddlSubCategory').val() == '-1') {
        $('#ddlSubCategory').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlSubCategory').css('background-color', '#ffff'); }
    if ($('#ddlUnit').val() == '-1') {
        $('#ddlUnit').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlUnit').css('background-color', '#ffff'); }
    if ($('#ddlAssetsType').val() == '-1') {
        $('#ddlAssetsType').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlAssetsType').css('background-color', '#ffff'); }
    if ($('#ddlKeepingType').val() == '-1') {
        $('#ddlKeepingType').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlKeepingType').css('background-color', '#ffff'); }

    if (flag) { return true } else {
        toastr.warning("Please enter informations in red backhground !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}

function ClearForm() {
    $('#txtName').val('');
    $('#ddlSubCategory').val('-1');
    $('#ddlUnit').val('-1');
    $('#ddlAssetsType').val('-1');
    $('#ddlKeepingType').val('-1');
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
        url: "item_d.aspx/GetDetailByID",
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

            toastr.info("Please enter correct information ! , After Then You Are Not Allowed to Amend It", "INV-MIS:  Alert !", { progressBar: !0 });
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
        url: "item_d.aspx/UpdateFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Information in the system are updated!", "INV-MIS: Successfully Updated  !", { progressBar:!0 });
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
        url: "item_d.aspx/GetClass",
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
function getUnit() {
    $.ajax({
        type: "POST",
        url: "item_d.aspx/GetUnit",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlUnit').empty();
            $.each(data.d, function (key, value) {
                $('#ddlUnit').append($("<option></option>").val(value.ID).html(value.Unit));
            });
            $('#ddlUnit').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlUnit option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}

//#region coded
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

//#endregion

