using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return (from l in Provinces where l.ID == id select l).FirstOrDefault().province1;
        }
        public static string GetCityName(int id)
        {
            return (from l in Cities where l.id == id select l).FirstOrDefault().city1;
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
                ct.Hot+= 1;
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
                result.Add(0, "在读");
                result.Add(1, "应届");
                result.Add(2, "一年");
                result.Add(3, "二年");
                result.Add(4, "三年");
                result.Add(5, "五年");
                result.Add(6, "八年");
                result.Add(7, "十年");
                return result;
            }
        }

        public static string GetExpressionsName(int key)
        {
            return Expressions[key];
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

                var cts = (from l in ent.City where l.ProvinceID == pid select l).AsCache();
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

    }
}
