<%@ Page Title="" Language="C#" MasterPageFile="~/RTOAdmin/RTOAdmin.Master" AutoEventWireup="true" CodeBehind="StaffMaster.aspx.cs" Inherits="QMgmtRTO.WebLayer.RTOAdmin.StaffMaster" %>
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
            <h2>Staff Master <span>// You can add number of services here............</span></h2>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <a href="Dashboard.aspx"><i class="fa fa-dashboard"></i>Dashboard</a>
                    </li>
                    <li>
                        <a href="#">Master Entry</a>
                    </li>
                    <li>
                        <a href="StaffMaster.aspx">Staff Master</a>
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
                        <h1 class="custom-font"><strong>Add </strong>Staff</h1>
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
                            <div class="row">
                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="sr-only" for="exampleInputEmail2">Staff Name</label>
                                       <%-- <input id="txtStaffname" type="text" placeholder="Staff Name" autocomplete="off" maxlength="30" class="form-control" />--%>
                                        <asp:TextBox id="txtStaffname" runat="server"  placeholder="Staff Name" autocomplete="off" maxlength="30" class="form-control" ></asp:TextBox>
                                        <asp:HiddenField  ID="hidden1" runat="server"/>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <div class="form-group" style="text-align: center">
                                        <label class="sr-only" for="exampleInputPassword2">Mobile No.</label>
                                       <%-- <input id="txtMobileNo" type="text" placeholder="Staff Mobile No" autocomplete="off" onkeypress="return isNumberKey(event)" maxlength="10" class="form-control" />--%>
                                      <asp:TextBox id="txtMobileNo" runat="server" placeholder="Staff Mobile No" autocomplete="off" onkeypress="return isNumberKey(event)" maxlength="10" class="form-control"></asp:TextBox>
                                        <asp:HiddenField  ID="hidden2" runat="server"/>
                                       <%-- <input type="hidden" id="hdnMobileNo" value="0" /><br />--%>
                                        <br />
                                        <asp:Button id="btnsubmit" class="btn btn-success" runat="server" Text="Submit"  OnClick="btnsubmit_Click"/>
                                         <asp:Button  ID="btnupdate" class="btn btn-success" Text="Update" runat="server" OnClick="btnupdate_Click"/>
                                       <%-- <button id="btnsubmit" class="btn btn-success" type="submit">Submit</button>
                                        <button id="btnReset" class="btn btn-danger" onclick="window.location.reload()" type="reset">Reset</button>
                                        <input type="hidden" id="Bid" value="0" />--%>
                                        <asp:Button  id="btnReset" class="btn btn-danger" Text="Reset" OnClick="btnReset_Click" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-12">
                                    <div class="form-group">
                                        <label class="sr-only" for="exampleInputPassword2">Email</label>
                                        <%--<input id="txtemail" type="email" placeholder="Email" onkeypress="return IsSpace(event)" autocomplete="off" maxlength="30" class="form-control" />
                                        <input type="hidden" id="hdnemail" value="0" />--%>
                                        <asp:TextBox id="txtemail" runat="server" placeholder="Email" onkeypress="return IsSpace(event)" autocomplete="off" maxlength="30" class="form-control" ></asp:TextBox>
                                        <asp:HiddenField  ID="hidden3" runat="server"/>
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
                        <h1 class="custom-font"><strong>Staff</strong> Table</h1>
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
                            <table class="table table-custom" id="staffTab">
                                <thead>
                                    <tr>
                                        <th>Sl No</th>
                                        <th>Name</th>
                                        <th>Mobile</th>
                                        <th>Email</th>
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
            getstaffdata();
            $('#ContentPlaceHolder1_btnupdate').hide();
        });
        $('#ContentPlaceHolder1_btnsubmit').click(function () {
            if ($('#ContentPlaceHolder1_txtStaffname').val() == "") {
                alert("Staff Name Can't Be Blank");
                $('#ContentPlaceHolder1_txtStaffname').val('');
                $('#ContentPlaceHolder1_txtStaffname').focus();
                return false;
            }
            if ($('#ContentPlaceHolder1_txtMobileNo').val() == "") {
                alert("Staff Mobile No. Can't Be Blank")
                $('#ContentPlaceHolder1_txtMobileNo').focus();
                return false;
            }
            if (!$('#ContentPlaceHolder1_txtMobileNo').val().match('[0-9]{10}')) {
                alert("Please Enter a Valid Mobile Number(10 digits)");
                $("#ContentPlaceHolder1_txtMobileNo").focus();
                return false;
            }
            if ($('#ContentPlaceHolder1_txtemail').val() == "") {
                alert("Staff Email Can't Be Blank")
                $('#ContentPlaceHolder1_txtemail').focus();
                return false;
            }
            var email = $("#ContentPlaceHolder1_txtemail").val();
            if (IsEmail(email) == false) {
                alert('This email is not valid');
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
         });
        function getstaffdata() {
            $.ajax({
                type: "POST",
                url: "StaffMaster.aspx/getAllStaffDetails",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var result = $.parseJSON(data.d);
                    var len = result.length;
                    var txt = "";
                    if (len > 0) {
                        var datatableVariable = $('#staffTab').DataTable({
                            "bProcessing": true,
                            "destroy": true,
                            "aaData": JSON.parse(data.d),
                            "columnDefs": [{
                                "searchable": true,
                                "orderable": false,
                                "targets": 0
                            }],
                            "order": [[1, 'asc']],
                            "columns": [{ "data": "StaffID_INT" }, { "data": "StaffName_VCR" }, { "data": "StaffMobileNo_VCR" }, { "data": "StaffEmailID_VCR" },
                               {
                                   "mRender": function (data, type, row) {
                                       if (row.status == "1") {
                                           return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10 CE" id=' + row.StaffID_INT + '>Edit</a><a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.StaffID_INT + '>Remove</a>'
                                       }
                                       else {
                                           return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10 CE" id=' + row.StaffID_INT + '>Edit</a><a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.StaffID_INT + '>Remove</a>'
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

            $("#ContentPlaceHolder1_txtStaffname").val(p);
            $("#ContentPlaceHolder1_txtMobileNo").val(q);
            $("#ContentPlaceHolder1_txtemail").val(r);

            $("#ContentPlaceHolder1_hidden1").val(x);
            $("#ContentPlaceHolder1_hidden2").val(q);
            $("#ContentPlaceHolder1_hidden3").val(r);
            $('#ContentPlaceHolder1_btnupdate').show();
            $('#ContentPlaceHolder1_btnsubmit').hide();
        });

        $(document).on("click", ".CD", function () {
            var id = $(this).attr("id");
            $.ajax({
                type: "POST",
                url: "StaffMaster.aspx/deletetabledata",
                data: '{id: ' + JSON.stringify(id) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var jsodatan = JSON.parse(response.d);
                    if (jsodatan == "success") {
                        alert('Staff Details Deleted sucessfully');
                        window.location = "StaffMaster.aspx";
                    }
                    else {
                        alert('Staff Details Deleted Failed');
                        window.location = "StaffMaster.aspx";
                    }
                }

            });
        });
    </script>
</asp:Content>
