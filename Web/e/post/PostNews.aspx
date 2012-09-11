<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostNews.aspx.cs" Inherits="Web.e.post.PostNews"
    ValidateRequest="false" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="cc1" %>
<%= Voodoo.Basement.CreatePage.CreateHeaderString("投递新闻") %>
<style type="text/css">
    #tb_post
    {
        border: solid 1px #c0c0c0;
        border-collapse: collapse;
        color: #000;
        width: 100%;
    }
    #tb_post td
    {
        height: 30px;
        line-height: 30px;
        border: solid 1px #c0c0c0;
        padding: 3px;
    }
    #tb_post td input[type=text], textarea
    {
        width: 200px;
    }
    #td_editor div
    {
        display: block;
        float: none;
    }
</style>

<script type="text/javascript" src="../../skin/script/editor/kindeditor-min.js"></script>

<script type="text/javascript" src="../../skin/script/editor/lang/zh_CN.js"></script>

<script type="text/javascript">
    var editor;
    KindEditor.ready(function(K) {
    editor = K.create('textarea[name="txt_Content"]', {
            resizeType: 1,
            allowPreviewEmoticons: false,
            allowImageUpload: true,
            allowFileManager : false,
            uploadJson : 'upload_json.aspx'
        });
    });
</script>

<div id="main_1" class="clearfix mg">
    <div class="nav">
        您的位置：<a href="/">首页</a>> <a href="javascript:void(0)">投递新闻</a></div>
    <div id="newslist" class="left inner" style="width: 660px;">
        <h1>
            投递新闻
        </h1>
        <form id="form1" runat="server">
        <table border="1" id="tb_post">
            <tr>
                <td width="100">
                    提交者
                </td>
                <td>
                    <asp:label id="lb_UserName" runat="server"></asp:label>
                </td>
            </tr>
            <tr>
                <td>
                    栏目
                </td>
                <td>
                    <asp:dropdownlist id="ddl_Class" runat="server">
                            </asp:dropdownlist>
                </td>
            </tr>
            <tr>
                <td>
                    标题
                </td>
                <td>
                    <cc1:VTextBox ID="txt_Title" runat="server" EnableValidate="true" EnableNull="false"></cc1:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    副标题
                </td>
                <td>
                    <cc1:VTextBox ID="txtFtitle" runat="server"></cc1:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    关键字
                </td>
                <td>
                    <cc1:VTextBox ID="txt_Keyword" runat="server"></cc1:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    标题图片
                </td>
                <td>
                    <asp:fileupload id="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    内容简介
                </td>
                <td>
                    <cc1:VTextBox ID="txt_Description" runat="server" TextMode="MultiLine"></cc1:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    作者
                </td>
                <td>
                    <cc1:VTextBox ID="txt_Author" runat="server"></cc1:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    信息来源
                </td>
                <td>
                    <cc1:VTextBox ID="txt_Source" runat="server"></cc1:VTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    正文
                </td>
            </tr>
            <tr>
                <td colspan="2" id="td_editor">
                    <asp:textbox id="txt_Content" runat="server" textmode="MultiLine" style="width: 650px;
                        height: 200px; visibility: hidden;"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:button id="btn_Save" runat="server" text="投递" onclick="btn_Save_Click" />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div class="right" style="width: 259px; margin-left: 32px;">
        <h1>
            功能菜单
        </h1>
        <ul style=" padding:10px">
            <%=Voodoo.Basement.CreatePage.BuildUserMenuString()%>
        </ul>
    </div>
</div>
<%= Voodoo.Basement.CreatePage.CreateFooterString() %>