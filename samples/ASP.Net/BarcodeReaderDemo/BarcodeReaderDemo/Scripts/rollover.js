/** 
 * Fusion 8 DHTML Menus
 */


/*****************************************
Global Parameters
*****************************************/

var GLOBAL_LoadedImages  = new Array();
var GLOBAL_CurrentItem   = "";
var GLOBAL_Close         = null;
var GLOBAL_Hide          = null;
var GLOBAL_items         = new NOF_OpenedItems();

var GLOBAL_slideItem     = null;
var GLOBAL_slideSpeed    = 10; //Defines how fast the slide submenus will unfold
var GLOBAL_slidePixel    = 0; 
var GLOBAL_slideMinOffset = -800;
var GLOBAL_slideMaxOffset = 800;

var useDebuger   = false;


/*
*  DOM compliant browsers
*/
function NOF_DOMBrowser() {

  this.getMenuItemLayerStartString = function getMenuItemLayerStartString(menuItemId, parentId) {

    parentId = ( (parentId != null) && (parentId != "undefined") && (typeof(parentId) != "undefined"))
                  ? new String(parentId + CONSTANTS.MENU_LAYER_SUFIX) : null;
    menuItemId += CONSTANTS.MENU_LAYER_SUFIX;
    
    var isAutoClose = typeof(C_MENU_AUTO_CLOSE) == "undefined" || C_MENU_AUTO_CLOSE == true ? "true" : "false";

    return '<DIV ID="' + menuItemId + '" isautoclose="' + isAutoClose + '" STYLE="z-index:5; filter:blendTrans(duration=0.5)" onmouseover="NOF_KeepOpen(\'' + menuItemId + '\', ' + parentId + ')" onmouseout="NOF_KeepClose()">';
  }

  this.getMenuItemLayerEndString = function getMenuItemLayerEndString() {
    return '</DIV>';
  }

  /** method showMenuItem
  *@parameter image Image object - item parent
  *@parameter item String or Object coresponding to a layer
  *@parameter offsetX:  horizontal offset distance from parent
  *@parameter offsetY:  vertical offset distance from parent
  *@parameter direction Horizontal = false, Vertical = true
  */
  this.showMenuItem = function showMenuItem(image, item, offsetX, offsetY, openEffect) {

    if (typeof(item) == "string")
      item   = this.getItem(item)

    image    = typeof(image) == "string" ? this.getItem(image) : image;

    var top  = this.findItemTopOffset(image);
    var left = this.findItemLeftOffset(image);

    var slideDirection = "";
    if (openEffect.indexOf("left") > -1 || openEffect.indexOf("Left") > -1 ) {
        top  += offsetY; 
        left -= offsetX;
        slideDirection = "left";
    } else if (openEffect.indexOf("top") > -1 || openEffect.indexOf("Top") > -1 ) {
        top   -= offsetY;
        left += offsetX;
        slideDirection = "top";
    } else if (openEffect.indexOf("right") > -1 || openEffect.indexOf("Right") > -1 ) {
        top  += offsetY; 
        left += offsetX;
        slideDirection = "right";
    } else { // Bottom
        top   += offsetY;
        left += offsetX;
        slideDirection = "bottom";
    }
 
    if (item == null  || typeof(item.style) == "undefined" || item.style == null )
      return;

    item.style.top  = top;
    item.style.left = left;      
    item.style.visibility = "visible"; 
    
    if (openEffect.indexOf("slide") > -1)
      this.slideEffect(item, slideDirection);
    else if (openEffect.indexOf("fade") > -1)
      this.fadeEffect(item);    
  }


  this.hideMenuItem = function hideMenuItem(item) {

    if (typeof(item) == "string")
      item = this.getItem(item)   
 
    if ( item == null || typeof(item) == "undefined" || item == "")
      return;

    item.style.visibility = "hidden";
  }

  this.findItemLeftOffset = function findItemLeftOffset(item) {

    var offset = item.offsetLeft;
    if (item.offsetParent)
      offset += this.findItemLeftOffset(item.offsetParent);

    return offset;
  }

  this.findItemTopOffset = function findItemTopOffset(item) {

    var offset = item.offsetTop;
    if (item.offsetParent)
      offset += this.findItemTopOffset(item.offsetParent);

    return offset;
  }

  this.getItem = function getItem(itemId) {    
    return document.getElementById(itemId);
  }

  this.getItemAttribute = function getItemAttribute(itemId, attrId) {
  
    if (this.getItem(itemId)) {
      var attr = this.getItem(itemId).attributes;
      return eval("attr." + attrId.toLowerCase() + ".value");
    }
  }
 
 this.debug = function debug(txt) {

    var container = this.getItem("debug");
    if ( useDebuger )
      container.value += txt + "\n";
  }

  this.fadeEffect = function fadeEffect(item) {
      
      item.style.visibility = "hidden"; 
      item.filters.blendTrans.Apply();
      item.filters.blendTrans.Play();
      item.style.visibility = "visible"; 
  }

  this.slideEffect = function slideEffect(item, margin) {

    GLOBAL_slideItem = item;
    this.setItemClip('rect(auto, auto, auto, auto)');

    GLOBAL_slidePixel = (margin == "top" || margin == "left") ? 100 : 0;
    this.playEffect(margin);
  }

  this.playEffect = function playEffect(margin) {

    var clip = GLOBAL_slideItem.style.clip;
    if (clip.indexOf("-") > 0) // NS7.x fix
      return;

    if (GLOBAL_slidePixel < GLOBAL_slideMinOffset || GLOBAL_slidePixel > GLOBAL_slideMaxOffset)     
      return;

    var rect = 'rect(';
    if (margin == "top") {
      GLOBAL_slidePixel -= 3;
      rect += GLOBAL_slidePixel +'px auto auto auto)';
    } else if (margin == "right") {
      GLOBAL_slidePixel += 3; 
      rect += 'auto ' + GLOBAL_slidePixel +'px auto auto)';
    } else if (margin == "bottom") {
      GLOBAL_slidePixel += 3;
      rect += 'auto auto ' + GLOBAL_slidePixel + 'px auto)';
    } else {//left
      GLOBAL_slidePixel -= 3;
      rect += 'auto auto auto ' + GLOBAL_slidePixel + 'px)';
    }


    this.setItemClip(rect); 
    setTimeout('browser.playEffect("' + margin + '")', GLOBAL_slideSpeed);    
  }

  this.setItemClip = function setItemClip(rect) {
    GLOBAL_slideItem.style.clip = rect; 
  }

  this.getLayerTag = function getLayerTag() { return "div" };
}


