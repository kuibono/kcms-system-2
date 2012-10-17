<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Web.e.admin.Job.Application.Edit" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请查看</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
            本页进行对公司信息进行编辑修改和新增</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        公司信息编辑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                        用户
                    </td>
                    <td>
                        
                        <asp:Label ID="lb_User" runat="server" Text=""></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        公司名称
                    </td>
                    <td>
                       <asp:Label ID="lb_Company" runat="server" Text=""></asp:Label>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        职位
                    </td>
                    <td>
                        <asp:Label ID="lb_Post" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        简历
                    </td>
                    <td>
                        <asp:Label ID="lb_Resume" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        时间
                    </td>
                    <td>
                        <asp:Label ID="lb_Time" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                       消息
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Intro" runat="server" height="50px" textmode="MultiLine" width="300px"></vd:vtextbox>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        
                        <input type="button" value="返回" onclick="location.href='List.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
