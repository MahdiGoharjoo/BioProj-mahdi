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
    public class RComments : IComments
    {
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RComments(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public bool Add(Comments_Dto Dt)
        {
            if (Dt != null)
            {
                try
                {
                    Tbl_Comments tb = new Tbl_Comments();
                    tb.CommentDescription = Dt.CommentDescription_Dto;
                    tb.CustommerName = Dt.CustommerName_Dto;
                    tb.CustommerRole = Dt.CustommerRole_Dto;
                    tb.Image = Dt.Image_Dto;
                    if (Dt.Img_Dto != null)
                    {
                        Upload upload = new Upload(en);
                        tb.Image = upload.Upload_Webp_Thumb(Dt.Img_Dto, "admin/Comments", 60).Result;

                    }
                    db.tbl_Comments.Add(tb);
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
                    var find = db.tbl_Comments.SingleOrDefault(p => p.Id == id);
                    Delete del = new Delete(en);
                    del.Delete_Image(find.Image);
                    db.tbl_Comments.Remove(find);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
        }

        public Comments_Dto Find(long id)
        {
            var data = db.tbl_Comments.SingleOrDefault(p => p.Id == id);
            Comments_Dto comments_Dto = new Comments_Dto()
            {
                Id_Dto = data.Id,
                CommentDescription_Dto = data.CommentDescription,
                CustommerName_Dto = data.CustommerName,
                CustommerRole_Dto = data.CustommerRole,
                Image_Dto = data.Image,

            };
            return comments_Dto;
        }

        public List<Comments_Dto> ShowAdmin()
        {
            var all = db.tbl_Comments.ToList();
            List<Comments_Dto> comments_Dtos = new List<Comments_Dto>();
            foreach (var item in all)
            {
                Comments_Dto dt = new Comments_Dto()
                {
                    Id_Dto = item.Id,
                    CommentDescription_Dto = item.CommentDescription,
                    CustommerName_Dto = item.CustommerName,
                    CustommerRole_Dto = item.CustommerRole,
                    Image_Dto = item.Image,
                };
                comments_Dtos.Add(dt);
            }
            return comments_Dtos;
        }

        public List<Comments_Dto> ShowClient()
        {
            var all = db.tbl_Comments.ToList();
            List<Comments_Dto> comments_Dtos = new List<Comments_Dto>();
            foreach (var item in all)
            {
                Comments_Dto dt = new Comments_Dto()
                {
                    Id_Dto = item.Id,
                    CommentDescription_Dto = item.CommentDescription,
                    CustommerName_Dto = item.CustommerName,
                    CustommerRole_Dto = item.CustommerRole,
                    Image_Dto = item.Image,
                };
                comments_Dtos.Add(dt);
            }
            return comments_Dtos;
        }

        public bool Status(long id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comments_Dto Dt)
        {
            var find = db.tbl_Comments.SingleOrDefault(p => p.Id == Dt.Id_Dto);
            if (Dt.Img_Dto != null)
            {
                Delete del = new Delete(en);
                del.Delete_Image(find.Image);

                Upload m = new(en);
                find.Image = m.Upload_Webp_Thumb(Dt.Img_Dto, "Admin\\Comments", 100).Result;
            }
            else
            {
                find.Image = find.Image; 
            }
            find.CommentDescription = Dt.CommentDescription_Dto;
            find.CustommerName = Dt.CustommerName_Dto;
            find.CustommerRole = Dt.CustommerRole_Dto;
            db.tbl_Comments.Update(find);
            db.SaveChanges();
            return true;
        }
    }
}