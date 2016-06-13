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
    /// TShopData基础方法的提供
    /// </summary>
    public class TShopDataApp : ITShopDataApp
    {
        private ITShopDataRepository _repository;

        public TShopDataApp(ITShopDataRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TShopData记录
        /// </summary>
        /// <param name="dto">TShopData实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TShopDataDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_ShopData>();
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
        /// 根据主键删除一条TShopData记录
        /// </summary>
        /// <param name="guid">TShopData主键值</param>
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
        /// 更新一条TShopData记录
        /// </summary>
        /// <param name="dto">TShopData实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TShopDataDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_ShopData>()) >= 0)
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
        /// 根据TShopData主键获取一条记录
        /// </summary>
        /// <param name="guid">TShopData主键值</param>
        /// <returns>根据主键查询到的TShopData记录</returns>
        public TShopDataDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TShopDataDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TShopData记录
        /// </summary>
        /// <returns>TShopData所有记录集合</returns>
        public List<TShopDataDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TShopDataDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
