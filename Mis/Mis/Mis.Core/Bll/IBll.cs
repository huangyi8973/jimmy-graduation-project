using System.Collections.Generic;
using Mis.Core.Model;

namespace Mis.Core.Bll
{
    public interface IBll<T>
    {
        List<T> GetList();
        void Add(T vm);
        T GetModel(int id);
        void Update(T vm);
        void Del(int id);
    }
}