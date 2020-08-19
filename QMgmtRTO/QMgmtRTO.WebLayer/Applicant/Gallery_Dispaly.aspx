<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gallery_Dispaly.aspx.cs" Inherits="Display_Gallery_Dispaly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="maValidation" content="bdf5b5569d28a382a610300e980a8451" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>RTO CUTTACK : Gallery Display</title>
    <link rel="icon" type="image/ico" href="../assets/images/favicon.png" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />


    <!-- vendor css files -->
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style1.css" />
</head>
<body class="home">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="home-top">
            <h2>RTO <span>Cuttack</span></h2>
            <h4 class="date">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h4>
            <p class="time">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </p>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="True">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" Enabled="True">
                </asp:Timer>
                <div class="home-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <div class="circle">
                                    <div class="circle-top">
                                        <h3>Learner  License(LL)</h3>
                                    </div>
                                    <div class="circle-green">
                                        <h4><i class="fa fa-caret-left"></i>
                                            <asp:Label ID="lllbltoken" runat="server">NA</asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-4 col-xs-12">
                                <div class="circle circle-small">
                                    <div class="circle-top">
                                        <h3>Token Number(LL)</h3>
                                    </div>
                                    <div class="circle-orange">
                                        <h4>
                                            <asp:Label ID="lllgbltoken" runat="server" Text="NA"></asp:Label>
                                            <i class="fa fa-caret-right"></i></h4>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <div class="circle circle-small">
                                    <div class="circle-top">
                                        <h3>Token Number(DL)</h3>
                                    </div>
                                    <div class="circle-orange">
                                        <h4>
                                            <asp:Label ID="dllbgltoken" runat="server" Text="NA"></asp:Label>
                                            <i class="fa fa-caret-right"></i></h4>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <div class="circle circle-small">
                                    <div class="circle-top">
                                        <h3>DRIVING LICENCE(DL)</h3>
                                    </div>
                                    <div class="circle-orange">
                                        <h4>
                                            <asp:Label ID="dllbltoken" runat="server">NA</asp:Label>
                                            <i class="fa fa-caret-right"></i></h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="home-footer">
            <p class="ft-ctn">@ Welcome to RTO Cuttack</p>
        </div>
    </form>
</body>
</html>
