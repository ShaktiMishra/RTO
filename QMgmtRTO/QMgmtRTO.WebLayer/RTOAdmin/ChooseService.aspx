<%@ Page Title="" Language="C#" MasterPageFile="~/RTOAdmin/RTOAdmin.Master" AutoEventWireup="true" CodeBehind="ChooseService.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOAdmin.ChooseService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    '
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script type="text/javascript">
        function SearchEmployees(txtSearch, cblEmployees) {
            if ($(txtSearch).val() != "") {
                var count = 0;
                $(ServiceCheckBoxList).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtSearch).val().toUpperCase()) > -1)
                            match = true;
                    });
                    if (match) {
                        $(this).show();
                        count++;
                    }
                    else { $(this).hide(); }
                });
                $('#spnCount').html((count) + ' match');
            }
            else {
                $(ServiceCheckBoxList).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
                $('#spnCount').html('');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page page-forms-common">
        <div class="pageheader">
            <h2>Choose Service</h2>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <a href="Dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="#">Master Entry</a>
                    </li>
                    <li>
                        <a href="ChooseService.aspx">Choose Service</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <section class="tile">
                    <!-- tile header -->
                    <div class="tile-header dvd dvd-btm">
                        <h1 class="custom-font"><strong>Select</strong> Services</h1>
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
                        <div class="table-bordered" style="padding: 10px;overflow-y: auto; overflow-x: hidden;height: 300px;" >
                            <div class="form-inline">
                                <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search..." Width="70%" onkeyup="SearchEmployees(this,'#ServiceCheckBoxList');"></asp:TextBox><span id="spnCount" style="color: red"></span>
                            </div>
                            <asp:CheckBox ID="ServiceCheckBoxListAll" Text="Select All Service" runat="server" OnCheckedChanged="ServiceCheckBoxListAll_CheckedChanged" AutoPostBack="true" />

                            <asp:CheckBoxList ID="ServiceCheckBoxList" runat="server" Width="100%" ClientIDMode="Static">
                            </asp:CheckBoxList>
                            <br />
                        </div>
                        <br />
                        <br />
                        <asp:Button ID="btnSubmit" CssClass="btn btn-success align-middle" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        <button id="btnReset" class="btn btn-danger" onclick="window.location.reload()" type="reset">Reset</button>
                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary" Text="Edit" OnClick="btnEdit_Click" />
                    </div>
                    <!-- /tile body -->

                    <!-- tile footer -->
                    <div class="tile-footer text-right bg-tr-black lter dvd dvd-top">
                    </div>
                    <!-- /tile footer -->

                </section>
            </div>
            <div class="col-md-8">
                <section class="tile">
                    <!-- tile header -->
                    <div class="tile-header dvd dvd-btm">
                        <h1 class="custom-font"><strong>Services</strong>Details</h1>
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
                        <div class="table-responsive">
                            <table class="table" id="ServiceTab">
                                <thead class="text-primary">
                                    <tr>
                                        <th>Sl No.</th>
                                        <th>Service Name</th>
                                        <th>Service Short Name</th>
                                        <th>Create Date</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <!-- /tile body -->

                    <!-- tile footer -->
                    <div class="tile-footer text-right bg-tr-black lter dvd dvd-top">
                    </div>
                    <!-- /tile footer -->

                </section>

            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            displayservicedata();
        });

        function displayservicedata() {
            $.ajax({
                type: "POST",
                url: "ChooseService.aspx/displayselectedService",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var result = $.parseJSON(data.d);
                    var len = result.length;
                    var txt = "";
                    if (len > 0) {
                        var datatableVariable = $('#ServiceTab').DataTable({
                            "bProcessing": true,
                            "destroy": true,
                            "aaData": JSON.parse(data.d),
                            "columnDefs": [{
                                "searchable": true,
                                "orderable": false,
                                "targets": 0
                            }],
                            "order": [[0, 'asc']],
                            "columns": [{ "data": null }, { "data": "ServiceName_VCR" }, { "data": "ServiceShortName_VCR" }, { "data": "ChooseServiceCreateDate_DAT" }
                            ]
                        });
                        datatableVariable.on('order.dt search.dt', function () {
                            datatableVariable.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                                cell.innerHTML = i + 1;

                            });

                        }).draw();
                    }
                }
            });
        }
    </script>
</asp:Content>

