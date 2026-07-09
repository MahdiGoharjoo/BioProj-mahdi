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
    public class RContactUsClient : IContactUsClient
    {
        private readonly Application db;
        private readonly IWebHostEnvironment en;
        public RContactUsClient(Application _db, IWebHostEnvironment _en)
        {
            db = _db;
            en = _en;
        }
        public bool Add(ContactUsClient_Dto Dt)
        {

            if (Dt != null)
            {
                try
                {
                    Tbl_ContactUsClient tb = new Tbl_ContactUsClient();
                    tb.Name = Dt.Name_Dto;
                    tb.Email = Dt.Email_Dto;
                    tb.Comment = Dt.Comment_Dto;
                    db.tbl_Contactusclients.Add(tb);
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
                    var find = db.tbl_Contactusclients.SingleOrDefault(p => p.Id == id);
                    Delete del = new Delete(en);
                    db.tbl_Contactusclients.Remove(find);
                    db.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    return false;
                }
            }
        }

        public List<ContactUsClient_Dto> Show()
        {
            var all = db.tbl_Contactusclients.ToList();
            List<ContactUsClient_Dto> contactUsClients = new List<ContactUsClient_Dto>();
            foreach (var item in all)
            {
                ContactUsClient_Dto dt = new ContactUsClient_Dto()
                {
                    Id_Dto = item.Id,
                    Name_Dto = item.Name,
                    Email_Dto = item.Email,
                    Comment_Dto = item.Comment,
                };
                contactUsClients.Add(dt);
            }
            return contactUsClients;
        }
    }
}