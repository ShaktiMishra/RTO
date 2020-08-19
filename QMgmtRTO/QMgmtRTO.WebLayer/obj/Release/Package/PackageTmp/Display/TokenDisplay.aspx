<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TokenDisplay.aspx.cs" Inherits="QMgmtRTO.WebLayer.Display.TokenDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>RTO CUTTACK : Scrutinizing Display</title>
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

                <div class="col-md-12">
                    <div class="col-md-10">
                        <div class="text-left">
                            <h1 class="h1-class">Welcome To Scrutinizing Display</h1>
                           <h1 class="h1-class">  ସ୍କ୍ରୁଟାଇଜିଂ ପ୍ରଦର୍ଶନକୁ ସ୍ୱାଗତ </h1>|
                            <h3 class="h3-class">Please wait till your Token number is displayed</h3>
                         <h3 class="h3-class"> ଆପଣଙ୍କର ଟୋକେନ୍ ନମ୍ବର ପ୍ରଦର୍ଶିତ ହେବା ପର୍ଯ୍ୟନ୍ତ ଦୟାକରି ଅପେକ୍ଷା କରନ୍ତୁ </h3>
                        </div>
                    </div>
                   
                </div>
                
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" Enabled="false">
                        </asp:Timer>
                        <div class="col-md-12" style="margin-top: 120px;">
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-blue portlet">
                                    <asp:Literal runat="server" ID="token"></asp:Literal>
                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-lightred portlet">
                                    <asp:Literal runat="server" ID="token1"></asp:Literal>
                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-orange portlet">
                                    <asp:Literal runat="server" ID="token2"></asp:Literal>
                                </section>
                            </div>
                            <div class="col-sm-3 portlets sortable">
                                <section class="tile bg-green portlet">
                                    <asp:Literal runat="server" ID="token3"></asp:Literal>
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
