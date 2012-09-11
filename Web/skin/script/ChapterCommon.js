$(function () {
    $(document).bind('keydown', 'left', function (evt) {
        if ($('#btn_pre').size() == 0) {
            return false;
        }
        try {
            if ($('#btn_pre').attr("href") != '#') {
                location.href = $('#btn_pre').attr("href");
            }
        } catch (e) {
            alert("已经是第一章了");
        }
        return false;
    });
    $(document).bind('keydown', 'right', function (evt) {
        if ($('#btn_next').size() == 0) {
            return false;
        }
        try {
            if ($('#btn_next').attr("href") != '#') {
                location.href = $('#btn_next').attr("href");
            }
        } catch (e) {
            location.href = $('#btn_list').attr("href");
        }
        return false;
    });
    $(document).bind('keydown', 'return', function (evt) { location.href = $('#btn_list').attr("href"); return false; });
})