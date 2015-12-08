var nLen;
var dlgDoBarcode;
var varCurrentImageWidth = 0;
var varCurrentImageHeight = 0;
var run;

function showWaitDialog(waitDialogType) {
    var varInformation = "";
    if (waitDialogType == "Barcode Recognize") {
        varInformation = "Recognition...";
    }
    else if (waitDialogType == "Upload Image") {
        varInformation = "Uploading Image...";
    }
    else if (waitDialogType == "Upload Image URL") {
        varInformation = "Uploading Image From URL...";
    }
    else if (waitDialogType == "Engine Changed") {
        varInformation = "Please Wait while Updating Language List...";
    }

    var ObjString = "<div class=\"D-dailog-body-Recognition\">";
    ObjString += "<p>" + varInformation + "</p>";
    ObjString += "<img src='Images/loading.gif' style='width:160px; height:160px; margin-left:17px; margin-top:20px;' /></div>";
    document.getElementById("strBody").innerHTML = ObjString;

    ShowWaitDialog(237, 262); 
}

function DoNotShowWaitDDialogInner() {
    if (dlgDoBarcode) {
        dlgDoBarcode.hide();
    }
}

function ShowWaitDialog(varWidth, varHeight) {
    S.use("overlay", function(S, o) {

    dlgDoBarcode = new o.Dialog({
            srcNode: "#J_waiting",
            width: varWidth,
            height: varHeight,
            closable: false,
            mask: true,
            align: {
                points: ['cc', 'cc']
            }
        });
        dlgDoBarcode.show();
		run=1;
    });
}
        

function CloseDownLoadFile_onclick() {
    DoNotShowWaitDDialog();
}

function Init() {
    if (document.getElementById('upLoadFile')) {
        if (!document.getElementById('upLoadFile').onchange)
            document.getElementById('upLoadFile').onchange = function() {
                document.getElementById('txtUploadFileName').value = document.getElementById('upLoadFile').value;
            };
    }
}

function InitialPreviewIMGInner(ImgSrc, objImgage, objHide, bAleady) {
    ShowImgWithURL(ImgSrc, objImgage, objHide, bAleady)   
    var tmpLoad = document.createElement("img");
    tmpLoad.src = "Images/loading.gif";
}

function getURL(ImgSrc)
{
    var retString = ImgSrc;
    var index = ImgSrc.lastIndexOf("/");
    var normalImgSrc = ImgSrc;
    if (index > 0) {
        var dotPos = ImgSrc.lastIndexOf(".");
        if (dotPos > 0) {
            var dir = ImgSrc.substring(0, index + 1);
            var file = ImgSrc.substring(index + 1, dotPos);
            var extPos = file.lastIndexOf("_");
            if (extPos > 0) {
                var name = file.substring(0, extPos);
                var ext = file.substring(extPos + 1);
                normalImgSrc = dir + name + "." + ext;
                try {
                    var hPos = name.lastIndexOf("_");
                    var nameWidth = name.substring(0, hPos);
                    varCurrentImageWidth = parseInt(nameWidth.substring(nameWidth.lastIndexOf("_") + 1));
                    varCurrentImageHeight = parseInt(name.substring(hPos + 1));
                } catch (e) {

                }

                retString = normalImgSrc;
            }
        }
    }
    return retString;
}


function ShowImgWithURL(ImgSrc, objImgage, objHide, bAleady) {
    var normalImgSrc = getURL(ImgSrc);
    if (bAleady) {
        objImgage.src = normalImgSrc;
        objHide.value = normalImgSrc;
    }
    else {
        ShowImgInner(normalImgSrc, objImgage, objHide);
    }
    if (normalImgSrc == ImgSrc) {
        ShowImgSize(objHide.value);
    }
    else {
        ShowImgSizeInner();
    }
  
    ClearResult();
}




function ShowImgSizeInner() {
    var objShowType = document.getElementById("hide_ShowType");

    if (objShowType.value == "1") {
        FixWidth();
    }
    else if (objShowType.value == "2") {
        OriginSize();
    }
    else if (objShowType.value == "3") {
        FullSize();
    }
    else {
        FixSize();
    }
} 

function ShowImgInner(ImgSrc, objImgage, objHide) {

    var objBarcodeResults = document.getElementById("BarcodeResults");
    objBarcodeResults.innerHTML = "downloading images...please wait."
    objImgage.src = "";

    var img = new Image();
    img.onload = function () {
        objImgage.src = ImgSrc;
        objHide.value = ImgSrc;
        objBarcodeResults.innerHTML = "";
        img = null;
    }
    img.src = ImgSrc;
}

