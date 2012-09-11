<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChapterEdit.aspx.cs" Inherits="Web.e.admin.Book.ChapterEdit" ValidateRequest="false" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>章节编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
            章节内容的编辑和修改</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        章节编辑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                        书籍
                    </td>
                    <td>
                        <asp:Label ID="lb_BookTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        分卷
                    </td>
                    <td>
                        <asp:Label ID="lb_ValumeName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        章节名称
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Title" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                
                <tr>
                    <td width="163">
                        章节内容
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Content" runat="server" TextMode="MultiLine" 
                            Height="250px" Width="100%"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        是否VIP
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_IsVip" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        是否启用
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_IsEnable" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        是否草稿
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_IsTemp" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        是否免费章节
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_IsFree" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        是否图片章节
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_IsImageChapter" runat="server" />
                    </td>
                </tr>

            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="history.go(-1)" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>