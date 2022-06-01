<%@ Page Title="INV_MIS:System Reports" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="data-report.aspx.cs" Inherits="Reports_data_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="Server">
    <link rel="stylesheet" type="text/css" href="../APPContent/css/plugins/forms/listbox/bootstrap-duallistbox.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopic" runat="Server">
    SYSTEM DATA REPORTS
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    Select Your Required Field (Report Type,Report Month,Report Year repectively) and then click on Generate Button.Your Report will be generated in PDF Format .
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pageBody" runat="Server">

    <script type="text/javascript">
        $(function () {
            //getProvince();
            $(".duallistbox-multi-selection").bootstrapDualListbox();
            // $('select.form-control:not(.duallistbox-multi-selection)').select2({ containerCssClass: "select-xs" });

            $('#ddlYear').select2({ containerCssClass: "select-xs" }); $('#ddlMonth').select2({ containerCssClass: "select-xs" }); $('#ddlReportType').select2({ containerCssClass: "select-xs" });

            $('#btnGenerate').click(function () {
                $('#btnGenerate').prop("href", "../pages/FormDownload.aspx?data-report=" + $('.duallistbox-multi-selection').val() + "&m=" + $('#ddlMonth').val() + "&y=" + $('#ddlYear').val() + "&tp=" + $('#ddlReportType').val() + "");
                $('#btnGenerate').trigger('click');
            });

            $('#ddlReportType').on('change', function (e) {
                if ($(this).val() == '4' || $(this).val() == '5') {
                    $('#ddlMonth').attr('disabled', 'disabled');
                    $('#ddlYear').select2({ multiple: true, containerCssClass: "select-xs" }).find('[value="-1"]').remove();
                } else {
                    $('#ddlMonth').removeAttr('disabled');
                    $('#ddlYear').select2({ multiple: false, containerCssClass: "select-xs" }).trigger('change');
                    if ($('#ddlYear option').filter(function () { return $(this).val() == "-1"; }).length) {

                    } else {
                        $("#ddlYear option").eq(0).before($("<option></option>").val("-1").text("--Select--"));
                    }
                }
            });


        });
    </script>
    <section class="with-multi-selection">
        <div class="row">
            <div class="col-xs-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title ">Data Reports</h4>
                        <a class="heading-elements-toggle"><i class="icon-ellipsis font-medium-3"></i></a>
                        <div class="heading-elements">
                            <ul class="list-inline mb-0">
                                <li><a data-action="collapse"><i class="icon-minus4"></i></a></li>
                                <li><a data-action="reload"><i class="icon-reload"></i></a></li>
                                <li><a data-action="expand"><i class="icon-expand2"></i></a></li>
                                <li><a data-action="close"><i class="icon-cross2"></i></a></li>
                            </ul>
                        </div>
                    </div>



                    <div class="card-body collapse in">
                        <div class="card-block">
                            <div class="form form-horizontal">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="label-control text-bold-700 " for="ddlReportType">Report Type</label>
                                                <select id="ddlReportType" class="form-control">
                                                    <option value="-1">--Select--</option>
                                                    <option value="1"><b>Monthly </b>Summary Report</option>
                                                    <option value="2">Monthly Goods Issue (S) Report</option>
                                                    <option value="3">Monthly Goods Receive (S) Report</option>
                                                    <option value="4">Received Vouchers (S) Report</option>
                                                    <option value="5">Fixed Asset Issue Report</option>
                                                    <option value="6">Fixed Asset Return Report</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="label-control text-bold-700" for="ddlMonth">Report Month</label>
                                                <select id="ddlMonth" class="form-control">
                                                    <option value="-1">--Select--</option>
                                                    <option value="1">Jan</option>
                                                    <option value="2">Feb</option>
                                                    <option value="3">March</option>
                                                    <option value="4">Apr</option>
                                                    <option value="5">May</option>
                                                    <option value="6">Jun</option>
                                                    <option value="7">July</option>
                                                    <option value="8">Aug</option>
                                                    <option value="9">Sep</option>
                                                    <option value="10">Oct</option>
                                                    <option value="11">Nov</option>
                                                    <option value="12">Dec</option>

                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label class="label-control text-bold-700" for="ddlYear">Report Year</label>
                                                <select id="ddlYear" class="form-control">
                                                    <option value="-1">--Select--</option>
                                                    <option value="2019">2019</option>
                                                    <option value="2018">2018</option>
                                                    <option value="2017">2017</option>
                                                    <option value="2016">2016</option>
                                                    <option value="2015">2015</option>
                                                    <option value="2014">2014</option>
                                                    <option value="2013">2013</option>
                                                    <option value="2012">2012</option>

                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-12">
                                            <select multiple="multiple" size="10" class="duallistbox-multi-selection">
                                                <option value="1">Kabul Province</option>
                                                <option value="3">Parwan</option>
                                                <option value="7">Paktia</option>
                                                <option value="8">Nangarhar</option>
                                                <option value="11">Badakhshan</option>
                                                <option value="13">Baghlan</option>
                                                <option value="14">Kunduz</option>
                                                <option value="16">Balkh</option>
                                                <option value="17">Jawzjan</option>
                                                <option value="20">Hirat</option>
                                                <option value="21">Farah</option>
                                                <option value="22">Nimroz</option>
                                                <option value="23">Hilmand</option>
                                                <option value="24">Kandahar</option>
                                                <option value="27">Ghor</option>
                                                <option value="28">Bamyan</option>
                                                <option value="29">Paktika</option>
                                                <option value="30">Nuristan</option>
                                                <option value="32">Khost</option>
                                                <option value="35">NHLP Head Office</option>
                                            </select>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="form-actions center">
                                <a id="btnGenerate" class="btn btn-primary  white">
                                    <i class="icon-news"></i>&nbsp Generate	                           
                                </a>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scripts" runat="Server">
    <script src="../APPContent/js/plugins/forms/listbox/jquery.bootstrap-duallistbox.min.js" type="text/javascript"></script>

</asp:Content>

