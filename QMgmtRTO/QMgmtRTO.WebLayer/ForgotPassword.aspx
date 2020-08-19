<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="QMgmtRTO.WebLayer.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>RTO: Reset Password</title>
    <link rel="icon" type="image/ico" href="assets/images/favicon.png" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- ============================================
        ================= Stylesheets ===================
        ============================================= -->
    <!-- vendor css files -->
    <link rel="stylesheet" href="assets/css/vendor/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/vendor/animate.css" />
    <link rel="stylesheet" href="assets/css/vendor/font-awesome.min.css" />
    <link rel="stylesheet" href="assets/js/vendor/animsition/css/animsition.min.css" />
    <!-- project main css files -->
    <link rel="stylesheet" href="assets/css/main.css" />
    <!--/ stylesheets -->
    <!-- ==========================================
        ================= Modernizr ===================
        =========================================== -->
    <!--/ modernizr -->
    <script lang="javascript" type="text/javascript">
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () {
            null
        };
    </script>
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
</head>
<body id="minovate" class="appWrapper" style="margin: 0px; background-color: #f2f8f9;">
    <div class="container">
        <div class="row">
            <div class="row">
                <h1 style="text-align: center">Regional Transport Office</h1>
                <div class="col-md-4 col-md-offset-4" style="margin-top: 5%">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="text-center">
                                <h3><i class="fa fa-lock fa-4x"></i></h3>
                                <h2 class="text-center">Forgot Password?</h2>
                                <p>
                                    Please enter your registered email address.
                                You will receive a Reset Password url in your mail box.
                                </p>
                                <div class="panel-body">
                                    <form class="form">
                                        <fieldset>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                                                    <input id="txtemail" placeholder="Enter email address" onkeypress="return IsSpace(event)" class="form-control" type="email" maxlength="30" />
                                                </div>
                                                <label id="errormsg" style="color: red"></label>
                                            </div>
                                            <div class="form-group">
                                                <input class="btn btn-lg btn-primary btn-block" value="Send recovery email" type="button" id="btnRestPsw" />
                                            </div>
                                            <br />
                                            <div class="form-group">
                                                <input class="btn btn-lg btn-success btn-block" onclick='window.location.href = "Logininfo.aspx";' value="Back To Login" type="button" id="btnlogin" />
                                            </div>
                                        </fieldset>
                                    </form>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
        $('#txtemail').hover(function () {
            $('#errormsg').text('');
        });
        $('#btnRestPsw').click(function () {
            //debugger;
            if ($('#txtemail').val() == "") {
                //alert("Email Address Can't Be Blank")
                $('#errormsg').text("Email Address Can't Be Blank")
                $('#txtemail').focus();
                return false;
            }

            var emailid = $("#txtemail").val();
            $.ajax({
                type: "POST",
                url: "ForgetPassword.aspx/Passwordsend",
                data: '{emailid: ' + JSON.stringify(emailid) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var jsodatan = JSON.parse(response.d);
                    if (jsodatan == "success") {
                        alert('Please check your inbox, we have sent you reset password url');
                        window.location = "ForgetPassword.aspx";
                    } else if (jsodatan == "Usuccess") {
                        $('#txtemail').val('');
                        $('#errormsg').text("Your email does not exist. Please enter a valid email.");
                        window.location = "ForgetPassword.aspx";
                    }
                }
            });
        });
    </script>
</body>
</html>
