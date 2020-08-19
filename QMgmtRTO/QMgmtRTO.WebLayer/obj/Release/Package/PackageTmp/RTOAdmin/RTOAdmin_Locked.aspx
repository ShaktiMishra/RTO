<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RTOAdmin_Locked.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOAdmin.RTOAdmin_Locked" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>RTO CUTTACK : Admin Locked</title>
    <link rel="icon" type="image/ico" href="../assets/images/favicon.png" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- ============================================
        ================= Stylesheets ===================
        ============================================= -->
    <!-- vendor css files -->
    <link rel="stylesheet" href="../assets/css/vendor/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/vendor/animate.css" />
    <link rel="stylesheet" href="../assets/css/vendor/font-awesome.min.css" />
    <link rel="stylesheet" href="../assets/js/vendor/animsition/css/animsition.min.css" />
    <!-- project main css files -->
    <link rel="stylesheet" href="../assets/css/main.css" />
    <!--/ stylesheets -->
    <!-- ==========================================
        ================= Modernizr ===================
        =========================================== -->
    <script src="../assets/js/vendor/modernizr/modernizr-2.8.3-respond-1.4.2.min.js"></script>
    <!--/ modernizr -->
    <script lang="javascript" type="text/javascript">
        function checkregister() {
            if (document.getElementById("<%=txtpassword.ClientID %>").value == "") {
                alert("Enter Password!");
                document.getElementById("<%=txtpassword.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body id="minovate" class="appWrapper">
    <form id="form1" runat="server">
        <!-- ====================================================
        ================= Application Content ===================
        ===================================================== -->
        <div id="wrap" class="animsition">
            <div class="page page-core page-locked">
                <div class="text-center">
                    <h3 class="text-light text-white"><span class="text-lightred" style="color: white !important"><strong>RTO-</strong></span>CUTTACK</h3>
                </div>
                <div class="container w-420 p-15 bg-white mt-40">
                    <div class="bg-slategray lt wrap-reset mb-20 text-center">
                        <h2 class="text-light text-greensea m-0">Locked</h2>
                    </div>
                    <div class="media p-15">
                        <div class="pull-left thumb thumb-lg mr-20">
                            <img class="media-object img-circle" src="../assets/images/admin.png" alt="" />
                        </div>
                        <div class="media-body">
                            <form name="form" class="form-validation">
                                <h4 class="media-heading mb-0"><strong>ADMIN</strong></h4>
                                <div class="form-group mt-10">
                                    <asp:TextBox ID="txtpassword" name="pass" runat="server" TextMode="Password" class="form-control underline-input" placeholder="Password" MaxLength="20"></asp:TextBox>
                                </div>
                                <div class="form-group text-left">
                                    <%-- <a href="index.html" class="btn btn-greensea b-0 br-2 mr-5 block">Login</a>--%>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Login" CssClass="btn btn-greensea b-0 br-2 mr-5 block" OnClientClick=" return checkregister()" OnClick="btnSubmit_Click" />
                                </div>
                            </form>
                        </div>
                    </div>
                    <div class="bg-slategray lt wrap-reset mt-0 text-center">
                        <p class="m-0">
                            <a href="../Logininfo.aspx">Not you?</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <!--/ Application Content -->
        <!-- ============================================
        ============== Vendor JavaScripts ===============
        ============================================= -->
        <script src="../../../ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="../assets/js/vendor/jquery/jquery-1.11.2.min.js"><\/script>')</script>

        <script src="../assets/js/vendor/bootstrap/bootstrap.min.js"></script>

        <script src="../assets/js/vendor/jRespond/jRespond.min.js"></script>

        <script src="../assets/js/vendor/sparkline/jquery.sparkline.min.js"></script>

        <script src="../assets/js/vendor/slimscroll/jquery.slimscroll.min.js"></script>

        <script src="../assets/js/vendor/animsition/js/jquery.animsition.min.js"></script>

        <script src="../assets/js/vendor/screenfull/screenfull.min.js"></script>
        <!--/ vendor javascripts -->
        <!-- ============================================
        ============== Custom JavaScripts ===============
        ============================================= -->
        <script src="../assets/js/main.js"></script>
        <!--/ custom javascripts -->
        <!-- ===============================================
        ============== Page Specific Scripts ===============
        ================================================ -->
        <script>
            $(window).load(function () {


            });
        </script>
        <!--/ Page Specific Scripts -->
    </form>
</body>
</html>
