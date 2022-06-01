<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<html lang="en" data-textdirection="LTR" class="loading">


<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <title>NHLP:INV-MIS Login Page </title>
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-touch-fullscreen" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <!-- BEGIN VENDOR CSS-->
    <link rel="stylesheet" href="APPContent/css/vendors.min.css" />
    <!-- BEGIN VENDOR CSS-->
    <!-- BEGIN Font icons-->
    <link rel="stylesheet" type="text/css" href="APPContent/fonts/icomoon.css">
    <link rel="stylesheet" type="text/css" href="APPContent/fonts/flag-icon-css/css/flag-icon.min.css">
    <!-- END Font icons-->
    <!-- BEGIN Plugins CSS-->
    <link rel="stylesheet" type="text/css" href="APPContent/css/plugins/sliders/slick/slick.css">
    <!-- END Plugins CSS-->

    <!-- BEGIN Vendor CSS-->
    <link rel="stylesheet" type="text/css" href="APPContent/css/plugins/forms/icheck/icheck.css">
    <link rel="stylesheet" type="text/css" href="APPContent/css/plugins/forms/icheck/custom.css">
    <!-- END Vendor CSS-->
    <!-- BEGIN ROBUST CSS-->
    <link rel="stylesheet" href="APPContent/css/app.min.css" />
    <!-- END ROBUST CSS-->
</head>
<body data-open="click" data-menu="vertical-compact-menu" data-col="1-column" class="vertical-layout vertical-compact-menu 1-column  blank-page blank-page">
    <form runat="server">
        <!-- START PRELOADER-->

        <div id="preloader-wrapper">
            <div id="loader">
                <div class="chasing-dots loader-black">
                    <div class="child dot1"></div>
                    <div class="child dot2"></div>
                </div>
            </div>
            <div class="loader-section section-top bg-amber"></div>
            <div class="loader-section section-bottom bg-amber"></div>
        </div>

        <!-- END PRELOADER-->
        <!-- ////////////////////////////////////////////////////////////////////////////-->
        <div class="robust-content content container-fluid">
            <div class="content-wrapper">
                <div class="content-header row">
                </div>
                <div class="content-body">
                    <section class="flexbox-container">
                        <div class="col-md-4 offset-md-4 col-xs-10 offset-xs-1  box-shadow-2 p-0">
                            <div class="card border-grey border-lighten-3 m-0">
                                <div class="card-header no-border">
                                    <div class="card-title text-xs-center">
                                        <div class="p-1">
                                            <img alt="NHLP INVENTORY MIS">
                                        </div>
                                    </div>
                                    <h6 class="card-subtitle line-on-side text-muted text-xs-center font-small-3 pt-2"><span>Login with INV_MIS Credentials</span></h6>
                                </div>
                                <div class="card-body collapse in">
                                    <div class="card-block">
                                        <asp:Login ID="Login1" FailureTextStyle-ForeColor="Red" runat="server" Width="100%">
                                            <LayoutTemplate>

                                                <asp:Label ID="FailureText" runat="server" Font-Size="13.5px" CssClass="label label-danger" EnableViewState="false"></asp:Label>


                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"></asp:Label>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ToolTip="User Name is required." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                <fieldset class="form-group has-feedback has-icon-left mb-0">
                                                    <asp:TextBox ID="UserName" placeholder="Your Name" class="form-control form-control-lg input-lg" runat="server"></asp:TextBox>
                                                    <div class="form-control-position">
                                                        <i class="icon-head"></i>
                                                    </div>
                                                </fieldset>

                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"></asp:Label>
                                                <asp:RequiredFieldValidator Display="Static" ID="PasswordRequired" runat="server" ControlToValidate="Password" ToolTip="Password is required." ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                <fieldset class="form-group has-feedback has-icon-left">
                                                    <asp:TextBox ID="Password" placeholder="Enter Password" class="form-control form-control-lg input-lg" runat="server" TextMode="Password"></asp:TextBox>
                                                    <div class="form-control-position">
                                                        <i class="icon-key3"></i>
                                                    </div>
                                                </fieldset>


                                                <fieldset class="form-group row">
                                                    <div class="col-md-6 col-xs-12 text-xs-center text-md-left">
                                                        <fieldset>
                                                            <input type="checkbox" id="remember" class="chk-remember" value="1">
                                                            <label for="remember">
                                                                Keep me signed in
                                                            </label>
                                                        </fieldset>
                                                    </div>

                                                </fieldset>

                                                <asp:LinkButton ID="LoginButton" ValidationGroup="Login1" class="btn btn-primary btn-lg btn-block" CommandName="Login" runat="server"> Login <i class="icon-unlock2"></i> </asp:LinkButton>

                                            </LayoutTemplate>
                                        </asp:Login>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-4"><a href="RF/ReqIn.aspx"><i class="icon-paper"></i><span data-i18n="nav.dash.main" class="menu-title m-1">Tools(FC) Request</span></a></div>
                                            <div class="col-md-4"><a href="RF/ReqS.aspx"><i class="icon-wpforms"></i><span data-i18n="nav.dash.main" class="menu-title m-1">Store Request</span></a></div>
                                            <div class="col-md-4"><a href="RF/Req.aspx"><i class="icon-newspaper-o"></i><span data-i18n="nav.dash.main" class="menu-title m-1">Office Used Items Request</span></a></div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </section>

                </div>
            </div>
        </div>
        <!-- ////////////////////////////////////////////////////////////////////////////-->

        <!-- BEGIN VENDOR JS-->
        <script src="APPContent/js/vendors.min.js"></script>
        <!-- BEGIN VENDOR JS-->
        <!-- BEGIN PAGE VENDOR JS-->
        <script src="APPContent/js/plugins/forms/icheck/icheck.min.js" type="text/javascript"></script>
        <script src="APPContent/js/plugins/forms/validation/jqBootstrapValidation.js" type="text/javascript"></script>
        <!-- END PAGE VENDOR JS-->
        <!-- BEGIN ROBUST JS-->
        <script src="APPContent/js/app.min.js"></script>
        <!-- END ROBUST JS-->
    </form>
</body>


</html>
