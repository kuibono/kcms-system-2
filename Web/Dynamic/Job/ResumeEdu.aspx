<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeEdu.aspx.cs" Inherits="Web.Dynamic.Job.ResumeEdu" %>
<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>教育背景-南京第一职网</title>
    <link type="text/css" rel="stylesheet" href="/skin/job/css/style.css" />
    <link type="text/css" rel="stylesheet" href="/skin/job/css/2013.css" />
    <link href="/skin/job/css/incenter.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../skin/script/jquery-1.7.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("select").change(function () {
                if ($(this).find(":selected").attr("class") == "disabled") {
                    $(this).val("");
                    return false;
                }
            })
        })
    </script>
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
                                    <span class="fr fc-999"><span id="resumetime" style="color: #999999;">更新于：<%=DateTime.Now.ToString("yyyy-MM-dd") %></span>&nbsp;&nbsp;|&nbsp;&nbsp;<%=ResumeOpen %></span><span
                                        class="yahei ft18 "><img src="/skin/job/img/ico-write.gif" width="23" height="20">我的简历</span></div>
                                <div class="resume-top-eara-wrap mt-10 ">
                                </div>
                                <div class="resume-m">
                                    <p class="clearfix w385">
                                        <a href="javascript:$('#fileUp').show();return false;" class="up-resume ft14 fc-333 re_upload_resume">
                                            上传附件简历
                                            <img src="/skin/job/img/up-ixo.png" width="21" height="22"></a><br />
                                        <div id="fileUp" style="display: none;">
                                            <form method="post" action="/e/Job/UploadResume.aspx" enctype="multipart/form-data">
                                            <input type="file" name="fname" />
                                            <br />
                                            <input type="submit" value="上传" class="btn-blue114" />
                                            </form>
                                        </div>
                                    </p>
                                </div>
                                <ul class="tab-blue clearfix" id="yw0">
                                    <li><a href="ResumeBasic.aspx">基本信息</a></li>
                                    <li class="here"><a href="ResumeEdu.aspx">教育背景</a></li>
                                </ul>
                                <div id="expedid" style="display: block;">
                                    <table width="752" border="0" cellspacing="0" cellpadding="0" class="tb-752" id="980">
                                        <tbody>
                                            <tr>
                                                <th width="240">
                                                    学校名称
                                                </th>
                                                <th>
                                                    时间
                                                </th>
                                                <th>
                                                    学历
                                                </th>
                                                <th>
                                                    操作
                                                </th>
                                            </tr>
                                            <asp:repeater id="rp_listEdu" runat="server">
                                             <ItemTemplate>
                                            <tr>
                                                <td align="center" width="240">
                                                    <p class="len w240">
                                                        <%#Eval("SchoolName") %></p>
                                                </td>
                                                <td align="center">
                                                    <%#Eval("StartTime").ToDateTime().ToString("yyyy年MM月") %> 至 <%#Eval("LeftTime").ToDateTime().ToString("yyyy年MM月") %>
                                                </td>
                                                <td align="center">
                                                    <%#JobAction.GetEduName(Eval("Edu").ToInt32()) %> <span></span>
                                                </td>
                                                <td align="center">
                                                    <a href="?id=<%#Eval("id") %>&action=edit">编辑</a><a href="?id=<%#Eval("id") %>&action=del"> 删除</a>
                                                </td>
                                            </tr>
                                            </ItemTemplate>
                                            </asp:repeater>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="pos-r">
                                  
                                    <h2 class="tit-cur-two">
                                        <span style="font-weight: bold;">新增教育背景</span></h2>
                                    <form id="xinxi" runat="server">
                                    <table width="752" border="0" cellspacing="0" cellpadding="0" class="tb-fillin">
                                        <tr>
                                            <td width="45" align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>学校名称</strong>
                                            </td>
                                            <td>
                                                <vd:vtextbox id="txt_Edu_SchoolName" runat="server" cssclass="inp-366 bor-d7d7d7 needCheck radius-4"></vd:vtextbox>
                                                <asp:label runat="server" id="lb_edu_id" visible="false"></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td id="time">
                                                <strong>进修时间</strong>
                                            </td>
                                            <td>
                                                <asp:dropdownlist id="ddl_edu_StartTime_Year" runat="server"></asp:dropdownlist>
                                                年
                                                <asp:dropdownlist id="ddl_edu_StartTime_Month" runat="server"></asp:dropdownlist>
                                                月 至
                                                <asp:dropdownlist id="ddl_edu_LeftTime_Year" runat="server"></asp:dropdownlist>
                                                年
                                                <asp:dropdownlist id="ddl_edu_LeftTime_Month" runat="server"></asp:dropdownlist>
                                                月
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;<i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>学&nbsp;&nbsp;&nbsp;&nbsp;历</strong>
                                            </td>
                                            <td>
                                                <asp:dropdownlist id="ddl_edu_Edu" runat="server"></asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;<i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>专&nbsp;&nbsp;&nbsp;&nbsp;业</strong>
                                            </td>
                                            <td>
                                                <asp:dropdownlist id="ddl_edu_Specialty" runat="server"></asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;
                                            </td>
                                            <td width="76" valign="top">
                                                <strong>专业描述</strong>
                                            </td>
                                            <td>
                                                <vd:vtextbox id="txt_edu_Intro" runat="server" height="50px" textmode="MultiLine"
                                                    width="300px" cssclass="tex-486-136 bor-d7d7d7 radius-4"></vd:vtextbox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;
                                            </td>
                                            <td width="76" valign="top">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:button runat="server" id="btn_edu_Save" text="保存" onclick="btn_edu_Save_Click"
                                                    cssclass="btn-blue114 fl mr-20" />
                                                <a onclick="_gaq.push(['_trackEvent', 'user center', 'continue', 'education'])" href="/mybaijob/resume/training"
                                                    class="link-conti"></a>
                                            </td>
                                        </tr>
                                    </table>
                                    </form>
                                </div>
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
                                <li><a href="Home.aspx" class="my-baijob" id="wodebaibo">我的第一职</a></li>
                                <li class="here"><a href="ResumeBasic.aspx" class="my-resume" id="jianliguanli">简历管理</a></li>
                                <li><a href="App.aspx" class="my-job" id="zhiweiguanli">职位管理</a></li>
                                <li><a href="Password.aspx" class="my-manage" id="zhanghaoguanli">帐号管理</a></li>
                            </ul>
                        </div>
                        <!-- .widget-area -->
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <%=JobAction.BottomHtml %>
</body>
</html>
