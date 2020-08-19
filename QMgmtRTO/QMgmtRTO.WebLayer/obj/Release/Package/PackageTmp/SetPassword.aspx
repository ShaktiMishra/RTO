<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setpassword.aspx.cs" Inherits="QMgmtRTO.WebLayer.Setpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <title>RTO: Set Password</title>
    <link rel="icon" type="image/ico" href="assets/images/favicon.png" />
    <style type="text/css">
        a:hover {
            text-decoration: underline !important;
        }
    </style>
    <link rel="stylesheet" href="assets/css/vendor/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/vendor/font-awesome.min.css" />
    <script language="javascript" type="text/javascript">
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () {
            null
        };
    </script>
</head>
<body marginheight="0" topmargin="0" marginwidth="0" style="margin: 0px; background-color: #f2f8f9;" leftmargin="0">
    <!--100% body table-->
    <form id="fm1" runat="server">
    <table cellspacing="0" border="0" cellpadding="0" width="100%" bgcolor="#f2f8f9" runat="server" style="@import url(https: //fonts.googleapis.com/css?family=Roboto:400,500,300); font-family: 'Roboto', sans-serif , Arial, Helvetica, sans-serif;">
        <tbody>
            <tr>
                <td>
                    <table style="background-color: #f2f8f9; max-width: 670px; margin: 0 auto;" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td style="height: 80px;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <h1>Regional Transport Office</h1>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="display: none" id="Dvpthanku">
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="max-width: 670px; background: #fff; border-radius: 3px; text-align: center; -webkit-box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.16), 0 1px 3px 0 rgba(0, 0, 0, 0.12); -moz-box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.16), 0 1px 3px 0 rgba(0, 0, 0, 0.12); box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.16), 0 1px 3px 0 rgba(0, 0, 0, 0.12)">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 40px;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 0 15px;">
                                                        <asp:Image ID="thanku" runat="server" ImageUrl="~/assets/images/thanku.png" Width="50%" />
                                                        <h1 style="color: #3075BA; font-weight: 400; margin: 0; font-size: 20px;">Your Password Has been Successfully Set.</h1>
                                                        <br />
                                                        <strong>Go To Login Page ?</strong><a href="LoginInfo.aspx">Login</a><br />
                                                        <span style="display: inline-block; vertical-align: middle; margin: 29px 0 26px; border-bottom: 1px solid #cecece; width: 100px;"></span>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 40px;">&nbsp;</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div style="display: none" id="Dvpswreset">
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="max-width: 670px; background: #fff; border-radius: 3px; text-align: center; -webkit-box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.16), 0 1px 3px 0 rgba(0, 0, 0, 0.12); -moz-box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.16), 0 1px 3px 0 rgba(0, 0, 0, 0.12); box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.16), 0 1px 3px 0 rgba(0, 0, 0, 0.12)">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 40px;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 0 15px;">
                                                        <h1 style="color: #3075BA; font-weight: 400; margin: 0; font-size: 30px;">Set Password</h1>
                                                        <span style="display: inline-block; vertical-align: middle; margin: 29px 0 26px; border-bottom: 1px solid #cecece; width: 100px;"></span>
                                                        <%--   <strong>This Page allows you to reset your password.</strong>--%>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-md-2"></div>
                                                            <div class="col-md-8">
                                                                <div class="input-group" id="show_hide_password">
                                                                    <asp:TextBox ID="txtpsw" runat="server"  class="form-control" placeholder="Enter New Password" maxlength="30" autocomplete="off"></asp:TextBox>
                                                                   <%-- <input type="password" id="txtpsw" class="form-control" placeholder="Enter New Password" maxlength="30" autocomplete="off" />--%>
                                                                    <div class="input-group-addon" style="cursor: pointer;">
                                                                        <a><i class="fa fa-eye-slash" aria-hidden="true"></i></a>
                                                                    </div>
                                                                </div>
                                                                <%-- <input id="txtpsw" type="password" class="form-control" placeholder="Enter New Password" maxlength="30" autocomplete="off" />--%>
                                                                <label id="errormsgpsw" style="color: red"></label>
                                                                <input type="hidden" id="scode" />
                                                                <input type="hidden" id="stype" />
                                                                <input type="hidden" id="centerid" />
                                                                <%--<input id="txtcpsw" type="password" class="form-control" placeholder="Confirm Password" maxlength="30" autocomplete="off" />--%>
                                                                <div class="input-group" id="show_hide_password1">
                                                                    <asp:TextBox ID="txtcpsw" runat="server"  class="form-control" placeholder="Confirm Password" maxlength="30" autocomplete="off"></asp:TextBox>
                                                                   <%-- <input type="password" id="txtcpsw" class="form-control" placeholder="Confirm Password" maxlength="30" autocomplete="off" />--%>
                                                                    <div class="input-group-addon" style="cursor: pointer;">
                                                                        <a><i class="fa fa-eye-slash" aria-hidden="true"></i></a>
                                                                    </div>
                                                                </div>
                                                                <label id="errormsgcpsw" style="color: red"></label>
                                                            </div>
                                                            <div class="col-md-2"></div>
                                                        </div>
                                                        <asp:Button ID="btnsetpsw" runat="server" Text="Set Password" class="btn btn-primary btn-lg" OnClick="btnsetpsw_Click" value="Reset Password" />
                                                        <%--<input id="btnsetpsw" type="button" class="btn btn-primary btn-lg" value="Reset Password" />--%>


                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 40px;">&nbsp;</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <p style="font-size: 14px; color: #455056bd; line-height: 18px; margin: 0 0 0;">Powered by <strong>Suyog Computech (P) Limited </strong></p>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 80px;">&nbsp;</td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
        </form>
    <!--/100% body table-->
    <script src="assets/js/jquery-3.3.1.min.js"></script>
    <!-- vendor css files -->
    <script type="text/javascript">
        $(document).ready(function () {
           
            debugger;
            $('#show_hide_password input').attr('type', 'password');
            $('#show_hide_password1 input').attr('type', 'password');

            var pageURL = $(location).attr("href");
            //alert(pageURL);
            var code = pageURL.split("-");
            if (code[1] == undefined) {
                window.location = "404.aspx";
            }
            else if (code[1] == "thanku") {
                $('#Dvpswreset').css('display', 'none');
                $('#Dvpthanku').css('display', 'block');
            }
            else {
                $('#Dvpswreset').css('display', 'block');
                $('#txtpsw').focus();
                $('#scode').val(code[1]);
                $('#centerid').val(code[6]);
                $('#stype').val(code[7]);
                $('#scode').attr('disabled', true);
            }
            //alert($('#centerid').val());

        });

        //$(document).ready(function () {
        //    debugger;
        //    var pageURL = $(location).attr("href");
        //    var code = pageURL.split("-");
            

        //});


        $("#show_hide_password a").on('click', function (event) {
            event.preventDefault();
            if ($('#show_hide_password input').attr("type") == "text") {
                $('#show_hide_password input').attr('type', 'password');
                $('#show_hide_password i').addClass("fa-eye-slash");
                $('#show_hide_password i').removeClass("fa-eye");
            } else if ($('#show_hide_password input').attr("type") == "password") {
                $('#show_hide_password input').attr('type', 'text');
                $('#show_hide_password i').removeClass("fa-eye-slash");
                $('#show_hide_password i').addClass("fa-eye");
            }
        });
        $("#show_hide_password1 a").on('click', function (event) {
            event.preventDefault();
            if ($('#show_hide_password1 input').attr("type") == "text") {
                $('#show_hide_password1 input').attr('type', 'password');
                $('#show_hide_password1 i').addClass("fa-eye-slash");
                $('#show_hide_password1 i').removeClass("fa-eye");
            } else if ($('#show_hide_password1 input').attr("type") == "password") {
                $('#show_hide_password1 input').attr('type', 'text');
                $('#show_hide_password1 i').removeClass("fa-eye-slash");
                $('#show_hide_password1 i').addClass("fa-eye");
            }
        });

        $('#txtpsw').keypress(function () {
            var upperCase = new RegExp('[A-Z]');
            var lowerCase = new RegExp('[a-z]');
            var numbers = new RegExp('[0-9]');
            if ($(this).val().match(upperCase) && $(this).val().match(lowerCase) && $(this).val().match(numbers) && $(this).val().length >= 8) {
                $('#errormsgpsw').text('');
            }
            else {
                $('#errormsgpsw').text("contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters");
            }
        });

        $('#txtcpsw').hover(function () {

            $('#errormsgcpsw').text('');
        });

        $('#btnsetpsw').click(function () {

            // debugger;
            var upperCase = new RegExp('[A-Z]');
            var lowerCase = new RegExp('[a-z]');
            var numbers = new RegExp('[0-9]');
            if ($('#txtpsw').val().match(upperCase) && $('#txtpsw').val().match(lowerCase) && $('#txtpsw').val().match(numbers) && $('#txtpsw').val().length >= 8) {
                $('#errormsgpsw').text('');
            }
            else {
                $('#errormsgpsw').text("contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters");
                $('#txtpsw').focus();
                return false;
            }
            if ($('#txtcpsw').val() == "") {
                $('#errormsgcpsw').text("Confirm Password Field Can't Be Blank");
                $('#errormsgpsw').text('');
                $('#txtcpsw').focus();
                return false;
            }

            if ($('#txtpsw').val() != $('#txtcpsw').val()) {
                $('#errormsgcpsw').text("Confirm Password Must be Match With Password");
                $('#txtcpsw').val('');
                $('#txtcpsw').focus();
                return false;
            }
            else {
                $('#errormsgcpsw').text('');
            }

           

        });
    </script>
</body>
</html>