function CheckLocalPathInner(objImgURL) {
    var strValue = objImgURL.value;
    if (strValue.length < 1) {
        alert("Local file path is invalid.");
        return false;
    }
    var a = strValue.split(".");
    if (a.length < 1) {
        alert("Only 'bmp','dib','jpg','jpeg','jpe','jfif','tif','tiff','gif','png', supported.");
        return false;
    }
    var ext = a[a.length - 1];
    ext = ext.toLowerCase();
    var allFileSupport = ['bmp', 'dib', 'jpg', 'jpeg', 'jpe', 'jfif', 'tif', 'tiff', 'gif', 'png'];
    var len = allFileSupport.length;
    var i = 0;
    for (i = 0; i < len; ++i) {
        if (allFileSupport[i] == ext)
            break;
    }
    if (i == len) {
        alert("Only 'bmp','dib','jpg','jpeg','jpe','jfif','tif','tiff','gif','png', supported.");
        return false;
    }
    return true;
}


function OnFileChange() {
    var objPath = document.getElementById("txtLocalPath.ClientID");
    var objUploadFile = document.getElementById("upLoadFile.ClientID");
    objPath.value = objUploadFile.value;
}
function ClickUpLoad() {
    var objUploadFile = document.getElementById("<%=upLoadFile.ClientID%>");
    objUploadFile.click();
}
function CheckFileExistInner(objImgURL) {
    var strValue = objImgURL.value;
    strValue = strValue.replace(/^\s+|\s+$/g, '');
    if (strValue.length < 1) {
        alert("URL is invalid.");
        return false;
    }
    return true;
}

function ShowImgSize(ImgSrc) {
    var img = new Image();

    img.onload = function () {
        varCurrentImageWidth = img.width;
        varCurrentImageHeight = img.height;
        ShowImgSizeInner();
        img = null;
    }
    img.src = ImgSrc;
}

function FixSizeInner(objImgage) {
    var height = varCurrentImageHeight;
    var width = varCurrentImageWidth; 
    var ppw = Math.round(MaxWidth * 100.00) / width;
    var pph = Math.round(MaxHeight * 100.00) / height;

    if (ppw > pph && pph > 0) {
        width = (width * pph) / 100;
        height = MaxHeight;
    }
    else if (ppw < pph && ppw > 0) {
        width = MaxWidth;
        height = (height * ppw) / 100;
    }
    else {
        height = MaxHeight;
        width = MaxWidth;
    }
    var scaleRate = width / parseFloat(objImgage.style.width);

    objImgage.style.width = width + "px";
    objImgage.style.height = height + "px";

    ResizeResult(objImgage, scaleRate);
}
function OriginSizeInner(objImgage) {
    var height = varCurrentImageHeight; 
    var width = varCurrentImageWidth; 
    if (width != 0 && height != 0) {
        var scaleRate = width / parseFloat(objImgage.style.width);
        objImgage.style.height = height + "px"; 
        objImgage.style.width = width + "px";
        ResizeResult(objImgage, scaleRate);
    }
}
function FullSizeInner(objImgage) {
    objImgage.style.width = MaxWidth + "px";
    objImgage.style.height = MaxHeight + "px";
}
function FixWidthInner(objImgage) {
    var height = varCurrentImageHeight;
    var width = varCurrentImageWidth; 
    var pp = 1.0 * MaxWidth / width;
    height = height * pp;
    objImgage.style.width = MaxWidth + "px";
    objImgage.style.height = height + "px";
} 

var _strTempStr = "";       // Store the temp string for display
function appendMessage(strMessage) {
    _strTempStr = strMessage;
    var _divMessageContainer = document.getElementById("DWTemessage");
    if (_divMessageContainer) {
        _divMessageContainer.innerHTML = _strTempStr;
        //_divMessageContainer.scrollTop = _divMessageContainer.scrollHeight;
    }
}

function ClickCheckBox(obj) {
    var bSelect = obj.checked;
    var i = 0;
    var barcodeType = document.getElementsByName("BarcodeType");
    if (bSelect == true) {
        for (i = 0; i < barcodeType.length; i++) {
            if (barcodeType[i].checked == false)
                break;
        }
    }
    else {
        for (i = 0; i < barcodeType.length; i++) {
            if (barcodeType[i].checked == true)
                break;
        }
    }
}
	

