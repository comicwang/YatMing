using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TDetailInfo基础方法接口
    /// </summary>
    public interface ITDetailInfoApp
    {
        /// <summary>
        /// 新增一条TDetailInfo记录
        /// </summary>
        /// <param name="dto">TDetailInfo实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TDetailInfoDTO dto);

        /// <summary>
        /// 根据主键删除一条TDetailInfo记录
        /// </summary>
        /// <param name="guid">TDetailInfo主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TDetailInfo记录
        /// </summary>
        /// <param name="dto">TDetailInfo实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TDetailInfoDTO dto);

        /// <summary>
        /// 根据TDetailInfo主键获取一条记录
        /// </summary>
        /// <param name="guid">TDetailInfo主键值</param>
        /// <returns>根据主键查询到的TDetailInfo记录</returns>
        TDetailInfoDTO Get(string guid);

        /// <summary>
        /// 查询所有TDetailInfo记录
        /// </summary>
        /// <returns>TDetailInfo所有记录集合</returns>
        List<TDetailInfoDTO> GetAll();

        TDetailInfoDTO GetByForignKey(string id);

    }
}
