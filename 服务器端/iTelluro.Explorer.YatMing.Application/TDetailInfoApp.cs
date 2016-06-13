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
    /// TDetailInfo基础方法的提供
    /// </summary>
    public class TDetailInfoApp : ITDetailInfoApp
    {
        private ITDetailInfoRepository _repository;

        public TDetailInfoApp(ITDetailInfoRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TDetailInfo记录
        /// </summary>
        /// <param name="dto">TDetailInfo实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TDetailInfoDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_DetailInfo>();
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
        /// 根据主键删除一条TDetailInfo记录
        /// </summary>
        /// <param name="guid">TDetailInfo主键值</param>
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
        /// 更新一条TDetailInfo记录
        /// </summary>
        /// <param name="dto">TDetailInfo实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TDetailInfoDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_DetailInfo>()) >= 0)
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
        /// 根据TDetailInfo主键获取一条记录
        /// </summary>
        /// <param name="guid">TDetailInfo主键值</param>
        /// <returns>根据主键查询到的TDetailInfo记录</returns>
        public TDetailInfoDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TDetailInfoDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TDetailInfo记录
        /// </summary>
        /// <returns>TDetailInfo所有记录集合</returns>
        public List<TDetailInfoDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TDetailInfoDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TDetailInfoDTO GetByForignKey(string id)
        {
            try
            {
                return _repository.EntityNoTracking.Where(t => t.BaseInfoId == id).FirstOrDefault().ProjectedAs<TDetailInfoDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
