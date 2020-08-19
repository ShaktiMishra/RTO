<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DL_Exam_Call.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOStaff.DL_Exam_Call" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>RTO : DL Test Call</title>
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
    <link rel="stylesheet" href="../assets/js/vendor/datetimepicker/css/bootstrap-datetimepicker.min.css" />
    <link rel="stylesheet" href="../assets/js/vendor/daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" href="../assets/js/vendor/owl-carousel/owl.carousel.css" />
    <link rel="stylesheet" href="../assets/js/vendor/owl-carousel/owl.theme.css" />
    <link rel="stylesheet" href="../assets/js/vendor/chosen/chosen.css" />
    <link rel="stylesheet" href="../assets/js/vendor/summernote/summernote.css" />
    <link rel="stylesheet" href="../assets/css/vendor/weather-icons.min.css" />

    <!-- project main css files -->
    <link rel="stylesheet" href="../assets/css/main.css" />
    <!--/ stylesheets -->
    <!-- ==========================================
        ================= Modernizr ===================
        =========================================== -->
    <script src="../assets/js/vendor/modernizr/modernizr-2.8.3-respond-1.4.2.min.js"></script>
    <!--/ modernizr -->
    <style>
        #call {
            font-size: 60px;
            height: 121px;
            margin-left: 0px;
            margin-top: 22px;
            width: 156px;
            font-weight: bold;
        }

        .mm {
            font-size: 32px !important;
            height: 100px;
            margin-left: 0px;
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
            document.getElementById('currenttime').innerHTML = h + ":" + m + ":" + s;
            document.getElementById('currenttime1').innerHTML = h + ":" + m + ":" + s;
            var t = setTimeout(startTime, 500);
        }
        function checkTime(i) {
            if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10  
            return i;
        }
    </script>
