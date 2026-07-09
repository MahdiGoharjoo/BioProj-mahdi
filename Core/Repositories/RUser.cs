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

namespace Core.Repositories;

public class RUser : IUser
{
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RUser(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }

    public bool Add(User_Dto Dt)
    {

            if (Dt != null)
            {
                try
                {
                    Tbl_User tb = new Tbl_User();
                    tb.FullName = Dt.FullName_Dto;
                    tb.Password = Dt.Password_Dto;
                    tb.UserName = Dt.UserName_Dto;
                    db.tbl_Users.Add(tb);
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
                    var find = db.tbl_Users.SingleOrDefault(p => p.Id == id);
                    Delete del = new Delete(en);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
    }

    public User_Dto Find(long id)
    {
            var data = db.tbl_Users.SingleOrDefault(p => p.Id == id);
            User_Dto user_Dto = new User_Dto()
            {
                Id_Dto = data.Id,
                FullName_Dto = data.FullName,
                Password_Dto = data.Password,
                UserName_Dto = data.UserName

            };
            return user_Dto;
    }

    public List<User_Dto> ShowAdmin()
    {
            var all = db.tbl_Users.ToList();
            List<User_Dto> user_Dtos = new List<User_Dto>();
            foreach (var item in all)
            {
                User_Dto dt = new User_Dto()
                {
                Id_Dto = item.Id,
                FullName_Dto = item.FullName,
                Password_Dto = item.Password,
                UserName_Dto = item.UserName
                };
                user_Dtos.Add(dt);
            }
            return user_Dtos;
    }

    public List<User_Dto> ShowClient()
    {
            var all = db.tbl_Users.ToList();
            List<User_Dto> user_Dtos = new List<User_Dto>();
            foreach (var item in all)
            {
                User_Dto dt = new User_Dto()
                {
                Id_Dto = item.Id,
                FullName_Dto = item.FullName,
                Password_Dto = item.Password,
                UserName_Dto = item.UserName
                };
                user_Dtos.Add(dt);
            }
            return user_Dtos;
    }

    public bool Update(User_Dto Dt)
    {
            var find = db.tbl_Users.SingleOrDefault(p => p.Id == Dt.Id_Dto);
            find.FullName = Dt.FullName_Dto;
            find.Password = Dt.Password_Dto;
            find.UserName = Dt.UserName_Dto;
            db.tbl_Users.Update(find);
            db.SaveChanges();
            return true;
    }
}