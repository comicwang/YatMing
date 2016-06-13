using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TLogin基础方法接口
    /// </summary>
    public interface ITLoginApp
    {
        /// <summary>
        /// 新增一条TLogin记录
        /// </summary>
        /// <param name="dto">TLogin实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TLoginDTO dto);

        /// <summary>
        /// 根据主键删除一条TLogin记录
        /// </summary>
        /// <param name="guid">TLogin主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TLogin记录
        /// </summary>
        /// <param name="dto">TLogin实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TLoginDTO dto);

        /// <summary>
        /// 根据TLogin主键获取一条记录
        /// </summary>
        /// <param name="guid">TLogin主键值</param>
        /// <returns>根据主键查询到的TLogin记录</returns>
        TLoginDTO Get(string guid);

        /// <summary>
        /// 查询所有TLogin记录
        /// </summary>
        /// <returns>TLogin所有记录集合</returns>
        List<TLoginDTO> GetAll();

        bool CheckLogin(string account, string psw, out string message,out TLoginDTO result);

        bool CheckAccountExits(string account);

        bool CheckUpdate(string currentVersion);

        bool Update(out string[] uploadFileLst, out string[] deleteFileLst, out byte[][] fileContent);
    }
}
