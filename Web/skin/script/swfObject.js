var PlaySwf = function (url, width, height) {
    document.writeln("<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" width=\"" + width + "\" height=\"" + height + "\" align=\"absmiddle\" id=\"FlashID\">");
    document.writeln("    <param name=\"movie\" value=\""+ url +"\" \/>");
    document.writeln("    <param name=\"quality\" value=\"high\" \/>");
    document.writeln("    <param name=\"wmode\" value=\"transparent\" \/>");
    document.writeln("    <param name=\"swfversion\" value=\"6.0.65.0\" \/>");
    document.writeln("    <param name=\"SCALE\" value=\"exactfit\" \/>");
    document.writeln("    <!-- 下一个对象标签用于非 IE 浏览器。所以使用 IECC 将其从 IE 隐藏。 -->");
    document.writeln("    <!--[if !IE]>-->");
    document.writeln("        <object data=\"" + url + "\" type=\"application\/x-shockwave-flash\"");
    document.writeln("        width=\"" + width + "\" height=\"" + height + "\" align=\"absmiddle\">");
    document.writeln("        <!--<![endif]-->");
    document.writeln("        <param name=\"quality\" value=\"high\" \/>");
    document.writeln("        <param name=\"wmode\" value=\"transparent\" \/>");
    document.writeln("        <param name=\"swfversion\" value=\"6.0.65.0\" \/>");
    document.writeln("        <param name=\"SCALE\" value=\"exactfit\" \/>");
    document.writeln("        <!-- 浏览器将以下替代内容显示给使用 Flash Player 6.0 和更低版本的用户。 -->");
    document.writeln("        <div>");
    document.writeln("            <h4>");
    document.writeln("                此页面上的内容需要较新版本的 Adobe Flash Player。");
    document.writeln("            <\/h4>");
    document.writeln("            <p>");
    document.writeln("                <a href=\"http:\/\/www.adobe.com\/go\/getflashplayer\">");
    document.writeln("                    <img src=\"http:\/\/www.adobe.com\/images\/shared\/download_buttons\/get_flash_player.gif\"");
    document.writeln("                    alt=\"获取 Adobe Flash Player\" width=\"" + width + "\" height=\"" + height + "\" \/>");
    document.writeln("                <\/a>");
    document.writeln("            <\/p>");
    document.writeln("        <\/div>");
    document.writeln("        <!--[if !IE]>-->");
    document.writeln("        <\/object>");
    document.writeln("    <!--<![endif]-->");
    document.writeln("<\/object>")
}