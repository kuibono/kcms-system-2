<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageTemplateEdit.aspx.cs" Inherits="Web.e.admin.template.PageTemplateEdit" ValidateRequest="false" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>页面模板编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        对页面模板进行修改编辑、非专业人员请勿操作</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    页面模板编辑
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="163">
                    启用
                </td>
                <td>
                    <asp:CheckBox ID="chk_Enable" runat="server" Text="启用" />
                </td>
            </tr>
            <tr>
                <td width="163">
                    页面名称
                </td>
                <td>
                    <vd:VTextBox ID="txt_pageName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    文件名称
                </td>
                <td>
                    <vd:VTextBox ID="txt_FileName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    跟随生成
                </td>
                <td>
                    <asp:DropDownList ID="ddl_CreateWith" runat="server">
                        <asp:ListItem Text="不生成" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="首页" Value="1"></asp:ListItem>
                        <asp:ListItem Text="列表页" Value="2"></asp:ListItem>
                        <asp:ListItem Text="内容页" Value="3"></asp:ListItem>
                        <asp:ListItem Text="详细信息页" Value="4"></asp:ListItem>
                        <asp:ListItem Text="公共模版" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr style="<%=showIfDevelopment%>">
                <td>
                    模版内容
                </td>
                <td>
                    <%--<CKEditor:CKEditorControl ID="txt_Content" runat="server" Height="200" BasePath="~/ckeditor" Width="99%">
		            </CKEditor:CKEditorControl>--%>
                    <vd:VTextBox ID="txt_Content" runat="server" TextMode="MultiLine" Height="200px" Width="99%"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    正文
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="FCKeditor1" runat="server" Height="200" BasePath="~/e/data/ckeditor" Width="99%">
		            </CKEditor:CKEditorControl>
                    <%--<FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="300px">
                    </FCKeditorV2:FCKeditor>--%>
                    
                </td>
            </tr>

        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="location.href='PageTemplateList.aspx'" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
