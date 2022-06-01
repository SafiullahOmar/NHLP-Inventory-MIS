<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PReq_d.aspx.cs" Inherits="pages_ReqApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    ISSUED REQUISITIONS DESCRIPTION
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
     The below form provide us the details for those requisitions which were issued or processed.Also give us the facility to manipulate the data list according to the user rights . 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
    <script src="../Script/PReq_d.js"></script>
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
                                <h6 class="far text-md-center">Issued Form Informations  </h6>
                            </div>
                            <div class="col-md-4">
                                <h4 class="far text-md-center mt-3">د افغانستان د اسلامی جمهوریت </h4>
                                <h4 class="far text-md-center">دکرنی ،اوبه لګونی او مالداری وزارت</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card-text">
                                    <p class="far bold">معلومات درخواست های صادر شده</p>
                                    <hr />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">

                                <p>Please <code>click on ISSUE links </code>in the table row to <code>Issue OR Cancel Request items </code>for the users . <code>The List </code>will be shown according to your<code>Roles</code> in the system.</p>

                                <table id="tblItemInsertion" class='table table-xs nowrap table-striped' width='100%' cellspacing='0'>
                                    <thead>
                                        <tr class="far text-md-center">
                                            
                                            <th>S.NO</th>
                                            <th>Req #</th>
                                            <th>Req Type</th>                                            
                                            <th>Requested By</th>
                                            <th>Position</th>
                                            <th>Location</th>
                                            <th>Unit</th>
                                            <th>(#)T Items Req</th>
                                            <th>(#)T Items Issued</th>
                                            <th>Issue #</th>
                                            <th>Downoald</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                </table>
                                <%--<div id="dvIssuetbl">

                                </div>--%>
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

    
           
    <input type="hidden" id="hdnDeptId" />
    <input type="hidden" id="hdnProvId" /><input type="hidden" id="hdnReqId" />
</asp:Content>

