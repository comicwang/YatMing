using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// THardware基础方法接口
    /// </summary>
    public interface ITHardwareApp
    {
        /// <summary>
        /// 新增一条THardware记录
        /// </summary>
        /// <param name="dto">THardware实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(THardwareDTO dto);

        /// <summary>
        /// 根据主键删除一条THardware记录
        /// </summary>
        /// <param name="guid">THardware主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条THardware记录
        /// </summary>
        /// <param name="dto">THardware实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(THardwareDTO dto);

        /// <summary>
        /// 根据THardware主键获取一条记录
        /// </summary>
        /// <param name="guid">THardware主键值</param>
        /// <returns>根据主键查询到的THardware记录</returns>
        THardwareDTO Get(string guid);

        /// <summary>
        /// 查询所有THardware记录
        /// </summary>
        /// <returns>THardware所有记录集合</returns>
        List<THardwareDTO> GetAll();

    }
}
