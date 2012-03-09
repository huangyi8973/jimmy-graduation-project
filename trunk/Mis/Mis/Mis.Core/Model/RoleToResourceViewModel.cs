using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Model
{
    public class RoleToResourceViewModel
    {
        public RoleToResourceViewModel()
        {
            this.canAdd = false;
            this.canView = false;
            this.canDel = false;
            this.canDetail = false;
            this.canEdit = false;
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }

        private int value;

        public int Value
        {
            get {   ValueProcess(); return value; }
            set
            {
                this.value = value;
                Process();
            }
        }


        private void Process()
        {

            if ((value & Premission.VIEW) == Premission.VIEW)
            {
                this.canView = true;
            }

            if ((value & Premission.ADD) == Premission.ADD)
            {
                this.canAdd = true;
            }

            if ((value & Premission.EDIT) == Premission.EDIT)
            {
                this.canEdit = true;
            }

            if ((value & Premission.DEL) == Premission.DEL)
            {
                this.canDel = true;
            }
            if((value&Premission.DETAIL)==Premission.DETAIL)
            {
                this.canDetail = true;
            }
        }

        public bool CanView
        {
            get { return canView; }
            set
            {
                canView = value;
            }
        }

        public bool CanEdit
        {
            get { return canEdit; }
            set { canEdit = value; }
        }

        public bool CanDel
        {
            get { return canDel; }
            set { canDel = value;  }
        }

        public bool CanAdd
        {
            get { return canAdd; }
            set { canAdd = value;  }
        }

        private bool canView;
        private bool canEdit;
        private bool canDel;
        private bool canAdd;
        private bool canDetail;

        public bool CanDetail
        {
            get { return canDetail; }
            set { canDetail = value; }
        }

        private void ValueProcess()
        {
            int view = canView ? Premission.VIEW : 0;
            int add = canAdd ?  Premission.ADD : 0;
            int edit = canEdit ?  Premission.EDIT: 0;
            int del = canDel ?  Premission.DEL : 0;
            int detail = canDetail ? Premission.DETAIL : 0;
            this.value = view | add | edit | del | detail;
        }
    }
}
