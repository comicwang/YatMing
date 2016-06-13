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
    /// TPackage基础方法的提供
    /// </summary>
    public class TPackageApp : ITPackageApp
    {
        private ITPackageRepository _repository;

        public TPackageApp(ITPackageRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TPackage记录
        /// </summary>
        /// <param name="dto">TPackage实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TPackageDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Package>();
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
        /// 根据主键删除一条TPackage记录
        /// </summary>
        /// <param name="guid">TPackage主键值</param>
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
        /// 更新一条TPackage记录
        /// </summary>
        /// <param name="dto">TPackage实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TPackageDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Package>()) >= 0)
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
        /// 根据TPackage主键获取一条记录
        /// </summary>
        /// <param name="guid">TPackage主键值</param>
        /// <returns>根据主键查询到的TPackage记录</returns>
        public TPackageDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TPackageDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TPackage记录
        /// </summary>
        /// <returns>TPackage所有记录集合</returns>
        public List<TPackageDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TPackageDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
