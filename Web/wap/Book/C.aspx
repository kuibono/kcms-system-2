<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="C.aspx.cs" Inherits="Web.wap.Book.C" %>
<?xml version="1.0" encoding="utf-8" ?>
<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.0//EN" "http://www.wapforum.org/DTD/xhtml-mobile10.dtd">
<!--STATUS OK-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="application/xhtml+xml; charset=utf-8" />
    <style type="text/css">form,h1,h2,h3,h4,h5,h6,h7,ul,li,ol{margin:0;padding:0}ul,li,ol{list-style:none}.tc_open{background-color:#F4F4F4;border-bottom:1px solid #7BACEF;margin:5px 0}.qwt{color:#C60A00;background-color:#99ff99;font-weight:bold}.keyword{color:#C60A00}img{border:none}.tc_column_title a{text-decoration:none}.bk{color:#333;text-decoration:none;display:block}a{color:#000000}body{font-size:medium;line-height:1.5em}h1,h2,h3,h4,h5,h6{font-size:16px}p{margin:0;padding:0}a{display:inline-block}.z{color:#333;margin:6px 0px 6px -5px;padding-left:5px;background-color:#E4EDF8}.footer{border-top:1px solid#94C4EF;background-color:#E4EDF8}.footer a{color:#00e}.gray{color:#777}.c1{background-color:#e7f4fe;padding:2px}.red{color:red}#top_navi{background:#E4EDF8;border-bottom:1px solid#94C4EF;width:100%}#top_navi a{color:#00E}.trans{margin:0 0 0 -5px;padding:0 5px;line-height:18px;font-weight:normal;font-size:12px;color:#555;background-color:#efefef}.trans a{color:#6666FF;text-decoration:underline}.chapterstyle a{color:blue}.chapterstyle{border-top:1px solid #94C4EF;margin-top:5px;padding-top:15px}.chapterstyle .sitestyle{color:green;display:inline}</style>
    <script type="text/javascript" src="/skin/script/jquery-1.7.min.js"></script>
    <title><%=c.Title+"-"+b.Title+"-"+b.Author %>-<%=SystemSetting.SiteName %></title>
</head>
<body>
    <div>
        <a href="/wap/book/">
            <img src="/skin/novel/logo.png"  alt="<%=SystemSetting.SiteName %>" /></a><br />
        <div class="c1">
            <div class="c2">
                <a href="/wap/Book/" style=""><%=SystemSetting.SiteName %></a>-&gt;
                <a href="/wap/Book/cls.aspx?<%=cls.ID %>" style=""><%=cls.ClassName %></a>-&gt;
                <a href="b.aspx?id=<%=b.ID %>" style=""><%=b.Title %></a>-&gt;
                <%=c.Title %>
                <br />
            </div>
            <br />

            <div class="c4">
                <div class="c5">
                    正文
                </div>
                <%=Content %>
               
            </div>
            <% if(next!=null) {%>
            <a id="tc_next_chapter" title="<%=next.Title %>" href="/wap/book/c.aspx?id=<%=next.ID %>" accesskey="6">下章</a> 
            <%} %>
            <a  id="tc_back_novellist" href="/wap/book/b.aspx?id=<%=b.ID %>">目录</a> 
            <%if(pre!=null){ %>
            <a  id="tc_pre_chapter" title="<%=pre.Title %>" href="/wap/book/c.aspx?id="<%=pre.ID %>">上章</a> 
            <%} %>
        </div>
        <br />
    </div>
    <div class="footer">
        手机阅读《<%=b.Title %>》,尽在<%=SystemSetting.SiteName %>
        <br />
        <form action="/wap/book/s.aspx"
        method="get">
        <div>
            <input type="text" name="key" id="word" value="<%=b.Title %>" /><input type="submit" name="su"
                value="搜小说" />
        </div>
        </form>
        <a href="/" title="<%=SystemSetting.SiteName %>">电脑站</a>
        <br />
        <%= DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss") %> 
    </div>
    <%=SystemSetting.CountCode %>
</body>
</html>