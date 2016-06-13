using iTelluro.Explorer.YatMing.IApplication;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.Application.CodeFirst.Seedwork;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Domain.Context;
using iTelluro.Explorer.YatMing.Domain.Entities;
using iTelluro.Explorer.Infrastruct.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Application
{
    /// <summary>
    /// TPlatform基础方法的提供
    /// </summary>
    public class TPlatformApp : ITPlatformApp
    {
        private ITPlatformRepository _repository;

        public TPlatformApp(ITPlatformRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TPlatform记录
        /// </summary>
        /// <param name="dto">TPlatform实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TPlatformDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Platform>();
                if (_repository.Insert(entity) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据主键删除一条TPlatform记录
        /// </summary>
        /// <param name="guid">TPlatform主键值</param>
        /// <returns>是否删除成功</returns>
        public bool Remove(string guid)
        {
            try
            {
                if (_repository.Delete(guid) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新一条TPlatform记录
        /// </summary>
        /// <param name="dto">TPlatform实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TPlatformDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Platform>()) >= 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据TPlatform主键获取一条记录
        /// </summary>
        /// <param name="guid">TPlatform主键值</param>
        /// <returns>根据主键查询到的TPlatform记录</returns>
        public TPlatformDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TPlatformDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TPlatform记录
        /// </summary>
        /// <returns>TPlatform所有记录集合</returns>
        public List<TPlatformDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TPlatformDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TPlatformDTO> GetByForignKey(string key)
        {
            try
            {
                return _repository.EntityNoTracking.Where(t => t.MerchantId == key).ProjectedAsCollection<TPlatformDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
