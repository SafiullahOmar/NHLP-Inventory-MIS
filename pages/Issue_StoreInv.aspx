<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Issue_StoreInv.aspx.cs" Inherits="pages_ReqApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    STORE FIXED ASSET ISSUE FORM
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to issue items in the system on the base of those requisition forms which were processed and approved by thier relevant supervisors .Fill the form according to the requirments, and always keep the Items Barcode or its number while issuing the products. 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
    <script src="../Script/Issue_store.js"></script>
    <div class="row  bg-amber bg-darken-4  ">
        <div class="col-md-12 bg-amber bg-darken-4">
            <div class="card">
                <div class="card-body">
                    <div class="card-block">

                        <div class="row ">
                            <div class="col-md-4">
                                <h4 class="far text-md-center mt-3">جمهوری اسـلامی افغانستان</h4>
                                <h4 class="far text-md-center">وزارت زراعت آبیاری و مالداری</h4>
                            </div>
                            <div class="col-md-4 text-md-center">
                                <img src="../APPContent/images/mail.png" style="height: 70px; width: 70px;" />
                                <h5><strong>Islamic Republic of Afghanistan</strong></h5>
                                <h5><strong>Ministry of Agriculture & Irrigation and Livestock</strong></h5>
                                <h5 class="far text-md-center">(NHLP) د باغداری او مالداری ملی پروژه</h5>
                                <h5 class="far text-md-center">(Operation ) د خدماتو څانګه /  شعبه خدمات</h5>
                                <h6 class="far text-md-center">Store Section <code>Store Items Issue form</code>  </h6>
                            </div>
                            <div class="col-md-4">
                                <h4 class="far text-md-center mt-3">د افغانستان د اسلامی جمهوریت </h4>
                                <h4 class="far text-md-center">دکرنی ،اوبه لګونی او مالداری وزارت</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card-text">
                                    <p class="far bold">معلومات درخواست های پیشنهاد شده</p>
                                    <hr />
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-12">

                                <p>Please <code>click on ISSUE links </code>in the table row to <code>Issue OR Cancel Request items </code>for the users . <code>The List </code>will be shown according to your<code>Roles</code> in the system.</p>

                                <table id="tblItemInsertion" class='table display nowrap table-striped table-bordered scroll-horizontal'>
                                    <thead>
                                        <tr class="far text-md-center">
                                            <th>Select</th>
                                            <th>S.NO</th>
                                            <th>Req #</th>
                                            <th>Requested By</th>
                                            <th>Position</th>
                                            <th>Unit</th>
                                            <th>Location</th>
                                            <th>(#)T Items</th>
                                            <th>Days Last</th>
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
                </div>
            </div>
        </div>
    </div>

    <%-- Modal --%>
    <div class="modal fade text-xs-left" id="MDReqItemsD" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog ">
            <div class="modal-content">
                <div class="modal-header bg-success">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title"><i class="icon-road2"></i>&nbsp; Items Details</h4>
                </div>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div id="tblReqItemDetail">
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

    <%-- Modal --%>
    <div class="modal fade text-xs-left" id="MDItemIssueDetail" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-success">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title"><i class="icon-road2"></i>&nbsp; Items ISSUE Details</h4>
                </div>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="row">
                            <div class="col-md-4 border-right-blue">
                                <h5 class="blue">Requested Items Details </h5>
                                <div id="DivLeftReqItemDetail">
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div id="DivRightNewIssueDetails">
                                    <div class="row">
                                        <div class="form-group col-md-5">
                                            <label class="col-md-5 label-control" for="txtBrcd">Barcode #</label>
                                            <div class="col-md-7">
                                                <input id="txtBrcd" class="form-control" placeholder="Barcode #" type="text">
                                            </div>
                                        </div>
                                        <div class="form-group col-md-7">
                                            <label class="col-md-3 label-control" for="txtItemInfo">Item Detail</label>
                                            <div class="col-md-9">
                                                <input id="txtItemInfo" class="form-control" disabled placeholder="Item Detail" type="text">
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


                                            <p>Office Supplue Issue Voucher <code>Items Description</code> . You can Manipulate the list</p>
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

                                        <div class="col-md-12 border-top-blue pt-1 mt-1">
                                            <div class="form-group col-md-6">
                                                <label class="col-md-4 label-control far" for="txtIssueDate">Issued Date</label>
                                                <div class="col-md-8">
                                                    <input id="txtIssueDate" class="form-control far" placeholder="Issue Date" type="text">
                                                </div>
                                            </div>
                                           <%-- <div class="form-group col-md-4">
                                                <label class="col-md-4 label-control far" for="txtIssuedBy">Items Issued By</label>
                                                <div class="col-md-8">
                                                    <input id="txtIssuedBy" class="form-control far" placeholder="Issued By" type="text">
                                                </div>
                                            </div>--%>
                                            <div class="form-group col-md-6">
                                                <label class="col-md-4 label-control far" for="txtRecievedBy">Recieved By</label>
                                                <div class="col-md-8">
                                                    <input id="txtRecievedBy" class="form-control far" placeholder="Recieved By" type="text">
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12">
                                                <label class="col-md-1 label-control far" for="txtRecievedBy">Remarks</label>
                                                <div class="col-md-11">
                                                    <input id="txtRemarks" class="form-control far" placeholder="Remarks" type="text">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn mr-1 mb-1 btn-outline-deep-orange" data-dismiss="modal"><i class="icon-close-circled"></i>Close</button>
                    <button type="button" class="btn mr-1 mb-1 btn-outline-success" id="btnIssue"><i class=" icon-save"></i>Issue Items</button>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" id="hdnDeptId" />
    <input type="hidden" id="hdnProvId" />
    <input type="hidden" id="hdnReqId" />
</asp:Content>

