<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_panel_ajax.aspx.cs" Inherits="Web.e.member.user_panel_ajax" %>
<%
  if(id<=0)
  {
 %>
 <a href="/index.htm">注册</a> 或 <a href="/login.html">登录</a>&nbsp;&nbsp;&nbsp;<a href="#">企业用户</a>
 <%}
 else { %>
 欢迎回来，<%=name %> 第<%=loginCount %>次登录 <a href="/Dynamic/Job/Home.aspx">简历中心</a> <a href="/e/member/Logout.aspx">退出</a>
 <% }%>