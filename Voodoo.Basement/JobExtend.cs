using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voodoo.Basement.Model;

namespace Voodoo.Basement
{
    public static class JobExtend
    {
        public static JobResumeInfo DefaultResume(this User u)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.JobResumeInfo where l.UserID==u.ID select l).FirstOrDefault();
            }
        }

        public static int GetCompanyIDByPost(long postID)
        {
            using (DataEntities ent = new DataEntities())
            {
                return (from l in ent.JobPost where l.ID==postID select l).FirstOrDefault().CompanyID.ToInt32();
            }
        }

        public static void DeleteObjects<T>(this DataEntities ent, IQueryable<T> entitis) where T : class, new()
        {
            
            foreach (var item in entitis)
            {
                ent.DeleteObject(item);
            }
        }

        public static string GetPostEduAndNumber(this JobPost post)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var list = (List<JobPostEduAndEmployeeCount>)Voodoo.IO.XML.DeSerialize(typeof(List<JobPostEduAndEmployeeCount>), post.Ext1);
                foreach (var j in list.Where(p=>p.Checked==true))
                {
                    sb.AppendFormat("{0}:{1}/", j.Text, j.Number);
                }
                sb = sb.TrimEnd('/');
            }
            catch
            {
                sb.Append("未知");
            }
            return sb.ToS();
        }

        public static string GetPostEdu(this JobPost post)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var list = (List<JobPostEduAndEmployeeCount>)Voodoo.IO.XML.DeSerialize(typeof(List<JobPostEduAndEmployeeCount>), post.Ext1);
                foreach (var j in list.Where(p => p.Checked == true))
                {
                    sb.AppendFormat("{0}/", j.Text);
                }
                sb = sb.TrimEnd('/');
            }
            catch
            {
                sb.Append("未知");
            }
            return sb.ToS();
        }
    }
}
