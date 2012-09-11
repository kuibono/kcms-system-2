<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChapterList.aspx.cs" Inherits="Web.e.admin.Book.ChapterList" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>章节管理</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" cellpadding="0" cellspacing="1" class="list">
            <thead>
                <tr>
                    <th><input type="checkbox" id="checkall" /></th>
                    <th>标题</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rp_List" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><input name="id" type="checkbox" value="<%#Eval("ID") %>" /></td>
                            <td><a href="ChapterEdit.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a></td>
                            <td>
                                <a href="ChapterEdit.aspx?id=<%#Eval("ID") %>&class=<%#Eval("ClassID") %>">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del&bookid=<%#Eval("BookId") %>"> 删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="10" class="ctrlPn">
                        <asp:Button ID="btn_disable" Text="审核" runat="server" OnClick="btn_disable_Click" />
                        <asp:Button ID="btn_enable" Text="撤销审核" runat="server" OnClick="btn_enable_Click" />
                        <asp:Button ID="Button1" Text="删除" runat="server" OnClick="Button1_Click" />
                        <input type="button" value="新增" onclick="location.href='ChapterEdit.aspx?bookid=<%=id %>'" />
                        <input type="button" value="返回" onclick="history.go(-1)" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
