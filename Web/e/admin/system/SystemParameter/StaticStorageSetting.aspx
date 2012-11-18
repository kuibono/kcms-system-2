<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaticStorageSetting.aspx.cs"
    Inherits="Web.e.admin.system.SystemParameter.StaticStorageSetting" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="vd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>基本参数</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
    <style type="text/css">
    input[type='text']
    {
        width:300px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="tip">
        ....</div>
    <table border="1" cellpadding="0" cellspacing="0" class="edit">
        <thead>
            <tr>
                <th colspan="2">
                    静态页面存储规则设置
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="100">
                    新闻列表
                </td>
                <td>
                    <vd:vtextbox id="txt_NewsClass" runat="server" enablevalidate="true" enablenull="false"></vd:vtextbox>{id} {classname}
                </td>
            </tr>
            <tr>
                <td>
                    新闻页面
                </td>
                <td>
                    <vd:vtextbox id="txt_NewsPage" runat="server" enablevalidate="true" enablenull="false"></vd:vtextbox>{id} {classid} {classname} {filefolder} {filename}
                </td>
            </tr>
            <tr>
                <td>
                    图片列表
                </td>
                <td>
                    <vd:vtextbox id="txt_ImageClass" runat="server" enablevalidate="true" enablenull="false"></vd:vtextbox>{id} {classname}
                </td>
            </tr>
            <tr>
                <td>
                    图片页面
                </td>
                <td>
                    <vd:vtextbox id="txt_ImagePage" runat="server" enablevalidate="true" enablenull="false"></vd:vtextbox>{id} {classid} {classname}
                </td>
            </tr>
            <tr>
                    <td>
                        问答列表
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_QuestionClass" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classname}
                    </td>
                </tr>
                <tr>
                    <td>
                        问题页面
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_QuestionPage" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classid} {classname} {title}
                    </td>
                </tr>
                <tr>
                    <td>
                        书籍列表
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_BookClass" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classname}
                    </td>
                </tr>
                <tr>
                    <td>
                        书籍信息
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_BookInfo" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classid} {classname} {title} {author}
                    </td>
                </tr>
                <tr>
                    <td>
                        书籍章节
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_BookChapter" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classid} {classname} {bookid} {booktitle} {author}
                    </td>
                </tr>
                <tr>
                    <td>
                        章节txt
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_BookChapterTxt" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classid} {classname} {bookid} {booktitle} {author}
                    </td>
                </tr>
                <tr>
                    <td>
                        人才列表
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_JobClass" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classname}
                    </td>
                </tr>
                <tr>
                    <td>
                        职位页面
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_JobPost" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {companyid} {title} 
                    </td>
                </tr>
                <tr>
                    <td>
                        公司
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_JobCompany" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id}  {companyname} 
                    </td>
                </tr>
                <tr>
                    <td>
                        电影列表
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_MovieClass" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classname}
                    </td>
                </tr>
                <tr>
                    <td>
                        电影信息
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_MovieInfo" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {classid} {classname} {title} {director} {location}
                    </td>
                </tr>
                <tr>
                    <td>
                        百度播放
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_MovieBaiduPlay" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {title} {movieid} {movietitle} {classid} {classname} {director} {location}
                    </td>
                </tr>
                <tr>
                    <td>
                        快播播放
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_MovieKuaibPlay" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {title} {movieid} {movietitle} {classid} {classname} {director} {location}
                    </td>
                </tr>
                <tr>
                    <td>
                        剧集列表
                    </td>
                    <td>
                        <vd:VTextBox ID="txt_MovieDramaPlay" runat="server" EnableValidate="true" EnableNull="false"></vd:VTextBox>{id} {title} {movieid} {movietitle} {classid} {classname} {director} {location}
                    </td>
                </tr>
        </tbody>
        <tfoot>
            <tr>
                <th colspan="2">
                    <asp:button id="btn_Save" text="保存" runat="server" onclick="btn_Save_Click" />
                    &nbsp;
                    <input type="button" value="取消" onclick="location.href='main.aspx'" />
                </th>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
