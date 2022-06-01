<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="tansfer_items_w_app.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    TRANSFERED GOODS APPROVAL
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
     The below form is going to approve the items which were transfered to your regions. Please be noted once you approved then your approval won't be rollbacked again.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">

    <script src="../Script/transfer_items_w_approval.js"></script>
    <section id="horizontal-form-layouts">

        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title" id="horz-layout-card-center"> Transfered Items Description</h4>
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
                            <div class="card-text">
                                <p><code>Search the required transfered items on the basis of below description</code></p>
                            </div>
                            <div class="form form-horizontal">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="form-group col-md-4">
                                            <label class="col-md-5 label-control" for="txtTransferDate">Issued Month/Date </label>
                                            <div class="col-md-7">
                                                <input id="txtTransferMonth" class="form-control" placeholder="Transfer Date" type="text">
                                            </div>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label class="col-md-5 label-control" for="ddlProvince">Issued Province</label>
                                            <div class="col-md-7">

                                                <asp:DropDownList ID="ddlTProvince" CssClass="form-control Tprovince" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label class="col-md-5 label-control" for="ddlDepartment">Issued Department</label>
                                            <div class="col-md-7">

                                                <select id="ddlTDepartment" class="form-control"></select>
                                            </div>
                                        </div>
                                    </div>





                                    <div class="row">
                                        <div class="col-md-12">
                                            <div id="dvTblTransfItems">
                                            </div>
                                        </div>
                                    </div>


                                </div>

                                <div class="form-actions center">
                                    <button type="button" class="btn btn-warning mr-1" onclick="ClearForm();">
                                        <i class="icon-cross2"></i>Cancel
	                           
                                    </button>
                                    <button type="button" id="btnApprove"  class="btn btn-primary">
                                        <i class="icon-check2"></i>Approve
	                           
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
    <!--Modal-->
    <div class="modal fade text-xs-left" id="MDItemInsert" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-info">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel2"><i class="icon-road2"></i>&nbsp; Items Insertion Form</h4>
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
    </div>

    <!--Modal Search-->
    <div class="modal fade text-xs-left" id="MDSearch" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-success">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="H1"><i class="icon-road2"></i>&nbsp; Items Insertion Form</h4>
                </div>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div id="dvSearch" class="nowrap  " style="width: 800px; margin: 0 auto;">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn grey btn-outline-secondary" data-dismiss="modal">Close</button>
                    <button type="button" id="Button1" class="btn btn-outline-primary">Add to List</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

