<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Web.e.admin.Job.Company.Edit" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司编辑</title>
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
                        <%--<asp:label runat="server" ID="lb_user" text=""></asp:label>--%>
                        <asp:dropdownlist ID="ddl_User" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        公司名称
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_CompanyName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        所属行业
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Industry" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        公司性质
                    </td>
                    <td>
                        <asp:dropdownlist ID="ddl_CompanyType" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        规模
                    </td>
                    <td>
                        <asp:dropdownlist ID="ddl_EmployeeCount" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        简介
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Intro" runat="server" Height="50px" TextMode="MultiLine" 
                            Width="300px" ></vd:VTextBox>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:button id="btn_Save" text="保存" runat="server" onclick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="location.href='List.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
