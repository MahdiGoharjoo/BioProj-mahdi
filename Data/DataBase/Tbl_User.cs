using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Data.DataBase
{
    public class Tbl_User
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}