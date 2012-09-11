<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiAdd.aspx.cs" Inherits="Web.e.admin.Movie.MultiAdd"  ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>批量添加</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        资源批量添加</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    资源批量添加
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    影视
                </td>
                <td>
                    <asp:label id="txt_BookTitle" runat="server"></asp:label>
                </td>
            </tr>
            <tr>
                <td width="163">
                    资源s
                </td>
                <td>
                    <vd:vtextbox id="txt_source" runat="server" height="219px" textmode="MultiLine" width="506px"></vd:vtextbox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:gridview runat="server" ID="GridView1"></asp:gridview>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:button id="btn_Bind" text="查看" runat="server" onclick="btn_Bind_Click" />
                    &nbsp;
                    <asp:button id="btn_Save" text="保存" runat="server" onclick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="history.go(-1)" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
