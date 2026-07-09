using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface IContactUsAdmin
    {
        public ContactUsAdmin_Dto Show();
        public ContactUsAdmin_Dto Findforupdate ();
        public bool Update(ContactUsAdmin_Dto first);
        
    }
}