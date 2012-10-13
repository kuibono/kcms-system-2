<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.e.admin.Job.Company.List" %>

<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司列表</title>
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
            <asp:dropdownlist id="ddl_Type" runat="server">
                <asp:ListItem Text="--不限类型--" Value=""></asp:ListItem>
            </asp:dropdownlist>
            <asp:dropdownlist id="ddl_EmployeeCount" runat="server">
                <asp:ListItem Text="--不限规模--" Value=""></asp:ListItem>
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
                        公司名称
                    </th>
                    <th>
                        行业
                    </th>
                    <th>
                        性质
                    </th>
                    <th>
                        规模
                    </th>
                    <th>
                        用户
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
                                <%#Eval("CompanyName")%>
                            </td>
                            <td>
                                <%#Eval("Industry")%>
                            </td>
                            <td>
                                <%#JobAction.GetCompanyTypeName(Eval("CompanyType").ToInt32())%>
                            </td>
                            <td>
                                <%#JobAction.GetEmployeeCountName(Eval("EmployeeCount").ToInt32())%>
                            </td>
                            <td>
                                <%#UserAction.GetUserNameByID(Eval("UserID").ToInt32())%>
                            </td>
                            <td>
                                <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del"> 删除</a>
                                <a href="<%#Eval("ID") %>">职位</a>
                                <a href="<%#Eval("ID") %>">新增职位</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="8" class="ctrlPn">
                        <asp:Button ID="Button1" Text="删除" runat="server" OnClick="Button1_Click" />
                        &nbsp;
                        <asp:Button ID="btn_Add" Text="新增" OnClientClick="location.href='Edit.aspx';return false;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
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
