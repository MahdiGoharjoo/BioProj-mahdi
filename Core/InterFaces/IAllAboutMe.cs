using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface IAllAboutMe
    {
        public bool Add (AllAboutMe_Dto Dt);
        public List<AllAboutMe_Dto> ShowAdmin ();
        public List<AllAboutMe_Dto> ShowClient ();
        public bool Delete (long id);
        public bool Update (AllAboutMe_Dto Dt) ;
        public AllAboutMe_Dto Find (long id);
    }
}