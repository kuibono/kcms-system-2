<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.e.admin.Job.Application.List" %>

<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请列表</title>
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
                        用户
                    </th>
                    <th>
                        公司
                    </th>
                    <th>
                        职位
                    </th>
                    <th>
                        简历
                    </th>
                    <th>
                        时间
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
                               <a href="../Person/edit.aspx?id=<%#Eval("UserID")%>"><%#Eval("UserName")%></a> 
                            </td>
                            <td>
                                <a href="../Company/edit.aspx?id=<%#Eval("CompanyID")%>"> <%#Eval("CompanyName")%></a>
                            </td>
                            <td>
                                 <a href="../Post/edit.aspx?id=<%#Eval("PostID")%>"><%#Eval("Title")%></a>
                            </td>
                            <td>
                                <a href="../Resume/edit.aspx?id=<%#Eval("ResumeID")%>"><%#Eval("rTitle")%></a>
                            </td>
                            <td>
                                <%#Eval("ApplicationTime").ToDateTime().ToString()%>
                            </td>
                            <td>
                                <a href="Edit.aspx?id=<%#Eval("ID") %>">查看</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del"> 删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="8" class="ctrlPn">
                        <asp:button id="Button1" text="删除" runat="server" onclick="Button1_Click" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <vd:aspnetpager id="pager" runat="server" firstpagetext="首页" lastpagetext="尾页" nextpagetext="后页"
                            prevpagetext="前页" alwaysshow="true" onpagechanged="pager_PageChanged">
                        </vd:aspnetpager>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
