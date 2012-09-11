<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoEdit.aspx.cs" Inherits="Web.e.admin.Info.InfoEdit" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分类信息编辑</title>
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
    <script type="text/javascript">
    var json=<%=ValueString %>;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <vd:VTextBox ID="txt_nothing" runat="server" EnableValidate="true" VType="integer" style="display:none;"></vd:VTextBox>
       
       
        <%=TypeHtml %>
    </div>
    </form>
</body>
</html>
