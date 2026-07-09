using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Data.DataBase
{
    public class Tbl_Role : IdentityRole
    {
        public string Detail { get; set; }
    }
}