using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Model
{
    public class LogViewModel
    {
        private int id;
        private string message;
        private string userName;
        private string logTime;

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

        public string LogTime
        {
            get { return logTime; }
            set { logTime = value; }
        }
    }
}
