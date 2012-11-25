<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.e.admin.Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMS内容管理系统</title>
    <style type="text/css">
        *
        {
            font-size: 12px;
        }
        
       <%-- .blue-bg div, div.x-panel-body
        {
            background-color: #DFE8F6;
        }--%>
        #southPn
        {
            background-color: rgb(217,231,248);
            height: 30px;
            line-height: 30px;
            color: gray;
            position: relative;
        }
        #northPn
        {
            background-image: url(../images/cms_bg.png);
            height: 53px;
            position: relative;
            color: #FFF;
        }
        
        #loginInfoSp
        {
            position: absolute;
            right: 10px;
            top: 30px;
        }
    </style>
    <script type="text/javascript">
        function openpage(url, title) {
            TabPanel1.removeAll(true);
            var tab = TabPanel1.add({
                title: title,
                cls: "blue-bg",
                autoLoad: { url: url, scripts: true, mode: "iframe" }
            });
            TabPanel1.setActiveTab(tab);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:resourcemanager id="ResourceManager1" runat="server">
    </ext:resourcemanager>
    <ext:viewport id="Viewport1" runat="server" layout="border">
        <Items>
            <ext:Panel ID="Panel1" Cls="blue-bg" runat="server" Region="North" Height="50" Padding="0" Border="false" />
            <ext:Panel ID="west" runat="server" Title="导航" Region="West" Width="225" MinWidth="225"
                MaxWidth="400" Split="true" Collapsible="true">
            </ext:Panel>
            <ext:TabPanel ID="TabPanel1" runat="server" Region="Center">
                <Items>
                    <ext:Panel ID="Panel5" runat="server" Title="空白页面" Border="false" Padding="6" Cls="blue-bg" />
                </Items>
            </ext:TabPanel>
            <ext:Panel ID="Panel7" runat="server" Title="East" Region="East" Visible="false"
                Collapsible="true" Split="true" MinWidth="225" Width="225" Layout="Fit">
            </ext:Panel>
            <ext:Panel ID="Panel2" runat="server" Region="South" Height="30" Border="false" Layout="Fit" Cls="blue-bg" 
              Html="<div id='southPn' style='background-color:rgb(217,231,248);height:30px;line-height:30px;color:gray;position:relative'><span>WELCOME TO ADMINISTRATORS SYSTEM <a href='/' target='_blank;'>网站首页</a></span><span style='position:absolute;top:2px;right:10px'>&copy; 2011 <a href='mailto:kuibono@163.com'>Kuibono</a></span></div>"
             >
            </ext:Panel>
        </Items>
    </ext:viewport>
    </form>
</body>
</html>
