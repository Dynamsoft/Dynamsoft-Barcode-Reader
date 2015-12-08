<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarcodeOnLineDemo.aspx.cs"
    Inherits="BarcodeWeb.BarcodePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Barcode online scanner - 1D, QRCode, DataMatrix and PDF417</title>
    <link type="text/css" rel="Stylesheet" href="Css/style.css" />
    <meta name="viewport" content="width=device-width, maximum-scale=1.0" />
    <meta name="description" content="Dynamsoft Barcode Reader SDK online demo allows fast and robust linear barcode (Code 39, Code 128, etc.), QR Code, DataMatrix and PDF417 recognition in lines of code." />
    <link rel="stylesheet" type="text/css" href="Css/basis-bs.css?ver=2.0" />
    <link rel="stylesheet" type="text/css" href="Css/bootstrap.css" />
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <style>
        #subNav {
            position: static;
        }
		#cookie-warn { display:none !important;}
    </style>
    <script type="text/javascript" language="javascript" src="Scripts/jquery-1.11.2.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/ds-jquery-bs.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/kissy-min.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/OnlineDemoAjax.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/DemoCommon.js"></script>
    <!--[if lt IE 9]>
      <script type="text/javascript" src="Scripts/html5shiv.js"></script>
      <script type="text/javascript" src="Scripts/respond.js"></script>
     <![endif]-->
    <script type="text/javascript">
        // Assign the page onload fucntion.
        function S_get(id) {
            return document.getElementById(id);
        }

        var S = KISSY;

        function ClickDoBarcode() {
            var objImgage = document.getElementById("<%=Image1.ClientID%>");
            var ss = objImgage.src;
            if (ss.indexOf('Barcoding.aspx') > 0) {
                alert("Please change image.");
                return false;
            }

            showWaitDialog("Barcode Recognize");
            DoBarcode();
            return true;
        }

        function DoBarcode() {
            var objHide = document.getElementById("<%=hide_ImgFileName.ClientID %>");
            var vFileName = objHide.value;
            var end = vFileName.lastIndexOf("/") - 1;
            var temp = vFileName.substring(0, end);
            var start = temp.lastIndexOf("/");
            if (start < 0)
                start = 0;
            vFileName = vFileName.substring(start);
            var vType = 0;
            var barcodeType = document.getElementsByName("BarcodeType");
            for (i = 0; i < barcodeType.length; i++) {

                if (barcodeType[i].checked == true)
                    vType = vType | (barcodeType[i].value * 1);
            }

            var maxNumbers = document.getElementById("txtBarcodeNumbers");

            var AjaxFunctionUrl = "Ajaxfunctions.aspx";
            var body = "DW_AjaxMethod=DoBarcode&FileName=" + _Function_EncodeXmlString(vFileName) +
                        "&BarcodeFormat=" + _Function_EncodeXmlString(vType.toString()) +
                       "&MaxNumbers=" + _Function_EncodeXmlString(maxNumbers.value.toString()) +
                        "&SessionID=" + _Function_EncodeXmlString("<%=SessionID %>");

            _Function_AjaxPOST(AjaxFunctionUrl, body, _Function_DoBarcode, null);
        }

        function _Function_DoBarcode(xmlHttpRequestObject, objFieldObject) {
            DoNotShowWaitDDialog();
            var responseText = xmlHttpRequestObject.responseText;
            if (responseText != "") {
                var tmpState = responseText.split(';');
                if (tmpState.length > 3) {
                    var varFirst = tmpState[0];
                    var aryIndex = new Array();
                    var varIndex = 0;
                    while ((varIndex = responseText.indexOf("}];", varIndex)) != -1) {
                        aryIndex.push(varIndex);
                        varIndex += 3;
                    }
                    if (aryIndex.length % 2 == 1) {
                        var varSecondEndIndex = aryIndex[(aryIndex.length - 1) >> 1] + 2;
                        var varSecond = responseText.substring(varFirst.length + 1, varSecondEndIndex);
                        var varThird = responseText.substring(varSecondEndIndex + 1);
                        tmpState = new Array([3]);
                        tmpState[0] = varFirst;
                        tmpState[1] = varSecond;
                        tmpState[2] = varThird;
                    }
                }
                if (tmpState[0] == "OK") {
                    var objImage = document.getElementById("<%=Image1.ClientID%>");
                    var objBarcodeResults = document.getElementById("BarcodeResults");
                    var aryBarcodeResult = JSON.parse(tmpState[1]);
                    ClearResult();
                    ResizeResult(objImage, 0);
                    var dRate = GetScaleRate(objImage);
                    for (var i = 0; i < aryBarcodeResult.length; i++) {
                        var newBarcodeNode = document.createElement("div");
                        newBarcodeNode.innerHTML = aryBarcodeResult[i].text;
                        newBarcodeNode.className = "divBarcodeResult";
                        //var width = aryBarcodeResult[i].width * dRate;
                        var height = aryBarcodeResult[i].height * dRate;
                        //var minWidth = newBarcodeNode.innerHTML.getWidth(12);
                        //if (width < minWidth)
                        //    width = minWidth;
                        if (height < 12)
                            height = 12;
                        //newBarcodeNode.style.width = width + "px";
                        newBarcodeNode.style.height = height + "px";
                        newBarcodeNode.style.lineHeight = height + "px";
                        var fontsize = aryBarcodeResult[i].fontsize * dRate;
                        if (fontsize < 12)
                            fontsize = 12;
                        newBarcodeNode.style.fontSize = fontsize + "px";
                        newBarcodeNode.style.top = aryBarcodeResult[i].y * dRate + "px";
                        newBarcodeNode.style.left = aryBarcodeResult[i].x * dRate + "px";
                        objBarcodeResults.appendChild(newBarcodeNode);
                    }
                    var message = tmpState[2];
                    var r, re;
                    re = /&nbsp/g;
                    r = message.replace(re, "&nbsp;");
                    appendMessage(r);
                }
                else if (tmpState[0] == "EXP") {
                    var message = tmpState[1];
                    appendMessage(message);
                    alert(message);
                }
            }
        }

        function FixSize() {
            var objShowType = document.getElementById("hide_ShowType");
            objShowType.value = 0;
            var objImgage = document.getElementById("<%=Image1.ClientID%>");
            FixSizeInner(objImgage);
        }

        function OriginSize() {
            var objShowType = document.getElementById("hide_ShowType");
            objShowType.value = 2;
            var objImgage = document.getElementById("<%=Image1.ClientID%>");
            OriginSizeInner(objImgage);
        }

        function FullSize() {
            var objShowType = document.getElementById("hide_ShowType");
            objShowType.value = 3;
            var objImgage = document.getElementById("<%=Image1.ClientID%>");
            FullSizeInner(objImgage);
        }

        function FixWidth() {
            var objShowType = document.getElementById("hide_ShowType");
            objShowType.value = 1;
            var objImgage = document.getElementById("<%=Image1.ClientID%>");
            FixWidthInner(objImgage);
        }


        function ClickUploadFile() {
            showWaitDialog("Upload Image");
        }

        function ClickUploadImageURL() {
            showWaitDialog("Upload Image URL");
        }

        function DoNotShowWaitDDialog() {
            DoNotShowWaitDDialogInner();
        }

        var MaxHeight = 480;
        var MaxWidth = 450;
        var Per = 0.98;
        var OriginWidth = 0;

        function InitialPreviewIMG() {
            var allImgListObj = document.getElementById("<%=hide_allImgURL.ClientID%>");
            var objImgage = document.getElementById("<%=Image1.ClientID%>");
            var objHide = document.getElementById("<%=hide_ImgFileName.ClientID %>");

            var allImgList = allImgListObj.value.split(":");
            

            //var iOnloadCount = 0;
            for (var i = 0; i < allImgList.length; i++) {
                var ImgSrc = getURL(allImgList[i]);
                var img = new Image();
                img.src = ImgSrc;
                img.index = i;
                img.hideSrc = allImgList[i];
                if (i <= 10) {
                    img.onload = function () {
                        //iOnloadCount++;
                        if (this.index == 0) {
                            objImgage.src = this.src;
                            objHide.value = this.src;
                            InitialPreviewIMGInner(this.hideSrc, objImgage, objHide, true);
                            DoNotShowWaitDDialog();
                        }
                    }

                    img.onerror = function () {
                        //iOnloadCount++;
                         DoNotShowWaitDDialog();
                    }
                }
            }
        }

        function AppendImage(fileName, iWidth, iHeight) {
            var objAllImgURL = document.getElementById("<%=hide_allImgURL.ClientID%>");
            objAllImgURL.value = fileName;

            var objIndex = document.getElementById("<%=hide_index.ClientID%>");
            objIndex.value = 0;

            var objBarcodeResults = document.getElementById("BarcodeResults");
            objBarcodeResults.innerHTML = "";

            varCurrentImageWidth = iWidth;
            varCurrentImageHeight = iHeight;
            InitialPreviewIMG();
            ClearResult();
        }

        function GetScaleRate(objImage) {
            var dRate = 1;
            if (varCurrentImageWidth > 0) {
                nWidth = varCurrentImageWidth;
                var CurrentImageWidth = parseFloat(objImage.style.width);
                if (nWidth > 0) {
                    dRate = CurrentImageWidth / nWidth;
                }
            }
            return dRate;
        }

        function ClearResult() {
            appendMessage("");
        }
        function ResizeResult(objImage, dRate) {
            var objImageContainer = document.getElementById("BarcodeResults");
            objImageContainer.style.width = objImage.style.width;
            objImageContainer.style.height = objImage.style.height;
            if (parseFloat(objImage.style.width) > 604) {
                objImageContainer.style.marginLeft = "20px";
                objImageContainer.style.left = "0px";
            }
            else {
                objImageContainer.style.marginLeft = -parseFloat(objImage.style.width) / 2 + "px";
                objImageContainer.style.left = "50%";
            }
            if (dRate > 0) {
                var divBarcodeResults = objImageContainer.getElementsByTagName("div");
                for (var i = 0; i < divBarcodeResults.length; i++) {
                    //divBarcodeResults[i].style.width = parseInt(divBarcodeResults[i].style.width) * dRate + "px";
                    var height = parseFloat(divBarcodeResults[i].style.height) * dRate;
                    if (height < 12)
                        height = 12;
                    divBarcodeResults[i].style.height = height + "px";
                    divBarcodeResults[i].style.lineHeight = height + "px";
                    var fontsize = parseFloat(divBarcodeResults[i].style.fontSize) * dRate;
                    if (fontsize < 12)
                        fontsize = 12;
                    divBarcodeResults[i].style.fontSize = fontsize + "px";
                    divBarcodeResults[i].style.top = parseFloat(divBarcodeResults[i].style.top) * dRate + "px";
                    divBarcodeResults[i].style.left = parseFloat(divBarcodeResults[i].style.left) * dRate + "px";
                }
            }
        }


        function GetNextImage() {
            var objIndex = document.getElementById("<%=hide_index.ClientID%>");
            var allImgListObj = document.getElementById("<%=hide_allImgURL.ClientID%>");

            var index = objIndex.value;
            if (index == "" || index == 0)
                index = 1;
            index = parseInt(index);

            index += 1;
            var aryFileName = allImgListObj.value.split(':');
            var count = aryFileName.length;
            if (index == count + 1) {
                $("#curPage").text(count);
                return;
            } else {
                $("#curPage").text(index);
            }

            if (index >= count) {
                var objIndex = document.getElementById("<%=hide_index.ClientID%>");
                //disable next
            }

            objIndex.value = index;
            var fileName = aryFileName[index - 1];
            var objImgage = document.getElementById("<%=Image1.ClientID%>");
            var objHide = document.getElementById("<%=hide_ImgFileName.ClientID %>");
            ShowImgWithURL(fileName, objImgage, objHide, false);

        }

        function GetPreImage() {
            var objIndex = document.getElementById("<%=hide_index.ClientID%>");
            var allImgListObj = document.getElementById("<%=hide_allImgURL.ClientID%>");

            var index = objIndex.value;
            if (index == "" || index == 0)
                index = 1;
            index = parseInt(index);
            index -= 1;
            if (index == 0) {
                $("#curPage").text(1);
                return;
            } else {
                $("#curPage").text(index);
            }

            var aryFileName = allImgListObj.value.split(':');
            var count = aryFileName.length;
            if (index + 1 >= count) {
                //disable next
            }
            objIndex.value = index;
            var fileName = aryFileName[index - 1];
            var objImgage = document.getElementById("<%=Image1.ClientID%>");
            var objHide = document.getElementById("<%=hide_ImgFileName.ClientID %>");
            ShowImgWithURL(fileName, objImgage, objHide, false);
        }
        function imgPageNum() {
            var allImgListObj = document.getElementById("<%=hide_allImgURL.ClientID%>");
            var aryFileName = allImgListObj.value.split(':');
            var count = aryFileName.length;
            document.getElementById("allPage").innerHTML = count;
            document.getElementById("curPage").innerHTML = 1;
        }

        function clearBarcodeResults() {
            document.getElementById("BarcodeResults").innerHTML = '';
        }

        window.onload = function () {
            InitialPreviewIMG();
        }

        window.setInterval(function () {
            var AjaxFunctionUrl = "Ajaxfunctions.aspx";
            var body = "DW_AjaxMethod=Interval&SessionID=" + _Function_EncodeXmlString("<%=SessionID %>");
            _Function_AjaxPOST(AjaxFunctionUrl, body, null, null);
        }, 900000);

    </script>
