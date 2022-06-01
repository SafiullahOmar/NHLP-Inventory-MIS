<%@ Page Title="INV_MIS:Goods Receiving Voucher" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="items_receiving_v.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    RECIEVE ITEMS VOUCHER
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to save recieve items voucher details form supplier and also this form gives the facility to manipulate the recieved items list or print recieve items vouchers  according to user right. 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">

    <script src="../Script/Recieved_Items.js"></script>
    <section id="horizontal-form-layouts">

        <div class="row">
            <div class="col-md-12 bg-grey ">
                <div class="card">
                    <div class="card-body">
                        <div class="card-block">

                            <div class="row">
                                <div class="col-md-12 ">
                                    <div class="card">
                                        <div class="card-header">
                                            <h4 class="card-title" id="horz-layout-card-center"><a id="lnkSearch" class="btn btn-social-icon mr-1 mb-1 btn-outline-dropbox" href="#"><span class="icon-search font-medium-4"></span></a>&nbsp Recieve Items Detail</h4>
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
                                                    Please <code>fill</code> the below form according to requirements. 
                                                </div>
                                                <hr />
                                                <div class="form form-horizontal">
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class=" label-control" for="txtRecievedDate">Recived Date </label>

                                                                <input id="txtRecievedDate" class="form-control" placeholder="Recieved Date" type="text">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="label-control" for="ddlProvince">Province</label>

                                                                <asp:DropDownList ID="ddlProvince" CssClass="form-control province" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="label-control" for="ddlDepartment">Reciever Department</label>


                                                                <select id="ddlDepartment" class="form-control"></select>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="label-control" for="txtInvoice">Invoice #</label>

                                                                <input id="txtInvoice" class="form-control" placeholder="Invoice #" type="text">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="label-control" for="txtPurchaseRef">Contract #</label>

                                                                <input id="txtPurchaseRef" class="form-control" placeholder="Contract #" type="text">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group ">
                                                                <label class="label-control" for="txtSupplier">Supplier</label>

                                                                <input id="txtSupplier" class="form-control" placeholder="Supplier" type="text">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 ">
                                    <div class="card border-cyan border-lighten-2 ">
                                        <div class="card-header bg-amber bg-accent-1 ">
                                            <div class="card-text">
                                                <p><b>Vouchers Inspectors</b></p>
                                            </div>
                                            <a class="heading-elements-toggle"><i class="icon-ellipsis font-medium-3"></i></a>
                                            <div class="heading-elements">
                                                <ul class="list-inline mb-0">
                                                    <li><a data-action="collapse"><i class="icon-minus4"></i></a></li>
                                                    <li><a data-action="close"><i class="icon-cross2"></i></a></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="card-body collapse in">
                                            <div class="row">
                                                <%-- <div class="form-group col-md-12">
                                        <label class="col-md-2 label-control blue" for="txtInspectedBy">Inspected By</label>
                                        <div class="col-md-10">
                                            <input id="txtInspectedBy" class="form-control" placeholder="Inspected By" type="text">
                                        </div>
                                    </div>--%>

                                                <div class="col-md-3 offset-md-2 center">
                                                    <div class="form-group ">
                                                        <label class=" label-control" for="txtInspector">Inspector Name</label>

                                                        <input id="txtInspector" class="form-control" placeholder="Inspector Name" type="text">
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group ">
                                                        <label class="label-control" for="txtPosition">Position</label>

                                                        <input id="txtPosition" class="form-control" placeholder="Position" type="text">
                                                    </div>

                                                </div>
                                                <div class="col-md-2">
                                                    <p>
                                                        <br />
                                                        <a id="lnkAddInpector" data-backdrop="false" class="btn btn-social-icon mr-1 mb-1 btn-outline-dropbox teal" href="#"><span class="icon-plus-circle font-medium-4"></span></a>
                                                        <a id="lnkDeleteInspector" class="btn btn-social-icon mr-1 mb-1 btn-outline-dropbox teal" href="#"><span class="icon-delete font-medium-4"></span></a>

                                                    </p>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-10 offset-md-1 center">

                                                    <table id="tblInspectors" class='table display nowrap table-striped table-bordered scroll-horizontal'>
                                                        <thead>
                                                            <tr class="far text-md-center">
                                                                <th>Select</th>
                                                                <th>S.No</th>
                                                                <th>Insp.Name</th>
                                                                <th>Position</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-7 offset-md-2 center">
                                                    <div class="form-group">
                                                        <label class="label-control blue" for="txtInspectionDate">Inspection Date</label>
                                                        <input id="txtInspectionDate" class="form-control" placeholder="Inspection Date" type="text"><br />

                                                    </div>
                                                </div>
                                   <%--             <div class="col-md-3 mt-2">
                                                    <a id="lnPrintInspectionD" data-backdrop="false" class=" btn  btn-social-icon mr-1 mb-1 btn-outline-dropbox teal" href="#"><span class="icon-print font-medium-4"></span></a>

                                                </div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12  ">
                                    <div class="card">
                                        <div class="card-header">
                                            <div class="card-text">
                                                <p><b>Voucher Item Details</b></p>
                                            </div>
                                            <a class="heading-elements-toggle"><i class="icon-ellipsis font-medium-3"></i></a>
                                            <div class="heading-elements">
                                                <ul class="list-inline mb-0">
                                                    <li><a data-action="collapse"><i class="icon-minus4"></i></a></li>
                                                    <li><a data-action="close"><i class="icon-cross2"></i></a></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="card-body collapse in">
                                            <div class="row m-1">
                                                <div class="col-md-12">
                                                    <p>Goods Reciveing Voucher <code>Items Description</code> . You can Manipulate the list</p>
                                                    <p>
                                                        <a id="lnkShowItemInsertModal" data-backdrop="false" class="btn btn-social-icon mr-1 mb-1 btn-outline-dropbox" href="#"><span class="icon-plus-circle font-medium-4"></span></a>
                                                        <a id="lnkShowItemRemove" class="btn btn-social-icon mr-1 mb-1 btn-outline-dropbox" href="#"><span class="icon-delete font-medium-4"></span></a>
                                                    </p>
                                                    <div class="nowrap" style="width: 820px; margin: 0 auto;">
                                                        <table id="tblItemInsertion" class='table table-xs nowrap table-striped ' width='100%' cellspacing='0'>
                                                            <thead>
                                                                <tr>
                                                                    <th>Select</th>
                                                                    <th>S.NO</th>
                                                                    <th>Item</th>
                                                                    <th>Quantity</th>
                                                                    <th>Invoice Quantity</th>
                                                                    <th>Modal</th>
                                                                    <th>Serial</th>
                                                                    <th>Total Price</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                        <div class="float-md-right font-weight-bold blue">
                                                            <div id="cTotalAmount"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row m-1">
                                                <div class="col-md-12">
                                                    <div class="form-group ">
                                                        <label class=" label-control blue" for="txtRemarks">Remarks &nbsp;</label>
                                                        <input id="txtRemarks" class="form-control blue" placeholder="Remakrs" type="text">
                                                    </div>

                                                </div>
                                                <%--<div class="col-md-6">
                                                    <div class="form-group">
                                                        <div class="card-text  label-control">
                                                            <p><b>*** :: Please Upload Inpection list <code>(Required)</code></b></p>
                                                        </div>

                                                    </div>
                                                </div--%>
                                                <%--<div class="col-md-4">
                                                    <input type="file" id="FileUpload1" />
                                                    <a id="lnkFile"></a>
                                                </div>--%>

                                            </div>

                                            <div class="row mt-3 mb-2">
                                                <div class="col-md-12 text-md-center">
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <input type="hidden" id="hdnRVoucherItemID" />
    <input type="hidden" id="hdnRVoucherSr" />
    <input type="hidden" id="hdnSerialNumber" />
    <!--Modal-->
    <div class="modal fade text-xs-left" id="MDItemInsert" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-facebook bg-accent-1  white">
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
                <div class="modal-header bg-primary bg-lighten-3">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="H1"><i class="icon-road2"></i>&nbsp; Items Recieved Voucher</h4>
                </div>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div id="tblSearch">
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

