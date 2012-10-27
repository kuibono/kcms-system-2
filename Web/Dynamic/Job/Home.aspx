<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web.Dynamic.Job.Home" %>

<%@ Import Namespace="Voodoo.Basement" %>
<%@ Import Namespace="Voodoo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的简历-南京第一职网</title>
    <link type="text/css" rel="stylesheet" href="/skin/job/css/style.css" />
    <link type="text/css" rel="stylesheet" href="/skin/job/css/2013.css" />
    <link href="/skin/job/css/incenter.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../skin/script/jquery-1.7.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#li1").click(function () {
                $(this).prop("class", "here");
                $("#li2").prop("class", "");
                $("#tj").show();
                $("#vis").hide();
            })
            $("#li2").click(function () {
                $(this).prop("class", "here");
                $("#li1").prop("class", "");
                $("#tj").hdie();
                $("#vis").show();
            })
        })
    </script>
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
                                <div class="tit-my-resume">
                                    <span class="fr fc-999"><span id="resumetime" style="color: #999999;">更新于：2012-10-10
                                        10:11:23</span>&nbsp;&nbsp;|&nbsp;&nbsp;<%=ResumeOpen %></span><span class="yahei ft18 "><img
                                            src="/skin/job/img/ico-write.gif" width="23" height="20">我的简历</span></div>
                                <div class="resume-top-eara-wrap mt-10 ">
                                </div>
                                <div class="resume-m">
                                    <p class="clearfix w385">
                                        <a href="javascript:$('#fileUp').show();return false;" class="up-resume ft14 fc-333 re_upload_resume">
                                            上传附件简历
                                            <img src="/skin/job/img/up-ixo.png" width="21" height="22"></a><br />
                                        <div id="fileUp" style="display: none;">
                                            <form method="post" action="/e/Job/UploadResume.aspx" enctype="multipart/form-data">
                                            <input type="file" name="fname" />
                                            <br />
                                            <input type="submit" value="上传" class="btn-blue114" />
                                            </form>
                                        </div>
                                    </p>
                                </div>
                                <ul class="tab-blue clearfix">
                                    <li class="here" id="li1"><a href="javascript:void(0);" class="radius-tl4">我的职位推荐</a></li>
                                    <li id="li2"><a class="radius-tr4" href="javascript:void(0);">我浏览过的职位</a></li>
                                </ul>
                                <ul class="jobs-list-ul" id="tj">
                                    <asp:repeater id="rp_lis" runat="server">
                                       <ItemTemplate>
                                       
                                        <li class="clearfix">
                                            <input type="button" onclick="location.href='Job.aspx?id=<%#Eval("Pid")%>'" style="float: right" class="btn-blue114" value="查看详情" id="Button1" />
                                            <p>
                                                <span class="mr-10">&nbsp;</span></p>
                                            <p>
                                                <strong><a href="Job.aspx?id=<%#Eval("Pid")%>" target="_blank" class=" mr-40 ft14 ml-10"><%#Eval("Title")%></a></strong><a
                                                    href="Company.aspx?id=<%#Eval("CompanyID")%>" target="_blank"><%#Eval("CompanyName")%></a></p>
                                        </li>
                                        
                                        </ItemTemplate>
                                    </asp:repeater>
                                </ul>
                                <ul class="jobs-list-ul" id="vis" style="display: none;">
                                    <asp:repeater id="rp_lis2" runat="server">
                                       <ItemTemplate>
                                       
                                        <li class="clearfix">
                                            <input type="button" onclick="location.href='Job.aspx?id=<%#Eval("Pid")%>'" style="float: right" class="btn-blue114" value="查看详情" id="Button2" />
                                            <p>
                                                <span class="mr-10"><%#Eval("ApplicationTime").ToDateTime().ToString("yyyy-MM-dd HH:mm") %></span></p>
                                            <p>
                                                <strong><a href="Job.aspx?id=<%#Eval("Pid")%>" target="_blank" class=" mr-40 ft14 ml-10"><%#Eval("Title")%></a></strong><a
                                                    href="Company.aspx?id=<%#Eval("CompanyID")%>" target="_blank"><%#Eval("CompanyName")%></a></p>
                                        </li>
                                        
                                        </ItemTemplate>
                                    </asp:repeater>
                                </ul>
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
                                <li class="here"><a href="Home.aspx" class="my-baijob" id="wodebaibo">我的第一职</a></li>
                                <li><a href="ResumeBasic.aspx" class="my-resume" id="jianliguanli">简历管理</a></li>
                                <li><a href="App.aspx" class="my-job" id="zhiweiguanli">职位管理</a></li>
                                <li><a href="Password.aspx" class="my-manage" id="zhanghaoguanli">帐号管理</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <%=JobAction.BottomHtml %>
</body>
</html>
