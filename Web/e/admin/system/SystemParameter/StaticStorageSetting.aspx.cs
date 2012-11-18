using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Voodoo;
using Voodoo.Basement;
using Voodoo.Basement.Routing;

namespace Web.e.admin.system.SystemParameter
{
    public partial class StaticStorageSetting : AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        protected void LoadInfo()
        {
            var s = StorageSetting.Get();
            txt_NewsClass.Text = s.NewsClass;
            txt_NewsPage.Text = s.NewsPage;
            txt_ImageClass.Text = s.ImageClass;
            txt_ImagePage.Text = s.ImagePage;
            txt_QuestionClass.Text = s.QuestionClass;
            txt_QuestionPage.Text = s.QuestionPage;
            txt_BookClass.Text = s.BookClass;
            txt_BookInfo.Text = s.BookInfo;
            txt_BookChapter.Text = s.BookChapter;
            txt_BookChapterTxt.Text = s.BookChapterTxt;
            txt_JobClass.Text = s.JobClass;
            txt_JobPost.Text = s.JobPost;
            txt_JobCompany.Text = s.JobCompany;
            txt_MovieClass.Text = s.MovieClass;
            txt_MovieInfo.Text = s.MovieInfo;
            txt_MovieBaiduPlay.Text = s.MovieBaiduPlay;
            txt_MovieKuaibPlay.Text = s.MovieKuaibPlay;
            txt_MovieDramaPlay.Text = s.MovieDramaPlay;

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var s = StorageSetting.Get();

            s.NewsClass = txt_NewsClass.Text;
            s.NewsPage = txt_NewsPage.Text;
            s.ImageClass = txt_ImageClass.Text;
            s.ImagePage = txt_ImagePage.Text;
            s.QuestionClass = txt_QuestionClass.Text;
            s.QuestionPage = txt_QuestionPage.Text;
            s.BookClass = txt_BookClass.Text;
            s.BookInfo = txt_BookInfo.Text;
            s.BookChapter = txt_BookChapter.Text;
            s.BookChapterTxt = txt_BookChapterTxt.Text;
            s.JobClass = txt_JobClass.Text;
            s.JobPost = txt_JobPost.Text;
            s.JobCompany = txt_JobCompany.Text;
            s.MovieClass = txt_MovieClass.Text;
            s.MovieInfo = txt_MovieInfo.Text;
            s.MovieBaiduPlay = txt_MovieBaiduPlay.Text;
            s.MovieKuaibPlay = txt_MovieKuaibPlay.Text;
            s.MovieDramaPlay = txt_MovieDramaPlay.Text;

            s.Save();
            Js.AlertAndChangUrl("保存成功！", "StaticStorageSetting.aspx");
        }
    }
}