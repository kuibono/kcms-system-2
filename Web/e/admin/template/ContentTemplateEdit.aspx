<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContentTemplateEdit.aspx.cs" Inherits="Web.e.admin.template.ContentTemplateEdit" ValidateRequest="false" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>内容模板编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        对内容模板进行修改编辑、非专业人员请勿操作</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    内容模板编辑
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="163">
                    模板名称
                </td>
                <td>
                    <vd:VTextBox ID="txt_TempName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    系统模型
                </td>
                <td>
                    <asp:DropDownList ID="ddl_SysModel" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    时间格式
                </td>
                <td>
                    <vd:VTextBox ID="txt_TimeFormat" runat="server" EnableValidate="true" EnableNull="false" Text="yyyy-MM-dd"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    模版内容
                </td>
                <td>
                    <vd:VTextBox ID="txt_Content" runat="server" EnableValidate="true" EnableNull="false" TextMode="MultiLine" Height="400px" Width="99%"></vd:VTextBox>
                </td>
            </tr>

        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="location.href='ContentTemplateList.aspx'" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
