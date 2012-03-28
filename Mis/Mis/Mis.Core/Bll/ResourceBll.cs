using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Dal;
using Mis.Core.Entity;
using Mis.Core.Model;

namespace Mis.Core.Bll
{
    public class ResourceBll:IBll<ResourceViewModel>
    {
        private ResourceDao resourceDao = null;
        private RoleToResourceDao rrDao = null;
        private RoleDao roleDao = null;
        public ResourceBll()
        {
               this.resourceDao=new ResourceDao();
               this.rrDao = new RoleToResourceDao();
                this.roleDao=new RoleDao();
        }
        
        public List<ResourceViewModel> GetList()
        {
            var resourceEntities = resourceDao.Find();
            var vmlist = resourceEntities.Select(m => new ResourceViewModel
                                                          {
                                                              CanShowInNav = m.CanShowInNav == 1 ? true : false,
                                                              ResourceId = m.Id,
                                                              ResourceName = m.ResourceName,
                                                              Uri = m.Uri,
                                                              Value = m.OperateValue
                                                          }).ToList();
            return vmlist;
        }

        public void Add(ResourceViewModel vm)
        {
            var resourceEntity = new ResourceEntity
                                     {
                                         CanShowInNav = vm.CanShowInNav ? 1 : 0,
                                         ResourceName = vm.ResourceName,
                                         Uri = vm.Uri,
                                         OperateValue = vm.Value
                                     };
            resourceDao.Add(resourceEntity);
        }

        public ResourceViewModel GetModel(int id)
        {
            var entity = resourceDao.GetEntity(id);
            var vm = new ResourceViewModel
                         {
                             ResourceId = entity.Id,
                             ResourceName = entity.ResourceName,
                             CanShowInNav = entity.CanShowInNav == 1 ? true : false,
                             Uri = entity.Uri,
                             Value = entity.OperateValue
                         };
            return vm;
        }

        public RoleToResourceViewModel GetPremissionModel(int id)
        {
            var entity = rrDao.GetEntity(id);
            var vm = new RoleToResourceViewModel
                         {
                             ResourceId = entity.ResourceId,
                             RoleId = entity.RoleId,
                             Value = entity.Value,
                             Id = entity.Id
                         };
            return vm;
        }

        public RoleToResourceViewModel GetPremissionViewModelById(int id)
        {
            var entity = rrDao.GetEntity(id);
            var premissonEntity = resourceDao.GetEntity(entity.ResourceId);
            var vm = new RoleToResourceViewModel
                         {
                             ResourceId = entity.ResourceId,
                             Value = entity.Value,
                             Id = entity.Id,
                             ResourceName = premissonEntity.ResourceName,
                             RoleId =entity.RoleId,
                         };
            return vm;

        }


        public void Update(ResourceViewModel vm)
        {
            var entity = new ResourceEntity
                             {
                                 Id = vm.ResourceId,
                                 CanShowInNav = vm.CanShowInNav ? 1 : 0,
                                 ResourceName = vm.ResourceName,
                                 Uri = vm.Uri,
                                 OperateValue = vm.Value
                             };
            resourceDao.Update(entity);
        }
        
        public void Del(int id)
        {
            var result = rrDao.Find(new RoleToResourceEntity
                                        {
                                            Id = id
                                        });

            foreach (var roleToResourceEntity in result)
            {
                rrDao.Del(roleToResourceEntity);
            }

            resourceDao.Del(id);
        }

        public List<ResourceEntity> GetResourceWithoutRoleId(int roleId)
        {
            var rrList = rrDao.Find(new RoleToResourceEntity
                                        {
                                            RoleId = roleId
                                        });
            var resourceList = resourceDao.Find();

            List<int> deleteId= (from resourceEntity in resourceList
                                 from rr in rrList
                                 where rr.ResourceId == resourceEntity.Id
                                 select resourceEntity.Id).ToList();
            foreach (var i in deleteId)
            {
                resourceList.RemoveAll(entity => entity.Id == i);
            }
            return resourceList.ToList();

        }

        public List<RoleToResourceViewModel> GetPremissionByRoleId(int roleId)
        {
            List<RoleToResourceViewModel> list=new List<RoleToResourceViewModel>();
            var entities = rrDao.Find(new RoleToResourceEntity {RoleId = roleId});

            foreach (var entity in entities)
            {
                var role = roleDao.GetEntity(entity.RoleId);
                var resource = resourceDao.GetEntity(entity.ResourceId);
                var vm = new RoleToResourceViewModel
                             {
                                 Id = entity.Id,
                                 RoleId = entity.RoleId,//这个貌似没用
                                 RoleName = role.RoleName,//这个貌似也没用
                                 ResourceId = entity.ResourceId,
                                 ResourceName = resource.ResourceName,
                                 Value = entity.Value
                             };
                list.Add(vm);
            }
            return list;
        }

        public void PremissionDel(int id)
        {

            rrDao.Del(id);
        }

        public void PremissionAdd(RoleToResourceViewModel vm)
        {
            var entity = new RoleToResourceEntity
                             {
                                 ResourceId = vm.ResourceId,
                                 RoleId = vm.RoleId,
                                 Value = vm.Value
                             };
            rrDao.Add(entity);
        }
        
        public void PremissionUpdate(RoleToResourceViewModel vm)
        {
            var entity = new RoleToResourceEntity
                             {
                                 Id=vm.Id,
                                 ResourceId = vm.ResourceId,
                                 RoleId = vm.RoleId,
                                 Value = vm.Value
                             };
            rrDao.Update(entity);
        }

    }

}
