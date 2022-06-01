//Front Page
$(function () {
    $("#btnUpdate").hide();
    $("#btnDelete").hide();
    $("#btnSave").show();
    getClass();
    
    $("#ddlClass").change(function () {
        if ($(this).val() == "-1") {
            $('#dtTableDetail').html('');
        } else {
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
    $("#btnDelete").click(function (e) {
        e.preventDefault();
        if (formValidation(e)) {            
            Delete();
        }
    });
});
//Jscode
function Save() {
    var formDetails = {}; 
    formDetails.Name = $('#txtSubClass').val();
    formDetails.ClassID = $('#ddlClass').val();
    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "item_s_category.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Class Information is Added !", "INV-MIS: Successfully Saved !", { progressBar: !0 });
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
        url: "item_s_category.aspx/GetSubClassLists",
        data: '{ClassID:' + $('#ddlClass').val() + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table id='tbl'  width='98%' class='table table-striped table-bordered  table-hover'>";
            var header = "<thead><tr ><th>SN</th><th style='text-align:center;'>Sub Class Code</th><th style='text-align:center;'>General Category </th><th style='text-align:center;'></th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td style='text-align:center;'>" + count + "<span id='spanSeedPlantedId' style='display:none'>" + x.ID + "</span></td>" +
                   "<td style='text-align:center;'><span>" + x.ID + "  </span></td>" +
                   "<td style='text-align:center;'><span>" + x.Name + "</span></td>" +                   
                   (x.Edit == true ? "<td><a onclick='EditDetail(this)' class='btn-sm btn-blue edit' href='#'>Edit</a><span id='spID' style='display:none'>" + x.ID + "</span></td>" : "<td></td>") +
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
    
    if ($('#txtSubClass').val() == '') {
        $('#txtSubClass').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtSubClass').css('background-color', '#ffff'); }

    if ($('#ddlClass').val() == '-1') {
        $('#ddlClass').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlClass').css('background-color', '#ffff'); }

    if (flag) { return true } else {
        toastr.warning("Please enter informations in red backhground !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}

function ClearForm() {
    $('#txtSubClass').val('');
    $('#btnSave').show();
    $('#btnDelete').hide();
    $('#btnUpdate').hide();
    $('#hdnSubClass').val('');
}

function EditDetail(obj) {
    var td = obj.parentNode;
    row = obj.parentNode.parentNode;
    var span = $(td).find('span');
    var ID = span.html();
    $('#hdnSubClass').val(ID);
    var obj = JSON.stringify({ SCID: ID });
    $.ajax({
        type: "POST",
        url: "item_s_category.aspx/GetDetailByID",
        data: obj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            $('#txtSubClass').val(r.d.Name);            
            $('#btnSave').hide();
            $('#btnDelete').show();
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
    formDetails.Name = $('#txtSubClass').val();
    formDetails.ID = $('#hdnSubClass').val();
    formDetails.ClassID = $('#ddlClass').val();
    var jsonObject = JSON.stringify({ formDetails: formDetails });

    $.ajax({
        type: "POST",
        url: "item_s_category.aspx/UpdateFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            toastr.success("Information in the system are updated!", "INV-MIS: Successfully Updated  !", { progressBar: !0 });

            //Clear components
            ClearForm();
            $('#btnSave').show();
            $('#btnDelete').hide();
            $('#btnUpdate').hide();
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
        url: "item_s_category.aspx/GetClass",
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

function Delete() {
    var jsonObject = JSON.stringify({ subclassId: $('#hdnSubClass').val() });

    $.ajax({
        type: "POST",
        url: "item_s_category.aspx/DeleteSubClass",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == true) {

                $('#btnSave').show();
                $('#btnDelete').hide();
                $('#btnUpdate').hide();
                ClearForm();
                // call function
                ShowList();
                toastr.info("You Can Not Delete the Selected Record !", "INV-MIS: Form-Alert !", { progressBar: !0 });
            }
            else {


                toastr.success("Your Record has been deleted!", "INV-MIS:Successfully Deleted !", { progressBar: !0 });

                //Clear components
                ClearForm();
                $('#btnSave').show();
                $('#btnDelete').hide();
                $('#btnUpdate').hide();
                // call function
                ShowList();

            }


        },
        error: function (data) {
            alert("error found");
        }

    });
}

