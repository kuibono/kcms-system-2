<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobParameter.aspx.cs" Inherits="Web.e.admin.system.SystemParameter.JobParameter" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>人才参数</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tip">本页进行人才系统基本参数的配置</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        人才配置
                    </th>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="100">
                    启用邮件发送
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_SendMail" runat="server" Text="启用" />
                    </td>
                </tr>

                <tr>
                    <td width="100">
                    发件邮箱地址
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_From" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    发件人姓名
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_FromText" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                    登录帐号
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_LoginName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    登录密码
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Password" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    SMTP服务器
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_SmtpHost" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                     邮件标题
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Subject" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                     邮件内容
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="txt_MailBody" runat="server" Height="200" BasePath="~/e/data/ckeditor" Width="99%">
		                </CKEditor:CKEditorControl>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="location.href='main.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>
