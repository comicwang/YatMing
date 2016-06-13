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
    /// TContract基础方法的提供
    /// </summary>
    public class TContractApp : ITContractApp
    {
        private ITContractRepository _repository;

        public TContractApp(ITContractRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TContract记录
        /// </summary>
        /// <param name="dto">TContract实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TContractDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Contract>();
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
        /// 根据主键删除一条TContract记录
        /// </summary>
        /// <param name="guid">TContract主键值</param>
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
        /// 更新一条TContract记录
        /// </summary>
        /// <param name="dto">TContract实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TContractDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Contract>()) >= 0)
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
        /// 根据TContract主键获取一条记录
        /// </summary>
        /// <param name="guid">TContract主键值</param>
        /// <returns>根据主键查询到的TContract记录</returns>
        public TContractDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TContractDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TContract记录
        /// </summary>
        /// <returns>TContract所有记录集合</returns>
        public List<TContractDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TContractDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
