<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.e.admin.Login" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="cc1" %>
<html>
<head>
    <title>网站管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <style type="text/css">
        .text
        {
            font-size: 12px;
            line-height: 18px;
        }
        .input
        {
            border-right: #999999 1px solid;
            border-top: #999999 1px solid;
            border-left: #999999 1px solid;
            border-bottom: #999999 1px solid;
            height: 18px;
            background-color: #efefef;
        }
        .style1
        {
            font-weight: bold;
            font-size: 12px;
            color: #666666;
        }
        #btn_Login
        {
            background-image:url(/skin/job/img/button-search.gif);
            border-width:0;
            width:28px;
            height:16px;
        }
    </style>
    <meta content="MSHTML 6.00.2800.1106" name="GENERATOR">
</head>
<body text="#000000" leftmargin="0" topmargin="0" onload="javascript:document.all.code.focus();">
    <form id="Form1" name="form1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tbody>
            <tr>
                <td align="center" height="470">
                    <table cellspacing="0" cellpadding="0" width="500" border="0">
                        <tbody>
                            <tr>
                                <td width="230" align="center" valign="middle">
                                    <img src="/skin/job/img/logo.gif" width="132" height="65"><br>
                                </td>
                                <td align="center">
                                    <table class="text" cellspacing="0" cellpadding="0" width="350" border="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2">
                                                    <font class="style1" size="4">第一职网站后台管理系统</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    管理员：
                                                    <cc1:vtextbox id="txt_UserName" runat="server" enablevalidate="true" enablenull="false"
                                                        cssclass="input"></cc1:vtextbox>
                                                </td>
                                            </tr>
                                            <tr valign="bottom">
                                                <td colspan="2">
                                                    密&nbsp;&nbsp;码：
                                                    <cc1:vtextbox id="txt_Userpass" runat="server" enablevalidate="true" enablenull="false"
                                                        textmode="Password" cssclass="input"></cc1:vtextbox>
                                                </td>
                                            </tr>
                                            <tr valign="bottom">
                                                <td colspan="2" valign="bottom" style="height:30px; vertical-align:bottom; padding:0;">
                                                    验证码：
                                                    <cc1:vtextbox id="txt_VCode" runat="server" enablevalidate="true" enablenull="false"
                                                        cssclass="input" width="80px" height="30px"></cc1:vtextbox>
                                                    <img src="/e/admin/tool/safecode.ashx" width="65" height="30" title="看不清？点击更换" alt="看不清？点击更换" onClick="this.src=this.src+'?'">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="345" height="3">
                                                </td>
                                                <td width="102" rowspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="345">
                                                    <asp:Button ID="btn_Login" runat="server" class="login_btn" Text="" OnClick="btn_Login_Click" CssClass="submit" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <hr size="1" noshade>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right" class="text">
                                    <font color="#666666"><b>技术支持</b>：南京光芒科技有限公司 nj-gm.com, All rights reserveds.<br>
                                        <b>公司地址</b>：南京市白下路7－11号新万里广场601室(210001)
                                        <br>
                                        <b>总机</b>：025-84653096 84653090 传真：025-84518060转18 免费热线：4000251180<br>
                                    </font>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</form></html>
