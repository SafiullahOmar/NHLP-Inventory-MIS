<%@ Page Title="HCMIS:Role Managment" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RoleManager.aspx.cs" Inherits="Admin_RoleManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
    USER ROLE MANAGMENT
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
    The given data list provide us various system role facility on the users such as users role creation , users role assigning on the basis of thier (location,rights) , users account locking and users password resetting.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">

    <script>
        $(function () {
            var tabName = $("#<%=TabName.ClientID%>").val() != "" ? $("#<%=TabName.ClientID%>").val() : "NewRole";
            $('#tabs a[href="#' + tabName + '"]').tab('show');
            $("#tabs a[data-toggle='tab']").click(function (e) {

                $("#<%=TabName.ClientID%>").val($(this).attr('href').replace('#', ''));

            });
        });
            $(function () {
                $('input[id*="chkAll"]').on('ifChecked', function () {
                    $('#<%=grdSubProgram.ClientID%> input[id*="chksubPro"]').iCheck('check');
                });
                $('input[id*="chkAll"]').on('ifUnchecked', function () {
                    $('#<%=grdSubProgram.ClientID%> input[id*="chksubPro"]').iCheck('uncheck');
                });
            });

    </script>




    <div class="container-fluid container-fullw bg-white">
        <div class="row">
            <div class="col-md-12">
                <div id="tabs" class="mt-3">
                    <ul class="nav nav-tabs nav-top-border no-hover-bg">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" aria-controls="tab11" href="#NewRole" aria-expanded="true">Create Role</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" aria-controls="tab12" href="#AsignRole" aria-expanded="false">Assign Role</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" aria-controls="tab13" href="#PassReset" aria-expanded="false">Manage User</a>
                        </li>
                    </ul>
                </div>
                <div class="tab-content px-1 pt-1" style="padding-top: 20px">
                    <div role="tabpanel" class="tab-pane active" id="NewRole">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="input-group">
                                    <span class="input-group-addon">Role</span>
                                    <asp:textbox id="txtRoleName" validationgroup="insertrole" cssclass="form-control" runat="server"></asp:textbox>
                                </div>
                                <asp:requiredfieldvalidator validationgroup="insertrole" id="RequiredFieldValidator1" controltovalidate="txtRoleName" runat="server" errormessage="Enter Role Name">*</asp:requiredfieldvalidator>
                            </div>
                            <div class="col-md-3">
                                <asp:button id="BtnAddRole" validationgroup="insertrole" cssclass="btn btn-primary" onclick="BtnAddRole_Click" runat="server" text="Save" />
                            </div>
                        </div>

                        <div style="width: 98%; margin: 0 auto;">
                            <asp:gridview id="GrdRoles" cssclass="table table-bordered"
                                runat="server" autogeneratecolumns="False" enablemodelvalidation="True"
                                gridlines="None" width="98%" onrowdatabound="GrdRoles_RowDataBound" headerstyle-backcolor="White">
                                <Columns>
                                    <asp:BoundField DataField="RoleID" HeaderText="Role ID" />
                                    <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <li style="width: 17px; height: 16px; padding: 3px; list-style-type: none;">
                                                <asp:LinkButton ID="lnkDelete" runat="server" OnCommand="imgDelete_Command"
                                                    CommandArgument='<%# Eval("RoleID") %>' OnClientClick="javascript:return confirm('do you want to delete this role');"><i class="icon-trash-b"></i></asp:LinkButton>
                                                <%-- <asp:ImageButton CausesValidation="false" AlternateText='<%#Eval("RoleID") %>' CommandArgument='<%# Eval("RoleID") %>' OnClientClick="javascript:return deleteItem(this.name,this.alt,'Do you want to Delete this Record!');"
                                            CssClass="ui-icon ui-icon-closethick" ID="imgDelete" runat="server" OnCommand="imgDelete_Command" />--%>
                                            </li>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:gridview>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="AsignRole">
                        <asp:panel runat="server" id="pnlUsers">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <span class="input-group-addon">User Name</span>
                                        <asp:TextBox ID="txtSearchuserName" ValidationGroup="assignroles" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ControlToValidate="txtSearchuserName" ValidationGroup="assignroles" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnSearchUser" ValidationGroup="assignroles" runat="server" CssClass="btn btn-sm btn-primary"
                                        Text="Search User" OnClick="btnSearchUser_Click" />
                                </div>
                            </div>

                            <div style="width: 98%; margin: 0 auto; margin-top: 20px;">
                                <asp:GridView ID="grdUser" CssClass="table table-bordered" AutoGenerateColumns="False" runat="server" EnableModelValidation="True"
                                    OnSelectedIndexChanging="grdUser_SelectedIndexChanging" Width="100%"
                                    AllowPaging="True" OnPageIndexChanging="grdUser_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <%-- <asp:BoundField DataField="ApplicationName" HeaderText="Application" />--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkAssingRoles"
                                                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only "
                                                    CausesValidation="False" CommandArgument='<%# Eval("UserID") %>' runat="server"
                                                    OnCommand="lnkAssingRoles_Command"><span class="label label-info "><i class="glyphicon glyphicon-cog"></i>Assign Role</span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </asp:panel>

                        <asp:panel runat="server" visible="false" horizontalalign="Center" id="pnlroles">
                            <div class="alert alert-success">
                                <i class="glyphicon glyphicon-info-sign"></i>&nbsp;&nbsp;
                        <asp:Label ID="lblUserInfo" runat="server" Text="" CssClass="ui-button-text"></asp:Label>
                            </div>
                            <div style="width: 98%; margin: 0 auto;">
                                <asp:GridView ID="GrdUserRoles" CssClass="table table-bordered" AutoGenerateColumns="False" runat="server"
                                    EnableModelValidation="True" Width="100%"
                                    OnRowDataBound="GrdUserRoles_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Role ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleID" runat="server" Text='<%# Bind("RoleID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAssign" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />

                            <div class="alert alert-success">
                                <i class="glyphicon glyphicon-info-sign"></i>&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Assigning Provinces and Sub Departments" CssClass="ui-button-text"></asp:Label>
                            </div>
                            <div style="height: 300px; overflow-y: scroll; float:left;">


                                <asp:GridView Width="40%" CssClass="table table-bordered"
                                    AutoGenerateColumns="False" ID="gridSubDepartments" runat="server"
                                    EnableModelValidation="True" AllowPaging="false"
                                    OnRowDataBound="gridSubDepartments_RowDataBound" HeaderStyle-HorizontalAlign="Center">

                                    <Columns>
                                        <asp:TemplateField HeaderText="SR">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubComponentID" runat="server" Text='<%#Bind("SubDepartmentID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SubDepartment" HeaderText="Sub Components" />

                                        <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkAll" runat="server" Text="All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <asp:CheckBox ID="chkSubComponent" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>


                            </div>
                            <div style="height: 300px; overflow-y: scroll; float:right;">


                                <asp:GridView Width="40%" CssClass="table table-bordered"
                                    AutoGenerateColumns="False" ID="grdSubProgram" runat="server"
                                    EnableModelValidation="True" AllowPaging="false"
                                    OnRowDataBound="grdSubProgram_RowDataBound" HeaderStyle-HorizontalAlign="Center">

                                    <Columns>
                                        <asp:TemplateField HeaderText="SR">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubProgramID" runat="server" Text='<%#Bind("ProvinceID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ProvinceEngName" HeaderText="Province" />

                                        <asp:TemplateField HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" Text="All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <asp:CheckBox ID="chksubPro" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>


                            </div>
                            <hr />
                            <asp:Button ID="AssignRoles" runat="server" Text="Assign Role" CssClass="btn btn-sm btn-primary" OnClick="AssignRoles_Click" />
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-sm btn-primary" Text="back" OnClick="btnBack_Click" />
                        </asp:panel>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="PassReset">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="input-group">
                                    <span class="input-group-addon">User Name</span>
                                    <asp:textbox validationgroup="ManageUsers" cssclass="form-control" id="txtSearchManageUser" runat="server"></asp:textbox>
                                </div>
                                <asp:requiredfieldvalidator validationgroup="ManageUsers" controltovalidate="txtSearchManageUser" id="RequiredFieldValidator3" runat="server" errormessage="RequiredFieldValidator">*</asp:requiredfieldvalidator>
                            </div>
                            <div class="col-md-3">
                                <asp:button id="btnSearchManageUser" validationgroup="ManageUsers" cssclass="btn btn-sm btn-primary"
                                    runat="server" text="Search" onclick="btnSearchManageUser_Click" />
                            </div>
                        </div>

                        <div style="width: 98%">
                            <asp:gridview id="grdManageUsers" cssclass="table table-bordered" runat="server" autogeneratecolumns="False"
                                enablemodelvalidation="True" width="100%" allowpaging="True"
                                onpageindexchanging="grdManageUsers_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="User Id">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserId") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <%--  <asp:BoundField DataField="ApplicationName" HeaderText="Application Name" />--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLock" CausesValidation="false"
                                                CssClass="label label-danger" Style="padding: 0.4em 1em; line-height: 1.4;"
                                                runat="server" CommandArgument='<%#Eval("UserId") %>' OnClientClick="return confirm('Do You Want to perform this Action')" Text='<%#Eval("IsLockedOut").ToString()=="False"?"Lock":" Unlock"%>' OnCommand="lnkLock_Command">
                                       
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkResetPassword" CausesValidation="false" OnClientClick="return confirm('Do you want to Reset Password To (abc)')" CommandArgument='<%#Eval("UserId") %>'
                                                CssClass="label label-warning"
                                                runat="server" OnCommand="lnkResetPassword_Command"><span class="ui-button-text">Reset Password</span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:gridview>
                            <%-- <span class="ui-button-text">"+--%>
                            <%--"--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:hiddenfield id="TabName" runat="server" />
    <asp:hiddenfield id="hdUserID" value="0" runat="server" />
</asp:Content>

