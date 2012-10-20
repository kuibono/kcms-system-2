using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;

namespace Web.Dynamic.Job
{
    public partial class Company : BasePage
    {
        public JobCompany Comapny { get; set; }

        public string CompanyName = "";
        public string Industry = "";
        public string CompanyType = "";
        public string EmployeeCount = "";
        public string Intro = "";

        private string curUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        protected void LoadInfo()
        {
            long id = WS.RequestLong("id");

            if (id < 0)
            {
                return;
            }

            DataEntities ent = new DataEntities();

            Comapny = (from l in ent.JobCompany where l.ID == id select l).FirstOrDefault();
            CompanyName = Comapny.CompanyName;
            Industry = Comapny.Industry;
            CompanyType = JobAction.GetCompanyTypeName(Comapny.CompanyType.ToInt32());
            EmployeeCount = JobAction.GetEmployeeCountName(Comapny.EmployeeCount.ToInt32());
            Intro = Comapny.Intro;



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
            db_list = from l in db_list where l.CompanyID == id select l;


            pager.RecordCount = db_list.Count();
            int page = WS.RequestInt("page", 1);
            db_list = db_list.OrderByDescending(p => p.ID).Skip((page - 1) * pager.PageSize).Take(pager.PageSize);

            pager.UrlRewritePattern = "Company.aspx?id="+ WS.RequestString("id") +"&page={0}";
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

            ent.Dispose();

        }
    }
}