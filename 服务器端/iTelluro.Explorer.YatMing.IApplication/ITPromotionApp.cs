using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TPromotion基础方法接口
    /// </summary>
    public interface ITPromotionApp
    {
        /// <summary>
        /// 新增一条TPromotion记录
        /// </summary>
        /// <param name="dto">TPromotion实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TPromotionDTO dto);

        /// <summary>
        /// 根据主键删除一条TPromotion记录
        /// </summary>
        /// <param name="guid">TPromotion主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TPromotion记录
        /// </summary>
        /// <param name="dto">TPromotion实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TPromotionDTO dto);

        /// <summary>
        /// 根据TPromotion主键获取一条记录
        /// </summary>
        /// <param name="guid">TPromotion主键值</param>
        /// <returns>根据主键查询到的TPromotion记录</returns>
        TPromotionDTO Get(string guid);

        /// <summary>
        /// 查询所有TPromotion记录
        /// </summary>
        /// <returns>TPromotion所有记录集合</returns>
        List<TPromotionDTO> GetAll();

    }
}
