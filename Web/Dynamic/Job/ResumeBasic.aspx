<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeBasic.aspx.cs" Inherits="Web.Dynamic.Job.ResumeBasic" %>

<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��������-�Ͼ���һְ��</title>
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
                                    <span class="fr fc-999"><span id="resumetime" style="color: #999999;">�����ڣ�<%=DateTime.Now.ToString("yyyy-MM-dd") %>
                                    </span>&nbsp;&nbsp;|&nbsp;&nbsp;<%=ResumeOpen %></span><span class="yahei ft18 "><img
                                        src="/skin/job/img/ico-write.gif" width="23" height="20">�ҵļ���</span></div>
                                <div class="resume-top-eara-wrap mt-10 ">
                                </div>
                                <div class="resume-m">
                                    <p class="clearfix w385">
                                        <a href="javascript:$('#fileUp').show();return false;" class="up-resume ft14 fc-333 re_upload_resume">
                                            �ϴ���������
                                            <img src="/skin/job/img/up-ixo.png" width="21" height="22"></a><br />
                                        <div id="fileUp" style="display: none;">
                                            <form method="post" action="/e/Job/UploadResume.aspx" enctype="multipart/form-data">
                                            <input type="file" name="fname" />
                                            <br />
                                            <input type="submit" value="�ϴ�" class="btn-blue114" />
                                            </form>
                                        </div>
                                    </p>
                                </div>
                                <ul class="tab-blue clearfix" id="yw0">
                                    <li class="here"><a href="ResumeBasic.aspx">������Ϣ</a></li>
                                    <li><a href="ResumeEdu.aspx">��������</a></li>
                                </ul>
                                <div class="pos-r">
                                    <form id="fom1" runat="server">
                                    <table width="752" border="0" cellspacing="0" cellpadding="0" class="tb-fillin">
                                        <tr>
                                            <td width="45" align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>�û�����</strong>
                                            </td>
                                            <td>
                                                <asp:textbox id="txt_ChineseName" cssclass="inp-154 bor-d7d7d7 radius-4" runat="server"></asp:textbox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td>
                                                <strong>��������</strong>
                                            </td>
                                            <td>
                                                <asp:dropdownlist id="ddl_Year" runat="server">
                                                </asp:dropdownlist>
                                                &nbsp;��&nbsp;
                                                <asp:dropdownlist id="ddl_Month" runat="server">
                                                </asp:dropdownlist>
                                                &nbsp;��&nbsp;
                                                <asp:dropdownlist id="ddl_Day" runat="server">
                                                </asp:dropdownlist>
                                                ��
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>��&nbsp;&nbsp;&nbsp;&nbsp;��</strong>
                                            </td>
                                            <td>
                                                <asp:radiobuttonlist id="ckl_sex" runat="server" repeatdirection="Horizontal" repeatlayout="Flow">
                                                    <asp:ListItem Value="1">��</asp:ListItem>
                                                    <asp:ListItem Value="0">Ů</asp:ListItem>
                                                </asp:radiobuttonlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>�־�ס��</strong>
                                            </td>
                                            <td>
                                                <asp:dropdownlist id="ddl_Province" runat="server" autopostback="True" onselectedindexchanged="ddl_Province_SelectedIndexChanged"></asp:dropdownlist>
                                                -
                                                <asp:dropdownlist id="ddl_City" runat="server"></asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>�ֻ�����</strong>
                                            </td>
                                            <td>
                                                <vd:vtextbox id="txt_Mobile" cssclass="inp-154 bor-d7d7d7 radius-4" runat="server"></vd:vtextbox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>�����ַ</strong>
                                            </td>
                                            <td>
                                                <vd:vtextbox id="txt_Email" runat="server" cssclass="inp-154 bor-d7d7d7 radius-4"></vd:vtextbox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                            </td>
                                            <td width="76">
                                                <strong>�ϴ���Ƭ</strong>
                                            </td>
                                            <td>
                                                <asp:fileupload id="file_Face" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                <i class="star-fill">*</i>
                                            </td>
                                            <td width="76">
                                                <strong>����������</strong>
                                            </td>
                                            <td>
                                                <asp:dropdownlist id="ddl_ProvinceWork" runat="server" autopostback="True" onselectedindexchanged="ddl_ProvinceWork_SelectedIndexChanged"></asp:dropdownlist>
                                                -
                                                <asp:dropdownlist id="ddl_CityWork" runat="server"></asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;
                                            </td>
                                            <td width="76" valign="top">
                                                <strong style="line-height: 32px">��ְ״̬</strong>
                                            </td>
                                            <td>
                                                <asp:radiobuttonlist id="ckl_Enable" runat="server" repeatdirection="Horizontal"
                                                    repeatlayout="Flow">
                                                    <asp:ListItem Value="1">Ŀǰ�������ҹ���</asp:ListItem>
                                                    <asp:ListItem Value="0">����ʱ�����ҹ���</asp:ListItem>
                                                </asp:radiobuttonlist>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="752" border="0" cellspacing="0" cellpadding="0" class="tb-fillin">
                                        <tr>
                                            <td width="45" align="right">
                                                &nbsp;
                                            </td>
                                            <td width="76" valign="top">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:button id="btn_Save" text="����" cssclass="btn-blue114" runat="server" onclick="btn_Save_Click" />
                                                <a id="jxtxgzjy" style="padding-left: 15px;" href="/mybaijob/resume/experience">
                                                </a>
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
                                <a id="xiugaijibenxinxi" href="ResumeBasic.aspx">
                                    <img src="<%=Image %>" width="96" height="96" id="user_face" />
                                    <span>�޸Ļ�����Ϣ</span></a></div>
                            <ul class="l-nav">
                                <li><a href="Home.aspx" class="my-baijob" id="wodebaibo">�ҵĵ�һְ</a></li>
                                <li class="here"><a href="ResumeBasic.aspx" class="my-resume" id="jianliguanli">��������</a></li>
                                <li><a href="App.aspx" class="my-job" id="zhiweiguanli">ְλ����</a></li>
                                <li><a href="Password.aspx" class="my-manage" id="zhanghaoguanli">�ʺŹ���</a></li>
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
