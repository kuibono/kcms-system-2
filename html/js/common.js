// JavaScript Document
/**
 * 百伯全局函数
 * @type {Object}
 */
var baijob = {
    domain : 'http://'+document.domain+'/',
    cookie_domain : '.baijob.com',
    cookie_prefix : '',
    setCookie:	function(name ,val ,extime , domain)
    {
        var exdate = new Date();
        var extime = extime ? extime :  12 * 30 * 24 * 60 * 60 * 1000;
        exdate.setTime(exdate.getTime() + extime);
        name = this.cookie_prefix + name;
        var domain = domain ? domain : this.cookie_domain;
        document.cookie = name + "=" + val + ";expires=" + exdate.toGMTString()+";domain="+this.cookie_domain+";path=/";
    },
    getCookieVal:	function(offset)
    {
        var endstr = document.cookie.indexOf (";", offset);
        if (endstr == -1)
            endstr = document.cookie.length;
        return unescape(document.cookie.substring(offset, endstr));
    },
    getCookie:	function(name)
    {
        var arg = this.cookie_prefix + name + "=";
        var alen = arg.length;
        var clen = document.cookie.length;
        var i = 0;
        while (i < clen)
        {
            var j = i + alen;
            if (document.cookie.substring(i, j) == arg)
                return this.getCookieVal (j);
            i = document.cookie.indexOf(" ", i) + 1;
            if (i == 0) break;
        }
        return null;
    },
    delCookie:	function(name,domain)
    {
        var domain = domain ? domain : this.cookie_domain;
        this.setCookie(name ,'' ,-1 , this.cookie_domain);
    }
}

var errmsgcode = -1;
$(function(){
//头部个人信息隐藏显示 
useBox();

function useBox(){
	var s = null;
	var isFocus =0;
	$('.user').hover(function(){   
		isFocus =1;
		$(this).find('.dropdown-box').show();
	},function(){
			var $this = $(this);
			isFocus =0;
			setTimeout(function(){
			if(isFocus==0){$this.find('.dropdown-box').hide();$('.tipBox').hide();}		
			},1000);
	})
	
	$('.tipBox').live('mouseover',function(){isFocus =1;});
}

//初始化input提示
$("input[type='text'],textarea").each(function(){
	if($(this).val()==""||$(this).val()==$(this).attr("placeholder")){
		$(this).val($(this).attr("placeholder"));
		$(this).css("color","#adadad");
	}
})
if($.browser.msie){
	$("input[type='password']").each(function(i,item){
		if($(item).attr('placeholder')){
			var p={
				$la : $("<label class='pwdholder'>"+$(item).attr('placeholder')+"</label>"),
				_t : $(item).offset().top + 5,
				_l : $(item).offset().left +7
			}
			if(!$(item).is(':visible')){
				$(item).parent().addClass('pos-r');
				p.$la.insertBefore($(item)).css({position:"absolute",left:p._l,top:p._t,display:"block",color:"#ADADAD"});
			}else{
				p.$la.appendTo($(document.body)).css({position:"absolute",left:p._l,top:p._t,display:"block",color:"#ADADAD"});
			}
			$(item).focus(function(){
				p.$la.hide();
			});
			$(item).blur(function(){
				if($(item).val()=== $(item).attr('placeholder')||$(item).val()==""){
					p.$la.show()
				}
			})
		}
	
	})
}

//鼠标经过技能框效果
	$("input[type='text'],input[type='password'],textarea").live('focus',function(){
		$(this).clearQueue();
		$(this).stop();
		$(this).addClass("active_t");
		$(this).css({
					"color":"",
					"box-shadow":"0 0 3px #08c",
					"border-color":"#08c"
					});
		if($(this).val()==$(this).attr("placeholder")){
			$(this).val("");
		}
	})

	$("input[type='text'],input[type='password'],textarea").live('blur',function(){
		$(this).removeClass("active_t");
		$(this).css({
					"box-shadow":"",
					"border-color":""
					});
		if($(this).val()==""||$(this).val()==$(this).attr("placeholder")){
			if(!$(this).is(':password')){
				$(this).val($(this).attr("placeholder"));
			};
			$(this).css("color","#adadad");
		}
	})
//鼠标经过按钮高亮
/*	$(":button,:submit,.btn218_48,.btn73_24,.btn52_20").hover(function(){
		if($(this).is(':visible')){$(this).fadeTo("fast", 0.8)}
	},function(){
		if($(this).is(':visible')){$(this).fadeTo("fast", 1)}
		
	});*/
//鼠标经过按钮加深
	/*if($(".hideIn").is(':visible')){$(".hideIn").css('opacity', 0.75)}
	$(".hideIn").hover(function(){
		if($(this).is(':visible')){$(this).fadeTo("fast", 1)}
	},function(){
		if($(this).is(':visible')){$(this).fadeTo("fast", 0.75)}
		
	});
*/
})