/*
*  Netscape 6+ and Mozilla
*/
function NOF_BrowserNetscapeNavigator() {

  //Event capture
  window.onclick= HideMenu;
  
  this.fadeEffect = function fadeEffect() { return; };

  // Set a higher sliding speed
  GLOBAL_slideSpeed = 1;

  return this;
}
NOF_BrowserNetscapeNavigator.prototype = new NOF_DOMBrowser;

/*
*  Internet Explorer 5+
*/
function NOF_BrowserInternetExplorer() {

  //Event capture
  document.onmouseup = HideMenu;
}
NOF_BrowserInternetExplorer.prototype = new NOF_DOMBrowser;


/*
*  Nestcape Navigator version 4.x
*/
function NOF_BrowserNetscape4x() {

  this.getMenuItemLayerStartString = function getMenuItemLayerStartString(menuItemId, parentId) {

    parentId = ( (parentId != null) && (parentId != "undefined") && (typeof(parentId) != "undefined"))
                  ? new String(parentId + CONSTANTS.MENU_LAYER_SUFIX) : null;
    menuItemId += CONSTANTS.MENU_LAYER_SUFIX;
    
    var isAutoClose = typeof(C_MENU_AUTO_CLOSE) == "undefined" || C_MENU_AUTO_CLOSE == true ? "true" : "false";

    return '<layer ID="' + menuItemId + '" isautoclose="' + isAutoClose + '" onmouseover="NOF_KeepOpen(\'' + menuItemId + '\', ' + parentId + ')" onmouseout="NOF_KeepClose()">';
  }

  this.getMenuItemLayerEndString = function getMenuItemLayerEndString() {
    return '</layer>';
  }    

  this.getImageParent = function getImageParent(imageObject){
  
    for (var position = 0; position < document.layers.length; position++) {      
      var layer = document.layers[position];
      for (var imagePosition = 0; imagePosition < layer.document.images.length; imagePosition++) {  
        if (layer.document.images[imagePosition].name == imageObject.name) {
         return layer;
        }
      }     
    }

    return null;    
  }

  /** method showMenuItem
  *@parameter image Image object - item parent
  *@parameter item String or Object coresponding to a layer
  *@parameter offsetX:  horizontal offset distance from parent
  *@parameter offsetY:  vertical offset distance from parent
  *@parameter direction Horizontal = false, Vertical = true
  */
  this.showMenuItem = function showMenuItem(image, item, offsetX, offsetY, openEffect) {

    var parent = this.getImageParent(image);

    var itemId = image;
    if (typeof(item) == "string")
      item   = this.getItem(item)
  
    image    = typeof(image) == "string" ? this.getItem(image) : image;

    var top  = this.findItemTopOffset(image);
    var left = this.findItemLeftOffset(image);

    if (parent != null) {
      left += parent.pageX;
      top += parent.pageY;
    }

    var slideDirection = "";
    if (openEffect.indexOf("left") > -1 || openEffect.indexOf("Left") > -1 ) {
        top  += offsetY; 
        left -= offsetX;
        slideDirection = "left";
    } else if (openEffect.indexOf("top") > -1 || openEffect.indexOf("Top") > -1 ) {
        top   -= offsetY;
        left += offsetX;
        slideDirection = "top";
    } else if (openEffect.indexOf("right") > -1 || openEffect.indexOf("Right") > -1 ) {
        top  += offsetY; 
        left += offsetX;
        slideDirection = "right";
    } else { // Bottom
        top   += offsetY;
        left  += offsetX;
        slideDirection = "bottom";
    }

    if (typeof(item) == "undefined")
      return;



    item.y = parseInt(top);
    item.x = parseInt(left);   
    item.visibility = "visible"; 
    
    if (openEffect.indexOf("slide") > -1)
      this.slideEffect(item, slideDirection);
    else if (openEffect.indexOf("fade") > -1) {      
      this.fadeEffect(item);
    }
  }

  this.hideMenuItem = function hideMenuItem(item) {
    if (typeof(item) == "string")
      item = this.getItem(item)
    
    if ( item == null || typeof(item) == "undefined" || item == "")
      return;

    item.visibility = "hide";
  }

  this.findItemLeftOffset = function findItemLeftOffset(item) {
    return item.x;  
  }

  this.findItemTopOffset = function findItemTopOffset(item) {
    return item.y;
  }

  this.getItem = function getItem(itemId) {    

    if (itemId == "")
      return;

    var item = eval("document.layers['" + itemId + "']");

    return item;
  }

  this.getItemAttribute = function getItemAttribute(itemId, attrId) {

    return eval("document.layers['" + itemId.toLowerCase() + "']." + attrId);
  }

  this.getLayerTag = function getLayerTag() { return "layer" };

  this.slideEffect = function slideEffect(item, margin) {

    GLOBAL_slideItem  = item;
    GLOBAL_slidePixel = (margin == "bottom" || margin == "left") ? 200 : 0;

    this.playEffect(margin);
  }

  this.playEffect = function playEffect(margin) {

    if (GLOBAL_slidePixel < GLOBAL_slideMinOffset || GLOBAL_slidePixel > GLOBAL_slideMaxOffset)
      return;
 
    if (margin == "top") {
      GLOBAL_slideItem.clip.bottom = GLOBAL_slidePixel += 1;
    } else if (margin == "right") {
      GLOBAL_slideItem.clip.right = GLOBAL_slidePixel += 1;
    } else if (margin == "bottom") {
      GLOBAL_slideItem.clip.top = GLOBAL_slidePixel -= 1;
    } else {//left
      GLOBAL_slideItem.clip.left = GLOBAL_slidePixel -= 1;
    }

    setTimeout('browser.playEffect("' + margin + '")', GLOBAL_slideSpeed);    
  }
}
NOF_BrowserNetscape4x.prototype = new NOF_DOMBrowser;


