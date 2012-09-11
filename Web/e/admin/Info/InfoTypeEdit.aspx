<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoTypeEdit.aspx.cs" Inherits="Web.e.admin.Info.InfoTypeEdit"
    ValidateRequest="false" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分类信息类型编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
            分类信息类型的编辑和修改</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        分类信息类型编辑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                        名称
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_TypeName" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        首页模板
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_TemplateIndex" runat="server" TextMode="MultiLine" Height="200px" Width="800px"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        列表模板
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_TemplateList" runat="server" TextMode="MultiLine" Height="200px" Width="800px"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        内容模板
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_TemplateContent" runat="server" TextMode="MultiLine" Height="200px" Width="800px"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        表单模板模板
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_TemplateForm" runat="server" TextMode="MultiLine" Height="200px" Width="800px"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        管理表单模板模板
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_TemplateAdminForm" runat="server" TextMode="MultiLine" Height="200px" Width="800px"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字1
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num1" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字2
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num2" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字3
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num3" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字4
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num4" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字5
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num5" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字6
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num6" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字7
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num7" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字8
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num8" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字9
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num9" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        数字10
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Num10" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本1
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar1" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本2
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar2" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本3
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar3" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本4
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar4" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本5
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar5" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本6
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar6" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本7
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar7" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本8
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar8" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本9
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar9" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本10
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar10" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                               <tr>
                    <td width="163">
                        文本11
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar11" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本12
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar12" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本13
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar13" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本14
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar14" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        文本15
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Nvarchar15" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        金额1
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Decimal1" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        金额2
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Decimal2" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        金额3
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Decimal3" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        金额4
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Decimal4" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        金额5
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Decimal5" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        长文本1
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Text1" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        长文本2
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Text2" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        长文本3
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Text3" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        长文本4
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Text4" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        长文本5
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Text5" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        布尔1
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Bit1" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        布尔2
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Bit2" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        布尔3
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Bit3" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        布尔4
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Bit4" runat="server"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        布尔5
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Bit5" runat="server"></vd:VTextBox>
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                        &nbsp;
                        <input type="button" value="取消" onclick="history.go(-1)" />
                    </th>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
