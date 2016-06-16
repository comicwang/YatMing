using iTelluro.Explorer.Domain.CodeFirst.Seedwork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Infrastructure.Context.Extention;
using System.Data.Entity.Infrastructure;
using iTelluro.Explorer.Infrastruct.CodeFirst.Seedwork;
using System.Data.SqlClient;

namespace iTelluro.Explorer.YatMing.Infrastructure.Context
{

    public partial class YatMingContext : IQueryableUnitOfWork
    {

        /// <summary>
        /// 获取 当前单元操作是否已被提交
        /// </summary>
        public bool IsCommitted { get; private set; }

        #region IQueryableUnitOfWork 成员 以前

        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            //attach and set as unchanged
            base.Entry<TEntity>(item).State = System.Data.EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            //this operation also attach item in object state manager
            base.Entry<TEntity>(item).State = System.Data.EntityState.Modified;
        }
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            //if it is not attached, attach original and set current values
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }
        #endregion

        #region IQueryableUnitOfWork 成员

        /// <summary>
        /// 提交当前操作的结果
        /// </summary>
        /// <param name="validateOnSaveEnabled">保存时是否自动验证跟踪实体</param>
        /// <returns></returns>
        public int Commit(bool validateOnSaveEnabled = true)
        {
            if (IsCommitted)
            {
                return 0;
            }
            try
            {
                int result = this.SaveChanges(validateOnSaveEnabled);
                IsCommitted = true;
                return result;
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    throw new Exception("提交数据更新时发生异常：", sqlEx);
                }
                throw;
            }
        }

        /// <summary>
        /// 把当前操作回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            IsCommitted = false;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            this.Dispose();
        }

        /// <summary>
        /// 执行Sql语句(查询)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlQuery">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回查询的结果</returns>
        public IQueryable<T> ExecuteQuery<T>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<T>(sqlQuery, parameters).AsQueryable();
        }

        /// <summary>
        /// 执行Sql语句(查，删，改)
        /// </summary>
        /// <param name="sqlCommand">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>影响的行数</returns>
        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void AddEntity<TEntity>(TEntity entity) where TEntity : Entity
        {
            EntityState state = this.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                this.Entry(entity).State = EntityState.Added;
            }
            IsCommitted = false;
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public void AddEntities<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            try
            {
                this.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    AddEntity(entity);
                }
            }
            finally
            {
                this.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void DeleteEntity<TEntity>(TEntity entity) where TEntity : Entity
        {
            this.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public void DeleteEntities<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            try
            {
                this.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    DeleteEntity(entity);
                }
            }
            finally
            {
                this.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void UpdateEntity<TEntity>(TEntity entity) where TEntity : Entity
        {
            this.Update<TEntity>(entity);
            IsCommitted = false;
        }

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public void UpdateEntities<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            this.Update<TEntity>(entities.ToArray());
            IsCommitted = false;
        }

        #endregion
    }
}