/** NOF.BrowserFactory
*@return The associate class for the browser
*/

function NOF_BrowserFactory() {

    var agt = navigator.userAgent.toLowerCase();

    var is_major = parseInt(navigator.appVersion);
    var is_minor = parseFloat(navigator.appVersion);

    var is_nav  = ((agt.indexOf('mozilla')!=-1) && (agt.indexOf('spoofer')==-1)
                && (agt.indexOf('compatible') == -1) && (agt.indexOf('opera')==-1)
                && (agt.indexOf('webtv')==-1) && (agt.indexOf('hotjava')==-1));
    var is_nav2 = (is_nav && (is_major == 2));
    var is_nav3 = (is_nav && (is_major == 3));
    var is_nav4 = (is_nav && (is_major == 4));
    var is_nav4up = (is_nav && (is_major >= 4));
    var is_navonly      = (is_nav && ((agt.indexOf(";nav") != -1) ||
                          (agt.indexOf("; nav") != -1)) );
    var is_nav6 = (is_nav && (is_major == 5));
    var is_nav6up = (is_nav && (is_major >= 5));
    var is_gecko = (agt.indexOf('gecko') != -1);


    var is_ie     = ((agt.indexOf("msie") != -1) && (agt.indexOf("opera") == -1));
    var is_ie3    = (is_ie && (is_major < 4));
    var is_ie4    = (is_ie && (is_major == 4) && (agt.indexOf("msie 4")!=-1) );
    var is_ie4up  = (is_ie && (is_major >= 4));
    var is_ie5    = (is_ie && (is_major == 4) && (agt.indexOf("msie 5.0")!=-1) );
    var is_ie5_5  = (is_ie && (is_major == 4) && (agt.indexOf("msie 5.5") !=-1));
    var is_ie5up  = (is_ie && !is_ie3 && !is_ie4);
    var is_ie5_5up =(is_ie && !is_ie3 && !is_ie4 && !is_ie5);
    var is_ie6    = (is_ie && (is_major == 4) && (agt.indexOf("msie 6.")!=-1) );
    var is_ie6up  = (is_ie && !is_ie3 && !is_ie4 && !is_ie5 && !is_ie5_5);

    var is_opera = (agt.indexOf("opera") != -1);
    var is_opera2 = (agt.indexOf("opera 2") != -1 || agt.indexOf("opera/2") != -1);
    var is_opera3 = (agt.indexOf("opera 3") != -1 || agt.indexOf("opera/3") != -1);
    var is_opera4 = (agt.indexOf("opera 4") != -1 || agt.indexOf("opera/4") != -1);
    var is_opera5 = (agt.indexOf("opera 5") != -1 || agt.indexOf("opera/5") != -1);
    var is_opera5up = (is_opera && !is_opera2 && !is_opera3 && !is_opera4);

    this.getBrowser = function getBrowser() {
    
      if (is_ie5up) {   
        return new NOF_BrowserInternetExplorer();
      } 

      if (is_nav6up) {
        return new NOF_BrowserNetscapeNavigator();
      }

      if (is_opera5up) {
        return new NOF_BrowserInternetExplorer();        
      }

      if (is_nav4) {
        return new NOF_BrowserNetscape4x();
      }
    }
}

