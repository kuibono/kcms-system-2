<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassEdit.aspx.cs" Inherits="Web.e.admin.news.ClassEdit" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>栏目编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
            本页进行信息的增加/修改</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        信息编辑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                        栏目名称
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ClassName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        栏目别名
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Alter" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        所属父栏目
                    </td>
                    <td>
                        <vd:VListBox ID="lbox_ParentID" runat="server" >
                        </vd:VListBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        是否终极栏目
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_IsLeafClass" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        栏目存放文件夹
                    </td>
                    <td>
                        <table border="0" cellspacing="1" cellpadding="3" style="width:300px">
                            <tr bgcolor="DBEAF5">
                                <td bgcolor="DBEAF5">
                                    &nbsp;
                                </td>
                                <td bgcolor="DBEAF5">
                                    上层栏目目录
                                </td>
                                <td bgcolor="DBEAF5">
                                    本栏目目录
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="right">
                                        /</div>
                                </td>
                                <td>
                                    <vd:VTextBox ID="txt_ParentClassForder" runat="server" Width="100px"></vd:VTextBox>
                                </td>
                                <td>
                                    <vd:VTextBox ID="txt_ClassForder" runat="server" Width="100px"></vd:VTextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        绑定系统模型
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_ModelID" runat="server">
                            <asp:ListItem Text="新闻系统模型" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        列表模版
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_Template" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        列内容模版
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_TemplateContent" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        栏目缩略图
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ClassICON" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        管理地址
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ManagementUrl" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        图片宽度
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ImageWidth" runat="server" Text="100"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        图片高度
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ImageHeight" runat="server" Text="100"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        栏目关键词
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ClassKeywords" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        栏目简介
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_ClassDescription" runat="server" TextMode="MultiLine"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        选项设置
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_ShowInNav" runat="server" Text="在导航中显示" />
                        <asp:CheckBox ID="chk_EnablePost" runat="server" Text="开放投稿" />
                        <br /><br />
                        显示排序：
                        <vd:VTextBox ID="txt_NavIndex" runat="server" EnableValidate="true" 
                            VType="integer" Text="0" Width="50px">0</vd:VTextBox>
                        <br /><br />
                        栏目访问权限<asp:CheckBoxList ID="cbl_VisitRole" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>
                        投稿设置
                    </td>
                    <td>
                        投稿权限 <asp:CheckBoxList ID="cbl_PostRoles" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                        <br />
                        <br />
                        投稿生成列表<asp:DropDownList ID="ddl_PostcreateList" runat="server"></asp:DropDownList>
                        <br/><br/>
                        投稿增加点数<vd:VTextBox ID="txt_PostAddCent" runat="server" EnableValidate="true" VType="integer" Width="50px" Text="0"></vd:VTextBox>
                        <asp:CheckBox ID="chk_NeedAudit" runat="server" Text="投稿需要审核" />
                        <br/><br/>
                        管理投稿<asp:DropDownList ID="ddl_PostManagement" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        信息发布设置
                    </td>
                    <td>
                        增加/编辑信息<asp:DropDownList ID="ddl_EditcreateList" runat="server"></asp:DropDownList>
                        <br /><br />
                        审核设置<asp:CheckBox ID="chk_AutoAudt" runat="server" Checked="true" Text="直接审核" />
                    </td>
                </tr>
                <tr>
                    <td>
                        评论设置
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_EnableReply" runat="server" Checked="true" Text="允许评论" />
                        <asp:CheckBox ID="chk_ReplyNeedAudit" runat="server" Checked="true" Text="评论自动审核" />
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="location.href='SysUserList.aspx'" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
