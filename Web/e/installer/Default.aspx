<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.e.intaller.Default" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统安装</title>
    <link rel="stylesheet" type="text/css" href="../data/css/management.css" />

    <script type="text/javascript" src="../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../data/script/common.js"></script>
    <style type="text/css">
    body
    {
        padding:20px;
    }
    table
    {
        margin-top:20px;
    }
    #step_1,#step_2
    {
        display:none;
    }
    
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div id="step_0">
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="3">
                        系统环境(请自行检查环境是否符合最低要求，否则会安装失败)
                    </th>
                </tr>
            </thead>
            <tbody style="text-align:center;">
                <tr style="font-weight:bold">
                    <td>
                        项目
                    </td>
                    <td>
                        最低要求
                    </td>
                    <td>
                        当前系统
                    </td>
                </tr>
                <tr>
                    <td>
                        IIS
                    </td>
                    <td>
                       Microsoft-IIS/6.0
                    </td>
                    <td>
                        <%=Voodoo.Security.Server.GetServerSoftware() %>
                    </td>
                </tr>
                <tr>
                    <td >
                        .NET版本
                    </td>
                    <td>
                       2.0
                    </td>
                    <td>
                        <%=Voodoo.Security.Server.GetDotNetVersion()%>
                    </td>
                </tr>

                <tr>
                    <td colspan="3" align="right">
                        <asp:Button ID="Button2" runat="server" Text="下一步" OnClientClick="$('#step_1').show();$('#step_0').hide();" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div id="step_1">
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        数据库配置
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="100">
                        数据库服务器
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Server" runat="server" EnableValidate="True"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        数据库帐号
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Username" runat="server" EnableValidate="True"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        数据库密码
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Password" runat="server" EnableValidate="True" TextMode="Password"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        数据库名
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_DbName" runat="server" EnableValidate="True"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        内置初始数据
                    </td>
                    <td>
                        <vd:VCheckBox ID="chk_WithData" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btn_Next" runat="server" Text="下一步" OnClientClick="$('#step_2').show();$('#step_1').hide();"  />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div id="step_2">
    
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        管理员配置
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="100">
                        初始帐号
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_AdminName" runat="server" EnableValidate="True"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="100">
                        初始密码
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_AdminPass" runat="server" EnableValidate="True" TextMode="Password"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="100">
                        重复密码
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_AdminPassR" runat="server" EnableValidate="True" TextMode="Password"></vd:VTextBox>
                    </td>
                </tr>


                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="Button1" runat="server" Text="完成" onclick="Button1_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