var browserFactory  = new NOF_BrowserFactory();
var browser         = browserFactory.getBrowser();



/*****************************************
NOF.Menu Constants
*****************************************/

var CONSTANTS = {
  MENU_TYPE_IMAGE : "Image",
  MENU_TYPE_TEXT  : "Text",

  BUTTON_TYPE_IMAGE : "image",
  BUTTON_TYPE_TEXT  : "text",

  MENU_TABLE_HEADER : '<table border="0" cellspacing="0" cellpadding="0">',
  MENU_TABLE_END :    '</table>',

  MOUSE_OVER_IMAGE : 1,
  MOUSE_OUT_IMAGE  : 2,

  MENU_ITEM_HORIZONTAL : false,
  MENU_ITEM_VERTICAL   : true,

  MENU_LAYER_SUFIX : "LYR",

  NOT_A_MAIN_ITEM : 1,
  
  MENU_REFRESH_TIME : 600
}

/** 
* NOF_Menu
*/
function NOF_Menu() {
  return this;
}


/** 
* NOF_Menu_Item
*/
function NOF_Menu_Item() {

  this.id           = arguments[0]; //div id

  this.orientation  = arguments[1];
  this.openEffect   = arguments[2];
  this.offsetX      = arguments[3];
  this.offsetY      = arguments[4];

  this.buttons = new Array();
  
  this.submenuHeight = 0;
  for (var i = 5; i < arguments.length; i++)
    this.buttons[i - 5] = arguments[i];


  this.getPosition = function () {
    return new Array(this.offsetX, this.offsetY);
  }


  this.getOffsetX = function getOffsetX() { return this.offsetX;}
  this.getOffsetY = function getOffsetY() { return this.offsetY;}
  this.getOpenEffect = function getOffsetY() { return this.openEffect;}
  this.getOrientation = function getOrientation() { return this.orientation; }

  return this;
}


/** 
@name NOF_Menu_Button
@parameter normal   : image name (src) or text (link value), depending on button type : image or text.
@parameter rollover : rollover image name or css attributes, depending on button type : image or text.
@parameter submenu  : a NOF_Menu_Item instance.
*/
function NOF_Menu_Button(link, normal, rollover, submenu) {

  this.link     = link;
  this.normal   = normal;
  this.rollover = rollover != "" ? rollover : normal;
  this.submenu  = submenu;

  this.hasSubmenu = function hasSubmenu() {
    return (this.submenu != null)
  }

  this.type = function type() {
    if (typeof(this.rollover) == "object")
      return CONSTANTS.BUTTON_TYPE_TEXT;
    else if (typeof(this.rollover) == "string")
      return CONSTANTS.BUTTON_TYPE_IMAGE;
    else 
      return null;
  }
  return this;
}


