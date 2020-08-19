<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DL_Dispaly_for_Result.aspx.cs" Inherits="Display_DL_Dispaly_for_Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="maValidation" content="bdf5b5569d28a382a610300e980a8451" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>RTO CUTTACK : DL Result Display</title>
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
    <link rel="stylesheet" href="../assets/js/vendor/daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" href="../assets/js/vendor/morris/morris.css" />
    <link rel="stylesheet" href="../assets/js/vendor/owl-carousel/owl.carousel.css" />
    <link rel="stylesheet" href="../assets/js/vendor/owl-carousel/owl.theme.css" />
    <link rel="stylesheet" href="../assets/js/vendor/rickshaw/rickshaw.min.css" />
    <link rel="stylesheet" href="../assets/js/vendor/datetimepicker/css/bootstrap-datetimepicker.min.css" />
    <link rel="stylesheet" href="../assets/js/vendor/datatables/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="../assets/js/vendor/datatables/datatables.bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/js/vendor/chosen/chosen.css" />
    <link rel="stylesheet" href="../assets/js/vendor/summernote/summernote.css" />

    <!-- project main css files -->
    <link rel="stylesheet" href="../assets/css/main.css" />
    <!--/ stylesheets -->

    <!-- ==========================================
        ================= Modernizr ===================
        =========================================== -->
    <script src="../assets/js/vendor/modernizr/modernizr-2.8.3-respond-1.4.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page page-forms-common">
            <!-- row -->
            <div class="row">
                <!-- col -->
                <div class="col-md-12">
                    <section class="tile">
                        <!-- tile header -->
                        <div class="tile-header dvd dvd-btm">
                            <h1 class="custom-font"><strong>DL Result </strong>Display</h1>
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
                        <div class="tile-body">
                            <div class="table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                    <ContentTemplate>
                                        <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" Enabled="True">
                                        </asp:Timer>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="false" CssClass="table table-custom" OnRowDataBound="GridView1_RowDataBound" Style="border-collapse: collapse; color: #000; font-weight: bold;">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL NO">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Token Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltokenNo" runat="server" Text='<%# Eval("token") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Applicant ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplicantId" runat="server" Text='<%# Eval("applno") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Applicant Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplicantName" runat="server" Text='<%# Eval("appli") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmobno" runat="server" Text='<%# Eval("mobno") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Slot Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSlotDt" runat="server" Text='<%# Eval("stdt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Slot Time">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSlotTime" runat="server" Text='<%# Eval("sttim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vehicle">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVehicle" runat="server" Text='<%# Eval("Vehicle") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Result">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblresult" runat="server" Text='<%# Eval("Result") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </section>
                </div>
                <!-- /col -->
            </div>
            <!-- /row -->
        </div>
        <script src="../../ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="../assets/js/vendor/jquery/jquery-1.11.2.min.js"><\/script>')</script>

        <script src="../assets/js/vendor/bootstrap/bootstrap.min.js"></script>

        <script src="../assets/js/vendor/jRespond/jRespond.min.js"></script>

        <script src="../assets/js/vendor/d3/d3.min.js"></script>
        <script src="../assets/js/vendor/d3/d3.layout.min.js"></script>

        <script src="../assets/js/vendor/rickshaw/rickshaw.min.js"></script>

        <script src="../assets/js/vendor/sparkline/jquery.sparkline.min.js"></script>

        <script src="../assets/js/vendor/slimscroll/jquery.slimscroll.min.js"></script>

        <script src="../assets/js/vendor/animsition/js/jquery.animsition.min.js"></script>

        <script src="../assets/js/vendor/daterangepicker/moment.min.js"></script>
        <script src="../assets/js/vendor/daterangepicker/daterangepicker.js"></script>

        <script src="../assets/js/vendor/screenfull/screenfull.min.js"></script>

        <script src="../assets/js/vendor/flot/jquery.flot.min.js"></script>
        <script src="../assets/js/vendor/flot-tooltip/jquery.flot.tooltip.min.js"></script>
        <script src="../assets/js/vendor/flot-spline/jquery.flot.spline.min.js"></script>

        <script src="../assets/js/vendor/easypiechart/jquery.easypiechart.min.js"></script>

        <script src="../assets/js/vendor/raphael/raphael-min.js"></script>
        <script src="../assets/js/vendor/morris/morris.min.js"></script>

        <script src="../assets/js/vendor/owl-carousel/owl.carousel.min.js"></script>

        <script src="assets/js/vendor/datetimepicker/js/bootstrap-datetimepicker.min.js"></script>

        <script src="../assets/js/vendor/datatables/js/jquery.dataTables.min.js"></script>
        <script src="../assets/js/vendor/datatables/extensions/dataTables.bootstrap.js"></script>

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

        <!-- ===============================================
        ============== Page Specific Scripts ===============
        ================================================ -->
    </form>
</body>
</html>
