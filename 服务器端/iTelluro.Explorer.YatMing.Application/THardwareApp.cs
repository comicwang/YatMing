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
    /// THardware基础方法的提供
    /// </summary>
    public class THardwareApp : ITHardwareApp
    {
        private ITHardwareRepository _repository;

        public THardwareApp(ITHardwareRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条THardware记录
        /// </summary>
        /// <param name="dto">THardware实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(THardwareDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Hardware>();
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
        /// 根据主键删除一条THardware记录
        /// </summary>
        /// <param name="guid">THardware主键值</param>
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
        /// 更新一条THardware记录
        /// </summary>
        /// <param name="dto">THardware实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(THardwareDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Hardware>()) >= 0)
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
        /// 根据THardware主键获取一条记录
        /// </summary>
        /// <param name="guid">THardware主键值</param>
        /// <returns>根据主键查询到的THardware记录</returns>
        public THardwareDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<THardwareDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有THardware记录
        /// </summary>
        /// <returns>THardware所有记录集合</returns>
        public List<THardwareDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<THardwareDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
