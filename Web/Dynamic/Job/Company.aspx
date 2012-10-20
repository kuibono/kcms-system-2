<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="Web.Dynamic.Job.Company" %>

<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=CompanyName %>-南京第一职网</title>
    <link type="text/css" rel="stylesheet" href="/skin/job/css/style.css" />
    <link type="text/css" rel="stylesheet" href="/skin/job/css/2013.css" />
    <script type="text/javascript" src="../../skin/script/jquery-1.7.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#chk_all").click(function () {
                if ($(this).prop("checked") == true) {
                    $(".select_id").prop("checked", true);
                }
                else {
                    $(".select_id").prop("checked", false);
                }
            })

            $("#btnMultiPost").click(function () {
                var ids = "";
                $(".select_id:checked").each(function () {
                    ids += $(this).val() + ",";
                });
                ids = ids.substr(0, ids.length - 1);
                post(ids);
            })

            $("#btnPostAll").click(function () {
                var ids = "";
                $(".select_id").each(function () {
                    ids += $(this).val() + ",";
                });
                ids = ids.substr(0, ids.length - 1);
                post(ids);
            })
        })

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
                        <td align="left" height="35">
                            <h2>
                                <%=CompanyName %></h2>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            公司行业：
                            <%=Industry %><br />
                            公司性质：
                            <%=CompanyType %>
                            <br />
                            公司规模：
                            <%=EmployeeCount %>
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                        </td>
                    </tr>
                    <tr>
                        <td class="job_com_detail">
                            <table width="95%" align="center" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="35" align="left" class="job_zw">
                                        公司简介
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
                        <td width="851">
                            <table width="851" border="0" cellspacing="0" cellpadding="0" align="center" class="chaxun">
                                <tr>
                                    <td width="40" align="center">
                                        <input type="checkbox" id="chk_all" />
                                    </td>
                                    <td width="80" align="left">
                                        <input type="button" id="btnMultiPost" value="批量投递" style="background: #75b90c; border: 1px solid #53a906;
                                            color: #FFFFFF; padding: 3px;" />
                                    </td>
                                    <td width="50" align="left">
                                        <input type="button" value="默认" style="background: #009bd8; border: 0px; color: #FFFFFF;
                                            padding: 3px;" />
                                    </td>
                                    <td width="80" align="center" class="job">
                                        <a id="btnPostAll" href="javascript:void(0);">一键投递</a>
                                    </td>
                                    <td width="300">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <%--                            <select style="border: 1px solid #e0e1e1; color: #666;" id="ddl_emp">
                                <%=str_EmployeeCount %>
                            </select>--%>
                                    </td>
                                    <td align="center">
                                        <%--                            <select style="border: 1px solid #e0e1e1; color: #666;" id="ddl_exp">
                                <%=str_Exp %>
                            </select>--%>
                                    </td>
                                </tr>
                            </table>
                            <table width="810" border="0" cellspacing="0" cellpadding="0" align="center" bgcolor="#FFFFFF">
                                <asp:repeater id="rp_list" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td height="130"><table width="810" align="center" border="0" cellspacing="0" cellpadding="0">
                                      <tbody><tr>
                                        <td width="40" valign="top" style="padding-top:10px;"><input type="checkbox"  value="<%#Eval("ID")%>" class="select_id"></td>
                                        <td><table width="710" border="0" cellspacing="0" cellpadding="0" align="center">
                                      <tbody><tr>
                                        <td align="left" class="job_title"><a href="Job.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %></a></td>
                                      </tr>
                                      <tr>
                                        <td align="left"><table width="610" border="0" cellspacing="0" cellpadding="0">
                                      <tbody><tr>
                                        <td align="left" class="job_compangy"><a href="Company.aspx?id=<%#Eval("CompanyID")%>"><%#Eval("CompanyName")%></a></td>
                                        <td align="left" class="job_qt">规模<%#Eval("EmployeeCount")%> / 学历<%#Eval("Edu")%> / 经验<%#Eval("Expressions")%></td>
                                        <td align="left" class="job_qt1">月薪 <span><%#Eval("Salary")%></span></td>
                                      </tr>
                                    </tbody></table></td>
                                      </tr>
                                    </tbody></table></td>
	                                    <td width="100" align="center" style="line-height:24px; color:#666666"><input  onclick="post(<%#Eval("ID")%>)" type="button" value="一键投递" style="background:url(img/td.gif) no-repeat; width:60px; height:22px; color:#FFFFFF; border:0px;"><br><%#Eval("PostTime").ToDateTime().ToString("yyyy-MM-dd")%></td>
                                      </tr>
                                      <tr>
                                        <td></td>
                                        <td class="job_con"><%#Eval("Intro")%>&nbsp;</td>
                                      </tr>
                                    </tbody></table></td>
                                      </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr>
                                        <td height="130" style="background:#f6f6f8; border-bottom:1px solid #eeeeee; border-top:1px solid #eeeeee;"><table width="810" align="center" border="0" cellspacing="0" cellpadding="0">
                                      <tbody><tr>
                                        <td width="40" valign="top" style="padding-top:10px;"><input type="checkbox"  value="<%#Eval("ID")%>" class="select_id"></td>
                                        <td><table width="710" border="0" cellspacing="0" cellpadding="0" align="center">
                                      <tbody><tr>
                                        <td align="left" class="job_title"><a href="Job.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %></a></td>
                                      </tr>
                                      <tr>
                                        <td align="left"><table width="610" border="0" cellspacing="0" cellpadding="0">
                                      <tbody><tr>
                                        <td align="left" class="job_compangy"><a href="Company.aspx?id=<%#Eval("CompanyID")%>"><%#Eval("CompanyName")%></a></td>
                                        <td align="left" class="job_qt">规模<%#Eval("EmployeeCount")%> / 学历<%#Eval("Edu")%> / 经验<%#Eval("Expressions")%></td>
                                        <td align="left" class="job_qt1">月薪 <span><%#Eval("Salary")%></span></td>
                                      </tr>
                                    </tbody></table></td>
                                      </tr>
                                    </tbody></table></td>
	                                    <td width="100" align="center" style="line-height:24px; color:#666666"><input  onclick="post(<%#Eval("ID")%>)" type="button" value="一键投递" style="background:url(img/td.gif) no-repeat; width:60px; height:22px; color:#FFFFFF; border:0px;"><br><%#Eval("PostTime").ToDateTime().ToString("yyyy-MM-dd")%></td>
                                      </tr>
                                      <tr>
                                        <td></td>
                                        <td class="job_con"><%#Eval("Intro")%>&nbsp;</td>
                                      </tr>
                                    </tbody></table></td>
                                      </tr>
                                </AlternatingItemTemplate>
                             </asp:repeater>
                                <tr>
                                    <td height="60" style="border-top: 1px solid #eeeeee;">
                                        <div id="page_id">
                                            <div class="pageNum">
                                                <vd:aspnetpager id="pager" runat="server" firstpagetext="首页" lastpagetext="尾页" nextpagetext="后页"
                                                    prevpagetext="前页" alwaysshow="true" urlpaging="True" pagesize="10" enableurlrewriting="True"
                                                    urlrewritepattern="Search.aspx">
                        </vd:aspnetpager>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
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
