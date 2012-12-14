<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.wap.Book.Default" %>
<%@ Import Namespace="Voodoo.Basement" %>
<?xml version="1.0" encoding="utf-8" ?>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.0//EN" "http://www.wapforum.org/DTD/xhtml-mobile10.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--STATUS OK-->
<head>
    <meta http-equiv="Content-Type" content="application/xhtml+xml; charset=UTF-8" />
    <script type="text/javascript" src="/skin/script/jquery-1.7.min.js"></script>
    <title><%=SystemSetting.SiteName %></title>
    <style type="text/css">
        *{padding:0;margin:0;}body{line-height:130%;}img{border:0;}*{color:#a06534;}* a{color:#a06534;text-decoration:none;}.red{color:#f30;}.b{font-weight:bold;}.l,.left{text-align:left;}.left,.center,.right{padding:3px 8px;}.logo{padding:10px 8px;}.black{color:#000;}.categorys{padding-top:3px;padding-bottom:5px;}.search-form{background:url("http://m.baidu.com/static/wapxs/colorful-se-bg.gif") repeat-x scroll 0 0 #F5CE9C;padding:8px 5px;border-bottom:1px solid #eab770;}.search-box{position:relative;font-size:14px;}.search-input-wrap{padding-right:6em;}.search-button-wrap{position:absolute;top:0;right:0;width:5em;}.search-input{color:#999;width:100%;padding:2px;padding-bottom:4px;font-size:16px;border:1px solid #999;-webkit-border-radius:6px;-moz-border-radius:6px;}.search-button{color:#c25200;margin-left:5px;font-size:14px;width:100%;text-align:center;padding-left:2px;padding-right:2px;}.bBottom{border-bottom:1px solid #e4d1b7;}.banner{border:1px solid #eab770;}.title-wrap{background:url("http://m.baidu.com/static/wapxs/colorful-title-bg.gif") repeat-x scroll 0 0 #F5CE9C;border-bottom:1px solid #eab770;padding-top:3px;padding-bottom:3px;}.list-time{color:#999;}.list-item{color:#a06534;line-height:1.5em;line-height:1.5em;padding-bottom:3px;}.c,.center{text-align:center;}.banner{padding:1px;border:1px solid #eab770;}.turn-page-form{display:inline-block;padding:0;}.no-bTop{border-top:0;}.no-bBottom{border-bottom:0;}.nagiv-bottom{padding-top:8px;}.list-wrap{line-height:1.5em;}.bTop{border-top:1px solid #E4D1B7;}.zhuanti-img{padding:3px 0px 0px;text-align:center;line-height:100%;}
    </style>
</head>
<body>
    <div id="wrap">
        <div class="login">
            <a id="top"></a>
        </div>
        <div class="center logo">
            <img src="/skin/novel/logo.png" width="100" height="35" alt="<%=SystemSetting.SiteName %>" /></div>
        <div class="search-form-wrap">
            <!--include colorful/common/inc_form.xhtml-->
            <form class="search-form" action="/wap/book/s.aspx?" method="get">
            <div class="search-box">
                <div class="search-input-wrap">
                    <input type="text" class="search-input" name="key" id="word" /></div>
                <div class="search-button-wrap">
                    <input type="submit" class="search-button search-button-xs" name="su" value="搜小说" /></div>
            </div>
            </form>
        </div>
        <br />
        <div class="title-wrap left black">
            继续阅读</div>
        <div class="left bBottom">
            <%
                foreach (var c in ReadingChapters)
                {
                    var b = GetByID(c.BookID);
            %>
            <img src="http://m.baidu.com/static/wapxs/book.png" alt="" />
            <a href="/wap/book/b.aspx?id=<%=c.BookID %>"><%=c.BookTitle %></a>&nbsp;| <a href="/wap/book/c.aspx?id=<%=c.ID %>"><%=c.Title %></a>| <a href="/wap/book/c.aspx?id=<%=b.LastChapterID %>"><%=b.LastChapterTitle %></a>
            <br />
            <%} %>
        </div>
        <div class="title-wrap left black">
            小说分类</div>
        <div class="left categorys list-wrap">
            <!--分类-->
            <%= Voodoo.Basement.Functions.Getclassbyfilter("t.IsLeafClass=false", "<a href='/wap/book/cls.aspx?id={id}'>{classname}</a> ")%>
        </div>
        <div class="title-wrap left">
            火热标签</div>
        <div class="list-wrap left">
            <%= Voodoo.Basement.Functions.Getsearchkey("t.ModelID=4", 10, "<a href=\"/wap/book/s.aspx?key={keyword}\">{keyword}</a> ")%>
        </div>

        <div class="center go-top">
            <a href="#top">
                <img src="http://m.baidu.com/static/wapxs/wapxs-gotop.gif" width="46" height="16"
                    alt="返回顶部" /></a></div>
        <div class="search-form-wrap">
            <!--include colorful/common/inc_form.xhtml-->
            <form class="search-form" action="/wap/book/s.aspx" method="get">
            <div class="search-box">
                <div class="search-input-wrap">
                    <input type="text" class="search-input" name="key" id="Text1" /></div>
                <div class="search-button-wrap">
                    <input type="submit" class="search-button search-button-xs" name="su" value="搜小说" /></div>
            </div>
            </form>
        </div>
        <div class="center nagiv-bottom">
            <div class="center list-time">
                <%= DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss") %>
            </div>
        </div>
    </div>
</body>

</html>
