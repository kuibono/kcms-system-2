﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.e.admin.Ad.Ad.List" %>

<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告列表</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="search">
            搜索：
            <asp:textbox id="txt_Key" runat="server"></asp:textbox>
            <asp:button id="btn_Search" runat="server" text="搜索" />
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
                        名称
                    </th>
                    <th>
                        广告位
                    </th>
                    <th>
                        URL
                    </th>
                    <th>
                        管理
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:repeater id="rp_list" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input name="id" type="checkbox" value="<%#Eval("ID") %>" />
                            </td>
                            <td>
                                <%#Eval("ID") %>
                            </td>
                            <td>
                                <%#Eval("Title")%>
                            </td>
                            <td>
                                <%#Eval("Group")%>
                            </td>
                            <td>
                                <%#Eval("Url")%>
                            </td>
                            <td>
                                <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del"> 删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="9" class="ctrlPn">
                        <asp:button id="Button1" text="删除" runat="server" onclick="Button1_Click" />
                        &nbsp;
                        <asp:button id="btn_Add" text="新增" onclientclick="location.href='Edit.aspx';return false;"
                            runat="server" />
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
