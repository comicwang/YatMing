using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TPrice基础方法接口
    /// </summary>
    public interface ITPriceApp
    {
        /// <summary>
        /// 新增一条TPrice记录
        /// </summary>
        /// <param name="dto">TPrice实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TPriceDTO dto);

        /// <summary>
        /// 根据主键删除一条TPrice记录
        /// </summary>
        /// <param name="guid">TPrice主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TPrice记录
        /// </summary>
        /// <param name="dto">TPrice实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TPriceDTO dto);

        /// <summary>
        /// 根据TPrice主键获取一条记录
        /// </summary>
        /// <param name="guid">TPrice主键值</param>
        /// <returns>根据主键查询到的TPrice记录</returns>
        TPriceDTO Get(string guid);

        /// <summary>
        /// 查询所有TPrice记录
        /// </summary>
        /// <returns>TPrice所有记录集合</returns>
        List<TPriceDTO> GetAll();

    }
}
