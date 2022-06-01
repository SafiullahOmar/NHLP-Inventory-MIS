<%@ Page Title="INV_MIS:Goods Return Voucher (FA)" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Fixed_Asset_Return.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    Fixed Asset Return Voucher
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to save office FIXED ITEMS and gives the facility to manipulate the already saved data list and also gives us the right to print the required items Barcodes in  place
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
    <script src="../Script/Fixed_Asset_Return.js"></script>
    <section id="horizontal-form-layouts">

        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title" id="horz-layout-card-center">Fixed Asset Items Detail</h4>
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
                                <p>Please fill the below <code>form </code>according to the requirements.</p>
                            </div>
                            <hr />
                            <div class="form form-horizontal">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="form-group col-md-12">
                                                <label class="col-md-4 label-control" for="ddlProvince">Province</label>
                                                <div class="col-md-8">
                                                    <asp:dropdownlist id="ddlProvince" cssclass="form-control province" runat="server"></asp:dropdownlist>
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12">
                                                <label class="col-md-4 label-control" for="ddlSubComponent">S/Component</label>
                                                <div class="col-md-8">
                                                    <select class="form-control" id="ddlSubComponent"></select>
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12">
                                                <label class="col-md-4 label-control" for="ddlReciever">Reciever</label>
                                                <div class="col-md-8">
                                                    <select class="form-control" id="ddlReciever"></select>
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12">
                                                <label class="col-md-4 label-control" for="ddlAsset">Asset Name</label>
                                                <div class="col-md-8">
                                                    <select class="form-control" id="ddlAsset"></select>
                                                </div>
                                            </div>

                                            <div class="form-group col-md-12">
                                                <label class="label-control offset-md-4 text-bold-900 text-capitalize  float-md-left">Issued Quantity :</label>
                                                <label class="tag tag-default tag-pill bg-info float-xs-right text-capitalize  text-bold-900 float-md-left " id="lblQuantiy"></label>
                                                <label class="tag tag-default tag-pill bg-warning float-xs-right text-capitalize  text-bold-900 float-md-left  " style="visibility:hidden;" id="lblCOFID"></label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 border-left-blue-grey">
                                        <div class="row">
                                            <div class="form-group col-md-12">
                                                <label class="col-md-4 label-control" for="ddlStatus">Asset Status</label>
                                                <div class="col-md-8">
                                                    <select class="form-control" id="ddlStatus">
                                                        <option value="-1">--Select--</option>
                                                        <option value="1">Good</option>
                                                        <option value="-1">Damaged</option>
                                                        
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12">
                                                <label class="col-md-4 label-control" for="txtReturnQuantity">Return Quantity</label>
                                                <div class="col-md-8">
                                                    <input id="txtReturnQuantity" class="form-control" placeholder="Return Quantity" type="text">
                                                </div>
                                            </div>
                                               <div class="form-group col-md-12">
                                                <label class="col-md-4 label-control" for="txtReturnQuantity">Return Date</label>
                                                <div class="col-md-8">
                                                    <input id="txtRDate" class="form-control date" placeholder="Return Date" type="text">
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12">
                                                <label class="col-md-4 label-control" for="txtRemarks">Reason & Remarks</label>
                                                <div class="col-md-8">
                                                    <input id="txtRemarks" class="form-control" placeholder="Remarks" type="text">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <div class="form-actions center">
                                <button type="button" class="btn btn-warning mr-1" onclick="ClearForm();">
                                    <i class="icon-cross2"></i>Cancel
	                           
                                </button>
                                <button type="button" id="btnSave" class="btn btn-primary">
                                    <i class="icon-check2"></i>Save
	                           
                                </button>
                                <button type="button" id="btnUpdate" class="btn btn-info">
                                    <i class="icon-check-circle"></i>Update
	                           
                                </button>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--<div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="icon-data" id="horz-layout-basic">Office Fixed Items Information </h4>
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
                                <p>Find the required <code>item</code>  from the list , According to your right you are able to delete the item from the system or print its <code>barcode</code> </p>
                            </div>
                            <div id="dtTableDetail">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
       <%-- <div id="pnlCode"></div>--%>
    </section>
</asp:Content>

