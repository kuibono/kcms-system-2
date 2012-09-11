<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Web.e.member.LoginForm" %>

<%@ Import Namespace="Voodoo.Basement" %>
<%
    if (UserAction.opuser.ID <= 0)
    {
%>
    <div class="topBody">
        <div class="loginFrom">
            <form method="post" action="/user/check.aspx">
            <%--<label>
                账号：</label>
            <input type="text" class="input1 mr5" name="username" id="username" onfocus="if(this.value=='用户名...'){this.value='';}"
                onblur="if(this.value==''){this.value='用户名...';}" value="用户名..." />
            <label>
                密码：</label>
            <input type="password" class="input1 mr5" name="userpass" id="userpwd" />
            <input type="hidden" id="url" name="url" value="" />
            <script type="text/javascript">                $(function () { $("#url").val(location.href); });</script>
            <input type="submit" class="logBtn mr5" value="登 录" />
            <label>
                保存登录</label>
            <input type="checkbox" class="input2 mr5" id="remember_me" name="remember_me" value="1"
                tabindex="6" />
            <span><a href="/user/register.aspx" class="red mr5">免费注册</a>|
            <a href="/user/forgetPassword.aspx" class="ml5 mr10">忘记密码？</a>
            </span>--%> 
            <a href="/e/OAuth/QQlogin" target="_blank">
                    <img src="/skin/novel/Connect_logo_2.png" class="qqLoginBtn" border="0" alt="使用QQ登陆" /></a>
            </form>
        </div>
        <div class="gongnengLink">
            <a href="javascript:void(0);" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.aizr.net');">设为主页</a> 
                    | 
            <a href="javascript:window.external.AddFavorite(document.URL,document.title);" style="color: #FF6600;">加为收藏</a>
        </div>
    </div>
<%
    }
    else
    {
%>

    <div class="topBody">
        <div class="loginFrom">
          
              <ul>
                <li>欢迎回来 
                  <a href="/user" style="COLOR: #FF6600;"><%=Voodoo.Basement.UserAction.opuser.ChineseName %></a>┊
                </li>
                <li class="menu2" onMouseOver="this.className='menu1'" onMouseOut="this.className='menu2'">
                  <a href="#" class="mybookcase" onclick="alert('您好，会员系统正在开发过程中，请稍后使用！');return false;">我的书架</a>
                  <div class="list">
		                <a href="#" class="red" onclick="alert('您好，会员系统正在开发过程中，请稍后使用！');return false;">最近阅读</a><br />                        <a href="#" onclick="alert('您好，会员系统正在开发过程中，请稍后使用！');return false;">我的书架1</a><br />                        <a href="#" onclick="alert('您好，会员系统正在开发过程中，请稍后使用！');return false;">我的书架2</a><br />                        <a href="#" onclick="alert('您好，会员系统正在开发过程中，请稍后使用！');return false;">我的书架3</a><br />
	                </div>
                </li>
                <li>┊<a href="#" onclick="alert('您好，会员系统正在开发过程中，请稍后使用！');return false;">设置</a></li>
                <li>┊<a href="/e/member/logout.aspx">退出</a></li>
              </ul>
        </div>
        <div class="gongnengLink"> 
        <a href="javascript:void(0);"  onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.aizr.net');">设为主页</a> | 
        <a href="javascript:window.external.AddFavorite(document.URL,document.title);" style="COLOR: #FF6600;">加为收藏</a> </div>
    </div>
<%
    }
%>