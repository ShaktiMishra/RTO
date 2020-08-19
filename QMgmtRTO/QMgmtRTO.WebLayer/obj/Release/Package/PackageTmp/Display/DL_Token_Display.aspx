<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DL_Token_Display.aspx.cs" Inherits="QMgmtRTO.WebLayer.Display.DL_Token_Display" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>RTO CUTTACK : DL Token Display</title>
    <link rel="icon" type="image/ico" href="../assets/images/favicon.png" />
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
    <script src="assets/js/vendor/modernizr/modernizr-2.8.3-respond-1.4.2.min.js"></script>
    <!--/ modernizr -->

    <script language="javascript" type="text/javascript">
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () {
            null
        };

    </script>
    <style>
        .h1-class {
            font-size: 37px;
            font-weight: bold;
            color: #d4d8de;
        }

        .h3-class {
            font-size: 26px;
            /*font-weight: bold;*/
            color: #d4d8de;
        }

        .h11-class {
            font-size: 70px;
            font-weight: bold;
            color: #d4d8de;
        }

        .st-class {
            font-size: 40px;
        }

        .st-class1 {
            font-size: 25px;
        }

        .st-class12 {
            font-size: 130px;
        }

        .h {
            line-height: normal;
        }
    </style>
    <script>
        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById('lbl_current_time').innerHTML =
            h + ":" + m + ":" + s;
            var t = setTimeout(startTime, 500);
        }
        function checkTime(i) {
            if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10  
            return i;
        }
    </script>
</head>
<body id="minovate" class="appWrapper" onload="startTime()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="wrap" class="animsition">
            <div class="page page-core page-login">
                <div class="col-md-12" style="margin-top: -68px !important;">
                    <div class="col-md-6">
                        <div class="text-left">
                            <h1 class="h1-class">Welcome To Driving Licence Display</h1>
                             <h3 class="h3-class">Please wait till your Token number is displayed</h3>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="text-right">
                        <h1 class="h1-class">ଡ୍ରାଇଭିଂ ଲାଇସେନ୍ସ ପ୍ରଦର୍ଶନକୁ ସ୍ୱାଗତ</h1>
                            <h3 class="h3-class">ଆପଣଙ୍କର ଟୋକେନ୍ ନମ୍ବର ପ୍ରଦର୍ଶିତ ହେବା ପର୍ଯ୍ୟନ୍ତ ଦୟାକରି ଅପେକ୍ଷା କରନ୍ତୁ </h3>
                            </div>
                        <%--<div class="text-right">
                            <h1 class="h11-class">
                                <label id="lbl_current_time"></label>
                            </h1>
                        </div>--%>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" Enabled="True">
                        </asp:Timer>
                        <div class="col-md-12" style="margin-top: 20px; display: block; height: 264px;">
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-blue portlet">
                                    <div class="tile-header dvd dvd-btm">
                                        <div class="text-center">
                                            <h1 class="custom-font"><strong class="st-class">LMV</strong></h1>
                                        </div>
                                    </div>
                                    <div class="tile-body h">
                                        <div class="text-center">
                                            <strong class="st-class1">Token Number</strong><br />
                                            <asp:Label runat="server" ID="lbl_tokenLMV" class="st-class12"></asp:Label>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-lightred portlet">
                                    <div class="tile-header dvd dvd-btm">
                                        <div class="text-center">
                                            <h1 class="custom-font"><strong class="st-class">MCWG</strong></h1>
                                        </div>
                                    </div>
                                    <div class="tile-body h">
                                        <div class="text-center">
                                            <strong class="st-class1">Token Number</strong><br />
                                            <asp:Label runat="server" ID="lbl_tokenMCWG" class="st-class12"></asp:Label>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-orange portlet">
                                    <div class="tile-header dvd dvd-btm">
                                        <div class="text-center">
                                            <h1 class="custom-font"><strong class="st-class">MCWOG</strong></h1>
                                        </div>
                                    </div>
                                    <div class="tile-body h">
                                        <div class="text-center">
                                            <strong class ="st-class1">Token Number</strong><br />
                                            <asp:Label runat="server" ID="lbl_tokenMCWOG" class="st-class12"></asp:Label>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-green portlet">
                                    <div class="tile-header dvd dvd-btm">
                                        <div class="text-center">
                                            <h1 class="custom-font"><strong class="st-class">TRANS</strong></h1>
                                        </div>
                                    </div>
                                    <div class="tile-body h">
                                        <div class="text-center">
                                            <strong class="st-class1">Token Number</strong><br />
                                            <asp:Label runat="server" ID="lbl_tokenTRANS" class="st-class12"></asp:Label>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </div>
                        <div class="col-md-12" style="margin-top: 50px; display: block;">
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-blue portlet">
                                    <div class="tile-header dvd dvd-btm">
                                        <div class="text-center">
                                            <h1 class="custom-font"><strong class="st-class">LMV Pending</strong></h1>
                                        </div>
                                    </div>
                                    <div class="tile-body h">
                                        <div class="text-center">
                                            <strong class="st-class1">Token Number</strong><br />
                                            <asp:Label runat="server" ID="lbl_lmvPending" class="st-class12"></asp:Label>
                                        </div>
                                    </div>

                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-lightred portlet">
                                    <div class="tile-header dvd dvd-btm">
                                        <div class="text-center">
                                            <h1 class="custom-font"><strong class="st-class">MCWG Pending</strong></h1>
                                        </div>
                                    </div>
                                    <div class="tile-body h">
                                        <div class="text-center">
                                            <strong class="st-class1">Token Number</strong><br />
                                            <asp:Label runat="server" ID="lbl_mcwgPending" class="st-class12"></asp:Label>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-orange portlet">
                                    <div class="tile-header dvd dvd-btm">
                                        <div class="text-center">
                                            <h1 class="custom-font"><strong class="st-class" style="font-size:35px !important;">MCWOG Pending</strong></h1>
                                        </div>
                                    </div>
                                    <div class="tile-body h">
                                        <div class="text-center">
                                            <strong class="st-class1">Token Number</strong><br />
                                            <asp:Label runat="server" ID="lbl_mcwogPending" class="st-class12"></asp:Label>
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-green portlet">
                                    <div class="tile-header dvd dvd-btm">
                                        <div class="text-center">
                                            <h1 class="custom-font"><strong class="st-class">TRANS Pending</strong></h1>
                                        </div>
                                    </div>
                                    <div class="tile-body h">
                                        <div class="text-center">
                                            <strong class="st-class1">Token Number</strong><br />
                                            <asp:Label runat="server" ID="lbl_transPending" class="st-class12"></asp:Label>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <script src="assets/js/font.js"></script>
        <script>window.jQuery || document.write('<script src="assets/js/vendor/jquery/jquery-1.11.2.min.js"><\/script>')</script>

        <script src="assets/js/vendor/bootstrap/bootstrap.min.js"></script>

        <script src="assets/js/vendor/jRespond/jRespond.min.js"></script>

        <script src="assets/js/vendor/sparkline/jquery.sparkline.min.js"></script>

        <script src="assets/js/vendor/slimscroll/jquery.slimscroll.min.js"></script>

        <script src="assets/js/vendor/animsition/js/jquery.animsition.min.js"></script>

        <script src="assets/js/vendor/screenfull/screenfull.min.js"></script>
        <!--/ vendor javascripts -->

        <!-- ============================================
        ============== Custom JavaScripts ===============
        ============================================= -->
        <script src="assets/js/main.js"></script>
    </form>
</body>

</html>
