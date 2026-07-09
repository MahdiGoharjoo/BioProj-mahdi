using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.InterFaces;
using Data.Context;
using Microsoft.AspNetCore.Hosting;

namespace Core.Repositories
{
    public class RContactUsAdmin : IContactUsAdmin
    {
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RContactUsAdmin(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public ContactUsAdmin_Dto Findforupdate()
        {
            return db.tbl_ContactUsAdmins.Select(p=> new ContactUsAdmin_Dto()
            {
                Id_Dto = p.Id,
                Description_Dto = p.Description,
            }).First();
        }


        public ContactUsAdmin_Dto Show()
        {
            return db.tbl_ContactUsAdmins.Select(p=> new ContactUsAdmin_Dto()
            {
                Id_Dto = p.Id,
                Description_Dto = p.Description,
            }).First();
        }


        public bool Update(ContactUsAdmin_Dto first)
        {
            var find = db.tbl_ContactUsAdmins.First();
            find.Description = first.Description_Dto;
            db.tbl_ContactUsAdmins.Update(find);
            db.SaveChanges();
            return true;
        }
    }
}