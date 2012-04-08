using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Entity;
using Mis.Core.Dal;
using Mis.Core.Model;

namespace Mis.Core.Bll
{

    public class RoleBll : IBll<RoleViewModel>
    {
        private IDao<RoleEntity> roleDao = null;
        public RoleBll()
        {
            this.roleDao = new RoleDao();
        }
        
        public List<RoleViewModel> GetList()
        {
            var list = roleDao.Find().Select(m => new RoleViewModel
                                                      {
                                                          RoleId = m.Id,
                                                          RoleName = m.RoleName
                                                      }).ToList();
            return list;
        }

        public void Add(RoleViewModel vm)
        {
            var entity = new RoleEntity
                             {
                                 RoleName = vm.RoleName
                             };
            roleDao.Add(entity);
        }

        public RoleViewModel GetModel(int id)
        {
            var result = roleDao.Find(new RoleEntity {Id = id}).FirstOrDefault();
            if (null != result)
            {
                var vm = new RoleViewModel
                             {
                                 RoleId = result.Id,
                                 RoleName = result.RoleName
                             };
                return vm;
            }
            return new RoleViewModel();
        }

        public void Update(RoleViewModel vm)
        {
            RoleEntity entity = new RoleEntity
                                    {
                                        Id = vm.RoleId,
                                        RoleName = vm.RoleName
                                    };
            roleDao.Update(entity);
        }

        public void Del(int Id)
        {
            UserToRoleDao urDao=new UserToRoleDao();
            var urList=urDao.Find(new UserToRoleEntity {RoleId = Id});
            if(urList.Count>0)
            {
                throw new Exception("角色下有用户存在，不能删除角色");
            }
            else
            {
                RoleToResourceDao rrdao=new RoleToResourceDao();
                rrdao.Del(new RoleToResourceEntity
                              {
                                  RoleId = Id
                              });
                roleDao.Del(Id);    
            }
        }
    }
}
