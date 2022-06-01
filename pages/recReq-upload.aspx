<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="recReq-upload.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    ITEMS RECIEVE VOUCHER UPLOADS
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to UPLOAD  the list of the recieve items that have checked and signed . 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">

    <script src="../Script/recReq-upload.js"></script>
    <section id="horizontal-form-layouts">

        <div class="row ">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title" id="horz-layout-card-center">Voucher Forms Filter</h4>
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
                                        <div class="form-group col-md-12">
                                            <p><code>Select the required detials for the requested Voucher .</code></p>
                                            <label class="col-md-2 label-control" for="ddProvince">Office Location</label>
                                            <div class="col-md-10">

                                                <asp:DropDownList ID="ddlProvince" CssClass="form-control province" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group col-md-12">
                                            <label class="col-md-2 label-control" for="ddlDepartment">Department</label>
                                            <div class="col-md-10">

                                                <select id="ddlDepartment" class="form-control"></select>
                                            </div>
                                        </div>
                                        <div class="form-group col-md-12">
                                            <label class="col-md-2 label-control" for="ddlSr">R.Voucher Serial Number</label>
                                            <div class="col-md-10">

                                                <select id="ddlSr" class="form-control"></select>
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
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="icon-data" id="horz-layout-basic">Upload File for the Voucher Detail</h4>
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
                            <div class="card-text"></div>
                            <div id="dvTblVouchers">
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
                                            <th>Scan File</th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=" col-md-12">
                <div class="card">
                    <div class="card-block">
                        <div class=" card-body  col-md-7 label-control">
                            <hr />
                            <p><b>*** :: Please Upload Signed Recieved Voucher <code>(Required)</code></b></p>
                        </div>
                        <div class="col-md-5">
                            <hr />
                            <input type="file" id="FileUpload1"  multiple />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                 <button type="button" id="btnSave" class="btn btn-primary">
                                        <i class="icon-check2"></i>Save
	                           
                                    </button>
            </div>
            
        </div>
    </section>

</asp:Content>

