<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewQuestion.aspx.cs" Inherits="Web.e.post.question.NewQuestion"  ValidateRequest="false" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register assembly="Voodoo" namespace="Voodoo.UI" tagprefix="vd" %>
<%= Voodoo.Basement.CreatePage.CreateHeaderString("发布提问")%>
<script type="text/javascript" src="../../../skin/script/editor/kindeditor-min.js"></script>

<script type="text/javascript" src="../../../skin/script/editor/lang/zh_CN.js"></script>

<script type="text/javascript">
    var editor;
    KindEditor.ready(function(K) {
    editor = K.create('textarea[name="txt_Content"]', {
            resizeType: 0,
            allowPreviewEmoticons: false,
            allowImageUpload: true,
            allowFileManager : false,
            uploadJson : 'upload_json.aspx'
        });
    });
    $("#form1").submit(function() { 
    	if($("#ddl_Class").val().length==0){
          alert("栏目不能为空");
          return false;
        }
    })
    $("#btn_Submit").click(function() { 
    	if($("#ddl_Class").val().length==0){
          alert("栏目不能为空");
          return false;
        }
    })

</script>
<style type="text/css">
    td
    {
        height: 30px;
        line-height: 30px;
        border: solid 1px #c0c0c0;
        padding: 3px;
    }
    .ke-edit
    {
        width:680px;
    }
</style>

        <div id="main_1" class="clearfix mg">
        	<div class="nav">您的位置：<a href="/">首页</a>> <a href="javascript:void(0)">发布提问</a></div>
            <div id="newslist" class="left inner" style="width: 690px;">
                <h1>
                    发布提问
                </h1>
                <form id="form1" runat="server" style="display: block; float: none;">
                    <table border="1" cellpadding="0" cellspacing="0" style="border:solid 1px #c0c0c0; border-collapse:collapse">
                        <tr>
                            <td style="width:100px;">
                                选择栏目
                            </td>
                            <td style="width:500px;">
                                <asp:dropdownlist ID="ddl_Class" runat="server"></asp:dropdownlist>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                标题
                            </td>
                            <td style="width:500px;">
                                <asp:textbox ID="txt_Title" runat="server" Width="250px"></asp:textbox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <textarea name="txt_Content" style="width:684px; height:200px;margin-top:10px;"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                <asp:button runat="server" ID="btn_Submit" text="提问" OnClick="btn_Submit_Click" />
                            </td>
                        </tr>
                    </table>
                
                </form>
            </div>
            <div class="right" style="width: 259px; margin-left:0px;">
                <h1>
                    功能菜单
                 </h1>
                <ul style=" padding:10px"> 
                    <%=Voodoo.Basement.CreatePage.BuildUserMenuString()%>
                </ul>
            </div>
        </div>


<%= Voodoo.Basement.CreatePage.CreateFooterString() %>