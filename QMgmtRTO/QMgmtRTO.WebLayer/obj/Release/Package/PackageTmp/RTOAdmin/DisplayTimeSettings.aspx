<%@ Page Title="" Language="C#" MasterPageFile="~/RTOAdmin/RTOAdmin.Master" AutoEventWireup="true" CodeBehind="DisplayTimeSettings.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOAdmin.DisplayTimeSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page page-forms-common">
        <div class="pageheader">
            <h2>Display Time Settings <span>//You can Set your Display Time settings...........</span></h2>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <a href="Dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="#">Settings</a>
                    </li>
                    <li>
                        <a href="DisplayTimeSettings.aspx">Display Time Settings</a>
                    </li>
                </ul>
            </div>
        </div>

        <!-- row -->
        <div class="row">
            <!-- col -->
            <div class="col-md-12">
                <!-- tile -->
                <section class="tile">
                    <!-- tile header -->
                    <div class="tile-header dvd dvd-btm">
                        <h1 class="custom-font"><strong>Display Time </strong>Settings</h1>
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
                        <div class="form-inline">
                            <asp:Button runat="server" ID="btndisplaytime" Text="Save" CssClass="btn btn-success" OnClick="btndisplaytime_Click" />
                            <asp:DropDownList runat="server" ID="ddldisplaytime" CssClass="form-control">
                                <asp:ListItem Value="0">Minute</asp:ListItem>
                                <asp:ListItem Value="1">Hour</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox runat="server" ID="txtdisplaytime" CssClass="form-control" placeholder="Enter Time"></asp:TextBox>
                        </div>
                    </div>



                    <!-- /tile body -->
                </section>
                <!-- /tile -->

            </div>
            <!-- /col -->
        </div>
        <!-- /row -->
    </div>
    <script src="../assets/js/jquery-3.3.1.min.js"></script>
    <script>
        $('#ContentPlaceHolder1_btndisplaytime').click(function () {         
            var Time = $("#ContentPlaceHolder1_txtdisplaytime").val();
            var median = $("#ContentPlaceHolder1_ddldisplaytime").val();
            if (Time == "") {
                alert("Time Field Cant Be Blank");
                $("#ContentPlaceHolder1_txtdisplaytime").focus();
                return false;
            } else if (median == "1") {
                if (Time > 12) {
                    alert("Hours Limit Exceed");
                    $("#ContentPlaceHolder1_txtdisplaytime").val('');
                    $("#ContentPlaceHolder1_txtdisplaytime").focus();
                    return false;
                }
            }
            else if (median == "0") {
                if (Time > 60) {
                    alert("Min Limit Exceed");
                    $("#ContentPlaceHolder1_txtdisplaytime").val('');
                    $("#ContentPlaceHolder1_txtdisplaytime").focus();
                    return false;
                }
            }
            
        });

    </script>
</asp:Content>
