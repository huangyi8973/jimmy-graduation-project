using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Entity
{
    class RoleToResourceEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ResourceId { get; set; }
        public int Value { get; set; }
    }
}
