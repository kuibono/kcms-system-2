<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionEdit.aspx.cs" Inherits="Web.e.admin.question.QuestionEdit" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>问答编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        本页进行问答的增加/修改</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    问答编辑
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    栏目
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Class" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    标题
                </td>
                <td>
                    <vd:VTextBox ID="txt_Title" runat="server" EnableValidate="true" Width="400px"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    作者
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Author" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    内容
                </td>
                <td>
                    <vd:VTextBox ID="txt_Content" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    点击数
                </td>
                <td>
                    <vd:VTextBox ID="txt_ClickCount" runat="server" EnableValidate="true" VType="integer" Text="0" Width="50px"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="1" cellpadding="0" cellspacing="0" style="border: solid 1px gray;
                        border-collapse: collapse">
                        <thead>
                            <tr>
                                <th>
                                    回答
                                </th>
                                <th width="100">
                                    姓名
                                </th>
                                <th width="100">
                                    电话
                                </th>
                                <th width="100">
                                    管理
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rp_list" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td align="left">
                                            <%#Eval("Content") %>
                                        </td>
                                        <td align="left">
                                            <%#Eval("UserName") %>
                                        </td>
                                        <td align="left">
                                            <%#Eval("Tel") %>
                                        </td>
                                        <td align="center">
                                            <a href="?id=<%=id %>&anid=<%#Eval("ID") %>&action=del&class=<%=cls %>" onclick="return confirm('确定要删除这张照片？')">删除</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="history.go(-1)'" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
