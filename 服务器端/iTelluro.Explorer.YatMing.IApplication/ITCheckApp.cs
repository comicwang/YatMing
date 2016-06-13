using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TCheck基础方法接口
    /// </summary>
    public interface ITCheckApp
    {
        /// <summary>
        /// 新增一条TCheck记录
        /// </summary>
        /// <param name="dto">TCheck实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TCheckDTO dto);

        /// <summary>
        /// 根据主键删除一条TCheck记录
        /// </summary>
        /// <param name="guid">TCheck主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TCheck记录
        /// </summary>
        /// <param name="dto">TCheck实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TCheckDTO dto);

        /// <summary>
        /// 根据TCheck主键获取一条记录
        /// </summary>
        /// <param name="guid">TCheck主键值</param>
        /// <returns>根据主键查询到的TCheck记录</returns>
        TCheckDTO Get(string guid);

        /// <summary>
        /// 查询所有TCheck记录
        /// </summary>
        /// <returns>TCheck所有记录集合</returns>
        List<TCheckDTO> GetAll();

    }
}
