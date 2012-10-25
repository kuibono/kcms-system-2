<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Web.e.admin.Ad.Ad.Edit" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告编辑</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="tip">
            本页进行对广告进行编辑修改和新增</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        广告编辑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                        广告位
                    </td>
                    <td>
                        
                        <asp:DropDownList ID="ddl_Group" runat="server">
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        名称
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Title" runat="server" enablevalidate="true" enablenull="false"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        Url
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Url" runat="server" enablevalidate="true" enablenull="false"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        图片
                    </td>
                    <td>
                        
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/u/ResumeFace/0.jpg" />
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        宽度
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Width" runat="server" Text="0" enablevalidate="true" enablenull="false"  VType="integer"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        高度
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Height" runat="server" Text="0" enablevalidate="true" enablenull="false"  VType="integer"></vd:vtextbox>
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
