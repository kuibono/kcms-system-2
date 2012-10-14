<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Web.e.admin.Job.Person.Edit" %>
<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人才编辑</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
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
                    邮箱
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Email" runat="server" EnableValidate="true" VType="email" EnableNull="true"></vd:VTextBox>
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
                        <input type="button" value="取消" onclick="location.href='List.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </form>
</body>
</html>
