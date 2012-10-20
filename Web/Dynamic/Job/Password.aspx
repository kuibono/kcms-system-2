<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="Web.Dynamic.Job.Password" %>

<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>南京第一职网</title>
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
                                    <li class="here"><a href="Password.aspx">更改密码</a></li>
                                </ul>
                                <form id="form1" runat="server">
                                <table width="752" cellspacing="0" cellpadding="0" border="0" class="tb-fillin">
                                    <tbody>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;
                                            </td>
                                            <td width="76">
                                                <strong>当前密码</strong>
                                            </td>
                                            <td>
                                                <vd:VTextBox ID="txt_Old" runat="server" CssClass="inp-154 bor-d7d7d7 radius-4" 
                                                    TextMode="Password"></vd:VTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;
                                            </td>
                                            <td width="76">
                                                <strong>更改密码</strong>
                                            </td>
                                            <td>
                                                <vd:VTextBox ID="txt_New" runat="server" CssClass="inp-154 bor-d7d7d7 radius-4" 
                                                    TextMode="Password"></vd:VTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;
                                            </td>
                                            <td width="76">
                                                <strong>确认密码</strong>
                                            </td>
                                            <td>
                                                <vd:VTextBox ID="txt_NewConf" runat="server" CssClass="inp-154 bor-d7d7d7 radius-4" 
                                                    TextMode="Password"></vd:VTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;
                                            </td>
                                            <td width="76" valign="top">
                                                &nbsp;
                                            </td>
                                            <td>

                                                <asp:Button ID="btn_Save" runat="server" CssClass="btn-blue114" Text="保存" 
                                                    onclick="btn_Save_Click" />
                                        </tr>
                                    </tbody>
                                </table>
                                </form>
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
                                <li class="here"><a href="Password.aspx" class="my-manage" id="zhanghaoguanli">帐号管理</a></li>
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
