<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileManagement.aspx.cs"  Inherits="Web.e.admin.system.Basement.FileManagement" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文件管理器</title>
    <style type="text/css">
        .style1
        {
            height: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" style="border: solid 1px gray; border-collapse: collapse; width:100%">
            <tr>
                <td rowspan="3" style="width:400px">
                    <asp:treeview id="TreeView1" runat="server" imageset="XPFileExplorer" 
                        nodeindent="15" ExpandDepth="2" ShowLines="true" 
                        onselectednodechanged="TreeView1_SelectedNodeChanged" 
                        ontreenodeexpanded="TreeView1_TreeNodeExpanded" >
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                        HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                        HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:treeview>
                </td>
                <td class="style1" height="14">
                    <asp:Label ID="lb_Path" runat="server" Text=""></asp:Label><asp:Button ID="btn_Save" runat="server" onclick="btn_Save_Click" Text="保存" />
                </td>
            </tr>
            <tr>
                <td class="style1" height="14">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btn_Upload" runat="server" onclick="btn_Upload_Click" 
                        Text="上传" />
                </td>
            </tr>
            <tr>
                <td>

                    <asp:TextBox ID="txt_Content" runat="server" TextMode="MultiLine" Height="100%" Width="100%"></asp:TextBox>

                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
