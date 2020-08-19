<%@ Page Title="" Language="C#" MasterPageFile="~/RTOAdmin/RTOAdmin.Master" AutoEventWireup="true" CodeBehind="Assign.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOAdmin.Assign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <h2>Assign Master <span>// You can assign staff for Service and counters here............</span></h2>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <a href="Dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="#">Master Entry</a>
                    </li>
                    <li>
                        <a href="StaffAssign.aspx">Staff Assign Master</a>
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
                        <h1 class="custom-font"><strong>Assign </strong>Staff</h1>
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
                        <form id="Form1" class="form-inline">
                            <div class="row">
                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="sr-only" for="exampleInputEmail2">Select Staff Name</label>
                                        <asp:DropDownList ID="ddlstaffname" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="sr-only" for="exampleInputPassword2">Select Counter Name</label>
                                        <asp:DropDownList ID="ddlCounteName" runat="server" CssClass="form-control"></asp:DropDownList>

                                        <br />
                                        <asp:Button ID="btnsubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                                        <button id="btnReset" class="btn btn-danger" onclick="window.location.reload()" type="reset">Reset</button>
                                        <input type="hidden" id="Bid" value="0" />
                                    </div>
                                </div>

                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <div class="table-bordered" style="padding: 10px; overflow-y: auto; overflow-x: auto; height: 300px;">
                                            <div class="form-inline">
                                                <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search..." Width="70%" onkeyup="SearchEmployees(this,'#ServiceCheckBoxList');"></asp:TextBox><span id="spnCount" style="color: red"></span>
                                            </div>
                                            <asp:CheckBox ID="ServiceCheckBoxListAll" Text="Select All Service" runat="server" OnCheckedChanged="ServiceCheckBoxListAll_CheckedChanged" AutoPostBack="true" />

                                            <asp:CheckBoxList ID="ServiceCheckBoxList" runat="server" Width="100%" ClientIDMode="Static">
                                            </asp:CheckBoxList>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </form>
                    </div>
                    <!-- /tile body -->
                </section>
                <!-- /tile -->
                <section class="tile">
                    <!-- tile header -->
                    <div class="tile-header dvd dvd-btm">
                        <h1 class="custom-font"><strong>Staff Assign</strong> Table</h1>
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
                            <table class="table table-custom" id="staffTabAssign">
                                <thead>
                                    <tr>
                                        <th>Sl No</th>
                                        <th>Staff Name</th>
                                        <th>Counter Name</th>
                                        <th>Service Name</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                    <!-- /tile body -->
                </section>
            </div>
            <!-- /col -->
        </div>
        <!-- /row -->
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            displayAssigned();
        });
        $("#ContentPlaceHolder1_btnsubmit").click(function () {

            if ($('#ContentPlaceHolder1_ddlstaffname option:selected').val() == 0) {
                alert("Select A Staff Name")
                $('#ContentPlaceHolder1_ddlstaffname').focus();
                return false;
            }
            if ($('#ContentPlaceHolder1_ddlCounteName option:selected').val() == 0) {
                alert("Select counter Name")
                $('#ContentPlaceHolder1_ddlCounteName').focus();
                return false;
            }
        });

        function displayAssigned() {
            $.ajax({
                type: "POST",
                url: "Assign.aspx/displayAssigneddata",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var result = $.parseJSON(data.d);
                    var len = result.length;
                    var txt = "";
                    if (len > 0) {
                        var datatableVariable = $('#staffTabAssign').DataTable({
                            "bProcessing": true,
                            "destroy": true,
                            "aaData": JSON.parse(data.d),
                            "columnDefs": [{
                                "searchable": true,
                                "orderable": false,
                                "targets": 0
                            }],
                            "order": [[0, 'asc']],
                            "columns": [{ "data": null }, { "data": "StaffName_VCR" }, { "data": "CounterName_VCR" }, { "data": "ServiceName_VCR" },
                               {
                                   "mRender": function (data, type, row) {
                                       if (row.AssignActiveStatus_INT == "1") {
                                           return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10  CE" id=' + row.AssignID_INT + '>Edit</a><a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.AssignID_INT + '>Remove</a>'
                                       }
                                       else {
                                           return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10  CE" id=' + row.AssignID_INT + '>Edit</a><a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.AssignID_INT + '>Remove</a>'
                                       }
                                   }
                               }
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

         $(document).on("click", ".CE", function () {
            var id = $(this).attr("id");
            $.ajax({
                type: "POST",
                url: "Assign.aspx/updatetbldata",
                data: '{id: ' + JSON.stringify(id) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var jsodatan = JSON.parse(response.d);
                    $("#ContentPlaceHolder1_ddlstaffname").val(jsodatan.Table1[0].StaffID_INT);
                    $("#ContentPlaceHolder1_ddlCounteName").val(jsodatan.Table1[0].CounterID_INT);
                    $('[id *= ServiceCheckBoxList]').find('input[type="checkbox"]').each(function () { $(this).prop("checked", false); });
                    var targetValue = jsodatan.Table1[0].ServiceID_INT;
                    var items = $('#<% = ServiceCheckBoxList.ClientID %> input:checkbox');
                    for (var i = 0; i < items.length; i++) {
                        if (items[i].value == targetValue) {
                            items[i].checked = true;
                            break;
                        }
                    }

                    $("#ContentPlaceHolder1_btnsubmit").val('Update');
                }
            });
        });

        $(document).on("click", ".CD", function () {
            var id = $(this).attr("id");
            //alert(id);
            $.ajax({
                type: "POST",
                url: "Assign.aspx/deletetabledata",
                data: '{id: ' + JSON.stringify(id) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var jsodatan = JSON.parse(response.d);
                    if (jsodatan == "success") {
                        alert('Assign Details Deleted successfully');
                        window.location = "Assign.aspx";
                    }
                    else {
                        alert('Assign Details Deleted Failed');
                        window.location = "Assign.aspx";
                    }
                }

            });
        });
    </script>
</asp:Content>
