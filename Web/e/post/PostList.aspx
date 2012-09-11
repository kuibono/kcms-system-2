<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostList.aspx.cs" Inherits="Web.e.post.PostList" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register assembly="Voodoo" namespace="Voodoo.UI" tagprefix="cc1" %>
<%= Voodoo.Basement.CreatePage.CreateHeaderString("我的文章") %>
<style type="text/css">
#tb_post
{
    border:solid 1px #c0c0c0;
    border-collapse:collapse;
    color:#000;
    width:100%;
    margin:10px 2px 10px 2px;
}
#tb_post td
{
    height:22px;
    line-height:22px;
    border:solid 1px #c0c0c0;
    padding:3px;
}
.news_header
{
    background-color:#ddd;
}

</style>
        <div id="main_1" class="clearfix mg">
        	<div class="nav">您的位置：<a href="/">首页</a>> <a href="javascript:void(0)">我的文章</a></div>
            <div id="newslist" class="left inner" style="width: 660px;">
                <h1>
                    我的文章
                </h1>
                <form id="form1" runat="server">
                <table border="1" id="tb_post">
                    <tr class="news_header">
                        <td align="center"> ID</td>
                        <td align="center">标题</td>
                        <td align="center">投递时间</td>
                        <td align="center">状态</td>
                        <td align="center">管理</td>
                    </tr>
                    <asp:Repeater id="rp_list" runat="Server">
                        <ItemTemplate>
                        <tr>
                            <td align="center"><%#Eval("ID") %></td>
                            <td align="center"><%#Eval("Title") %></td>
                            <td align="center"><%#Eval("NewsTime")%></td>
                            <td align="center"><%#Eval("Audit").ToBoolean()?"已经发布":"未审核"%></td>
                            <td >
                                <%#Eval("Audit").ToBoolean() ? "" : "<a href='PostNews.aspx?id=" + Eval("ID") + "'>修改</a> <a href='?id=" + Eval("ID") + "&action=del' onclick=\"return confirm('确定要删除这条记录吗？')\">删除</a>"%>
                            </td>
                        </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </form>
            </div>
            <div class="right" style="width: 259px; margin-left:32px;">
                <h1>
                    功能菜单
                 </h1>
                <ul style=" padding:10px"> 
                    <%=Voodoo.Basement.CreatePage.BuildUserMenuString()%>
                </ul>
            </div>
        </div>

 <%= Voodoo.Basement.CreatePage.CreateFooterString() %>