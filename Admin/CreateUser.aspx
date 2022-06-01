<%@ Page Title="HCMIS:Create New User" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageTopic" runat="Server">
   USER CREATION
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTopicDetail" runat="Server">
   The below form is going to create new user for the system .
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageBody" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        function fnOnUpdateValidators() {
            for (var i = 0; i < Page_Validators.length; i++) {
                var val = Page_Validators[i];
                var ctrl = document.getElementById(val.controltovalidate);
                if (ctrl != null && ctrl.style != null) {
                    if (!val.isvalid)
                        ctrl.style.background = '#FFAAAA';
                    else
                        ctrl.style.backgroundColor = '';
                }
            }
        }
        $(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_CreateUserWizard1_CreateUserStepContainer_UserName").keyup(function (e) { OnChange(e); });
            $("#ctl00_ContentPlaceHolder1_CreateUserWizard1_CreateUserStepContainer_Email").keyup(function (e) { $("#emessage")[0].innerHTML = ""; });
            $("#ctl00_ContentPlaceHolder1_CreateUserWizard1_CreateUserStepContainer_btnCheckAvail").click(function (e) { ShowAvailability(); e.preventDefault(); });

            $("#ctl00_ContentPlaceHolder1_CreateUserWizard1_CreateUserStepContainer_btnCheckAvailability").click(function (e) {
                e.preventDefault();
                $.ajax({

                    type: "POST",

                    url: "CreateUser.aspx/CheckEmailAvailability",
                    data: '{"email":"' + $("#ctl00_ContentPlaceHolder1_CreateUserWizard1_CreateUserStepContainer_Email").val() + '" }',

                    contentType: "application/json; charset=utf-8",

                    dataType: "json",

                    success: function (response) {

                        var mesg = $("#emessage")[0];



                        switch (response.d) {

                            case "true":

                                mesg.style.color = "red";

                                mesg.innerHTML = "Not Available";

                                break;

                            case "false":

                                mesg.style.color = "green";

                                mesg.innerHTML = "Available";

                                break;

                            case "error":

                                mesg.style.color = "red";

                                mesg.innerHTML = "Error occured";

                                break;

                        }
                    },

                    failure: function (response) {

                        alert(response);

                    }

                });
            });

        });


        function ShowAvailability() {

            $.ajax({

                type: "POST",

                url: "CreateUser.aspx/CheckAvailability",
                data: '{"userName":"' + $("#ctl00_ContentPlaceHolder1_CreateUserWizard1_CreateUserStepContainer_UserName").val() + '" }',

                contentType: "application/json; charset=utf-8",

                dataType: "json",

                success: OnSuccess,

                failure: function (response) {

                    alert(response);

                }

            });

        }

        function OnSuccess(response) {

            var mesg = $("#mesg")[0];



            switch (response.d) {

                case "true":

                    mesg.style.color = "red";

                    mesg.innerHTML = "Not Available";

                    break;

                case "false":

                    mesg.style.color = "green";

                    mesg.innerHTML = "Available";

                    break;

                case "error":

                    mesg.style.color = "red";

                    mesg.innerHTML = "Error occured";

                    break;

            }

        }

        function OnChange(txt) {

            $("#mesg")[0].innerHTML = "";

        }

    </script>




    <div class="container-fluid container-fullw bg-white">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <asp:CreateUserWizard ID="CreateUserWizard1" Width="700px" LoginCreatedUser="false" runat="server"
                    OnCreatedUser="CreateUserWizard1_CreatedUser"
                    CompleteSuccessText="Account has been successfully created."
                    CreateUserButtonText="Create User" CreateUserButtonStyle-CssClass="btn btn-success">
