<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.e.admin.Login" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>后台登录</title>
<link href="../data/css/loginstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" name="form1" runat="server">
    <div id="main">
    	<div class="l" id="loginForm">
        	<div id="form_username">
            	帐号：<br/><cc1:VTextBox ID="txt_UserName" runat="server" EnableValidate="true" EnableNull="false" CssClass="textbox"></cc1:VTextBox>
            </div>
            <div id="form_password">
            	密码：<br/><cc1:VTextBox ID="txt_Userpass" runat="server" EnableValidate="true" EnableNull="false" TextMode="Password"  CssClass="textbox"></cc1:VTextBox>
            </div>
            <div id="form_vcode">
            	验证码：<br/><cc1:VTextBox ID="txt_VCode" runat="server" EnableValidate="true" EnableNull="false" CssClass="textbox" Width="80px"></cc1:VTextBox>
                <img id="vdimgck" align="absmiddle" onClick="this.src=this.src+'?'" style="cursor: pointer;margin-left:-4px;" alt="看不清？点击更换" src="/e/admin/tool/safecode.ashx"/>
            </div>
            <div id="form_submit">
                <asp:Button ID="btn_Login" runat="server" class="login_btn" Text="" OnClick="btn_Login_Click" CssClass="submit" />
            </div>
            <div id="form_other">
            	<div class="r other">Help: <a href="http://www.aizr.net/">aizr.net</a></div>
                <div class="l other">Design By ：<a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=363212404&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:363212404:45" alt="点击这里给我发消息" title="点击这里给我发消息"></a></div>
            </div>
        </div>
        <div class="l" id="info">

        </div>
        <div class="clear"></div>
    </div>
    </form>
</body>
</html>