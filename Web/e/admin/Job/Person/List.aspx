<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.e.admin.Job.Person.List" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人才管理</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="search">
            搜索： &nbsp;&nbsp;&nbsp; 用户名
            <asp:textbox id="txt_UserName" runat="server"></asp:textbox>
            &nbsp;&nbsp;
            <asp:dropdownlist id="ddl_Group" runat="server"></asp:dropdownlist>
            <asp:dropdownlist id="ddl_Enabled" runat="server">
                <asp:ListItem Text="--不限--" Value=""></asp:ListItem>
                <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                <asp:ListItem Text="停用" Value="0"></asp:ListItem>
            </asp:dropdownlist>
            <asp:button id="btn_Search" runat="server" text="搜索" onclick="btn_Search_Click" />
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
                        账号
                    </th>
                    <th>
                        所在组
                    </th>
                    <th>
                        邮件
                    </th>
                    <th>
                        启用
                    </th>
                    <th>
                        管理
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:repeater id="rp_list" runat="server">
                    <ItemTemplate>
                        <tr class="<%#Eval("Enable").ToBoolean()?"":"disabled" %>">
                            <td>
                                <input name="id" type="checkbox" value="<%#Eval("ID") %>" />
                            </td>
                            <td>
                                <%#Eval("ID") %>
                            </td>
                            <td>
                                <%#Eval("UserName") %>
                            </td>
                            <td>
                                <%#GetGroupNameByID(Eval("Group").ToInt32())%>
                            </td>
                            <td>
                                <%#Eval("Email") %>
                            </td>
                            <td>
                                <%#Eval("Enable").ToBoolean().ToChinese()%>
                            </td>
                            <td> 
                                <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del">删除</a>
                                <a href="../Resume/List.aspx?uid=<%#Eval("ID") %>">简历</a>
                                <a href="../Application/List.aspx?id=<%#Eval("ID") %>">申请记录</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="8" class="ctrlPn">
<%--                        <asp:button id="btn_disable" text="停用" runat="server" onclick="btn_disable_Click" />
                        <asp:button id="btn_enable" text="启用" runat="server" onclick="btn_enable_Click" />--%>
                        <asp:button id="btn_Add" text="新增" runat="server" onclientclick="location.href='Edit.aspx';return false" />
                        <asp:button id="Button1" text="删除" runat="server" onclick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <vd:aspnetpager id="pager" runat="server" firstpagetext="首页" lastpagetext="尾页" nextpagetext="后页"
                            prevpagetext="前页" alwaysshow="true">
                        </vd:aspnetpager>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
