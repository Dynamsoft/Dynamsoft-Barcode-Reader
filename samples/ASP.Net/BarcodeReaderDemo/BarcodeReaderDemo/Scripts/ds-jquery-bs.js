/*JavaScript Document*/
(function ($) {
/*drop down menu*/
$.fn.clickhide = function (options) {
	/*default configuration properities*/
	var defaults = {
		_clickOrHover: "click",/*click&&mouseenter*/
		_slideOrShow: "slide",
		_switchSpeed: " ",
		_documentClick: "true",
		_rootObjID: "#rootObjID",
		_toggleNode: ".toggleNode",
		_operateNode: ".operateNode",
		_currentTabClass: "currentTabClass",
		handler: null
	};
	var options = $.extend(defaults, options);
	var operateNode = $(options._rootObjID).find(options._operateNode);
	$(options._rootObjID).find(options._toggleNode).each(function(index, element) {   
       $(this).bind(options._clickOrHover, function (e) {   
	      $(options._toggleNode).not(this).removeClass(options._currentTabClass);
	      $(this).toggleClass(options._currentTabClass);
		  operateNode.eq(index).toggleClass('on');/*filter options._operateNode*/
	      if(options._slideOrShow == 'slide'){
		     operateNode.not('.on').slideUp(options._switchSpeed);
		     operateNode.eq(index).slideToggle(options._switchSpeed); 
	      }else if(options._slideOrShow == 'show'){
		     operateNode.not('.on').hide(options._switchSpeed);
		     operateNode.eq(index).toggle(options._switchSpeed);
		   }
		   operateNode.eq(index).removeClass('on');
	  });
	});
	$(document).click(function(){
		if(options._documentClick == 'true'){
			$(options._toggleNode).removeClass(options._currentTabClass);
		    if(options._slideOrShow == 'slide'){
		       operateNode.slideUp();
		      }else if(options._slideOrShow == 'show'){
			   operateNode.hide();
			  }
		}
	});
	$(options._toggleNode).bind(options._clickOrHover,function(e){
		stopPropagation(e);
	});
	
}
/*hover-change-image-src*/
$.fn.extend({
	hoverChangeSrc:function(e){ 
		var curSrc1,curSrc2;
	 $(this).hover(function(){
		var curSrc = $(this).attr('src');
		var curSrcString = String(curSrc);
		 curSrc1 = curSrcString.slice(0,curSrcString.length-4);
		 curSrc2 = curSrcString.slice(-4);
		$(this).attr('src',curSrc1+'-hover'+curSrc2);
		},
		function(){
			$(this).attr('src',curSrc1+curSrc2);
			});	
	
			}
});

})(jQuery);

window.onload = function (){
	/*Compatible -- click document to hide headerNav*/
	/*devic-type*/
	if(browserRedirect() != 'pc'){
		$("#main").css('cursor','pointer');
	    $(document).click(function(){
		   $("#nav970 .nav970-secondary").removeClass("active");
		   $("#overall-nav .ct-nav li").removeClass("active");
	      });
	    $("#overall-nav .ct-nav li").bind('click',function(e){
		   stopPropagation(e);
	    });
	}
}

$(function () { $("[data-toggle='tooltip']").tooltip(); });

