using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using Voodoo;
using Voodoo.Basement;

namespace Web.Dynamic.Job
{
    public partial class Search : BasePage
    {
        #region 变量
        public string str_Salary { get; set; }
        public string str_Edu { get; set; }
        public string str_UpdateTime { get; set; }
        public string str_Industry { get; set; }

        public string str_Salary_Bx { get; set; }
        public string str_Edu_Bx { get; set; }
        public string str_UpdateTime_Bx { get; set; }
        public string str_Industry_Bx { get; set; }

        public string str_EmployeeCount { get; set; }
        public string str_Exp { get; set; }

        private int? salary { get; set; }
        private int? updatetime { get; set; }
        private int? edu { get; set; }
        private int? industry { get; set; }
        public string key { get; set; }
        public string location { get; set; }
        private int? employeeCount { get; set; }
        private int? exp { get; set; }

        private int? province { get; set; }
        private int? city { get; set; }

        private int page { get; set; }

        private string curUrl = "";

        public string htmlFooter { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSearchPars();
            str_Salary = bindItems(JobAction.SalaryDegree, salary, "s");
            str_UpdateTime = bindItems(JobAction.UpdateTime, updatetime, "t");
            str_Edu = bindItems(JobAction.Edu, edu, "e");
            str_EmployeeCount = GetEmplyeeCountItems(employeeCount);
            str_Exp = GetExpItems(exp);
            BindIndustry();

            salary = null;
            newUrl();
            str_Salary_Bx = string.Format("<a href=\"{0}\">不限</a>",curUrl);
            LoadSearchPars();

            edu = null;
            newUrl();
            str_Edu_Bx = string.Format("<a href=\"{0}\">不限</a>", curUrl);
            LoadSearchPars();

            updatetime = null;
            newUrl();
            str_UpdateTime_Bx = string.Format("<a href=\"{0}\">不限</a>", curUrl);
            LoadSearchPars();

            industry = null;
            newUrl();
            str_Industry_Bx = string.Format("<a href=\"{0}\">不限</a>", curUrl);
            LoadSearchPars();

            TemplateHelper helper = new TemplateHelper();
            htmlFooter=helper.GetPublicTemplate("indexbottom");

            BindList();
        }

        #region 绑定列表
        /// <summary>
        /// 绑定列表
        /// </summary>
        protected void BindList()
        {
            DateTime today = DateTime.Now.Date;
            DateTime day3 = DateTime.Now.AddDays(-3).Date;
            DateTime day7 = DateTime.Now.AddDays(-7).Date;
            DateTime day30 = DateTime.Now.AddDays(-30).Date;

            using (DataEntities ent = new DataEntities())
            {
                var db_list = from p in ent.JobPost
                              from c in ent.JobCompany
                              from pro in ent.Province
                              from ct in ent.City
                              where p.CompanyID == c.ID
                              && p.Province == pro.ID
                              && p.City == ct.id
                              select new
                              {
                                  p.City,
                                  p.CompanyID,
                                  p.Edu,
                                  p.PostTime,
                                  p.EmployNumber,
                                  p.Expressions,
                                  p.ID,
                                  p.Intro,
                                  p.Province,
                                  p.Salary,
                                  p.Title,
                                  c.CompanyName,
                                  c.Industry,
                                  c.EmployeeCount,
                                  ProvinceName = pro.province1,
                                  CityName = ct.city1

                              };
                if (salary != null)
                {
                    db_list = from l in db_list where l.Salary == salary select l;
                }
                if (edu != null)
                {
                    db_list = from l in db_list where l.Edu >= edu select l;
                }
                if (industry != null)
                {
                    string str_ind = industry.ToS();
                    db_list = from l in db_list where l.Industry == str_ind select l;
                }
                if (city != null)
                {
                    db_list = from l in db_list where l.City == city select l;
                }
                if (province != null)
                {
                    db_list = from l in db_list where l.Province == province select l;
                }
                if (key.Length > 0)
                {
                    db_list = from l in db_list
                              where l.Title.Contains(key)
                                  || l.CompanyName.Contains(key)
                              select l;
                }
                switch (updatetime)
                {
                    case 0:
                        db_list = from l in db_list where l.PostTime >= today select l;
                        break;
                    case 1:
                        db_list = from l in db_list where l.PostTime >= day3 select l;
                        break;
                    case 2:
                        db_list = from l in db_list where l.PostTime >= day7 select l;
                        break;
                    case 3:
                        db_list = from l in db_list where l.PostTime >= day30 select l;
                        break;
                    default:
                        break;

                }
                if (!location.IsNullOrEmpty())
                {
                    db_list = from l in db_list where l.ProvinceName.Contains(location) || l.CityName.Contains(location) select l;
                }
                if (employeeCount != null)
                {
                    db_list = from l in db_list where l.EmployeeCount >= employeeCount select l;
                }
                if (exp != null)
                {
                    if (exp == 0)
                    {
                        db_list = from l in db_list where l.Expressions == 0 select l;
                    }
                    else
                    {
                        db_list = from l in db_list where l.Expressions > 0 select l;
                    }

                }


                pager.RecordCount = db_list.Count();
                db_list = db_list.OrderByDescending(p => p.ID).Skip((page - 1) * pager.PageSize).Take(pager.PageSize);

                LoadSearchPars();
                newUrl();
                pager.UrlRewritePattern = curUrl += "&page={0}";
                // pager.CurrentPageIndex = page;
                if (db_list.Count() == 0)
                {
                    return;
                }
                var list = from l in db_list.ToList()
                           from e in JobAction.EmployeeCount
                           from ed in JobAction.Edu
                           from ex in JobAction.Expressions
                           from sa in JobAction.SalaryDegree
                           where l.EmployeeCount == e.Key
                           && l.Edu == ed.Key
                           && l.Expressions == ex.Key
                           && l.Salary == sa.Key
                           select new
                           {
                               l.City,
                               l.CompanyID,
                               Edu = ed.Value,
                               l.PostTime,
                               l.EmployNumber,
                               Expressions = ex.Value,
                               l.ID,
                               l.Intro,
                               l.Province,
                               Salary = sa.Value,
                               l.Title,
                               l.CompanyName,
                               l.Industry,
                               EmployeeCount = e.Value

                           };

                rp_list.DataSource = list;
                rp_list.DataBind();

            }
        }
        #endregion

