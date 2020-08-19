<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LL_Exam_Call.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOStaff.LL_Exam_Call" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>RTO : LL Series Call</title>
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
    <%--    <style>
        #call {
            font-size: 32px;
            height: 100px;
            margin-left: 0px;
            margin-top: 22px;
        }
    </style>--%>
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
            document.getElementById('currenttime2').innerHTML = h + ":" + m + ":" + s;
            var t = setTimeout(startTime, 500);
        }
        function checkTime(i) {
            if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10  
            return i;
        }
    </script>
</head>
<body onload="startTime()">
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
                        <h2>LL EXAM SERIES CALL <span>// You can call series range for LL exam</span></h2>
                        <div class="page-bar">
                            <ul class="page-breadcrumb">
                                <li>
                                    <a href="LL_Exam_Series_Call.aspx"><i class="fa fa-book"></i>&nbsp;LL EXAM SERIES CALL</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <!-- row -->
                    <div class="row">
                        <!-- col -->
                        <div class="col-md-12">
                            <!-- tile -->
                            <section class="tile bg-greensea widget-appointments">
                                <!-- tile header -->
                                <div class="tile-header dvd dvd-btm">
                                    <h1 class="custom-font">Appointments</h1>
                                    <ul class="controls">
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
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4 text-center">
                                            </div>
                                            <div class="col-md-4 text-center">
                                                <div class="col-md-4 text-center">
                                                    <div class="form-group">
                                                        From
                                                        <%--<input id="txtfromno" type="text" placeholder="From number " autocomplete="off" class="form-control" />--%>

                                                        <asp:TextBox id="txtfromno" type="text" placeholder="From number " autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 text-center">
                                                    <div class="form-group">
                                                        To
                                                       <%-- <input id="txttono" type="text" placeholder="To number " autocomplete="off" class="form-control" />--%>

                                                        <asp:TextBox id="txttono" type="text" placeholder="To number " autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 text-center">
                                                    <input type="hidden" id="Bid" value="0" />
                                                    Call The series
                                                    <%--<button id="call" class="btn btn-success" type="submit"><i class="fa fa-arrow-right" data-toggle="tooltip" title="click for the next token series"></i></button>--%>
                                                    <asp:Button runat="server" ID="btnnext" Text="Call" OnClick="btnnext_Click" class="btn btn-danger"/>
                                                </div>

                                            </div>
                                            <div class="col-md-4 text-center">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /tile body -->

                                <!-- tile footer -->
                                <div class="tile-footer dvd dvd-top mt-20">
                                    <div class="owl-carousel" id="appointments-carousel">
                                        <div>
                                            <p class="text-center text-strong" style="font-size: 35px"><i class="fa fa-clock-o"></i>&nbsp;<asp:Label runat="server" ID="currenttime"></asp:Label></p>
                                            <p>
                                                <h4 class="mt-10 mb-0 text-strong">Total Tokens Completed At Scrutinizing & Biometrics Counter</h4>
                                                <br />
                                                <span style="font-size: 40px">
                                                    <asp:Label runat="server" ID="lbltotcompatbio">NA</asp:Label></span>
                                            </p>
                                        </div>

                                        <div>
                                            <p class="text-center text-strong" style="font-size: 35px"><i class="fa fa-clock-o"></i>&nbsp;<asp:Label runat="server" ID="currenttime1"></asp:Label></p>
                                            <p>
                                                <h4 class="mt-10 mb-0 text-strong">Total Tokens Waiting near Scrutinizing & Biometrics Counter</h4>
                                                <br />
                                                <span style="font-size: 40px">
                                                    <asp:Label runat="server" ID="lbltotwaitnearbio">NA</asp:Label></span>
                                            </p>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                            <ContentTemplate>
                                                <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" Enabled="True">
                                                </asp:Timer>
                                                <div>
                                                    <p class="text-center text-strong" style="font-size: 35px"><i class="fa fa-clock-o"></i>&nbsp;<asp:Label runat="server" ID="currenttime2"></asp:Label></p>
                                                    <span style="font-size: 40px">Series Called from
                                                    <asp:Label runat="server" ID="lblfrom">__</asp:Label> to <asp:Label runat="server" ID="lblto">__</asp:Label>.</span>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                            </Triggers>
                                        </asp:UpdatePanel>
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
            $(window).load(function () {

                // Initialize owl carousels
                $('#appointments-carousel').owlCarousel({
                    autoPlay: 9000,
                    stopOnHover: true,
                    slideSpeed: 300,
                    paginationSpeed: 400,
                    navigation: true,
                    navigationText: ['<i class=\'fa fa-chevron-left\'></i>', '<i class=\'fa fa-chevron-right\'></i>'],
                    singleItem: true
                });
                //* Initialize owl carousels
            });

            //#region previous
            //$('#call').click(function () {
            //    if ($('#txtfromno').val() == "") {
            //        alert("Enter From Number")
            //        $('#txtfromno').focus();
            //        return false;
            //    }
            //    if ($('#txttono').val() == "") {
            //        alert("Enter To Number")
            //        $('#txttono').focus();
            //        return false;
            //    }

            //    var data = {};

            //    data.from = $("#txtfromno").val();
            //    data.to = $("#txttono").val();


            //    data.Bid = $('#Bid').val();

            //    $.ajax({
            //        type: "POST",
            //        url: "LL_Exam_Series_Call.aspx/Call_series_range",
            //        data: '{data: ' + JSON.stringify(data) + '}',
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (response) {
            //            var jsodatan = JSON.parse(response.d);
            //            if (jsodatan == "success") {
            //                alert('Called sucessfully');
            //                $('#form1')[0].reset();
            //            }
            //            else {
            //                alert('Something Went Wrong !!!!!!!!!');
            //            }
            //            getdata();
            //        }

            //    });
            //});

            //$('#txtfromno').change(function () {
            //    var user = {};
            //    user.from = $("#txtfromno").val();
            //    $.ajax({
            //        type: "POST",
            //        url: "LL_Exam_Series_Call.aspx/Checkfromno",
            //        data: '{user: ' + JSON.stringify(user) + '}',
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (response) {
            //            if (response.d == '"1"') {
            //                alert("Alreay this number called.");
            //                $("#txtfromno").val('');
            //            }
            //        }
            //    });
            //});

            //$('#txttono').change(function () {
            //    var user = {};
            //    user.to = $("#txttono").val();
            //    $.ajax({
            //        type: "POST",
            //        url: "LL_Exam_Series_Call.aspx/Checktono",
            //        data: '{user: ' + JSON.stringify(user) + '}',
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (response) {
            //            if (response.d == '"1"') {
            //                alert("Alreay this number called.");
            //                $("#txttono").val('');
            //            }
            //        }
            //    });
            //});
            //#endregion
        </script>
    </form>
</body></html>
