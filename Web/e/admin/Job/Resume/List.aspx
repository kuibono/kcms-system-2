<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.e.admin.Job.Resume.List" %>
<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>简历管理</title>
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


            <asp:dropdownlist id="ddl_Province" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddl_Province_SelectedIndexChanged">
                <asp:ListItem Text="--不限省份--" Value=""></asp:ListItem>
            </asp:dropdownlist>
            <asp:dropdownlist id="ddl_City" runat="server">
                <asp:ListItem Text="--不限城市--" Value=""></asp:ListItem>
            </asp:dropdownlist>
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
                        标题
                    </th>
                    <th>
                        姓名
                    </th>
                    <th>
                        省
                    </th>
                    <th>
                        市
                    </th>
                    <th>
                        手机
                    </th>
                    <th>
                        Email
                    </th>
                    <th>
                        性别
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
                                <%#Eval("Title")%>
                            </td>
                            <td>
                                <%#Eval("ChineseName")%>
                            </td>
                            <td>
                                 <%#Eval("province1")%>
                            </td>
                            <td>
                                 <%#Eval("city1")%>
                            </td>
                            <td>
                                 <%#Eval("Mobile")%>
                            </td>
                            <td>
                                 <%#Eval("Email")%>
                            </td>
                            <td>
                                 <%#Eval("IsMale").ToBoolean()?"男":"女"%>
                            </td>
                            <td>
                                <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del"> 删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="11" class="ctrlPn">
                        <asp:Button ID="Button1" Text="删除" runat="server" OnClick="Button1_Click" />
                        &nbsp;
                        <asp:Button ID="btn_Add" Text="新增" OnClientClick="location.href='Edit.aspx';return false;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="11">
                        <vd:AspNetPager ID="pager" runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="后页"
                            PrevPageText="前页" AlwaysShow="true" OnPageChanged="pager_PageChanged">
                        </vd:AspNetPager>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
