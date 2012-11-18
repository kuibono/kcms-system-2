<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Web.e.admin.Job.Post.Edit" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>职位编辑</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
    <script type="text/javascript" src="../../../data/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $(":checkbox.c_edu").click(function () {
                var vl = $(this).prop("checked") == true ? "True" : "False";
                $(this).parent("td").find(":hidden").val(vl);
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
            本页进行对职位信息进行编辑修改和新增</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        职位信息编辑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                        用户
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_User" runat="server" autopostback="True" onselectedindexchanged="ddl_User_SelectedIndexChanged"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        公司
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Company" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        标题
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Title" runat="server" enablevalidate="true" enablenull="false"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        地区
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Province" runat="server" autopostback="True" onselectedindexchanged="ddl_Province_SelectedIndexChanged"></asp:dropdownlist>
                        -
                        <asp:dropdownlist id="ddl_City" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        工资范围
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Salary" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        职位类型
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Expressions" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr style="display:none">
                    <td>
                        学历要求
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Edu" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        学历设置
                    </td>
                    <td>
                        <table class="style1">
                            <tr>
                                <td>
                                    学历
                                </td>
                                <td>
                                    招聘人数
                                </td>
                            </tr>
                            <asp:repeater id="rp_edu" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td width="50">
                                        <input class="c_edu" id="c_<%#Eval("key") %>" type="checkbox"  <%#Eval("Checked").ToString().ToLower()=="true"?"checked":"" %> value="<%#Eval("key") %>" />
                                        <label for="c_<%#Eval("key") %>"><%#Eval("text") %></label>

                                        <input name="chk" type="hidden" value="<%#Eval("Checked")%>" />
                                    </td>
                                    <td>
                                        <input type="text" name="number" value="<%#Eval("Number") %>" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:repeater>
                        </table>
                    </td>
                </tr>
                <tr style="display:none">
                    <td>
                        招聘人数
                    </td>
                    <td>
                        <vd:vtextbox id="txt_EmployNumber" runat="server" enablevalidate="true" enablenull="false"
                            vtype="integer"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        职位要求
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Intro" runat="server" height="50px" textmode="MultiLine" width="300px"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        过期时间
                    </td>
                    <td>
                         <vd:vtextbox id="txt_ExpireTime" runat="server" CssClass="Wdate" Width="140px" onfocus="WdatePicker({minDate:'%y-%M-%d',dateFmt:'yyyy-MM-dd HH:mm:ss'})"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        显示在首页
                    </td>
                    <td>
                        <asp:checkbox id="chk_Settop" runat="server" text="显示" />
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:button id="btn_Save" text="保存" runat="server" onclick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="location.href='<%=refer %>'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
