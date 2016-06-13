using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TTrain基础方法接口
    /// </summary>
    public interface ITTrainApp
    {
        /// <summary>
        /// 新增一条TTrain记录
        /// </summary>
        /// <param name="dto">TTrain实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TTrainDTO dto);

        /// <summary>
        /// 根据主键删除一条TTrain记录
        /// </summary>
        /// <param name="guid">TTrain主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TTrain记录
        /// </summary>
        /// <param name="dto">TTrain实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TTrainDTO dto);

        /// <summary>
        /// 根据TTrain主键获取一条记录
        /// </summary>
        /// <param name="guid">TTrain主键值</param>
        /// <returns>根据主键查询到的TTrain记录</returns>
        TTrainDTO Get(string guid);

        /// <summary>
        /// 查询所有TTrain记录
        /// </summary>
        /// <returns>TTrain所有记录集合</returns>
        List<TTrainDTO> GetAll();

    }
}
