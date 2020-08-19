<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Scrutinizing_Display.aspx.cs" Inherits="Display_Scrutinizing_Display" %>

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
                    <div class="col-md-6">
                        <div class="text-left">
                            <h1 class="h1-class">Welcome To Scrutinizing Display</h1>
                           <h1 class="h1-class">  ସ୍କ୍ରୁଟାଇଜିଂ ପ୍ରଦର୍ଶନକୁ ସ୍ୱାଗତ </h1>|
                            <h3 class="h3-class">Please wait till your Token number is displayed</h3>
                         <h3 class="h3-class"> ଆପଣଙ୍କର ଟୋକେନ୍ ନମ୍ବର ପ୍ରଦର୍ଶିତ ହେବା ପର୍ଯ୍ୟନ୍ତ ଦୟାକରି ଅପେକ୍ଷା କରନ୍ତୁ </h3>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <%--<div class="text-left">
                            <canvas id="canvas" width="200" height="200"></canvas>
                        </div>--%>
                        <div class="text-right">
                            <h1 class="h11-class">
                                <label id="lbl_current_time"></label>
                            </h1>
                        </div>
                    </div>
                </div>
                <%--<div class="col-md-12" style="margin-top: 120px; display: none;">
                    <div class="col-sm-3 portlets sortable">
                        <section class="tile bg-blue portlet">
                            <div class="tile-header dvd dvd-btm">
                                <div class="text-center">
                                    <h1 class="custom-font"><strong class="st-class">Counter 1</strong></h1>
                                </div>
                            </div>
                            <div class="tile-body h">
                                <div class="text-center">
                                    <strong class="st-class1">Learners License(LL)</strong><br />
                                    <strong class="st-class1">Token Number</strong><br />
                                    <strong class="st-class12">66</strong>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-sm-3 portlets sortable">
                        <section class="tile bg-lightred portlet">
                            <div class="tile-header dvd dvd-btm">
                                <div class="text-center">
                                    <h1 class="custom-font"><strong class="st-class">Counter 2</strong></h1>
                                </div>
                            </div>
                            <div class="tile-body h">
                                <div class="text-center">
                                    <strong class="st-class1">Learners License(LL)</strong><br />
                                    <strong class="st-class1">Token Number</strong><br />
                                    <strong class="st-class12">52</strong>

                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-sm-3 portlets sortable">
                        <section class="tile bg-orange portlet">
                            <div class="tile-header dvd dvd-btm">
                                <div class="text-center">
                                    <h1 class="custom-font"><strong class="st-class">Counter 3</strong></h1>
                                </div>
                            </div>
                            <div class="tile-body h">
                                <div class="text-center">
                                    <strong class="st-class1">Learners License(LL)</strong><br />
                                    <strong class="st-class1">Token Number</strong><br />
                                    <strong class="st-class12">27</strong>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-sm-3 portlets sortable">
                        <section class="tile bg-green portlet">
                            <div class="tile-header dvd dvd-btm">
                                <div class="text-center">
                                    <h1 class="custom-font"><strong class="st-class">Counter 4</strong></h1>
                                </div>
                            </div>
                            <div class="tile-body h">
                                <div class="text-center">
                                    <strong class="st-class1">Learners License(LL)</strong><br />
                                    <strong class="st-class1">Token Number</strong><br />
                                    <strong class="st-class12">159</strong>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>--%>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" Enabled="True">
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

        <%--<script>
            var canvas = document.getElementById("canvas");
            var ctx = canvas.getContext("2d");
            var radius = canvas.height / 2;
            ctx.translate(radius, radius);
            radius = radius * 0.90
            setInterval(drawClock, 1000);

            function drawClock() {
                drawFace(ctx, radius);
                drawNumbers(ctx, radius);
                drawTime(ctx, radius);
            }

            function drawFace(ctx, radius) {
                var grad;
                ctx.beginPath();
                ctx.arc(0, 0, radius, 0, 2 * Math.PI);
                ctx.fillStyle = 'white';
                ctx.fill();
                grad = ctx.createRadialGradient(0, 0, radius * 0.95, 0, 0, radius * 1.05);
                grad.addColorStop(0, '#333');
                grad.addColorStop(0.5, 'white');
                grad.addColorStop(1, '#333');
                ctx.strokeStyle = grad;
                ctx.lineWidth = radius * 0.1;
                ctx.stroke();
                ctx.beginPath();
                ctx.arc(0, 0, radius * 0.1, 0, 2 * Math.PI);
                ctx.fillStyle = '#333';
                ctx.fill();
            }

            function drawNumbers(ctx, radius) {
                var ang;
                var num;
                ctx.font = radius * 0.15 + "px arial";
                ctx.textBaseline = "middle";
                ctx.textAlign = "center";
                for (num = 1; num < 13; num++) {
                    ang = num * Math.PI / 6;
                    ctx.rotate(ang);
                    ctx.translate(0, -radius * 0.85);
                    ctx.rotate(-ang);
                    ctx.fillText(num.toString(), 0, 0);
                    ctx.rotate(ang);
                    ctx.translate(0, radius * 0.85);
                    ctx.rotate(-ang);
                }
            }

            function drawTime(ctx, radius) {
                var now = new Date();
                var hour = now.getHours();
                var minute = now.getMinutes();
                var second = now.getSeconds();
                //hour
                hour = hour % 12;
                hour = (hour * Math.PI / 6) +
                (minute * Math.PI / (6 * 60)) +
                (second * Math.PI / (360 * 60));
                drawHand(ctx, hour, radius * 0.5, radius * 0.07);
                //minute
                minute = (minute * Math.PI / 30) + (second * Math.PI / (30 * 60));
                drawHand(ctx, minute, radius * 0.8, radius * 0.07);
                // second
                second = (second * Math.PI / 30);
                drawHand(ctx, second, radius * 0.9, radius * 0.02);
            }

            function drawHand(ctx, pos, length, width) {
                ctx.beginPath();
                ctx.lineWidth = width;
                ctx.lineCap = "round";
                ctx.moveTo(0, 0);
                ctx.rotate(pos);
                ctx.lineTo(0, -length);
                ctx.stroke();
                ctx.rotate(-pos);
            }
        </script>--%>
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