$(function(){	
	/*nav-360*/
	$(".clicked-360nav > li > a").click(function() {
		    var curindex = $(this).parent().index();
			$("#nav360 .nav360-secondary .subNav360").slideUp();
			$("#nav360 .nav360-secondary .xs-active").removeClass('xs-active');
			$(".clicked-360nav > li > a").removeClass('xs-active');
			$(this).addClass('xs-active');
			$("#nav360 .nav360-secondary").removeClass('xs-active');
			$("#nav360 .nav360-secondary").eq(curindex).addClass('xs-active');
	});
	$("#nav360 .nav360-secondary > li > a").click(function() {
			$(this).parent().siblings().find('ul').slideUp();
			$(this).parent().siblings().find('a').removeClass('xs-active');
			$(this).next('ul').slideToggle();
			$(this).toggleClass('xs-active');
	});
	$("#overall-header360 .toggle-nav360").click(function() {
            $("#header360-clicked").slideToggle();
			$("#overall-header360 .xs-active").removeClass('xs-active');
			$("#nav360 .nav360-secondary .subNav360").slideUp();
			$("#overall-header360 .clicked-360nav li:first").find('a').addClass('xs-active');
			$("#nav360 .nav360-products").addClass('xs-active');
	});
	
    /*nav-750*/
	$("#header750-clicked-content li").click(function() {
		    var curindex = $(this).index();
			$("#header750-clicked-content li").removeClass('sm-active');
			$(this).addClass('sm-active');
			$("#nav970 .clicked-750").removeClass('sm-active');
			$("#nav970 .clicked-750").eq(curindex).addClass('sm-active');
	});
	$("#overall-header750 .toggle-nav750").click(function() {
		var clicked750 = $("#header750-clicked").css('display');
		 if(clicked750=='none'){
		    $("#header750-clicked").slideDown();
			setTimeout (function(){$("#nav970 .nav970-products").addClass('sm-active');},300)
			$("#header750-clicked-content li").removeClass('sm-active');
			$("#header750-clicked-content li:first").addClass('sm-active');
		 }else {
			 $("#header750-clicked").slideUp(300);
			 $("#nav970 .clicked-750").removeClass('sm-active');
			 }
			
	});
	
	/*nav970*/  
    var timeoutLeaveNavLi;
	var timeoutLeaveNavSecondary;
	var timeoutLeaveNav;
    $("#overall-nav .ct-nav li").hover(function() {
		    var curindex = $(this).index();
            var targetToggler = $(this);
            var targetSubNav = $("#nav970 .nav970-secondary").eq(curindex);
			clearTimeout(timeoutLeaveNavSecondary);
            if ($("#overall-nav .ct-nav .active").length == 0) {
                targetSubNav.addClass('active');
                targetToggler.addClass("active");
            } else {
               timeoutLeaveNavLi = setTimeout(function() {
                    $("#overall-nav .ct-nav .active").removeClass("active");
                    targetSubNav.addClass('active');
					targetSubNav.siblings().removeClass("active");
                    targetToggler.addClass("active");
                }, 300);
            }
        },
        function() {
            clearTimeout(timeoutLeaveNavLi);
        });
	$("#overall-nav .ct-nav").mouseleave(function(){
		timeoutLeaveNav = setTimeout(function() {
			$("#nav970 .nav970-secondary").removeClass("active");
            $("#overall-header970 .active").removeClass("active");
			},300);
		});
    $("#nav970 .nav970-secondary").hover(function(){
		  clearTimeout(timeoutLeaveNav);
		  clearTimeout(timeoutLeaveNavLi);
		},
		function(){
		  timeoutLeaveNavSecondary = setTimeout(function() {
			$("#nav970 .nav970-secondary").removeClass("active");
            $("#overall-header970 li").removeClass("active");
		  },300);
			});
	
	/*== subNav  ==*/
	$("#subNav").clickhide({
		_rootObjID: "#subNav",
		_toggleNode: ".dropdown-toggle",
		_operateNode: ".subNav-ct-more",
		_currentTabClass: "on",
	});
	/*== xsNav  ==*/
	$("#xsNav").clickhide({
		_rootObjID: "#xsNav",
		_toggleNode: ".dropdown-toggle",
		_operateNode: ".subNav-ct-more",
		_currentTabClass: "on",
	});
	
	/*window - resize*/
	$(window).resize(function(){
		var screenWidth = $(window).width();
		if(screenWidth > 768){
			/*window.location.reload();
			$("#header360-clicked").hide();*/
			}else if(screenWidth > 992){
				$("#header750-clicked").hide();
			    $(".clicked-750").removeClass('sm-active');
				}
		});
		
	/*toTop && sunNav-scroll-fixed*/
    $("#toTop").hide();
	$(window).scroll(function(){
	   var windowScTop = $(window).scrollTop();
	   if (windowScTop>90){
			var subNavPs=$("#subNav").css('position');
			var subNavDis=$("#subNav").css('display');
			if(subNavPs=='relative'&&subNavDis=='block'){
			$("#subNav").addClass('subNav-fixed');
			$("#header").css({"padding-bottom":"60px"});
			}
			$("#toTop").fadeIn();
			$("#cookie-warn").css({"position":"absolute"});
			$("#cookie-warn").animate({top:'-500px'},800);
		}else{
			$("#header").css({"padding-bottom":""});
			$("#subNav").removeClass('subNav-fixed');
			$("#toTop").fadeOut();
			$("#cookie-warn").css({"position":"",'top':''});
		}
	});
	$("#toTop").click(function(){
			$('body,html').animate({scrollTop:0},500);
			return false;		
         });
		
});

$(function() {
	/*cookie-warn*/
    var cookiewarn = $("<div>").attr('id','cookie-warn').insertBefore($("#wrapper"));
	var cookieinner = $("<div>").addClass("container pr").appendTo(cookiewarn);
	var cookietext = $("<p>").attr('id','cookie-warn-text').appendTo(cookieinner);
    cookietext.html("We use cookies to study how our website is being used. You consent to our cookies if you continue to use this website.");
	var cookieclose = $("<img>").attr('id','warn-close').attr('src','http://www.dynamsoft.com/assets/img-icon/icn-close-20x20.png').appendTo(cookieinner);
	$("#warn-close").click(function(){
		$("#cookie-warn").hide();
		});
	function count() {
	   var now = new Date();
	   now.setTime(now.getTime() + 7*24*60*60*1000);
	   var visits = Cookie("cookie-warn-count");
	   if( !visits ){
	       visits = 1;
	      }else {
	        visits = parseInt(visits)+1;
	           }
	   setCookie("cookie-warn-count",visits,now,'/');
	   return visits;
	}
	function start() {
	
	  if(count()>1) {
	       $("#cookie-warn").fadeOut();
	    } else {
	       $("#cookie-warn").fadeIn();
	      }
    }
	start();		
	
});

