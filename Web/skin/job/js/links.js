$(function () {
    // 图片左右翻滚
    var size = $('.slidebtn-01>ul>li').length;
    var frist = 0;
    var datetime;
    $('.slidebtn-01 li').mouseover(function () {
        frist = $('.slidebtn-01 li').index(this);
        showpic(frist);
    }).eq(0).mouseover();

    $('.slidebox-01').hover(function () {
        clearInterval(datetime);
    }, function () {
        datetime = setInterval(function () {
            showpic(frist)
            frist++;
            if (frist == size) {
                frist = 0;
            }
        }, 3000);
    }).trigger('mouseleave');

    function showpic(frist) {
        var imgheight = $('.slidebox-01').width();
        $('.slidepic-01').stop(true, false).animate({ left: -imgheight * frist }, 600)
        $('.slidebtn-01 li').removeClass('current').eq(frist).addClass('current');
    };

});


function scrollDoor0(){ 
} 
scrollDoor0.prototype = { 
    yibys : function(menu,div,openClas,closeClas){ 
        var _thir = this; 
        if(menu.length != div.length) 
        { 
            alert("菜单层数量和内容层数量不一样!"); 
            return false; 
        }                 
        for(var z = 0 ; z < menu.length ; z++) 
        {     
            _thir.selector(menu[z]).value = z;                 
            _thir.selector(menu[z]).onmouseover = function(){ 
                     
                for(var x = 0 ; x < menu.length ; x++) 
                {                         
                    _thir.selector(menu[x]).className = closeClas; 
                    _thir.selector(div[x]).style.display = "none"; 
                } 
                _thir.selector(menu[this.value]).className = openClas;     
                _thir.selector(div[this.value]).style.display = "block";                 
            } 
        } 
        }, 
    selector : function(old){ 
        if(typeof(old) == "string") 
        return document.getElementById(old); 
        return old; 
    } 
} 

function Door0(){ 
    var yibysmodel = new scrollDoor0(); 
    yibysmodel.yibys(["t1","t2","t3","t4","t5"],["t_1","t_2","t_3","t_4","t_5"],"t11","t22"); 
} 
if (document.all){

window.attachEvent('onload',Door0);//IE

}

else{

window.addEventListener('load',Door0,false);//firefox

}



function scrollDoor1(){ 
} 
scrollDoor1.prototype = { 
    yibys : function(menu,div,openClas,closeClas){ 
        var _thir = this; 
        if(menu.length != div.length) 
        { 
            alert("菜单层数量和内容层数量不一样!"); 
            return false; 
        }                 
        for(var z = 0 ; z < menu.length ; z++) 
        {     
            _thir.selector(menu[z]).value = z;                 
            _thir.selector(menu[z]).onmousemove = function(){ 
                     
                for(var x = 0 ; x < menu.length ; x++) 
                {                         
                    _thir.selector(menu[x]).className = closeClas; 
                    _thir.selector(div[x]).style.display = "none"; 
                } 
                _thir.selector(menu[this.value]).className = openClas;     
                _thir.selector(div[this.value]).style.display = "block";                 
            } 
        } 
        }, 
    selector : function(old){ 
        if(typeof(old) == "string") 
        return document.getElementById(old); 
        return old; 
    } 
} 

function Door1(){ 
    var yibysmodel = new scrollDoor1(); 
    yibysmodel.yibys(["l01","l02"],["log01","log02"],"g01","g02"); 
} 
if (document.all){

window.attachEvent('onload',Door1);//IE

}

else{

window.addEventListener('load',Door1,false);//firefox

}





function scrollDoor8(){ 
} 
scrollDoor8.prototype = { 
    yibys : function(menu,div,openClas,closeClas){ 
        var _thir = this; 
        if(menu.length != div.length) 
        { 
            alert("菜单层数量和内容层数量不一样!"); 
            return false; 
        }                 
        for(var z = 0 ; z < menu.length ; z++) 
        {     
            _thir.selector(menu[z]).value = z;                 
            _thir.selector(menu[z]).onmouseover = function(){ 
                     
                for(var x = 0 ; x < menu.length ; x++) 
                {                         
                    _thir.selector(menu[x]).className = closeClas; 
                    _thir.selector(div[x]).style.display = "none"; 
                } 
                _thir.selector(menu[this.value]).className = openClas;     
                _thir.selector(div[this.value]).style.display = "block";                 
            } 
        } 
        }, 
    selector : function(old){ 
        if(typeof(old) == "string") 
        return document.getElementById(old); 
        return old; 
    } 
} 

function Door8(){ 
    var yibysmodel = new scrollDoor8(); 
    yibysmodel.yibys(["link01","link02"],["flink01","flink02"],"links01","links02"); 
} 
if (document.all){

window.attachEvent('onload',Door8);//IE

}

else{

window.addEventListener('load',Door8,false);//firefox

}