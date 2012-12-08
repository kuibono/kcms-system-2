<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VarTemplateEdit.aspx.cs" Inherits="Web.e.admin.template.VarTemplateEdit" ValidateRequest="false" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>模版变量</title>
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
                    模版变量编辑
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="163">
                    变量名称
                </td>
                <td>
                    <vd:VTextBox ID="txt_VarName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                </td>
            </tr>

            <tr>
                <td>
                    模版内容
                </td>
                <td>
                     <CKEditor:CKEditorControl ID="txt_Content" runat="server" Height="200" BasePath="~/e/data/ckeditor" Width="99%">
		            </CKEditor:CKEditorControl>
                   <%-- <vd:VTextBox ID="txt_Content" runat="server" EnableValidate="true" EnableNull="false" TextMode="MultiLine" Height="400px" Width="99%"></vd:VTextBox>--%>
                </td>
            </tr>

        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="location.href='VarTemplateList.aspx'" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
