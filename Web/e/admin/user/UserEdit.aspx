<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Web.e.admin.user.UserEdit" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>会员编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">确保用户信息正确</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        会员编辑
                    </th>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                    帐号
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_UserName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    密码
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Password" TextMode="Password" runat="server" EnableValidate="true" EnableNull="true"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    姓名
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ChineseName" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    邮箱
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Email" runat="server" EnableValidate="true" VType="email" EnableNull="true"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    电话
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_TelNumber" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    手机
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Mobile" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    个人网站
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Website" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    头像
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Image" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    地址
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Address" runat="server" TextMode="MultiLine"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    邮编
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Zipcode" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    个人简介
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Intro" runat="server" TextMode="MultiLine"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    所在群组
                    </td>
                    <td>
                        <vd:VDropDownList ID="ddl_Group" runat="server">
                        </vd:VDropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    积分
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Cent" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    投稿数量
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_PostCount" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    QQ
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_QQ" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    Gtalk
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Gtalk" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    Twitter
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Twitter" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    ICQ
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ICQ" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    新浪微博
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Weibo" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    上次登录时间
                    </td>
                    <td>
                        <asp:Label ID="lb_LastLoginTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    上次登录IP
                    </td>
                    <td>
                        <asp:Label ID="lb_LastLoginIP" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    登录次数
                    </td>
                    <td>
                        <asp:Label ID="lb_LoginCount" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    学号
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_StudentNo" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    工号
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_TeachNo" runat="server" ></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    已经启用
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_Enable" Text="启用" runat="server" />
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="btn_Save" Text="保存" runat="server" onclick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="location.href='UserList.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>
