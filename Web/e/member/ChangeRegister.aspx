<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeRegister.aspx.cs" Inherits="Web.e.member.ChangeRegister" %>
<%= Voodoo.Basement.CreatePage.CreateHeaderString("会员注册") %>
        <div id="main_1" class="clearfix mg">
        	<div class="nav">您的位置：<a href="/">首页</a>> <a href="javascript:void(0)">注册</a></div>
            <div id="newslist" class="left inner" style="width: 660px;">
                <h1>
                    选择用户类型
                </h1>
                <form method="get" action="RegisterForm.aspx">
                    <table border="0" style="margin:10px auto 10px 0px; background-color:#eee;">
                    <%= GetUserGroupString()%>
                    </table>
                    <div>
                        <input type="submit" value="下一步" />
                    </div>
                </form>
            </div>
            <div class="right" style="width: 259px; margin-left:32px;">
                <h1>
                    功能菜单
                </h1>
                <ul class="inner">
                    <%=Voodoo.Basement.CreatePage.BuildUserMenuString()%>
                </ul>
            </div>
        </div>
 <%= Voodoo.Basement.CreatePage.CreateFooterString() %>