using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface IBlog
    {
        public bool Add(Blog_Dto Dt);
        public List<Blog_Dto> ShowAdmin ();
        public List<Blog_Dto> ShowClient ();
        public bool Delete (long id);
        public bool Update (Blog_Dto Dt) ;
        public Blog_Dto Find (long id);
        public bool Status(long id);
    }
}