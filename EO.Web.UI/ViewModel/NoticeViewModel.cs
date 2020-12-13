using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EO.Web.UI.ViewModel
{
    public class NoticeViewModel
    {
        public IEnumerable<Notice> Notices { get; set; }
        public Notice Notice { get; set; }

    }
}
