using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.DTOs
{
    public class First_Dto
    {
        public long Id_Dto { get; set; }
        public string Bio1_Dto { get; set; }
        public string Skills_Dto { get; set; }
        public string Bio2_Dto { get; set; }
        public string Description_Dto { get; set; }
        public string Email_Dto { get; set; }
        public string Phone_Dto { get; set; }
        public string Address_Dto { get; set; }
        public string Image_Dto { get; set; }
        public IFormFile Img_Dto { get; set; }
    }
}