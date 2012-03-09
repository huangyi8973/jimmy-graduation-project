using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Entity;

namespace Mis.Core.Model
{

    public class UserViewModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public int UserToRoleId { get; set; }
    }
}
