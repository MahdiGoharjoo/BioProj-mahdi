using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.InterFaces;
using Core.Tools.Upload;
using Data.Context;
using Data.DataBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebCore.Tools;

namespace Core.Repositories
{
    public class RSerrvices : ISerrvices
    {
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RSerrvices(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public bool Add(Serrvices_Dto Dt)
        {

            if (Dt != null)
            {
                try
                {
                    Tbl_Serrvices tb = new Tbl_Serrvices();
                    tb.Description = Dt.Description_Dto;
                    tb.Title = Dt.Title_Dto;
                    tb.Image = Dt.Image_Dto;
                    if (Dt.Img_Dto != null)
                    {
                        Upload upload = new Upload(en);
                        tb.Image = upload.Upload_Webp_Thumb(Dt.Img_Dto, "admin/Serrvices", 1650).Result;

                    }
                    db.tbl_Serrvices.Add(tb);
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
                    var find = db.tbl_Serrvices.SingleOrDefault(p => p.Id == id);
                    Delete del = new Delete(en);
                    del.Delete_Image(find.Image);
                    db.tbl_Serrvices.Remove(find);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
        }

        public Serrvices_Dto Find(long id)
        {
            var data = db.tbl_Serrvices.SingleOrDefault(p => p.Id == id);
            Serrvices_Dto serrvices_Dto = new Serrvices_Dto()
            {
                Id_Dto = data.Id,
                Description_Dto = data.Description,
                Title_Dto = data.Title,
                Image_Dto = data.Image,

            };
            return serrvices_Dto;
        }

        public List<Serrvices_Dto> ShowAdmin()
        {
            var all = db.tbl_Serrvices.ToList();
            List<Serrvices_Dto> serrvices_Dtos = new List<Serrvices_Dto>();
            foreach (var item in all)
            {
                Serrvices_Dto dt = new Serrvices_Dto()
                {
                    Id_Dto = item.Id,
                    Description_Dto = item.Description,
                    Title_Dto = item.Title,
                    Image_Dto = item.Image,
                };
                serrvices_Dtos.Add(dt);
            }
            return serrvices_Dtos;
        }

        public List<Serrvices_Dto> ShowClient()
        {
            var all = db.tbl_Serrvices.ToList();
            List<Serrvices_Dto> serrvices_Dtos = new List<Serrvices_Dto>();
            foreach (var item in all)
            {
                Serrvices_Dto dt = new Serrvices_Dto()
                {
                    Id_Dto = item.Id,
                    Description_Dto = item.Description,
                    Title_Dto = item.Title,
                    Image_Dto = item.Image,
                };
                serrvices_Dtos.Add(dt);
            }
            return serrvices_Dtos;
        }

        public bool Status(long id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Serrvices_Dto Dt)
        {
            var find = db.tbl_Serrvices.SingleOrDefault(p => p.Id == Dt.Id_Dto);
            if (Dt.Img_Dto != null)
            {
                Delete del = new Delete(en);
                del.Delete_Image(find.Image);

                Upload m = new(en);
                find.Image = m.Upload_Webp_Thumb(Dt.Img_Dto, "Admin\\Serrvices", 100).Result;
            }
            else
            {
                find.Image = find.Image; 
            }
            find.Description = Dt.Description_Dto;
            find.Title = Dt.Title_Dto;
            db.tbl_Serrvices.Update(find);
            db.SaveChanges();
            return true;
        }
    }
}