<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkEdit.aspx.cs" Inherits="Web.e.admin.system.friendlink.LinkEdit" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>友情链接编辑</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />

    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        请勿链接网页价值低的网站，这样会影响本站的价值</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    友情链接编辑
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="163">
                    链接文本
                </td>
                <td>
                    <vd:VTextBox ID="txt_LinkTitle" runat="server" EnableValidate="true" EnableNull="false" Width="200px"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    链接地址
                </td>
                <td>
                    <vd:VTextBox ID="txt_Url" runat="server" EnableValidate="false" EnableNull="false" VType="url" Width="200px"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    序号
                </td>
                <td>
                    <vd:VTextBox ID="txt_Index" runat="server" EnableValidate="true" EnableNull="false" VType="integer" Text="0"></vd:VTextBox>
                </td>
            </tr>


        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="location.href='LinkList.aspx'" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
