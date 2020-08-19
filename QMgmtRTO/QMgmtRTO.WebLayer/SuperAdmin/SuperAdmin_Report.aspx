<%@ Page Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.master" AutoEventWireup="true" CodeBehind="SuperAdmin_Report.aspx.cs" Inherits="QMgmtRTO.WebLayer.SuperAdmin.SuperAdminReports" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                    <form id="RegisterValidation" action="#" method="">
                        <div class="card ">
                            <div class="card-header ">
                                <h4 class="card-title">CENTRE-WISE</h4>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Select Centre</label>
                                                <br/>
                                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
<%--                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Service Short Name</label>
                                                <input id="txtshtservicename" type="text" class="form-control" required="required" autocomplete="off" onkeypress="return IsSpace(event)" maxlength="5" />
                                                <input type="hidden" id="hdnshtservicename" value="0" />

                                            </div>
                                        </div>
                                    </div>--%>

                                </form>
                            </div>
                            <%--<div class="card-footer text-center">
                                <input id="btnservice" type="button" value="Add Service" class="btn btn-primary" />
                                <button id="btnReset" class="btn btn-danger" onclick="window.location.reload()" type="reset">Reset</button>
                                <input type="hidden" id="Bid" value="0" />
                                <div class="clearfix"></div>
                            </div>--%>
                        </div>
                    </form>
                </div>
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header card-header-primary">
                            <h4 class="card-title ">CENTRE REPORT</h4>
                        </div>
                        <div class="card-body">
                            
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>


                            <%--<div class="table-responsive">
                                <table class="table" id="ServiceTab">
                                    <thead class="text-primary">
                                        <tr>
                                            <th>Sl No.</th>
                                            <th>Service Name</th>
                                            <th>Service Short Name</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>
