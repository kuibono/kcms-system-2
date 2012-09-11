<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookEdit.aspx.cs" Inherits="Web.e.admin.Book.BookEdit" ValidateRequest="false" %>
<%@ Import Namespace="Voodoo" %>
<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>章节编辑</title>
    <link rel="stylesheet" type="text/css" href="../../data/css/management.css" />
    <script type="text/javascript" src="../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../data/script/common.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tip">
           书籍内容的编辑和修改</div>
        <table border="1" cellpadding="0" cellspacing="0" class="edit">
            <thead>
                <tr>
                    <th colspan="2">
                        书籍编辑
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td width="163">
                        书籍名称
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Title" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        作者
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_Author" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        所属类别
                    </td>
                    <td>
                        
                        <asp:DropDownList ID="ddl_CLass" runat="server">
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        所属专题</td>
                    <td>
                        
                        <asp:DropDownList ID="ddl_Zt" runat="server">
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        状态</td>
                    <td>
                        
                        <asp:DropDownList ID="ddl_Status" runat="server">
                            <asp:ListItem Text="连载中" Value="0"></asp:ListItem>
                            <asp:ListItem Text="已完结" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        简介</td>
                    <td>
                        
                        <vd:VTextBox ID="txt_Intro" runat="server" Height="100px" TextMode="MultiLine"></vd:VTextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        人物</td>
                    <td>
                        
                        <vd:VTextBox ID="txt_BookRole" runat="server" Height="100px" TextMode="MultiLine"></vd:VTextBox>每行一个
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        字数</td>
                    <td>
                        
                        <vd:VTextBox ID="txt_Length" runat="server" EnableValidate="true" VType="integer">0</vd:VTextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        阅读数</td>
                    <td>
                        
                        <vd:VTextBox ID="txt_ClickCount" runat="server" EnableValidate="true" VType="integer">0</vd:VTextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        收藏数</td>
                    <td>
                        
                        <vd:VTextBox ID="txt_SaveCount" runat="server" EnableValidate="true" VType="integer">0</vd:VTextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        推荐数</td>
                    <td>
                        
                        <vd:VTextBox ID="txt_TjCount" runat="server" EnableValidate="true" VType="integer">0</vd:VTextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        Comment Count</td>
                    <td>
                        
                        <vd:VTextBox ID="txt_Replycount" runat="server" EnableValidate="true" VType="integer">0</vd:VTextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        是否VIP</td>
                    <td>
                        <asp:CheckBox ID="chk_IsVip" runat="server" Text="vip" />
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        是否审核</td>
                    <td>
                        <asp:CheckBox ID="chk_Enable" runat="server" Text="审核通过" />
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        Is First Post</td>
                    <td>
                        <asp:CheckBox ID="chk_IsFirstpost" runat="server" Text="First Post" />
                    </td>
                </tr>
                <tr>
                    <td width="163">
                        书籍封面</td>
                    <td>
                        <asp:FileUpload ID="file_Bookfacefile" runat="server" />
                        <br />
                        <asp:Image ID="img_Bookface" runat="server" />
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
