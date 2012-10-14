<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobEduSpecialtyManagement.aspx.cs"
    Inherits="Web.e.admin.Job.Config.JobEduSpecialtyManagement" %>

<%@ Register assembly="Voodoo" namespace="Voodoo.UI" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>专业管理</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        #Spe_Tree table
        {
            width:auto;
        }
        #Spe_Tree td
        {
            text-align:left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    专业管理
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td style="width:300px">
                    <asp:treeview id="Spe_Tree" runat="server" 
                        onselectednodechanged="Spe_Tree_SelectedNodeChanged"><SelectedNodeStyle CssClass="treeselected" /></asp:treeview>
                </td>
                <td valign="top">

                    <table class="style1" border="1" cellpadding="0" cellspacing="0" class="edit">
                        <tr>
                            <td width="160">
                                <asp:Button ID="Btn_Edit" runat="server" Text="编辑" onclick="Btn_Edit_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="Btn_Add" runat="server" Text="增加子项" onclick="Btn_Add_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chk_Edit" runat="server" Visible="False" />
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                名称:</td>
                            <td align="left">
                                <cc1:VTextBox ID="txt_Name" runat="server" EnableValidate="False"></cc1:VTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Btn_Save" runat="server" Text="保存" Enabled="False" 
                                    onclick="Btn_Save_Click" />
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
