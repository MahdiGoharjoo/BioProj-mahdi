using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.DTOs
{
    public class Comments_Dto
    {
        public long Id_Dto { get; set; }
        public string CommentDescription_Dto { get; set; }
        public string CustommerName_Dto { get; set; }
        public string CustommerRole_Dto { get; set; }
        public string Image_Dto { get; set; }
        public IFormFile Img_Dto { get; set; }
    }
}