<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Web.Dynamic.Job.Search" %>
<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>南京第一职网</title>
    <link type="text/css" rel="stylesheet" href="/skin/job/css/style.css" />
    <link type="text/css" rel="stylesheet" href="/skin/job/css/2013.css" />
    <script type="text/javascript" src="../../skin/script/jquery-1.7.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnSearch").click(function () {
                if ($("#txtKey").val() == "任何关键字") {
                    $("#txtKey").val("")
                }
                if ($("#txtLocation").val() == "请输入地点") {
                    $("#txtLocation").val("")
                }
                $("#search").submit();
            });
            $("#ddl_emp").change(function () {
                location.href = $(this).val();
            })
            $("#ddl_exp").change(function () {
                location.href = $(this).val();
            })
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
    <script type="text/javascript">
        $(function () {
            $("#btnSearch").click(function () {
                if ($("#txtKey").val() == "任何关键字") {
                    $("#txtKey").val("")
                }
                if ($("#txtLocation").val() == "请输入地点") {
                    $("#txtLocation").val("")
                }
                $("#search").submit();
            });
            Mark($("#txtKey"), "任何关键字");
            Mark($("#txtLocation"), "请输入地点");
        })
        function Mark(obj, mark) {
            if ($(obj).val() == "") {
                $(obj).val(mark);
            }
            $(obj).focus(function () {
                if ($(obj).val() == mark) {
                    $(obj).val("");
                }
            }).blur(function () {
                if ($(obj).val() == "") {
                    $(obj).val(mark);
                }
            })
        }
    </script>