var $_ScrollBot = {};
$_ScrollBot.scrollHeight;
//屏幕滚动
$_ScrollBot.pageScroll = function(){
    if(jQuery.browser.mozilla || jQuery.browser.msie){
        window.scrollBy(0,-20);
        scrolldelay = setTimeout('$_ScrollBot.pageScroll()',1);
        if(document.documentElement.scrollTop < $_ScrollBot.scrollHeight) clearTimeout(scrolldelay);        
    }else{
        scroll(0,$_ScrollBot.scrollHeight);
    }
}
//错误验证
function err_tip(obj,type,_pxmsg){
    $('.tipBox').hide();
	var clrT = null;
	var $tip = $("<div class=\"tipBox\"><div class=\"outTip\"><div class=\"outDot\">◇<div class=\"inDot\">◆</div></div><span class=\"top-err\"></span></div></div>");
	$(obj).each(function(i,item){
		if($(item).val()==""||$(item).val()==$(item).attr("placeholder")){
			if((type&&type == "100")||(type&&isNaN(type))){		//通用
				if(type!="100"){_pxmsg=type};
				tipPost(_pxmsg,item);
				errmsgcode = -1;
				return false;
			}else{
			tipPost("该项不能为空",item);
			errmsgcode = -1;
			return false;
			}
		}else{
			$('.tipBox').hide();
			if(type&&type == "0"){
				var _val = $(item).val();
				var rag = new RegExp(/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)
				if(!rag.test(_val)){
					tipPost("您输入的邮箱格式不对",item);
					errmsgcode = -1;
					return false;
				}
			}else if(type&&type == "1"){
				tipPost("此帐号不存在",item);
				errmsgcode = -1;
				return false;
			}else if(type&&type == "2"){
				tipPost("验证码不正确",item);
				errmsgcode = -1;
				return false;
			}else if(type&&type == "3"){
				tipPost("密码不正确",item);
				errmsgcode = -1;
				return false;
			}else if((type&&type == "100")||(type&&isNaN(type))){		//通用
				if(type!="100"){_pxmsg=type};
				tipPost(_pxmsg,item);
				errmsgcode = -1;
				return false;
			}else{
				$('.tipBox').hide();
				errmsgcode = 0;
			}
			errmsgcode = 0;
		}
	});


	function tipPost(msg,item){
			clearTimeout(clrT);
			$('.tipBox').clearQueue();
			$('.tipBox').stop();
		if($(item).is(':visible')){
			if(!$('.tipBox').is(':visible')){
			$('.tipBox').size()=="0"?$tip.appendTo($(document.body)).show().css('opacity','1'):$('.tipBox').show().css('opacity','1');
			//$(item).focus();
			$('.tipBox').css({"left":$(item).offset().left,"top":$(item).offset().top+$(item).outerHeight(),"display":"block"});
			$('.tipBox').find(".top-err").text(msg);
			$_ScrollBot.scrollHeight=$(item).offset().top;
			if($_ScrollBot.scrollHeight>$(document).scrollTop()&&$_ScrollBot.scrollHeight<$(document).scrollTop()+$(window).height()){}else{
			$_ScrollBot.pageScroll();}
			redbox(item);
			clrT = setTimeout(function(){
			$('.tipBox').clearQueue();
			$('.tipBox').stop();
			$('.tipBox').animate({'opacity':'0'},1500,function(){$('.tipBox').hide()})		
			},2000);
			}
		}
	}

	return errmsgcode==0 ? true : false;
}

