<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="Web.e.admin.system.SystemParameter.user" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员参数</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />

    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../../data/script/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        本页配置会员登录注册等功能</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    会员参数
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="100">
                    启用注册
                </td>
                <td>
                    <vd:VCheckBox ID="chk_EnableReg" runat="server" Text="启用" />
                </td>
            </tr>
            <tr>
                <td>
                    会员注册默认组
                </td>
                <td>
                    <asp:DropDownList ID="ddl_RegisterDefaultGroup" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    注册赠送点数
                </td>
                <td>
                    <vd:VTextBox ID="txt_RegCent" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    注册用户名长度限制
                </td>
                <td>
                    <vd:VTextBox ID="txt_MinUserName" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>
                    ~
                    <vd:VTextBox ID="txt_MaxUserName" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    密码长度限制
                </td>
                <td>
                    <vd:VTextBox ID="txt_MinPassword" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>
                    ~
                    <vd:VTextBox ID="txt_MaxPassword" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    邮箱唯一性检查
                </td>
                <td>
                    <vd:VCheckBox ID="chk_EmailCheck" runat="server" Text="检查" />
                </td>
            </tr>
            <tr>
                <td>
                    注册时间间隔
                </td>
                <td>
                    <vd:VTextBox ID="txt_RegTimeSpan" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>分钟
                </td>
            </tr>
            <tr>
                <td>
                    用户名保留关键字
                </td>
                <td>
                    <vd:VTextBox ID="txt_UserNameFilter" runat="server" TextMode="MultiLine"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>
                    后台登陆开启验证码
                </td>
                <td>
                    <vd:VCheckBox ID="chk_BackLoginUseVCode" runat="server" Text="开启" />
                </td>
            </tr>
            <tr>
                <td>
                    后台登陆错误次数限制
                </td>
                <td>
                    <vd:VTextBox ID="txt_BackLoginErrorSize" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    重新登录时间间隔
                </td>
                <td>
                    <vd:VTextBox ID="txt_BackLoginErrorTimeSpan" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>分钟
                </td>
            </tr>
            <tr>
                <td>
                    登陆超时时间
                </td>
                <td>
                    <vd:VTextBox ID="txt_BackCookieTimeOut" runat="server" EnableValidate="true" EnableNull="false" VType="integer"></vd:VTextBox>分钟
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
