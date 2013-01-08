using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Voodoo;
using Voodoo.Basement;

namespace Web.wap.b
{
    public partial class b : BasePage
    {
        public Voodoo.Basement.Book book;
        public Class ParentCls;
        public Class Cls;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetBookInfo();
            if (!IsPostBack)
            {
                BindChapterList();
            }
        }

        protected void GetBookInfo()
        {
            int id = WS.RequestInt("id");
            using (DataEntities ent = new DataEntities())
            {
                var bs = from l in ent.Book where l.ID == id select l;
                if (bs.Count() > 0)
                {
                    book = bs.First();
                }
                else
                {
                    book = new Voodoo.Basement.Book();
                }

            }

            Cls = book.GetClass();
            ParentCls = ClassAction.Classes.Where(p => p.ID == Cls.ParentID).First();

        }

        protected void BindChapterList()
        {
            bool asc = WS.RequestString("asc").ToBoolean();
            int id = WS.RequestInt("id");
            int page = AspNetPager1.CurrentPageIndex;
            using (DataEntities ent = new DataEntities())
            {
                if (asc)
                {
                    var lst = from l in ent.BookChapter where l.BookID == id orderby l.ID select l;
                    AspNetPager1.RecordCount = lst.Count();
                    Repeater1.DataSource = lst.Skip((page - 1) * AspNetPager1.PageSize).Take(AspNetPager1.PageSize);
                    Repeater1.DataBind();
                }
                else
                {
                    var lst = from l in ent.BookChapter where l.BookID == id orderby l.ID descending select l;
                    AspNetPager1.RecordCount = lst.Count();
                    Repeater1.DataSource = lst.Skip((page - 1) * AspNetPager1.PageSize).Take(AspNetPager1.PageSize);
                    Repeater1.DataBind();
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindChapterList();
        }
    }
}