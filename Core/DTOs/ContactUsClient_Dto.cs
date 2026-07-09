using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ContactUsClient_Dto
    {
        public long Id_Dto { get; set; }
        public string Name_Dto { get; set; }
        public string Email_Dto { get; set; }
        public string Comment_Dto { get; set; }
        
    }
}