using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Model
{
    [Serializable]
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
