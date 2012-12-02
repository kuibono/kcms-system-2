<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RewriteSetting.aspx.cs"
    Inherits="Web.e.admin.system.SystemParameter.RewriteSetting" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>基本参数</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
    <style type="text/css">
        input[type='text'], textarea
        {
            width: 300px;
            height: 50px;
            float: left;
        }
        .right
        {
            float: left;
        }
        .edit tbody tr, .edit tbody tr td
        {
            height: 60px;
            line-height: 60px;
        }
        .style1
        {
            width: 103px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        ....</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    静态页面存储规则设置
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="style1">
                    新闻列表
                </td>
                <td>
                    <asp:RadioButtonList ID="rbl_NewsList" runat="server">
                        <asp:ListItem Value="0">/Class/{classid}/{page}</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    新闻页面
                </td>
                <td>
                    <asp:RadioButtonList ID="rbl_News" runat="server">
                        <asp:ListItem Value="0">/News/{newsid}/</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    图片列表
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    图片页面
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    问答列表
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    问题页面
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    书籍列表
                </td>
                <td>
                    <asp:RadioButtonList ID="rbl_BookList" runat="server">
                        <asp:ListItem Value="0">/Book/Class/{classname}/</asp:ListItem>
                        <asp:ListItem Value="1">/Book/{classname}/index.htm</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    书籍信息
                </td>
                <td>
                    <asp:RadioButtonList ID="rbl_BookInfo" runat="server">
                        <asp:ListItem Value="0">/Book/Book/{id}/</asp:ListItem>
                        <asp:ListItem Value="1">/Book/b-{id}/</asp:ListItem>
                        <asp:ListItem Value="2">/Book/{classname}/{title}-{author}/</asp:ListItem>
                        <asp:ListItem Value="3">/Book/{title}-{author}/</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    书籍章节
                </td>
                <td>
                    <asp:RadioButtonList ID="rbl_Chapter" runat="server">
                        <asp:ListItem Value="0">/Book/{classname}/{title}-{author}/{id}.htm</asp:ListItem>
                        <asp:ListItem Value="1">/Book/{title}-{author}/{id}.htm</asp:ListItem>
                        <asp:ListItem Value="2">/Book/{classname}/{title}-{author}/{id}/</asp:ListItem>
                        <asp:ListItem Value="3">/Book/{title}-{author}/{id}/</asp:ListItem>
                        <asp:ListItem Value="4">/Book/Chapter/{id}/</asp:ListItem>
                        <asp:ListItem Value="5">/Book/Chapter/{id}.htm</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    章节txt
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    人才列表
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    职位页面
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    公司
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    电影列表
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    电影信息
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    百度播放
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    快播播放
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    剧集列表
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    产品列表
                </td>
                <td>
                    <asp:RadioButtonList ID="rbl_ProductList" runat="server">
                        <asp:ListItem Value="0">/Class/{classid}/</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    产品内容
                </td>
                <td>
                    <asp:RadioButtonList ID="rbl_Product" runat="server">
                        <asp:ListItem Value="0">/p/{productid}/{page}</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="location.href='main.aspx'" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
