using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Model
{
    public class DeparmentViewModel
    {
        private int id;
        private string deptName;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }
    }
}
