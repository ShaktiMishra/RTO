<%@ Page Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.master" AutoEventWireup="true" CodeBehind="SuperAdmin_AddCentre.aspx.cs" Inherits="QMgmtRTO.WebLayer.SuperAdmin.SuperAdmin_AddCentre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server" >
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                    <form id="RegisterValidation" action="#" method="">
                        <div class="card ">
                            <div class="card-header ">
                                <h4 class="card-title">Center Register Form</h4>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Center Code</label>
                                                <asp:TextBox ID="txtcentercode" runat="server" class="form-control" required="true" autocomplete="off" onkeypress="return AvoidSpace(event)"></asp:TextBox>
                                                <asp:HiddenField runat="server" ID="Hdnslno" Value="0"/>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Center Name</label>
                                                <asp:TextBox ID="txtcenter" runat="server" class="form-control" required="true" autocomplete="off" onkeypress="return AvoidSpace(event)"></asp:TextBox>
<%--                                                <asp:HiddenField runat="server" ID="Hdncenter" Value="0" />--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Email</label>
                                                <asp:TextBox ID="txtemail" TextMode="Email" runat="server" class="form-control" required="true" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Mobile No</label>
                                                <asp:TextBox ID="txtmobile" runat="server" class="form-control" required="true" autocomplete="off" onkeypress="return isNumberKey(event)" MaxLength="10" minlength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Address</label>
                                                <asp:TextBox ID="txtaddress" runat="server" class="form-control" required="true" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">PIN Code</label>
                                                <asp:TextBox ID="txtpostal" runat="server" class="form-control" required="true" autocomplete="off" MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </form>
                            </div>
                            <div class="card-footer text-right">
                                <asp:Button ID="btncreatecenter" runat="server" Text="Create Center" class="btn btn-primary pull-right" OnClick="btncreatecenter_Click" />
                                <input type="hidden" id="Bid" value="0" />
                                <asp:HiddenField ID="hdnbtn" runat="server" Value="0" />
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </form>
                </div>
                <div class="col-md-8">
                       <div class="card">
                            <div class="card-header card-header-primary">
                                <h4 class="card-title ">Center Table</h4>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table class="table" id="centerTab">
                                        <thead class="text-primary">
                                            <tr>
                                                <th>Sl No.</th>
                                                <th>Center Code</th>
                                                <th>Center Name</th>
                                                <th>Email Id</th>
                                                <th>Mobile No.</th>
                                                <th>Address</th>
                                                <th>PIN</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
        <script src="../assets/js/vendor/jquery/jquery-1.11.2.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                getcenterdata();
            });

            function AvoidSpace(event) {
                var k = event ? event.which : window.event.keyCode;
                if (k == 32) return false;
            }

            function isNumberKey(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    //alert("Please Input integer Value Only!");
                    return false;
                }
                return true;
            }

            //var email = ContentPlaceHolder1_txtemail.val();
            //if (email.value != "") {
            //    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

            //    if (!filter.test(email.value)) {
            //        alert('Please provide a valid email address');
            //        email.focus();
            //    }

            //}

            function getcenterdata() {
                $.ajax({
                    type: "POST",
                    url: "SuperAdmin_AddCentre.aspx/getAllCenterDetails",
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = $.parseJSON(data.d);
                        var len = result.length;
                        var txt = "";
                        if (len > 0) {
                            var datatableVariable = $('#centerTab').DataTable({
                                "bProcessing": true,
                                "destroy": true,
                                "aaData": JSON.parse(data.d),
                                "columnDefs": [{
                                    "searchable": true,
                                    "orderable": false,
                                    "targets": 0
                                }],
                                "order": [[0, 'asc']],
                                //"columns": [{ "data": "Cid" }, { "data": "CenterName" }, { "data": "Email" }, { "data": "Address" }, { "data": "AdminMobNumber" }, { "data": "Pin" },
                                //Modified - SPM 14Jul2020
                                //"columns": [{ "data": "Cid" },{ "data": "CenterCode" }, { "data": "CenterName" }, { "data": "Email" }, { "data": "Address" }, { "data": "AdminMobNumber" }, { "data": "MsgTime" },
                                "columns": [{ "data": "col0" }, { "data": "col1" }, { "data": "col3" }, { "data": "col4" }, { "data": "col5" }, { "data": "col6" }, { "data": "col7" }, 
                                   {
                                       "mRender": function (data, type, row) {
                                           if (row.col10 == "1") {
                                               return '<a class="text-success edit CE" id=' + row.col0 + '>Edit</a> <a class="text-danger delete CD" id=' + row.col0 + '>Remove</a>'
                                           }
                                           else {
                                               return '<a class="text-success edit CE" id=' + row.col0 + '>Edit</a> <a class="text-danger delete CD" id=' + row.col0 + '>Remove</a>'
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
                //alert(id);
                $.ajax({
                    type: "POST",
                    //url: "Add_Center.aspx/updatecenterdata", //SPM 15Jul2020
                    url: "SuperAdmin_AddCentre.aspx/updatecenterdata",
                    data: '{id: ' + JSON.stringify(id) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        //$("#ContentPlaceHolder1_Hdncenter").val(jsodatan.Table1[0].CenterCode);2
                        //$("#ContentPlaceHolder1_txtcenter").val(jsodatan.Table1[0].CenterName);3
                        //$("#ContentPlaceHolder1_txtemail").val(jsodatan.Table1[0].Email);4
                        //$("#ContentPlaceHolder1_txtaddress").val(jsodatan.Table1[0].Address);5
                        //$("#ContentPlaceHolder1_txtmobile").val(jsodatan.Table1[0].AdminMobNumber);7
                        //$("#ContentPlaceHolder1_txtpostal").val(jsodatan.Table1[0].Pin);12     

                        $("#ContentPlaceHolder1_Hdnslno").val(jsodatan.Table1[0].col0);
                        $("#ContentPlaceHolder1_txtcentercode").val(jsodatan.Table1[0].col1);
                        $("#ContentPlaceHolder1_txtcenter").val(jsodatan.Table1[0].col3);
                        $("#ContentPlaceHolder1_txtemail").val(jsodatan.Table1[0].col4);
                        $("#ContentPlaceHolder1_txtmobile").val(jsodatan.Table1[0].col5);
                        $("#ContentPlaceHolder1_txtaddress").val(jsodatan.Table1[0].col6);                        
                        $("#ContentPlaceHolder1_txtpostal").val(jsodatan.Table1[0].col7);                        

                        $('#Bid').val(id);
                        $("#ContentPlaceHolder1_btncreatecenter").val('Update');
                        $("#ContentPlaceHolder1_hdnbtn").val(1);

                    }


                });
            });

            $(document).on("click", ".CD", function () {
                var id = $(this).attr("id");
                //alert(id);
                $.ajax({
                    type: "POST",
                    //url: "Add_Center.aspx/deltetabledata", //SPM 15Jul2020
                    url: "SuperAdmin_AddCentre.aspx/deltetabledata",
                    data: '{id: ' + JSON.stringify(id) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        if (jsodatan == "success") {
                            alert('Centre Details Deleted Successfully');
                            location.reload();
                            getcounterdata();                           

                        }
                        else {
                            alert('Centre Details Delete Failed');
                            location.reload();
                        }
                    }

                });
            });
        </script>
    </form>
</asp:Content>  