using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DataBase
{
    public class Tbl_First
    {
        public long Id { get; set; }
        public string Bio1 { get; set; }
        public string Skills { get; set; }
        public string Bio2 { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }
}