function redbox(item){
    if($(item).is('input')&&!document.all){
        $(item).css({
            "box-shadow":"0 0 3px #e70000",
            "border-color":"#e70000"
        }).delay(1).animate({
            "box-shadow":"0 0 3px #fff",
            "border-color":"#fff"
        }).animate({
            "box-shadow":"0 0 3px #e70000",
            "border-color":"#e70000"
        }).animate({
            "box-shadow":"0 0 3px #fff",
            "border-color":"#fff"
        }).animate({
            "box-shadow":"0 0 3px #e70000",
            "border-color":"#e70000"
        });
    }
}

//遍历class或id为obj执行blur()事件
function eachCheck(obj){
	$(obj).each(function(){
		$(this).blur();
		if(errmsgcode==-1){
			return false;
		}
	});
	return errmsgcode==0 ? true : false;
}



function viewMore(){

	//初始化收缩显示
	$('.lenText').each(function(){
		$(this).attr("max-height",$(this).outerHeight());
		if($(this).outerHeight()>100){
		  $(this).css({
			  "overflow":"hidden",
			  "height":"100px"
		  })
		}else{
		  $(this).next('li').find('.viewMore').hide();
		}
	})
//显示更多
	$('.viewMore,.viewMoreText').click(function(){
		if($(this).text()=='+ 展开内容'){
		$(this).parents('li').prev('li').animate({height: $(this).parents('li').prev('li').attr("max-height")});
		$(this).text('- 收缩内容');
		}else{
		$(this).parents('li').prev('li').animate({height: '100px'});
		$(this).text('+ 展开内容');

		}

	})
}

(function($){
	$.fn.tip=function(obj){
		var _l = $(this).offset().left + $(this).outerWidth() - $(obj).outerWidth();
		var _t = $(this).offset().top + $(this).outerHeight();
		var _blur = 1;
		$(obj).show().attr('tabindex','-1').css({position:"absolute",left:_l,top:_t}).focus();
		$(obj).mousedown(function(){
			_blur = 0;
		})
		$(document).mousedown(function(){
			if(_blur==1){
			$(obj).hide();
			}
			_blur = 1;
		});
	}
})(jQuery);

//ajaxloading
function ajaxLoading(){
  var lo = setInterval(_load,10);
  function _load(){
	  $('.load').each(function(){
		  var n =1;
		  if(n!=0){
			  var num = $(this).find('span').text();
			  num++;
			  if(num<100){
				  $(this).find('span').text(num);
				  var y = (Math.ceil(num/4)-1)*82;
				  $(this).css("background-position","0px -"+y+"px");
			  }
		  }else{
			  $(this).css("background-position","0px -2050px").html("");
			  clearInterval(lo);
			  $('.mateTxt').hide();
			  $('.mateOver').show();
		  }
	  })
  }
}




