using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;

namespace Voodoo.Basement
{
    public class JobAction
    {
        #region 系统省市
        /// <summary>
        /// 市
        /// </summary>
        private static List<City> Cities
        {
            get
            {
                using (DataEntities ent = new DataEntities())
                {
                    return (from l in ent.City select l).AsCache();
                }
            }
        }

        /// <summary>
        /// 省
        /// </summary>
        private static List<Province> Provinces
        {
            get
            {
                using (DataEntities ent = new DataEntities())
                {
                    return (from l in ent.Province select l).AsCache();
                }
            }
        }

        public static string GetProviceName(int id)
        {
            try
            {
                return (from l in Provinces where l.ID == id select l).FirstOrDefault().province1;
            }
            catch
            {
                return "未设置";
            }
        }
        public static string GetCityName(int id)
        {
            try
            {
                return (from l in Cities where l.id == id select l).FirstOrDefault().city1;
            }
            catch
            {
                return "未设置";
            }
        }
        #endregion

        #region 增加省市热度
        /// <summary>
        /// 增加省市热度
        /// </summary>
        /// <param name="id"></param>
        public static void AddCityHot(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                var ct = (from l in ent.City where l.id == id select l).FirstOrDefault();
                ct.Hot += 1;
                ent.SaveChanges();
            }
        }
        #endregion


