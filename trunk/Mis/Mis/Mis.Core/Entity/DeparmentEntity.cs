using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Entity
{
    public class DeparmentEntity
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