<table width="989" border="0" cellspacing="0" cellpadding="0" align="center">
        <tbody><tr>
            <td height="35" class="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody><tr>
                        <td align="left" class="top_left">
                            <a href="/Dynamic/Job/">首页</a><a href="Home.aspx">简历</a> <a href="App.aspx">职位</a> <a href="Home.aspx">推荐职位</a>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td width="260" class="top_right" id="pnLogin" align="right">
                            <script type="text/javascript">
                                $(function () {
                                    $("#pnLogin").load("/e/member/user_panel_ajax.aspx");
                                });
                            </script>
                        </td>
                    </tr>
                </tbody></table>
            </td>
        </tr>
        <tr>
            <td class="menu">
                <form method="get" id="search" name="search" action="Search.aspx">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody><tr>
                        <td width="200" align="center">
                            <a href="/Dynamic/Job/"><img src="/skin/job/img/logo.jpg" border="0" width="146"></a>
                        </td>
                        <td>
                            <input type="text" id="txtKey" value="<%=key %>" name="k" style="width: 433px; height: 30px; line-height: 30px;">
                        </td>
                        <td>
                            <input type="text" id="txtLocation" value="<%=location %>" name="l" style="width: 187px; height: 30px; line-height: 30px;">
                        </td>
                        <td width="45">
                            <img src="/skin/job/img/9.jpg" id="btnSearch" width="38" height="34">
                        </td>
                        <td width="80" align="left" class="search">
                            <a href="Search.aspx">高级搜索</a><br>
                            <a href="Search.aspx">职位浏览</a>
                        </td>
                    </tr>
                </tbody></table>
                </form>
                
            </td>
        </tr>
    </tbody></table>
    <table width="989" bgcolor="#FFFFFF" align="center" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="20">
            </td>
        </tr>
    </table>
    <table width="989" bgcolor="#FFFFFF" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" height="35">
                                <tr>
                                    <td align="center" class="job">
                                        月薪：
                                    </td>
                                    <td width="50" align="left" class="buxian">
                                        <%=str_Salary_Bx %>
                                    </td>
                                    <td align="left" class="xz">
                                        <%=str_Salary %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" height="35">
                                <tr>
                                    <td align="center" class="job">
                                        更新：
                                    </td>
                                    <td width="50" align="left" class="buxian">
                                       <%=str_UpdateTime_Bx %>
                                    </td>
                                    <td align="left" class="xz">
                                        <%=str_UpdateTime %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" height="35">
                                <tr>
                                    <td align="center" class="job">
                                        学历：
                                    </td>
                                    <td width="50" align="left" class="buxian">
                                        <%=str_Edu_Bx %>
                                    </td>
                                    <td align="left" class="xz">
                                        <%=str_Edu %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" height="35">
                                <tr>
                                    <td align="center" valign="top" class="job" style="padding-top: 10px;">
                                        行业：
                                    </td>
                                    <td width="50" align="left" valign="top" class="buxian" style="padding-top: 10px;">
                                        <%=str_Industry_Bx %>
                                    </td>
                                    <td align="left" class="xz">
                                        <%=str_Industry %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="989" bgcolor="#FFFFFF" align="center" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10">
            </td>
        </tr>
    </table>
    <table width="989" bgcolor="#FFFFFF" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td width="782">
                <table width="771" border="0" cellspacing="0" cellpadding="0" align="center" class="chaxun">
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
                            <select style="border: 1px solid #e0e1e1; color: #666;" id="ddl_emp">
                                <%=str_EmployeeCount %>
                            </select>
                        </td>
                        <td align="center">
                            <select style="border: 1px solid #e0e1e1; color: #666;" id="ddl_exp">
                                <%=str_Exp %>
                            </select>
                        </td>
                    </tr>
                </table>
                <table width="770" border="0" cellspacing="0" cellpadding="0" align="center" bgcolor="#FFFFFF">
                    <asp:repeater id="rp_list" runat="server">
                                <ItemTemplate>
                                <tr>
                                 <td height="130">
                                  <table width="710" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" valign="top" style="padding-top: 10px;">
                                            <input type="checkbox" value="<%#Eval("ID")%>" class="select_id" />
                                        </td>
                                        <td>
                                            <table width="580" border="0" cellspacing="0" cellpadding="0" align="center">
                                                <tr>
                                                    <td align="left" class="job_title">
                                                        <a href="Job.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <table width="610" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="left" class="job_compangy">
                                                                    <a href="Company.aspx?id=<%#Eval("CompanyID")%>"><%#Eval("CompanyName")%></a>
                                                                </td>
                                                                <td align="left" class="job_qt">
                                                                    规模<%#Eval("EmployeeCount")%> / 学历<%#Eval("Edu")%> / 经验<%#Eval("Expressions")%>
                                                                </td>
                                                                <td align="left" class="job_qt1">
                                                                    月薪 <span><%#Eval("Salary")%></span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="100" align="center" style="line-height: 24px; color: #666666">
                                            <input onclick="post(<%#Eval("ID")%>)" type="button" value="一键投递" style="background: url(/skin/job/img/td.gif) no-repeat;
                                                width: 60px; height: 22px; color: #FFFFFF; border: 0px;" /><br />
                                            <%#Eval("PostTime").ToDateTime().ToString("yyyy-MM-dd")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td class="job_con">
                                            &nbsp;&nbsp;<%#Eval("Intro").ToS().TrimHTML().CutString(200)%>
                                        </td>
                                    </tr>
                                </table>
                              </td>
                            </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr>
                                       <td height="130" style="background: #f6f6f8; border-bottom: 1px solid #eeeeee; border-top: 1px solid #eeeeee;">
                                            <table width="710" align="center" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="40" valign="top" style="padding-top: 10px;">
                                                    <input type="checkbox" value="<%#Eval("ID")%>"  class="select_id"/>
                                                </td>
                                                <td>
                                                    <table width="580" border="0" cellspacing="0" cellpadding="0" align="center">
                                                        <tr>
                                                            <td align="left" class="job_title">
                                                                <a href="Job.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <table width="610" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td align="left" class="job_compangy">
                                                                             <a href="Company.aspx?id=<%#Eval("CompanyID")%>"><%#Eval("CompanyName")%></a>
                                                                        </td>
                                                                        <td align="left" class="job_qt">
                                                                            规模<%#Eval("EmployeeCount")%> / 学历<%#Eval("Edu")%> / 经验<%#Eval("Expressions")%>
                                                                        </td>
                                                                        <td align="left" class="job_qt1">
                                                                            月薪 <span><%#Eval("Salary")%></span>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="100" align="center" style="line-height: 24px; color: #666666">
                                                    <input onclick="post(<%#Eval("ID")%>)" type="button" value="一键投递" style="background: url(/skin/job/img/td.gif) no-repeat;
                                                        width: 60px; height: 22px; color: #FFFFFF; border: 0px;" /><br />
                                                    <%#Eval("PostTime").ToDateTime().ToString("yyyy-MM-dd")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td class="job_con">
                                                    &nbsp;&nbsp;<%#Eval("Intro").ToS().TrimHTML().CutString(200)%>
                                                </td>
                                            </tr>
                                        </table>
                                 </td>
                                </tr>
                                </AlternatingItemTemplate>
                             </asp:repeater>
                    <tr>
                        <td height="60" style="border-top: 1px solid #eeeeee;">
                            <div id="page_id">
                                <div class="pageNum">
                                    <vd:aspnetpager id="pager" runat="server" firstpagetext="首页" lastpagetext="尾页" nextpagetext="后页"
                                        prevpagetext="前页" alwaysshow="true" urlpaging="True" pagesize="10" enableurlrewriting="True"
                                        urlrewritepattern="Search.aspx"></vd:aspnetpager>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <div class="listLeft">
                    <div class="blur-bor-box clearfix mb-10" style="height: 80px;display:none;">
                        <dl class="wzd-dl">
                            <dt>您的简历不完善，影响投递效果</dt>
                            <dd>
                                <span class="wzd-dgree-pricent"><i style="width: 30%"></i></span>
                            </dd>
                        </dl>
                        <dl class="wanshan">
                            <a target="_blank" href="ResumeBasic.aspx">请立即完善&raquo;</a></dl>
                    </div>
                    <div class="blur-bor-box clearfix mb-10" style="display:none;">
                        <a href="#" target="_blank">
                            <img alt="" src="/skin/job/img/zwtj.jpg"></a>
                    </div>
                    <p class="pb-10" id="upload_send" style="height: 33px;">
                        <a href="ResumeBasic.aspx" class="btn_upRsu upload_attachment"></a>
                    </p>
                    <div class="listSel_ad">
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <%=htmlFooter %>
</body>
</html>
