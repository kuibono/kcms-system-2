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
using System.IO;
using Voodoo.IO;

namespace Web.e.post
{
    public partial class PostNews : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            User u = UserAction.opuser;

            if (u.ID <= 0)
            {
                Js.AlertAndChangUrl("对不起，您没有登录，请登陆后进行投稿！", "/");
                return;

            }

            UserGroup g = //UserGroupView.GetModelByID(u.Group.ToS());
                (from l in ent.UserGroup where l.ID == u.Group select l).FirstOrDefault();
            if (g.MaxPost <= 0)
            {
                Js.AlertAndGoback("对不起，您没有投稿的权限！如有疑问，请联系管理员");
                return;
            }

            lb_UserName.Text = u.UserName;
            txt_Author.Text = u.UserName;
            if (!IsPostBack)
            {
                var cls = NewsAction.NewsClass;
                cls = cls.Where(p => p.EnablePost==true && p.IsLeafClass==true&&p.ModelID==1).ToList();
                ddl_Class.DataSource = cls;
                ddl_Class.DataTextField = "ClassName";
                ddl_Class.DataValueField = "id";
                ddl_Class.DataBind();
            }
            LoadInfo();
        }

        protected void LoadInfo()
        {
            int id = WS.RequestInt("id");
            if(id<0)
            {
                return;
            }
            DataEntities ent = new DataEntities();
            News n = (from l in ent.News where l.ID == id select l).FirstOrDefault();
            ent.Dispose();
            if (n.ID < 0)
            {
                Js.Jump("?");
                return;
            }

            if (n.AutorID != UserAction.opuser.ID)
            {
                Js.AlertAndChangUrl("这不是您投递的文章，无权修改","PostList.aspx");
                return;
            }

            ddl_Class.SelectedValue = n.ClassID.ToS();
            txt_Title.Text = n.Title;
            txtFtitle.Text = n.FTitle;
            txt_Keyword.Text = n.KeyWords;
            txt_Description.Text = n.Description;
            txt_Author.Text = n.Author;
            txt_Source.Text = n.Source;
            txt_Content.Text = n.Content;

        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataEntities ent = new DataEntities();
            User u=UserAction.opuser;
            UserGroup g = //UserGroupView.GetModelByID(u.Group.ToS());
                (from l in ent.UserGroup where l.ID == u.Group select l).FirstOrDefault();
            if (FileUpload1.FileName.IsNullOrEmpty())
            {
                Js.AlertAndGoback("为提高您文章的排名，请选择一张标题图片");
                return;
            }

            #region  上传图片
            SysSetting ss = BasePage.SystemSetting;

            HttpPostedFile file = Request.Files["FileUpload1"];
            string FileName = file.FileName.GetFileNameFromPath();//文件名
            string ExtName = file.FileName.GetFileExtNameFromPath();//扩展名
            string NewName = @string.GetGuid() + ExtName;//新文件名

            if (!ExtName.Replace(".", "").IsInArray(ss.FileExtNameFilter.Split(',')))
            {
                Js.AlertAndGoback("不允许上传此类文件");
                return;
            }
            if (file.ContentLength > ss.MaxPostFileSize)
            {
                Js.AlertAndGoback("文件太大");
                return;
            }

            string Folder = ss.FileDir + "/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//文件目录
            string FolderShotCut = Folder + "ShortCut/";//缩略图目录

            string FilePath = Folder + NewName;//文件路径
            string FilePath_ShortCut = FolderShotCut + NewName;//缩略图路径

            file.SaveAs(Server.MapPath(FilePath), true);
            ImageHelper.MakeThumbnail(Server.MapPath(FilePath), Server.MapPath(FilePath_ShortCut), 105, 118, "Cut");



            FileInfo savedFile = new FileInfo(Server.MapPath(FilePath));

            Voodoo.Basement.File f = new Voodoo.Basement.File();

            f.FileDirectory = ss.FileDir;
            f.FileExtName = ExtName;
            f.FilePath = FilePath;
            f.FileSize = (savedFile.Length / 1024).ToInt32();
            //f.FileType=
            f.SmallPath = FilePath_ShortCut;
            f.UpTime = DateTime.Now;

            ent.AddToFile(f);
            ent.SaveChanges();
            #endregion 


            News n = new News();
            n.Author = txt_Author.Text.TrimDbDangerousChar();
            n.AutorID = UserAction.opuser.ID;
            n.ClassID = ddl_Class.SelectedValue.ToInt32();
            n.ClickCount = 0;
            n.Content = txt_Content.Text.TrimDbDangerousChar();
            n.Description = txt_Description.Text.TrimDbDangerousChar();
            n.DownCount = 0;
            n.EnableReply = false;
            n.FTitle = txtFtitle.Text.TrimDbDangerousChar();
            n.KeyWords = txt_Keyword.Text.TrimDbDangerousChar();
            n.ModelID = 0;
            n.NavUrl = "";
            n.NewsTime = DateTime.Now;
            n.SetTop = false;
            n.Source = txt_Source.Text.TrimDbDangerousChar();
            n.Title = txt_Title.Text.TrimDbDangerousChar();
            n.TitleColor = "000";
            n.TitleImage = FilePath;//上传图片
            n.ZtID = 0;
            n.Audit = g.PostAotuAudit;
            n.FileForder = DateTime.Now.ToString("yyyy-MM-dd");

            n.ID = WS.RequestInt("id");

            Result r=NewsAction.UserPost(n, UserAction.opuser);

            if (r.Success)
            {
                Js.AlertAndChangUrl(r.Text, "PostList.aspx");
            }
            else
            {
                Js.AlertAndGoback(r.Text);
            }
            ent.Dispose();

        }
    }
}
