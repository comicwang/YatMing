using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TPlatform基础方法接口
    /// </summary>
    public interface ITRecorderApp
    {
        /// <summary>
        /// 新增一条TPlatform记录
        /// </summary>
        /// <param name="dto">TPlatform实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TRecorderDTO dto);

        /// <summary>
        /// 根据主键删除一条TPlatform记录
        /// </summary>
        /// <param name="guid">TPlatform主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TPlatform记录
        /// </summary>
        /// <param name="dto">TPlatform实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TRecorderDTO dto);

        /// <summary>
        /// 根据TPlatform主键获取一条记录
        /// </summary>
        /// <param name="guid">TPlatform主键值</param>
        /// <returns>根据主键查询到的TPlatform记录</returns>
        TRecorderDTO Get(string guid);

        /// <summary>
        /// 查询所有TPlatform记录
        /// </summary>
        /// <returns>TPlatform所有记录集合</returns>
        List<TRecorderDTO> GetAll();

        List<TRecorderDTO> GetByForignKey(string key);

    }
}
