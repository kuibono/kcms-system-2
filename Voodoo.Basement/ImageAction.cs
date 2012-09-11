using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.IO;

using Voodoo;
using Voodoo.IO;
using System.Web;

namespace Voodoo.Basement
{
    public class ImageAction
    {
        #region 上传图片
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <param name="ClassID"></param>
        /// <returns></returns>
        public static Result UpLoadImage(HttpPostedFile file, int ImageAlbumID)
        {
            DataEntities ent = new DataEntities();

            Result r = new Result();
            SysSetting ss = BasePage.SystemSetting;

            string FileName = file.FileName.GetFileNameFromPath().ToLower();//文件名
            string ExtName = file.FileName.GetFileExtNameFromPath().ToLower();//扩展名
            string NewName = @string.GetGuid() + ExtName;//新文件名

            if (!ExtName.Replace(".", "").IsInArray(ss.FileExtNameFilter.Split(',')))
            {
                r.Success = false;
                r.Text = "不允许上传此类文件";
                return r;
            }
            if (file.ContentLength > ss.MaxPostFileSize)
            {
                r.Success = false;
                r.Text = "文件太大";
                return r;
            }

            string Folder = ss.FileDir + "/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//文件目录
            string FolderShotCut = Folder + "ShortCut/";//缩略图目录

            string FilePath = Folder + NewName;//文件路径
            string FilePath_ShortCut = FolderShotCut + NewName;//缩略图路径

            file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(FilePath), true);


            if (ExtName.ToLower().Replace(".", "").IsInArray("jpg,jpeg,png,gif,bmp".Split(',')))
            {
                ImageHelper.MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(FilePath), System.Web.HttpContext.Current.Server.MapPath(FilePath_ShortCut), 105, 118, "Cut");
            }

            ImageAlbum album = (from l in ent.ImageAlbum where l.ID == ImageAlbumID select l).FirstOrDefault();


            Images img = new Images();
            img.AlbumID = album.ID;
            img.ClickCount = 0;
            img.ExtName = ExtName;
            img.FilePath = FilePath;
            img.FileSize = file.ContentLength;
            img.Intro = "";
            img.ReplyCount = 0;
            img.SmallPath = FilePath_ShortCut;
            img.Title = "";
            img.UploadTime = DateTime.Now;

            ent.AddToImages(img);

            //ImageAlbum imga = ImageAlbumView.GetModelByID(ImageAlbumID.ToString());
            //imga.Size = ImagesView.Count(string.Format("AlbumID={0}", imga.ID));
            //ImageAlbumView.Update(imga);
            album.Size = (from l in ent.Images where l.AlbumID == ImageAlbumID select l).Count();

            ent.SaveChanges();

            r.Success = true;
            r.Text = FilePath;
            return r;
        }
        #endregion 

        #region 删除图片
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="m_where"></param>
        /// <returns></returns>
        public static Result DeleteImage(string m_where)
        {
            DataEntities ent = new DataEntities();

            Result r = new Result();
            try
            {
                var imgs = ent.CreateQuery<Images>(string.Format("select * from Images where {0}",m_where)).ToList();
                foreach (var img in imgs)
                {
                    Voodoo.IO.File.Delete(HttpContext.Current.Server.MapPath(img.SmallPath));
                    Voodoo.IO.File.Delete(HttpContext.Current.Server.MapPath(img.FilePath));
                    ent.DeleteObject(img);

                }
                ent.SaveChanges();
                ent.Dispose();
                
                r.Success = false;
                r.Text = string.Format("删除{0}张图片成功！",imgs.Count);

            }
            catch (Exception ex)
            {
                r.Success = false;
                r.Text = ex.Message;
            }
            return r;
        }
        #endregion 

        #region  删除相册
        /// <summary>
        /// 删除相册
        /// </summary>
        /// <param name="m_where"></param>
        /// <returns></returns>
        public static Result DeleteImageAlbum(string m_where)
        {
            DataEntities ent = new DataEntities();

            Result r = new Result();
            try
            {
                var imgas = //ImageAlbumView.GetModelList(m_where);
                    ent.CreateQuery<ImageAlbum>(string.Format("select * from ImageAlbum where {0}", m_where)).ToList();

                foreach (ImageAlbum imga in imgas)
                {
                    try
                    {
                        Voodoo.IO.File.Delete(HttpContext.Current.Server.MapPath(BasePage.GetImageUrl(imga, imga.GetClass())));//删除相册HTML页面
                        DeleteImage(string.Format("AlbumID={0}", imga.ID));
                        ent.DeleteObject(imga);
                    }
                    catch { }
                }
                r.Success = true;
                r.Text = string.Format("成功删除{0}条记录",imgas.Count);
            }
            catch(Exception ex) 
            {
                r.Success = false;
                r.Text = ex.Message;

            }

            ent.SaveChanges();
            ent.Dispose();

            return r;
        }
        #endregion 
    }
}
