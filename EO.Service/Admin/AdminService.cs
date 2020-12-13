using EO.Core.Repository;
using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO.Service
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<AdminUser> _repository;
        public AdminService(IRepository<AdminUser> repository)
        {
            _repository = repository;
        }
        public void Add(AdminUser adminUser)
        {
            _repository.Add(adminUser);
        }

        public void Delete(AdminUser adminUser)
        {
            _repository.Delete(adminUser);
        }

        public IEnumerable<AdminUser> GetAll()
        {
            var adminList = _repository.GetAll(x => x.IsActive == true);
            return adminList;
        }

        public AdminUser GetById(int id)
        {
            //var getAdmin = _repository.Find(id);
            var getAdmin = _repository.Get(x => x.Id == id);
            return getAdmin;
        }

        public AdminUser GetByUserName(string userName)
        {
            var admin = _repository.Get(x => x.UserName == userName);
            return admin;
        }

        public AdminUser Login(string userName, string password)
        {
            var admin = _repository.Get(x => x.UserName == userName && x.Password == password);
            return admin;
        }

        public void Update(AdminUser adminUser)
        {
            _repository.Update(adminUser);
        }
    }
}
