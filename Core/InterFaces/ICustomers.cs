using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Data.DataBase;

namespace Core.InterFaces
{
    public interface ICustomers
    {
        public bool Add (Customers_Dto Dt);
        public List<Customers_Dto> ShowAdmin ();
        public List<Customers_Dto> ShowClient ();
        public bool Delete (long id);
        public bool Update (Customers_Dto Dt) ;
        public Customers_Dto Find (long id);
        public bool Status (long id);
        
    }
}