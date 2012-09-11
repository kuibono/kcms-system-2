using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Voodoo;

using Voodoo.Security;


namespace Voodoo.Basement
{
    public class NewsAction
    {
        /// <summary>
        /// 系统中的所有栏目
        /// </summary>
        public static List<Class> NewsClass
        {
            get
            {
                if (Voodoo.Cache.Cache.GetCache("_NewClassList") == null)
                {
                    using (DataEntities ent = new DataEntities())
                    {
                        Cache.Cache.SetCache("_NewClassList", (from l in ent.Class select l).ToList(), 10);
                    }
                }
                return (List<Class>)Voodoo.Cache.Cache.GetCache("_NewClassList");
            }
        }

        public static List<Zt> NewsZt
        {
            get
            {
                if (Voodoo.Cache.Cache.GetCache("_NewsZtList") == null)
                {
                    using (DataEntities ent = new DataEntities())
                    {
                        Cache.Cache.SetCache("_NewsZtList", (from l in ent.Zt select l).ToList(), 10);
                    }
                }
                return (List<Zt>)Voodoo.Cache.Cache.GetCache("_NewsZtList");
            }

        }

        #region  用户投稿
        /// <summary>
        /// 用户投稿
        /// </summary>
        /// <param name="news"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Result UserPost(News news, User user)
        {
            using (DataEntities ent = new DataEntities())
            {
                Result r = new Result();

                UserGroup g = (from l in ent.UserGroup where l.ID == user.Group select l).FirstOrDefault();

                int? maxPost = 0;
                try
                {
                    maxPost = g.MaxPost;
                }
                catch { }


                //验证用户是否允许投稿
                if (maxPost <= 0)
                {
                    r.Success = false;
                    r.Text = "对不起，您没有投稿的权限！";
                    return r;
                }

                //验证本日投稿数是否已经过多
                //int todayPost = NewsView.Count(string.Format("AutorID={0}", user.ID));
                int todayPost = (from l in ent.News where l.AutorID == user.ID && l.NewsTime > DateTime.Now.Date && l.NewsTime < DateTime.Now.AddDays(1).Date select l).Count();
                if (todayPost > maxPost && news.ID <= 0)
                {
                    r.Success = false;
                    r.Text = "对不起，您本日投稿数量已经达到最大限制，请明天继续！";
                    return r;
                }

                //验证标题是否为空
                if (news.Title.IsNullOrEmpty())
                {
                    r.Success = false;
                    r.Text = "文章标题不能为空";
                    return r;
                }

                //验证栏目
                if (news.ClassID <= 0)
                {
                    r.Success = false;
                    r.Text = "栏目不能为空！";
                    return r;
                }

                news.Audit = g.PostAotuAudit;
                news.AutorID = user.ID;
                if (news.Author.IsNullOrEmpty())
                {
                    news.Author = user.UserName;
                }

                if (news.ID <= 0)
                {
                    ent.AddToNews(news);
                }



                user.Cent += (from l in ent.Class where l.ID == news.ClassID select l).FirstOrDefault().PostAddCent;

                ent.SaveChanges();

                r.Success = true;
                r.Text = "投递成功！";

                return r;
            }
        }
        #endregion

    }
}
