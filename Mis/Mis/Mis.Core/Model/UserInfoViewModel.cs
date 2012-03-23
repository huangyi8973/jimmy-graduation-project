using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Model
{
    public class UserInfoViewModel
    {
        private int id;
        private int userId;
        private string realName;
        private string birthday;
        private string phoneNumber;
        private string sex;
        private int deptId;
        private string position;
        private string deptName;
        private string userName;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public int DeptId
        {
            get { return deptId; }
            set { deptId = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
