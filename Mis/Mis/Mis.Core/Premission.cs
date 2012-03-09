using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Model;
using Mis.Core.Utilty;

namespace Mis.Core
{
    public class Premission
    {
        public bool Check(UserCacheModel userCacheModel, string path)
        {
            bool IsPass = false;
            string controller = "";
            string action = "";

            //把处理地址，分解成controller和action
            UrlTools.UrlSplit(path,out controller,out action);
            if (userCacheModel.PremissionList != null)
            {
                var result = userCacheModel.PremissionList.FirstOrDefault(p => p.Uri.Equals(controller.ToLower()));
                if (null != result)
                {
                    switch (action)
                    {
                        case "index":
                            IsPass = result.CanView;
                            break;
                        case "add":
                            IsPass = result.CanAdd;
                            break;
                        case "edit":
                            IsPass = result.CanEdit;
                            break;
                        case "del":
                            IsPass = result.CanView;
                            break;
                        case "detail":
                            IsPass = result.CanDetail;
                            break;
                    }
                }
            }
            return IsPass;
        }

        public static readonly int VIEW = 1;
        public static readonly int ADD = 2;
        public static readonly int EDIT = 4;
        public static readonly int DEL = 8;
        public static readonly int DETAIL = 16;


    }
}
