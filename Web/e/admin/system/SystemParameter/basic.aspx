<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="basic.aspx.cs" Inherits="Web.e.admin.system.SystemParameter.basic" ValidateRequest="false" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>基本参数</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tip">本页进行系统的基本配置，首次安装本系统请务必修改这个配置</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        基本参数
                    </th>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="100">
                    网站名称
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_SiteName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    网站地址
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_SiteUrl" runat="server" EnableValidate="true" EnableNull="false" VType="url"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    开放网站
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_SiteOpen" runat="server" Text="开放" />
                    </td>
                </tr>
                <tr>
                    <td>
                    关闭时的提示
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_SiteCloseMsg" runat="server" TextMode="MultiLine"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    关键词
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_KeyWords" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    简介(用于SEO)
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Description" runat="server" TextMode="MultiLine"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    版权信息
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Copyright" runat="server" TextMode="MultiLine"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    三方统计
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_CountCode" runat="server" TextMode="MultiLine"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    附件前缀
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_FileDirString" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    首页扩展名
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ExtName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    启用PING
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_EnalePing" Text="启用" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    PING接口
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_PingAddress" runat="server" TextMode="MultiLine"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                     分类文件目录
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ClassFolder" runat="server" Text="/Book"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        邮件地址
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_COntactEmail" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        QQ
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_QQ" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        MSN
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Msn" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        微博
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Weibo" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        人人主页
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Renren" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        列表每页条数
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_MagageListSize" runat="server"></vd:VTextBox>
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
