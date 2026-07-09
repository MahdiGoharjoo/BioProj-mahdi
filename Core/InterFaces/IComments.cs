using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface IComments
    {
        public bool Add(Comments_Dto Dt);
        public List<Comments_Dto> ShowAdmin ();
        public List<Comments_Dto> ShowClient ();
        public bool Delete (long id);
        public bool Update (Comments_Dto Dt) ;
        public Comments_Dto Find (long id);
        public bool Status(long id);
        
    }
}