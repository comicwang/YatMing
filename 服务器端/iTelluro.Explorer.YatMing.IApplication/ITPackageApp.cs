using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TPackage基础方法接口
    /// </summary>
    public interface ITPackageApp
    {
        /// <summary>
        /// 新增一条TPackage记录
        /// </summary>
        /// <param name="dto">TPackage实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TPackageDTO dto);

        /// <summary>
        /// 根据主键删除一条TPackage记录
        /// </summary>
        /// <param name="guid">TPackage主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TPackage记录
        /// </summary>
        /// <param name="dto">TPackage实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TPackageDTO dto);

        /// <summary>
        /// 根据TPackage主键获取一条记录
        /// </summary>
        /// <param name="guid">TPackage主键值</param>
        /// <returns>根据主键查询到的TPackage记录</returns>
        TPackageDTO Get(string guid);

        /// <summary>
        /// 查询所有TPackage记录
        /// </summary>
        /// <returns>TPackage所有记录集合</returns>
        List<TPackageDTO> GetAll();

    }
}