$(function() {
// popup div
	//select all the a tag with name equal to modal
    $('a[name=modal]').click(function(e) {
		var id = $(this).attr('href');
		popup(id, e);
		$('#mask').show();	
	});
	//if close button is clicked
    $('.window .close').click(function (e) {
		//Cancel the link behavior
		e.preventDefault();
		$('#mask').hide();
		$('.window').hide();
	});		
	//if mask is clicked
    $('#mask').click(function () {
		$(this).hide();
		$('.window').hide();
	});	
	
	$(window).resize(function () {	 
 		resizeWindow();
	});		
});

/*popup div*/
function popup(id, e) {
	/*Cancel the link behavior*/
    if ( e && e.preventDefault ){
					 e.preventDefault();
                   } else {
					 window.event.returnValue = false;
                   }
	/*Get the screen height and width*/
    var maskHeight = $(document).height();
    var maskWidth = $(window).width();
	/*Set heigth and width to mask to fill up the whole screen*/
    $("#mask").css({
        "width": maskWidth,
        "height": maskHeight
    });
	/*Get the window height and width*/
    var winH = $(window).height();
    var winW = $(window).width();
	/*Set the popup window to center*/
    $(id).css("top", winH / 2 - $(id).height() / 2);
    $(id).css("left", winW / 2 - $(id).width() / 2);
	/*transition effect*/
    $(id).fadeIn(500);
}
function resizeWindow() {
    var box = $(".window");
	/*Get the window height and width*/
    var winH = $(window).height();
    var winW = $(window).width();
	/*Set the popup window to center*/
    box.css("top", winH/2 - box.height()/2);
    box.css("left",winW /2 - box.width()/2);
}

/*cookie operation*/
var expdate= new Date();
function getCookieVal (offset) {
 var endstr = document.cookie.indexOf (";", offset);
 if (endstr == -1) endstr = document.cookie.length;
 return unescape(document.cookie.substring(offset, endstr));
}
function Cookie (name) {
 var arg = name + "=";
 var alen = arg.length;
 var clen = document.cookie.length;
 var i = 0;
 while (i < clen) {
  var j = i + alen;
  if (document.cookie.substring(i, j) == arg) return getCookieVal (j);
  i = document.cookie.indexOf(" ", i) + 1;
  if (i == 0) break;
 }
 return null;
}
function setCookie (name,value,expires,path,domain,secure) {
 expdate.setTime(expdate.getTime() + (24*60*60*1000*365));
 document.cookie = name + "=" + escape (value) +
 ((expires) ? "; expires=" + expires.toGMTString() : "") +
 ((path) ? "; path=" + path : "") +
 ((domain) ? "; domain=" + domain : "") +
 ((secure) ? "; secure" : "");
}
function deleteCookie(name) { 
 expdate = new Date(); 
 expdate.setTime(expdate.getTime() - (86400 * 1000 * 1)); 
 setCookie(name, "", expdate); 
}

/*event bubble*/
function stopPropagation(e) {
	if (e.stopPropagation)
		e.stopPropagation();
	else
		e.cancelBubble = true;
}

/*device - Type*/
function browserRedirect() {
	var deviceType;
	var sUserAgent = navigator.userAgent.toLowerCase();
	var bIsIpad = sUserAgent.match(/ipad/i) == "ipad";
	var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
	var bIsMidp = sUserAgent.match(/midp/i) == "midp";
	var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
	var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
	var bIsAndroid = sUserAgent.match(/android/i) == "android";
	var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
	var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile"; 
	if (bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM) {
		deviceType = 'phone'; 
	} else {
		deviceType = 'pc'; 
	}
	return deviceType;
}

// easy tooltip
(function($) {

	$.fn.easyTooltip = function(options){
	  
		// default configuration properties
		var defaults = {	
			xOffset: 10,		
			yOffset: 25,
			tooltipId: "easyTooltip",
			clickRemove: false,
			content: "",
			useElement: ""
		}; 
			
		var options = $.extend(defaults, options);  
		var content;
				
		this.each(function() {  				
			var title = $(this).attr("title");				
			$(this).hover(function(e){											 							   
				content = (options.content != "") ? options.content : title;
				content = (options.useElement != "") ? $("#" + options.useElement).html() : content;
				$(this).attr("title","");									  				
				if (content != "" && content != undefined){			
					$("body").append("<div id='"+ options.tooltipId +"' class=''>"+ content +"</div>");		
					$("#" + options.tooltipId)
						.css("position","absolute")
						.css("top",(e.pageY - options.yOffset) + "px")
						.css("left",(e.pageX + options.xOffset) + "px")						
						.css("display","none")
						.fadeIn("fast")
				}
			},
			function(){	
				$("#" + options.tooltipId).remove();
				$(this).attr("title",title);
			});	
			$(this).mousemove(function(e){
				$("#" + options.tooltipId)
					.css("top",(e.pageY - options.yOffset) + "px")
					.css("left",(e.pageX + options.xOffset) + "px")					
			});	
			if(options.clickRemove){
				$(this).mousedown(function(e){
					$("#" + options.tooltipId).remove();
					$(this).attr("title",title);
				});				
			}
		});	  
	};		
})(jQuery);