<CreateUserButtonStyle CssClass="btn btn-success"></CreateUserButtonStyle>
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                            <ContentTemplate>
                                
                                        <div class="row">
                                            <div class="col-md-12 mt-3"><p><b> User Information</b></p></div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFullName"
                                                        Text="Full Name"></asp:Label>
                                                    <asp:TextBox ID="txtFullName" SkinID="large" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="txtFullName" Display="Static" ValidationGroup="CreateUserWizard1" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div>
                                                        <asp:Label ID="lblAge" runat="server" AssociatedControlID="txtAge" Text="Age"></asp:Label>
                                                    </div>
                                                    <asp:TextBox ID="txtAge" SkinID="large" runat="server"></asp:TextBox>

                                                </div>

                                            </div>
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <asp:Label ID="Label4" AssociatedControlID="txtDesignation" runat="server" Text="Designation"></asp:Label>
                                                    <asp:TextBox ID="txtDesignation" SkinID="large" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:Label ID="lblDepartment" runat="server" AssociatedControlID="ddlDepartment" Text="Department"></asp:Label>
                                                    <asp:DropDownList SkinID="large" ID="ddlDepartment" runat="server" >
                                                    </asp:DropDownList>

                                                    <asp:CompareValidator Display="Static" ID="CompareValidator1" runat="server"
                                                        ControlToValidate="ddlDepartment" ErrorMessage="CompareValidator"
                                                        Operator="NotEqual" ValueToCompare="-1" ValidationGroup="CreateUserWizard1">*</asp:CompareValidator>
                                                </div>
                                            </div>
                                           
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="ddlLocation" Text="Work Station"></asp:Label>
                                                    <asp:DropDownList SkinID="large" ID="ddlLocation" runat="server">
                                                    </asp:DropDownList>

                                                    <asp:CompareValidator Display="Static" ID="CompareValidator2" runat="server"
                                                        ControlToValidate="ddlLocation" ErrorMessage="CompareValidator"
                                                        Operator="NotEqual" ValueToCompare="-1" ValidationGroup="CreateUserWizard1">*</asp:CompareValidator>
                                                </div>
                                            </div>


                                        </div>
                                 

                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <i class="glyphicon glyphicon-user"></i>
                                        <strong>Login Information to System</strong>
                                    </div>
                                    <div class="panel-body">

                                        <div class="col-md-12">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <asp:Label ID="UserNameLabel" runat="server" ForeColor="White" AssociatedControlID="UserName">User Name</asp:Label>
                                                </div>
                                                <asp:TextBox ID="UserName" SkinID="large" runat="server"></asp:TextBox>
                                                <div class="input-group-addon">
                                                    <%-- <asp:Button ID="btnCheckAvail" runat="server" Text="برسی موجودیت" />--%>

                                                    <asp:LinkButton ID="btnCheckAvail" CssClass="label label-success" runat="server"> Existance Checkup </asp:LinkButton>
                                                </div>
                                                <div class="input-group-addon">

                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                        ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                        ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </div>

                                                <div class="input-group-addon">
                                                    <span id="mesg"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="col-md-12">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <asp:Label ID="EmailLabel" ForeColor="White" runat="server" AssociatedControlID="Email">Email</asp:Label>
                                                </div>
                                                <asp:TextBox ID="Email" SkinID="large" runat="server"></asp:TextBox>
                                                <div class="input-group-addon">
                                                    <asp:LinkButton CssClass="label label-success" ID="btnCheckAvailability" runat="server">Existance Checkup</asp:LinkButton>
                                                </div>
                                                <div class="input-group-addon">
                                                    <asp:RequiredFieldValidator Display="None" ID="EmailRequired" runat="server"
                                                        ControlToValidate="Email" ErrorMessage="E-mail is required."
                                                        ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="input-group-addon">
                                                    <asp:RegularExpressionValidator ControlToValidate="Email"
                                                        ID="RegularExpressionValidator1" Display="Static" runat="server"
                                                        ErrorMessage="RegularExpressionValidator" ValidationGroup="CreateUserWizard1"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                </div>
                                                <%--<asp:Button ID="btnCheckAvailability" runat="server" 
                                                Text="برسی موجودیت" />--%>
                                                <div class="input-group-addon">
                                                    <span id="emessage"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <asp:Label ID="PasswordLabel" ForeColor="White" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                                    </div>

                                                    <asp:TextBox ID="Password" SkinID="large" runat="server" TextMode="Password"></asp:TextBox>
                                                    <div class="input-group-addon">
                                                        <asp:RequiredFieldValidator Display="Static" ID="PasswordRequired" runat="server"
                                                            ControlToValidate="Password" ErrorMessage="Password is required."
                                                            ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        <asp:Label ID="ConfirmPasswordLabel" ForeColor="White" runat="server"
                                                            AssociatedControlID="ConfirmPassword">Confirm Password</asp:Label>
                                                    </div>

                                                    <asp:TextBox SkinID="large" ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                    <div class="input-group-addon">
                                                        <asp:RequiredFieldValidator Display="Static" ID="ConfirmPasswordRequired" runat="server"
                                                            ControlToValidate="ConfirmPassword"
                                                            ErrorMessage="Confirm Password is required."
                                                            ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:CompareValidator ID="PasswordCompare" runat="server"
                                                ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                                Display="Dynamic"
                                                ErrorMessage="The Password and Confirmation Password must match."
                                                ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                        </div>

                                    </div>
                                </div>

                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <i class="glyphicon glyphicon-lock"></i>
                                        <strong>Security Information</strong>
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <asp:Label ID="QuestionLabel" ForeColor="White" runat="server" AssociatedControlID="Question">Security Question </asp:Label>
                                                </div>
                                                <asp:TextBox ID="Question" SkinID="large" runat="server"></asp:TextBox>
                                                <div class="input-group-addon">
                                                    <asp:RequiredFieldValidator Display="Static" ID="QuestionRequired" runat="server"
                                                        ControlToValidate="Question" ErrorMessage="Security question is required."
                                                        ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <div class="input-group">
                                                <div class="input-group-addon">
                                                    <asp:Label ID="AnswerLabel" ForeColor="White" runat="server" AssociatedControlID="Answer">Security Answer</asp:Label>
                                                </div>
                                                <asp:TextBox ID="Answer" SkinID="large" runat="server"></asp:TextBox>
                                                <div class="input-group-addon">
                                                    <asp:RequiredFieldValidator Display="Static" ID="AnswerRequired" runat="server"
                                                        ControlToValidate="Answer" ErrorMessage="Security answer is required."
                                                        ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </div>
                            </ContentTemplate>
                            
                        </asp:CreateUserWizardStep>
                        <asp:TemplatedWizardStep ID="TemplatedWizardStep1" runat="server">
                        </asp:TemplatedWizardStep>
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                            <ContentTemplate>
                                <div class="panel panel-success">
                                    <div class="panel-heading">Successfully </div>
                                    <div class="panel-body">
                                        <p class="alert alert-success">Account has been created</p>

                                        <asp:Button ID="ContinueButton" CssClass="btn btn-success" PostBackUrl="~/DashBoard.aspx" runat="server" CausesValidation="False"
                                            CommandName="Continue" Text="Continue" ValidationGroup="CreateUserWizard1" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                    <StepNavigationTemplate>
                        <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False"
                            CommandName="MovePrevious" Text="Previous" />
                        <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext"
                            Text="Next" />
                    </StepNavigationTemplate>
                </asp:CreateUserWizard>
            </div>
            <div class="col-md-1"></div>
        </div>
    </div>

</asp:Content>

