<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job.aspx.cs" Inherits="Web.Dynamic.Job.Job" %>
<%@ Import Namespace="Voodoo.Basement" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=Title %>-<%=CompanyName %>-�Ͼ���һְ��</title>
    <link type="text/css" rel="stylesheet" href="/skin/job/css/style.css" />
    <script type="text/javascript" src="../../skin/script/jquery-1.7.min.js"></script>
    <script type="text/javascript">
        function post(data) {
            $.post("/e/Job/Post.aspx", { id: data }, function (r) {
                alert(r.Text);
            }, "json")
        }
    </script>
</head>
<body>
    <%=JobAction.TopHtml %>
    <table width="989" bgcolor="#FFFFFF" align="center" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="20">
            </td>
        </tr>
    </table>
    <table width="989" bgcolor="#FFFFFF" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                <table width="851" border="0" cellspacing="0" cellpadding="0" align="center">
                    <tr>
                        <td align="left">
                            <h1>
                                <%=Title %></h1>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: 1px solid #a5d3e8; padding-bottom: 15px;" align="left">
                            <h2>
                                <a href="company.aspx?id=<%=CompanyID %>"><%=CompanyName %></a></h2>
                        </td>
                    </tr>
                    <tr>
                        <td height="130">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tbPosi">
                                <tr>
                                    <td width="115" height="31" align="center" class="wTit">
                                        ��������
                                    </td>
                                    <td class="wCon">
                                        <%=PostTime %>
                                    </td>
                                    <td width="115" align="center" class="wTit">
                                        �����ص�
                                    </td>
                                    <td class="wCon" style="border-right: 0px;">
                                        <p class="len addrDet">
                                            <%=Province %>-<%=City %></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="31" align="center" class="wTit">
                                        ��������
                                    </td>
                                    <td class="wCon">
                                        <%=Exp %>
                                    </td>
                                    <td align="center" class="wTit">
                                        ���ʴ���
                                    </td>
                                    <td class="wCon" style="border-right: 0px;">
                                        <%=Salary %>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="31" align="center" class="wTit">
                                        ѧ��Ҫ��
                                    </td>
                                    <td class="wCon" style="border-bottom: 0px">
                                        <%=Edu %>
                                    </td>
                                    <td align="center" class="wTit">
                                        ��Ƹ����
                                    </td>
                                    <td class="wCon" style="border-right: 0px; border-bottom: 0px;">
                                        <%=EmpCount %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input onclick="post(<%=id %>);" type="button" class="btn-job" value="һ��Ͷ��" />
                        </td>
                    </tr>
<%--                    <tr>
                        <td height="30" class="job_tedail">
                            ������������С��80%�����Ͷ��Ч���� <a href="#">���Ƽ���</a>
                        </td>
                    </tr>--%>
                    <tr>
                        <td height="20">
                        </td>
                    </tr>
                    <tr>
                        <td class="job_com_detail">
                            <table width="95%" align="center" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="35" align="left" class="job_zw">
                                        ְλ����
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-bottom: 10px;">
                                        <%=Intro %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                        </td>
                    </tr>
                    <tr>
                        <td class="job_detail_detail">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="job_detail_top">
                                        ��˾���
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center">
                                            <tr>
                                                <td height="55" style="font-size: 14px" class="job_compangy">
                                                    <a href="company.aspx?id=<%=CompanyID %>"><%=CompanyName %></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%=CompIntro %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="job_compangy">
                                                    <a href="company.aspx?id=<%=CompanyID %>">�鿴��Ƹ�е�ְλ>></a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                        </td>
                    </tr>
                    <tr>
                        <td class="job_detail_detail">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="job_detail_top1">
                                        ���ְλ
                                    </td>
                                </tr>
                                <%=RelaJobs %>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
     <%=JobAction.BottomHtml %>
</body>
</html>
