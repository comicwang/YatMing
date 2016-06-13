using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TMerchantType基础方法接口
    /// </summary>
    public interface ITMerchantTypeApp
    {
        /// <summary>
        /// 新增一条TMerchantType记录
        /// </summary>
        /// <param name="dto">TMerchantType实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TMerchantTypeDTO dto);

        /// <summary>
        /// 根据主键删除一条TMerchantType记录
        /// </summary>
        /// <param name="guid">TMerchantType主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TMerchantType记录
        /// </summary>
        /// <param name="dto">TMerchantType实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TMerchantTypeDTO dto);

        /// <summary>
        /// 根据TMerchantType主键获取一条记录
        /// </summary>
        /// <param name="guid">TMerchantType主键值</param>
        /// <returns>根据主键查询到的TMerchantType记录</returns>
        TMerchantTypeDTO Get(string guid);

        /// <summary>
        /// 查询所有TMerchantType记录
        /// </summary>
        /// <returns>TMerchantType所有记录集合</returns>
        List<TMerchantTypeDTO> GetAll();

        List<TMerchantTypeDTO> GetByPid(string pid);

    }
}
