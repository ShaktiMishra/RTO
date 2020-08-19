<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="QMgmtRTO.WebLayer._404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <title>RTO: 404</title>
    <link rel="icon" type="image/ico" href="assets/images/favicon.png" />
    <style type="text/css">
        a:hover {
            text-decoration: underline !important;
        }
    </style>
    <link rel="stylesheet" href="assets/css/vendor/bootstrap.min.css" />
    <style type="text/css">
        /* Chart.js */
        @-webkit-keyframes chartjs-render-animation {
            from {
                opacity: 0.99;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes chartjs-render-animation {
            from {
                opacity: 0.99;
            }

            to {
                opacity: 1;
            }
        }

        .chartjs-render-monitor {
            -webkit-animation: chartjs-render-animation 0.001s;
            animation: chartjs-render-animation 0.001s;
        }
    </style>
</head>
<body style="background-color: #f2f8f9;">
    <!--content area start-->
    <div id="content" class="pmd-content errorpage d-flex justify-content-center align-items-center" style="margin-top: 12%;">
        <div class="text-center error-page">
            <img src="assets/images/404.png" alt="404" class="mb-4 img-fluid">
            <h1>Oops! Page not found</h1>
            <p class="mb-4">
                Sorry, but the page you are looking for is not found.
			Please make sure you have typed the right URL.
            </p>
            <a class="btn btn-primary btn-lg pmd-btn-raised pmd-ripple-effect" title="Back to home" href="Logininfo.aspx">Back to home</a>
        </div>
    </div>
    <script type="text/javascript" src="themes/js/bootstrap4-admin-compress.min.js"></script>
</body>
</html>
