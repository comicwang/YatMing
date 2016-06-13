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
    /// TEmployee基础方法的提供
    /// </summary>
    public class TEmployeeApp : ITEmployeeApp
    {
        private ITEmployeeRepository _repository;

        public TEmployeeApp(ITEmployeeRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TEmployee记录
        /// </summary>
        /// <param name="dto">TEmployee实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TEmployeeDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Employee>();
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
        /// 根据主键删除一条TEmployee记录
        /// </summary>
        /// <param name="guid">TEmployee主键值</param>
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
        /// 更新一条TEmployee记录
        /// </summary>
        /// <param name="dto">TEmployee实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TEmployeeDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Employee>()) >= 0)
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
        /// 根据TEmployee主键获取一条记录
        /// </summary>
        /// <param name="guid">TEmployee主键值</param>
        /// <returns>根据主键查询到的TEmployee记录</returns>
        public TEmployeeDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TEmployeeDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TEmployee记录
        /// </summary>
        /// <returns>TEmployee所有记录集合</returns>
        public List<TEmployeeDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TEmployeeDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
