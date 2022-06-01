<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="recReq_d.aspx.cs" Inherits="pages_ReqApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    ITEMS RECIEVEING VOUCHERS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
     The below form provide us the details for those requisitions which were recieved at our stores or ware houses.Also give us the facility to manipulate the data list according to the user rights . 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
    <script src="../Script/recReq_d.js"></script>
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
                                <h5 class="far text-md-center">(NHLP) د بڼوالی او مالداری ملی پروژه</h5>
                                <h5 class="far text-md-center">(Operation ) د خدماتو څانګه /  شعبه خدمات</h5>
                                <h6 class="far text-md-center">Received Vouchers Form Informations  </h6>
                            </div>
                            <div class="col-md-4">
                                <h4 class="far text-md-center mt-3">د افغانستان د اسلامی جمهوریت </h4>
                                <h4 class="far text-md-center">دکرنی ،اوبه لګونی او مالداری وزارت</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card-text">
                                    <p class="far bold">معلومات برای اجناس وصول شده </p>
                                    <hr />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">

                                <p><strong><u> Search your Required  Recieveing Voucher and click on Downoald to find it on your machine.</u></strong></p>

                                <table id="tblItemInsertion" class='table table-xs nowrap table-striped' width='100%' cellspacing='0'>
                                    <thead>
                                        <tr class="far text-md-center">
                                            
                                            <th>S.NO</th>
                                            <th>Province</th>
                                            <th>Department</th>                                            
                                            <th>Receiving Date</th>
                                            <th>Received By</th>
                                            <th>Invoice Number</th>
                                            <th>M16 Number</th>
                                            <th>Supplier</th>
                                            <th>Inspection Date</th>
                                            <th>Downoald</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    

    
           
    <input type="hidden" id="hdnDeptId" />
    <input type="hidden" id="hdnProvId" /><input type="hidden" id="hdnReqId" />
</asp:Content>

