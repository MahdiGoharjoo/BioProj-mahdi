using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DataBase
{
    public class Tbl_Projects
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Categories { get; set; }
        public string Employer { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}