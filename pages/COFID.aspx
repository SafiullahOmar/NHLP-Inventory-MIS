<%@ Page Title="INV_MIS:Items (Fixed Asset) Issue Voucher" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="COFID.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    OFFICE FIXED USED ITEMS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to save office FIXED ITEMS and gives the facility to manipulate the already saved data list and also gives us the right to print the required items Barcodes in  place
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
    <script src="../Script/cofid.js"></script>
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
                                    <div class="form-group col-md-4">
                                        <label class="col-md-5 label-control" for="ddlProvince">Province</label>
                                        <div class="col-md-7">

                                            <asp:DropDownList ID="ddlProvince" CssClass="form-control province" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-8">
                                        <label class="col-md-3 label-control" for="ddlClass">Barcode Number </label>
                                        <div class="col-md-9">
                                            <input id="txtBarcodeNumber" class="form-control pl-3" placeholder="Barcode" type="text">
                                        </div>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <label class="label-control offset-md-4 text-bold-900 text-capitalize  float-md-left" for="ddlSubCategory">Stocked Asset Name & Quantity :</label>
                                        <label class="tag tag-default tag-pill bg-info float-xs-right text-capitalize  text-bold-900 float-md-left " id="lblAsset"></label>
                                        <label class="tag tag-default tag-pill bg-warning float-xs-right text-capitalize  text-bold-900 float-md-left " id="lblQuantity"></label>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">                                   
                                     <div class="form-group col-md-4">
                                        <label class="col-md-3 label-control" for="txtQuantity">Quantity </label>
                                        <div class="col-md-9">
                                            <input id="txtQuantity" class="form-control" placeholder="Quantity" type="text">
                                        </div>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label class="col-md-3 label-control" for="txtReciever">Reciever Name</label>
                                        <div class="col-md-9">
                                            <input id="txtReciever" class="form-control" placeholder="Reciever Name" type="text">
                                        </div>
                                    </div>
                                     <div class="form-group col-md-4">
                                        <label class="col-md-3 label-control" for="ddlSubComponent">S/Comp</label>
                                        <div class="col-md-9">
                                            <select id="ddlSubComponent" class="form-control">
                                            </select>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                   
                                    
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-4">
                                        <label class="col-md-3 label-control" for="txtPosition">Position </label>
                                        <div class="col-md-9">
                                            <input id="txtPosition" class="form-control pl-3" placeholder="Position" type="text">
                                        </div>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label class="col-md-3 label-control" for="txtIssueDate">Issue Date</label>
                                        <div class="col-md-9">
                                            <input id="txtIssueDate" class="form-control pl-3"  placeholder="Issue Date" type="text">
                                        </div>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label class="col-md-3 label-control" for="txtIssueDate">Issued By</label>
                                        <div class="col-md-9">
                                            <input id="txtIssuer" class="form-control pl-3" placeholder="Issued By" type="text">
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <label class="col-md-1 label-control" for="txtRemarks">Remarks </label>
                                        <div class="col-md-11">
                                            <input id="txtRemarks" class="form-control pl-3" placeholder="Remarks" type="text">
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

        <div class="row">
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
        </div>
        <div id="pnlCode"></div>
    </section>
</asp:Content>

