<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cls.aspx.cs" Inherits="Web.wap.Book.cls" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="cc1" %>

<?xml version="1.0" encoding="utf-8" ?>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.0//EN" "http://www.wapforum.org/DTD/xhtml-mobile10.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--STATUS OK-->
<head>
    <meta http-equiv="Content-Type" content="application/xhtml+xml; charset=utf-8" />
    <script type="text/javascript" src="/skin/script/jquery-1.7.min.js"></script>
    <title><%#Eval("className") %>-<%=SystemSetting.SiteName %> </title>
    <style type="text/css">.ec_keyword,.ec_keyword a{color:#c60a00}.ec_site{color:#008000;padding:0;margin:0}.ec_site,.ec_abs{font-size:small}.ec_abs{margin-top:2px}.ec_gray{color:#666666}.ec_adv3{padding-right:6px;padding-left:6px}.ec_resitem{margin:5px 0}.ec_adv,.ec_adv2,.ec_adv3{margin:5px 0}.ec_brand_ads{padding:4px 0px 0px 0px}.ec_brand_ads .ec_logo{line-height:0px}.ec_brand_ads .ec_logo img{border:0px solid #ccc}.ec_brand_ads .ec_title{padding:2px 0px 0px 0px}.ec_brand_ads .ec_more_info{font-size:small}.ec_brand_ads .ec_content{padding:3px 0px 0px 0px;font-size:small}.ec_brand_ads .ec_more_links{padding:0px 0px 8px 0px;line-height:1.5em;border-bottom:1px solid #e1e1e1;font-size:small}.ec_brand_ads .ec_more_links img{padding:0px 4px 0px 0px}.ec_brand_ads .ec_more_links .ec_sep{color:#666;padding:0px 4px}body{padding:0;margin:0;line-height:120%}form{margin:0}img{border:0}small{font-size:small}* a{color:#06534;text-decoration:none}em{font-style:normal;color:#FF3300}.keyword,.keyword a{color:#c60a00}.bc{border-top:1px solid #E4D1B7;padding-top:8px;margin-top:8px;margin-bottom:8px}.bc-top{padding-left:6px;padding-right:6px;margin-bottom:8px;margin-top:8px}.hr{border-top:1px solid #6699CC;margin:5px 0}.b{margin:5px 0}.d{margin-bottom:6px}.i{margin-bottom:4px}.site,.date,.size,.g{color:#008000;padding:0;margin:0}.site,.date,.size,.abs{font-size:small}.gray{color:#666666}.green{color:#008000}.wrap{}.reswrap,.relate,.adv3,.pagenav,.timestamp,.bc,.retlink,.ew,.url,.ca{padding-right:6px;padding-left:6px}.ew{padding-top:3px;padding-bottom:3px}.relate{padding-bottom:5px;padding-top:5px;background-color:#EFF2FA;line-height:150%}.reswrap{}.resitem{margin:5px 0}.adv,.adv2,.adv3{margin:5px 0}.f{padding:5px}.tf{border-bottom:1px solid #D7EBFF}.bf{}.pagenav{padding-top:5px;padding-bottom:5px}.pagenav{margin:5px 0}.retlink{margin-top:1em}.timestamp{margin-bottom:2em;color:#999999}.search-form{background:url("http://wap.baidu.com/static/wapxs/colorful-se-bg.gif") repeat-x scroll 0 0 #F5CE9C;padding:8px 5px;border-bottom:1px solid #eab770}.search-box{position:relative;font-size:14px}.search-input-wrap{padding-right:6em}.search-input{color:#999999;width:100%;padding:2px;padding-bottom:4px;font-size:16px;border:1px solid #999;-webkit-border-radius:6px;-moz-border-radius:6px}.search-button-wrap{position:absolute;top:0;right:0;width:5em}.search-button{color:#c25200;margin-left:5px;font-size:14px;width:100%;text-align:center;padding-left:2px;padding-right:2px}.title-wrap{background:url("http://wap.baidu.com/static/wapxs/colorful-title-bg.gif") repeat-x scroll 0 0 #F5CE9C;border-bottom:1px solid #EAB770;padding:3px 6px}</style>
</head>
<body>
    <div class="wrap">
        <div class="search-form-wrap">
            <form class="search-form" action="/wap/book/s.aspx" method="get">
            <div class="search-box">
                <div class="search-input-wrap">
                    <input type="text" class="search-input" name="key" maxlength="64" value="" /></div>
                <div class="search-button-wrap">
                    <input type="submit" class="search-button" name="su" value="搜小说" /></div>
            </div>
            </form>
        </div>
        <div class="reswrap">
            <asp:Repeater ID="rp" runat="server">
                <ItemTemplate>
            <div class="resitem">
                <a href="/wap/book/b.aspx?id=<%#Eval("id") %>"><%#Eval("Title") %></a>(<%#Eval("Author") %>)-
                <a href="/wap/book/cls.aspx?id=<%#Eval("classid") %>"><%#Eval("className") %></a>
                <div class="abs">
                            <%#Eval("Intro").ToString().CutString(30) %>
                            <br />
                            <a href="/wap/book/c.aspx?id=<%#Eval("lastChapterID") %>"><%#Eval("lastChapterTitle") %></a>
                            <span class="date"><%# Eval("updatetime").ToDateTime().ToString("MM-dd HH:mm") %></span></div>
            </div>
                </ItemTemplate>
            </asp:Repeater>

            
            
        </div>
        <div class="pagenav">
            <cc1:AspNetPager ID="AspNetPager1" runat="server" PageSize="10" UrlPaging="true"></cc1:AspNetPager>
        </div>
        <div class="search-form-wrap">
            <form class="search-form" action="/wap/book/s.aspx" method="get">
            <div class="search-box">
                <div class="search-input-wrap">
                    <input type="text" class="search-input" name="key" maxlength="64" value="" /></div>
                <div class="search-button-wrap">
                    <input type="submit" class="search-button" name="su" value="搜小说" /></div>
            </div>
            </form>
        </div>

        <div class="center nagiv-bottom">
            <a href="/" title="<%=SystemSetting.SiteName %>">电脑站</a>
            <div class="center list-time">
                <%= DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss") %> 
            </div>
        </div>
    </div>
    <%=SystemSetting.CountCode %>
</body>
</html>
