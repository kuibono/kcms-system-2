<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageEdit.aspx.cs" Inherits="Web.e.admin.images.ImageEdit" %>

<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />

    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="../../data/script/common.js"></script>

    <script type="text/javascript" src="../../data/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../data/swfupload/fileprogress.js"></script>
    <script type="text/javascript" src="../../data/swfupload/handlers.js"></script>
    <script type="text/javascript" src="../../data/swfupload/swfupload.queue.js"></script>

    <script type="text/javascript">
        var swfu;
        $(function() {
            var settings = {
                flash_url: "../../data/swfupload/swfupload.swf",
                upload_url: "upload.aspx",
                post_params: { "id": "<%=WS.RequestString("ID") %>" },
                file_size_limit: "100 MB",
                file_types: "*.jpg;*.png;*.bmp;*.gif",
                file_types_description: "图片文件",
                file_upload_limit: 300,
                file_queue_limit: 0,
                custom_settings: {
                    progressTarget: "fsUploadProgress",
                    cancelButtonId: "btnCancel"
                },
                debug: false,

                // Button settings
                button_image_url: "../../data/swfupload/TestImageNoText_65x29.png",
                button_width: "100",
                button_height: "29",
                button_placeholder_id: "spanButtonPlaceHolder",
                button_text: '<span class="theFont">选择</span>',
                button_text_style: ".theFont { font-size: 16; }",
                button_text_left_padding: 12,
                button_text_top_padding: 3,

                // The event handler functions are defined in handlers.js
                file_queued_handler: fileQueued,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_start_handler: uploadStart,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadSuccess,
                upload_complete_handler: uploadComplete,
                queue_complete_handler: queueComplete	// Queue plugin event
            };

            swfu = new SWFUpload(settings);
        })
    </script>

    <style type="text/css">
        div.fieldset
        {
            border: 1px solid #afe14c;
            margin: 10px 0;
            padding: 20px 10px;
        }
        div.fieldset span.legend
        {
            position: relative;
            background-color: #FFF;
            padding: 3px;
            top: -30px;
            font: 700 14px Arial, Helvetica, sans-serif;
            color: #73b304;
        }
        div.flash
        {
            width: 375px;
            margin: 10px 5px;
            border-color: #D9E4FF;
            -moz-border-radius-topleft: 5px;
            -webkit-border-top-left-radius: 5px;
            -moz-border-radius-topright: 5px;
            -webkit-border-top-right-radius: 5px;
            -moz-border-radius-bottomleft: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -moz-border-radius-bottomright: 5px;
            -webkit-border-bottom-right-radius: 5px;
        }
        li
        {
            border: 1px solid #C0C0C0;
            float: left;
            height: auto;
            margin: 2px 12px;
            padding: 1px;
            text-align: center;
            color  : #000000;
            list-style-type: none;
            font-family: inherit;
            font-size: 100%;
            font-style: inherit;
            font-weight: inherit;
            outline: 0 none;
            vertical-align: baseline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        本页进行图片的增加/修改</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    图片编辑
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
                    <vd:VTextBox ID="txt_Title" runat="server" EnableValidate="true"></vd:VTextBox>
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
            <%--            <tr>
                <td>
                    文件夹
                </td>
                <td>
                    <vd:VTextBox ID="txt_Folder" runat="server" EnableValidate="true"></vd:VTextBox>
                </td>
            </tr>--%>
            <tr>
                <td>
                    关键词
                </td>
                <td>
                    <vd:VTextBox ID="txt_Keyword" runat="server" EnableValidate="true"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    简介
                </td>
                <td>
                    <vd:VTextBox ID="txt_Intro" runat="server" TextMode="MultiLine"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    点击数
                </td>
                <td>
                    <vd:VTextBox ID="txt_ClickCount" runat="server" EnableValidate="true" VType="integer"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    评论数
                </td>
                <td>
                    <vd:VTextBox ID="txt_ReplyCount" runat="server" EnableValidate="true" VType="integer"></vd:VTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    图集
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <ul>
                        <asp:Repeater ID="rp_list" runat="server">
                            <ItemTemplate>
                            <li>
                                <img height="100" src="<%#Eval("SmallPath")%>" />
                                <br />
                                <span><input type="text" name="tit[]" value="<%#Eval("Title")%>" style="width:98%;" /></span>
                                <br />
                                <span><textarea name="intro[]" style="height: 100%; width: 95%"><%#Eval("Intro")%></textarea></span>
                                <br />
                                <span><a href="?id=<%=id %>&imgid=<%#Eval("ID") %>&action=del&class=<%=cls %>" onclick="return confirm('确定要删除这张照片？')">删除</a></span>
                            </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </td>
            </tr>
            <tr>
                <td>
                    上传
                </td>
                <td>
                    <div class="fieldset flash" id="fsUploadProgress">
                        <span class="legend">传输队列</span>
                    </div>
                    <div>
                        <span id="spanButtonPlaceHolder"></span>
                    </div>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:Button ID="btn_Save" Text="保存" runat="server" OnClick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="history.go(-1)'" />
                    &nbsp;
                    <asp:Button ID="btn_Refresh" runat="server" Text="刷新" OnClick="btn_Refresh_Click"
                        Style="display: none" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
