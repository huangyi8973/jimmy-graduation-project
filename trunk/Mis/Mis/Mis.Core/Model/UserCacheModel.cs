using System;
using System.Collections.Generic;
using System.Text;

namespace Mis.Core.Model
{
    [Serializable]
    public class UserCacheModel
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public RoleCacheModel Role { get; set; }
        public List<ResourceCacheModel> PremissionList { get; set; }
    }
}
