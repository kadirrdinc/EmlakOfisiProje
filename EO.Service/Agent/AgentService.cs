using EO.Core.Repository;
using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO.Service
{
    public class AgentService : IAgentService
    {
        private readonly IRepository<Agent> _repository;
        public AgentService(IRepository<Agent> repository)
        {
            _repository = repository;
        }

        public void Add(Agent agent)
        {
            _repository.Add(agent);
        }

        public void Delete(Agent agent)
        {
            _repository.Delete(agent);
        }

        public IEnumerable<Agent> GetAll()
        {
            var agentList = _repository.GetAll();
            return agentList;
        }

        public Agent GetById(int id)
        {
            //var getAgent = _repository.Find(id);
            var getAgent = _repository.Get(x => x.Id == id);
            return getAgent;
        }

        public Agent Login(string userName, string password)
        {
            var agent = _repository.Get(x => x.UserName == userName && x.Password == password);
            return agent;
        }

        public void Update(Agent agent)
        {
            _repository.Update(agent);
        }
    }
}
