using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO.Service
{
    public interface IAgentService
    {
        void Add(Agent agent);
        void Update(Agent agent);
        void Delete(Agent agent);
        Agent GetById(int id);
        IEnumerable<Agent> GetAll();
        Agent Login(string userName, string password);

    }
}
