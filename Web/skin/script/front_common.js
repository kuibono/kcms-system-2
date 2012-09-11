/* 设为首页 */
function setMyHome() {
  if (document.all) {
    document.body.style.behavior='url(#default#homepage)';
 	document.body.setHomePage(location.href);
 
  } else if (window.sidebar) {
    if(window.netscape) {
        try {  
            netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");  
        } catch (e) {  
  		    alert( "该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true" );  
        }
    } 
    var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components. interfaces.nsIPrefBranch);
    prefs.setCharPref('browser.startup.homepage',location.href);
  }
}

/* 添加收藏  */
function addFav() {
    var title = document.title;
    var url = document.location.href;

    if (window.sidebar) {
        window.sidebar.addPanel(title, url, "");
    }

    else if (window.opera && window.print) {

        alert(title);
        var mbm = document.createElement('a');
        mbm.setAttribute('rel', 'sidebar');
        mbm.setAttribute('href', url);
        mbm.setAttribute('title', title);
        mbm.click();
    }
    else if (document.all) {
        try
        {
            //window.external.AddFavorite(url, title);
            window.external.addFavorite('http://www.baidu.com', '收藏夹');
        }
        catch (e) {
            alert(e);
            try { external.AddToFavoritesBar(url, title, ''); }
            catch (ee) {
                alert(ee);
            }
        }
    }
}

$(function() {
    //加载登陆框
$("#div_login").load("/e/member/LoginForm.aspx?jsoncallback=" + new Date().toLocaleTimeString());
    $("#btn_login").live("click", function() {
        if ($("#txt_username").val().length == 0 || $("#txt_password").val().length == 0) {
            alert("账号和密码不能为空");
            return false;
        }
    })
})
