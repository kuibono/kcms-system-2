using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
