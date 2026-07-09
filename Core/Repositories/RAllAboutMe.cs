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
using WebCore.Tools;

namespace Core.Repositories
{
    public class RAllAboutMe : IAllAboutMe
    {
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RAllAboutMe(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public bool Add(AllAboutMe_Dto Dt)
        {

            if (Dt != null)
            {
                try
                {
                    Tbl_AllAboutMe tb = new Tbl_AllAboutMe();
                    tb.Date = Dt.Date_Dto;
                    tb.Description = Dt.Description_Dto;
                    tb.ProjectName = Dt.ProjectName_Dto;
                    tb.Title = Dt.Title_Dto;
                    tb.Outline = Dt.Outline_Dto;
                    tb.Image = Dt.Image_Dto;
                    if (Dt.Img_Dto != null)
                    {
                        Upload upload = new Upload(en);
                        tb.Image = upload.Upload_Webp_Thumb(Dt.Img_Dto, "admin/AllAboutMe", 1650).Result;

                    }
                    db.tbl_Allaboutme.Add(tb);
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
                    var find = db.tbl_Allaboutme.SingleOrDefault(p => p.Id == id);
                    Delete del = new Delete(en);
                    del.Delete_Image(find.Image);
                    db.tbl_Allaboutme.Remove(find);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
        }

        public AllAboutMe_Dto Find(long id)
        {
            var data = db.tbl_Allaboutme.SingleOrDefault(p => p.Id == id);
            AllAboutMe_Dto allAboutMe_Dto = new AllAboutMe_Dto()
            {
                Id_Dto = data.Id,
                Date_Dto = data.Date,
                Description_Dto = data.Description,
                ProjectName_Dto = data.ProjectName,
                Title_Dto = data.Title,
                Outline_Dto = data.Outline,
                Image_Dto = data.Image,

            };
            return allAboutMe_Dto;
        }

        public List<AllAboutMe_Dto> ShowAdmin()
        {
            var all = db.tbl_Allaboutme.ToList();
            List<AllAboutMe_Dto> allAboutMe_Dtos = new List<AllAboutMe_Dto>();
            foreach (var item in all)
            {
                AllAboutMe_Dto dt = new AllAboutMe_Dto()
                {
                    Id_Dto = item.Id,
                    Date_Dto = item.Date,
                    Description_Dto = item.Description,
                    ProjectName_Dto = item.ProjectName,
                    Title_Dto = item.Title,
                    Outline_Dto = item.Outline,
                    Image_Dto = item.Image,
                };
                allAboutMe_Dtos.Add(dt);
            }
            return allAboutMe_Dtos;
        }

        public List<AllAboutMe_Dto> ShowClient()
        {
            var all = db.tbl_Allaboutme.ToList();
            List<AllAboutMe_Dto> allAboutMe_Dtos = new List<AllAboutMe_Dto>();
            foreach (var item in all)
            {
                AllAboutMe_Dto dt = new AllAboutMe_Dto()
                {
                    Id_Dto = item.Id,
                    Date_Dto = item.Date,
                    Description_Dto = item.Description,
                    ProjectName_Dto = item.ProjectName,
                    Title_Dto = item.Title,
                    Outline_Dto = item.Outline,
                    Image_Dto = item.Image,
                };
                allAboutMe_Dtos.Add(dt);
            }
            return allAboutMe_Dtos;
        }


        public bool Update(AllAboutMe_Dto Dt)
        {
            var find = db.tbl_Allaboutme.SingleOrDefault(p => p.Id == Dt.Id_Dto);
            if (Dt.Img_Dto != null)
            {
                Delete del = new Delete(en);
                del.Delete_Image(find.Image);

                Upload m = new(en);
                find.Image = m.Upload_Webp_Thumb(Dt.Img_Dto, "Admin\\AllAboutMe", 100).Result;
            }
            else
            {
                find.Image = find.Image; 
            }
            find.Date = Dt.Date_Dto;
            find.ProjectName = Dt.ProjectName_Dto;
            find.Description = Dt.Description_Dto;
            find.Title = Dt.Title_Dto;
            find.Outline = Dt.Outline_Dto;
            db.tbl_Allaboutme.Update(find);
            db.SaveChanges();
            return true;
        }
    }
}