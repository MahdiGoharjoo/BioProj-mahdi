using Core.DTOs;
using Core.InterFaces;
using Core.Tools.Upload;
using Data.Context;
using Data.DataBase;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebCore.Tools;


namespace Core.Repositories
{
    public class RFirst : IFirst
    {
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RFirst(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public First_Dto Findforupdate()
        {
            return db.tbl_First.Select(p=> new First_Dto()
            {
                Id_Dto = p.Id,
                Bio1_Dto = p.Bio1,
                Bio2_Dto = p.Bio2,
                Skills_Dto = p.Skills,
                Description_Dto = p.Description,
                Email_Dto = p.Email,
                Phone_Dto = p.Phone,
                Address_Dto = p.Address,
                Image_Dto = p.Image,
            }).First();
        }

        public First_Dto Show()
        {
            return db.tbl_First.Select(p=> new First_Dto()
            {
                Id_Dto = p.Id,
                Bio1_Dto = p.Bio1,
                Bio2_Dto = p.Bio2,
                Skills_Dto = p.Skills,
                Description_Dto = p.Description,
                Email_Dto = p.Email,
                Phone_Dto = p.Phone,
                Address_Dto = p.Address,
                Image_Dto = p.Image,
            }).First();
        }

        public bool Update(First_Dto first)
        {
            var find = db.tbl_First.First();
            if(first.Img_Dto != null)
            {
                Delete del = new Delete(en);
                del.Delete_Image(find.Image);
                Upload m = new Upload(en);
                find.Image = m.Upload_Webp_Thumb(first.Img_Dto , "Admin/First" , 411 ).Result;
            }
            else
            {
                find.Image = find.Image;
            }
            find.Bio1 = first.Bio1_Dto;
            find.Bio2 = first.Bio2_Dto;
            find.Skills = first.Skills_Dto;
            find.Description = first.Description_Dto;
            find.Email = first.Email_Dto;
            find.Address = first.Address_Dto;
            find.Phone = first.Phone_Dto;
            db.tbl_First.Update(find);
            db.SaveChanges();
            return true;
        }
    }

}