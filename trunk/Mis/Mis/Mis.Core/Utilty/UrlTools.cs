using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Utilty
{
    public class UrlTools
    {
        public static void UrlSplit(string path, out string controller, out string action)
        {
            if (path.StartsWith("/"))
            {
                path = path.Remove(0, 1);
            }
            if (path.Contains("?"))
            {
                path = path.Split('?')[0];
            }
            string[] url = path.Split('/');

            if (url[0].Equals(String.Empty))
            {
                controller = "home";
            }
            else
            {
                controller = url[0].ToLower();
            }

            action = "index";
            if (url.Count() > 1)
            {
                action = url[1].ToLower();
            }
        }
    }
}
