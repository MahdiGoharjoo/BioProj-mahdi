using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.InterFaces;
using Data.Context;
using Microsoft.AspNetCore.Hosting;
using WebCore.Tools;

namespace Core.Repositories
{
    public class RAboutMe : IAboutMe
    {
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RAboutMe(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public AboutMe_Dto Findforupdate()
        {
            return db.tbl_Aboutme.Select(p => new AboutMe_Dto()
            {
                Id_Dto = p.Id,
                Email_Dto = p.Email,
                Description_Dto = p.Description,
                Phone_Dto = p.Phone,
                BirthTown_Dto = p.BirthTown,
                Age_Dto = p.Age,
            }).First();
        }


        public AboutMe_Dto Show()
        {
            return db.tbl_Aboutme.Select(p => new AboutMe_Dto()
            {
                Id_Dto = p.Id,
                Email_Dto = p.Email,
                Description_Dto = p.Description,
                Phone_Dto = p.Phone,
                BirthTown_Dto = p.BirthTown,
                Age_Dto = p.Age,
            }).First();
        }

        public bool Update(AboutMe_Dto About)
        {
            var find = db.tbl_Aboutme.First();
            find.BirthTown = About.BirthTown_Dto;
            find.Description = About.Description_Dto;
            find.Email = About.Email_Dto;
            find.Phone = About.Phone_Dto;
            db.tbl_Aboutme.Update(find);
            db.SaveChanges();
            return true;
        }
    }
}