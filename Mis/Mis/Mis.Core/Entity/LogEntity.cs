using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Entity
{
    public class LogEntity
    {
        private int id;
        private string message;
        private string userName;
        private DateTime logTime;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public DateTime LogTime
        {
            get { return logTime; }
            set { logTime = value; }
        }
    }
}