</head>
<body >
    <div id="wrapper">
        <!--begin header-->
        <div id="header">
            <!-- #include file=overall-header-bs.aspx -->
            <!--begin subNav-->
            <!-- #include file=nav-dbr-demo.aspx -->
            <!--end subNav-->
        </div>
        <!--end header-->
        <div id="main">
            <div style="overflow: auto" class="container pb100">
                <div class="row main-pannel">
                    <div class="D-dailog row" id="J_waiting">
                        <div id="strBody"></div>
                    </div>
                    <form id="form1" class="form-content" runat="server">
                        <div class="body_Broad_width row">
                            <div id="main-content" class="col-xs-12">
                                <div id="content-left">
                                    <%-- <div id="sample-image">--%>
                                    <%--  <div class="divThumbnail">--%>
                                    <%-- <div id="content-nav">--%>
                                    <iframe width='100%' height="200" frameborder='0' scrolling="no" src="UploadMode.aspx"></iframe>
                                    <%--</div>--%>
                                    <div class="title"><span class="num">2</span>Barcode Types: </div>
                                   <div class="barcode-types">
                                        <label class="lblBarcodeType Linear">
                                            <input id="chkLinear" name="BarcodeType" type="checkbox" checked="true" value="0x3FF" onclick="ClickCheckBox(this);" />
                                            Linear <a rel="tooltipType" style="text-decoration: none;" title="">
                                                <img src="Images/icn-question-16x16.png" /></a></label>
                                        <label class="lblBarcodeType QRCode">
                                            <input id="chkQRCode" name="BarcodeType" type="checkbox" value="0x4000000" onclick="ClickCheckBox(this);" />
                                            QRCode</label>                 
                                       <br/>
                                        <label class="lblBarcodeType PDF417">
                                            <input id="chkPdf" name="BarcodeType" type="checkbox" value="0x2000000" onclick="ClickCheckBox(this);" />
                                            PDF417</label>
                                         <label class="lblBarcodeType DataMatrix">
                                            <input id="chkDM" name="BarcodeType" type="checkbox" value="0x8000000" onclick="ClickCheckBox(this);" />
                                            DataMatrix</label>
                                        <label style="display: none;">
                                            <span class="maxNum">Maximum Barcodes</span><br />
                                            <input id="txtBarcodeNumbers" class="mt10" type="text" value="100" />
                                            Per Page</label>
                                    </div>
                                    <div class="recognize-barcode"><span class="num">3</span><a id="RecgabtnCssBarcode" name="RecgabtnCssBarcode" onclick="ClickDoBarcode();"></a> </div>
                                    <div class="msg-box">
                                        <div id="DWTemessage"></div>
                                    </div>
                                    <%-- </div>--%>
                                </div>
                                <div id="content-right">
                                    <%-- <div class="divThumbnail">--%>
                                    <div id="tool-bar">
                                        <div id="origin" class="icn" onclick="OriginSize();"></div>
                                        <div id="fix" class="icn" onclick="FixSize();"></div>
                                    </div>
                                    <div id="switcher" class="tc">
                                        <div id="getPre" class="icn" onclick="GetPreImage();"></div>
                                        <div id="getNext" class="icn" onclick="GetNextImage();"></div>
                                        <div id="pageNum" class="fontWhite">page&nbsp;<span id="curPage">1</span>/<span id="allPage">1</span></div>
                                    </div>
                                    <div id="image-box">
                                        <div class="divShowBarcode">
                                            <asp:Image ID="Image1" CssClass="ImageBarcode" runat="server" />
                                            <div id="BarcodeResults"></div>
                                        </div>
                                    </div>
                                    <%-- </div>--%>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hide_ImgFileName" runat="server" />
                        <asp:HiddenField ID="hide_index" runat="server" />
                        <asp:HiddenField ID="hide_allImgURL" Value=" " runat="server" />
                        <asp:HiddenField ID="hide_showInputURLImage" runat="server" />
                        <asp:HiddenField ID="hide_ShowType" Value="2" runat="server" />
                    </form>
                </div>
            </div>
            <div class="main-intro bgGray">
                <div class="container ptb100">
                    <div class="row">
                        <h3 class="col-xs-12">Online Dynamsoft Barcode Reader</h3>
                        <p class="col-xs-12">With Dynamsoft Barcode Reader SDK, developers can easily integrate barcode detection and decoding functionalities into their desktop and web applications. Two editions available: The Windows Edition provides C, C++, ActiveX / COM and .NET APIs; The Mac Edition provides C and C++ APIs.</p>
                    </div>
                </div>
            </div>
        </div>
        <!--begin footer-->
        <div id="footer">
            <!-- #include file=overall-footer-bs.aspx -->
        </div>
        <!--end footer-->
    </div>
    </div>
