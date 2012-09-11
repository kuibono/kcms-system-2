<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addselect.aspx.cs" Inherits="Web.e.file.addselect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图片管理</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <script type="text/javascript" src="/script/jquery-1.7.min.js"></script>
    <script type="text/javascript">
        var parentCtrl = "<%=Request.QueryString["ctrl"] %>";
        $(function () { 
            $("#DataList1 img").live("click",function(){
                $(parent.opener.document).find("#"+parentCtrl).val($(this).attr("path"));
                window.close();
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <table class="style1" border="1" cellpadding="0" cellspacing="0" style="border-collapse:collapse">
        <tr>
            <td colspan="2">
                上传</td>
        </tr>
        <tr>
            <td width="100">
                上传文件</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                别名</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_UpLoad" runat="server" Text="上传" 
                    onclick="btn_UpLoad_Click" />
            </td>
        </tr>
    </table>
    
    <asp:DataList ID="DataList1" runat="server" BorderStyle="Solid" 
        BorderWidth="1px" RepeatColumns="4" RepeatDirection="Horizontal">
        <ItemTemplate>
             <a href="javascript:void(0)">
             <img src="<%#Eval("SmallPath") %>" path="<%#Eval("FilePath") %>" width="105" height="118" style="border:solid 1px gray; margin:2px;" />
             </a>
        </ItemTemplate>
        
    </asp:DataList>
    
    </form>
</body>
</html>
