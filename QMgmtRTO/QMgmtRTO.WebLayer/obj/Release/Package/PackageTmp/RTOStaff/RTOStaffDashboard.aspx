<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RTOStaffDashboard.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOStaff.RTOStaffDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RTO | Dashboard</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js'></script>
    <link href="../assets/css/style.css" rel="stylesheet" />
    <style>
        .s {
            position: relative;
            overflow: scroll;
            height: 800px;
            text-align: center !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="headerSection">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="logoarea left">
                                <div class="logo">RTO Logo</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="header-right-content right">
                                <p class="log-out-btn"><a href="../LoginInfo.aspx"><i class='fas fa-sign-out-alt'></i></a></p>
                                <div class="account-holder">
                                    <img src="../assets/images/dummy-img.jpg" />
                                    <div class="account-holder-content">
                                        <h2>Name:
                                            <asp:Label ID="lblstaffname" runat="server" Text=""></asp:Label></h2>
                                        <p>
                                            <asp:Label ID="lbldate" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="body-content">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="bodyLeftbox">
                                <div class="tokenArea">
                                    <div class="tokenBox">
                                        <h3>Current Serving Token Number</h3>
                                        <h1>
                                            <asp:Label runat="server" ID="lblcurrenttokenserving"></asp:Label></h1>
                                        <%--<p>Serving Time 00:00:16</p>--%>
                                    </div>
                                </div>
                                <div class="statisticBox">
                                    <h2>Serving Statistics</h2>
                                    <div class="row">
                                        <div class="col left">
                                            <div class="statusBox">
                                                <h3>Total Served Token</h3>
                                                <p>
                                                    <asp:Label runat="server" ID="lbltotraltokenserved"></asp:Label>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col right">
                                            <div class="statusBox">
                                                <h3>Performance Status</h3>
                                                <p>Excellent</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="statusBar greenBar"></div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="bodyRightbox">
                                <div class="remove-margin row">
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Button ID="btnnext" runat="server" CssClass="mid" Text="Next" OnClick="btnnext_Click" />
                                            </div>
                                            <div class="col-sm-6">
                                                <asp:Button ID="Button2" runat="server" CssClass="mid" Text="Recall" />
                                            </div>
                                            <div class="col-sm-6">
                                                <asp:Button ID="Button3" runat="server" CssClass="mid" Text="Forward" />
                                                <div class="midBlubtn">
                                                    <button>Forward</button>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="midBlubtn">
                                                    <button>Not Appear Next</button>
                                                </div>
                                            </div>
                                            <div class="col-sm-12">
                                                <div class="midBlubtn">
                                                    <button>Continue Sevice</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="demandBoxArea s">
                                            <asp:Literal runat="server" ID="litservices"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
