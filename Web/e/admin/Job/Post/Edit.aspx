<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Web.e.admin.Job.Post.Edit" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>职位编辑</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
            本页进行对职位信息进行编辑修改和新增</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        职位信息编辑
                    </th>
                </tr>
            </thead>
            <tbody>
            <tr>
                    <td width="163">
                        用户
                    </td>
                    <td>
                        <asp:dropdownlist ID="ddl_User" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddl_User_SelectedIndexChanged"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        公司
                    </td>
                    <td>
                        <asp:dropdownlist ID="ddl_Company" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        标题
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Title" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        地区
                    </td>
                    <td>
                        <asp:dropdownlist ID="ddl_Province" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddl_Province_SelectedIndexChanged"></asp:dropdownlist>-
                        <asp:dropdownlist ID="ddl_City" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        工资范围
                    </td>
                    <td>
                        <asp:dropdownlist ID="ddl_Salary" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        经验要求
                    </td>
                    <td>
                        <asp:dropdownlist ID="ddl_Expressions" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        学历要求
                    </td>
                    <td>
                        <asp:dropdownlist ID="ddl_Edu" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        招聘人数
                    </td>
                    <td>
                       <vd:VTextBox ID="txt_EmployNumber" runat="server" EnableValidate="true" 
                            EnableNull="false" VType="integer"></vd:VTextBox>

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
                <tr>
                    <td>
                        显示在首页
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_Settop" runat="server" Text="显示" />
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