/** 
*@name NOF_Main_Menu
*@description Menu generation - HTML code insertion in page
*@parameter NOF_Menu_Item menuItem
*@parameter parentId (another NOF_Menu_Item) of NOF_Menu_Item menuItem
*/
function NOF_Main_Menu(menuItem, parentId) {

  if(typeof(menuItem) == "undefined")
    return;

  var menuItemId        = menuItem.id;
  var buffer            = browser.getMenuItemLayerStartString(menuItemId, parentId) + '<table width="10" border="' + C_MENU_BORDER + '" cellspacing="' + C_MENU_SPACING + '" cellpadding="0" bgcolor="' + C_MENU_BGCOLOR + '">';
  var i                 = 0;

  buffer += '<tr>';
  while (i < menuItem.buttons.length) {
    var menuButton      = menuItem.buttons[i];
    if (menuButton == null) // If page is excluded from navigation then  button is 'null'
      return;

    var submenuId = "";
 
    if (menuButton.hasSubmenu() && menuButton.submenu) {
      submenuId = menuButton.submenu.id;
    }

    var link            = menuButton.link; // Link to Page
    var image           = menuButton.normal; // Image - menu cell
    var rollOverButton  = menuButton.rollover; // Roll over image - loaded onmouseover, 
    var isImageMenu     = menuButton.type() == CONSTANTS.BUTTON_TYPE_IMAGE ? true : false;
    var imageName       = isImageMenu ? menuItemId + 's' + i : 'NavigationButton_' + menuItemId + '_' + i;
    var isVertical      = menuItem.orientation == "vertical" ? true : false;

    // Extract link target and href
    var target          = '';
    if (link.indexOf(' target=') != -1) {
      target            = link.substr(link.indexOf(' target=') + 8);
      link              = link.substr(0, link.indexOf(' target='));
    }

    // Append buttons on vertical or horizontal
    buffer += (isVertical && i > 1) ? '<tr><td>' : '<td>';

    // Append button link and mouse over event
    buffer += '<a style="text-decoration:none; cursor:hand;" href="' + link + '" ';
    buffer += 'onMouseOver="F_roll(\'' + imageName + '\' ,' + CONSTANTS.MOUSE_OVER_IMAGE + ', \'' + menuItemId + '\', \''+ 
                              CONSTANTS.NOT_A_MAIN_ITEM + '\')" onMouseOut="F_roll(\'' + imageName + '\' ,' + 
                              CONSTANTS.MOUSE_OUT_IMAGE + ', \''+menuItemId+'\', \'' + CONSTANTS.NOT_A_MAIN_ITEM + '\')"';

    // Append button link target
    buffer += target.length ? ' target="' + target + '">' : '>';   

    // If button is image then append <img> tag, otherwise append <div>
    buffer += isImageMenu ? '<img border="0" src="' + image + '"' : '<' + browser.getLayerTag() + ' ';

    if (typeof(rollOverButton) != "undefined" || rollOverButton.length || !isImageMenu) {
      // This item has a submenu
      if (submenuId != "") {
        var submenu = menuButton.submenu;
        if (isImageMenu) {
          buffer += 'id="' + imageName + '" name="' + imageName + 
                    '" onLoad="F_loadRollover(this,\'' + rollOverButton + '\', new Array(\'' + submenuId + '\',\'' + submenu.getOrientation() + '\' , \'' + submenu.getOpenEffect() + '\', ' + submenu.getOffsetX() + ',' + submenu.getOffsetY() + '))"';
        } else {
          NOF_MenuLoadRollOver(imageName, rollOverButton, new Array(submenuId, submenu.getOrientation(), submenu.getOpenEffect(), submenu.getOffsetX(), submenu.getOffsetY() ));          
          buffer += 'id="' + imageName + '" name="' + imageName + '" class="' + imageName +  '" ' ;

          // Text menu has inline css
          if (typeof(menuButton.rollover) == "object")
            buffer+= ' style="' + rollOverButton[0] + '"'; 
        }
      } 
      // No submenu, simple rollover
      else {
        if (isImageMenu)
          buffer += 'id="' + imageName + '" name="' + imageName + 
                    '" onLoad="F_loadRollover(this,\'' + rollOverButton + '\',0)"';
        else {
          NOF_MenuLoadRollOver(imageName, rollOverButton, 0);
          buffer += 'id="' + imageName + '" name="' + imageName + '" class="' + imageName + '" ';
          // Text menu has inline css
          if (typeof(menuButton.rollover) == "object")
            buffer+= ' style="' + rollOverButton[0] +'"';
        }
      }
    } 

    // For text buttons 'image' is the name appears on it. 
    buffer += isImageMenu ? '></a></td>' : 
                      '><' + browser.getLayerTag() + ' id="' + imageName + '_padding" style="padding:' + rollOverButton[1] + '" padding="' + rollOverButton[1] + '" paddingOver="' + rollOverButton[3] + '">'  + image + 
                      '</' + browser.getLayerTag() + '></' + browser.getLayerTag() + '></a></td>'; 
    buffer += isVertical ? "</tr>" : "";

    i++; 
  }

  buffer += CONSTANTS.MENU_TABLE_END + browser.getMenuItemLayerEndString();
  document.writeln(buffer);  

  var k = 0;
  while (k < menuItem.buttons.length) {
    if (menuItem.buttons[k].hasSubmenu()) {
      NOF_Main_Menu(menuItem.buttons[k].submenu, menuItem.id);      
    }
    k++;
  }
}



