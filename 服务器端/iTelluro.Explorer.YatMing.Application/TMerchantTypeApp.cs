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
    /// TMerchantType基础方法的提供
    /// </summary>
    public class TMerchantTypeApp : ITMerchantTypeApp
    {
        private ITMerchantTypeRepository _repository;

        public TMerchantTypeApp(ITMerchantTypeRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TMerchantType记录
        /// </summary>
        /// <param name="dto">TMerchantType实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TMerchantTypeDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_MerchantType>();
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
        /// 根据主键删除一条TMerchantType记录
        /// </summary>
        /// <param name="guid">TMerchantType主键值</param>
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
        /// 更新一条TMerchantType记录
        /// </summary>
        /// <param name="dto">TMerchantType实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TMerchantTypeDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_MerchantType>()) >= 0)
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
        /// 根据TMerchantType主键获取一条记录
        /// </summary>
        /// <param name="guid">TMerchantType主键值</param>
        /// <returns>根据主键查询到的TMerchantType记录</returns>
        public TMerchantTypeDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TMerchantTypeDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TMerchantType记录
        /// </summary>
        /// <returns>TMerchantType所有记录集合</returns>
        public List<TMerchantTypeDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TMerchantTypeDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TMerchantTypeDTO> GetByPid(string pid)
        {
            try
            {
                return _repository.EntityNoTracking.Where(t => t.ParentId == pid).ProjectedAsCollection<TMerchantTypeDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
