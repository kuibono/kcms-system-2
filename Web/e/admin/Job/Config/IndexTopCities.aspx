<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexTopCities.aspx.cs" Inherits="Web.e.admin.Job.Config.IndexTopCities" %>

<%@ Import Namespace="Voodoo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>首页省市管理</title>
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
            本页进行首页右侧显示的省市进行管理</div>
    </div>
    <div>
        <asp:treeview id="TreeView1" runat="server" showcheckboxes="Leaf" 
            ExpandDepth="0">
            </asp:treeview>

        <asp:Button ID="btn_Save" runat="server" onclick="btn_Save_Click" Text="保存" />

    </div>
    </div>
    </form>
</body>
</html>
