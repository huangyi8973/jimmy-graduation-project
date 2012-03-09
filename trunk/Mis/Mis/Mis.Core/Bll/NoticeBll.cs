using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mis.Core.Dal;
using Mis.Core.Entity;
using Mis.Core.Model;

namespace Mis.Core.Bll
{
    public class NoticeBll : IBll<NoticeViewModel>
    {
        private NoticeDao noticeDao = null;

        public NoticeBll()
        {
            this.noticeDao = new NoticeDao();
        }
        public List<NoticeViewModel> GetList()
        {
            var vms = noticeDao.Find().Select(EntityToViewModel);
            return vms.ToList();
        }

        public void Add(NoticeViewModel vm)
        {
            noticeDao.Add(ViewModelToEntity(vm));
        }

        public NoticeViewModel GetModel(int id)
        {
            var entity=noticeDao.GetEntity(id);
            return EntityToViewModel(entity);
        }

        public void Update(NoticeViewModel vm)
        {
            noticeDao.Update(ViewModelToEntity(vm));
        }

        public void Del(int id)
        {
            noticeDao.Del(id);
        }

        private NoticeEntity ViewModelToEntity(NoticeViewModel vm)
        {
            NoticeEntity entity=new NoticeEntity();
            entity.Id = vm.Id;
            if (!String.IsNullOrEmpty(vm.Title))
            {
                entity.Title = vm.Title;
            }
            if(!String.IsNullOrEmpty(vm.Content))
            {
                entity.Content = vm.Content;
            }
            if(String.IsNullOrEmpty(vm.UserName))
            {
                entity.UserName = vm.UserName;
            }
            if(vm.CreateTime!=null)
            {
                entity.CreateTime = DateTime.Parse(vm.CreateTime);
            }
            if(vm.UserName!=null)
            {
                entity.UserName = vm.UserName;
            }
            else
            {
                entity.UserName = "unkonw";
            }
            return entity;
        }

        private NoticeViewModel EntityToViewModel(NoticeEntity entity)
        {
            var vm = new NoticeViewModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                CreateTime =
                    entity.CreateTime.ToString("yyyy-MM-dd hh:mm:ss"),
                UserName = entity.UserName
            };
            return vm;
        }
    }
}
