using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Basement
{
    public static class ObjectExtents
    {
        public static int CountItem(this Class cls)
        {
            using (DataEntities ent = new DataEntities())
            {
                switch (cls.ModelID)
                {
                    case 1://新闻
                        return (from l in ent.News select l).Count();
                        break;
                    case 2: //图片
                        return (from l in ent.ImageAlbum select l).Count();
                        break;
                    case 3: //问答
                        return (from l in ent.Question select l).Count();
                        break;
                    case 4://小说
                        return (from l in ent.Book select l).Count();
                        break;
                    case 5:
                    case 6: //电影
                        return (from l in ent.MovieInfo select l).Count();
                        break;
                    default:
                        return 0;
                }
            }

        }

        #region 通过用户获取群组
        /// <summary>
        /// 通过用户获取群组
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserGroup GetGroup(this User user)
        {
            return UserAction.GetUserGroups().Where(p => p.ID == user.Group).First();
        }
        #endregion

        #region GetClass
        public static Class Class(int id)
        {
            return ClassAction.Classes.Where(p => p.ID == id).FirstOrDefault();
        }

        public static Class GetClass(this ImageAlbum imga)
        {
            return ClassAction.Classes.Where(p => p.ID == imga.ClassID).FirstOrDefault();
        }

        public static Class GetClass(this Question q)
        {
            return ClassAction.Classes.Where(p => p.ID == q.ClassID).FirstOrDefault();
        }

        public static Class GetClass(this News news)
        {
            return ClassAction.Classes.Where(p => p.ID == news.ClassID).FirstOrDefault();
        }

        public static Class GetClass(this Book book)
        {
            return ClassAction.Classes.Where(p => p.ID == book.ClassID).FirstOrDefault();
        }

        public static Class GetClass(this BookChapter chapter)
        {
            return ClassAction.Classes.Where(p => p.ID == chapter.ClassID).FirstOrDefault();
        }

        public static Class GetClass(this MovieInfo movie)
        {
            return ClassAction.Classes.Where(p => p.ID == movie.ClassID).FirstOrDefault();
        }

        public static Class GetClass(this MovieUrlBaidu baidu)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.MovieInfo where l.id == baidu.MovieID select l).FirstOrDefault().GetClass();
            }
        }

        public static Class GetClass(this MovieUrlKuaib kuaib)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.MovieInfo where l.id == kuaib.MovieID select l).FirstOrDefault().GetClass();
            }
        }

        public static Class GetClass(this MovieDrama drama)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.MovieInfo where l.id == drama.MovieID select l).FirstOrDefault().GetClass();
            }
        }
        #endregion

        #region GetSubClass
        public static List<Class> GetSubClass(this Class cls)
        {
            return ClassAction.Classes.Where(p => p.ParentID.ToInt32() == cls.ID).ToList();
        }

        #endregion

        #region GetMovie
        public static MovieInfo GetMovie(this  MovieUrlBaidu baidu)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.MovieInfo where l.id == baidu.MovieID select l).FirstOrDefault();
            }
        }

        public static MovieInfo GetMovie(this  MovieUrlKuaib kuaib)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.MovieInfo where l.id == kuaib.MovieID select l).FirstOrDefault();
            }
        }

        public static MovieInfo GetMovie(this  MovieDrama drama)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.MovieInfo where l.id == drama.MovieID select l).FirstOrDefault();
            }
        }
        #endregion

        #region  GetBook
        public static Book GetBook(this BookChapter chapter)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.Book where l.ID == chapter.BookID select l).FirstOrDefault();
            }
        }
        #endregion

        #region Chapter
        public static BookChapter Chapter(long? id)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.BookChapter where l.ID == id select l).FirstOrDefault();
            }
        }

        #endregion

    }
}
