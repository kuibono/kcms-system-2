<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserFormEdit.aspx.cs" Inherits="Web.e.admin.user.UserFormEdit" ValidateRequest="false"%>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户表单修改</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="tip">非专业人员，请勿修改此内容</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        用户表单编辑
                    </th>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                    表单名
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_FormName" runat="server" EnableValidate="true" 
                            EnableNull="false" Width="234px"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                    表单
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="500px" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>

            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="btn_Save" Text="保存" runat="server" onclick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="location.href='SysUserList.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>
