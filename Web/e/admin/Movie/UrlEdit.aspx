<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrlEdit.aspx.cs" Inherits="Web.e.admin.Movie.UrlEdit" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>地址编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
    <script type="text/javascript">
        $(function () {

        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        本页进行地址的增加/修改</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    地址编辑
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    书籍
                </td>
                <td>
                    <asp:label ID="txt_BookTitle" runat="server"></asp:label>
                </td>
            </tr>
            <tr>
                <td width="163">
                    标题
                </td>
                <td>
                    <vd:vtextbox id="txt_Title" runat="server" enablevalidate="true" enablenull="false" Width="250px"></vd:vtextbox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    地址
                </td>
                <td>
                    <vd:vtextbox id="txt_Url" runat="server" enablevalidate="true" enablenull="false" Width="250px"></vd:vtextbox>
                </td>
            </tr>
 
            <tr>
                <td width="163">
                    审核
                </td>
                <td>
                    <asp:CheckBox ID="chk_Enable" runat="server" Text="已经审核" />
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="history.go(-1)" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
