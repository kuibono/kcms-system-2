<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieRules.aspx.cs" Inherits="Web.e.tool.MovieRules"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            border: 1px solid;
            border-collapse: collapse;
        }
    </style>
    <link type="text/css" rel="Stylesheet" href="../data/css/management.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" border="1" class="style1">
            <thead>
                <tr>
                    <th colspan="2" align="center">
                        规则编辑
                    </th>
                    <th align="center">
                        &nbsp;
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td style="width: 100px;">
                        规则选择
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_RuleList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_RuleList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        规则名称
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        站点名称
                    </td>
                    <td>
                        <asp:TextBox ID="txt_SiteName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        是够电影
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_IsMovie" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        是否搜索规则
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_IsSearchRule" runat="server" Text="如果是搜索规则，将不采集资源地址，只保留播放页面地址。" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        TAG做类
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_UseTagAsClass" runat="server" Text="以Tag作为剧集的分类。" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        位置做类
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_UseLocationAsClass" runat="server" Text="以影视的产地作为影视分类。" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        默认分类
                    </td>
                    <td>
                        <asp:TextBox ID="txt_DefaultClass" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        页面编码
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_Encoding" runat="server">
                            <asp:ListItem>GBK</asp:ListItem>
                            <asp:ListItem>utf-8</asp:ListItem>
                            <asp:ListItem>gb2312</asp:ListItem>
                            <asp:ListItem>big5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        列表页地址
                    </td>
                    <td>
                        <asp:TextBox ID="txt_ListPageUrl" runat="server" Width="400px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="测试" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        分页规则
                    </td>
                    <td>
                        <asp:TextBox ID="txt_NextListRule" runat="server" Rows="5" TextMode="MultiLine" Width="400px"></asp:TextBox>
                        key
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="测试" OnClick="Button2_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        列表规则
                    </td>
                    <td>
                        <asp:TextBox ID="txt_ListInfoRule" runat="server" Rows="5" TextMode="MultiLine" Width="400px"></asp:TextBox>
                        <br />
                        actors/class/director/image/intro/location/publicyear/tags/title
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="测试" OnClick="Button3_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        内容规则
                    </td>
                    <td>
                        <asp:TextBox ID="txt_InfoRule" runat="server" Rows="5" TextMode="MultiLine" Width="400px"></asp:TextBox>
                        <br />
                        actors/class/director/image/intro/location/publicyear/tags/title
                    </td>
                    <td>
                        <asp:Button ID="Button4" runat="server" Text="测试" OnClick="Button4_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        快播区域
                    </td>
                    <td>
                        <asp:TextBox ID="txt_KuaibAreaRule" runat="server" Rows="5" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        key
                    </td>
                    <td>
                        <asp:Button ID="Button5" runat="server" Text="测试" OnClick="Button5_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        百度区域
                    </td>
                    <td>
                        <asp:TextBox ID="txt_BaiduAreaRule" runat="server" Rows="5" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        key
                    </td>
                    <td>
                        <asp:Button ID="Button6" runat="server" Text="测试" OnClick="Button6_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        快播剧集
                    </td>
                    <td>
                        <asp:TextBox ID="txt_KuaibDramaRule" runat="server" Rows="5" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        title/url/playurl</td>
                    <td>
                        <asp:Button ID="Button7" runat="server" Text="测试" OnClick="Button7_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        百度剧集
                    </td>
                    <td>
                        <asp:TextBox ID="txt_BaiduDramaRule" runat="server" Rows="5" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        title/url/playurl</td>
                    <td>
                        <asp:Button ID="Button8" runat="server" Text="测试" OnClick="Button8_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        快播播放规则
                    </td>
                    <td>
                        <asp:TextBox ID="txt_DramaPageKuaibRule" runat="server" Rows="5" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        url/source
                    </td>
                    <td>
                        <asp:Button ID="Button9" runat="server" Text="测试" OnClick="Button9_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        百度播放规则
                    </td>
                    <td>
                        <asp:TextBox ID="txt_DramaPageBaiduRule" runat="server" Rows="5" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        url/source
                    </td>
                    <td>
                        <asp:Button ID="Button10" runat="server" Text="测试" OnClick="Button10_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        资源快播规则
                    </td>
                    <td>
                        <asp:TextBox ID="txt_SourceKuaibRule" runat="server" Rows="5" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        key
                    </td>
                    <td>
                        <asp:Button ID="Button11" runat="server" Text="测试" OnClick="Button11_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        资源百度规则
                    </td>
                    <td>
                        <asp:TextBox ID="txt_SourceBaiduRule" runat="server" Rows="5" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        key
                    </td>
                    <td>
                        <asp:Button ID="Button12" runat="server" Text="测试" OnClick="Button12_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="保存" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
