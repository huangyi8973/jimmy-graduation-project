using System.Collections.Generic;

namespace Mis.Core.Dal
{
    public interface IDao<T>
    {
        /// <summary>
        /// 执行更新操作
        /// </summary>
        /// <param name="obj">实体实例</param>
        /// <returns>受影响的行数</returns>
        int Update(T obj);

        /// <summary>
        /// 执行添加操作
        /// </summary>
        /// <param name="obj">实体实例</param>
        /// <returns>受影响的行数</returns>
        int Add(T obj);

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="IdList">ID列表</param>
        /// <returns>受影响的行数</returns>
        int Del(params int[] IdList);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns>数据集</returns>
        List<T> Find();

        /// <summary>
        /// 带翻页的查询
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="pagesize">每页的数据条数</param>
        /// <returns>数据集</returns>
        List<T> Find(int page, int pagesize);

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>实体</returns>
        T GetEntity(int Id);

        /// <summary>
        /// 带条件的翻页查询
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="pagesize">每页的数据条数</param>
        /// <param name="obj">查询条件的实体</param>
        /// <returns>数据集</returns>
        List<T> Find(int page, int pagesize, T obj);

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="obj">查询条件的实体</param>
        /// <returns></returns>
        List<T> Find(T obj);

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Del(T obj);
        /// <summary>
        /// 查询是否存在相同数据
        /// </summary>
        /// <param name="obj">实体</param>
        /// <returns></returns>
        bool IsExist(T obj);
    }
}