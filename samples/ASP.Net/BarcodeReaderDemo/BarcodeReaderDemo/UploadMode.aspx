<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadMode.aspx.cs" Inherits="BarcodeWeb.UploadMode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
     <head runat="server">
     <title></title>
     <link rel="stylesheet" href="Css/basis-bs.css"/>
     <link type="text/css" rel="Stylesheet" href="Css/style.css" />
     <link rel="stylesheet" type="text/css" href="Css/bootstrap.css"/>
     
     <script type="text/javascript" language="javascript" src="Scripts/kissy-min.js"></script>
     <script type="text/javascript" language="javascript" src="Scripts/OnlineDemoAjax.js"></script>
     <script type="text/javascript" language="javascript" src="Scripts/DemoCommon.js"></script>
     <script type="text/javascript" language="javascript" src="Scripts/jquery-1.11.2.js"></script>
     <script type="text/javascript" language="javascript" src="Scripts/bootstrap.min.js"></script>
     <!--[if lt IE 9]>
      <script type="text/javascript" src="Scripts/html5shiv.js"></script>
      <script type="text/javascript" src="Scripts/respond.js"></script>
     <![endif]-->
     <script type="text/javascript">
     function CheckLocalPath() {
            var objImgURL = document.getElementById("<%=upLoadFile.ClientID%>");
            return CheckLocalPathInner(objImgURL);
        }

        function CheckFileExist() {
            var objImgURL = document.getElementById("<%=txtImgURL.ClientID%>");
            return CheckFileExistInner(objImgURL);
        }

         function ClickUploadImage() {
            var objHide = document.getElementById("<%=hide_State.ClientID %>");
            if (CheckLocalPath()) {
                parent.ClickUploadFile();
                objHide.value = "1";
                return true;
            }
            else {
                ClearUpLoadFile();
                return false;
            }
			
        }
        function ClickCopyFromURL() {
            var objHide = document.getElementById("<%=hide_State.ClientID %>");
 
            var varReturn = "false";

            if (CheckFileExist()) {
                parent.ClickUploadFile();
                objHide.value = "2";
                varReturn = true;
            }
            else {
                ClearImgURL();
                varReturn = false;
            }

            return varReturn;
        }
        

        function DoNotShowWaitDDialog() {
            parent.DoNotShowWaitDDialog();
        }
        
        function ShowImages()
        {
            var objHide = document.getElementById("<%=hide_State.ClientID %>");
            if(objHide.value == "1" || objHide.value == "2" ) {
            
            if("<%=strReturnPath%>" != "")
                parent.AppendImage("<%=strReturnPath%>", "<%=iWidth%>", "<%=iHeight%>");
            }
        }

        function SetState(strValue) { 
            var objHide = document.getElementById("<%=hide_State.ClientID %>");
            objHide.value = strValue;
        }

        function ClearImgURL() {
             var objImgURL = document.getElementById("<%=txtImgURL.ClientID%>");
             objImgURL.value = "";
         }

         function ClearUpLoadFile() {
             var objImgLoadFile = document.getElementById("<%=upLoadFile.ClientID%>");
             objImgLoadFile.value = "";

             var objImgLoadFileText = document.getElementById("txtUploadFileName");
             objImgLoadFileText.value = "";

         }

         window.onload = function() {
             Init();
             ShowImages();
             //DoNotShowWaitDDialog();
             SetState("0");    
             ClearImgURL();
             ClearUpLoadFile();
			 parent.imgPageNum();
         }
     </script>
     </head>
     <body class="uploadmode" >
    <%-- <ul id="image-menu">
       <li class="clickon local-img">Local Images</li>
       <li class="download-img">Download Images</li>
     </ul>--%>
     <form id="form1" runat="server" enctype="multipart/form-data">
       <div id="local-image">
         <div class="img-title"><span class="num">1</span>Upload from local: </div>
         <div class="con-fileupload">
           <asp:FileUpload CssClass="ImgLocalPath"  ID="upLoadFile"  size="115%" 
                        style="width:305px; height:40px; filter:alpha(opacity=0);-moz-opacity:0;opacity:0; font-size:23px;" runat="server" onchange="javascript:document.getElementById('AddImage').click();"/>
            <asp:TextBox ID="txtUploadFileName" CssClass="ImgURL" ReadOnly="true" runat="server" ></asp:TextBox><input type="button" id="btnUploadFile" value="" />
         
         <input style="display:none;" type="button" id="Img1" value="" onclick="javascript:document.getElementById('AddImage').click();" />
         <a class="bluelink" href="javascript:void(0);">or, Specify an URL</a>
         </div>
         <div style="display:none;">
           <input id="AddImage" type="submit" onclick="return ClickUploadImage();" style="display:none;height:22px; width:1px;margin-left:0px; float:left;" value="Open Image" name="AddImage"/>
         </div>
       </div>
       
       <div id="download-image" class="hidden">
         <div class="img-title"><span class="num">1</span>Specify an URL: </div>
         <asp:TextBox ID="txtImgURL" CssClass="ImgURL" runat="server"></asp:TextBox>
         <input type="button" id="GetFileFromURL" onclick="javascript:document.getElementById('btnGetFileFromURL').click();" onkeyup=" if(event.keyCode==13) { javascript:document.getElementById('btnGetFileFromURL').click(); }" value="" />
         <a class="bluelink" href="javascript:void(0);">or, Upload from local</a>
         <div style="display:none;">
           <input id="btnGetFileFromURL" type="submit" onclick="return ClickCopyFromURL();" style="display:none;height:22px; width:1px; margin-left:0px;"  value="Open Image From URL" name="btnUploadFile"/>
         </div>
       </div>
       <asp:HiddenField ID="hide_State" Value= "0" runat="server" />
     </form>
<script type="text/javascript">
 $("#download-image .bluelink").click(function(){
	 $("#local-image").removeClass('hidden');
	 $("#download-image").addClass('hidden');
	 });
 $("#local-image .bluelink").click(function(){
	 $("#download-image").removeClass('hidden');
	 $("#local-image").addClass('hidden');
	 });
</script>

</body>
</html>
