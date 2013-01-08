<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.wap.b._default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>手机阅读-<%=Voodoo.Basement.BasePage.SystemSetting.SiteName %></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="no" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="white" />
    <link type="text/css" rel="Stylesheet" href="style/s.css" />
    <script type="text/javascript" src="script/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="script/s.js"></script>
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
        <div class="b-block hot-search">
            <strong>热门搜索：</strong> <%=Voodoo.Basement.Functions.getsearchkey("9","4") %>
        </div>
        <div class="tPanel b-block">
            <div class="tHeader">
                <div class="tTitle cur">
                    阅读历史
                </div>
                <div class="tTitle">
                    本站声明
                </div>
            </div>
            <div class="tBody">
                <div>
                    <ul id="history">
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>
                        <li>项目1 (<span class="red">5章未读</span>)</li>

                    </ul>
                </div>
                <div style="display: none;">
                    本店所有箱包，一律十元，全部十元
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="block">
            <header>
                <div class="short-btn">
                    <span class="short-btn-icon"></span>
                </div>
                <div class="title">本周强推</div>
            </header>
            <div class="body">
                <ul>
                    <%=Voodoo.Basement.Functions.booklist("18","0","t.id>0","t.TjCount desc","<li><a title=\"{title}\" href=\"b.aspx?id={id}\">{ftitle}</a></li>") %>
                </ul>
                
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="block">
            <header>
                <div class="short-btn">
                    <span class="short-btn-icon"></span>
                </div>
                <div class="title">点击排行</div>
            </header>
            <div class="body">
                <ul>
                     <%=Voodoo.Basement.Functions.booklist("18","0","t.id>0","t.clickcount  desc","<li><a title=\"{title}\" href=\"b.aspx?id={id}\">{ftitle}</a></li>") %>
                </ul>
                
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="block">
            <header>
                <div class="short-btn">
                    <span class="short-btn-icon"></span>
                </div>
                <div class="title">最新上架</div>
            </header>
            <div class="body">
                <ul>
                     <%=Voodoo.Basement.Functions.booklist("18","0","t.id>0","t.addtime  desc","<li><a title=\"{title}\" href=\"b.aspx?id={id}\">{ftitle}</a></li>") %>
                </ul>
                
            </div>
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
                    <span class="btn-gotop  go-top-btn" id="goToTop">顶部</span> 
                    <span class="s-hover">电脑版</span>
                    <span class="s-hover">首页</span>
                    <span class="s-hover">2013年1月7日10:08:24</span>
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

</html>