</head>
<body>
  <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page page-forms-common">
            <!-- ===============================================
            ================= HEADER Content ===================
            ================================================ -->
            <section id="header">
                <header class="clearfix">
                    <!-- Branding -->
                    <div class="branding">
                        <a class="brand" href="index.html">
                            <span><strong>RTO</strong></span>
                        </a>
                    </div>
                    <!-- Branding end -->

                    <!-- Right-side navigation -->
                    <ul class="nav-right pull-right list-inline">
                        <li class="dropdown nav-profile">
                            <a href="../Logininfo.aspx">
                                <span>LOGOUT <i class="fa fa-sign-out"></i></span>
                            </a>
                        </li>
                    </ul>
                    <!-- Right-side navigation end -->
                </header>
            </section>
            <!--/ HEADER Content  -->
            <!-- ====================================================
            ================= CONTENT ===============================
            ===================================================== -->
            <section id="content" style="padding: 0px !important;">
                <div class="page page-ui-widgets">
                    <div class="pageheader">
                        <h2>DL TEST  CALL <span>// You can call for DL test</span></h2>
                        <div class="page-bar">
                            <ul class="page-breadcrumb">
                                <li>
                                    <a href="LL_Exam_Series_Call.aspx"><i class="fa fa-book"></i>&nbsp;DL TEST CALL</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <!-- row -->
                    <div class="row">
                        <!-- col -->
                        <div class="col-md-12">
                            <!-- tile -->
                            <section class="tile bg-drank  widget-appointments">
                                <!-- tile header -->
                                <div class="tile-header dvd dvd-btm">
                                    <h1 class="custom-font">DL</h1>
                                    <ul class="controls" style="display: none;">
                                        <li class="dropdown">

                                            <a role="button" tabindex="0" class="dropdown-toggle settings" data-toggle="dropdown">
                                                <i class="fa fa-cog"></i>
                                                <i class="fa fa-spinner fa-spin"></i>
                                            </a>

                                            <ul class="dropdown-menu pull-right with-arrow animated littleFadeInUp">
                                                <li>
                                                    <a role="button" tabindex="0" class="tile-toggle">
                                                        <span class="minimize"><i class="fa fa-angle-down"></i>&nbsp;&nbsp;&nbsp;Minimize</span>
                                                        <span class="expand"><i class="fa fa-angle-up"></i>&nbsp;&nbsp;&nbsp;Expand</span>
                                                    </a>
                                                </li>
                                                <li>
                                                    <a role="button" tabindex="0" class="tile-refresh">
                                                        <i class="fa fa-refresh"></i>Refresh
                                                    </a>
                                                </li>
                                            </ul>

                                        </li>
                                        <li class="remove"><a role="button" tabindex="0" class="tile-close"><i class="fa fa-times"></i></a></li>
                                    </ul>
                                </div>
                                <!-- /tile header -->

                                <!-- tile body -->
                                <div class="tile-body">
                                    <!-- row -->
                                    <div class="row">
                                        <!-- col -->
                                        <div class="col-md-6 text-center">
                                            <h1 class="text-light">Time</h1>
                                            <div style="width: 100%;">
                                                <canvas id="c1" class="CoolClock:minovateClock:50"></canvas>
                                            </div>
                                        </div>
                                        <!-- /col -->
                                        <!-- col -->
                                        <div class="col-md-6 b-l text-center">
                                            <span class="day">
                                                <asp:Label ID="currday" runat="server"></asp:Label></span><br />
                                            <span class="month">
                                                <asp:Label ID="currmonth" runat="server"></asp:Label></span>
                                        </div>
                                        <!-- /col -->
                                    </div>
                                    <!-- /row -->
                                </div>
                                <!-- /tile body -->

                                <!-- tile footer -->
                                <div class="tile-footer dvd dvd-top mt-20">
                                    <div class="text-center">
                                        <input type="hidden" id="Bid" value="0" />
                                        <a id="call" class="btn btn-primary btn-rounded btn-icon-only btn-ef btn-ef-7 btn-ef-7c mb-10" data-toggle="tooltip" title="click for the next token number">Next</a>
                                        <p>.................  click on above button to call the next token number for DL test</p>
                                    </div>

                                    <div id="Div1" class="text-center" runat="server">
                                        <button id="btnMCWG" runat="server" class="btn btn-primary btn-rounded btn-icon-only btn-ef btn-ef-7 btn-ef-7c mb-10 mm" value="MCWG" text="MCWG">MCWG</button>
                                        <input type="hidden" id="Hidden1" />
                                        <button id="btnLMV" runat="server" class="btn btn-primary btn-rounded btn-icon-only btn-ef btn-ef-7 btn-ef-7c mb-10 mm" text="LMV" value="LMV">LMV</button>
                                        <input type="hidden" id="Hidden2" />
                                        <button id="btnTRANS" runat="server" class="btn btn-primary btn-rounded btn-icon-only btn-ef btn-ef-7 btn-ef-7c mb-10 mm" text="TRANS" value="TRANS">TRANS</button>
                                        <input type="hidden" id="Hidden3" />
                                        <button id="btnMCWOG" runat="server" class="btn btn-primary btn-rounded btn-icon-only btn-ef btn-ef-7 btn-ef-7c mb-10 mm" text="MCWOG" value="MCWOG">MCWOG</button>
                                        <input type="hidden" id="Hidden4" />
                                    </div>
                                </div>
                                <!-- /tile footer -->

                            </section>
                            <!-- /tile -->
                        </div>
                        <!-- /col -->
                    </div>
                    <!-- /row -->
                </div>
            </section>
            <!--/ CONTENT -->
        </div>

        <!-- ============================================
        ============== Vendor JavaScripts ===============
        ============================================= -->
        <script src="../../ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="../assets/js/vendor/jquery/jquery-1.11.2.min.js"><\/script>')</script>

        <script src="../assets/js/vendor/bootstrap/bootstrap.min.js"></script>

        <script src="../assets/js/vendor/jRespond/jRespond.min.js"></script>

        <script src="../assets/js/vendor/sparkline/jquery.sparkline.min.js"></script>

        <script src="../assets/js/vendor/slimscroll/jquery.slimscroll.min.js"></script>

        <script src="../assets/js/vendor/animsition/js/jquery.animsition.min.js"></script>

        <script src="../assets/js/vendor/screenfull/screenfull.min.js"></script>

        <script src="../assets/js/vendor/owl-carousel/owl.carousel.min.js"></script>

        <script src="../assets/js/vendor/daterangepicker/moment.min.js"></script>

        <script src="../assets/js/vendor/datetimepicker/js/bootstrap-datetimepicker.min.js"></script>

        <script src="../assets/js/vendor/chosen/chosen.jquery.min.js"></script>

        <script src="../assets/js/vendor/summernote/summernote.min.js"></script>

        <script src="../assets/js/vendor/coolclock/coolclock.js"></script>
        <script src="../assets/js/vendor/coolclock/excanvas.js"></script>
        <!--/ vendor javascripts -->

        <!-- ============================================
        ============== Custom JavaScripts ===============
        ============================================= -->
        <script src="../assets/js/main.js"></script>
        <!--/ custom javascripts -->
        <script type="text/javascript">
            //$(window).load(function () {

            //});
            $(document).ready(function () {
                $("#btnMCWG").hide();
                $("#btnLMV").hide();
                $("#btnTRANS").hide();
                $("#btnMCWOG").hide();

                $("#Hidden1").val("");
                $("#Hidden2").val("");
                $("#Hidden3").val("");
                $("#Hidden4").val("");



                $.ajax({
                    type: "POST",
                    url: "DL_Exam_Call.aspx/call_next_token_no",
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        $('#call').text(jsodatan);
                    }
                });

                startTime();
            });
            $(document).on('click', '#call', function () {
                $("#btnMCWG").hide();
                $("#btnLMV").hide();
                $("#btnTRANS").hide();
                $("#btnMCWOG").hide();

                $("#Hidden1").val("");
                $("#Hidden2").val("");
                $("#Hidden3").val("");
                $("#Hidden4").val("");

                var data = {};
                if ($('#call').text() == "Call") {
                    data.btnvalue = 0;
                }
                data.Bid = $('#Bid').val();
                $.ajax({
                    type: "POST",
                    url: "DL_Exam_Call.aspx/Call_Next_Token",
                    data: '{data: ' + JSON.stringify(data) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: "false",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        if (jsodatan == "success") {
                            alert('Called sucessfully');
                            $('#form1')[0].reset();
                            location.reload(true);

                        }
                        else if (jsodatan == "Fail") {
                            alert('Something Went Wrong!!');
                        }
                        else {

                            var myString = jsodatan.substr(jsodatan.indexOf("_") + 1)

                            $.ajax({
                                type: "POST",
                                url: "DL_Exam_Call.aspx/multiplebutton",
                                data: "{'data1':'" + myString + "'}",
                                //data: '{"data1":"' + myString + '"}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (response) {
                                    var jsodatan1 = JSON.parse(response.d);
                                    var leng = jsodatan1.length;
                                    for (var i = 0; i < leng; i++) {
                                        if ($.trim(jsodatan1[i]["Vehicle_type"]) == "LMV") {
                                            $("#btnLMV").show();
                                            $("#Hidden2").val(myString);
                                        }
                                        if ($.trim(jsodatan1[i]["Vehicle_type"]) == "MCWG") {
                                            $("#btnMCWG").show();
                                            $("#Hidden1").val(myString);
                                            //alert(jsodatan1[i]["Vehicle_type"]);
                                        }
                                        if ($.trim(jsodatan1[i]["Vehicle_type"]) == "TRANS") {
                                            $("#btnTRANS").show();
                                            $("#Hidden3").val(myString);
                                            //alert(jsodatan1[i]["Vehicle_type"]);
                                        }
                                        if ($.trim(jsodatan1[i]["Vehicle_type"]) == "MCWOG") {
                                            $("#btnMCWOG").show();
                                            $("#Hidden4").val(myString);
                                            // alert(jsodatan1[i]["Vehicle_type"]);
                                        }
                                    }
                                }
                            });

                        }

                    }
                });
            });

            $('#btnMCWG').click(function () {
                var data = {};
                if ($('#btnMCWG').text() == "MCWG") {
                    data.btnvalue = 0;
                    data.tokn = $("#Hidden1").val();
                }
                data.Bid = $('#Bid').val();

                $.ajax({
                    type: "POST",
                    url: "DL_Exam_Call.aspx/call_MCWG",
                    data: '{data: ' + JSON.stringify(data) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        if (jsodatan == "success") {
                            alert('Called sucessfully');
                            $('#form1')[0].reset();
                            location.reload(true);
                        }
                    }
                });
            });


            $('#btnLMV').click(function () {

                var data = {};
                if ($('#btnLMV').text() == "LMV") {
                    data.btnvalue = 0;
                    data.tokn = $("#Hidden2").val();
                }
                data.Bid = $('#Bid').val();

                $.ajax({
                    type: "POST",
                    url: "DL_Exam_Call.aspx/call_LMV",
                    data: '{data: ' + JSON.stringify(data) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        if (jsodatan == "success") {
                            alert('Called sucessfully');
                            $('#form1')[0].reset();
                            location.reload(true);
                        }
                    }
                });
            });

            $('#btnTRANS').click(function () {

                var data = {};
                if ($('#btnTRANS').text() == "TRANS") {
                    data.btnvalue = 0;
                    data.tokn = $("#Hidden3").val();
                }
                data.Bid = $('#Bid').val();

                $.ajax({
                    type: "POST",
                    url: "DL_Exam_Call.aspx/call_TRANS",
                    data: '{data: ' + JSON.stringify(data) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        if (jsodatan == "success") {
                            alert('Called sucessfully');
                            $('#form1')[0].reset();
                            location.reload(true);
                        }
                    }
                });
            });
            $('#btnMCWOG').click(function () {

                var data = {};
                if ($('#btnMCWOG').text() == "MCWOG") {
                    data.btnvalue = 0;
                    data.tokn = $("#Hidden4").val();
                }
                data.Bid = $('#Bid').val();

                $.ajax({
                    type: "POST",
                    url: "DL_Exam_Call.aspx/call_MCWOG",
                    data: '{data: ' + JSON.stringify(data) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        if (jsodatan == "success") {
                            alert('Called sucessfully');
                            $('#form1')[0].reset();
                            location.reload(true);
                        }
                    }
                });
            });
        </script>

    </form>
</body>
</html>
