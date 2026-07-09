using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface IProject
    {
        public bool Add (Projects_Dto Dt);
        public List<Projects_Dto> ShowAdmin ();
        public List<Projects_Dto> ShowClient ();
        public bool Delete (long id);
        public bool Update (Projects_Dto Dt) ;
        public Projects_Dto Find (long id);
        public bool Status (long id);
        
    }
}