<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ReqS.aspx.cs" Inherits="pages_Req" %>

<asp:Content ID="Content1" Visible="false" ContentPlaceHolderID="pageTopic" runat="Server">
    STORE ITEMS REQUISITION FORM 
</asp:Content>
<asp:Content ID="Content2"  Visible="false"  ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to save and process your store request .Fill the form according to the requirments, and always keep you request number while it is generated from the system. 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
    <script src="../Script/StoreReqS.js"></script>
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
                                <h6 class="far text-md-center"> Requisition Form (<code> Store Items</code>)</h6>
                            </div>
                            <div class="col-md-4">
                                <h4 class="far text-md-center mt-3">د افغانستان د اسلامی جمهوریت </h4>
                                <h4 class="far text-md-center">دکرنی ،اوبه لګونی او مالداری وزارت</h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card-text">
                                    <p class="far bold">REQUESTER INFORMATION  / معلومات درخواست کننده</p>
                                    <hr />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form form-horizontal">
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="form-group col-md-12">
                                                <label class="col-md-3 label-control " for="txtRequester">Name</label>
                                                <div class="col-md-9">
                                                    <input id="txtRequester" class="form-control input-sm font-small-3" placeholder="Requester Name" type="text">
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12 ">
                                                <label class="col-md-3 label-control" for="txtPosition">Position</label>
                                                <div class="col-md-9">
                                                    <input id="txtPosition" class="form-control input-sm font-small-3" placeholder="Position" type="text">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form form-horizontal">
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="form-group col-md-12 rtl">
                                                <label class="col-md-3 label-control" for="ddlProvince">ًDuty Station</label>
                                                <div class="col-md-9">
                                                    <select class="form-control input-sm" id="ddlProvince"></select>
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12 rtl">
                                                <label class="col-md-3 label-control" for="ddlDepartment">Department</label>
                                                <div class="col-md-9">
                                                    <select class="form-control input-sm" id="ddlDepartment"></select>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">

                                <p>Goods Reciveing Voucher <code>Items Description</code> . You can Manipulate the list</p>
                                <p>
                                    <a id="lnkShowItemInsertModal" data-backdrop="false" class="btn btn-social-icon mr-1 mb-1 btn-outline-dropbox warning" href="#"><span class="icon-plus-circle font-medium-4"></span></a>
                                    <a id="lnkShowItemRemove" class="btn btn-social-icon mr-1 mb-1 btn-outline-dropbox warning" href="#"><span class="icon-delete font-medium-4"></span></a>
                                </p>
                                <table id="tblItemInsertion" class='table display nowrap table-striped table-bordered scroll-horizontal'>
                                    <thead>
                                        <tr class="far text-md-center">
                                            <th>Select</th>
                                            <th>S.NO /ګڼه</th>
                                            <th>Item /جنس</th>
                                            <th>Unit /واحد</th>
                                            <th>Quantity Req/غوښتل شوی مقدار</th>
                                            <th>Remarks/ملاحظات</th>
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

                        <hr />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form form-horizontal">
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="form-group col-md-12">
                                                <div class="card-text col-md-7 label-control">
                                                    <p class=" bold">Please select your <code>Supervisor</code> which this request should be sent to him </p>
                                                </div>
                                                <div class="col-md-5">
                                                    <select class="form-control far" id="ddlSupervisor"></select>
                                                </div>
                                            </div>
                                            <div class="form-group col-md-12">
                                                <div class="card-text col-md-7 label-control">
                                                    <p class=" bold">(*) NOTE <code>Please mention your Email</code> , If you are interested to get notification and track your request </p>
                                                </div>
                                                <div class="col-md-5">
                                                    <input id="txtEmail" class="form-control input-sm font-small-3" placeholder="Email" type="text">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="form form-horizontal">
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
    </div>

    <div class="modal fade text-xs-left" id="MDItemInsert"  role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-warning ">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel2"><i class="icon-road2"></i>&nbsp; Items Insertion Form</h4>
                </div>
                <div class="modal-body">
                    <div class="form form-horizontal">
                        <div class="form-body">
                            <div class="row far text-md-center">
                                <div class="form-group col-md-12">
                                    <label class="col-md-3 label-control " for="txtRequester">Item/جنس</label>
                                    <div class="col-md-9">
                                        <%--<input id="txtItems" class="form-control input-sm font-small-3" placeholder="Item/جنس" type="text">--%>
                                          <select id="ddlItems" class="select2-size-xs form-control"></select>
                                    </div>
                                </div>
                                <div class="form-group col-md-12 ">
                                    <label class="col-md-3 label-control " for="txtPosition">Quanity / غوښتل شوی مقدار</label>
                                    <div class="col-md-9">
                                        <input id="txtReqQunatity"  title="numbers" class="form-control input-sm  font-small-3 number" placeholder="Quanity / غوښتل شوی مقدار" type="text">
                                    </div>
                                </div>
                                <div class="form-group col-md-12 ">
                                    <label class="col-md-3 label-control" for="txtPosition">Unit /واحد</label>
                                    <div class="col-md-9">
                                        <select id="ddlUnit" class="form-control input-sm"></select>
                                    </div>
                                </div>
                                <div class="form-group col-md-12 ">
                                    <label class="col-md-3 label-control" for="txtPosition">Remarks / ملاحظات</label>
                                    <div class="col-md-9">
                                        <input id="txtRemarks" class="form-control input-sm font-small-3" placeholder="Remarks / ملاحظات" type="text">
                                    </div>
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
</asp:Content>

