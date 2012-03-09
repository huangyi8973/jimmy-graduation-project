using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Entity;

namespace Mis.Core.Model
{
    
    public class ResourceViewModel
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string Uri { get; set; }
        public bool CanShowInNav { get; set; }
    }
}