//弹出层popLayer(是否加载遮罩层，追加位置-不填则加在body里)
function popLayer(url,flg,h,appObj,callBack){	
	var h =h?h:"";
	var $popObj = $("<div class=\"pop\" id=\"popLayle\" style=\"display:none\"><div class=\"clearfix popInner\"><h4><a class=\"popCl popKill\"></a><span>"+h+"</span></h4><div class=\"popCon\"></div></div></div>");
	var scrTop = $(window).scrollTop();
	//加载弹出层页面
	var rand = Math.random()*935+134;
	if(url){
		if(url.substring(0,1)=='#'){
			var datatemp = $(url).clone();
			$popObj.find('.popCon').html(datatemp);
			$('#popLayle').find('.popCon').html(datatemp);
			$('#popLayle').find(url).css('display','block');
			init();
			$('#popLayle').find(url).css('display','block');
			init();
			}else{
				if(url.indexOf('?')== "-1"){
					url = url+"?rand="+rand;
				}else{
					url = url+"&rand="+rand;
				}
				$.ajax({
				   url:url,
				   type:"post",
				   async:true,
				   error:function(){
					   throw "Page address is wrong!";
					   return false;
					},
				   success:function(data){
						$popObj.find('.popCon').html(data);
						$('#popLayle').find('.popCon').html(data);
						init();
					}
			})
	}
	}else{
		throw "Please input your address!";
	}
	closePop('.popKill',callBack);

	//抖一下
	$('#popIframe').live('click',function(){
		var _l = $popObj.offset().left-10,  _r = _l +20, _c = _r -10;
		$popObj.animate({"left":_l+"px"},5,function(){
			$popObj.animate({"left":_r+"px"},10,function(){
				$popObj.animate({"left":_c+"px"},5)
			});
		});
	})

	//加载弹出层
	function init(){
		var appObj = appObj || $(document.body);
		$('#popLayle').size()==0?$popObj.appendTo(appObj).show():$('#popLayle').show();
		$('#popLayle').width($('#popLayle .popCon').children('div').outerWidth()+20+'px');
		$('#popLayle h4 span').text(h);
		var $iframe = $("<div id=\"popIframe\"><div id=\"vayDiv\"  style=\"width:100%;height:"+$(document.body).height()+"px;top:0px;left:0px; position:absolute; z-index:9999; border-style:none;filter:alpha(opacity=10);opacity:0.1; background:#000 \"></div><iframe width=\"100%\" style=\"height:"+$(document.body).height()+"px;top:0px;left:0px; position:absolute; z-index:9998; border-style:none;filter:alpha(opacity=0);opacity:0; \"></iframe></div>");
		if(flg){
			$('#popIframe').size()=="0"?$iframe.appendTo($(document.body)):$('#popIframe').show();
		};
		var _w = $('#popLayle').outerWidth(), _h =$('#popLayle').outerHeight();
		var _top = $(window).height()-_h,_left = $(window).width() - _w;
		
		var topover = _top*0.5 + scrTop;
		if(topover<0){topover=0}
		$('#popLayle').css({left:_left*0.5 +"px",top:topover+"px","z-index":"10000"});
	}

}
function closePop(closeObj,callBack){
	$(closeObj).live('click',function(){
		$('#popIframe').hide();
		$('#popLayle').hide();
		if(callBack){
		top.location.href=callBack;
		}
	});
}


//选择器弹出层
//地址多选弹出层
function addressFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getAddressDetails(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_address/getAddress.html','680px','gray',buttonId,hiddenId,num,initialVal,"1");
			$(this).blur();
		});
	};
}
//行业多选弹出层
function industryFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getIndustryDetails(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_industry/getIndustry.html','680px','gray',buttonId,hiddenId,num,initialVal,"2");
			$(this).blur();
		});
	};
}
//职业多选弹出层
function professionFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getProfessionDetails(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_profession/getProfession.html','680px','gray',buttonId,hiddenId,num,initialVal,"3");
			$(this).blur();
		});
	};
}

//专业单选弹出层
function majorRadioFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getMajorDetailsRadio(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_majorType/getMajorRadio.html','680px','gray',buttonId,hiddenId,num,initialVal,"9");
			$(this).blur();
		});
	};
}
//专业多选弹出层
function majorFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getMajorDetails(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_majorType/getMajor.html','680px','gray',buttonId,hiddenId,num,initialVal,"4");
			$(this).blur();
		})
	};
}
//学校多选弹出层
function schoolFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getSchoolDetails(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_School/getSchool.html','680px','gray',buttonId,hiddenId,num,initialVal,"5");
			$(this).blur();
		});
	};
}

