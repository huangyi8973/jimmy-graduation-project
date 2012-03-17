using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Dal;
using Mis.Core.Model;

namespace Mis.Core.Bll
{
    public class LogBll : IBll<LogViewModel>
    {
        private LogDao dao = new LogDao();
        public List<LogViewModel> GetList()
        {
            List<LogViewModel> list =
                dao.Find().Select(m => new LogViewModel
                                {
                                    Id = m.Id,
                                    Message = m.Message,
                                    LogTime = m.LogTime.ToString(),
                                    UserName = m.UserName
                                }).ToList();
            return list;
        }

        public void Add(LogViewModel vm)
        {
            throw new NotImplementedException();
        }

        public LogViewModel GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(LogViewModel vm)
        {
            throw new NotImplementedException();
        }

        public void Del(int id)
        {
            throw new NotImplementedException();
        }

        public void Clean()
        {
            dao.Clean();
            
        }
    }
}
