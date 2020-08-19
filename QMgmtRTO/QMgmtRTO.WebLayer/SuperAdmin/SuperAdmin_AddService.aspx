<%@ Page Language="C#"  MasterPageFile="~/SuperAdmin/SuperAdmin.master" AutoEventWireup="true" CodeBehind="SuperAdmin_AddService.aspx.cs" Inherits="QMgmtRTO.WebLayer.SuperAdmin.SuperAdmin_AddService" %>

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
                                <h4 class="card-title">Add Service</h4>
                            </div>
                            <div class="card-body">
                                <form>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Service Name</label>
                                                <input id="txtservicename" type="text" class="form-control" required="required" autocomplete="off" onchange="AllowSpace(this);" maxlength="40" />
                                                <input type="hidden" id="hdnservicename" value="0" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Service Short Name</label>
                                                <input id="txtshtservicename" type="text" class="form-control" required="required" autocomplete="off" onkeypress="return IsSpace(event)" maxlength="5" />
                                                <input type="hidden" id="hdnshtservicename" value="0" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Service Type</label>
                                                <select id="ddlserviceType" class="form-control">
                                                    <option value="0">Select Service Type</option>
                                                     <option value="ONLINE">ONLINE</option>
                                                     <option value="OFFLINE">OFFLINE</option>
                                                </select>

                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                            <div class="card-footer text-center">
                                <input id="btnservice" type="button" value="Add Service" class="btn btn-primary" />
                                <button id="btnReset" class="btn btn-danger" onclick="window.location.reload()" type="reset">Reset</button>
                                <input type="hidden" id="Bid" value="0" />
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </form>
                </div>
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header card-header-primary">
                            <h4 class="card-title ">Service Details</h4>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table" id="ServiceTab">
                                    <thead class="text-primary">
                                        <tr>
                                            <th>Sl No.</th>
                                            <th>Service Name</th>
                                            <th>Service Short Name</th>
                                            <th>Service Type</th>
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
                $('#txtservicename').focus();
                getservicedata();
            });
            $('#btnservice').click(function () {
                if ($('#txtservicename').val().trim() == "") {
                    alert("Service Name Can't Be Blank")
                    $('#txtservicename').focus();
                    return false;
                }
                if ($('#txtshtservicename').val().trim() == "") {
                    alert("Service Short Name Can't Be Blank")
                    $('#txtshtservicename').focus();
                    return false;
                }
                if ($('#ddlserviceType option:selected').val() == 0) {
                    alert("Select Service Type")
                    $('#ddlserviceType').focus();
                    return false;
                }

                var data = {};
                data.servicename = $("#txtservicename").val().trim();
                data.shtservicename = $("#txtshtservicename").val().trim();
                data.Type = $('#ddlserviceType option:selected').val();
                if ($('#btnservice').val() == "Add Service") {
                    data.btnvalue = 0;
                } else if ($('#btnservice').val() == "Update Service") {
                    data.btnvalue = 1;
                }
                data.Bid = $('#Bid').val();

                $.ajax({
                    type: "POST",
                    //url: "Add_Service.aspx/saveservicename", SPM20072020
                    url: "SuperAdmin_AddService.aspx/saveservicename",
                    data: '{data: ' + JSON.stringify(data) + '}', //cmtd SPM 20072020

                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        if (jsodatan == "success") {
                            alert('Service Details Saved Successfully');
                            //window.location = "Add_Service.aspx"; SPM20072020
                            window.location = "SuperAdmin_AddService.aspx";
                        } else if (jsodatan == "Usuccess") {
                            alert('Service Details Updated Successfully');
                            //window.location = "Add_Service.aspx"; SPM20072020
                            window.location = "SuperAdmin_AddService.aspx";
                        }
                        else {
                            //alert('Oops Some Problems !!');
                            alert('Service Name Already Exists !!');
                            $("#txtservicename").val('');
                        }
                        getservicedata();
                    }
                });
            });

            function getservicedata() {
                $.ajax({
                    type: "POST",
                    //url: "Add_Service.aspx/getAllService", SPM20072020
                    url: "SuperAdmin_AddService.aspx/getAllService",
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
                                //"columns": [{ "data": null }, { "data": "Service_Name" }, { "data": "Service_Short_Name" }, // cmtd SPM 20072020
                                "columns": [{ "data": "col0" }, { "data": "col1" }, { "data": "col2" }, { "data": "col3" },
                                   {
                                       "mRender": function (data, type, row) {
                                           //if (row.status == "1") { //Cmtd SPM-20072020
                                           if (row.col5 == "1") {
                                                //return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10 CE" id=' + row.Service_Id + '>Edit</a> <a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.Service_Id + '>Remove</a>'
                                               //cmtd above SPM20072020
                                               return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10 CE" id=' + row.col0 + '>Edit</a> <a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.col0 + '>Remove</a>'
                                           }
                                           else {
                                               //return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10 CE" id=' + row.Service_Id + '>Edit</a> <a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.Service_Id + '>Remove</a>'
                                               //cmtd above SPM20072020
                                               return '<a class="actions edit text-primary text-uppercase text-strong text-sm mr-10 CE" id=' + row.col0 + '>Edit</a> <a class="actions delete text-danger text-uppercase text-strong text-sm mr-10 CD" id=' + row.col0 + '>Remove</a>'
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
                    //url: "Add_Service.aspx/updatetbldata", SPM20072020
                    url: "SuperAdmin_AddService.aspx/updatetbldata",
                    data: '{id: ' + JSON.stringify(id) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        //$("#txtservicename").val(jsodatan.Table1[0].Service_Name);
                        //$("#txtshtservicename").val(jsodatan.Table1[0].Service_Short_Name);
                        //$("#hdnservicename").val(jsodatan.Table1[0].Service_Name);
                        //$("#hdnshtservicename").val(jsodatan.Table1[0].Service_Short_Name);
                        //cmtd above SPM 20072020


                        $("#txtservicename").val(jsodatan.Table1[0].col1);
                        $("#txtshtservicename").val(jsodatan.Table1[0].col2);
                        $("#hdnservicename").val(jsodatan.Table1[0].col1);
                        $("#hdnshtservicename").val(jsodatan.Table1[0].col2);
                        $('#ddlserviceType').val(jsodatan.Table1[0].col3);


                        $('#Bid').val(id);
                        $("#btnservice").val('Update Service');
                        $('#txtservicename').focus();
                        //alert(id);
                    }
                });
            });

            $(document).on("click", ".CD", function () {
                var id = $(this).attr("id");
                //alert(id);
                $.ajax({
                    type: "POST",
                    //url: "Add_Service.aspx/deltetabledata", SPM20072020
                    url: "SuperAdmin_AddService.aspx/deltetabledata",
                    data: '{id: ' + JSON.stringify(id) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var jsodatan = JSON.parse(response.d);
                        if (jsodatan == "success") {
                            alert('Service Details Deleted Successfully');
                            //window.location = "Add_Service.aspx"; SPM20072020
                            window.location = "SuperAdmin_AddService.aspx";
                        }
                        else {
                            alert('Service Details Deleted Failed');
                        }
                    }

                });
            });

            $('#txtservicename').change(function () {
                //var user = {}; //SPM20072020
                //user.servicename = $("#txtservicename").val(); //SPM20072020
                $.ajax({
                    type: "POST",
                    //url: "Add_Service.aspx/Checkservicename", SPM20072020
                    url: "SuperAdmin_AddService.aspx/Checkservicename",
                    data: '{user: ' + JSON.stringify(user) + '}', 
                    //data: '{user: ' + JSON.stringify($("#txtservicename").val()) + '}',//SPM20072020
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == '"1"') {
                        
                            alert("Service Name Already Exists.");
                            $("#txtservicename").val('');
                            if ($('#btnservice').val() == "Update Service") {
                                $("#txtservicename").val($("#hdnservicename").val());
                            }
                        }
                    }
                });
            });

            $('#txtshtservicename').change(function () {
                var user = {};
                user.serviceshortname = $("#txtshtservicename").val();
                $.ajax({
                    type: "POST",
                    //url: "Add_Service.aspx/Checkshortservicename", SPM20072020
                    url: "SuperAdmin_AddService.aspx/Checkshortservicename",
                    data: '{user: ' + JSON.stringify(user) + '}', 

                    //data: '{user: ' + JSON.stringify(user.serviceshortname) + '}',//SPM 20072020

                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == '"1"') {
                        
                            alert("Service Short Name Already Exists.");
                            $("#txtshtservicename").val('');
                            if ($('#btnservice').val() == "Update Service") {
                                $("#txtshtservicename").val($("#hdnshtservicename").val());
                            }
                        }
                    }
                });
            });
        </script>
    </form>
</asp:Content>
