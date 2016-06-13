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
    /// TTrain基础方法的提供
    /// </summary>
    public class TTrainApp : ITTrainApp
    {
        private ITTrainRepository _repository;

        public TTrainApp(ITTrainRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TTrain记录
        /// </summary>
        /// <param name="dto">TTrain实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TTrainDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Train>();
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
        /// 根据主键删除一条TTrain记录
        /// </summary>
        /// <param name="guid">TTrain主键值</param>
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
        /// 更新一条TTrain记录
        /// </summary>
        /// <param name="dto">TTrain实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TTrainDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Train>()) >= 0)
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
        /// 根据TTrain主键获取一条记录
        /// </summary>
        /// <param name="guid">TTrain主键值</param>
        /// <returns>根据主键查询到的TTrain记录</returns>
        public TTrainDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TTrainDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TTrain记录
        /// </summary>
        /// <returns>TTrain所有记录集合</returns>
        public List<TTrainDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TTrainDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
