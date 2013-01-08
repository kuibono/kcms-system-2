$(function () {
    $("#showSlider").click(showSlider);
    $("#goToTop").click(function () {
        window.scrollTo(0, 0);
    });
    $(window).scroll(closeSlider);

    $(".tPanel .tHeader .tTitle").each(function (i) {
        $(this).click(function () {
            $(".tPanel .tHeader .tTitle").removeClass("cur");
            $(this).addClass("cur");

            $(this).parents(".tPanel").find(".tBody div").hide();
            $(this).parents(".tPanel").find(".tBody div").eq(i).show();
        })

    })
    $(".short-btn").click(function () {
        if ($(this).hasClass("up")) {
            $(this).removeClass("up");
            $(this).parents(".block").find(".body").removeClass("up");
        } else {
            $(this).addClass("up");
            $(this).parents(".block").find(".body").addClass("up");
        }
    })
    $(".back-btn").click(function () {
        history.go(-1);
    });
    //    addReadHistory(1, "按时打算", 100, "第两千八百章");
    //    addReadHistory(2, "打发斯蒂芬飞", 100, "第二十章");
    //    addReadHistory(3, "更符合风光好发光", 100, "第一章");
    //    addReadHistory(4, "味儿萨芬撒地方", 100, "第九百章");
    //    addReadHistory(5, "通话费得更好地方滚动", 100, "第一万两千章");
    $("#history").html(getReadHistory());
})

function closeSlider() {
    if ($("#sidebar:visible").size() > 0) {
        $("#sidebar").hide("fast");
        $("#page").animate({
            //width: $(document).width()
            left:'0'
        }, "fast");
    }
}

function addReadHistory(bookid,booktitle,chapterid,chaptertitle) {
    var storage = window.localStorage;
    var j = [];
    if (storage.a) {
        j = eval(storage.a);
    }
    var item = { "bookid": bookid,
        "booktitle": booktitle,
        "chapterid": chapterid,
        "chaptertitle": chaptertitle,
        "tm":new Date()
    };
    var index = -1;
    for (var i = 0; i < j.length; i++) {
        if (j[i].bookid == item.bookid) {
            index = i;
        }
    }
    if (index > -1) {
        j.splice(index, 1);
    }
    j.push(item);

    storage.a = JSON.stringify(j);
}
function getReadHistory() {
    var storage = window.localStorage;
    var j = [];
    if (storage.a) {
        j = eval(storage.a);
    }
    var html = "";
    for (var i = 0; i < j.length; i++) {
        html += "<li><a href=\"b.aspx?id="+j[i].bookid+"\">"+j[i].booktitle+"</a> (<span class=\"red\"><a href=\"#\">5章未读</a></span>) </li>";
    }
    if (html.length == 0) {
        html = "还没有阅读任何书籍";
    }
    return html;
}

function showSlider() {
    if ($("#sidebar:visible").size() > 0) {
        $("#sidebar").hide("fast");
        $("#page").animate({
            //width: $(document).width()
            left:'0'
        }, "fast");
    }
    else {
        $("#page").animate({
            //width: $("#page").width() - 240
            left: '-240px'
        }, "fast");
        $("#sidebar").show("fast");
    }
}