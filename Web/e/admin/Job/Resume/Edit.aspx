<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Web.e.admin.Job.Resume.Edit" %>

<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>简历编辑</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
            本页进行对简历进行编辑修改和新增</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        简历基本信息编辑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                        用户
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_User" runat="server"></asp:dropdownlist>
                        <asp:textbox id="txt_key" runat="server"></asp:textbox>
                        <asp:button id="btn_search" runat="server" causesvalidation="False" text="检索" onclick="btn_search_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        简历名称
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Title" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        姓名
                    </td>
                    <td>
                        <vd:vtextbox id="txt_ChineseName" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        照片
                    </td>
                    <td>
                        <asp:image id="Image1" runat="server" imageurl="~/u/ResumeFace/0.jpg" />
                        <asp:fileupload id="file_Face" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        出生日期
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Birthday" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        性别
                    </td>
                    <td>
                        <asp:radiobuttonlist id="ckl_sex" runat="server" repeatdirection="Horizontal" repeatlayout="Flow">
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="0">女</asp:ListItem>
                        </asp:radiobuttonlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        居住地
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Province" runat="server" autopostback="True" onselectedindexchanged="ddl_Province_SelectedIndexChanged"></asp:dropdownlist>
                        -
                        <asp:dropdownlist id="ddl_City" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        手机
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Mobile" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Email" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        期望工作地
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_ProvinceWork" runat="server" autopostback="True" onselectedindexchanged="ddl_ProvinceWork_SelectedIndexChanged"></asp:dropdownlist>
                        -
                        <asp:dropdownlist id="ddl_CityWork" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        国籍
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Country" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        地址
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Address" runat="server" width="300px"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        电话
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Tel" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        证件类型
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_CardType" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        证件号码
                    </td>
                    <td>
                        <vd:vtextbox id="txt_CardNo" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        籍贯
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_ProvinceHome" runat="server" autopostback="True" onselectedindexchanged="ddl_ProvinceHome_SelectedIndexChanged"></asp:dropdownlist>
                        -
                        <asp:dropdownlist id="ddl_CityHome" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        民族
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Nation" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        政治面貌
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Political" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        婚姻状况
                    </td>
                    <td>
                        <asp:dropdownlist id="ddl_Marriage" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        QQ
                    </td>
                    <td>
                        <vd:vtextbox id="txt_QQ" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        MSN
                    </td>
                    <td>
                        <vd:vtextbox id="txt_MSN" runat="server"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        简介
                    </td>
                    <td>
                        <vd:vtextbox id="txt_Intro" runat="server" height="50px" textmode="MultiLine" width="300px"></vd:vtextbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        简历开启
                    </td>
                    <td>
                        <asp:checkbox runat="server" id="chk_Enable" text="启用"></asp:checkbox>
                    </td>
                </tr>
                <tr>
                    <table border="1" cellpadding="0" cellspacing="1" class="list">
                        <thead>
                            <tr>
                                <th colspan="4">
                                    工作经验
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    企业名称
                                </th>
                                <th>
                                    时间
                                </th>
                                <th>
                                    职位
                                </th>
                                <th>
                                    操作
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:repeater id="rp_listExperience" runat="server" DataMember="id" 
                                onitemcommand="rp_listExperience_ItemCommand">
                                <ItemTemplate>
                                <tr>
                                    <td><asp:Label runat="server" ID="lab_typeID" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                        <%#Eval("CompanyName") %>
                                    </td>
                                    <td>
                                        <%#Eval("StartTime").ToDateTime().ToString("yyyy年MM月") %> 至 <%#Eval("LeftTime").ToDateTime().ToString("yyyy年MM月") %>
                                    </td>
                                    <td>
                                        <%#JobAction.GetIndustryName(Eval("Post").ToInt32()) %>
                                    </td>
                                    <td>
                                        <asp:LinkButton id="btn_Edit" runat="server">修改</asp:LinkButton>
                                        <asp:LinkButton id="btn_Del" runat="server">删除</asp:LinkButton>
                                    </td>
                                </tr>
                                </ItemTemplate>
                            </asp:repeater>
                        </tbody>
                    </table>
                    
                    <table border="1" cellpadding="0" cellspacing="0" class="edit">
                        <tbody>
                            <tr>
                                <td>
                                    公司名称
                                </td>
                                <td>
                                    <vd:vtextbox id="txt_Exp_CompanyName" runat="server"></vd:vtextbox>
                                    <asp:label runat="server" id="lb_id" visible="false"></asp:label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    时间
                                </td>
                                <td>
                                    <asp:dropdownlist id="ddl_exp_StartTime_Year" runat="server"></asp:dropdownlist>
                                    年
                                    <asp:dropdownlist id="ddl_exp_StartTime_Month" runat="server"></asp:dropdownlist>
                                    月 至
                                    <asp:dropdownlist id="ddl_exp_LeftTime_Year" runat="server"></asp:dropdownlist>
                                    年
                                    <asp:dropdownlist id="ddl_exp_LeftTime_Month" runat="server"></asp:dropdownlist>
                                    月
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    职位名称
                                </td>
                                <td>
                                    <asp:dropdownlist id="ddl_exp_Post" runat="server"></asp:dropdownlist>
                                </td>
                            </tr>
                            <tr>
                                <td>
              简介
                                </td>
                                <td>
                                    <vd:vtextbox id="txt_Exp_Intro" runat="server" height="50px" textmode="MultiLine" width="300px"></vd:vtextbox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:button runat="server" id="btn_Exp_Save" text="保存" 
                                        onclick="btn_Exp_Save_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:button id="btn_Save" text="保存" runat="server" onclick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="location.href='List.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
