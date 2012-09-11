<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoList.aspx.cs" Inherits="Web.e.admin.Info.InfoList" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分类信息列表</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btn_Add").click(function () {
                if ($("#ddl_Class_search").val() != "") {
                    location.href = "BookEdit.aspx?class=" + $("#ddl_Class_search").val();
                }
                return false;
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="search">
            搜索：
            
            标题：<asp:TextBox ID="txt_Title" runat="server"></asp:TextBox>

            联系人：<asp:TextBox ID="txt_Contact" runat="server"></asp:TextBox>

            电话：<asp:TextBox ID="txt_Tel" runat="server"></asp:TextBox>

            地址：<asp:TextBox ID="txt_Address" runat="server"></asp:TextBox>

            简介：<asp:TextBox ID="txt_Intro" runat="server"></asp:TextBox>
            
            <asp:Button ID="btn_Search" runat="server" Text="搜索" />
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
                        类别
                    </th>
                    <th>
                        联系人
                    </th>
                    <th>
                        电话
                    </th>
                    <th>
                        地址
                    </th>
                    <th>
                        发布时间
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
                                <%#Eval("ClassName")%>
                            </td>
                            <td>
                                <%#Eval("Contact")%>
                            </td>
                            <td>
                                <%#Eval("Tel")%>
                            </td>
                            
                            <td>
                                <%#Eval("Address")%>
                            </td>
                            <td>
                                <%# Eval("PostTime")%>
                            </td>
                            <td>
                                <a href="InfoEdit.aspx?id=<%#Eval("ID") %>&class=<%#Eval("ClassID") %>&type=1">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del&class=<%=cls %>&type=1"> 删除</a>
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
                        <asp:Button ID="btn_Status" Text="完结" runat="server" OnClick="btn_Status_Click" />
                        <asp:Button ID="btn_First" Text="连载中" runat="server" OnClick="btn_Status0_Click" />
                        <asp:Button ID="Button1" Text="删除" runat="server" OnClick="Button1_Click" />
                        &nbsp;
                        <asp:DropDownList ID="ddl_Class_search" runat="server"></asp:DropDownList>
                        <asp:Button ID="btn_Add" Text="新增" runat="server" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btn_createPage" Text="重新生成" runat="server" 
                            onclick="btn_createPage_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="10">
                        <vd:AspNetPager ID="pager" runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="后页"
                            PrevPageText="前页" AlwaysShow="true" OnPageChanged="pager_PageChanged">
                        </vd:AspNetPager>
                    </td>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>
