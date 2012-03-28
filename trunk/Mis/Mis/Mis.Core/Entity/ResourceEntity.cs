using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Entity
{
    public class ResourceEntity
    {
        public int Id { get; set;}
        public string ResourceName { get; set; }
        public string Uri { get; set; }
        public int OperateValue { get; set; }
        public int CanShowInNav { get; set; }
    }
}
