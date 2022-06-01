<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Transfer_Fixed_Assets.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    TRANSFER Fixed Assets
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to record the items which are transfered from one regions to other regions and also provide you the list which gives more facility to manipulate the transfer list items according to user right.
</asp:Content>  
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">

    <script src="../Script/Transfer_Fixed_Assets.js"></script>
    <section id="horizontal-form-layouts">

        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title" id="horz-layout-card-center"><a id="lnkSearch" class="btn btn-social-icon mr-1 mb-1 btn-outline-dropbox" href="#"><span class="icon-search font-medium-4"></span></a>&nbsp Transfer Asset Details</h4>
                        <a class="heading-elements-toggle"><i class="icon-ellipsis font-medium-3"></i></a>
                        <div class="heading-elements">
                            <ul class="list-inline mb-0">
                                <li><a data-action="collapse"><i class="icon-minus4"></i></a></li>
                                <li><a data-action="reload"><i class="icon-reload"></i></a></li>
                                <li></li>
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
                                            <div class="row">
                                                <div class="form-group col-md-12">
                                                    <label class="col-md-5 label-control" for="txtTransferDate">Transfer Date </label>
                                                    <div class="col-md-7">
                                                        <input id="txtTransferDate" class="form-control" placeholder="Transfer Date" type="text">
                                                    </div>
                                                </div>
                                                <div class="form-group col-md-12">
                                                    <label class="col-md-5 label-control" for="ddlProvince">Transfer Province</label>
                                                    <div class="col-md-7">

                                                        <asp:DropDownList ID="ddlTProvince" CssClass="form-control Tprovince" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group col-md-12">
                                                    <label class="col-md-5 label-control" for="ddlDepartment">Transfer Department</label>
                                                    <div class="col-md-7">

                                                        <select id="ddlTDepartment" class="form-control"></select>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 border-left-blue-grey">
                                            <div class="row">

                                                <div class="form-group col-md-12">
                                                    <label class="col-md-5 label-control" for="ddlRProvince">Reciever Province</label>
                                                    <div class="col-md-7">

                                                        <asp:DropDownList ID="ddlRProvince" CssClass="form-control Rprovince" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group col-md-12">
                                                    <label class="col-md-5 label-control" for="ddlRDepartment">Reciever Department</label>
                                                    <div class="col-md-7">

                                                        <select id="ddlRDepartment" class="form-control"></select>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <div class="row mt-2">
                                        <div class="form-group col-md-12">
                                            <label class="col-md-2 label-control" for="txtBrcd">Barcode #</label>
                                            <div class="col-md-10">
                                                <input id="txtBrcd" class="form-control" placeholder="Barcode #" type="text">
                                            </div>
                                        </div>

                                        <div class="form-group col-md-12">
                                            <label class="col-md-2 label-control" for="txtItemQuantity">Quantity</label>
                                            <div class="col-md-10">
                                                <input id="txtItemQuantity" class="form-control" placeholder="Quantity" type="text">
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">


                                            <p>Transfer Goods list .<code> You can Manipulate the list either </code></p>
                                            <div class="float-lg-right" id="dvNumberInStocked"></div>
                                            <p>
                                                <a id="lnkIssueItemInsert" data-backdrop="false" class="btn btn-social-icon mr-1 mb-1 green btn-outline-dropbox" href="#"><span class="icon-plus-circle font-medium-4"></span></a>
                                                <a id="lnkIssueItemRemove" class="btn btn-social-icon mr-1 mb-1 green btn-outline-dropbox" href="#"><span class="icon-delete font-medium-4"></span></a>
                                            </p>
                                            <table id="tblIssuedItems" class='table table-striped scroll-horizontal '>
                                                <thead>
                                                    <tr>
                                                        <th>Select</th>
                                                        <th>S.NO</th>
                                                        <th>Item</th>
                                                        <th>Quantity</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                </tbody>
                                            </table>
                                            <div class="float-md-right font-weight-bold blue">
                                                <div id="dvIssueTotalItems"></div>
                                            </div>
                                        </div>


                                    </div>



                                    <div class="row mt-3">                                       
                                        <div class="form-group col-md-12">
                                            <label class="col-md-2 label-control blue" for="txtSender">Transfered By</label>
                                            <div class="col-md-10">
                                                <input id="txtIssuer" class="form-control" placeholder="Sender " type="text">
                                            </div>
                                        </div>


                                        <div class="form-group col-md-12">
                                            <label class="col-md-2 label-control blue" for="txtRemarks">Remarks &nbsp;</label>
                                            <div class="col-md-10">
                                                <input id="txtRemarks" class="form-control blue" placeholder="Remakrs" type="text">
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



    </section>
    <input type="hidden" id="hdnRVoucherItemID" />
    <input type="hidden" id="hdnRVoucherSr" />
    

    <!--Modal Search-->
    <div class="modal fade text-xs-left" id="MDSearch" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-success">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="H1"><i class="icon-road2"></i>&nbsp; Transfered Goods Data List</h4>
                </div>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div id="dvSearch" class="nowrap  " style="width:800px;margin:0 auto;">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn grey btn-outline-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <!--Modal-->
    <%--<div class="modal fade text-xs-left" id="MDItemInsert" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-info">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel2"><i class="icon-road2"></i>&nbsp; Transfered Goods Data List</h4>
                </div>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group ">
                                    <label class="label-control blue" for="txtRecievedDate">Item Class </label>
                                    <select id="ddlReviecedItemClass" class="form-control border-primary"></select>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group ">
                                    <label class="label-control blue" for="txtRecievedDate">Item Category (Sub Class) </label>
                                    <select id="ddlReviecedItemSubClass" class="form-control border-primary"></select>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group ">
                                    <label class="label-control blue" for="ddlClass">Item / Product </label>
                                    <select id="ddlReviecedItems" class="form-control border-primary"></select>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="label-control blue" for="txtQuantity">Quantity</label>
                                    <input id="txtQuantity" class="form-control border-primary" placeholder="Quantity" type="text">
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="label-control blue" for="txtInvoiceQuantity">Invoice Quantity</label>
                                    <input id="txtInvoiceQuantity" class="form-control border-primary" placeholder="Invoice Quantity" type="text">
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="label-control blue" for="txtModal">Modal</label>
                                    <input id="txtModal" class="form-control border-primary" placeholder="Modal" type="text">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="label-control blue" for="txtSerial">Serial #</label>
                                    <input id="txtSerial" class="form-control border-primary" placeholder="Serial #" type="text">
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="label-control blue" for="txtUnitPrice">Unit Price</label>
                                    <input id="txtUnitPrice" class="form-control border-primary" placeholder="Unit Price" type="text">
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="label-control blue" for="txtTotalPrice">Total Price</label>
                                    <input id="txtTotalPrice" class="form-control border-primary" disabled placeholder="Total Price" type="text">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="label-control blue " for="txtItemRemarks">Remarks</label>
                                    <input id="txtItemRemarks" class="form-control border-primary" placeholder="Remarks" type="text">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn grey btn-outline-secondary" data-dismiss="modal">Close</button>
                    <button type="button" id="btnAddtoItemList" class="btn btn-outline-primary">Add to List</button>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>

