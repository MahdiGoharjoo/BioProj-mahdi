using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface ISerrvices
    {
        public bool Add(Serrvices_Dto Dt);
        public List<Serrvices_Dto> ShowAdmin ();
        public List<Serrvices_Dto> ShowClient ();
        public bool Delete (long id);
        public bool Update (Serrvices_Dto Dt) ;
        public Serrvices_Dto Find (long id);
        public bool Status(long id);
        
    }
}