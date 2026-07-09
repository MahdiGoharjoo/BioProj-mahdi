using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface IContactUsClient
    {
        public bool Add(ContactUsClient_Dto Dt);
        public List<ContactUsClient_Dto> Show();
        public bool Delete(long id);
    }
}