/** 
*@name NOF.MenuLoadRollOverImage
*@parameter button:
*@parameter buttonName: 
*@parameter submenu: Array(int offsetX, int offsetY, String submenuId, boolean ??).
*/
function NOF_MenuLoadRollOver(button, buttonName, submenu) {

  // Check if button is image
  if (button && button.src &&
          (null == button.out || typeof(button.out) == typeof(void(0)))) {


    var imageSrc   = button.src;
    button.out     = new Image();
    button.out.src = imageSrc;
    button.over    = new Image();


    if (buttonName.lastIndexOf('/') >= 0 || buttonName.lastIndexOf('\\') >= 0) {
      imageSrc = buttonName;
    } else {
      var i = imageSrc.lastIndexOf('/');
      if (i < 0) 
          i = imageSrc.lastIndexOf('\\');
      if (i < 0)
          imageSrc = buttonName;
      else   
          imageSrc = imageSrc.substring(0, i + 1) + buttonName;
    }

    button.over.src                  = imageSrc;
    button.submenu                   = submenu;   
    GLOBAL_LoadedImages[button.name] = button;

  // Button is text
  } else {    
      if (typeof(buttonName) == "object") {
        if (typeof(GLOBAL_LoadedImages[button]) == "undefined") {
          GLOBAL_LoadedImages[button + "Normal"]  = buttonName[0];
          GLOBAL_LoadedImages[button + "Over"]    = buttonName[2];  
          GLOBAL_LoadedImages[button]             = submenu;  
        }
        return;
      }
      if (typeof(submenu) != "undefined"  && typeof(button) == "string" && typeof(GLOBAL_LoadedImages[button]) == "undefined") 
          GLOBAL_LoadedImages[button]  = submenu;           
  }
}


/** 
*@name NOF.MenuRollButton
*@description Show rollover cell
*@parameter buttonName: image name
*@parameter over: 1 means mouse over (load rollverimage) , 0 means mouseout (load original image).
*/
function NOF_MenuRollButton(buttonName, over, layerId, isNotMainItem) { 

    var rollType    = (over == CONSTANTS.MOUSE_OVER_IMAGE) ? "over" : "out"; // Defined in NOF_MenuLoadRollOver
    var isOver      = (over == CONSTANTS.MOUSE_OVER_IMAGE) ? true : false;
    var rollOver    = GLOBAL_LoadedImages[buttonName];
  
    if (typeof(rollOver) == "undefined")
      return;
  
    var menuType = typeof(rollOver.src) == "undefined" ? CONSTANTS.MENU_TYPE_TEXT : 
                                                         CONSTANTS.MENU_TYPE_IMAGE;
    
    if (menuType == CONSTANTS.MENU_TYPE_IMAGE) { // Image menu
      var imageRollSrcString  = "rollOver." + rollType + ".src"; 
      if (rollOver) 
         rollOver.src = eval(imageRollSrcString) ? eval(imageRollSrcString) : "";     
    
    } else if (menuType == CONSTANTS.MENU_TYPE_TEXT){ // Text menu             
        if (typeof(buttonName) == "string") {
          browser.getItem(buttonName).className = isOver ? buttonName + "Hover" : buttonName;
      
          if (browser.getItem(buttonName + "_padding")){
              browser.getItem(buttonName + "_padding").style.padding = isOver ? 
                              browser.getItem(buttonName + "_padding").paddingOver : 
                              browser.getItem(buttonName + "_padding").padding;
          }
  
          if (typeof(browser.getItem(buttonName).style) != "undefined")
            browser.getItem(buttonName).style.cssText = isOver ? 
                            GLOBAL_LoadedImages[buttonName + "Over"] : 
                            GLOBAL_LoadedImages[buttonName + "Normal"]; 
        }
  
    } else // Undefined menu type
        return;
  
    if ((isNotMainItem == null || typeof(isNotMainItem) == "undefined" ) && over == CONSTANTS.MOUSE_OUT_IMAGE) {   
      GLOBAL_CurrentItem = "";
      GLOBAL_items.removeAll();    
    }
      
    var hasSubmenu = null;
    if (menuType == CONSTANTS.MENU_TYPE_IMAGE)
      hasSubmenu = rollOver.submenu;
    else if (menuType == CONSTANTS.MENU_TYPE_TEXT)
      hasSubmenu = typeof(rollOver) == "object";
  
    if (hasSubmenu) {
      if (over == CONSTANTS.MOUSE_OVER_IMAGE) {
        if ( layerId && typeof(layerId) != "undefined" && layerId != "null") {
          if (GLOBAL_Close != null)
            clearTimeout(GLOBAL_Close);
          GLOBAL_items.removeSubitems(layerId + CONSTANTS.MENU_LAYER_SUFIX);
        } else
          GLOBAL_items.removeAll();
  
        if (menuType == CONSTANTS.MENU_TYPE_IMAGE)
          NOF_MenuOpenItem(rollOver, rollOver.submenu, layerId);
        else
          NOF_MenuOpenItem(buttonName, rollOver, layerId); 
      }
      else { // MOUSE_OUT_IMAGE
        if (menuType == CONSTANTS.MENU_TYPE_IMAGE)
          NOF_MenuCloseItem(rollOver.submenu);
        else
          NOF_MenuCloseItem(rollOver);
      }
    
    } else if (over == CONSTANTS.MOUSE_OVER_IMAGE ) { // This image doesn't have a submenu, only a rollover button      
        if ( layerId && typeof(layerId) != "undefined" && layerId != "null" ) {
          GLOBAL_CurrentItem = layerId + CONSTANTS.MENU_LAYER_SUFIX;
          GLOBAL_items.removeSubitems(GLOBAL_CurrentItem);
        } else // Only for html - always visible - menu part        
            browser.hideMenuItem(GLOBAL_CurrentItem);
    }
}


