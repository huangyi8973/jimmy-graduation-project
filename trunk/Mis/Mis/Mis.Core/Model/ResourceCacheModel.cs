using System;
using System.Collections.Generic;
using System.Text;
using Mis.Core.Utilty;

namespace Mis.Core.Model
{
    [Serializable]
    public class ResourceCacheModel
    {
        public string ResourceName { get; set; }

        public bool CanShowInNav { get; set; }
        private string uri;
        public string Uri
        {
            get { return uri; }
            set
            {
                this.uri = value;
                UrlTools.UrlSplit(uri, out this.controller, out this.action);
            }
        }

        private string controller;
        public string Controller { get { return controller; } }
        private string action;
        public string Action { get { return action; } }

        private int _value;
        public int Value
        {
            get { return this._value; }
            set
            {
                this._value = value;
                Process(value);
            }
        }

        public ResourceCacheModel()
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
            if((value&Premission.DETAIL)==Premission.DETAIL)
            {
                this.canDetail = true;
            }
        }

        private bool canView;

        public bool CanView
        {
            get { return this.canView; }
        }

        private bool canAdd;
        public bool CanAdd
        {
            get { return this.canAdd; }
        }

        private bool canEdit;
        public bool CanEdit
        {
            get { return this.canEdit; }
        }

        private bool canDel;
        public bool CanDel
        {
            get { return this.canDel; }
        }

        private bool canDetail;

        public bool CanDetail
        {
            get { return canDetail; }
        }
    }
}
