<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ReqApproval.aspx.cs" Inherits="pages_ReqApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    REQUISITION FORM APPROVAL
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to show the list of the requests that you have to APPROVE or REJECT the form . 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
    <script src="../Script/ReqApproval.js"></script>
    <div class="row  bg-warning bg-darken-4  ">
        <div class="col-md-12 bg-warning bg-darken-4">
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
                                <h6 class="far text-md-center">په سیستم کی د غوښتل شوی اجناسو باوری کړنه    </h6>
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
                            <div class="col-md-12 noOfsReq"></div>
                            <div class="col-md-12">
                                <div class="nowrap" style=" margin: 0 auto;">

                                    <p>Please <code>check checkbox </code>in the table row to <code>approve or reject </code>the user requests forms . The List will be shown according to your<code>Roles</code> in the system.</p>

                                    <table id="tblItemInsertion" class='table display nowrap table-striped table-bordered scroll-horizontal-vertical' cellspacing='0'>
                                        <thead>
                                            <tr class="far text-md-center">
                                                <th>Select</th>
                                                <th>S.NO</th>
                                                <th>Req #</th>
                                                <th>Requested By</th>
                                                <th>Requested Type</th>
                                                <th>Position</th>
                                                <th>Location</th>
                                                <th>Unit</th>
                                                <th>(#)T Items</th>
                                                <th>Days Last</th>
                                                <th>Documents</th>
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
                        <div class="row">
                            <div class="form form-horizontal">
                                <div class="form-actions center">
                                    <button type="button" class="btn btn-danger mr-1" id="btnReject">
                                        <i class="icon-cross2"></i>Reject Requests
	                           
                                    </button>
                                    <button type="button" id="btnApprove" class="btn btn-success">
                                        <i class="icon-check2"></i>Approve Requests
	                           
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Modal --%>
    <div class="modal fade text-xs-left" id="MDItemsD" tabindex="-1" role="dialog" aria-hidden="true">
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
                                <div id="tblItemDetail">
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
</asp:Content>