        #region 获取页面参数
        /// <summary>
        /// 获取页面参数
        /// </summary>
        private void LoadSearchPars()
        {
            salary = WS.RequestNullInt32("s");
            updatetime = WS.RequestNullInt32("t");
            edu = WS.RequestNullInt32("e");
            industry = WS.RequestNullInt32("i");
            key = WS.RequestString("k");
            province = WS.RequestNullInt32("p");
            city = WS.RequestNullInt32("c");
            page = WS.RequestInt("page", 1);
            location = WS.RequestString("l");
            employeeCount = WS.RequestNullInt32("em");
            exp = WS.RequestNullInt32("ex");
        }
        #endregion

        #region 重新生成Url
        /// <summary>
        /// 重新生成Url
        /// </summary>
        private void newUrl()
        {
            curUrl = string.Format("Search.aspx?s={0}&t={1}&e={2}&i={3}&p={4}&c={5}&k={6}&l={7}&em={8}&ex={9}",
                salary,
                updatetime,
                edu,
                industry,
                province,
                city,
                key,
                location,
                employeeCount,
                exp
                );


        }
        #endregion


        #region 绑定行业选项
        /// <summary>
        /// 绑定行业选项
        /// </summary>
        protected void BindIndustry()
        {
            using (DataEntities ent = new DataEntities())
            {
                StringBuilder sb = new StringBuilder();

                var qs = (from l in ent.JobIndustry where l.ParentID == 0 select l).AsCache("parent0");
                foreach (var q in qs)
                {
                    industry = q.ID;
                    newUrl();
                    sb.AppendFormat("<a href=\"{0}\" class={1}>{2}</a> ", curUrl, q.ID == WS.RequestNullInt32("i") ? "select" : "", q.Name);
                }
                str_Industry = sb.ToS();
                LoadSearchPars();
            }
        }
        #endregion

        #region 获取员工数量选择项
        /// <summary>
        /// 获取员工数量选择项
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetEmplyeeCountItems(int? value)
        {
            StringBuilder sb = new StringBuilder();
            employeeCount = null;
            newUrl();
            sb.AppendFormat("<option value=\"{0}\" {1}>不限规模</option>", curUrl, value == null ? "selected='selected'" : "");
            foreach (var item in JobAction.EmployeeCount)
            {
                employeeCount = item.Key;
                newUrl();
                sb.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", curUrl, item.Key == value ? "selected='selected'" : "", item.Value);
            }
            return sb.ToS();
        }
        #endregion

        #region 获取经验下拉列表
        /// <summary>
        /// 获取经验下拉列表
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetExpItems(int? value)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(0, "实习");
            dic.Add(1, "应届");
            StringBuilder sb = new StringBuilder();

            exp = null;
            newUrl();
            sb.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", curUrl, WS.RequestNullInt32("ex") == null ? "selected='selected'" : "", "工作性质");
            foreach (var item in dic)
            {
                exp = item.Key;
                newUrl();
                sb.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", curUrl, item.Key == value ? "selected='selected'" : "", item.Value);
            }
            return sb.ToS();
        }
        #endregion

        #region 绑定ENUM项
        /// <summary>
        /// 绑定ENUM项
        /// </summary>
        /// <param name="val"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string bindItems(Dictionary<int, string> val, int? value, string parName)
        {
            StringBuilder sb = new StringBuilder();
            page = 1;
            foreach (var item in val)
            {
                switch (parName)
                {
                    case "s":
                        salary = item.Key;
                        break;
                    case "t":
                        updatetime = item.Key;
                        break;
                    case "e":
                        edu = item.Key;
                        break;
                    case "i":
                        industry = item.Key;
                        break;
                    case "p":
                        province = item.Key;
                        break;
                    case "c":
                        city = item.Key;
                        break;
                }

                newUrl();
                sb.AppendFormat("<a href=\"{0}\" class={1}>{2}</a> ", curUrl, item.Key == value ? "select" : "", item.Value);
            }
            LoadSearchPars();
            return sb.ToS();
        }
        #endregion
    }
}