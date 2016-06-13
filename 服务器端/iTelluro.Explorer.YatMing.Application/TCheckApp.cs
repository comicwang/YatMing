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
    /// TCheck基础方法的提供
    /// </summary>
    public class TCheckApp : ITCheckApp
    {
        private ITCheckRepository _repository;

        public TCheckApp(ITCheckRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TCheck记录
        /// </summary>
        /// <param name="dto">TCheck实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TCheckDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Check>();
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
        /// 根据主键删除一条TCheck记录
        /// </summary>
        /// <param name="guid">TCheck主键值</param>
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
        /// 更新一条TCheck记录
        /// </summary>
        /// <param name="dto">TCheck实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TCheckDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Check>()) >= 0)
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
        /// 根据TCheck主键获取一条记录
        /// </summary>
        /// <param name="guid">TCheck主键值</param>
        /// <returns>根据主键查询到的TCheck记录</returns>
        public TCheckDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TCheckDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TCheck记录
        /// </summary>
        /// <returns>TCheck所有记录集合</returns>
        public List<TCheckDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TCheckDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
