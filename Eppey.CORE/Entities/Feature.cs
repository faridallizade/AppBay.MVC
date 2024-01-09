using Eppey.CORE.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eppey.CORE.Entities
{
    public class Feature : BaseAudiTableEntity
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
