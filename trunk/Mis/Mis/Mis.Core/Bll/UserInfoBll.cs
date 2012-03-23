using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Dal;
using Mis.Core.Entity;
using Mis.Core.Model;

namespace Mis.Core.Bll
{
    public class UserInfoBll : IBll<UserInfoViewModel>
    {
        private UserInfoDao userInfoDao = null;
        private DeparmentBll deparmentBll = null;
        private UserBll userBll = null;
        public UserInfoBll()
        {
            userInfoDao = new UserInfoDao();
            deparmentBll = new DeparmentBll();
            userBll = new UserBll();
        }
        public List<UserInfoViewModel> GetList()
        {
            var entityList = userInfoDao.Find();
            List<UserInfoViewModel> userInfoViewModels=new List<UserInfoViewModel>();
            foreach(var entity in entityList)
            {
                UserInfoViewModel vm = new UserInfoViewModel
                                           {
                                               Birthday = entity.Birthday.ToString(),
                                               DeptId = entity.DeptId,
                                               Id = entity.Id,
                                               PhoneNumber = entity.PhoneNumber,
                                               Position = entity.Position,
                                               RealName = entity.RealName,
                                               Sex = entity.Sex,
                                               UserId = entity.UserId

                                           };
                userInfoViewModels.Add(vm);
            }
            
            var userlist = userBll.GetList();
            var deptList = deparmentBll.GetList();
            foreach (var userInfo in userInfoViewModels)
            {
                userInfo.DeptName = deptList.First(m => m.Id.Equals(userInfo.DeptId)).DeptName;
                userInfo.UserName = userlist.First(m => m.UserId.Equals(userInfo.UserId)).UserName;
            }
            return userInfoViewModels;
        }

        public void Add(UserInfoViewModel vm)
        {
            throw new NotImplementedException();
        }

        public UserInfoViewModel GetModel(int id)
        {
            UserInfoEntity userInfoEntity = userInfoDao.GetEntity(id);
            UserInfoViewModel viewModel = new UserInfoViewModel
                                              {
                                                  Birthday = userInfoEntity.Birthday.ToString(),
                                                  DeptId = userInfoEntity.DeptId,
                                                  Id = userInfoEntity.Id,
                                                  PhoneNumber = userInfoEntity.PhoneNumber,
                                                  Position = userInfoEntity.Position,
                                                  RealName = userInfoEntity.RealName,
                                                  Sex = userInfoEntity.Sex,
                                                  UserId = userInfoEntity.UserId
                                              };
            var user = userBll.GetModel(viewModel.UserId);
            var dept = deparmentBll.GetModel(viewModel.DeptId);

            viewModel.DeptName = dept.DeptName;
            viewModel.UserName = user.UserName;

            return viewModel;
        }

        public void Update(UserInfoViewModel vm)
        {
            UserInfoEntity entity=new UserInfoEntity();
            entity.Birthday = Convert.ToDateTime(vm.Birthday);
            entity.DeptId = vm.DeptId;
            entity.Id = vm.Id;
            entity.PhoneNumber = vm.PhoneNumber;
            entity.Position = vm.Position;
            entity.RealName = vm.RealName;
            entity.Sex = vm.Sex;
            userInfoDao.Update(entity);
        }

        public void Del(int id)
        {
            throw new NotImplementedException();
        }
    }
}
