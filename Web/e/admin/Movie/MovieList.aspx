<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="Web.e.admin.Movie.MovieList" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>信息管理</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btn_Add").click(function () {
                if ($("#ddl_Class_search").val() != "") {
                    location.href = "MovieEdit.aspx?class=" + $("#ddl_Class_search").val();
                }
                return false;
            });
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="search">
            搜索：
            <%--<asp:DropDownList ID="ddl_Prop" runat="server">
                <asp:ListItem Text="--不限属性--" Value=""></asp:ListItem>
                <asp:ListItem Text="置顶" Value="SetTop"></asp:ListItem>
                <asp:ListItem Text="推荐" Value="Tuijian"></asp:ListItem>
                <asp:ListItem Text="头条" Value="Toutiao"></asp:ListItem>
                <asp:ListItem Text="未审核" Value="UnAudit"></asp:ListItem>
                <asp:ListItem Text="已审核" Value="Audit"></asp:ListItem>
            </asp:DropDownList>
            |--%>
            <asp:TextBox ID="txt_Key" runat="server"></asp:TextBox>
            <asp:DropDownList ID="txt_Column" runat="server">
                <asp:ListItem Text="--不限字段--" Value=""></asp:ListItem>
                <asp:ListItem Text="标题" Value="Title"></asp:ListItem>
                <asp:ListItem Text="演员" Value="Actors"></asp:ListItem>
                <asp:ListItem Text="标签" Value="Tags"></asp:ListItem>
                <asp:ListItem Text="地区" Value="Location"></asp:ListItem>
                <asp:ListItem Text="简介" Value="Intro"></asp:ListItem>
                <asp:ListItem Text="ID" Value="ID"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddl_Class" runat="server">
                <asp:ListItem Text="--所有栏目--" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddl_Zt" runat="server">
                <asp:ListItem Text="--所有专题--" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddl_Order" runat="server">
                <asp:ListItem Text="按发布时间" Value="InsertTime"></asp:ListItem>
                <asp:ListItem Text="按剧集ID" Value="ID"></asp:ListItem>
                <asp:ListItem Text="按更新时间" Value="UpdateTime"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddl_Desc" runat="server">
                <asp:ListItem Text="按信息倒序排列" Value="DESC"></asp:ListItem>
                <asp:ListItem Text="顺序排列" Value="ASC"></asp:ListItem>
            </asp:DropDownList>
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
                        导演
                    </th>
                    <th>
                        演员
                    </th>
                    <th>
                        标签
                    </th>
                    <th>
                        地区
                    </th>
                    <th>
                        发行时间
                    </th>
                    <th>
                        更新到
                    </th>
                    <th>
                        状态
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
                                <%#Eval("Director")%>
                            </td>
                            <td>
                                <%#Eval("Actors")%>
                            </td>
                            <td>
                                <%#Eval("Tags")%>
                            </td>
                            <td>
                                <%#Eval("Location")%>
                            </td>
                            <td>
                                <%#Eval("PublicYear")%>
                            </td>
                            <td>
                                <%#Eval("LastDramaTitle")%>
                            </td>
                            <td>
                                <%#Eval("Status")%>
                            </td>
                            <td>
                                <a href="UrlList.aspx?movieid=<%#Eval("ID") %>&type=kuaib">快播</a> 
                                <a href="UrlList.aspx?movieid=<%#Eval("ID") %>&type=baidu">百度</a> 
                                <a href="UrlList.aspx?movieid=<%#Eval("ID") %>&type=mag">磁力链</a> 
                                <a href="MultiAdd.aspx?id=<%#Eval("ID") %>&type=mag">批量</a> 
                                <a href="MovieEdit.aspx?id=<%#Eval("ID") %>&class=<%#Eval("ClassID") %>">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del&class=<%=cls %>">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="11" class="ctrlPn">
                        <asp:Button ID="btn_disable" Text="审核" runat="server" OnClick="btn_disable_Click" />
                        <asp:Button ID="btn_enable" Text="撤销审核" runat="server" OnClick="btn_enable_Click" />

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
