using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class Projects_Dto
    {
        public long Id_Dto { get; set; }
        public string Title_Dto { get; set; }
        public string Categories_Dto { get; set; }
        public string Employer_Dto { get; set; }
        public string Image_Dto { get; set; }
        public string Description_Dto { get; set; }
        public string Date { get; set; }
    }
}