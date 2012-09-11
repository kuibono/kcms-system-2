<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Createpages.aspx.cs" Inherits="Web.e.admin.system.Update.Createpages" %>

<%@ Register Assembly="Voodoo" Namespace="Voodoo.UI" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据更新中心</title>
    <link rel="stylesheet" type="text/css" href="../../../data/css/management.css" />
    <script type="text/javascript" src="../../../data/script/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../../../data/script/common.js"></script>
    <script type="text/javascript">
        var createList = function () {
            $.ajax({
                url: "/e/tool/Create/CreatePage.aspx",
                data: { "a": "getmaxid", "table": "class" },
                dataType: "json",
                type: "POST",
                success: function (id) {
                    //getPageCount(1, id);
                    cList(0, id, 1, 0);
                }
            });
        }
        var getPageCount = function (id,maxid) {
            $.ajax({
                url: "/e/tool/Create/CreatePage.aspx",
                data: { "a": "getclasspagecount", "id": id },
                dataType: "text",
                type: "POST",
                success: function (count) {
                    cList(1, id, 1, count);
                }
            });
        }


        var cList = function (id, maxid, page, pagecount) {
            if (id <= maxid) {
                if (page <= pagecount) {

                    $.ajax({
                        url: "/e/tool/Create/CreatePage.aspx",
                        data: { "a": "createclasspage", "id": id, "page": page },
                        dataType: "text",
                        type: "POST",
                        success: function (msg) {
                            $("#status").text(msg);
                            cList(id, maxid, page + 1, pagecount);
                        }
                    });
                }
                else {
                    $.ajax({
                        url: "/e/tool/Create/CreatePage.aspx",
                        data: { "a": "getclasspagecount", "id": id+1 },
                        dataType: "text",
                        type: "POST",
                        success: function (count) {
                            cList(id + 1, maxid, 1, count);
                        }
                    });
                }
            }
            else {
                $("#status").text("列表页生成完成");
            }
        }
        var createContent = function () {
            $.ajax({
                url: "/e/tool/Create/CreatePage.aspx",
                data: { "a": "getmaxid", "table": "Book" },
                dataType: "text",
                type: "POST",
                success: function (id) {
                    cBookPage(1, id);
                }
            });
            $.ajax({
                url: "/e/tool/Create/CreatePage.aspx",
                data: { "a": "getmaxid", "table": "MovieInfo" },
                dataType: "text",
                type: "POST",
                success: function (id) {
                    cMoviePage(1, id);
                }
            });
        }
        var cBookPage = function (id, maxid) {
            if (id <= maxid) {
                $.ajax({
                    "url": "/e/tool/Create/CreatePage.aspx",
                    data: { "a": "createbook", "id": id },
                    dataType: "text",
                    type: "POST",
                    success: function (msg) {
                        $("#status").text(msg);
                        id++;
                        cBookPage(id, maxid);
                    },
                    error: function () {
                        id++;
                        cBookPage(id, maxid);
                    }
                });
            }
            else {
                $("#status").text("生成书籍页面完成")
            }
        }
        var cMoviePage = function (id, maxid) {
            if (id <= maxid) {
                $.ajax({
                    url: "/e/tool/Create/CreatePage.aspx",
                    data: { "a": "createmoviepage", "id": id },
                    dataType: "text",
                    type: "POST",
                    success: function (msg) {
                        $("#status").text(msg);
                        id++;
                        cMoviePage(id, maxid);
                    },
                    error: function () {
                        id++;
                        cMoviePage(id, maxid);
                    }
                });
            }
            else {
                $("#status").text("生成电影内容页面完成")
            }
        }
        var createChapter = function () {
            $.ajax({
                url: "/e/tool/Create/CreatePage.aspx",
                data: { "a": "getmaxid", "table": "BookChapter" },
                dataType: "text",
                type: "POST",
                success: function (id) {
                    cChapter(1, id);
                }
            });
        }
        var cChapter = function (id, maxid) {
            if (id <= maxid) {
                $.ajax({
                    url: "/e/tool/Create/CreatePage.aspx",
                    data: { "a": "createchapter", "id": id },
                    dataType: "text",
                    type: "POST",
                    success: function (msg) {
                        $("#status").text(msg);
                        id++;
                        cChapter(id, maxid);
                    }
                });
            }
            else {
                $("#status").text("所有章节完成");
            }
        }
        var createDrama = function () {
            $.ajax({
                url: "/e/tool/Create/CreatePage.aspx",
                data: { "a": "getmaxid", "table": "MovieDrama" },
                dataType: "text",
                type: "POST",
                success: function (id) {
                    cDrama(1, id, function () {
                        $.ajax({
                            url: "/e/tool/Create/CreatePage.aspx",
                            data: { "a": "getmaxid", "table": "MovieUrlKuaib" },
                            dataType: "text",
                            type: "POST",
                            success: function (kid) {
                                cKuaibo(1, kid, function () {
                                    $.ajax({
                                        url: "/e/tool/Create/CreatePage.aspx",
                                        data: { "a": "getmaxid", "table": "MovieUrlBaidu" },
                                        dataType: "text",
                                        type: "POST",
                                        success: function (bid) {
                                            cBaidu(1, bid);
                                        }
                                    });
                                });
                            }
                        })
                    });
                }
            });
        }
        var cDrama = function (id, maxid, callback) {
            if (id <= maxid) {
                $.ajax({
                    url: "/e/tool/Create/CreatePage.aspx",
                    data: { "a": "createdramapage", "id": id },
                    dataType: "text",
                    type: "POST",
                    success: function (msg) {
                        $("#status").text(msg);
                        id++;
                        cDrama(id, maxid);
                    }
                });
            }
            else {
                $("#status").text("生成搜索剧集完成");
                callback();
            }
        }
        var cKuaibo = function (id, maxid, callback) {
            if (id <= maxid) {
                $.ajax({
                    url: "/e/tool/Create/CreatePage.aspx",
                    data: { "a": "createkuaibopage", "id": id },
                    dataType: "text",
                    type: "POST",
                    success: function (msg) {
                        $("#status").text(msg);
                        id++;
                        cKuaibo(id, maxid);
                    }
                });
            }
            else {
                $("#status").text("生成快播剧集完成");
                callback();
            }
        }
        var cBaidu = function (id, maxid) {
            if (id <= maxid) {
                $.ajax({
                    url: "/e/tool/Create/CreatePage.aspx",
                    data: { "a": "createbaidupage", "id": id },
                    dataType: "text",
                    type: "POST",
                    success: function (msg) {
                        $("#status").text(msg);
                        id++;
                        cBaidu(id, maxid);
                    }
                });
            }
            else {
                $("#status").text("生成百度影音剧集完成");
            }
        }


        $(function () {
//            $("#btn_List").click(function () {
//                createList();
//                return false;
//            });

            $("#btn_Content").click(function () {
                createContent();
                return false;
            });

            $("#btn_Chapter").click(function () {
                createChapter();
                return false;
            });

            $("#btn_Drama").click(function () {
                createDrama();
                return false;
            });
        })
    </script>
    <style type="text/css">
        td
        {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="1" cellpadding="0" cellspacing="1" class="list">
        <tbody>
            <tr>
                <td>
                    状态：<label id="status">就绪</label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_Index" runat="server" Text="生成首页" OnClick="btn_Index_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_List" runat="server" Text="生成列表页" OnClick="btn_List_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_Content" runat="server" Text="生成内容页" OnClick="btn_Content_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_Chapter" runat="server" Text="生成章节" OnClick="btn_Chapter_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_Drama" runat="server" Text="生成播放页面" OnClick="btn_Drama_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_ClearAll" runat="server" Text="清理所有静态页面" OnClick="btn_ClearAll_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_GenSitreMap" runat="server" Text="生成SiteMap" OnClick="btn_GenSitreMap_Click" />
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Button ID="btn_CreatePage" runat="server" Text="生成静态页面" OnClick="btn_CreatePage_Click"  />
                </td>
            </tr>
             <tr>
                <td>
                    <asp:TextBox ID="txt_OldFolder" runat="server"></asp:TextBox>
                    =&gt;<asp:TextBox ID="txt_NewFolder" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_Move" runat="server" onclick="btn_Move_Click" Text="复制" />
                </td>
            </tr>
            <tr>
                <td>
                    <cc1:vtextbox id="txt_SQL" runat="server" textmode="MultiLine" width="300px"></cc1:vtextbox>
                    <asp:Button ID="btn_Excute" runat="server" OnClick="btn_Excute_Click" Text="Excute" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
