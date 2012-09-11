var tj = function (id) {
    $.getJSON("/e/tool/BookOperate.aspx?action=tj&jsonpostback=?&id=" + id, function (json) {
        $("#tjcount").text(json.data);
        $.messager.show("感谢您的支持", "您已经推荐本书，目前该书推荐票数为：" + json.data, 2000);
        return false;
    })
}