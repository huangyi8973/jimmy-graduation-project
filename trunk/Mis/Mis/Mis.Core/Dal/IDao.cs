using System.Collections.Generic;

namespace Mis.Core.Dal
{
    public interface IDao<T>
    {
        /// <summary>
        /// ִ�и��²���
        /// </summary>
        /// <param name="obj">ʵ��ʵ��</param>
        /// <returns>��Ӱ�������</returns>
        int Update(T obj);

        /// <summary>
        /// ִ����Ӳ���
        /// </summary>
        /// <param name="obj">ʵ��ʵ��</param>
        /// <returns>��Ӱ�������</returns>
        int Add(T obj);

        /// <summary>
        /// ɾ��ָ��ID������
        /// </summary>
        /// <param name="IdList">ID�б�</param>
        /// <returns>��Ӱ�������</returns>
        int Del(params int[] IdList);

        /// <summary>
        /// ��ѯȫ��
        /// </summary>
        /// <returns>���ݼ�</returns>
        List<T> Find();

        /// <summary>
        /// ����ҳ�Ĳ�ѯ
        /// </summary>
        /// <param name="page">�ڼ�ҳ</param>
        /// <param name="pagesize">ÿҳ����������</param>
        /// <returns>���ݼ�</returns>
        List<T> Find(int page, int pagesize);

        /// <summary>
        /// ����ID��ȡ����ʵ��
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>ʵ��</returns>
        T GetEntity(int Id);

        /// <summary>
        /// �������ķ�ҳ��ѯ
        /// </summary>
        /// <param name="page">�ڼ�ҳ</param>
        /// <param name="pagesize">ÿҳ����������</param>
        /// <param name="obj">��ѯ������ʵ��</param>
        /// <returns>���ݼ�</returns>
        List<T> Find(int page, int pagesize, T obj);

        /// <summary>
        /// ����������ѯ
        /// </summary>
        /// <param name="obj">��ѯ������ʵ��</param>
        /// <returns></returns>
        List<T> Find(T obj);

        /// <summary>
        /// ��������ɾ������
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Del(T obj);
        /// <summary>
        /// ��ѯ�Ƿ������ͬ����
        /// </summary>
        /// <param name="obj">ʵ��</param>
        /// <returns></returns>
        bool IsExist(T obj);
    }
}