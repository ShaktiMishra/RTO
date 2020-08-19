<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceDisplay.aspx.cs" Inherits="QMgmtRTO.WebLayer.Display.ServiceDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <title>RTO</title>
    <!-- Favicon-->
    <link rel="icon" href="favicon.ico" type="image/x-icon">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css">
    <!-- <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css"> -->

    <!-- Bootstrap Core Css -->
    <link href="ServiceCSS/plugins/bootstrap/css/bootstrap.css" rel="stylesheet">
   
    <!-- Waves Effect Css -->
    <link href="ServiceCSS/plugins/node-waves/waves.css" rel="stylesheet" />

    <!-- Animation Css -->
    <link href="ServiceCSS/plugins/animate-css/animate.css" rel="stylesheet" />

    <!-- Custom Css -->
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/token.css" rel="stylesheet">
    <link href="ServiceCSS/css/style.css" rel="stylesheet" />
   
    <link href="ServiceCSS/token.css" rel="stylesheet" />
    
</head>
<body>
	<div class="tokendisplay">
		<div class="container-fluid">
			<!-- <div class="row full-page-nav">
				<img src="images/logo.jpg" class="logo-img">
				<div class="notification-box">
					<marquee> Your notification here</marquee>
				</div>
			</div> -->
		    <div class="row">
		    	<div class="col-md-10">
		    		<div class="token-box-side">
		    			<div class="all-token-cont">
			    			 <asp:Literal ID="token" runat="server"></asp:Literal>
			    		</div>
		    		</div>
		    		
		    	</div>
		    	
		        <!-- <div class="card">
		            <div class="body">
		                
		            </div>
		        </div> -->
		    </div>
		    <!-- <div class="row full-page-foot">
				<div class="copyright">
	                © 2017 <a href="javascript:void(0);">WebTown Solution Pvt. Ltd</a>.
	            </div>
			</div> -->
		</div>
	</div>
    <!-- Jquery Core Js -->
    <script src="ServiceCSS/plugins/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core Js -->
    <script src="ServiceCSS/plugins/bootstrap/js/bootstrap.js"></script>

    <!-- Waves Effect Plugin Js -->
    <script src="ServiceCSS/plugins/node-waves/waves.js"></script>

    <!-- Custom Js -->
    <script src="../js/admin.js"></script>

    <script>
        $(window).on("load", readyFn);
        $(window).on("resize", readyFn);

        function readyFn() {
            win_ht = $(window).height();
            win_wd = $('.token-box-side').width();
            console.log($(window).height());
            $('.all-token-cont').height(win_ht - 10);
            $('.doc-schedule-box').height(win_ht - 10);
            $('#schedule-sec-marq').height(win_ht - 70);
            // $('.all-token-cont').width(win_wd-30);
            $('.flex-item').height((win_ht - 40) / 3);
        }
    </script>
    
</body>
</html>
