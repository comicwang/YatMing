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
    /// TBaseInfo基础方法的提供
    /// </summary>
    public class TBaseInfoApp : ITBaseInfoApp
    {
        private ITBaseInfoRepository _repository;

        public TBaseInfoApp(ITBaseInfoRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TBaseInfo记录
        /// </summary>
        /// <param name="dto">TBaseInfo实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TBaseInfoDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_BaseInfo>();
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
        /// 根据主键删除一条TBaseInfo记录
        /// </summary>
        /// <param name="guid">TBaseInfo主键值</param>
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
        /// 更新一条TBaseInfo记录
        /// </summary>
        /// <param name="dto">TBaseInfo实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TBaseInfoDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_BaseInfo>()) >= 0)
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
        /// 根据TBaseInfo主键获取一条记录
        /// </summary>
        /// <param name="guid">TBaseInfo主键值</param>
        /// <returns>根据主键查询到的TBaseInfo记录</returns>
        public TBaseInfoDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TBaseInfoDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TBaseInfo记录
        /// </summary>
        /// <returns>TBaseInfo所有记录集合</returns>
        public List<TBaseInfoDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TBaseInfoDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TBaseInfoDTO> QueryByKeyword(string key)
        {
            try
            {
                return _repository.EntityNoTracking.Where(t => t.MerchantName.Contains(key)).ProjectedAsCollection<TBaseInfoDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
