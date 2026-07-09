using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.InterFaces;
using Data.Context;
using Data.DataBase;
using Microsoft.AspNetCore.Hosting;
using WebCore.Tools;

namespace Core.Repositories
{
    public class RStatics : IStatics
    {
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RStatics(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public bool Add(Statics_Dto Dt)
        {

            if (Dt != null)
            {
                try
                {
                    Tbl_Statics tb = new Tbl_Statics();
                    tb.Number = Dt.Number_Dto;
                    tb.Description = Dt.Description_Dto;
                    db.tbl_Statics.Add(tb);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception ex)
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                try
                {
                    var find = db.tbl_Statics.SingleOrDefault(p => p.Id == id);
                    Delete del = new Delete(en);
                    db.tbl_Statics.Remove(find);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
        }

        public Statics_Dto Find(long id)
        {
            var data = db.tbl_Statics.SingleOrDefault(p => p.Id == id);
            Statics_Dto statics_Dto = new Statics_Dto()
            {
                Id_Dto = data.Id,
                Number_Dto = data.Number,
                Description_Dto = data.Description,
               
            };
            return statics_Dto;
        }

        public List<Statics_Dto> ShowAdmin()
        {
            var all = db.tbl_Statics.ToList();
            List<Statics_Dto> statics = new List<Statics_Dto>();
            foreach (var item in all)
            {
                Statics_Dto dt = new Statics_Dto()
                {
                    Id_Dto = item.Id,
                    Number_Dto = item.Number,
                    Description_Dto = item.Description,
                };
                statics.Add(dt);
            }
            return statics;
        }

        public List<Statics_Dto> ShowClient()
        {
            var all = db.tbl_Statics.ToList();
            List<Statics_Dto> statics = new List<Statics_Dto>();
            foreach (var item in all)
            {
                Statics_Dto dt = new Statics_Dto()
                {
                    Id_Dto = item.Id,
                    Number_Dto = item.Number,
                    Description_Dto = item.Description,
                };
                statics.Add(dt);
            }
            return statics;
        }


        public bool Update(Statics_Dto Dt)
        {
            var find = db.tbl_Statics.SingleOrDefault(p => p.Id == Dt.Id_Dto);
            find.Number = Dt.Number_Dto;
            find.Description = Dt.Description_Dto;
            db.tbl_Statics.Update(find);
            db.SaveChanges();
            return true;
        }
    }
}