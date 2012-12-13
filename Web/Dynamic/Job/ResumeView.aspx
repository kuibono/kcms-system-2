<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeView.aspx.cs" Inherits="Web.Dynamic.Job.ResumeView" %>

<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的信息-南京第一职网</title>
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
                                <div class="tit-my-resume">
                                    <span class="fr fc-999"><span id="resumetime" style="color: #999999;">更新于：<%=DateTime.Now.ToString("yyyy-MM-dd") %>
                                    </span>&nbsp;&nbsp;|&nbsp;&nbsp;<%=ResumeOpen %></span><span class="yahei ft18 "><img
                                        src="/skin/job/img/ico-write.gif" width="23" height="20">我的简历</span></div>
                                <div class="resume-top-eara-wrap mt-10 ">
                                </div>
                                <div class="resume-m">
                                    <p class="clearfix w385">
                                        <a href="javascript:$('#fileUp').show();void(0);" class="up-resume ft14 fc-333 re_upload_resume">
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
                                <ul class="tab-blue clearfix" id="yw0">
                                    <li class="here"><a href="ResumeBasic.aspx">基本信息</a></li>
                                    <li><a href="ResumeEdu.aspx">教育背景</a></li>
                                </ul>
                                <div class="pos-r">
                                    <form id="fom1" runat="server">
                                    <table width="752" border="0" cellspacing="0" cellpadding="0" class="tb-fillin">
                                        <tr>
                                            <td width="45" align="right">
                                            </td>
                                            <td width="76">
                                                <strong>用户姓名</strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="txt_ChineseName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td>
                                                <strong>出生日期</strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="txt_Birth" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                            </td>
                                            <td width="76">
                                                <strong>性&nbsp;&nbsp;&nbsp;&nbsp;别</strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="txt_Sex" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                            </td>
                                            <td width="76">
                                                <strong>现居住地</strong>
                                            </td>
                                            <td>
                                                 <asp:Label ID="txt_LivePlace" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                            </td>
                                            <td width="76">
                                                <strong>手机号码</strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="txt_Mobile" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                            </td>
                                            <td width="76">
                                                <strong>邮箱地址</strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="txt_Email" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="45" align="right">
                                            </td>
                                            <td width="76">
                                                <strong>期望工作地</strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="txt_WorkPlace" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                            </td>
                                            <td width="76">
                                                <strong>我上传的简历</strong>
                                            </td>
                                            <td>
                                                <%=file_resume %>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    </form>
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
                                <li><a href="App.aspx" class="my-job" id="zhiweiguanli">职位管理</a></li>
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
