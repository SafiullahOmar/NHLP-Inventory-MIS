<%@ Page Title="" Language="C#" MasterPageFile="~/OuterSiteMaster2.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    Dashborad
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    Overview and Statistics of Inventory MIS .Line (1) Depicts (#) of Items Quantities Repect to Request Status.Line (2) Depicts (#) of Approved and Waiting Requests,# of Requests Type and (#) of Issued Request Respect to Thier Provinces.Line(3) Depicts (#) of Current Office Fixed Items/Products.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pageBody" runat="Server">

    <div class="card">
        <div class="row">
            <div class="col-md-6">
                <div class="card-block">
                    <div class="form-group">
                        <label for="ddlYear">Year to display relevant data and statistics</label>
                        <select class="form-control" id="ddlYear">
                            <option value="2021">2021</option>
                            <option value="2020">2020</option>
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

            <div class="col-md-6">

                <div class="card-block">
                    <div class="form-group">
                        <label for="ddlProvince">Select Duty Station </label>
                        <asp:DropDownList ID="ddlProvince" CssClass="form-control prov" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">

            <div class="col-xl-3 col-lg-6 col-sm-12 border-right-blue-grey border-right-lighten-5">

                <div class="media px-1">
                    <div class="media-left media-middle">
                        <i class="icon-box font-large-1 blue-grey"></i>
                    </div>
                    <div class="media-body text-xs-right">
                        <span class="font-large-1 text-bold-300 info OpeningQ">0</span>
                    </div>
                    <p class="text-muted">Purchased Items <span class="info float-xs-right"><i class="icon-arrow-up4 info"></i><span class="OpeningPer"></span></span></p>
                    <progress class="progress progress-sm progress-info OpeningP" max="100"></progress>
                </div>
            </div>
            <div class="col-xl-3 col-lg-6 col-sm-12 border-right-blue-grey border-right-lighten-5">
                <div class="media px-1">
                    <div class="media-left media-middle">
                        <i class="icon-tag3 font-large-1 blue-grey"></i>
                    </div>
                    <div class="media-body text-xs-right">
                        <span class="font-large-1 text-bold-300 deep-orange IssuedQ">0</span>
                    </div>
                    <p class="text-muted">Issued Items<span class="deep-orange float-xs-right "><i class="icon-arrow-down4 deep-orange"></i><span class="IssuedQPer"></span></span></p>
                    <progress class="progress progress-sm progress-deep-orange IssuedQP" max="100"></progress>
                </div>
            </div>
            <div class="col-xl-3 col-lg-6 col-sm-12 border-right-blue-grey border-right-lighten-5">
                <div class="media px-1">
                    <div class="media-left media-middle">
                        <i class="icon-shuffle3 font-large-1 blue-grey"></i>
                    </div>
                    <div class="media-body text-xs-right">
                        <span class=" font-medium-4 mr-2  danger TransQToOthr">0</span><span class="font-medium-4  green TransQRFromOther">0</span>
                    </div>
                    <p class="text-muted">Transfered Items<span class="danger float-xs-right"><i class="icon-arrow-down4 danger"></i>  <span class="TransQPer"></span></span></p>
                    <progress class="progress progress-sm progress-danger TransQP" value="75" max="100"></progress>
                </div>
            </div>
            <div class="col-xl-3 col-lg-6 col-sm-12">
                <div class="media px-1">
                    <div class="media-left media-middle">
                        <i class="icon-save font-large-1 blue-grey"></i>
                    </div>
                    <div class="media-body text-xs-right">
                        <span class="font-large-1 text-bold-300 success BalanceQ">0</span>
                    </div>
                    <p class="text-muted">Stocked Items<span class="success float-xs-right"><i class="icon-arrow-up4 success"></i><span class="BalanceQPer"></span></span></p>
                    <progress class="progress progress-sm progress-success BalanceQP" value="60" max="100"></progress>
                </div>
            </div>
        </div>
    </div>

    <div class="row match-height">
        <div class="col-xl-4 col-lg-12">
            <div class="card">
                <div class="card-body">
                    <div class="card-block text-xs-center">
                        <div class="card-header mb-2">
                            <span class="green darken-1">Total Requests</span>
                            <h3 class="font-large-2 grey darken-1 text-bold-200 TotalR"></h3>
                        </div>
                        <div class="card-body">
                            <input type="text" class="knob hide-value responsive angle-offset" data-angleoffset="0" data-thickness=".15" data-linecap="round" data-width="150" data-height="150" data-inputcolor="#e1e1e1" data-readonly="true" data-fgcolor="#FF5722" data-knob-icon="icon-dollar">
                            <ul class="list-inline clearfix mt-2 mb-0">
                                <li class="border-right-grey border-right-lighten-2 pr-2">
                                    <h2 class="grey darken-1 text-bold-400 ApprovedRPer">0</h2>
                                    <span class="deep-purple">Approved</span>
                                </li>
                                <li class="pl-2">
                                    <h2 class="grey darken-1 text-bold-400 NOTApprovedPer">0</h2>
                                    <span class="danger">Waiting</span>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xl-8 col-lg-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-12">
                            <div class="chart-stats text-xs-center my-3">
                                <div class="new-users my-2 overflow-hidden clearfix">
                                    <span>Ware House Items Requests</span>
                                    <h1 class="display-4 INVRPer"></h1>
                                </div>
                                <div class="returning-users my-2 overflow-hidden">
                                    <span>Store Requests</span>
                                    <h1 class="display-4 StoreRPer"></h1>
                                </div>
                                <div class="page-views my-2 overflow-hidden">
                                    <span>Office Use Items Requests</span>
                                    <h1 class="display-4 OfficeRPer"></h1>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-9 col-md-12">
                            <div class="card-block">
                                <div class="chartjs">
                                    <div id="containerChart"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-xl-12 col-lg-12">
            <div class="card">
                <div class="card-body">
                    <div class="card-block text-xs-center">
                        <div class="card-body">
                            <div id="chartCOFID">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="scripts" runat="Server">
    <script type="text/ecmascript">
        $(function () {
            $('#ddlYear').val((new Date()).getFullYear());
            $('#ddlYear').change(function () {
                $.fn.CallItemGInfo();
                $.fn.CallMultiInfo();
            });
            $('.prov').change(function () {
                $.fn.CallItemGInfo();
                $.fn.CallMultiInfo();
            });
            $.fn.CallItemGInfo = function () {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/ItemGTotalInfo",
                    data: '{year:' + $('#ddlYear').val() + ',provincId:' + $('.prov').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data.d.OpeningBQ != 0) {
                            $('span.OpeningQ').text(data.d.OpeningBQ);
                            $('.OpeningP').val(100);
                            $('span.OpeningPer').text("100%");
                        } else {
                            $('span.OpeningQ').text(data.d.OpeningBQ);
                            $('.OpeningP').val(data.d.OpeningBQ);
                            $('span.OpeningPer').text(data.d.OpeningBQ + "%");
                        }

                        if (data.d.OpeningBQ != 0) {
                            $('span.IssuedQ').text(data.d.IssueQ);
                            $('.IssuedQP').val(parseFloat(data.d.IssueQ) / parseFloat(data.d.OpeningBQ) * 100);
                            $('span.IssuedQPer').text(Math.round(parseFloat(data.d.IssueQ) / parseFloat(data.d.OpeningBQ) * 100) + "%");
                        } else {
                            $('span.IssuedQ').text(data.d.IssueQ);
                            $('.IssuedQP').val(parseFloat(data.d.IssueQ) / parseFloat(1) * 100);
                            $('span.IssuedQPer').text(Math.round(parseFloat(data.d.IssueQ) / parseFloat(1) * 100) + "%");
                        }
                        if (data.d.OpeningBQ != 0) {
                            $('span.TransQToOthr').text(data.d.TransfrmToQ + 'T');
                            $('span.TransQRFromOther').text(data.d.Transfrm4rmQ + 'R');
                            $('.TransQP').val(parseFloat(data.d.Transfrm4rmQ) / parseFloat(data.d.OpeningBQ) * 100);
                            $('span.TransQPer').text(Math.round(parseFloat(data.d.Transfrm4rmQ) / parseFloat(data.d.OpeningBQ) * 100) + "%");
                        } else {
                            $('span.TransQToOthr').text(data.d.TransfrmToQ);
                            $('span.TransQRFromOther').text(data.d.Transfrm4rmQ);
                            $('.TransQP').val(parseFloat(data.d.Transfrm4rmQ) / parseFloat(1) * 100);
                            $('span.TransQPer').text(Math.round(parseFloat(data.d.Transfrm4rmQ) / parseFloat(1) * 100) + "%");
                        }

                        if (data.d.OpeningBQ != 0) {
                            $('span.BalanceQ').text(data.d.BalanceQ);
                            $('.BalanceQP').val(parseFloat(data.d.BalanceQ) / parseFloat(data.d.OpeningBQ) * 100);
                            $('span.BalanceQPer').text(Math.round(parseFloat(data.d.BalanceQ) / parseFloat(data.d.OpeningBQ) * 100) + "%");
                        } else {
                            $('span.BalanceQ').text(data.d.BalanceQ);
                            $('.BalanceQP').val(parseFloat(data.d.BalanceQ) / parseFloat(1) * 100);
                            $('span.BalanceQPer').text(Math.round(parseFloat(data.d.BalanceQ) / parseFloat(1) * 100) + "%");
                        }


                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });

            }
            $.fn.CallMultiInfo = function () {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/ItemsMultiInfo",
                    data: '{year:' + $('#ddlYear').val() + ',provincId:' + $('.prov').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        //TotalREquests
                        $('h3.TotalR').text(parseFloat(data.d.WR) + parseFloat(data.d.AR));
                        $('h2.NOTApprovedPer').text(parseFloat(data.d.WR));
                        $('h2.ApprovedRPer').text(data.d.AR);

                        //#TypeOFRequests
                        $('.knob').val(parseFloat(data.d.AR) / (parseFloat(data.d.WR) + parseFloat(data.d.AR)) * 100).trigger('change');
                        var c = 1;
                        if (data.d.GReqDlst.length != 0) {
                            $.each(data.d.GReqDlst, function (i, x) {
                                if (c == 1)
                                    $('h1.OfficeRPer').text(x.Count);
                                else if (c == 2)
                                    $('h1.StoreRPer').text(x.Count);
                                else if (c == 3)
                                    $('h1.INVRPer').text(x.Count);
                                c += 1;
                            });
                        } else {
                            $('h1.OfficeRPer').text(0);
                            $('h1.StoreRPer').text(0);
                            $('h1.INVRPer').text(0);
                        }

                        //IssueChart
                        Store = []; province = []; CT = []; OFF = [];
                        var arr = new Array();
                        $.each(data.d.IssueItmlst, function (i, x) {
                            province.push(x.Prov);
                            Store.push(x.Store);
                            CT.push(x.CT);
                            OFF.push(x.OFF);
                        });


                        $('#containerChart').highcharts({
                            chart: {
                                type: 'bar'
                            },
                            title: {
                                text: '(Q) Issued Items '
                            },
                            subtitle: {
                                text: 'Number of Issued Items Quantity By Province '
                            },
                            xAxis: {
                                categories: province,
                                crosshair: true

                            },
                            legend: {
                                layout: 'vertical',
                                align: 'right',
                                verticalAlign: 'middle',
                                borderWidth: 0
                            },
                            tooltip: {
                                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                    '<td style="padding:0"><b>{point.y:.1f} </b></td></tr>',
                                footerFormat: '</table>',
                                shared: true,
                                useHTML: true
                            },
                            yAxis: {
                                min: 0,
                                allowDecimals: false, labels: {
                                    style: {
                                        color: 'black',
                                        fontWeight: 'bold',
                                        fontSize: '9px'
                                    }
                                },
                                stackLabels: {
                                    enabled: true,
                                    style: {
                                        fontWeight: 'bold',
                                        fontSize: '11px',
                                        color: 'black'
                                    }
                                },
                                title: {
                                    text: 'By Request Type'
                                },
                                plotLines: [{
                                    value: 0,
                                    width: 1,
                                    color: '#808080'
                                }]
                            },
                            series: [{
                                name: 'Store',
                                data: Store,
                                color: 'rgba(180, 0, 0, 0.66)'
                            }, {
                                name: 'WareHouse',
                                data: CT,
                                color: '#B7ED82'
                            }, {
                                name: 'Office Use',
                                data: OFF,
                                color: '#8CC9C9'
                            }, ]
                           , plotOptions: {

                               series: {
                                   stacking: 'normal'
                               }

                           },
                        });

                        //COF
                        COFcnt = []; COFprovince = []; COFQU = [];

                        $.each(data.d.COFAlst, function (i, x) {
                            COFprovince.push(x.Prov);
                            COFQU.push(x.QU);
                        });

                        $('#chartCOFID').highcharts({
                            chart: {
                                type: 'column'
                            },
                            xAxis: {
                                categories: COFprovince,
                                crosshair: true

                            },
                            credits: {
                                enabled: false
                            },
                            title: {
                                text: '(Q) Current Office Fixed Items'
                            },
                            subtitle: {
                                text: 'Number of Fixed Items Quantity By Province '
                            },

                            legend: {
                                layout: 'vertical',
                                align: 'right',
                                verticalAlign: 'middle',
                                borderWidth: 0
                            },
                            tooltip: {
                                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                    '<td style="padding:0"><b>{point.y:.1f} </b></td></tr>',
                                footerFormat: '</table>',
                                shared: true,
                                useHTML: true
                            },
                            series: [{
                                type: 'column',
                                name: 'Q',
                                data: COFQU,
                                color: '#FCAE25'
                            }, ],

                            plotOptions: {
                                series: {
                                    cursor: 'pointer',
                                    dataLabels: {
                                        enabled: true
                                    }
                                }
                            }
                        });

                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
            $.fn.GetNoty = function () {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/numberOfNoty",
                    data: '{year:' + $('#ddlYear').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (parseInt(data.d) > 0) {
                            $('span.noty').text(data.d);
                        }
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
            $.fn.CallItemGInfo();
            $.fn.CallMultiInfo();
            $.fn.GetNoty();
            $(".knob").knob();
        });
    </script>
</asp:Content>
