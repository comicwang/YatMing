using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.IApplication
{
    /// <summary>
    /// TDataInfo基础方法接口
    /// </summary>
    public interface ITDataInfoApp
    {
        /// <summary>
        /// 新增一条TDataInfo记录
        /// </summary>
        /// <param name="dto">TDataInfo实体</param>
        /// <returns>是否新增成功</returns>
        bool Add(TDataInfoDTO dto);

        /// <summary>
        /// 根据主键删除一条TDataInfo记录
        /// </summary>
        /// <param name="guid">TDataInfo主键值</param>
        /// <returns>是否删除成功</returns>
        bool Remove(string guid);

        /// <summary>
        /// 更新一条TDataInfo记录
        /// </summary>
        /// <param name="dto">TDataInfo实体</param>
        /// <returns>是否更新成功</returns>
        bool Update(TDataInfoDTO dto);

        /// <summary>
        /// 根据TDataInfo主键获取一条记录
        /// </summary>
        /// <param name="guid">TDataInfo主键值</param>
        /// <returns>根据主键查询到的TDataInfo记录</returns>
        TDataInfoDTO Get(string guid);

        /// <summary>
        /// 查询所有TDataInfo记录
        /// </summary>
        /// <returns>TDataInfo所有记录集合</returns>
        List<TDataInfoDTO> GetAll();

        bool UploadFile(byte[] buffer, string metaId, int index);

        bool DownloadFile(out byte[] outstream, long length, string metaId);

        List<TDataInfoDTO> GetByForginKey(string key);

        List<TDataInfoDTO> GetByParentKey(string key);

        List<TDataInfoDTO> Query(bool limit, DateTime start, DateTime end, string keyword, string baseId);
    }
}
