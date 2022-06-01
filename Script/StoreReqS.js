//Front Page
$(function () {
 
    $("#btnUpdate").hide();
    $("#delete").hide();
    $("#btnSave").show();

    getDepartment();
    getUnit();
    getProvince();
    getItems();
    $('#ddlItems').select2({ containerCssClass: "select-xs" });
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
    $("#ddlProvince").change(function () {
        if ($(this).val()=="-1") {
        }
        else {
            getSupervisors();
        }
    });
    $("#ddlDepartment").change(function () {
        if ($(this).val()=="-1") { }
        else {
            getSupervisors();
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
    $('#lnkShowItemInsertModal').click(function () {
        $('#MDItemInsert').modal('show');
        clearModal();
    });

    $('#btnAddtoItemList').click(function (e) {
        e.preventDefault();

        var flag = true;     

        if ($('#ddlUnit').val() == '-1') {
            $('#ddlUnit').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#ddlUnit').css('background-color', '#ffff'); }
        
        if ($('#txtItems').val() == '') {
            $('#txtItems').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtItems').css('background-color', '#ffff'); }

        if ($('#txtReqQunatity').val() == '') {
            $('#txtReqQunatity').css('background-color', '#FFAAAA'); flag = false;
        } else { $('#txtReqQunatity').css('background-color', '#ffff'); }


        var count = $('#tblItemInsertion tbody tr').length;
        if (flag) {
            var markup = "<tr class='far text-md-center'><td><input type='checkbox' name='record'></td><td>" + (parseInt(count) + 1) + "</td><td><span id='Item' style=''>" + $('#ddlItems').find('option:selected').text() + "</span></td><td><span id='unit' style='display:none'>" + $('#ddlUnit').val() + "</span>" + $('#ddlUnit').find('option:selected').text() + "</td><td><span id='Quantity'>" + $('#txtReqQunatity').val() + "</span></td><td><span>" + $('#txtRemarks').val() + "</span></td></tr>";
            $("#tblItemInsertion tbody").append(markup);
            $('#MDItemInsert').modal('hide');
            if (parseInt(count) == 0) {
                $('#tblItemInsertion').DataTable().destroy();
                $('#tblItemInsertion').DataTable({ "bPaginate": false, "bLengthChange": false, "bFilter": false , "bSort": false, "bInfo": false, "bAutoWidth": false });
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
    
});
//Jscode

function formValidation(e) {
   
    var flag = true;


    if ($('#ddlDepartment').val() == '-1') {
        $('#ddlDepartment').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlDepartment').css('background-color', '#ffff'); }

    if ($('#ddlProvince').val() == '-1') {
        $('#ddlProvince').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlProvince').css('background-color', '#ffff'); }

    if ($('#txtPosition').val() == '') {
        $('#txtPosition').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtPosition').css('background-color', '#ffff'); }

    if ($('#txtRequester').val() == '') {
        $('#txtRequester').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#txtRequester').css('background-color', '#ffff'); }

    if ($('#ddlSupervisor').val() == '-1') {
        $('#ddlSupervisor').css('background-color', '#FFAAAA');
        flag = false;
    }
    else { $('#ddlSupervisor').css('background-color', '#ffff'); }

    var count = $('#tblItemInsertion tbody tr').length;
    if (parseInt(count) == 0) {
        flag = false;    }

    if (flag) { return true } else {
        toastr.warning("Please enter informations in red background OR You Missed Items !", "INV-MIS: Validation Alert !", { progressBar: !0 });
        return false;
    }
}
function ClearForm() {
    $('#ddlDepartment').val('-1');
    $('#ddlProvince').val('-1');
    $('#ddlSupervisor').val('-1');   
    $('#txtRequester').val('');
    $('#txtPosition').val('');
    $('#txtEmail').val('');
    $('#tblItemInsertion tbody tr').remove();
    $("#cTotalAmount").html('');
}

function Save() {
    var formDetails = {};
    formDetails.Name = $('#txtRequester').val();
    formDetails.Position = $('#txtPosition').val();
    formDetails.Province = $('#ddlProvince').val();
    formDetails.Department = $('#ddlDepartment').val();
    formDetails.Supervisor = $('#ddlSupervisor').val();
    formDetails.Email = $('#txtEmail').val();
    var lst = new Array();
    $('#tblItemInsertion tbody tr').each(function () {
        var detail = {};
        var tr = $(this).closest('tr');
        var Item = $(tr).find('span:eq(0)');
        var Quantity = $(tr).find('span:eq(2)');;
        var Remarks = $(tr).find('span:eq(3)');

        detail.Item = $(Item).html();
        detail.ReqQuantity = $(Quantity).html();
        detail.Remarks = $(Remarks).html();

        lst.push(detail);
    });
    formDetails.lst = lst;
    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "ReqS.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var content = $(".lead");
            $(content).append("<div id='divMsg' class='alert bg-success alert-icon-left alert-arrow-left alert-dismissible fade in mb-2' role='alert'>" +
                 "<button class='close'  aria-label='Close' type='button' data-dismiss='alert'><span aria-hidden='true'>×</span></button> <strong> Req #: NHLP-Rq-" + data.d + "</strong> ,<p class='font-size-small'> Note your request number . This Message will be deleted after 30 seconds OR click on the (x) button.</p></div>");
            toastr.success("Requisition form and thier items detail are sent to your Supervisor !", "INV-MIS: Requisition Form is Sent !", { progressBar: !0, timeOut: 10e3 });
            //Clear components
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
function getUnit() {
    $.ajax({
        type: "POST",
        url: "ReqS.aspx/GetUnit",
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
function getProvince() {
    $.ajax({
        type: "POST",
        url: "ReqS.aspx/GetProvinces",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlProvince').empty();
            $.each(data.d, function (key, value) {
                $('#ddlProvince').append($("<option></option>").val(value.ID).html(value.Name));
            });
            $('#ddlProvince').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlProvince option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getItems() {
    $.ajax({
        type: "POST",
        url: "ReqS.aspx/GetItems",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlItems').empty();
            $.each(data.d, function (key, value) {
                $('#ddlItems').append($("<option></option>").val(value.ItemID).html(value.Name));
            });
            $('#ddlItems').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlItems option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getDepartment() {
    $.ajax({
        type: "POST",
        url: "ReqS.aspx/GetDepartment",
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
function getSupervisors() {
    if ($('#ddlProvince').val() != "-1" ) {
        $.ajax({
            type: "POST",
            url: "ReqS.aspx/GetSupervisors",
            data: '{OL:' + $('#ddlProvince').val() + ',DP:' + $('#ddlDepartment').val() + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#ddlSupervisor').empty();
                $.each(data.d, function (key, value) {
                    $('#ddlSupervisor').append($("<option></option>").val(value.ID).html(value.Name));
                });
                $('#ddlSupervisor').prepend("<option value='-1' selected='true'>-Select-</option>");
                $('#ddlSupervisor option:first').attr("selected", "selected");
            },
            error: function (data) {
                alert("error found");
            }

        });
    }
}

function clearModal() {
    $('#ddlUnit').val("-1");
    $('#txtRemarks').val("");
    $('#txtReqQunatity').val("");
    $('#txtItems').val("");
}
function SumTAmount() {
    var count = $('#tblItemInsertion tbody tr').length;
        $("#cTotalAmount").html('');
        var markup2 = "Total Requested Items in the List are  <code class='bold'> " + (parseInt(count)) + "</code> ";
        $("#cTotalAmount").html(markup2);
}