/** 
*@name NOF.MenuOpenItem
*@description Opens (visibility = 'visible') one menu item
*@parameter image Image object that is parent for this submenu
*@parameter imageSubmenu : Array(offset, layerId, horizontal) :
*      offsetX - distance from parent left
*      offsetY - distance from parent top
*      layerId - layer ID that will be opened
*      horizontal - indicates if it's horizontal or vertical. True = vertical, False = horizontal
*@parameter parentId
*@parameter
*/
function NOF_MenuOpenItem(image, submenu, parentId) {

  var layerId       = submenu[0] + CONSTANTS.MENU_LAYER_SUFIX; 
  var orientation   = submenu[1];
  var openEffect    = submenu[2];
  var offsetX       = submenu[3];
  var offsetY       = submenu[4];

  GLOBAL_items.addItem(layerId, parentId);
  GLOBAL_CurrentItem = layerId; // Current opened layer 

  browser.showMenuItem(image, layerId, offsetX, offsetY, openEffect);
}


/** 
*@name NOF.MenuCloseItem
*@description Close a menu item if mouse is out of it but not on his child.
*@parameter
*/
function NOF_MenuCloseItem(imageSubmenu) {

  if (imageSubmenu[0]) {
    var layerId  = imageSubmenu[0] + CONSTANTS.MENU_LAYER_SUFIX; 
  
    // If mouse outside a cell that belongs to main menu (root) - close it
    if (GLOBAL_items.toArray().length == 1)
      GLOBAL_CurrentItem = 0;
  
    GLOBAL_Close = setTimeout("NOF_MenuHideItem('" + layerId + "')", CONSTANTS.MENU_REFRESH_TIME/4);
  }
}


/** 
*@name NOF.MenuHideItem
*@description 
*@parameter itemId 
*/
function NOF_MenuHideItem(itemId) {

  if (itemId && itemId != null && GLOBAL_CurrentItem != itemId) { // Close item if mouse not over it
    browser.hideMenuItem(itemId);
  }
}


/** 
*@name NOF_KeepOpen
*@description Keeps a menu item (child) opened when mouse over it
*@parameter item Layer (Div) object
*/
function NOF_KeepOpen(itemId, parentId) {    

  GLOBAL_CurrentItem = itemId;
  if (GLOBAL_Hide != null)
    for (var i = 0; i < GLOBAL_Hide.length; i++)  
      clearTimeout(GLOBAL_Hide[i]);
}


/** 
*@name NOF_KeepClose
*@description Keeps a menu item (child) closed when mouse out of it
*/
function NOF_KeepClose() {  

  GLOBAL_CurrentItem = "";
  setTimeout("NOF_CloseChilds()", CONSTANTS.MENU_REFRESH_TIME);
}


/** 
*@name NOF_CloseChilds
*@description Close submenus when mouse goes out of layer
*/
function NOF_CloseChilds() {

  var itemsList = GLOBAL_items.toArray();
  GLOBAL_Hide   = new Array();  
  if (GLOBAL_CurrentItem == "" || GLOBAL_CurrentItem == 0)    
    for (var i in itemsList)
      if (itemsList[i])
        GLOBAL_Hide[i] = setTimeout("browser.hideMenuItem('" + itemsList[i] + "')", CONSTANTS.MENU_REFRESH_TIME/4);               

  if (!isMenuAutoClose()) {
    itemsList = GLOBAL_items.toArray();

    // Keep visible current opened submenus
    for ( var i in itemsList ) 
      if (itemsList[i])
        NOF_KeepOpen(itemsList[i]);      
  }  
}

