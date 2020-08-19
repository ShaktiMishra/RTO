<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo_Room_Display.aspx.cs" Inherits="Display_Demo_Room_Display" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="text-align: center">
                <video id="video1" width="100%"  controls="controls" autoplay="autoplay" >                 
                </video>             
            </div>
        </div>
    </form>
    <%--<script src="assets/js/vendor/jquery/jquery-1.11.2.min.js"></script>--%>
    <script type="text/javascript">
        window.onload = function () {
            var myvid = document.getElementById('video1');
            // Get values for video from Files Property
            var myvids = <%=this.Files %>;
            var activeVideo = 0;
            // Set first video as src for video element as default src
            myvid.setAttribute("src", myvids[0]);
            myvid.addEventListener('ended', function (e) {
                // update the new active video index
                activeVideo = (++activeVideo) % myvids.length;
                // update the video source and play
                myvid.src = myvids[activeVideo];
                myvid.play();
            });
        }
    </script>
</body>
</html>
