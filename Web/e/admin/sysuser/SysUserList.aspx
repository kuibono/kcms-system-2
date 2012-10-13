<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysUserList.aspx.cs" Inherits="Web.e.admin.sysuser.SysUserList" %>
<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
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
                        姓名
                    </th>
                    <th>
                        部门
                    </th>
                    <th>
                        所在组
                    </th>
                    <th>
                        邮件
                    </th>
                    <th>
                        电话
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
                <asp:Repeater ID="rp_list" runat="server">
                    <ItemTemplate>
                        <tr class="<%#Eval("Enabled").ToBoolean()?"":"disabled" %>">
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
                                <%#Eval("ChineseName") %>
                            </td>
                            <td>
                                <%#GetDepartmentByID(Eval("Department").ToInt32())%>
                            </td>
                            <td>
                                <%#GetGroupNameByID(Eval("UserGroup").ToInt32())%>
                            </td>
                            <td>
                                <%#Eval("Email") %>
                            </td>
                            <td>
                                <%#Eval("TelNumber") %>
                            </td>
                            <td>
                                <%#Eval("Enabled").ToBoolean().ToChinese()%>
                            </td>
                            <td>
                                <a href="?id=<%#Eval("ID") %>&action=disable">停用</a> 
                                <a href="?id=<%#Eval("ID") %>&action=enable">启用</a> 
                                <a href="SysUserEdit.aspx?id=<%#Eval("ID") %>">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="10" class="ctrlPn">
                        <asp:Button ID="btn_disable" Text="停用" runat="server" 
                            onclick="btn_disable_Click" />
                        <asp:Button ID="btn_enable" Text="启用" runat="server" 
                            onclick="btn_enable_Click" />
                        <asp:Button ID="btn_Add" Text="新增" runat="server" OnClientClick="location.href='SysUserEdit.aspx';return false" />
                        <asp:Button ID="Button1" Text="删除" runat="server" onclick="Button1_Click" />
                        <asp:Button ID="btn_MangeDep" Text="管理部门" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="10">
                        <vd:AspNetPager ID="pager" runat="server" FirstPageText="首页" LastPageText="尾页" 
                            NextPageText="后页" PrevPageText="前页" AlwaysShow="true">
                        </vd:AspNetPager>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