//地址单选弹出层
function addressRadioFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getAddressDetailsRadio(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_address/getAddressRadio.html','680px','gray',buttonId,hiddenId,num,initialVal,"6");
			$(this).blur();
		});
	};
}

//行业单选弹出层
function industryRadioFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getIndustryDetailsRadio(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_industry/getIndustryRadio.html','680px','gray',buttonId,hiddenId,num,initialVal,"7");
			$(this).blur();
		});
	};
}

//职业单选弹出层
function professionRadioFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getProfessionDetailsRadio(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_profession/getProfessionRadio.html','680px','gray',buttonId,hiddenId,num,initialVal,"8");
			$(this).blur();
		});
	};
}


//学校单选弹出层
function schoolRadioFun(buttonId,hiddenId,num,initialVal){
	if($("#"+buttonId).size()!=0){
		getSchoolDetailsRadio(buttonId,hiddenId,num,initialVal);
		$("#"+buttonId).click(function(){
			showPop1(' ','/component/baijob_School/getSchoolRadio.html','680px','gray',buttonId,hiddenId,num,initialVal,"10");
			$(this).blur();
		});
	};
}

//弹出层控件
function showPop1(_popTitle,_popUrl,_popWidth,gray,buttonId,hiddenId,num,initialVal,Pop){
			var popTitle = _popTitle || "窗口";
			var popUrl = _popUrl;
			var popWidth = _popWidth || "650px";

			dialogPop(popTitle,"",popWidth,"auto","",gray);
			$.get(popUrl, function(data) {
				$('.content_gray').html(data);
				return false;
			});
			switch(Pop){
				case "1":
					getAddressDetails(buttonId,hiddenId,num,initialVal);
				break;
				case "2":
					getIndustryDetails(buttonId,hiddenId,num,initialVal);
				break;
				case "3":
					getProfessionDetails(buttonId,hiddenId,num,initialVal);
				break;
				case "4":
					getMajorDetails(buttonId,hiddenId,num,initialVal);
				break;
				case "5":
					getSchoolDetails(buttonId,hiddenId,num,initialVal);
				break;
				case "6":
					getAddressDetailsRadio(buttonId,hiddenId,num,initialVal);
				break;
				case "7":
					getIndustryDetailsRadio(buttonId,hiddenId,num,initialVal);
				break;
				case "8":
					getProfessionDetailsRadio(buttonId,hiddenId,num,initialVal);
				break;
				case "9":
					getMajorDetailsRadio(buttonId,hiddenId,num,initialVal);
				break;
				case "10":
					getSchoolDetailsRadio(buttonId,hiddenId,num,initialVal);
				break;
			}
}


$(document).ready(function () {
    get_degree();
});
function get_degree() {
	var jobLength = +$('.mate_degree span').length;

    $('.mate_degree span').each(function () {
        var _this = this;
        if($.trim(_this.id) == '') return false;
        $.get('/getgrade',{job_id:_this.id},function (data) {

            var _grade = Number(data);
            if (_grade) {
                _this.className = 'mate'+_grade;
                _this.title = '匹配度'+_grade+'%';
                _this.innerHTML = _grade;
            }else{
                _this.className = 'mate0';
                _this.title = '匹配度0%';
                _this.innerHTML = '0';
            }
        });
    });
}

//滑动门
function changeTab(nav,cont,onstyle){
	$(nav).mouseover(function(){
		var $onnav = $(this).html();
		var i=0;
		$(nav).each(function(){
			if($onnav==$(this).html()){
				$(nav).removeClass(onstyle);
				$(this).addClass(onstyle);
				$(cont).hide();
				$(cont+":eq("+i+")").show();
				
			}else{
				i=i+1;
			}
		})
	})
}


