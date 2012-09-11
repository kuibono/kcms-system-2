using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Data;
using Voodoo.Basement;
using Voodoo.Setting;


namespace Web.e.admin.question
{
    public partial class QuestionEdit : AdminBase
    {
        protected int cls = WS.RequestInt("class", 0);
        protected int zt = WS.RequestInt("zt", 0);
        protected int id = WS.RequestInt("id");
        protected string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            url = string.Format("QuestionList.aspx?class={0}&zt={1}", cls, zt);

            if (WS.RequestString("action") == "del")
            {
                DeleteAnswer(WS.RequestInt("anid"));
            }

            if (!IsPostBack)
            {

                LoadInfo();
            }
        }

        #region 加载信息
        /// <summary>
        /// 加载信息
        /// </summary>
        protected void LoadInfo()
        {
            DataEntities ent = new DataEntities();

            ddl_Class.DataSource = NewsAction.NewsClass.Where(p => p.IsLeafClass==true && p.ModelID == 3);
            ddl_Class.DataTextField = "ClassName";
            ddl_Class.DataValueField = "ID";
            ddl_Class.DataBind();

            ddl_Class.SelectedValue = cls.ToS();

            ddl_Author.DataSource = from l in ent.User select l;
            ddl_Author.DataTextField = "UserName";
            ddl_Author.DataValueField = "ID";
            ddl_Author.DataBind();

            Question qu = //QuestionView.GetModelByID(id.ToS());
                (from l in ent.Question where l.ID == id select l).FirstOrDefault();


            if (id > 0)
            {

                ddl_Class.SelectedValue = qu.ClassID.ToS();
                txt_Title.Text = qu.Title;
                //ddl_Author.Text = qu.UserID.ToS();
                ddl_Author.SelectedValue = qu.UserID.ToS();
                txt_ClickCount.Text = qu.ClickCount.ToS();
                txt_Content.Text = qu.Content;

                rp_list.DataSource = //AnswerView.GetModelList(string.Format("QuestionID={0} order by id", qu.ID));
                    from l in ent.Answer where l.QuestionID == qu.ID orderby l.ID select l;
                rp_list.DataBind();
            }
            ent.Dispose();
        }
        #endregion

        protected void DeleteAnswer(int id)
        {
            int clsid = WS.RequestInt("class");
            int quID = WS.RequestInt("id");

            DataEntities ent = new DataEntities();
            var q = (from l in ent.Answer where l.ID == id select l).FirstOrDefault();
            ent.DeleteObject(q);


            Class cls = ObjectExtents.Class(clsid);
            Question qu = //QuestionView.GetModelByID(WS.RequestString("id"));
                (from l in ent.Question where l.ID == quID select l).FirstOrDefault();
            if (cls.ID > 0 && qu.ID > 0)
            {
                CreatePage.CreateContentPage(qu, cls);
            }
            rp_list.DataSource = from l in ent.Answer where l.QuestionID == qu.ID select l;
            rp_list.DataBind();
            ent.SaveChanges();
            ent.Dispose();
        }

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();

            int clsid = ddl_Class.SelectedValue.ToInt32();
            int quID = WS.RequestInt("id");
            Class cls = ObjectExtents.Class(clsid);

            Question qu = (from l in ent.Question where l.ID == quID select l).FirstOrDefault();

            qu.ClassID = ddl_Class.SelectedValue.ToInt32();
            qu.Title = txt_Title.Text.TrimDbDangerousChar();

            try
            {
                qu.UserID = ddl_Author.SelectedValue.ToInt32();
                qu.UserName = ddl_Author.SelectedItem.Text;
            }
            catch
            {
                qu.UserID = 0;
                qu.UserName = "";
            }

            qu.ClickCount = txt_ClickCount.Text.ToInt32(0);
            if (qu.ID <= 0)
            {
                qu.AskTime = DateTime.Now;
            }
            qu.Content = txt_Content.Text.TrimDbDangerousChar();

            qu.Title = txt_Title.Text;
            qu.ZtID = 0;

            if (qu.ID <= 0)
            {
                ent.AddToQuestion(qu);
            }
            ent.SaveChanges();
            ent.Dispose();


            //生成页面
            try
            {
                CreatePage.CreateContentPage(qu, cls);

                Question pre = GetPreQuestion(qu, cls);
                if (pre != null)
                {
                    CreatePage.CreateContentPage(pre, cls);
                }
                CreatePage.CreateListPage(cls, 1);
            }
            catch { }


            Js.AlertAndChangUrl("保存成功！", url);

        }
        #endregion
    }
}
