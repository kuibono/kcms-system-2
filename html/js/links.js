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
            _thir.$(menu[z]).value = z;                 
            _thir.$(menu[z]).onmouseover = function(){ 
                     
                for(var x = 0 ; x < menu.length ; x++) 
                {                         
                    _thir.$(menu[x]).className = closeClas; 
                    _thir.$(div[x]).style.display = "none"; 
                } 
                _thir.$(menu[this.value]).className = openClas;     
                _thir.$(div[this.value]).style.display = "block";                 
            } 
        } 
        }, 
    $ : function(old){ 
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
            _thir.$(menu[z]).value = z;                 
            _thir.$(menu[z]).onmousemove = function(){ 
                     
                for(var x = 0 ; x < menu.length ; x++) 
                {                         
                    _thir.$(menu[x]).className = closeClas; 
                    _thir.$(div[x]).style.display = "none"; 
                } 
                _thir.$(menu[this.value]).className = openClas;     
                _thir.$(div[this.value]).style.display = "block";                 
            } 
        } 
        }, 
    $ : function(old){ 
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
            _thir.$(menu[z]).value = z;                 
            _thir.$(menu[z]).onmouseover = function(){ 
                     
                for(var x = 0 ; x < menu.length ; x++) 
                {                         
                    _thir.$(menu[x]).className = closeClas; 
                    _thir.$(div[x]).style.display = "none"; 
                } 
                _thir.$(menu[this.value]).className = openClas;     
                _thir.$(div[this.value]).style.display = "block";                 
            } 
        } 
        }, 
    $ : function(old){ 
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