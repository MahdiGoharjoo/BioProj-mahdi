using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.DTOs
{
    public class Customers_Dto
    {
        public long Id_Dto { get; set; }
        public string Image_Dto { get; set; }
        public IFormFile Img { get; set; }
    }
}