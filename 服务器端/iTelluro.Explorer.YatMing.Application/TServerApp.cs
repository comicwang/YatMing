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
    /// TServer基础方法的提供
    /// </summary>
    public class TServerApp : ITServerApp
    {
        private ITServerRepository _repository;

        public TServerApp(ITServerRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TServer记录
        /// </summary>
        /// <param name="dto">TServer实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TServerDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Server>();
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
        /// 根据主键删除一条TServer记录
        /// </summary>
        /// <param name="guid">TServer主键值</param>
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
        /// 更新一条TServer记录
        /// </summary>
        /// <param name="dto">TServer实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TServerDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Server>()) > 0)
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
        /// 根据TServer主键获取一条记录
        /// </summary>
        /// <param name="guid">TServer主键值</param>
        /// <returns>根据主键查询到的TServer记录</returns>
        public TServerDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TServerDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TServer记录
        /// </summary>
        /// <returns>TServer所有记录集合</returns>
        public List<TServerDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TServerDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
