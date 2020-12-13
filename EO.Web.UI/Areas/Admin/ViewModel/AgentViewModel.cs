using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EO.Web.UI.Areas.Admin.ViewModel
{
    public class AgentViewModel
    {
        public IEnumerable<Agent> Agents { get; set; }
        public Agent Agent { get; set; }

    }
}