// 重写 alert
function alert(message,tit){
	var $tit="";
	if(tit){
		$tit=tit;
	}else{
		$tit='&nbsp;';
	}
	 $("body").append("<div class=\"pop\" id=\"alertLayle\" style=\"display:none\"><div class=\"clearfix popInner\"><h4><a class=\"popCl alertKill\"></a><span>"+$tit+"</span></h4><div class=\"popCon2\"></div></div></div>");
	 $('#alertLayle .popCon2').html(message);
	 $("#alertLayle").show();
	 var $iframe = $("<div id=\"alertIframe\"><div id=\"vayDiv\"  style=\"width:100%;height:"+$(document).height()+"px;top:0px;left:0px; position:absolute; z-index:9999; border-style:none;filter:alpha(opacity=10);opacity:0.1; background:#000 \"></div><iframe width=\"100%\" style=\"height:"+$(document).height()+"px;top:0px; position:absolute; z-index:89998; border-style:none;filter:alpha(opacity=0);opacity:0; \"></iframe></div>");	
	$('#alertIframe').size()=="0"?$iframe.appendTo($(document.body)):$('#alertIframe').show();	
	 $('#alertLayle').width($('#alertLayle .popCon2').outerWidth()+20+'px');
	 var _w = $('#alertLayle').outerWidth(), _h =$('#alertLayle').outerHeight();
	 var _top = $(window).height()-_h,_left = $(window).width() - _w;
	 var scrTop = $(window).scrollTop();
	 $('#alertLayle').css({left:_left*0.5 +"px",top:(_top*0.5 + scrTop)+"px","z-index":"89999"});	 
	 $(".alertKill").live("click",function(){
		$(this).parents("#alertLayle").remove();
		$("#alertIframe").remove(); 
	 })	
	 $(document).keydown(function(e){
	 	if(e.keyCode==13){
		$("#alertLayle").remove();
		$("#alertIframe").remove(); 
		}
	 })
}

// 带消失效果
function alertOut(message,tit) {
	var $tit="";
	if(tit){
		$tit=tit;
	}else{
		$tit='&nbsp;';
	}
	 $("body").append("<div class=\"pop\" id=\"alertLayle\" style=\"display:none\"><div class=\"clearfix popInner\"><h4><a class=\"popCl alertKill\"></a><span>"+$tit+"</span></h4><div class=\"popCon2\"></div></div></div>");
	 $('#alertLayle .popCon2').html(message);
	 $("#alertLayle").show();
	 var $iframe = $("<div id=\"alertIframe\"><div id=\"vayDiv\"  style=\"width:100%;height:"+$(document).height()+"px;top:0px;left:0px; position:absolute; z-index:9999; border-style:none;filter:alpha(opacity=10);opacity:0.1; background:#000 \"></div><iframe width=\"100%\" style=\"height:"+$(document).height()+"px;top:0px; position:absolute; z-index:89998; border-style:none;filter:alpha(opacity=0);opacity:0; \"></iframe></div>");	
	$('#alertIframe').size()=="0"?$iframe.appendTo($(document.body)):$('#alertIframe').show();	
	 $('#alertLayle').width($('#alertLayle .popCon2').outerWidth()+20+'px');
	 var _w = $('#alertLayle').outerWidth(), _h =$('#alertLayle').outerHeight();
	 var _top = $(window).height()-_h,_left = $(window).width() - _w;
	 var scrTop = $(window).scrollTop();
	 $('#alertLayle').css({left:_left*0.5 +"px",top:(_top*0.5 + scrTop)+"px","z-index":"89999"});	 
	 $(".alertKill").live("click",function(){
		$(this).parents("#alertLayle").remove();
		$("#alertIframe").remove(); 
	 })	
	 $(document).keydown(function(e){
	 	if(e.keyCode==13){
		$("#alertLayle").remove();
		$("#alertIframe").remove(); 
		}
	 })
     
    if (arguments[2]) {
        setTimeout(function () {
            $('#alertLayle').remove();
            $("#alertIframe").remove();
        }, 3000)

    }
}

