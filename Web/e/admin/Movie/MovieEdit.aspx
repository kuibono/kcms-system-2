<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieEdit.aspx.cs" Inherits="Web.e.admin.Movie.MovieEdit" ValidateRequest="false" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>信息编辑</title>
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
        本页进行信息的增加/修改</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    信息编辑
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    栏目
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Class" runat="server">
                    </asp:DropDownList>
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
                    导演
                </td>
                <td>
                    <vd:vtextbox id="txt_Director" runat="server" enablevalidate="true" enablenull="false" Width="250px"></vd:vtextbox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    演员
                </td>
                <td>
                    <vd:vtextbox id="txt_Actors" runat="server" enablevalidate="true" enablenull="false" Width="250px"></vd:vtextbox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    Tags
                </td>
                <td>
                    <vd:vtextbox id="txt_Tags" runat="server" enablevalidate="true" enablenull="false" Width="250px"></vd:vtextbox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    地区
                </td>
                <td>
                    <vd:vtextbox id="txt_Location" runat="server" enablevalidate="true" enablenull="false" Width="250px"></vd:vtextbox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    年
                </td>
                <td>
                    <vd:vtextbox id="txt_PublicYear" runat="server" enablevalidate="true" enablenull="false"></vd:vtextbox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    简介
                </td>
                <td>
                    <vd:vtextbox id="txt_Intro" runat="server" enablevalidate="true" enablenull="false" TextMode="Multiline" Width="500px" Height="200px"></vd:vtextbox>
                </td>
            </tr>
            <tr>
                <td width="163">
                    详情
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="FCKeditor1" runat="server" Height="200" BasePath="~/e/data/ckeditor" Width="99%">
		                </CKEditor:CKEditorControl>
                   <%-- <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="300px">
                    </FCKeditorV2:FCKeditor>--%>
                </td>
            </tr>
            <tr>
                <td width="163">
                    电影？
                </td>
                <td>
                    <asp:CheckBox ID="chk_IsMovie" runat="server" Text="是电影" />
                </td>
            </tr>
            <tr>
                <td width="163">
                    封面
                </td>
                <td>
                     <asp:FileUpload ID="file_Moviefacefile" runat="server" />
                        <br />
                        <asp:Image ID="img_Movieface" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="163">
                    状态
                </td>
                <td>
                    <asp:RadioButtonList ID="rbl_Status" runat="server">
                        <asp:ListItem Text="连载中" Value="0"></asp:ListItem>
                        <asp:ListItem Text="已完结" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
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
