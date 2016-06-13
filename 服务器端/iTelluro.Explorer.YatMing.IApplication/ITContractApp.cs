using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TContract基础方法接口
    /// </summary>
    public interface ITContractApp
    {
        /// <summary>
        /// 新增一条TContract记录
        /// </summary>
        /// <param name="dto">TContract实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TContractDTO dto);

        /// <summary>
        /// 根据主键删除一条TContract记录
        /// </summary>
        /// <param name="guid">TContract主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TContract记录
        /// </summary>
        /// <param name="dto">TContract实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TContractDTO dto);

        /// <summary>
        /// 根据TContract主键获取一条记录
        /// </summary>
        /// <param name="guid">TContract主键值</param>
        /// <returns>根据主键查询到的TContract记录</returns>
        TContractDTO Get(string guid);

        /// <summary>
        /// 查询所有TContract记录
        /// </summary>
        /// <returns>TContract所有记录集合</returns>
        List<TContractDTO> GetAll();

    }
}