//ga代码全站公用
var ga_trigger = {}
ga_trigger.searchpost={
	serLinks:function(){
		$('.serLinks a').mousedown(function(){
			_gaq.push(['_trackEvent', 'relevant search', $('#search').val(), $(this).text()]);
		})
	}
}
$(function(){
	ga_trigger.searchpost.serLinks();
})

//信息提示：三个参数分别为
//inputId:需要判断的表单id
//type:为 1 时是正确的提示， 2 时是错误提示
//tips:提示的文字信息，正确时为空
function checkTipsShow(inputId,type,tips){
	if(type==1){	   
	   var $corrSpan=$("<span class=\"corr\">&nbsp;</span>");
	   if($(inputId).parents("td").find(".corr").size()==0){
          $(inputId).parents("td").find(".warning").remove();
		  $(inputId).parents("td").append($corrSpan);	
		  }else{return;}	   
	}
	if(type==2){
	   var $warnSpan=$('<span class=\"warning\">'+tips+'</span>');
	    if($(inputId).parents("td").find(".warning").size()==0){
        $(inputId).parents("td").find(".corr").remove();
	    $(inputId).parents("td").append($warnSpan);	 }else{return;}
		 	
	}
}


/*
    @description 重写confirm
    @param {obj} 配置单 config
    config = {
        title: {string} 标题
        text: {string} 提示文字
        confirm: {string} 确定按钮文字
        cancel: {string} 取消按钮文字
        confirmFun: {function} 点击确定执行函数
        cancelFun：{function} 点击取消执行函数
    }
 */
function confirmFunc(config) {
    var bodyNode = $('body');
    var confirmNodeArr = [];
    var confirmWidth;
    var confirmHeight;
    var scrTop = $(window).scrollTop();
    var confirmNode;
    var iframe;
    config = $.extend({
        title: '',
        text: '',
        confirm: '确定',
        cancel: '取消',
        confirmFun: function () {
        },
        cancelFun: function () {
        }
    }, config);
    confirmNodeArr.push('<div class="pop pop_confrim" id="confirm_pop">');
    confirmNodeArr.push('<div class="clearfix popInner">');
    confirmNodeArr.push('<h4><span>' + config.title + '</span></h4>');
    confirmNodeArr.push('<div class="popCon2">' + config.text + '</div>');
    confirmNodeArr.push('<div id="pop_confirm_btn" class="pop_confirm_btn">');
    confirmNodeArr.push('<a id="confirm_true" class="btn75_33" href="#">' +
            config.confirm + '</a><a id="confirm_false" class="btn75_33" href="#">' + 
            config.cancel + '</a>');
    confirmNodeArr.push('</div></div></div>');
    
    iframe = $("<div id=\"alertIframe\"><div id=\"vayDiv\"  style=\"width:100%;height:"+$(document).height()+"px;top:0px;left:0px; position:absolute; z-index:9999; border-style:none;filter:alpha(opacity=10);opacity:0.1; background:#000 \"></div><iframe width=\"100%\" style=\"height:"+$(document).height()+"px;top:0px; position:absolute; z-index:89998; border-style:none;filter:alpha(opacity=0);opacity:0; \"></iframe></div>");
    bodyNode.append(iframe);
    bodyNode.append(confirmNodeArr.join(''));
    confirmNode = $('#confirm_pop');
    confirmWidth = confirmNode.width();
    confirmHeight = confirmNode.height();
    confirmNode.css({
        'left': ($(window).width() - confirmWidth) / 2,
        'top': ($(window).height() - confirmHeight) / 2 + scrTop
    });

	$(document).delegate('#confirm_true', 'click', function (e) {
        e.preventDefault();
        confirmNode.remove();
        $('#alertIframe').remove();
        config.confirmFun();
        $(document).undelegate('#confirm_false', 'click');
        $(document).undelegate('#confirm_true', 'click');
    });
    $(document).delegate('#confirm_false', 'click', function (e) {
        e.preventDefault();
        confirmNode.remove();
        $('#alertIframe').remove();
        config.cancelFun();
        $(document).undelegate('#confirm_false', 'click');
        $(document).undelegate('#confirm_true', 'click');
    });
}
/*
判断是否有数据在编辑的alert
*/
function AtrAlert(msg){
        alert(msg);
        setTimeout(function(){
        $('.alertKill').click()},3000);
   } 
