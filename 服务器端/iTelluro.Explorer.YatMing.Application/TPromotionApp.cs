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
    /// TPromotion基础方法的提供
    /// </summary>
    public class TPromotionApp : ITPromotionApp
    {
        private ITPromotionRepository _repository;

        public TPromotionApp(ITPromotionRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TPromotion记录
        /// </summary>
        /// <param name="dto">TPromotion实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TPromotionDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Promotion>();
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
        /// 根据主键删除一条TPromotion记录
        /// </summary>
        /// <param name="guid">TPromotion主键值</param>
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
        /// 更新一条TPromotion记录
        /// </summary>
        /// <param name="dto">TPromotion实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TPromotionDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Promotion>()) >= 0)
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
        /// 根据TPromotion主键获取一条记录
        /// </summary>
        /// <param name="guid">TPromotion主键值</param>
        /// <returns>根据主键查询到的TPromotion记录</returns>
        public TPromotionDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TPromotionDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TPromotion记录
        /// </summary>
        /// <returns>TPromotion所有记录集合</returns>
        public List<TPromotionDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TPromotionDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
