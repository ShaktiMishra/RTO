<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="SuperAdmin_ProfileDetails.aspx.cs" Inherits="QMgmtRTO.WebLayer.SuperAdmin.SuperAdmin_ProfileDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="card ">
                        <div class="card-header">
                            <h4 class="card-title">Edit Profile</h4>
                        </div>
                        <div class="card-body ">
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group has-label">
                                        <label>Name<span class="star">*</span></label>
                                        <asp:TextBox ID="txtname" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>
                                        <label id="errorname" style="color: red;"></label>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group has-label">
                                        <label>Email Address<star class="star">*</star></label>
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" MaxLength="40"></asp:TextBox>

                                        <label id="erroremail" style="color: red"></label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group has-label">
                                        <label>
                                            Mobile Number
                                                   
                                    <star class="star">*</star>
                                        </label>
                                        <asp:TextBox ID="txtphone" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <label id="errorphone" style="color: red;"></label>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group has-label">
                                        <label>
                                            Address
                                                   
                                    <star class="star">*</star>
                                        </label>
                                        <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        <label id="erroraddress" style="color: red;"></label>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="card-footer text-right">
                            <asp:Button ID="btnupdate" CssClass="btn btn-info" runat="server" Text="Update Profile" OnClick="btnupdate_Click" />
                             <%--<button id="btnReset" class="btn btn-danger" onclick="window.location.reload()" type="reset">Reset</button>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../assets/js/vendor/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript">

            $('#txtname').keyup(function () {
                $('#errorname').hide();
            });
            $('#txtemail').keyup(function () {
                $('#erroremail').hide();
            });
            $('#txtaddress').keyup(function () {
                $('#erroraddress').hide();
            });
            $('#txtphone').keyup(function () {
                $('#errorphone').hide();
            });
        $("#ContentPlaceHolder1_btnupdate").click(function () {
            if ($("#ContentPlaceHolder1_txtname").val() == "") {
                $('#errorname').show();
                $("#errorname").text("This field is required.");
                $("#ContentPlaceHolder1_txtname").focus();
                return false;
            }
            if ($("#ContentPlaceHolder1_txtemail").val() == "") {
                $('#erroremail').show();
                $("#erroremail").text("This field is required.");
                $("#ContentPlaceHolder1_txtemail").focus();
                return false;
            }
            var email = $("#ContentPlaceHolder1_txtemail").val();
            if (IsEmail(email) == false) {
                $('#erroremail').show();
                $("#erroremail").text("Please enter a valid email address");
                $("#ContentPlaceHolder1_txtemail").focus();
                $("#ContentPlaceHolder1_txtemail").val('');
                return false;
            }

            function IsEmail(email) {
                var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!regex.test(email)) {
                    return false;
                } else {
                    return true;
                }
            }
            if ($("#ContentPlaceHolder1_txtphone").val() == "") {
                $('#errorphone').show();
                $("#errorphone").text("This field is required.");
                $("#ContentPlaceHolder1_txtphone").focus();
                return false;
            }

            if (!$('#ContentPlaceHolder1_txtphone').val().match('[0-9]{10}')) {
                $('#errorphone').show();
                $("#errorphone").text("Please Enter a Valid Mobile Number (10 digits)");
                $("#ContentPlaceHolder1_txtphone").focus();
                return false;
            }
            if ($("#ContentPlaceHolder1_txtaddress").val() == "") {
                $('#erroraddress').show();
                $("#erroraddress").text("This field is required.");
                $("#ContentPlaceHolder1_txtaddress").focus();
                return false;
            }
        });
    </script>
</asp:Content>
