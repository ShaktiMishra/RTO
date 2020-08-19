<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginInfo.aspx.cs" Inherits="QMgmtRTO.WebLayer.LoginInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Login</title>
    <link rel="shortcut icon" type="image/x-icon" href="assets/images/favicon.png" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Rubik:300,400,500,700" rel="stylesheet" />
    <link href="assets/css/bootstrap4-admin-compress.min.css" rel="stylesheet" />
    <script type="text/javascript">
        //Not Allowed To Spaces --Code By Pravanjan Nayak
        function IsSpace(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode == 32) {
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        // Allowed only one Number --Code By Pravanjan Nayak
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }

            return true;
        }
    </script>
    <style>
        .handcursor {
            cursor: pointer;
        }
        
        .login-container #Image1 {
	box-shadow: 0px 2px 9px #DDD;
	background: #FFF;
	border-radius: 50%;
	padding: 0px 20px 20px 20px;
}
    </style>
    <script type="text/javascript">
        function CallConfirmBox() {
            if (confirm("You have active session some where.Do you Want to Logout from Other Active Session?")) {
                alert("You pressed OK!");
                document.getElementById('<%=HiddenField1.ClientID%>').value('');
                document.getElementById('<%=HiddenField1.ClientID%>').value = "1"
            } else {
                alert("You pressed Cancel!");
                document.getElementById('<%=HiddenField1.ClientID%>').value('');
                 document.getElementById('<%=HiddenField1.ClientID%>').value = "2"
            }
        }
    </script>
