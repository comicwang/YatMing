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
    /// TSubmit基础方法的提供
    /// </summary>
    public class TSubmitApp : ITSubmitApp
    {
        private ITSubmitRepository _repository;

        public TSubmitApp(ITSubmitRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TSubmit记录
        /// </summary>
        /// <param name="dto">TSubmit实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TSubmitDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Submit>();
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
        /// 根据主键删除一条TSubmit记录
        /// </summary>
        /// <param name="guid">TSubmit主键值</param>
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
        /// 更新一条TSubmit记录
        /// </summary>
        /// <param name="dto">TSubmit实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TSubmitDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Submit>()) >= 0)
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
        /// 根据TSubmit主键获取一条记录
        /// </summary>
        /// <param name="guid">TSubmit主键值</param>
        /// <returns>根据主键查询到的TSubmit记录</returns>
        public TSubmitDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TSubmitDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TSubmit记录
        /// </summary>
        /// <returns>TSubmit所有记录集合</returns>
        public List<TSubmitDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TSubmitDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
