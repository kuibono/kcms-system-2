<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web.Dynamic.Job.Home" %>
<%@ Import Namespace="Voodoo.Basement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>我的简历-南京第一职网</title>
    <link type="text/css" rel="stylesheet" href="/skin/job/css/style.css" />
    <link type="text/css" rel="stylesheet" href="/skin/job/css/2013.css" />
    <link href="/skin/job/css/incenter.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../skin/script/jquery-1.7.min.js"></script>
</head>
<body>
    <%=JobAction.TopHtml %>
    <table width="989" bgcolor="#FFFFFF" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                <div id="main">
                    <div class="bor-c2e0eb clearfix bg-fff">
                        <div id="primary">
                            <div id="content">
                                <div class="tit-my-resume">
                                    <span class="fr fc-999"><span id="resumetime" style="color: #999999;">更新于：2012-10-10
                                        10:11:23</span>&nbsp;&nbsp;|&nbsp;&nbsp;<%=ResumeOpen %></span><span class="yahei ft18 "><img
                                            src="/skin/job/img/ico-write.gif" width="23" height="20">我的简历</span></div>
                                <div class="resume-top-eara-wrap mt-10 ">
                                </div>
                                <div class="resume-m">
                                    <p class="clearfix w385">
                                        <a href="javascript:void(0);" class="up-resume ft14 fc-333 re_upload_resume" onmousedown="_gaq.push(['_trackEvent', 'user center', 're-upload', 'mybaijob']);">
                                            上传附件简历
                                            <img src="/skin/job/img/up-ixo.png" width="21" height="22"></a>
                                    </p>
                                </div>
                                <ul class="tab-blue clearfix">
                                    <li class="here"><a href="javascript:void(0);" onclick="javascript:changeMyjob(1);_gaq.push(['_trackEvent', 'user center', 'recommendation', 'recommend']);"
                                        class="radius-tl4">我的职位推荐</a></li><li><a class="radius-tr4" href="javascript:void(0);"
                                            onclick="javascript:changeMyjob(3);_gaq.push(['_trackEvent', 'user center', 'collection', 'position']);">
                                            我浏览过的职位</a></li>
                                </ul>
                                <ul class="jobs-list-ul">
                                    <li class="clearfix">
                                        <input type="button" style="float: right" class="btn-blue114" value="查看详情" id="saveinfo" />
                                        <p>
                                            <span class="mr-10">2012-10-10 15:47</span></p>
                                        <p>
                                            我申请了<strong><a href="#" target="_blank" class=" mr-40 ft14 ml-10" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">软件工程师（学徒）</a></strong><a
                                                href="#" target="_blank" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">苏州凯富精密模具有限公司</a></p>
                                    </li>
                                </ul>
                                <ul class="jobs-list-ul">
                                    <li class="clearfix">
                                        <input type="button" style="float: right" class="btn-blue114" value="查看详情" id="saveinfo" />
                                        <p>
                                            <span class="mr-10">2012-10-10 15:47</span></p>
                                        <p>
                                            我申请了<strong><a href="#" target="_blank" class=" mr-40 ft14 ml-10" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">软件工程师（学徒）</a></strong><a
                                                href="#" target="_blank" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">苏州凯富精密模具有限公司</a></p>
                                    </li>
                                </ul>
                                <ul class="jobs-list-ul">
                                    <li class="clearfix">
                                        <input type="button" style="float: right" class="btn-blue114" value="查看详情" id="saveinfo" />
                                        <p>
                                            <span class="mr-10">2012-10-10 15:47</span></p>
                                        <p>
                                            我申请了<strong><a href="#" target="_blank" class=" mr-40 ft14 ml-10" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">软件工程师（学徒）</a></strong><a
                                                href="#" target="_blank" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">苏州凯富精密模具有限公司</a></p>
                                    </li>
                                </ul>
                                <ul class="jobs-list-ul">
                                    <li class="clearfix">
                                        <input type="button" style="float: right" class="btn-blue114" value="查看详情" id="saveinfo" />
                                        <p>
                                            <span class="mr-10">2012-10-10 15:47</span></p>
                                        <p>
                                            我申请了<strong><a href="#" target="_blank" class=" mr-40 ft14 ml-10" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">软件工程师（学徒）</a></strong><a
                                                href="#" target="_blank" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">苏州凯富精密模具有限公司</a></p>
                                    </li>
                                </ul>
                                <ul class="jobs-list-ul">
                                    <li class="clearfix">
                                        <input type="button" style="float: right" class="btn-blue114" value="查看详情" id="saveinfo" />
                                        <p>
                                            <span class="mr-10">2012-10-10 15:47</span></p>
                                        <p>
                                            我申请了<strong><a href="#" target="_blank" class=" mr-40 ft14 ml-10" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">软件工程师（学徒）</a></strong><a
                                                href="#" target="_blank" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">苏州凯富精密模具有限公司</a></p>
                                    </li>
                                </ul>
                                <ul class="jobs-list-ul">
                                    <li class="clearfix">
                                        <input type="button" style="float: right" class="btn-blue114" value="查看详情" id="saveinfo" />
                                        <p>
                                            <span class="mr-10">2012-10-10 15:47</span></p>
                                        <p>
                                            我申请了<strong><a href="#" target="_blank" class=" mr-40 ft14 ml-10" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">软件工程师（学徒）</a></strong><a
                                                href="#" target="_blank" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">苏州凯富精密模具有限公司</a></p>
                                    </li>
                                </ul>
                                <ul class="jobs-list-ul">
                                    <li class="clearfix">
                                        <input type="button" style="float: right" class="btn-blue114" value="查看详情" id="saveinfo" />
                                        <p>
                                            <span class="mr-10">2012-10-10 15:47</span></p>
                                        <p>
                                            我申请了<strong><a href="#" target="_blank" class=" mr-40 ft14 ml-10" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">软件工程师（学徒）</a></strong><a
                                                href="#" target="_blank" onmousedown="_gaq.push(['_trackEvent', 'user center', 'position', 'apply'])">苏州凯富精密模具有限公司</a></p>
                                    </li>
                                </ul>
                            </div>
                            <!-- #content -->
                        </div>
                        <!-- #primary -->
                        <div class="widget-area">
                            <div class="face-eara">
                                <a id="xiugaijibenxinxi" href="/mybaijob/resume/information">
                                    <img src="<%=Image %>" width="96" height="96" id="user_face" />
                                    <span>修改基本信息</span></a></div>
                            <ul class="l-nav">
                                <li class="here"><a href="Home.aspx" class="my-baijob" id="wodebaibo">我的第一职</a></li>
                                <li><a href="ResumeBasic.aspx" class="my-resume" id="jianliguanli">简历管理</a></li>
                                <li><a href="App.aspx" class="my-job" id="zhiweiguanli">职位管理</a></li>
                                <li><a href="Password.aspx" class="my-manage" id="zhanghaoguanli">帐号管理</a></li>
                            </ul>
                        </div>
                       
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <%=JobAction.BottomHtml %>
</body>
</html>
