using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO.Service
{
    public interface IAdminService
    {
        void Add(AdminUser admin);
        void Update(AdminUser admin);
        void Delete(AdminUser admin);
        AdminUser GetById(int id);
        AdminUser GetByUserName(string userName);
        IEnumerable<AdminUser> GetAll();
        AdminUser Login(string userName, string password);
    }
}
