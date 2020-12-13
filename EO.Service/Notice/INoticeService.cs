using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EO.Service
{
    public interface INoticeService
    {
        void Add(Notice notice);
        void Update(Notice notice);
        void Delete(Notice notice);
        Notice GetById(int id);
        IEnumerable<Notice> GetAll();
        IQueryable<Notice> GetAllInclude(int? id);
    }
}
