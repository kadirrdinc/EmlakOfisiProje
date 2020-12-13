using EO.Core.Repository;
using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EO.Service
{
    public class NoticeService : INoticeService
    {
        private readonly IRepository<Notice> _repository;
        public NoticeService(IRepository<Notice> repository)
        {
            _repository = repository;
        }
        public void Add(Notice notice)
        {
            _repository.Add(notice);
        }

        public void Delete(Notice notice)
        {
            _repository.Delete(notice);
        }

        public IEnumerable<Notice> GetAll()
        {
            var noticeList = _repository.GetAll();
            return noticeList;
        }

        public IQueryable<Notice> GetAllInclude(int? id)
        {

            var includeList = _repository.Include(x => x.Agent).Where(x => x.AgentId == id).AsQueryable();
            return includeList;
        }

        public Notice GetById(int id)
        {
            //var notice = _repository.Find(id);
            var notice = _repository.Get(x => x.Id == id);
            return notice;
        }

        public void Update(Notice notice)
        {
            _repository.Update(notice);
        }
    }
}
