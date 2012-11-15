$(function () {
    $(".textbox").focus(function () {
        $(this).parent().find(".placeholder").hide();
    }).blur(function () {
        if ($(this).val().length == 0) {
            $(this).parent().find(".placeholder").show();
        }
    });
    setTimeout(function () {
        $(".textbox").each(function () {
            if ($(this).val().length > 0) {
                $(this).parent().find(".placeholder").hide();
            }
        });
    }, 500);


    //pre load a shadow div and a loaing img div at the top of the BODY of document
    $(document.body).prepend('<div class="shadow"></div> <div class="cover"><p id="loading_msg">Loading...</p><p>&nbsp;</p><img src="/e/data/images/ajax-loader.gif" /></div>');
})
function loading(msg) {
    if (msg) {
        $("#loading_msg").text(msg);
    }
    $(".shadow").show();
    $(".cover").show();
}
function endloading() {
    $(".shadow").hide();
    $(".cover").hide();
}