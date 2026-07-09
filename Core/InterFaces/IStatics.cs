using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;
using Microsoft.IdentityModel.Protocols;

namespace Core.InterFaces
{
    public interface IStatics
    {
        public bool Add(Statics_Dto Dt);
        public List<Statics_Dto> ShowAdmin ();
        public List<Statics_Dto> ShowClient ();
        public bool Delete (long id);
        public bool Update (Statics_Dto Dt) ;
        public Statics_Dto Find (long id);
    }
}