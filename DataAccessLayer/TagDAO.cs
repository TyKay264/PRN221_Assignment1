using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TagDAO
    {
        public static List<Tag> getTags()
        {
            List<Tag> tagsList = new List<Tag>();
            try
            {
                using var context = new FunewsManagementDbContext();
                tagsList = context.Tags.ToList();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tagsList;
        }
    }
}
