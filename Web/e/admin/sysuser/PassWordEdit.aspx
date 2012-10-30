<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassWordEdit.aspx.cs" Inherits="Web.e.admin.sysuser.PassWordEdit" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>用户编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">确保用户信息正确</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        用户编辑
                    </th>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                    密码
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Password" TextMode="Password" runat="server" EnableValidate="true" EnableNull="true"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    新密码
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_PasswordNew" TextMode="Password" runat="server" EnableValidate="true" EnableNull="true"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    确认密码
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_PasswordConfirm" TextMode="Password" runat="server" EnableValidate="true" EnableNull="true"></vd:VTextBox>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="btn_Save" Text="保存" runat="server" onclick="btn_Save_Click" />
                        &nbsp;
                    </th>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>
