<%@ Page Title="" Language="C#" MasterPageFile="~/RTOAdmin/RTOAdmin.Master" AutoEventWireup="true" CodeBehind="CounterMaster.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOAdmin.CounterMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="Checkboxcss/jquery-1.8.0.min.js"></script>
    <script src="Checkboxcss/jquery-ui-1.8.23.custom.min.js"></script>
    <script src="Checkboxcss/jquery.ui.checkList.js"></script>
    <link href="Checkboxcss/checkList.css" rel="stylesheet" />
    <link href="Checkboxcss/jquery-ui-1.8.23.custom.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page page-forms-common">
        <div class="pageheader">
            <h2>Counter Master <span>// You can add number of counters here............</span></h2>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <a href="Dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="#">Master Entry</a>
                    </li>
                    <li>
                        <a href="CounterDetails.aspx">Counter Master</a>
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
                        <h1 class="custom-font"><strong>Add </strong>Counter</h1>
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

                        <form class="form-inline" role="form">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="form-group">
                                    <label class="sr-only" for="exampleInputEmail2">Counter Name</label>
                                    <%--<input id="txtcountername" type="text" placeholder="Counter Name" autocomplete="off" class="form-control" />--%>
                                    <asp:TextBox ID="txtcountername" runat="server" placeholder="Counter Name" autocomplete="off" class="form-control"></asp:TextBox>
                                    <asp:HiddenField  ID="hidden1" runat="server"/>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="form-group">
                                    <label class="sr-only" for="exampleInputPassword2">Password</label>
                                    <%-- <input id="txtdevicecode" type="text" class="form-control" placeholder="Device Code" autocomplete="off" />--%>
                                    <asp:TextBox ID="txtdevicecode" runat="server" class="form-control" placeholder="Device Code" autocomplete="off"></asp:TextBox>
                                     <asp:HiddenField  ID="hidden2" runat="server"/>
                                </div>
                            </div>
                            <%--  <button id="btnsubmit" class="btn btn-success" type="submit">Submit</button>--%>
                            <asp:Button ID="btnsubmit" class="btn btn-success" Text="Submit" runat="server" OnClick="btnsubmit_Click" />
                            <asp:Button  ID="btnupdate" class="btn btn-success" Text="Update" runat="server" OnClick="btnupdate_Click"/>
                            <%-- <button id="btnReset" class="btn btn-danger" onclick="window.location.reload()" type="reset">Reset</button>
                            <input type="hidden" id="Bid" value="0" />--%>
                            <asp:Button ID="btnReset" class="btn btn-danger" Text="Reset" runat="server" OnClick="btnReset_Click" />
                        </form>

                    </div>
                    <!-- /tile body -->
                </section>
                <!-- /tile -->
                <section class="tile">
                    <!-- tile header -->
                    <div class="tile-header dvd dvd-btm">
                        <h1 class="custom-font"><strong>Counter</strong> Table</h1>
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
                            <table class="table table-custom" id="counterTab">
                                <thead>
                                    <tr>
                                        <th>Sl No</th>
                                        <th>Counter Name</th>
                                        <th>Counter Code</th>
                                        <th>Device Code</th>
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
            getcounterdata();
            $('#ContentPlaceHolder1_btnupdate').hide();
            var someSession = '<%= Session["CenterCode"].ToString() %>';
        });


        $('#ContentPlaceHolder1_btnsubmit').click(function () {
            if ($('#ContentPlaceHolder1_txtcountername').val().trim() == "") {
                alert("Counter Name Can't Be Blank")
                $('#ContentPlaceHolder1_txtcountername').focus();
                return false;
            }
            if ($('#ContentPlaceHolder1_txtdevicecode').val().trim() == "") {
                alert("Device Code Can't Be Blank")
                $('#ContentPlaceHolder1_txtdevicecode').focus();
                return false;
            }
        });

        function getcounterdata() {
            $.ajax({
                type: "POST",
                url: "CounterMaster.aspx/getAllCounterDetails",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var result = $.parseJSON(data.d);
                    var len = result.length;
                    var txt = "";
                    if (len > 0) {
                        var datatableVariable = $('#counterTab').DataTable({
                            "bProcessing": true,
                            "destroy": true,
                            "aaData": JSON.parse(data.d),
                            "columnDefs": [{
                                "searchable": true,
                                "orderable": false,
                                "targets": 0
                            }],
                            "order": [[1, 'asc']],
                            "columns": [{ "data": "CounterID_INT" }, { "data": "CounterName_VCR" }, { "data": "CounterCode_VCR" }, { "data": "DeviceCode_VCR" },
                               {
                                   "mRender": function (data, type, row) {
                                       if (row.status == "1") {
                                           return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10 CE" id=' + row.CounterID_INT + '>Edit</a><a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.CounterID_INT + '>Remove</a>'
                                       }
                                       else {
                                           return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10 CE" id=' + row.CounterID_INT + '>Edit</a><a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.CounterID_INT + '>Remove</a>'
                                       }
                                   }
                               }
                            ]
                        });
                    }
                }
            });
        }


        $(document).on("click", ".CE", function () {
            var id = $(this).attr("id");
           // alert(id);
            var x = $(this).closest('tr').find('td :eq(0)').text();
            var p = $(this).closest('tr').find('td :eq(1)').text();
            var q = $(this).closest('tr').find('td :eq(2)').text();
            var r = $(this).closest('tr').find('td :eq(3)').text();
            $("#ContentPlaceHolder1_txtcountername").val(p);
            $("#ContentPlaceHolder1_txtdevicecode").val(r);
            $("#ContentPlaceHolder1_hidden1").val(x);
            $("#ContentPlaceHolder1_hidden2").val(q);
            $('#ContentPlaceHolder1_btnupdate').show(); 
            $('#ContentPlaceHolder1_btnsubmit').hide();
        });

        $(document).on("click", ".CD", function () {
            var id = $(this).attr("id");
            //alert(id);
            $.ajax({
                type: "POST",
                url: "CounterMaster.aspx/deletetabledata",
                data: '{id: ' + JSON.stringify(id) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var jsodatan = JSON.parse(response.d);
                    if (jsodatan == "success") {
                        alert('Counter Details Deleted sucessfully');
                        window.location = "CounterMaster.aspx";
                    }
                    else {
                        alert('Counter Details Deleted Failed');
                        window.location = "CounterMaster.aspx";
                    }
                }

            });
        });
    </script>
</asp:Content>
