using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;

namespace Core.InterFaces
{
    public interface IUser
    {
        public bool Add (User_Dto Dt);
        public List<User_Dto> ShowAdmin ();
        public List<User_Dto> ShowClient ();
        public bool Delete (long id);
        public bool Update (User_Dto Dt) ;
        public User_Dto Find (long id);
        
    }
}