//Front Page
$(function () {
    $('#pnlCode').hide();
    $('#txtRecievedDate').dateDropper({ dropWidth: 200, init_animation: "bounce", dropPrimaryColor: "#fa4420", dropBorder: "1px solid #fa4420", dropBorderRadius: "20", dropShadow: "0 0 10px 0 rgba(250, 68, 32, 0.6)" });
    // getClass();

    //getting Supplier
    $(".province").change(function () {
        if ($(this).val() == "-1") {
        } else {
            getSupplier($(this).val(), $('#txtRecievedDate').val());
        }
    });
    $("#txtRecievedDate").change(function () {
        if ($(this).val() == "") {
        } else {
            getSupplier($('.province').val(), $(this).val());
        }
    });
    //gettingBrcdList
    $("#ddlSupplier").change(function () {
        if ($(this).val() == "-1"||$('.province').val()=="-1") {
            
        } else {
            
            ShowItemBrcdList($(this).val(), $(this).find('option:selected').text(), $('#txtRecievedDate').val(),$('.province').val());
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
        url: "Products_Items.aspx/SaveFormDetail",
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

function callPrint(obj) {
    var td = obj.parentNode;
    var row = obj.parentNode.parentNode;
    var spGRVID = $(td).find('span:eq(0)');
    var spItemID = $(td).find('span:eq(1)');
    var spModal = $(td).find('span:eq(2)');
    var spSerial = $(td).find('span:eq(3)');
    var spIsDeleted = $(td).find('span:eq(4)');
    var spSr = $(td).find('span:eq(5)');
    var Seq = $(row).find("[id^='ddlSEQ']").val();
    var formDetails = {};
    formDetails.GVRID = spGRVID.html();
    formDetails.Modal = spModal.html();
    formDetails.Serial = spSerial.html();
    formDetails.ItemID = spItemID.html();
    formDetails.IsDeleted =spIsDeleted.html();
    formDetails.Sr = spSr.html();
    formDetails.Seq = Seq;
    var jsonObject = JSON.stringify({ formDetails: formDetails });
    $.ajax({
        type: "POST",
        url: "Items_brcd.aspx/SaveFormDetail",
        data: jsonObject,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            var url = "FormDownload.aspx?brdI=" + r.d ;
            window.open(url, '_blank');        
            

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
var row = null;
function ShowItemBrcdList(GRVID, Supplier, GRVDate,Pro) {
    $.ajax({
        type: "POST",
        url: "Items_brcd.aspx/GetBrcdItemsList",
        data: JSON.stringify({ GRVID: GRVID, Supplier: Supplier, GRVDate: GRVDate ,Prov:Pro}),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var $table = "<table id='tbl' width='100%'   class='table table-striped table-bordered scroll-horizontal'>";
            var header = "<thead><tr ><th>SN</th><th style='text-align:center;'>Sub Class</th><th style='text-align:center;'>Item </th><th style='text-align:center;'>Price</th><th style='text-align:center;'>Modal</th><th style='text-align:center;'>Serial</th><th style='text-align:center;'>Unit</th><th style='text-align:center;'>SEQ</th><th style='text-align:center;'></th></tr></thead>";
            $table += header;
            var count = 1;
            $.each(data.d, function (i, x) {
                var row = "<tr ><td style='text-align:center;'>" + count + "</td>" +
                   "<td style='text-align:center;'><span>" + x.SubClass + "  </span></td>" +
                   "<td style='text-align:center;'><span>" + x.ItemName + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.Price + "</span></td>" +
                     "<td style='text-align:center;'><span>" + x.Modal + "</span></td>" +
                      "<td style='text-align:center;'><span>" + x.Serial + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.Unit + "</span></td>" +
                    "<td><select id='ddlSEQ' >" +

                    "<option value='1' >1</option> " +
                    "<option value='2' >2</option> " +
                    "<option value='3' >3</option> " +
                    "<option value='4' >4</option> " +
                    "</select ></td >"+
                //    "<td><select id='ddl' class='form-control'> " +
                //    ( for (var i = 0; i < x.Price; i++) {
                //       + "<option value='" + i + "' >" + i + "</option>"+
                //}) +
        "<td><a onclick='callPrint(this)' class='icon-print edit' href='#'></a><span id='' style='display:none'>" + x.GVRID + "</span><span id='' style='display:none'>" + x.ItemID + "</span><span id='' style='display:none'>" + x.Modal + "</span><span id='' style='display:none'>" + x.Serial + "</span><span id='' style='display:none'>" + x.IsDeleted + "</span><span id='' style='display:none'>" + x.Sr + "</span></td>" +
                "</tr>";
                $table += row;
                count++;
            });
            $('#dtItemBrcd').html($table);
            $table += "</table>";
            $('#tbl').DataTable({ "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, scrollX: !0 });
           
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function getSupplier(PRVID,GRVDate) {
    $.ajax({
        type: "POST",
        url: "Items_brcd.aspx/GetSupplier",
        data: JSON.stringify({ProvinceID:PRVID,GRVDate:GRVDate}),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#ddlSupplier').empty();
            $.each(data.d, function (key, value) {
                $('#ddlSupplier').append($("<option></option>").val(value.GRVID).html(value.Supplier));
            });
            $('#ddlSupplier').prepend("<option value='-1' selected='true'>-Select-</option>");
            $('#ddlSupplier option:first').attr("selected", "selected");
        },
        error: function (data) {
            alert("error found");
        }

    });
}
function generateBarcode(brcd) {
    var value =brcd;
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
        moduleSize:5,
        posX: 10,
        posY: 200,
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
    var w = 350;
    var h = 150;
    var l = (window.screen.availWidth - w) / 2;
    var t = (window.screen.availHeight - h) / 2;
    var sOption = "toolbar=no,location=no,directories=no,menubar=no,scrollbars=yes,width=" + w + ",height=" + h + ",left=" + l + ",top=" + t;
    var panel = document.getElementById("pnlCode");
    var PWindow = window.open('', '','');
    PWindow.document.write('<html><head><title>Item Barcode</title> <style>html,body{ height:24mm;width:24mm;} </style>');
    PWindow.document.write('</head><body>');
    PWindow.document.write(panel.innerHTML);
    PWindow.document.write('</body></html>');
    PWindow.document.close();
    setTimeout(function () { PWindow.print(); }, 500);
    return false;
}
function callDownoaldbrdc() {
   
}
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

