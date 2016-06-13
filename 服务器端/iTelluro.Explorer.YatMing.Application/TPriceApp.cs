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
    /// TPrice基础方法的提供
    /// </summary>
    public class TPriceApp : ITPriceApp
    {
        private ITPriceRepository _repository;

        public TPriceApp(ITPriceRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TPrice记录
        /// </summary>
        /// <param name="dto">TPrice实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TPriceDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Price>();
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
        /// 根据主键删除一条TPrice记录
        /// </summary>
        /// <param name="guid">TPrice主键值</param>
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
        /// 更新一条TPrice记录
        /// </summary>
        /// <param name="dto">TPrice实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TPriceDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Price>()) >= 0)
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
        /// 根据TPrice主键获取一条记录
        /// </summary>
        /// <param name="guid">TPrice主键值</param>
        /// <returns>根据主键查询到的TPrice记录</returns>
        public TPriceDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TPriceDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TPrice记录
        /// </summary>
        /// <returns>TPrice所有记录集合</returns>
        public List<TPriceDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TPriceDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
