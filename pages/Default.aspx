<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" Runat="Server">
    <script src="../APPContent/js/jquerybarcode.js"></script>
     <script type="text/javascript">

         function generateBarcode() {
             var value = $("#barcodeValue").val();
             var btype = $("input[name=btype]:checked").val();
             var renderer = $("input[name=renderer]:checked").val();

             var quietZone = false;
             if ($("#quietzone").is(':checked') || $("#quietzone").attr('checked')) {
                 quietZone = true;
             }

             var settings = {
                 output: renderer,
                 bgColor: $("#bgColor").val(),
                 color: $("#color").val(),
                 barWidth: $("#barWidth").val(),
                 barHeight: $("#barHeight").val(),
                 moduleSize: $("#moduleSize").val(),
                 posX: $("#posX").val(),
                 posY: $("#posY").val(),
                 addQuietZone: $("#quietZoneSize").val()
             };
             if ($("#rectangular").is(':checked') || $("#rectangular").attr('checked')) {
                 value = { code: value, rect: true };
             }
             if (renderer == 'canvas') {
                 clearCanvas();
                 $("#barcodeTarget").hide();
                 $("#canvasTarget").show().barcode(value, btype, settings);
             } else {
                 $("#canvasTarget").hide();
                 $("#barcodeTarget").html("").show().barcode(value, btype, settings);
             }
         }

         function showConfig1D() {
             $('.config .barcode1D').show();
             $('.config .barcode2D').hide();
         }

         function showConfig2D() {
             $('.config .barcode1D').hide();
             $('.config .barcode2D').show();
         }

         function clearCanvas() {
             var canvas = $('#canvasTarget').get(0);
             var ctx = canvas.getContext('2d');
             ctx.lineWidth = 1;
             ctx.lineCap = 'butt';
             ctx.fillStyle = '#FFFFFF';
             ctx.strokeStyle = '#000000';
             ctx.clearRect(0, 0, canvas.width, canvas.height);
             ctx.strokeRect(0, 0, canvas.width, canvas.height);
         }

         $(function () {
             $('input[name=btype]').click(function () {
                 if ($(this).attr('id') == 'datamatrix') showConfig2D(); else showConfig1D();
             });
             $('input[name=renderer]').click(function () {
                 if ($(this).attr('id') == 'canvas') $('#miscCanvas').show(); else $('#miscCanvas').hide();
             });
             generateBarcode();
         });

    </script>
       <div id="barcodeTarget" class="barcodeTarget"></div>
</asp:Content>

