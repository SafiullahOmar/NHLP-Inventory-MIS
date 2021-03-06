<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="item_d.aspx.cs" Inherits="pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    ITEMS DESCRIPTION
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The below form is going to save Items details and the second data list gives the facility to manipulate the list items according to user right
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">

    <script src="../Script/Product_Items.js"></script>
    <section id="horizontal-form-layouts">

        <div class="row">
            <div class="col-md-12">
                <div class="card">                    
                    <div class="card-header">
                        <h4 class="card-title" id="horz-layout-card-center">Items Detail</h4>
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
                                Please fill the below <code>form</code> according to requirements. 
                            </div>
                            <hr />
                            <div class="form form-horizontal">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label class="col-md-5 label-control" for="txtName">Item Name </label>
                                            <div class="col-md-7">
                                                <input id="txtName" class="form-control" placeholder="Product/Item Name" type="text">
                                               
                                            </div>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label class="col-md-5 label-control" for="ddlClass">Class (General Category) </label>
                                            <div class="col-md-7">
                                                
                                                 <select id="ddlClass" class="form-control"></select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                  <div class="form-body">
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label class="col-md-5 label-control" for="ddlSubCategory">Sub Category</label>
                                            <div class="col-md-7">
                                                <select id="ddlSubCategory" class="form-control"></select>
                                            </div>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label class="col-md-5 label-control" for="ddlUnit"> Item Measurement Unit</label>
                                            <div class="col-md-7">
                                                <select id="ddlUnit" class="form-control"></select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label class="col-md-5 label-control" for="ddlAssetsType">Asset Type</label>
                                            <div class="col-md-7">
                                                <select id="ddlAssetsType" class="form-control">
                                                    <option value="-1">--Select--</option>
                                                    <option value="1">Fixed Asset</option>
                                                    <option value="2">Consumable Asset</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label class="col-md-5 label-control" for="ddlKeepingType">Items is kept in system ?</label>
                                            <div class="col-md-7">
                                                <select id="ddlKeepingType" class="form-control">
                                                    <option value="-1">--Select--</option>
                                                    <option value="1">Individual</option>
                                                    <option value="2">Commulative</option>
                                                </select>
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
                                     <button type="button" id="btnDelete" class="btn btn-info">
                                        <i class="icon-delete"></i>Delete
	                           
                                    </button>
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
                        <h4 class="icon-data" id="horz-layout-basic"> Items Informations</h4>
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
                                Find the required <code>item</code>from the list , According to your right you are able to edit the item detail into the system. 
                            </div>
                            <div id="dtTableDetail">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <input type="hidden" id="hdnItemID" />
</asp:Content>

