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
    public class RBlog : IBlog
    {
        
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RBlog(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public bool Add(Blog_Dto Dt)
        { if (Dt != null)
            {
                try
                {
                    Tbl_Blog tb = new Tbl_Blog();
                    tb.Title = Dt.Title_Dto;
                    tb.Date = Dt.Date_Dto;
                    tb.Description = Dt.Description_Dto;
                    tb.Image = Dt.Image_Dto;
                    if (Dt.Img_Dto != null)
                    {
                        Upload upload = new Upload(en);
                        tb.Image = upload.Upload_Webp_Thumb(Dt.Img_Dto, "admin/ُBlog", 1650).Result;

                    }
                    db.tbl_Blog.Add(tb);
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
                    var find = db.tbl_Blog.SingleOrDefault(p => p.Id == id);
                    Delete del = new Delete(en);
                    del.Delete_Image(find.Image);
                    db.tbl_Blog.Remove(find);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
        }

        public Blog_Dto Find(long id)
        {
            var data = db.tbl_Blog.SingleOrDefault(p => p.Id == id);
            Blog_Dto blog_Dto = new Blog_Dto()
            {
                Id_Dto = data.Id,
                Description_Dto = data.Description,
                Title_Dto = data.Title,
                Date_Dto = data.Date,
                Image_Dto = data.Image,

            };
            return blog_Dto;
        }

        public List<Blog_Dto> ShowAdmin()
        {
            var all = db.tbl_Blog.ToList();
            List<Blog_Dto> blog_Dtos = new List<Blog_Dto>();
            foreach (var item in all)
            {
                Blog_Dto dt = new Blog_Dto()
                {
                    Id_Dto = item.Id,
                    Description_Dto = item.Description,
                    Date_Dto = item.Date,
                    Title_Dto = item.Title,
                    Image_Dto = item.Image,
                };
                blog_Dtos.Add(dt);
            }
            return blog_Dtos;
        }

        public List<Blog_Dto> ShowClient()
        {
            var all = db.tbl_Blog.ToList();
            List<Blog_Dto> blog_Dtos = new List<Blog_Dto>();
            foreach (var item in all)
            {
                Blog_Dto dt = new Blog_Dto()
                {
                    Id_Dto = item.Id,
                    Description_Dto = item.Description,
                    Date_Dto = item.Date,
                    Title_Dto = item.Title,
                    Image_Dto = item.Image,
                };
                blog_Dtos.Add(dt);
            }
            return blog_Dtos;
        }

        public bool Status(long id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Blog_Dto Dt)
        {
            var find = db.tbl_Blog.SingleOrDefault(p => p.Id == Dt.Id_Dto);
            if (Dt.Img_Dto != null)
            {
                Delete del = new Delete(en);
                del.Delete_Image(find.Image);

                Upload m = new(en);
                find.Image = m.Upload_Webp_Thumb(Dt.Img_Dto, "Admin\\Blog", 1650).Result;
            }
            else
            {
                find.Image = find.Image; 
            }
            find.Description = Dt.Description_Dto;
            find.Date = Dt.Date_Dto;
            find.Title = Dt.Title_Dto;
            db.tbl_Blog.Update(find);
            db.SaveChanges();
            return true;
        }
    }
}