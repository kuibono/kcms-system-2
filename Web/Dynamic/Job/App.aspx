<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="Web.Dynamic.Job.App" %>

<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>职位管理-南京第一职</title>
    <link type="text/css" rel="stylesheet" href="/skin/job/css/style.css" />
    <link type="text/css" rel="stylesheet" href="/skin/job/css/2013.css" />
    <link href="/skin/job/css/incenter.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../skin/script/jquery-1.7.min.js"></script>
</head>
<body>
    <%=JobAction.TopHtml %>
    <table width="989" bgcolor="#FFFFFF" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                <div id="main">
                    <div class="bor-c2e0eb clearfix bg-fff">
                        <div id="primary">
                            <div id="content">
                                <ul class="tab-blue clearfix">
                                    <li class="here"><a href="App.aspx">我申请的职位</a></li><%--<li><a href="App.aspx">我浏览过的职位</a></li>--%>
                                </ul>
                                <ul class="jobs-list-ul">
                                    <li class="clearfix">
                                        <p class="fw">
                                            截止<span class="mr-10"><%=DateTime.Now.ToString("yyyy-MM-dd") %></span>我已成功申请职位<span
                                                class="red ml-10"><%=count %></span></p>
                                    </li>
                                    <asp:repeater id="rp_lis" runat="server">
                                       <ItemTemplate>
                                        <li class="clearfix">
                                            <input type="button" onclick="location.href='Job.aspx?id=<%#Eval("Pid")%>'" style="float: right" class="btn-blue114" value="查看详情" id="saveinfo" />
                                            <p>
                                                <span class="mr-10"><%#Eval("ApplicationTime").ToDateTime().ToString("yyyy-MM-dd HH:mm") %></span></p>
                                            <p>
                                                我申请了<strong><a href="Job.aspx?id=<%#Eval("Pid")%>" target="_blank" class=" mr-40 ft14 ml-10"><%#Eval("Title")%></a></strong><a
                                                    href="Company.aspx?id=<%#Eval("CompanyID")%>" target="_blank"><%#Eval("CompanyName")%></a></p>
                                        </li>
                                        </ItemTemplate>
                                    </asp:repeater>
                                </ul>
                                <div class="pt-20 pageNum">
                                    <vd:aspnetpager id="pager" runat="server" firstpagetext="首页" lastpagetext="尾页" nextpagetext="后页"
                                        prevpagetext="前页" alwaysshow="true" urlpaging="True" pagesize="10"></vd:aspnetpager>
                                </div>
                            </div>
                            <!-- #content -->
                        </div>
                        <!-- #primary -->
                        <div class="widget-area">
                            <div class="face-eara">
                                <a id="xiugaijibenxinxi" href="ResumeBasic.aspx">
                                    <img src="<%=Image %>" width="96" height="96" id="user_face" />
                                    <span>修改基本信息</span></a></div>
                            <ul class="l-nav">
                                <li><a href="Home.aspx" class="my-baijob" id="wodebaibo">我的第一职</a></li>
                                <li><a href="ResumeBasic.aspx" class="my-resume" id="jianliguanli">简历管理</a></li>
                                <li><a href="ResumeView.aspx" class="my-resume" id="A1">我的信息</a></li>
                                <li class="here"><a href="App.aspx" class="my-job" id="zhiweiguanli">职位管理</a></li>
                                <li><a href="Password.aspx" class="my-manage" id="zhanghaoguanli">帐号管理</a></li>
                            </ul>
                        </div>
                        <!-- .widget-area -->
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <%=JobAction.BottomHtml %>
</body>
</html>