        #region 公司性质
        /// <summary>
        /// 公司性质
        /// </summary>
        public static Dictionary<int, string> CompanyType
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "其他");
                result.Add(1, "国企");
                result.Add(2, "民企");
                result.Add(3, "外资");
                result.Add(4, "合资");
                result.Add(5, "政府部门");
                result.Add(6, "事业单位");
                return result;
            }
        }

        public static string GetCompanyTypeName(int key)
        {
            return CompanyType[key];
        }
        #endregion

        #region 公司规模
        /// <summary>
        /// 公司规模
        /// </summary>
        public static Dictionary<int, string> EmployeeCount
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "50以下");
                result.Add(1, "50-150");
                result.Add(2, "150-500");
                result.Add(3, "500-2000");
                result.Add(4, "2000以上");
                return result;
            }
        }

        public static string GetEmployeeCountName(int key)
        {
            return EmployeeCount[key];
        }
        #endregion

        #region 工资级别
        /// <summary>
        /// 工资级别
        /// </summary>
        public static Dictionary<int, string> SalaryDegree
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "面议");
                result.Add(1, "1000元以下");
                result.Add(2, "1000-2000元");
                result.Add(3, "2001-4000元");
                result.Add(4, "4001-6000元");
                result.Add(5, "6001-8000元");
                result.Add(6, "8001-10000元");
                result.Add(7, "10001-15000元");
                result.Add(8, "150001-25001元");
                result.Add(9, "25000元以上");
                return result;
            }
        }

        public static string GetSalaryDegreeName(int key)
        {
            return SalaryDegree[key];
        }
        #endregion

        #region 经验要求
        /// <summary>
        /// 经验要求
        /// </summary>
        public static Dictionary<int, string> Expressions
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "应届");
                result.Add(1, "实习");
                return result;
            }
        }

        public static string GetExpressionsName(int key)
        {
            try
            {
                return Expressions[key];
            }
            catch
            {
                return "应届";
            }
        }
        #endregion

        #region  学历
        /// <summary>
        /// 学历
        /// </summary>
        public static Dictionary<int, string> Edu
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "初中");
                result.Add(1, "高中");
                result.Add(2, "中专");
                result.Add(3, "大专");
                result.Add(4, "本科");
                result.Add(5, "硕士");
                result.Add(6, "博士");
                result.Add(7, "其他");
                return result;
            }
        }

        public static string GetEduName(int key)
        {
            return Edu[key];
        }
        #endregion

        #region 证件类型
        /// <summary>
        /// 证件类型
        /// </summary>
        public static Dictionary<int, string> CardType
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "身份证");
                result.Add(1, "护照");
                result.Add(2, "军官证");
                result.Add(3, "香港身份证");
                result.Add(4, "澳门身份证");
                result.Add(5, "台胞证");
                result.Add(6, "其他");
                return result;
            }
        }
        public static string GetCardTypeName(int key)
        {
            return CardType[key];
        }
        #endregion

        #region 婚姻状况
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public static Dictionary<int, string> Marrage
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "保密");
                result.Add(1, "未婚");
                result.Add(2, "已婚");
                return result;
            }
        }
        public static string GetMarrageName(int key)
        {
            return Marrage[key];
        }
        #endregion

        #region 民族
        /// <summary>
        /// 民族
        /// </summary>
        public static Dictionary<int, string> Nation
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "其他");
                result.Add(1, "汉族");
                result.Add(2, "壮族");
                result.Add(3, "满族");
                result.Add(4, "回族");
                result.Add(5, "苗族");
                result.Add(6, "维吾尔族");
                result.Add(7, "土家族");
                result.Add(8, "彝族");
                result.Add(9, "蒙古族");
                result.Add(10, "藏族");
                result.Add(11, "布依族");
                result.Add(12, "侗族");
                result.Add(13, "瑶族");
                result.Add(14, "朝鲜族");
                result.Add(15, "白族");
                result.Add(16, "哈尼族");
                result.Add(17, "哈萨克族");
                result.Add(18, "黎族");
                result.Add(19, "傣族");
                result.Add(20, "畲族");
                result.Add(21, "傈僳族");
                result.Add(22, "仡佬族");
                result.Add(23, "东乡族");
                result.Add(24, "拉祜族");
                result.Add(25, "水族");
                result.Add(26, "佤族");
                result.Add(27, "纳西族");
                result.Add(28, "羌族");
                result.Add(29, "土族");
                result.Add(30, "仫佬族");
                result.Add(31, "锡伯族");
                result.Add(32, "柯尔克孜族");
                result.Add(33, "达斡尔族");
                result.Add(34, "景颇族");
                result.Add(35, "毛南族");
                result.Add(36, "撒拉族");
                result.Add(37, "布朗族");
                result.Add(38, "塔吉克族");
                result.Add(39, "阿昌族");
                result.Add(40, "普米族");
                result.Add(41, "鄂温克族");
                result.Add(42, "怒族");
                result.Add(43, "京族");
                result.Add(44, "基诺族");
                result.Add(45, "德昂族");
                result.Add(46, "保安族");
                result.Add(47, "俄罗斯族");
                result.Add(48, "裕固族");
                result.Add(49, "乌孜别克族");
                result.Add(50, "门巴族");
                result.Add(51, "鄂伦春族");
                result.Add(52, "独龙族");
                result.Add(53, "塔塔尔族");
                result.Add(54, "赫哲族");
                result.Add(55, "高山族");
                result.Add(56, "珞巴族");

                return result;
            }
        }
        public static string GetNationName(int key)
        {
            return Nation[key];
        }
        #endregion

        #region 政治面貌
        /// <summary>
        /// 政治面貌
        /// </summary>
        public static Dictionary<int, string> Political
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "其他");
                result.Add(1, "中共党员");
                result.Add(2, "团员");
                result.Add(3, "群众");
                result.Add(4, "民主党派");
                result.Add(5, "无党派人士");

                return result;
            }
        }
        public static string GetPoliticalName(int key)
        {
            return Political[key];
        }
        #endregion

        #region 外语语种
        /// <summary>
        /// 外语语种
        /// </summary>
        public static Dictionary<int, string> Languages
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "其他");
                result.Add(1, "英语");
                result.Add(2, "日语");
                result.Add(3, "法语");
                result.Add(4, "德语");
                result.Add(5, "俄语");
                result.Add(6, "韩语");
                result.Add(7, "西班牙语");
                result.Add(8, "葡萄牙语");
                result.Add(9, "阿拉伯语");
                result.Add(10, "意大利语");


                return result;
            }
        }
        public static string GetLanguageName(int key)
        {
            return Languages[key];
        }
        #endregion

        #region 语言能力
        /// <summary>
        /// 语言能力
        /// </summary>
        public static Dictionary<int, string> LanguageDegree
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "一般");
                result.Add(1, "良好");
                result.Add(2, "精通");

                return result;
            }
        }
        public static string GetLanguageDegreeName(int key)
        {
            return LanguageDegree[key];
        }
        #endregion

        #region 更新时间范围
        /// <summary>
        /// 更新时间范围
        /// </summary>
        public static Dictionary<int, string> UpdateTime
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                result.Add(0, "今天");
                result.Add(1, "三天内");
                result.Add(2, "一周内");
                result.Add(3, "一月内");
                return result;
            }
        }
        public static string GetUpdateTimeName(int key)
        {
            return UpdateTime[key];
        }
        #endregion

        #region 绑定城市
        /// <summary>
        /// 绑定城市
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="pid"></param>
        public static void BindCity(System.Web.UI.WebControls.ListControl lst, int pid)
        {
            using (DataEntities ent = new DataEntities())
            {

                var cts = (from l in ent.City where l.ProvinceID == pid select l).ToList();
                lst.Items.Clear();
                foreach (var ct in cts)
                {
                    lst.Items.Add(new System.Web.UI.WebControls.ListItem(ct.city1, ct.id.ToS()));
                }
            }
        }
        #endregion

        #region 绑定行业下拉列表
        /// <summary>
        /// 绑定行业下拉列表
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindIndustry(System.Web.UI.WebControls.DropDownList ddl)
        {
            DataEntities ent = new DataEntities();
            List<JobIndustry> lst = (from l in ent.JobIndustry select l).ToList();
            ddl.Items.Add("");
            AddSubItem(ddl, lst, 0, 0);
            ent.Dispose();
        }

        private static void AddSubItem(System.Web.UI.WebControls.DropDownList ddl, List<JobIndustry> lst, int ParentID, int deep)
        {
            string preChars = "";
            for (int i = 0; i < deep; i++)
            {
                preChars += "----";
            }
            var qs = from l in lst where l.ParentID == ParentID select l;
            foreach (var q in qs)
            {
                var item = new System.Web.UI.WebControls.ListItem(preChars + q.Name, q.ID.ToS());
                if (deep == 2)
                {
                    item.Attributes.Add("class", "mouseover");
                }
                else
                {
                    item.Attributes.Add("class", "disabled");
                }
                ddl.Items.Add(item);
                AddSubItem(ddl, lst, q.ID, deep + 1);
            }
        }
        #endregion

        #region 绑定教育专业下拉列表
        /// <summary>
        /// 绑定教育专业
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindEduSpecialty(System.Web.UI.WebControls.DropDownList ddl)
        {
            DataEntities ent = new DataEntities();
            List<JobEduSpecialty> lst = (from l in ent.JobEduSpecialty select l).ToList();
            ddl.Items.Add("");
            AddSubItem(ddl, lst, 0, 0);
            ent.Dispose();
        }

        private static void AddSubItem(System.Web.UI.WebControls.DropDownList ddl, List<JobEduSpecialty> lst, long ParentID, int deep)
        {
            string preChars = "";
            for (int i = 0; i < deep; i++)
            {
                preChars += "----";
            }
            var qs = from l in lst where l.ParentID == ParentID select l;
            foreach (var q in qs)
            {
                var item = new System.Web.UI.WebControls.ListItem(preChars + q.Name, q.ID.ToS());
                if (deep == 2)
                {
                    item.Attributes.Add("class", "mouseover");
                }
                else
                {
                    item.Attributes.Add("class", "disabled");
                }
                ddl.Items.Add(item);
                AddSubItem(ddl, lst, q.ID, deep + 1);
            }
        }
        #endregion

        #region 获取行业名称
        /// <summary>
        /// 获取行业名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetIndustryName(int id)
        {
            using (DataEntities ent = new DataEntities())
            {
                var q = (from l in ent.JobIndustry where l.ID == id select l).FirstOrDefault();
                if (q != null)
                {
                    return q.Name;
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion

        #region 根据名称获取专业
        /// <summary>
        /// 根据名称获取专业
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static long GetEduSpecialtyByName(string name)
        {
            using (DataEntities ent = new DataEntities())
            {
                var q = from l in ent.JobEduSpecialty where l.Name == name select l;
                if (q.Count() > 0)
                {
                    return q.First().ID;
                }
                else
                {
                    JobEduSpecialty j = new JobEduSpecialty();
                    j.Name = name;
                    j.ParentID = 0;
                    ent.AddToJobEduSpecialty(j);
                    ent.SaveChanges();
                    return j.ID;
                }
            }
        }
        #endregion

        #region Html
        public static string TopHtml
        {
            get
            {
                TemplateHelper h = new TemplateHelper();
                return h.GetPublicTemplate("top");
            }
        }

        public static string BottomHtml
        {
            get
            {
                TemplateHelper h = new TemplateHelper();
                return h.GetPublicTemplate("indexbottom");
            }
        }
        #endregion

        #region 上传简历
        /// <summary>
        /// 上传简历
        /// </summary>
        /// <param name="file">简历文件</param>
        /// <param name="id">用户id，不输入的话则自动创建新用户</param>
        public static void SaveResume(HttpPostedFile file, int id = 0)
        {
            DataEntities ent = new DataEntities();

            string extName = Path.GetExtension(file.FileName).ToLower();
            string fileName = string.Format("/u/Resume/{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), extName);
            BasePage.UpLoadFile(file, fileName);
            Aspose.Words.Document doc = new Aspose.Words.Document(System.Web.HttpContext.Current.Server.MapPath(fileName));
            string Context = doc.GetText();

            User u = new User();
            if (id <= 0)
            {
                u.UserName = @int.GetRandomNumber(1000, 999999).ToS();
                u.UserPass = Voodoo.Security.Encrypt.Md5("1");
                u.RegTime = DateTime.Now;
                u.RegIP = WS.GetIP();
                u.LoginCount = 0;
                u.LastLoginTime = DateTime.Now;
                u.LastLoginIP = WS.GetIP();
                u.Cent = 0;
                u.Enable = true;
                u.Group = 1;

                ent.AddToUser(u);
                ent.SaveChanges();
            }
            else
            {
                u = (from l in ent.User where l.ID == id select l).First();
            }

            JobResumeInfo r = new JobResumeInfo();

            var userResume = from l in ent.JobResumeInfo where l.UserID == u.ID select l;
            if (userResume.Count() > 0)
            {
                r = userResume.First();
            }
            else
            {
                r.UserID = u.ID;
                r.Title = string.Format("{0}的临时简历", u.UserName);
                ent.AddToJobResumeInfo(r);
                ent.SaveChanges();

            }



            #region 文件处理

            var files = from l in ent.JobResumeFile where l.UserID == u.ID select l;
            var resumeFile = new JobResumeFile();
            if (files.Count() == 0)
            {
                resumeFile.UserID = u.ID;
                resumeFile.ResumeID = r.ID;
                resumeFile.FilePath = fileName;
                resumeFile.FileName = Path.GetFileName(file.FileName);

                ent.AddToJobResumeFile(resumeFile);

            }
            else
            {
                resumeFile = files.First();
                resumeFile.FilePath = fileName;
                resumeFile.FileName = file.FileName;
            }
            ent.SaveChanges();

            Match match = new Regex("男|女").Match(Context);
            string str_r = "";
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                if (str_r == "男")
                {
                    r.IsMale = true;
                }
                else
                {
                    r.IsMale = false;
                }
            }
            match = new Regex("[a-zA-Z\\._]*?@.*?\\.(com|net|org|cn|edu|gov)").Match(Context);
            if (match.Success)
            {
                if (id <= 0)
                {
                    u.Email = match.Groups[0].Value;
                }
                r.Email = match.Groups[0].Value;
            }
            match = new Regex("姓名.{1,3}[^ ;,\\r]*").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                str_r = str_r.Replace("姓名", "").Replace("：", "");
                r.ChineseName = str_r;
                if (id <= 0)
                {
                    u.ChineseName = str_r;
                    u.UserName = str_r;
                }
            }
            else
            {
                r.ChineseName = u.UserName;
            }

            match = new Regex("江苏|安徽|福建|上海|浙江|河南|湖北|江西|山东|河北|山西|北京|天津|吉林|黑龙江|内蒙古|辽宁|湖南|青海|宁夏|陕西|甘肃|澳門|台湾|新疆|香港|海南|重庆|广东|广西|云南|西藏|四川|贵州").Match(Context);
            if (match.Success)
            {
                try
                {
                    r.Province = (from l in ent.Province select l).AsCache().Where(p => p.province1.Contains(match.Groups[0].Value)).First().ID;
                }
                catch
                {
                    r.Province = (from l in ent.Province select l).AsCache().First().ID;
                }
            }
            else
            {
                r.Province = (from l in ent.Province select l).AsCache().First().ID;
            }

            match = new Regex("南京|苏州|无锡|常州|宿迁|淮安|徐州|连云港|盐城|南通|镇江|扬州|泰州|北京|天津|邯郸|邢台|秦皇岛|石家庄|唐山|保定|廊坊|衡水|沧州|张家口|承德|长治|晋城|阳泉|太原|大同|朔州|临汾|吕梁|忻州|晋中|运城|赤峰|通辽|鄂尔多斯|呼和浩特|包头|乌海|锡林郭勒|兴安|阿拉善|呼伦贝尔|巴彦淖尔|乌兰察布|本溪|丹东|锦州|抚顺|沈阳|大连|鞍山|铁岭|朝阳|葫芦岛|盘锦|营口|阜新|辽阳|四平|辽源|长春|吉林|通化|白城|延边|白山|松原|牡丹江|佳木斯|鸡西|哈尔滨|大庆|齐齐哈尔|双鸭山|黑河|绥化|大兴安岭|伊春|七台河|鹤岗|上海|绍兴|湖州|温州|杭州|宁波|嘉兴|丽水|舟山|台州|金华|衢州|淮北|马鞍山|安庆|铜陵|芜湖|合肥|淮南|蚌埠|亳州|六安|宣城|池州|滁州|黄山|宿州|阜阳|莆田|三明|福州|南平|泉州|龙岩|宁德|厦门|漳州|九江|新余|萍乡|南昌|景德镇|鹰潭|抚州|上饶|宜春|赣州|吉安|烟台|东营|济宁|潍坊|青岛|济南|枣庄|淄博|泰安|聊城|德州|菏泽|滨州|日照|威海|临沂|莱芜|新乡|鹤壁|濮阳|焦作|安阳|开封|郑州|平顶山|洛阳|周口|信阳|济源|驻马店|商丘|漯河|许昌|南阳|三门峡|襄阳|宜昌|荆门|鄂州|黄石|武汉|荆州|十堰|孝感|天门|仙桃|神农架|潜江|咸宁|黄冈|恩施|随州|江门|佛山|湛江|肇庆|茂名|深圳|广州|珠海|韶关|汕头|惠州|中山|东莞|潮州|云浮|揭阳|汕尾|梅州|河源|清远|阳江|北海|防城港|钦州|梧州|南宁|柳州|桂林|河池|来宾|崇左|贺州|贵港|玉林|百色|邵阳|岳阳|常德|衡阳|长沙|株洲|湘潭|怀化|娄底|湘西|永州|张家界|益阳|郴州|海口|三亚|三沙|重庆|广元|绵阳|遂宁|乐山|内江|自贡|成都|攀枝花|德阳|泸州|南充|资阳|巴中|阿坝|凉山|甘孜|宜宾|眉山|广安|雅安|达州|遵义|安顺|贵阳|六盘水|铜仁|黔东南|黔南|毕节|黔西南|丽江|昭通|临沧|普洱|曲靖|昆明|保山|玉溪|红河|楚雄|西双版纳|文山|怒江|德宏|大理|迪庆|林芝|昌都|拉萨|山南|阿里|那曲|日喀则|咸阳|渭南|宝鸡|西安|铜川|安康|商洛|榆林|延安|汉中|天水|武威|酒泉|白银|兰州|嘉峪关|金昌|陇南|临夏|甘南|定西|张掖|庆阳|平凉|海北|海南|西宁|海东|玉树|海西|黄南|果洛|石嘴山|银川|吴忠|中卫|固原|博尔塔拉|伊犁哈萨克|阿克苏|巴音郭楞|昌吉回族|克拉玛依|乌鲁木齐|哈密|吐鲁番|图木舒克|阿拉尔|北屯|五家渠|石河子|喀什|克孜勒苏柯尔克孜|和田|香港|澳門|新竹縣|桃園縣|苗栗縣|南投縣|彰化縣|宜蘭縣|新北|臺北|臺中|高雄|臺南|新竹|基隆|嘉義|連江縣|金門縣|澎湖縣|嘉義縣|雲林縣|屏東縣|花蓮縣|臺東縣").Match(Context);
            if (match.Success)
            {
                try
                {
                    r.City = (from l in ent.City select l).AsCache().Where(p => p.city1.Contains(match.Groups[0].Value) && p.ProvinceID == r.Province).First().id;
                }
                catch
                {
                    r.City = (from l in ent.City select l).AsCache().First().id;
                }
            }
            else
            {
                r.City = (from l in ent.City select l).AsCache().First().id;
            }


            JobResumeEdu edu = new JobResumeEdu();
            var resumeEdu = from l in ent.JobResumeEdu where l.ResumeID == r.ID select l;
            if (resumeEdu.Count() > 0)
            {
                edu = resumeEdu.First();
            }
            else
            {
                edu.ResumeID = r.ID;
                edu.StartTime = DateTime.Now.AddYears(-1);
                edu.LeftTime = DateTime.Now;
                ent.AddToJobResumeEdu(edu);
            }



            match = new Regex("[^ ：:]{2,20}?(大学|学院|学校|技校|中学|中专)").Match(Context);
            if (match.Success)
            {
                edu.SchoolName = match.Groups[0].Value;
                //大学
            }



            match = new Regex("哲学|逻辑学|宗教学|伦理学|经济学类|经济学|国际经济与贸易|财政学|金融学|国民经济管理|贸易经济|保险|金融工程|税务|信用管理|网络经济学|体育经济|投资学|环境资源与发展经济学|海洋经济学|法学|知识产权|监狱学|马克思主义理论类|科学社会主义与国际共产主义运动|中国革命史与中国共产党党史|社会学类|社会学|社会工作|家政学|人类学|政治学类|政治学与行政学|国际政治|外交学|思想政治教育|国际政治经济学|国际事务|公安学类|治安学|侦察学|边防管理|火灾勘测|禁毒学|警犬技术|经济犯罪侦察|边防指挥|消防指挥|警卫学|教育学类|教育学|学前教育|特殊教育|教育技术学|小学教育|艺术教育|人文教育|科学教育|言语听觉科学|体育学类|体育教育|运动训练|社会体育|运动人体科学|民族传统体育|职业技术教育类|农艺教育|园艺教育|特用作物教育|林木生产教育|特用动物教育|畜禽生产教育|水产养殖教育|应用生物教育|农业机械教育|农业建筑与环境控制教育|农产品储运与加工教育|农业经营管理教育|机械制造工艺教育|机械维修及检测技术教育|机电技术教育|电气技术教育|汽车维修工程教育|应用电子技术教育|制浆造纸工艺教育|印刷工艺教育|橡塑制品成型工艺教育|食品工艺教育|纺织工艺教育|染整工艺教育|化工工艺教育|化工分析与检测技术教育|建筑材料工程教育|建筑工程教育|服装设计与工艺教育|装潢设计与工艺教育|旅游管理与服务教育|食品营养与检验教育|烹饪与营养教育|财务会计教育|文秘教育|市场营销教育|职业技术教育管理|中国语言文学类|汉语言文学|汉语言|对外汉语|中国少数民族语言文学|古典文献|中国语言文化|应用语言学|外国语言文学类|英语|俄语|德语|法语|西班牙语|阿拉伯语|日语|波斯语|朝鲜语|菲律宾语|梵语巴利语|印度尼西亚语|印地语|柬埔寨语|老挝语|缅甸语|马来语|蒙古语|僧加罗语|泰语|乌尔都语|希伯莱语|越南语|豪萨语|斯瓦希里语|阿尔巴尼亚语|保加利亚语|波兰语|捷克语|罗马尼亚语|葡萄牙语|瑞典语|塞尔维亚——克罗地亚语|土耳其语|希腊语|匈牙利语|意大利语|捷克语——斯洛伐克语|泰米尔语|普什图语|世界语|孟加拉语|尼泊尔语|塞尔维亚语——克罗地亚语|荷兰语|芬兰语|乌克兰语|韩国语|新闻传播学类|新闻学|广播电视新闻学|广告学|编辑出版学|传播学|媒体创意|艺术类|音乐学|作曲与作曲技术理论|音乐表演|绘画|雕塑|美术学|艺术设计学|艺术设计|舞蹈学|舞蹈编导|戏剧学|表演|导演|戏剧影视文学|戏剧影视美术设计|摄影|录音艺术|动画|播音与主持艺术|广播电视编导|影视教育|艺术学|影视学|广播影视编导|历史学类|历史学|世界历史|考古学|博物馆学|民族学|文物保护技术|数学类|数学与应用数学|信息与计算科学|数理基础科学|物理学类|物理学|应用物理学|声学|化学类|化学|应用化学|化学生物学|分子科学与工程|生物科学类|生物科学|生物技术|生物信息学|生物信息技术|生物科学与生物技术|动植物检疫|生物化学与分子生物学|医学信息学|植物生物技术|动物生物技术|生物资源科学|天文学类|天文学|地质学类|地质学|地球化学|地理科学类|地理科学|资源环境与城乡规划管理|地理信息系统|地理信息科学与技术|地球物理学类|地球物理学|地球与空间科学|空间科学与技术|大气科学类|大气科学|应用气象学|海洋科学类|海洋科学|海洋技术|海洋管理|军事海洋学|海洋生物资源与环境|力学类|理论与应用力学|电子信息科学类|电子信息科学与技术|微电子学|光信息科学与技术|科技防卫|信息安全|信息科学技术|光电子技术科学|材料科学类|材料物理|材料化学|环境科学类|环境科学|生态学|资源环境科学|心理学类|心理学|应用心理学|统计学类|统计学|系统科学类|系统理论|系统科学与工程|地矿类|采矿工程|石油工程|矿物加工工程|勘查技术与工程|资源勘查工程|地质工程|矿物资源工程|材料类|冶金工程|金属材料工程|无机非金属材料工程|高分子材料与工程|材料科学与工程|复合材料与工程|焊接技术与工程|宝石与材料工艺学|粉体材料科学与工程|再生资源科学与技术|稀土工程|高分子材料加工工程|生物功能材料|机械类|机械设计制造及其自动化|材料成型及控制工程|工业设计|过程装备与控制工程|机械工程及自动化|车辆工程|机械电子工程|汽车服务工程|制造自动化与测控技术|微机电系统工程|制造工程|仪器仪表类|测控技术与仪器|电子信息技术及仪器|能源动力类|热能与动力工程|核工程与核技术|工程物理|能源环境工程及自动化|能源工程及自动化|能源动力系统及自动化|电气信息类|电气工程及其自动化|自动化|电子信息工程|通信工程|计算机科学与技术|电子科学与技术|生物医学工程|电气工程与自动化|信息工程|光源与照明|软件工程|影视艺术技术|网络工程|信息显示与光电技术|集成电路设计与集成系统|光电信息工程|广播电视工程|电气信息工程|计算机软件|电力工程与管理|微电子制造工程|假肢矫形工程|数字媒体艺术|医学信息工程|信息物理工程|医疗器械工程|智能科学与技术|数字媒体技术|土建类|建筑学|城市规划|土木工程|建筑环境与设备工程|给水排水工程|城市地下空间工程|历史建筑保护工程|景观建筑设计|水务工程|建筑设施智能技术|道路桥梁与渡河工程|水利类|水利水电工程|水文与水资源工程|港口航道与海岸工程|港口海岸及治河工程|水资源与海洋工程|测绘类|测绘工程|遥感科学与技术|空间信息与数字技术|环境与安全类|环境工程|安全工程|水质科学与技术|灾害防治工程|环境科学与工程|环境监察|化工与制药类|化学工程与工艺|制药工程|化工与制药|化学工程与工业生物工程|资源科学与工程|交通运输类|交通运输|交通工程|油气储运工程|飞行技术|航海技术|轮机工程|物流工程|海事管理|交通设备信息工程|海洋工程类|船舶与海洋工程|轻工纺织食品类|食品科学与工程|轻化工程|包装工程|印刷工程|纺织工程|服装设计与工程|食品质量与安全|酿酒工程|葡萄与葡萄酒工程|轻工生物技术|农产品质量与安全|航空航天类|飞行器设计与工程|飞行器动力工程|飞行器制造工程|飞行器环境与生命保障工程|航空航天工程|工程力学与航天航空工程|武器类|武器系统与发射工程|探测制导与控制技术|弹药工程与爆炸技术|特种能源工程与烟火技术|地面武器机动工程|信息对抗技术|武器系统与工程|工程力学类|工程力学|工程结构分析|生物工程类|生物工程|农业工程类|农业机械化及其自动化|农业电气化与自动化|农业建筑环境与能源工程|农业水利工程|农业工程|生物系统工程|林业工程类|森林工程|木材科学与工程|林产化工|公安技术类|刑事科学技术|消防工程|安全防范工程|交通管理工程|核生化消防|植物生产类|农学|园艺|植物保护|茶学|烟草|植物科学与技术|种子科学与工程|应用生物科学|设施农业科学与工程|草业科学类|草业科学|森林资源类|林学|森林资源保护与游憩|野生动物与自然保护区管理|环境生态类|园林|水土保持与荒漠化防治|农业资源与环境|动物生产类|动物科学|蚕学|蜂学|动物医学类|动物医学|动物药学|水产类|水产养殖学|海洋渔业科学与技术|水族科学与技术|基础医学类|基础医学|预防医学类|预防医学|卫生检验|妇幼保健医学|营养学|临床医学与医学技术类|临床医学|麻醉学|医学影像学|医学检验|放射医学|眼视光学|康复治疗学|精神医学|医学技术|听力学|医学实验学|口腔医学类|口腔医学|口腔修复工艺学|中医学类|中医学|针灸推拿学|蒙医学|藏医学|中西医临床医学|法医学类|法医学|护理学类|护理学|药学类|药学|中药学|药物制剂|中草药栽培与鉴定|藏药学|中药资源与开发|应用药学|海洋药学|药事管理|管理科学与工程类|管理科学|信息管理与信息系统|工业工程|工程管理|工程造价|房地产经营管理|产品质量工程|项目管理|工商管理类|工商管理|市场营销|会计学|财务管理|人力资源管理|旅游管理|商品学|审计学|电子商务|物流管理|国际商务|物业管理|特许经营管理|公共管理类|行政管理|公共事业管理|劳动与社会保障|土地资源管理|公共关系学|公共政策学|城市管理|公共管理|文化产业管理|会展经济与管理|国防教育与管理|航运管理|农业经济管理类|农业经济管理|农村区域发展|图书档案学类|图书馆学|档案学|信息资源管理|").Match(Context);
            if (match.Success)
            {
                edu.Specialty = JobAction.GetEduSpecialtyByName(match.Groups[0].Value).ToInt32();
                //专业
            }



            match = new Regex("[0-9]{4}[-/年][0-9]{1,2}[-/月][0-9]{1,2}[日]{0,1}").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                r.Birthday = str_r.ToDateTime();

            }

            match = new Regex("1[34578][0-9]{9}").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                r.Mobile = str_r;
                if (id <= 0)
                {
                    u.Mobile = str_r;
                }
            }

            match = new Regex("0[1-9]{2,3}[- ]{0,1}[0-9]{7,8}").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                r.Tel = str_r;
                if (id < 0)
                {
                    u.Tel = str_r;
                }
            }
            match = new Regex("(博士|硕士|本科|专科|大专|中专|初中)").Match(Context);
            if (match.Success)
            {
                try
                {
                    edu.Edu = (from l in Edu where l.Value == match.Groups[0].Value select l).First().Key;
                }
                catch
                {
                    edu.Edu = (from l in Edu where l.Value == "其他" select l).First().Key;
                }
            }
            match = new Regex("[^ :：\r]+省[^ :：\r]*市[^ :：\r]*").Match(Context);
            if (match.Success)
            {
                str_r = match.Groups[0].Value;
                r.Address = str_r;
                if (id <= 0)
                {
                    u.Address = str_r;
                }

            }
            #endregion

            ent.SaveChanges();
            ent.Dispose();



        }
        #endregion

    }
}
