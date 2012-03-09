using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Dal;
using Mis.Core.Entity;
using Mis.Core.Model;

namespace Mis.Core.Bll
{
    public class UserBll : IBll<UserViewModel>
    {
        private IDao<UserEntity> userDao = null;
        private IDao<RoleEntity> roleDao = null;
        private IDao<UserToRoleEntity> urDao = null;
        public UserBll()
        {
            this.userDao = new UserDao();
            this.roleDao = new RoleDao();
            this.urDao = new UserToRoleDao();
        }

        public List<UserViewModel> GetList()
        {
            List<UserViewModel> userList=new List<UserViewModel>();
            List<UserEntity> userEntities = userDao.Find();
            foreach (var userEntity in userEntities)
            {
                UserToRoleEntity urEntity = urDao.Find(new UserToRoleEntity {UserId = userEntity.Id}).FirstOrDefault();
                RoleEntity roleEntity = roleDao.Find(new RoleEntity {Id = urEntity.RoleId}).FirstOrDefault();
                UserViewModel vm=new UserViewModel
                                     {
                                         UserId = userEntity.Id,
                                         UserName = userEntity.UserName,
                                         RoleId = roleEntity.Id,
                                         RoleName = roleEntity.RoleName
                                     };
                userList.Add(vm);
            }
            return userList;
        }

        public void Add(UserViewModel vm)
        {
            UserEntity userEntity = new UserEntity
                                        {
                                            UserName = vm.UserName,
                                            Password = vm.Password
                                        };
            if (userDao.IsExist(userEntity))
            {
                throw new Exception("该用户已经存在");
            }
            else
            {
                int insertedId = userDao.Add(userEntity);
                var userToRoleEntity = new UserToRoleEntity
                                           {
                                               UserId = insertedId,
                                               RoleId = vm.RoleId
                                           };
                urDao.Add(userToRoleEntity);
            }
        }

        public UserViewModel GetModel(int id)
        {
            UserViewModel vm =new UserViewModel();
            UserEntity userEntity = userDao.GetEntity(id);
            if(null!=userEntity)
            {
                UserToRoleDao dao = new UserToRoleDao();
                UserToRoleEntity urEntity = dao.GetEntityByUserId(userEntity.Id);
                if(null!=urEntity)
                {
                    RoleEntity roleEntity = roleDao.GetEntity(urEntity.RoleId);
                    vm.UserId = userEntity.Id;
                    vm.UserName = userEntity.UserName;
                    vm.RoleId = roleEntity.Id;
                    vm.RoleName = roleEntity.RoleName;
                    vm.UserToRoleId = urEntity.Id;
                }
            }
            return vm;
        }

        public void Update(UserViewModel vm)
        {
            UserToRoleEntity urEntity = new UserToRoleEntity
                                            {
                                                RoleId = vm.RoleId,
                                                UserId = vm.UserId,
                                                Id=vm.UserToRoleId
                                            };
            urDao.Update(urEntity);
        }

        public void Del(int id)
        {
            //先删除UserToRole里的数据
            urDao.Del(new UserToRoleEntity
                          {
                              UserId = id
                          });
            userDao.Del(id);
        }
    }
}
