<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="b.aspx.cs" Inherits="Web.wap.b.b" %>

<%@ Register assembly="Voodoo" namespace="Voodoo.UI" tagprefix="vd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=book.Title %>-<%=Voodoo.Basement.BasePage.SystemSetting.SiteName %></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="no" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <link type="text/css" rel="Stylesheet" href="style/s.css" />
    <script type="text/javascript" src="script/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="script/s.js"></script>
    <style type="text/css">
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="page" class="page page-current">
        <div class="header">
            <div class="back-btn">
                <span class="header-icon"></span>
            </div>
            小说阅读
            <div class="nav-btn">
                <span class="header-icon" id="showSlider"></span>
            </div>
        </div>
        <div class="nav">
            <ul>
                <li><span class="mypos-text"><%=ParentCls.ClassName %></span></li>
                <li><span class="mypos-text"><%=Cls.ClassName %></span></li>
                <li><span class="mypos-text"><%=book.Title %></span></li>
            </ul>
        </div>
        <div class="b-block hot-search">
            <strong>热门搜索：</strong><%=Voodoo.Basement.Functions.getsearchkey("9","4") %>
        </div>
        <div class="tPanel b-block">
            <div class="tHeader">
                <div class="tTitle cur">
                    简介
                </div>
            </div>
            <div class="tBody">
                <div>
                    <p>
                        <img style="float: left; margin-right: 10px;" src="<%=book.FaceImage %>" />
                        <%=book.Intro %>
                    </p>
                </div>
            </div>
        </div>
        <div class="block cList">
            <header>
                <div class="title">目录</div>
            </header>
            <div class="order">
                <div id="asc">
                    <a href="?id=<%=book.ID %>&asc=true">顺序排列</a>
                </div>
                <div>
                    |</div>
                <div id="desc">
                     <a href="?id=<%=book.ID %>&asc=false"> 倒序排列</a></div>
            </div>
            <div class="clear">
            </div>
            <div class="body up">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="item"><span class="w-link-text"><a href="c.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %></a></span></div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <footer>
                 <vd:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" NumericButtonCount="5" PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                 </vd:AspNetPager>
            </footer>
        </div>
        <div class="clear">
        </div>
        <div class="footer">
            <div class="search-form">
                <div class="form-right">
                    <input class="form-submit" type="submit" />
                    小说搜索</div>
                <div class="form-left">
                    <div class="form-text-wrapper">
                        <input class="form-text" type="text" name="word" maxlength="64" />
                    </div>
                </div>
            </div>
            <div class="footer-end">
                <div>
                    <span class="btn-gotop  go-top-btn" id="goToTop">顶部</span> <span class="s-hover">电脑版</span>
                    <span class="s-hover">首页</span>
                </div>
                <div class="copyright">
                    © 2013 aizr.net</div>
            </div>
        </div>
    </div>
    <div id="sidebar" style="overflow: hidden;">
        <ul style="-webkit-transition: -webkit-transform 0ms; -webkit-transform-origin: 0px 0px;
            -webkit-transform: translate3d(0px, 0px, 0px);">
            <li data-path="default.aspx">首页</li>
            <%=Voodoo.Basement.Functions.getclasslist("50","0","t.ParentID=0","<li data-path=\"c.aspx?id={id}\">{classname}</li>")%>
            <li data-path="Search.aspx">全部书籍</li>
        </ul>
    </div>
    </form>
</body>
</html>
