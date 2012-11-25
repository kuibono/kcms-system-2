<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Web.e.admin.Job.Resume.List" %>
<%@ Import Namespace="Voodoo" %>
<%@ Import Namespace="Voodoo.Basement" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>简历管理</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
    <script type="text/javascript" src="../../../data/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../../data/swfupload/fileprogress.js"></script>
    <script type="text/javascript" src="../../../data/swfupload/handlers.js"></script>
    <script type="text/javascript" src="../../../data/swfupload/swfupload.queue.js"></script>
    <style type="text/css">
    .ctrlPn input,ctrlPn object
    {
        float:left;
        margin-left:10px;
    }
    </style>
    <script type="text/javascript">
        var swfu;
        $(function () {
            var settings = {
                flash_url: "../../../data/swfupload/swfupload.swf",
                upload_url: "../../../job/multiupload.aspx",
                //post_params: { "id": "<%=WS.RequestString("ID") %>" },
                file_size_limit: "100 MB",
                file_types: "*.doc;*.docx;",
                file_types_description: "word文档",
                file_upload_limit: 300,
                file_queue_limit: 0,
                custom_settings: {
                    progressTarget: "fsUploadProgress",
                    cancelButtonId: "btnCancel"
                },
                debug: false,

                // Button settings
                button_image_url: "../../../data/swfupload/TestImageNoText_65x29.png",
                button_width: "64",
                button_height: "21",
                button_placeholder_id: "multiupdate",
                button_text: '<span class="theFont">批量上传</span>',
                button_text_style: ".theFont { font-size: 12; }",
                button_text_left_padding: 12,
                button_text_top_padding: 3,

                // The event handler functions are defined in handlers.js
                file_queued_handler: fileQueued,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_start_handler: uploadStart,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: function () { alert("上传成功！"); location.href = location.href; },
                upload_complete_handler: uploadComplete,
                queue_complete_handler: queueComplete	// Queue plugin event
            };

            swfu = new SWFUpload(settings);
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="search">
            搜索：
            <asp:textbox id="txt_Key" runat="server"></asp:textbox>


            <asp:dropdownlist id="ddl_Province" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddl_Province_SelectedIndexChanged">
                <asp:ListItem Text="--不限省份--" Value=""></asp:ListItem>
            </asp:dropdownlist>
            <asp:dropdownlist id="ddl_City" runat="server">
                <asp:ListItem Text="--不限城市--" Value=""></asp:ListItem>
            </asp:dropdownlist>
            <asp:button id="btn_Search" runat="server" text="搜索" />
        </div>
         <table border="1" cellpadding="0" cellspacing="1" class="list">
            <thead>
                <tr>
                    <th>
                        <input type="checkbox" id="checkall" />
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        标题
                    </th>
                    <th>
                        姓名
                    </th>
                    <th>
                        省
                    </th>
                    <th>
                        市
                    </th>
                    <th>
                        手机
                    </th>
                    <th>
                        Email
                    </th>
                    <th>
                        性别
                    </th>
                    <th>
                        管理
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rp_list" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input name="id" type="checkbox" value="<%#Eval("ID") %>" />
                            </td>
                            <td>
                                <%#Eval("index") %>
                            </td>
                            <td>
                                <%#Eval("Title")%>
                            </td>
                            <td>
                                <%#Eval("ChineseName")%>
                            </td>
                            <td>
                                 <%#Eval("province1")%>
                            </td>
                            <td>
                                 <%#Eval("city1")%>
                            </td>
                            <td>
                                 <%#Eval("Mobile")%>
                            </td>
                            <td>
                                 <%#Eval("Email")%>
                            </td>
                            <td>
                                 <%#Eval("IsMale").ToBoolean()?"男":"女"%>
                            </td>
                            <td>
                                <a href="Edit.aspx?id=<%#Eval("ID") %>">修改</a> 
                                <a href="?id=<%#Eval("ID") %>&action=del"> 删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="11" class="ctrlPn">
                        <asp:Button ID="Button1" Text="删除" runat="server" OnClick="Button1_Click" />
                        &nbsp;
                        <asp:Button ID="btn_Add" Text="新增" OnClientClick="location.href='Edit.aspx';return false;" runat="server" />
                        &nbsp;
                        <span id="multiupdate">批量上传</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="11">
                        <vd:AspNetPager ID="pager" runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="后页"
                            PrevPageText="前页" AlwaysShow="true" OnPageChanged="pager_PageChanged">
                        </vd:AspNetPager>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
    </form>
</body>
</html>
