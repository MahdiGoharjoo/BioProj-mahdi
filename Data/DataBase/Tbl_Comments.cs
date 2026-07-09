using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DataBase
{
    public class Tbl_Comments
    {
        public long Id { get; set; }
        public string CommentDescription { get; set; }
        public string CustommerName { get; set; }
        public string CustommerRole { get; set; }
        public string Image { get; set; }
    }
}