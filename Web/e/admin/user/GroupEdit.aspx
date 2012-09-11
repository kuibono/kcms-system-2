<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupEdit.aspx.cs" Inherits="Web.e.admin.user.GroupEdit" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>会员组管理</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">会员组的编辑修改</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        会员组编辑
                    </th>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                    组名
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_GroupName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                    级别
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_grade" runat="server" Text="0" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                    每天投稿数
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_MaxPost" runat="server" Text="0" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td >
                    投稿自动审核
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_PostAotuAudit" runat="server" Text="自动审核" />
                    </td>
                </tr>
                <tr>
                    <td >
                    允许注册
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_EnableReg" runat="server" Text="允许" />
                    </td>
                </tr>
                <tr>
                    <td >
                    注册自动审核
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_RegAutoAudit" runat="server" Text="自动审核" />
                    </td>
                </tr>
                <tr>
                    <td >
                    注册表单
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_RegForm" runat="server"></asp:DropDownList>
                    </td>
                </tr>
             
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="btn_Save" Text="保存" runat="server" onclick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="location.href='GroupList.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>
