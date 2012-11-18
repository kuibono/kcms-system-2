// JavaScript Document by:yes7
//获得鼠标坐标值
function mouseCoords(e) {
  if (e.pageX || e.pageY) {
    return {
      x: e.pageX,
      y: e.pageY
    };
  }
  return {
    x: e.clientX + document.body.scrollLeft - document.body.clientLeft,
    y: e.clientY + document.body.scrollTop - document.body.clientTop
  };
  return false;
}

function ForDight(Dight, How) {
  Dight = Math.round(Dight * Math.pow(10, How)) / Math.pow(10, How);
  return Dight;
}
var timer;
function StopScroll() {
	clearInterval(timer);
}
function BeginScroll() {
	timer = setInterval("Scrolling()", $.cookie("ya55_speed"));
}
function setSpeed(o) {
	$.cookie("ya55_speed", o);
}
function Scrolling() {
	currentpos = document.documentElement.scrollTop;
	window.scroll(0, ++currentpos);
	if (currentpos != document.documentElement.scrollTop) {
		clearInterval(timer);
	}
}

function setBG(o) {
  $("#content").css('backgroundColor', o);
  $.cookie("ya55_background", o);
}

function setFontColor(o) {
  $("#content").css("color", o);
  $.cookie("ya55_fontColor", o);
}

function setFontCookie(fs,fb) {
  $.cookie("ya55_fontSize", fs);
  $.cookie("ya55_fontBar",fb);
}

function setStyle(o) {
  if (o == '0') {
    $("#wrap").width(950);
  } else if (o == '1') {
    $("#wrap").width(document.body.clientWidth - 20);
  };
  $("#style"+o).val(o);
  $.cookie("ya55_style", o);
}
$(function() {
  $("body").click(function(){ StopScroll(); }).dblclick( function(){ BeginScroll(); });
  if ($.cookie("ya55_background")) {
    setBG($.cookie("ya55_background"));
  }
  if ($.cookie("ya55_fontColor")) {
    setFontColor($.cookie("ya55_fontColor"));
    $("#txtcolor").val($.cookie("ya55_fontColor"));
  }
  if ($.cookie("ya55_fontSize")) {
	var fontSize = $.cookie("ya55_fontSize");
	var fontBar = $.cookie("ya55_fontBar");
    $("#fontWidth").css({width:fontBar+"px"});
    $("#fontBtn").css({marginLeft:fontBar+"px"});
    $("#content").css({fontSize: fontSize+"px"});
    $("#fontVal").text(fontSize).css({marginLeft:(fontBar-3)+"px"});
  }
  if ($.cookie("ya55_style")) {
    setStyle($.cookie("ya55_style"));
  }
  if ($.cookie("ya55_speed")) {
    $("#sudu a").removeClass("this");
	$("#sudu"+$.cookie("ya55_speed")).addClass("this");
  }
  $("#sudu a").click( function(){
    $("#sudu a").removeClass("this");
	$(this).addClass("this");
  });
  $("#fontBtn").mousedown(function() {
    $(".setFont").mousemove(function(ev) {
      ev = ev || window.event;
      var e = mouseCoords(ev);
      var eX = e.x;
      var offset = $(this).offset();
      var sWidth = (eX - offset.left);
      var w = sWidth;
      var btnLeft = sWidth;
      if (w <= 93) {
        if (w <= 8) {
          w = 0;
          btnLeft = w;
        } else {
          btnLeft = (w - 8);
        }
      } else if (w > 93) {
        w = 85;
        btnLeft = w;
      };
      $("#fontBtn").css("margin-left", btnLeft);
      $("#fontVal").css("margin-left", btnLeft - 3);
      $("#fontWidth").width(btnLeft);
      var forSize = ForDight(sWidth / 10, 0);
      var fontSize = (forSize + 12);
      $("#fontVal").html(fontSize);
      $("#content").css("fontSize", fontSize);
    }).mouseout(function() {
      $(this).unbind("mousemove");
      var fs = $("#fontVal").text();
      var fb = $("#fontWidth").width();
      setFontCookie(fs,fb);
    });
  }).mouseup(function() {
    $(".setFont").unbind("mousemove");
      var fs = $("#fontVal").text();
      var fb = $("#fontWidth").width();
      setFontCookie(fs,fb);
  })
})