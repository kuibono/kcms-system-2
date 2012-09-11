<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="Web.e.admin.news.ClassList" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>栏目管理</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <link rel="stylesheet" type="text/css" href="../../data/css/jquery.treeTable.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
    <script type="text/javascript" src="../../data/script/jquery.blockUI.js"></script>
    <script type="text/javascript" src="../../data/script/jquery.ui.js"></script>
    <script type="text/javascript" src="../../data/script/jquery.treeTable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#table_tree").treeTable({
                //expandable: false //false为全部展开
                treeColumn: 0
            });

        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        如果你选择的是非终极栏目，则转为终极栏目(此栏目不能有子栏目) 如果你选择的是终极栏目，则转为非终极栏目(请先把当前栏目的数据转移，否则会出现冗余数据) 修改栏目顺序:顺序值越小越前面
    </div>
    <table border="1" cellpadding="0" cellspacing="1" class="list" id="table_tree">
        <thead>
            <tr>
                <th width="100">
                    栏目
                </th>
                <th>
                    <input type="checkbox" id="checkall" />
                </th>
                <th>
                    ID
                </th>
                <th>
                    顺序
                </th>
                <th>
                    是否终极栏目
                </th>
                <th>
                    管理
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rp_list" runat="server">
                <ItemTemplate>
                    <tr id="node-<%#Eval("ID") %>" <%#Eval("ParentID").ToInt32()>0?"class=\"child-of-node-"+ Eval("ParentID") +"\"":"" %>>
                        <td>
                            <%#Eval("ClassName")%>
                        </td>
                        <td>
                            <input name="id" type="checkbox" value="<%#Eval("ID") %>" />
                        </td>
                        <td>
                            <%#Eval("ID") %>
                        </td>
                        <td>
                            <input type="text" value="<%#Eval("NavIndex")%>" name="navindex[]">
                        </td>
                        <td>
                            <%#Eval("IsLeafClass")%>
                        </td>
                        <td>
                            <a href="ClassEdit.aspx?id=<%#Eval("ID") %>">修改</a> <a href="?id=<%#Eval("ID") %>&action=del">
                                删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="6" class="ctrlPn">
                    <asp:Button ID="btn_order" Text="修改顺序" runat="server" OnClick="btn_order_Click" />
                    &nbsp;<asp:Button ID="btn_Add" Text="新增" runat="server" OnClientClick="location.href='ClassEdit.aspx';return false;" />
                </td>
            </tr>
        </tfoot>
    </table>
  
    </form>
</body>
</html>