</head>
<body class="body-custom mb-0">
    <form id="Form1" runat="server">
        <div class="user-onboarding">
            <div class="container">
                <div class="login-container row d-flex justify-content-between">
                    <div class="col-sm-6 align-self-md-center login-content">
                        <h1 class="newlogin-logo"><span>Regional Transport Office</span></h1>
                        <hr>
                        <%-- <h3 class="pmd-display5 text-white">The Bootstrap 4 Admin Theme by Propeller is a full featured premium HRMS Admin theme built using Propeller Pro framework.</h3>
                        <p class="lead">The theme suitable for building CMS, CRM, ERP, Admin Panel, or a web application.</p>--%>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/images/favicon.png" Style="width: 50%; margin-left: 17%;" />
                    </div>
                    <div class="col-sm-6 align-self-md-center">
                        <div class="new-logincard card pmd-card">
                            <div runat="server" id="dvlogin" class="login-card">
                                <div class="card-header">
                                    <h2 class="card-title">Welcome to <span>RTO</span></h2>
                                    <p class="card-subtitle"><strong>Regional Transport Office (RTO)</strong></p>
                                </div>
                                <div class="card-body">
                                    <div class="input-group pmd-input-group pmd-input-group-icon mb-3">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <i class="material-icons md-dark pmd-sm">perm_identity</i>
                                            </div>
                                        </div>
                                        <div class="pmd-textfield pmd-textfield-floating-label">
                                            <label for="exampleInputAmount"></label>
                                            <asp:TextBox ID="txtusername" name="login" placeholder="Email Address" runat="server" class="form-control" onkeypress="return IsSpace(event)" MaxLength="40" AutoComplete="off"></asp:TextBox>                        
                                            <label id="errormsglemail" style="color: red"></label>
                                        </div>
                                    </div>

                                    <div class="input-group pmd-input-group pmd-input-group-icon">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <i class="material-icons md-dark pmd-sm">lock_outline</i>
                                            </div>
                                        </div>
                                        <div class="pmd-textfield pmd-textfield-floating-label">
                                            <label for="exampleInputAmount1"></label>
                                            <asp:TextBox ID="txtpassword" placeholder="Password" name="pass" runat="server" TextMode="Password" class="form-control" MaxLength="30"></asp:TextBox>
                                            <label id="errormsgpsw" style="color: red"></label>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer text-center">
                                    <div class="form-group clearfix">
                                        <%--<div class="float-left">
                                            <div class="custom-control custom-checkbox pmd-checkbox">
                                                <input class="custom-control-input" type="checkbox" value="" id="inverse_defaultCheck1" checked="checked" />
                                                <label class="custom-control-label" for="inverse_defaultCheck1">
                                                    Remember Me
                                                </label>
                                            </div>
                                        </div>--%>
                                        <span class="float-right">
                                            <a class="forgotpassword text-primary handcursor">Forgot password?</a>
                                        </span>
                                    </div>
                                    <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" CssClass="btn pmd-ripple-effect btn-primary btn-block btn-lg pmd-btn-raised m-0" />
                                     <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
                                    <p class="mt-3 mb-0 mb-0 handcursor">Don't have an account? <a class="register text-primary">Sign Up</a>. </p>
                                </div>
                            </div>

                            <div runat="server" id="dvforget" class="forgetpsw-card">
                                <div class="card-header">
                                    <h2 class="card-title">Forgot password?</h2>
                                    <p class="card-subtitle">Submit your email address and we'll send you a link to reset your password.</p>
                                </div>
                                <div class="card-body">
                                    <div class="input-group pmd-input-group pmd-input-group-icon mb-3">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <i class="material-icons md-dark pmd-sm">email</i>
                                            </div>
                                        </div>
                                        <div class="pmd-textfield pmd-textfield-floating-label">
                                            <label for="exampleInputAmount"></label>
                                            <asp:TextBox ID="txtfemail" placeholder="Email address" TextMode="Email" onkeypress="return IsSpace(event)" runat="server" class="form-control" autocomplete="off" MaxLength="50"></asp:TextBox>
                                            <label id="errormsgfemail" style="color: red"></label>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer text-center">
                                    <asp:Button ID="btnforgetpsw" runat="server" Text="Submit" OnClick="btnforgetpsw_Click" CssClass="btn pmd-ripple-effect btn-primary btn-block btn-lg pmd-btn-raised m-0" />
                                    <p class="mt-3 mb-0 handcursor">Already registered? <a class="login text-primary">Sign In</a></p>
                                </div>
                            </div>

                            <div runat="server" id="dvsignup" class="signup-card">
                                <div class="card-header">
                                    <h2 class="card-title">New to <span>SuperAdmin?</span></h2>
                                    <p class="card-subtitle">Start your account now.</p>
                                </div>

                                <div class="card-body">
                                    <div class="input-group pmd-input-group pmd-input-group-icon mb-3">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <i class="material-icons md-dark pmd-sm">perm_identity</i>
                                            </div>
                                        </div>
                                        <div class="pmd-textfield pmd-textfield-floating-label">
                                            <label for="exampleInputAmount"></label>
                                            <asp:TextBox ID="txtname" placeholder="Name" runat="server" class="form-control" autocomplete="off" MaxLength="40"></asp:TextBox>
                                            <label id="errormsgname" style="color: red"></label>
                                        </div>
                                    </div>

                                    <div class="input-group pmd-input-group pmd-input-group-icon mb-3">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <i class="material-icons md-dark pmd-sm">email</i>
                                            </div>
                                        </div>
                                        <div class="pmd-textfield pmd-textfield-floating-label">
                                            <label for="exampleInputAmount"></label>
                                            <asp:TextBox ID="txtemail" placeholder="Email address" TextMode="Email" onkeypress="return IsSpace(event)" runat="server" class="form-control" autocomplete="off" MaxLength="50"></asp:TextBox>
                                            <label id="errormsgemail" style="color: red"></label>
                                        </div>
                                    </div>

                                    <div class="input-group pmd-input-group pmd-input-group-icon mb-3">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <i class="material-icons md-dark pmd-sm">call</i>
                                            </div>
                                        </div>
                                        <div class="pmd-textfield pmd-textfield-floating-label">
                                            <label for="exampleInputAmount1"></label>
                                            <asp:TextBox ID="txtmob" placeholder="Mobile No." runat="server" class="form-control" autocomplete="off" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            <label id="errormsgmob" style="color: red"></label>
                                        </div>
                                    </div>
                                    <div class="input-group pmd-input-group pmd-input-group-icon">
                                        <div class="input-group-prepend">
                                            <div class="input-group-text">
                                                <i class="material-icons md-dark pmd-sm">home</i>
                                            </div>
                                        </div>
                                        <div class="pmd-textfield pmd-textfield-floating-label">
                                            <label for="confirm-password"></label>
                                            <asp:TextBox ID="txtaddress" placeholder="Address" runat="server" class="form-control" autocomplete="off" MaxLength="200"></asp:TextBox>
                                            <label id="errormsgadrs" style="color: red"></label>
                                        </div>
                                    </div>
                                </div>

                                <div class="card-footer text-center">
                                    <asp:Button ID="btnsignup" runat="server" Text="Sign Up" OnClick="btnsignup_Click" CssClass="btn pmd-ripple-effect btn-primary btn-block btn-lg pmd-btn-raised m-0" />

                                    <p class="mt-3 mb-0 handcursor">Already have an account? <a class="login text-primary">Sign In</a>. </p>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="position-relative">
                    <footer class="pmd-footer login-footer text-white">
                        © <span class="auto-update-year"></span>A <a href="https://www.suyogcomputech.com/" target="_blank" class="text-white"><strong>Suyog Computech (P) Ltd </strong></a>
                    </footer>
                </div>
            </div>
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //$('.login-card').show()
            //$('.forgetpsw-card').hide();
            //$('.signup-card').hide();

            $(".forgotpassword").click(function () {
                $('.login-card').hide();
                $('.forgetpsw-card').show();
                $('.signup-card').hide();
                $('#txtfemail').focus();
                $('#errormsgfemail').hide();
                $('#txtfemail').val('');
            });

            $(".register").click(function () {
                $('.login-card').hide();
                $('.forgetpsw-card').hide();
                $('.signup-card').show();
                $('#txtname').focus();

                $('#errormsgname').hide();
                $('#errormsgemail').hide();
                $('#errormsgmob').hide();
                $('#errormsgadrs').hide();

                $('#txtname').val('');
                $('#txtemail').val('');
                $('#txtmob').val('');
                $('#txtaddress').val('');
                //$("#dvsignup").text('')
            });

            $(".login").click(function () {
                $('.signup-card').hide();
                $('.login-card').show();
                $('.forgetpsw-card').hide();
              
                $('#txtusername').focus();
                $('#errormsglemail').hide();
                $('#errormsgpsw').hide();
                $('#txtusername').val('');
                $('#txtpassword').val('');
            });
            $('#txtfemail').keyup(function () {
                $('#errormsgfemail').hide();
            });
            $('#txtusername').keyup(function () {
                $('#errormsglemail').hide();
            });
            $('#txtpassword').keyup(function () {
                $('#errormsgpsw').hide();
            });

            $('#txtname').keyup(function () {
                $('#errormsgname').hide();
            });
            $('#txtemail').keyup(function () {
                $('#errormsgemail').hide();
            });
            $('#txtmob').keyup(function () {
                $('#errormsgmob').hide();
            });
            $('#txtaddress').keyup(function () {
                $('#errormsgadrs').hide();
            });

        });

        $("#btnsignup").click(function () {
            if ($('#txtname').val() == "" && $('#txtemail').val() == "" && $('#txtmob').val() == "" && $('#txtaddress').val() == "") {

                $('#errormsgname').show();
                $('#errormsgemail').show();
                $('#errormsgmob').show();
                $('#errormsgadrs').show();

                $('#errormsgname').text("Enter Name");
                $('#errormsgemail').text("Enter Email Address");
                $('#errormsgmob').text("Enter Mobile Number");
                $('#errormsgadrs').text("Enter Address");
            }


            if ($('#txtname').val() == "") {
                $('#errormsgname').show();
                $('#errormsgname').text("Enter Name");
                $('#txtname').focus();
                return false;
            }

            if ($('#txtemail').val() == "") {
                $('#errormsgemail').show();
                $('#errormsgemail').text("Enter Email Address");
                $('#txtemail').focus();
                return false;
            }

            var email = $("#txtemail").val();
            if (IsEmail(email) == false) {
                $('#errormsgemail').show();
                $('#errormsgemail').text("Please enter valid email address");
                $("#txtemail").focus();
                $("#txtemail").val('');
                return false;
            }

            function IsEmail(email) {
                var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!regex.test(email)) {
                    return false;
                } else {
                    return true;
                }
            }
            if ($('#txtmob').val() == "") {
                $('#errormsgmob').show();
                $('#errormsgmob').text("Enter Mobile Number");
                $('#txtmob').focus();
                return false;
            }

            if (!$('#txtmob').val().match('[0-9]{10}')) {
                $('#errormsgmob').show();
                $('#errormsgmob').text("Please Enter Valid Mobile Number (10 digits)");
                $("#txtmob").focus();
                return false;
            }
            if ($('#txtaddress').val() == "") {
                $('#errormsgadrs').show();
                $('#errormsgadrs').text("Enter Address");
                $('#txtaddress').focus();
                return false;
            }

        });

        $("#btnlogin").click(function () {

            if ($('#txtusername').val() == "" && $('#txtpassword').val() == "") {
                $('#errormsglemail').show();
                $('#errormsgpsw').show();
                $('#errormsglemail').text("Enter Email Address");
                $('#errormsgpsw').text("Enter Password");

            }
            if ($('#txtusername').val() == "") {
                $('#errormsglemail').show();
                $('#errormsglemail').text("Enter Email Address");
                $('#txtusername').focus();
                return false;
            }

            var email = $("#txtusername").val();
            if (IsEmail(email) == false) {
                $('#errormsglemail').show();
                $('#errormsglemail').text('Please enter valid email address');
                $("#txtusername").focus();
                $("#txtusername").val('');
                return false;
            }

            function IsEmail(email) {
                var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!regex.test(email)) {
                    return false;
                } else {
                    return true;
                }
            }
            if ($('#txtpassword').val() == "") {
                $('#errormsgpsw').show();
                $('#errormsgpsw').text("Enter Password");
                $('#txtpassword').focus();
                return false;
            }
        });

        $('#txtemail').hover(function () {
            $('#errormsg').text('');
        });

        $('#btnforgetpsw').click(function () {
            //debugger;
            if ($('#txtfemail').val() == "") {
                $('#errormsgfemail').show();
                $('#errormsgfemail').text("Enter Email Address")
                $('#txtfemail').focus();
                return false;
            }

            var email = $("#txtfemail").val();
            if (IsEmail(email) == false) {
                $('#errormsgfemail').show();
                $('#errormsgfemail').text('Please enter valid email address');
                $("#txtfemail").focus();
                $("#txtfemail").val('');
                return false;
            }

            function IsEmail(email) {
                var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!regex.test(email)) {
                    return false;
                } else {
                    return true;
                }
            }
        });
    </script>
    <!-- Scripts Ends -->

</body>
</html>
