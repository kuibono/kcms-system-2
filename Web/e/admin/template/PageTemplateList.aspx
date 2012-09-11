<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageTemplateList.aspx.cs" Inherits="Web.e.admin.template.PageTemplateList" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>列表模版管理</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="tip">
        非专业人员不要对此进行任何更改
    </div>
    <table border="1" cellpadding="0" cellspacing="1" class="list">
        <thead>
            <tr>
                <th>
                    <input type="checkbox" id="checkall" />
                </th>
                <th>
                    ID
                </th>
                <th>
                    页面名称
                </th>
                <th>
                    文件名
                </th>
                <th>
                    跟随生成
                </th>
                <th>
                    管理
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rp_list" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <input name="id" type="checkbox" value="<%#Eval("ID") %>" />
                        </td>
                        <td>
                            <%#Eval("ID") %>
                        </td>
                        <td>
                            <%#Eval("PageName")%>
                        </td>
                        <td>
                            <a href="<%#Eval("FileName")%>" target="_blank"><%#Eval("FileName")%></a>
                        </td>
                        <td>
                            <%#CREATE_WITH[Eval("CreateWith").ToInt32()]%>
                        </td>
                        <td>
                            <a href="PageTemplateEdit.aspx?id=<%#Eval("ID") %>">修改</a> <a href="?id=<%#Eval("ID") %>&action=del">
                                删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="7" class="ctrlPn">
                    &nbsp;<asp:Button ID="btn_Add" Text="新增" runat="server" OnClientClick="location.href='PageTemplateEdit.aspx';return false;" />
                    &nbsp;<asp:Button ID="btn_Del" runat="server" Text="删除" 
                        onclick="btn_Del_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
    </div>
    </form>
</body>
</html>
