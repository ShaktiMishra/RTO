<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QR_Scan.aspx.cs" Inherits="QMgmtRTO.WebLayer.Display.QR_Scan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>QR SCAN</title>
        <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="icon" type="image/ico" href="../assets/images/favicon.png" />  
    <script language="javascript" type="text/javascript">
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () {
            null
        };

    </script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="assets/js/jquery-3.3.1.min.js"></script>
    <style>
        .Bgpic {
            background-image: url(../assets/images/bg.jpg);
            background-size: 100%;          
           
        }
        .box3d {
             box-shadow: 0 16px 28px 0 rgba(0,0,0,.22), 0 25px 55px 0 rgba(0,0,0,.21);
        }
    </style>
</head>
<body class="Bgpic">
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-md-12">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <asp:Image ID="rtologin" runat="server" ImageUrl="~/assets/images/favicon.png" Width="70%" Style="margin-left: 10%;" />
                    <br />
                    <br />
                    <div class="box3d">
                    <asp:TextBox ID="txtsearchqr" runat="server" CssClass="form-control input-lg" Placeholder="Enter Application Number ..." OnTextChanged="txtsearchqr_TextChanged" AutoPostBack="true"></asp:TextBox>

                    <br />
                    <div class="panel panel-info">
                        <div class="panel-heading">RTO Applicant Details</div>
                        <div class="panel-body">
                            <div runat="server" id="dvappldetails">
                                <p><strong>NAME :- </strong>
                                    <asp:Label ID="Lblapplname" runat="server"></asp:Label></p>
                                <p>
                                    <strong>APPLICATION NO. :- </strong>
                                    <asp:Label ID="lblapplno" runat="server"></asp:Label>
                                </p>
                                <p><strong>TOKEN NO. :- </strong><asp:Label ID="lbltokenno" runat="server" ></asp:Label></p>
                                <p><strong>SERVICE NAME :- </strong><asp:Label ID="lblsrvcname" runat="server"></asp:Label></p>
                            </div>


                        </div>
                    </div>
                        </div>
                </div>
                <div class="col-md-4"></div>
            </div>
        </div>
    </form>
</body>
</html>