</body>
<script>
    // var iCurrentFirst = 0;
    //function ResetThumbnailList() {
    //    if ($("#imgCenterDiv a").length > 6 && iCurrentFirst < ($("#imgCenterDiv a").length - 6)) {
    //        $("#next span").show();
    //    }
    //    else {
    //        $("#next span").hide();
    //    }
    //    if ($("#imgCenterDiv a").length > 6 && iCurrentFirst > 0) {
    //        $("#pre span").show();
    //    }
    //    else {
    //        $("#pre span").hide();
    //    }
    //}
    //function GoToFirstAfterAppend() {        
    //    iCurrentFirst = 0;
    //    $("#imgCenterDiv").css('top', '40px');        
    //    ResetThumbnailList();
    //}
    //function GoToLastAfterAppend() {
    //    if ($("#imgCenterDiv a").length > 6) {
    //        iCurrentFirst = $("#imgCenterDiv a").length - 6;
    //        var Top = 40 - ($("#imgCenterDiv a").length - 6) *120;
    //        $("#imgCenterDiv").css('top', Top + 'px');
    //    }
    //    else {
    //        iCurrentFirst = 0;
    //        $("#imgCenterDiv").css('top', '40px');
    //    }
    //    ResetThumbnailList();
    //}

    $(document).ready(function () {

        //$("#pre span").click(function () {
        //    var imgCenterDivTop = $("#imgCenterDiv").css('top');
        //    var imglist = $("#imgCenterDiv a");
        //    imgCenterDivTop = parseInt(imgCenterDivTop) + 120;
        //    $("#imgCenterDiv").css('top', imgCenterDivTop);
        //    $("#next span").show();
        //    iCurrentFirst --;
        //    ResetThumbnailList();
        //});

        //$("#next span").click(function () {
        //    var imgCenterDivTop = $("#imgCenterDiv").css('top');
        //    var imglist = $("#imgCenterDiv a");
        //    // moveUp
        //    imgCenterDivTop = parseInt(imgCenterDivTop) - 120;
        //    $("#imgCenterDiv").css('top', imgCenterDivTop);
        //    $("#pre span").show();
        //    iCurrentFirst ++;
        //    ResetThumbnailList();
        //});

        $("a[rel=tooltipType]").easyTooltip({
            tooltipId: "tooltip",
            content: "<div class='tipBody' style='float:left; width:220px;'><div style='width:50%; float:left;'> Code 39<br />Code 93<br />Code 128<br />EAN-8<br />EAN-13</div><div style='width:50%; float:left;'>Interleaved 2 of 5<br />Industrial 2 of 5<br />UPC-A<br />UPC-E<br />Codabar</div></div>"
        });

        // collect data
        $.ajax({
            type: "GET",
            url: "http://www.dynamsoft.com/CustomerPortal/ActionLog.ashx",
            data: { op: 29, product: 17 },
            dataType: "text"
        });
    });
</script>
<!--
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
	  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-19660825-1', 'auto');
    ga('require', 'displayfeatures');
    ga('require', 'ec');
    ga('send', 'pageview');

</script>
-->
<script type="text/javascript">
    setTimeout(function () {
        var a = document.createElement("script");
        var b = document.getElementsByTagName("script")[0];
        a.src = document.location.protocol + "//script.crazyegg.com/pages/scripts/0036/0156.js?" + Math.floor(new Date().getTime() / 3600000);
        a.async = true; a.type = "text/javascript"; b.parentNode.insertBefore(a, b)
    }, 1);
</script>
</html>
