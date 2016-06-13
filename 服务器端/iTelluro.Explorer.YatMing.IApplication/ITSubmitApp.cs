using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TSubmit基础方法接口
    /// </summary>
    public interface ITSubmitApp
    {
        /// <summary>
        /// 新增一条TSubmit记录
        /// </summary>
        /// <param name="dto">TSubmit实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TSubmitDTO dto);

        /// <summary>
        /// 根据主键删除一条TSubmit记录
        /// </summary>
        /// <param name="guid">TSubmit主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TSubmit记录
        /// </summary>
        /// <param name="dto">TSubmit实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TSubmitDTO dto);

        /// <summary>
        /// 根据TSubmit主键获取一条记录
        /// </summary>
        /// <param name="guid">TSubmit主键值</param>
        /// <returns>根据主键查询到的TSubmit记录</returns>
        TSubmitDTO Get(string guid);

        /// <summary>
        /// 查询所有TSubmit记录
        /// </summary>
        /// <returns>TSubmit所有记录集合</returns>
        List<TSubmitDTO> GetAll();

    }
}
