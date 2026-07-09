using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface IFirst
    {
        public First_Dto Show();
        public First_Dto Findforupdate ();
        public bool Update(First_Dto first);
    }
}