using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Entity;

namespace Mis.Core.Model
{

    public class ResourceViewModel
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string Uri { get; set; }
        public bool CanShowInNav { get; set; }
        private int _value;
        public int Value
        {
            get
            {
                ValueProcess(); 
                return this._value;
            }
            set
            {
                this._value = value;
                Process(value);
            }
        }

        public ResourceViewModel()
        {
            this.canAdd = false;
            this.canView = false;
            this.canDel = false;
            this.canEdit = false;
            this.canDetail = false;
        }

        private void Process(int value)
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
            if ((value & Premission.DETAIL) == Premission.DETAIL)
            {
                this.canDetail = true;
            }
        }

        private bool canView;

        private bool canAdd;

        private bool canEdit;

        private bool canDel;

        private bool canDetail;

        public bool CanView
        {
            get { return canView; }
            set { canView = value; }
        }

        public bool CanAdd
        {
            get { return canAdd; }
            set { canAdd = value; }
        }

        public bool CanEdit
        {
            get { return canEdit; }
            set { canEdit = value; }
        }

        public bool CanDel
        {
            get { return canDel; }
            set { canDel = value; }
        }

        public bool CanDetail
        {
            get { return canDetail; }
            set { canDetail = value; }
        }
        private void ValueProcess()
        {
            int view = canView ? Premission.VIEW : 0;
            int add = canAdd ? Premission.ADD : 0;
            int edit = canEdit ? Premission.EDIT : 0;
            int del = canDel ? Premission.DEL : 0;
            int detail = canDetail ? Premission.DETAIL : 0;
            this._value = view | add | edit | del | detail;
        }
    }
}
