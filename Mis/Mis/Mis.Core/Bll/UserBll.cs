using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Dal;
using Mis.Core.Entity;
using Mis.Core.Model;
using Mis.Core.Utilty;

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
            List<UserViewModel> userList = new List<UserViewModel>();
            //获取所有用户实体
            List<UserEntity> userEntities = userDao.Find();
            foreach (var userEntity in userEntities)
            {
                List<int> roleIds=new List<int>();
                List<string> roleNames = new List<string>();
                //获取用户对应的角色信息
                List<UserToRoleEntity> urEntities = urDao.Find(new UserToRoleEntity {UserId = userEntity.Id});
                foreach (UserToRoleEntity userToRoleEntity in urEntities)
                {
                    RoleEntity roleEntity = roleDao.Find(new RoleEntity { Id = userToRoleEntity.RoleId }).FirstOrDefault();
                    if (roleEntity != null)
                    {
                        roleIds.Add(roleEntity.Id);
                        roleNames.Add(roleEntity.RoleName);
                    }
                }
                
                UserViewModel vm = new UserViewModel
                                     {
                                         UserId = userEntity.Id,
                                         UserName = userEntity.UserName,
                                         RoleIds = roleIds.ToArray(),
                                         RoleNames = roleNames.ToArray()
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
                                            Password = MD5Tool.Parse(vm.Password)
                                        };
            if (userDao.IsExist(userEntity))
            {
                throw new Exception("该用户已经存在");
            }
            else
            {
                int insertedId = userDao.Add(userEntity);
                foreach (int roleId in vm.RoleIds)
                {
                    var userToRoleEntity = new UserToRoleEntity
                    {
                        UserId = insertedId,
                        RoleId = roleId
                    };
                    urDao.Add(userToRoleEntity);
                }

            }
        }


        public UserViewModel GetModel(int id)
        {
            UserViewModel vm = new UserViewModel();
            UserEntity userEntity = userDao.GetEntity(id);
            if (null != userEntity)
            {
                UserToRoleDao dao = new UserToRoleDao();
                List<UserToRoleEntity> urEntities = dao.GetEntitiesByUserId(userEntity.Id);
                List<int> roleIds=new List<int>();
                List<string> roleNames=new List<string>();
                if (null != urEntities&&urEntities.Count>0)
                {
                    foreach(UserToRoleEntity entity in urEntities)
                    {
                        RoleEntity roleEntity = roleDao.GetEntity(entity.RoleId);
                        if(roleEntity!=null)
                        {
                            roleIds.Add(roleEntity.Id);
                            roleNames.Add(roleEntity.RoleName);
                        }
                    }
                }
                vm.UserId = userEntity.Id;
                vm.UserName = userEntity.UserName;
                vm.RoleIds = roleIds.ToArray();
                vm.RoleNames = roleNames.ToArray();
                //vm.UserToRoleId = urEntities.Id;
            }
            return vm;
        }

        public void Update(UserViewModel vm)
        {
            //数据库中用户的角色信息
            List<UserToRoleEntity> urEntities = urDao.Find(new UserToRoleEntity
                                                               {
                                                                   UserId = vm.UserId
                                                               });
            //编辑过后用户的角色信息
            List<int> roleIds = new List<int>(vm.RoleIds);
            //待删除的角色信息
            List<int> delUREntityIds;
            //新增的角色信息
            List<int> addRoleIds;
            //数据库中改用户已拥有的角色ID
            List<int> roleIdsInDB = new List<int>(urEntities.Select(m => m.RoleId));
            //比较已有角色信息和编辑后的角色信息
            UserToRoleCompare(roleIdsInDB,roleIds,out delUREntityIds,out addRoleIds);
            
            //删除不再拥有的角色
            foreach(int roleId in delUREntityIds)
            {
                urDao.Del(new UserToRoleEntity {RoleId = roleId, UserId = vm.UserId});
            }
            //新增用户角色信息
            foreach(int roleId in addRoleIds)
            {
                urDao.Add(new UserToRoleEntity {RoleId = roleId, UserId = vm.UserId});
            }
        }

        /// <summary>
        /// 比较数据库中的角色信息和编辑过后的角色信息，计算出需要删除和新增的角色信息
        /// </summary>
        /// <param name="roleIdsInDB"></param>
        /// <param name="roleIds"></param>
        /// <param name="delUREntityIds"></param>
        /// <param name="addRoleIds"></param>
        private void UserToRoleCompare(List<int> roleIdsInDB,List<int> roleIds,out List<int> delUREntityIds,out List<int> addRoleIds)
        {
            delUREntityIds = new List<int>(roleIdsInDB);
            addRoleIds = new List<int>(roleIds);
            if (roleIdsInDB != null)
            {
                foreach (int roleId in roleIds)
                {
                    //如果角色信息没有改变，就从列表里删除
                    if (roleIdsInDB.Contains(roleId))
                    {
                        addRoleIds.Remove(roleId);
                        delUREntityIds.Remove(roleId);
                    }
                }
            }
            
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

        public bool initUserPassword(int userId)
        {
            //默认密码为123
            UserDao userDao=new UserDao();
            return userDao.Update(new UserEntity {Id = userId, Password = MD5Tool.Parse("123")})>0;
        }
    }
}
