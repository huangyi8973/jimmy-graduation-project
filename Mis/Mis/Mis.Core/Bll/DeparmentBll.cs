using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Dal;
using Mis.Core.Entity;
using Mis.Core.Model;

namespace Mis.Core.Bll
{
    public class DeparmentBll : IBll<DeparmentViewModel>
    {
        private DeparmentDao dao = null;
        private UserInfoDao userInfoDao = null;
        public DeparmentBll()
        {
            userInfoDao = new UserInfoDao();
            dao = new DeparmentDao();
        }
        public List<DeparmentViewModel> GetList()
        {
            return dao.Find().Select(m => new DeparmentViewModel
                                            {
                                                Id = m.Id,
                                                DeptName = m.DeptName
                                            }).ToList();
        }

        public void Add(DeparmentViewModel vm)
        {
            DeparmentEntity entity = new DeparmentEntity
                                         {
                                             DeptName = vm.DeptName
                                         };
            dao.Add(entity);
        }

        public DeparmentViewModel GetModel(int id)
        {
            DeparmentEntity entity = dao.GetEntity(id);
            DeparmentViewModel vm = new DeparmentViewModel
                                        {
                                            Id = entity.Id,
                                            DeptName = entity.DeptName
                                        };
            return vm;
        }

        public void Update(DeparmentViewModel vm)
        {
            DeparmentEntity entity = new DeparmentEntity
                                         {
                                             DeptName = vm.DeptName,
                                             Id = vm.Id
                                         };
            dao.Update(entity);
        }

        public void Del(int id)
        {
            var  entities = userInfoDao.Find(new UserInfoEntity {DeptId = id});
            if(entities.Count==0)
            {
                dao.Del(id);
            }
            
        }
    }
}