function isMenuAutoClose() {

  var itemsList = GLOBAL_items.toArray();
  if  (itemsList[0] && itemsList[0].length) {
   var autoClose = browser.getItemAttribute(itemsList[0], "isautoclose");
     if ( autoClose == "true")
       return true;
     else 
       return false;
  }
  return false;   
}

/**
*@name HideMenu()
*@description Hide menu when click outside his area. Used in 'Non auto close navbars'.
*/
function HideMenu() {
  
  if (isMenuAutoClose())
    return;

  var itemsList = GLOBAL_items.toArray();

  if (GLOBAL_Hide == null)
    GLOBAL_Hide = new Array();
 
  for (var i in itemsList)
    if (itemsList[i] && itemsList[i].length) {
      GLOBAL_items.removeItem(itemsList[i]);     
      GLOBAL_Hide[i] = browser.hideMenuItem(itemsList[i]);        
    }
}


/**
*@name NOF_OpenedItems()  
*@description Keeps a list w/ current submenus open (visible)
*/
function NOF_OpenedItems() {

  this.openedItems = "";
  this.separator   = "*";

  /** method addItem
  *@description: adds one item in list using "*" separator
  */
  this.addItem = function addItem(item, parent) {

    if ( item == null || !item || item == "" )
      return;
  
    if (this.openedItems.indexOf(item) == -1) {

      this.openedItems += this.openedItems.length ? 
          ( this.openedItems.indexOf(this.separator) == this.openedItems.length - 1 ? "" : this.separator ) + item : 
          item;    
    }   
  }
  

  /** method removeItem
  *@description: remove one item
  */
  this.removeItem = function removeItem(item) { 
   
    if ( item == GLOBAL_CurrentItem )
      return;

    var temp = this.openedItems;
    if (temp.indexOf(item) > 0) {
      var a = temp.substring(0, temp.indexOf(item));
      var b = temp.substring(temp.indexOf(item) + item.length, temp.length );
      temp = a + b;
    }

    while (temp.lastIndexOf(this.separator) == temp.length - 1)
      temp = temp.substring(0, temp.length - 1);

    this.openedItems = temp;   
  }


  /** method removeSubitems
  *@description: remove all subitems (items above) 'item' 
  */
  this.removeSubitems = function removeSubitems(item) {
    
    if (item && typeof(item) != "undefined") {    
      var temp  = this.openedItems;
      temp      = temp.substring(0, temp.lastIndexOf(item) + item.length);  
      var temp1 = this.openedItems.substring(this.openedItems.indexOf(temp) + temp.length, this.openedItems.length);
      temp1 = temp1.split(this.separator);
  
      for (var i =  temp1.length - 1; i >= 0; i--)
         if (temp1[i])
           browser.hideMenuItem(temp1[i]);
  
      this.openedItems = temp;
    }
  }

  /** method currentItem
  *@description: return current item
  */
  this.currentItem = function currentItem() {

    var list = this.toArray();
    return list[list.length - 1];
  }

  /** method removeAll
  *@description: remove all items and hide them
  */
  this.removeAll = function removeAll() {

    var items = this.toArray();
    clearTimeout(GLOBAL_Close);
    for (var i = items.length - 1; i >= 0; i--)
      if ( items[i] != null && items[i] != "" ) {
        clearTimeout(items[i]);
        browser.hideMenuItem(items[i]);
      }

    this.openedItems = "";    
  }

  /** method toArray
  *@description: return an array with all items using split method by list separator
  */
  this.toArray = function toArray() {
    return this.openedItems.split(this.separator);
  }  
}


/**
*@name F_menu()
*@description backward compatibility
*/
function F_menu(item) {
  NOF_Menu(item);
}

/**
*@name F_roll()
*@description backward compatibility
*/
function F_roll(itemId, over, layerId, isNotMainItem){

  var layerId = (layerId == null || typeof(layerId) == "undefined") ? null : layerId;
  var isNotMainItem = (isNotMainItem == null || typeof(isNotMainItem) == "undefined") ? null : isNotMainItem;

  NOF_MenuRollButton(itemId, over, layerId, isNotMainItem);
}

/** F_loadRollover
*@param image
*@param submenu: Array(String submenuId, submenuOrientation, int offsetX, int offsetY).
*/
function F_loadRollover(image, rollOverButton, submenu) { 
  return NOF_MenuLoadRollOver(image, rollOverButton, submenu);
}

