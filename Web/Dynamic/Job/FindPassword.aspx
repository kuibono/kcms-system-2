<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPassword.aspx.cs" Inherits="Web.Dynamic.Job.FindPassword" %>

<%@ Import Namespace="Voodoo.Basement" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>
        找回密码-南京第一职网</title>
    <link type="text/css" rel="stylesheet" href="/skin/job/css/style.css" />
    <link type="text/css" rel="stylesheet" href="/skin/job/css/2013.css" />
    <link href="/skin/job/css/incenter.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../skin/script/jquery-1.7.min.js"></script>
    <script type="text/javascript">
        function post(data) {
            $.post("/e/Job/Post.aspx", { id: data }, function (r) {
                alert(r.Text);
            }, "json")
        }
    </script>
</head>
<body>
    <%=JobAction.TopHtml %>
    <table width="989" bgcolor="#FFFFFF" align="center" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="20">
            </td>
        </tr>
    </table>
    <table width="989" align="center" bgcolor="#FFFFFF" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left">
                <div class="find_wrap">
                    <div class="title clearfix">
                        <span class="bold">找回密码</span>
                    </div>
                    <div class="content">
                        <div class="progress p_1">
                        </div>
                        <form id="form1" runat="server">
                        <div class="line">
                            <label>
                                <span class="tit s_tit">邮箱/手机号码：</span><input runat="server" name="txtEmail" type="text"
                                    maxlength="40" id="txtEmail" tabindex="1" class="text" value="" onfocus="CheckEmailFocus();"
                                    onblur="CheckBlue(this,'DIVshowError',1);" />
                            </label>
                            <span id="email_ok" class="tip_yes" style="display: none"></span><span id="DIVshowError"
                                class="e9" style="display: none;"></span>
                        </div>
                        <div class="line">
                            <label>
                                <span class="tit ws2 s_tit">验 证 码：</span>
                                <input name="txtVerifyCode" type="text" maxlength="4" id="txtVerifyCode" tabindex="2"
                                    class="text" value="" onfocus="CheckVcodeFocus()" onblur="CheckBlue(this,'DIVshowError_code',1);"
                                    size="10" onkeydown="CheckdoSubmit(event)" runat="server" />
                            </label>
                            <span id="vcode_ok" class="tip_yes" style="display: none"></span><span id="DIVshowError_code"
                                class="e9" style="display: none;"></span>
                        </div>
                        <div>
                            <span class="tit"></span><a href="javascript:$('#imgVcode').prop('src','/e/admin/tool/safecode.ashx?'+Math.random());"
                                title="换张图" tabindex="3">
                                <img id='imgVcode' src="/e/admin/tool/safecode.ashx" alt="验证码" /></a>看不清？ <a href="javascript:$('#imgVcode').prop('src','/e/admin/tool/safecode.ashx?'+Math.random())"
                                    tabindex="4">换张图</a>
                        </div>
                        <div>
                            <span class="tit"></span>
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn_next" Text="" OnClick="Button1_Click" />
                        </div>
                        </form>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <%=JobAction.BottomHtml %>
</body>
</html>
