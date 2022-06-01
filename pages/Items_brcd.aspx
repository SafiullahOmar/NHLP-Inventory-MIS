<%@ Page Title="INV_MIS:Items Barcode Printing" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Items_brcd.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    RECIEVED ITEMS BARCODE
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to retrieve items voucher details,additionally it gives the facility to print iems Barcode according to user right. 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
   
    <script src="../Script/Items_brcd.js"></script>
    <section id="horizontal-form-layouts">

        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title" id="horz-layout-card-center">Items Detail</h4>
                        <a class="heading-elements-toggle"><i class="icon-ellipsis font-medium-3"></i></a>
                        <div class="heading-elements">
                            <ul class="list-inline mb-0">
                                <li><a data-action="collapse"><i class="icon-minus4"></i></a></li>
                                <li><a data-action="reload"><i class="icon-reload "></i></a></li>
                                <li><a data-action="expand"><i class="icon-expand2"></i></a></li>
                                <li><a data-action="close"><i class="icon-cross2"></i></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="card-body collapse in">
                        <div class="card-block">
                            <div class="card-text">
                                Please <code>fill</code> the below form according to requirements. 
                            </div>
                            <hr />
                            <div class="form form-horizontal">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="form-group col-md-4">
                                            <label class="col-md-4 label-control" for="txtRecievedDate">Recieved Date </label>
                                            <div class="col-md-8">
                                                <input id="txtRecievedDate" class="form-control" placeholder="Product/Item Recived Date" type="text">
                                            </div>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label class="col-md-4 label-control" for="ddlProvince">Province</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlProvince" CssClass="form-control province" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label class="col-md-3 label-control" for="ddlSupplier">Supplier</label>
                                            <div class="col-md-9">

                                                <select id="ddlSupplier" class="form-control"></select>
                                            </div>
                                        </div>
                                       
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="icon-data" id="horz-layout-basic">Recieved Items Information</h4>
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
                            <div class="card-text">
                                Find the required item from the list , According to your right you are able to print the item BARCODE into the system. 
                            </div>
                            <div id="dtItemBrcd">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>


    <div id="pnlCode" style="padding: 0px; overflow: auto; width: 87px;">
    </div>
    <a   id="btnG"></a>

</asp:Content>

