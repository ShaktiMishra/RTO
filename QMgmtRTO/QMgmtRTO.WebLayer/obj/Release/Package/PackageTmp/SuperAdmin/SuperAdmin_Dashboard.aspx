<%@ Page Language="C#" MasterPageFile="~/SUPERADMIN/SuperAdmin.master" AutoEventWireup="true" CodeBehind="SuperAdmin_Dashboard.aspx.cs" Inherits="QMgmtRTO.WebLayer.SuperAdmin.SuperAdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .label {
            font-size: 1.37em !important;
            color: #333333 !important;
            font-weight: 300 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-lg-3 col-sm-6">
            <div class="card card-stats">
                <div class="card-body">
                    <div class="row">
                        <div class="col-5">
                            <div class="icon-big text-center icon-warning">
                                <i class="nc-icon nc-tablet-2  text-warning"></i>
                            </div>
                        </div>
                        <div class="col-7">
                            <div class="numbers">
                                <p class="card-category">Total Center</p>
                                <h4 class="card-title">
                                    <label id="lbltotCenter" class="label"></label>
                                </h4>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer ">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh"></i>Total
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-6">
            <div class="card card-stats">
                <div class="card-body ">
                    <div class="row">
                        <div class="col-5">
                            <div class="icon-big text-center icon-warning">
                                <i class="nc-icon nc-circle-09 text-success"></i>
                            </div>
                        </div>
                        <div class="col-7">
                            <div class="numbers">
                                <p class="card-category">Total Staff</p>
                                <h4 class="card-title">1,345</h4>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer ">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-calendar-o"></i>Total
                                   
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-6">
            <div class="card card-stats">
                <div class="card-body ">
                    <div class="row">
                        <div class="col-5">
                            <div class="icon-big text-center icon-warning">
                                <i class="nc-icon nc-single-02 text-danger"></i>
                            </div>
                        </div>
                        <div class="col-7">
                            <div class="numbers">
                                <p class="card-category">Active Users</p>
                                <h4 class="card-title">23</h4>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer ">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-clock-o"></i>Today's
                                   
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-sm-6">
            <div class="card card-stats">
                <div class="card-body ">
                    <div class="row">
                        <div class="col-5">
                            <div class="icon-big text-center icon-warning">
                                <i class="nc-icon nc-single-02 text-primary"></i>
                            </div>
                        </div>
                        <div class="col-7">
                            <div class="numbers">
                                <p class="card-category">Total Applicants</p>
                                <h4 class="card-title">+45K</h4>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer ">
                    <hr />
                    <div class="stats">
                        <i class="fa fa-refresh"></i>Today's
                                   
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../assets/js/vendor/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            AllCenter();
        });

        function AllCenter() {
            $.ajax({
                type: "POST",
                url: "Superadmin_Dashboard.aspx/GetAllCenter",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var jsodatan = JSON.parse(response.d);
                    $("#lbltotCenter").html(jsodatan.Table1[0].TS);
                }
            });
        }

    </script>
</asp:Content>
