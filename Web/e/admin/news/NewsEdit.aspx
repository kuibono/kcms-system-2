<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="Web.e.admin.news.NewsEdit"
    EnableEventValidation="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#sp_cor").click(function () {
                $("#div_color").show();
            })

            $("#div_color").click(function () {
                $("#sp_cor").css("background-color", $(".x-color-palette-sel span").css("background-color"));
                $("#div_color").hide();
            })

            $("#btn_author").click(function () {
                $("#txt_Author").val($(this).val());
            })
            $("#btn_source").click(function () {
                $("#txt_Source").val($(this).val());
            })

            $("#FCKeditor1___Frame").document.find("#TB_Button_Image").click(function () {
                window.open('../../file/addselect.aspx?type=1&classid=1&ctrl=FCKeditor1', '', 'width=460,height=500,scrollbars=yes');
                return false;
            })
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
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
                <td>
                    栏目
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Class" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                
                <td width="163">
                    标题
                </td>
                <td style="position: relative">
                    <vd:VTextBox ID="txt_Title" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox><br />
                    颜色 <span id="sp_cor" runat="server" style="height: 12px; width: 12px; cursor: pointer;">
                        &nbsp; </span>
                    <div id="div_color" style="position: absolute; top: 20px; display: none; background-color: #FFF;">
                        <ext:ColorPalette ID="cp_TitleColor" runat="server">
                        </ext:ColorPalette>
                    </div>
                    &nbsp; 属性:
                    <asp:CheckBox ID="chk_TitleB" Text="粗体" runat="server" />
                    <asp:CheckBox ID="chk_TitleI" Text="斜体" runat="server" />
                    <asp:CheckBox ID="chk_TitleS" Text="删除线" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    副标题/英文标题
                </td>
                <td>
                    <vd:VTextBox ID="txt_FTitle" runat="server"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    特殊属性
                </td>
                <td>
                    信息属性:
                    <asp:CheckBox ID="chk_Audit" runat="server" Text="审核" Checked="true" />
                    <asp:CheckBox ID="chk_Tuijian" runat="server" Text="推荐" />
                    <asp:CheckBox ID="chk_Toutiao" runat="server" Text="头条" />
                    <br />
                    <br />
                    关&nbsp;键&nbsp;字:
                    <asp:TextBox ID="txt_Key" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    外部链接:
                    <asp:TextBox ID="txt_NavUrl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    发布时间
                </td>
                <td>
                    <vd:VTextBox ID="txt_NewsTime" runat="server"></vd:VTextBox>
                    <asp:Button ID="btn_setNow" runat="server" Text="设为当前时间" OnClick="btn_setNow_Click"
                        CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    标题图片
                </td>
                <td>
                    <vd:VTextBox ID="txt_TitleImage" runat="server"></vd:VTextBox>
                    <a href="javascript:void(0)" onclick="window.open('../../file/addselect.aspx?type=1&classid=1&ctrl=txt_TitleImage','','width=460,height=500,scrollbars=yes');">
                        <img src="/e/data/images/img.gif" alt="选择/上传图片" />
                    </a>
                </td>
            </tr>
            <tr>
                <td>
                    内容简介
                </td>
                <td>
                    <vd:VTextBox ID="txt_Description" runat="server" TextMode="MultiLine" Height="100px"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    作者
                </td>
                <td>
                    <vd:VTextBox ID="txt_Author" runat="server" Text="未知" Width="100px"></vd:VTextBox>
                    <input type="button" id="btn_author" value="未知" />
                </td>
            </tr>
            <tr>
                <td>
                    来源
                </td>
                <td>
                    <vd:VTextBox ID="txt_Source" runat="server" Text="本站" Width="100px"></vd:VTextBox><input type="button"
                        id="btn_source" value="本站" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    正文
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="300px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr style="display:none;">
                <td colspan="2">
                    正文英文
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" Height="300px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr>
                <td>
                    附加选项
                </td>
                <td>
                    <asp:CheckBox ID="chk_SetTop" runat="server" Text="置顶" />
                    <asp:CheckBox ID="chk_CloseReply" runat="server" Text="关闭评论" />
                    &nbsp; 内容模版
                    <asp:DropDownList ID="ddl_contentTemp" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    点&nbsp;&nbsp;击
                    <vd:VTextBox ID="txt_ClickCount" runat="server" Width="50px" Text="0"></vd:VTextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp; 下&nbsp;&nbsp;载
                    <vd:VTextBox ID="txt_DownCount" runat="server" Width="50px" Text="0"></vd:VTextBox>
                    <br />
                    <br />
                    文件名
                    <vd:VTextBox ID="txt_FileForder" runat="server" Width="100px" />/
                    <vd:VTextBox ID="txt_FileName" runat="server" Width="100px" />
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