//字符判断
function textareaLim(obj,len,outObj,t) {
	var l = 0; //当前长度
	var o = 0; //剩余长度
	if(t) obj.attr('maxlength',len);
	obj.bind('keydown keyup',function() {
		l = $(this).val().length;
		if(l>len){
			obj.val(obj.val().substr(0,len))
		}
		o = len - l;
		if(o<0) o = 0;
		outObj.html(o+'/'+len);
	});
}
//自有职位申请
function applyJob(jobid,type)
{
    if(typeof(type) !== 'undefined'){
        if(parseInt(type) == 1)
            _gaq.push(['_trackEvent', 'direct delivery', 'searchpost']);
        if(parseInt(type) == 2)
            _gaq.push(['_trackEvent', 'direct delivery', 'job']);
    }

    if(($config.uid.length == 0 && $config.attachmentid.length==0) || ($config.uid.length == 0 && baijob.getCookie('user_attachment')==null))
    {
        $('a[index='+jobid+']').tip('#pop');
        return;
    }
    if (typeof(search_key_word)!='undefined') {
        var num = baijob.getCookie(search_key_word);
        if (num == 1) {
            baijob.setCookie(search_key_word,num +1, 86400*1000, '.baijob.com');
            popLayer(baijob.domain + 'delivermore/recommend?search_key='+search_key_word, true, '推荐职位');
            return;
        } else {
            baijob.setCookie(search_key_word,num +1, 86400*1000, '.baijob.com');
        }
    }
    var h = '简历投递';
    var _applyUrl = baijob.domain + 'Apply/show?jobid=' + jobid;
    $('#seljob_'+jobid).attr('checked', true).attr('disabled', true);
    popLayer(_applyUrl,true,h);
}
//注册蒙层
var semRegLayer = {
    init:function(){
        var $iframe = $("<div id=\"alertIframe\"><div id=\"vayDiv\"  style=\"width:100%;height:"+$(document).height()+"px;top:0px;left:0px; position:absolute; z-index:8001; border-style:none;filter:alpha(opacity=30);opacity:0.3; background:#000 \"></div><iframe width=\"100%\" style=\"height:"+$(document).height()+"px;top:0px; position:absolute; z-index:8000; border-style:none;filter:alpha(opacity=0);opacity:0; \"></iframe></div>");
        $('#alertIframe').size()=="0"?$iframe.appendTo($(document.body)):$('#alertIframe').show();
        $('#semRegBox').show();
        $('#semRegBox').css({
            'top':(parseInt($(window).height())-parseInt($('#semRegBox').outerHeight()))/2+$(document).scrollTop(),
            'left':(parseInt($(window).width())-parseInt($('#semRegBox').outerWidth()))/2
        });
    },
    err:function(obj,msg){//obj为input id 或 class 如:.name或#name
        $(obj).siblings('.reg-sem-stats').removeClass('crct').addClass('err');
        $(obj).siblings('.sem-easy-reg-err').html(msg);
    },
    crct:function(obj,msg){//obj为input id 或 class 如:.name或#name
        $(obj).siblings('.reg-sem-stats').removeClass('err').addClass('crct');
        $(obj).siblings('.sem-easy-reg-err').html(msg);
    },
    pos:function(){
        $('#semRegBox').css({
            'top':(parseInt($(window).height())-parseInt($('#semRegBox').outerHeight()))/2+$(document).scrollTop(),
            'left':(parseInt($(window).width())-parseInt($('#semRegBox').outerWidth()))/2
        })
    }
}

