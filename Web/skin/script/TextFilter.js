String.prototype.replaceall = function (s1, s2) {
    return this.replace(new RegExp(s1, "gm"), s2);
}
var chars = [{ cn: "声音", py: "shengyin" },
{ cn: "地方", py: "difang" },
{ cn: "这个", py: "zhege" },
{ cn: "有些", py: "youxie" },
{ cn: "注意", py: "zhuyi" },
{ cn: "非常", py: "feichang" },
{ cn: "大家", py: "dajia" },
{ cn: "衣服", py: "yifu" },
{ cn: "自己", py: "ziji" },
{ cn: "来不及", py: "laibuji" },
{ cn: "意思", py: "yisi" },
{ cn: "能力", py: "nengli" },
{ cn: "容易", py: "rongyi" },
{ cn: "朋友", py: "pengyou" },
{ cn: "消息", py: "xiaoxi" },
{ cn: "这样", py: "zheyang" },
{ cn: "如此", py: "ruci" },
{ cn: "说话", py: "shuohua" },
{ cn: "：“", py: "maohaoyinhao" },
{ cn: "明天", py: "mingtian" },
{ cn: "你们", py: "nimen" },
{ cn: "没有", py: "meiyou" },
{ cn: "激动", py: "jidong" },
{ cn: "可以", py: "keyi" },
{ cn: "一起", py: "yiqi" },
{ cn: "小姐", py: "xiaojie" },
{ cn: "不但", py: "budan" },
{ cn: "而且", py: "erqie" },
{ cn: "其他", py: "qita" },
{ cn: "事情", py: "shiqing" },
{ cn: "一会", py: "yihui" },
{ cn: "一样", py: "yiyang" },
{ cn: "儿子", py: "erzi" },
{ cn: "应该", py: "yinggai" },
{ cn: "时候", py: "shihou" },
{ cn: "以前", py: "yiqian" },
{ cn: "不是", py: "bushi" },
{ cn: "什么", py: "shenme" },
{ cn: "怎么", py: "zenme" },
{ cn: "成功", py: "chenggong" },
{ cn: "如何", py: "ruhe" },
{ cn: "过去", py: "guoqu" },
{ cn: "出来", py: "chulai" }
];
$(function () {
    for (var i = 0; i < chars.length; i++) {
        document.body.innerHTML = document.body.innerHTML.replaceall(chars[i].py, chars[i].cn);
    }
})
