using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mis.Core.Entity
{
    public class NoticeEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserName { get; set; }
    }
}
