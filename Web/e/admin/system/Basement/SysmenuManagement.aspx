<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysmenuManagement.aspx.cs"
    Inherits="Web.e.admin.system.Basement.SysmenuManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统参数管理</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <style type="text/css">
    div
    {
        height:auto;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" style="border-collapse: collapse">
            <tr>
                <td style="width:300px;">
                    <asp:treeview id="PanelTree" runat="server" 
                        onselectednodechanged="PanelTree_SelectedNodeChanged" Width="100px">
                </asp:treeview>
                </td>
                <td style="width:300px;">
                    <asp:treeview id="SubTree" runat="server" Width="100px">
                </asp:treeview>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table border="1" cellpadding="0" cellspacing="0" class="edit">
                        <thead>
                            <tr>
                                <th colspan="2">
                                    Panel编辑
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr width="163">
                                <td>
                                    标题
                                </td>
                                <td>
                                    <asp:textbox id="txt_pn_title" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    图标
                                </td>
                                <td>
                                    <asp:dropdownlist id="ddl_ph_icon" runat="server"></asp:dropdownlist>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    序号
                                </td>
                                <td>
                                    <asp:textbox id="txt_pn_orderindex" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    权限
                                </td>
                                <td>
                                    <asp:checkboxlist id="cbl_pn_group" runat="server"></asp:checkboxlist>
                                </td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th colspan="2">
                                    <asp:button id="btn_Pn_new" text="新增" runat="server" onclick="btn_Pn_new_Click" />
                                    &nbsp;<asp:button id="btn_Save_pn" text="保存" runat="server" onclick="btn_Save_pn_Click" />
                                </th>
                            </tr>
                        </tfoot>
                    </table>
                </td>
                <td valign="top">
                    <table border="1" cellpadding="0" cellspacing="0" class="edit">
                        <thead>
                            <tr>
                                <th colspan="2">
                                    Tree编辑
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr width="163">
                                <td>
                                    标题
                                </td>
                                <td>
                                    <asp:textbox id="txt_tree_title" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    图标
                                </td>
                                <td>
                                    <asp:dropdownlist id="ddl_tree_icon" runat="server"></asp:dropdownlist>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    序号
                                </td>
                                <td>
                                    <asp:textbox id="txt_tree_orderindex" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    链接
                                </td>
                                <td>
                                    <asp:textbox id="txt_tree_url" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    InnerHtml
                                </td>
                                <td>
                                    <asp:textbox id="txt_tree_html" runat="server" TextMode="MultiLine"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    权限
                                </td>
                                <td>
                                    <asp:checkboxlist id="cbl_tree_group" runat="server"></asp:checkboxlist>
                                </td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th colspan="2">
                                    <asp:button id="btn_tree_new" text="新增" runat="server" onclick="btn_tree_new_Click" />
                                    &nbsp;<asp:button id="btn_Save_tree" text="保存" runat="server" onclick="btn_Save_tree_Click" />
                                </th>
                            </tr>
                        </tfoot>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
