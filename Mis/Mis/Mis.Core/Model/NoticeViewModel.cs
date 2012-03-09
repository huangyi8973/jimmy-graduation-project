using System;
using System.Web;
namespace Mis.Core.Model
{
    public class NoticeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string CreateTime { get; set; }
        public string UserName { get; set; }
    }
}
