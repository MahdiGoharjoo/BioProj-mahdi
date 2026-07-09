using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface IAboutMe
    {
        public AboutMe_Dto Show();
        public AboutMe_Dto Findforupdate ();
        public bool Update(AboutMe_Dto About);
        
    }
}