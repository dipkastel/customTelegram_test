using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Database.Common;
using Database.Common.Interfaces;
using Database.Config;
using DatabaseValidation.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Services.Common;
using Services.Common.Interfaces;
using Services.Enum;

namespace Services.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        protected DbContextModel Context;
        protected IGenericValidation<T> Validation;
        private bool _disposed = true;

        public IQueryable<T> Queryable { get; set; }


        protected GenericRepository(DbContextModel context, IGenericValidation<T> validation)
        {
            Context = context;
            Validation = validation;
            Queryable = Context.Set<T>();
        }


//        public IMyIncludedQueryable<T, object> Include(Expression<Func<T, object>> navigationPropertyPath)
//        {
//            return Queryable.Include(navigationPropertyPath) as IMyIncludedQueryable<T, object>;
//        }


        #region Create

        /// <summary>
        /// Insert object to database
        /// </summary>
        /// <param name="entity">object</param>
        /// <param name="createdById">id of user who want to insert this object</param>
        /// <exception cref="Exception"></exception>
        /// <returns>
        /// return inserted object with id
        /// </returns>
        public virtual DbResult<T> Add(T entity, int? createdById)
        {
            var result = new DbResult<T>();

            try
            {
                entity = FillInsertDefaultProperties(entity, createdById);

                if (!Validation.InsertValidation(entity,out var validationMessage))
                {
                    result.Success = false;
                    result.Data = null;
                    result.Count = 0;
                    result.MessageType = MessageType.InvalidData;
                    result.Info = MessageType.InvalidData.Description();
                    result.Message = validationMessage;

                    return result;
                }

                Context.Set<T>().Add(entity);
                Save();

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.Success;
                result.Info = MessageType.Success.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.Error;
                result.Info = MessageType.Error.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Insert object to database async
        /// </summary>
        /// <param name="entity">object</param>
        /// <param name="createdById">id of user who want to insert this object</param>
        /// <returns>
        /// return inserted object with id
        /// </returns>
        public virtual async Task<DbResult<T>> AddAsync(T entity, int? createdById)
        {
            var result = new DbResult<T>();

            try
            {
                entity = FillInsertDefaultProperties(entity, createdById);

                if (!Validation.InsertValidation(entity, out var validationMessage))
                {
                    result.Success = false;
                    result.Data = null;
                    result.Count = 0;
                    result.MessageType = MessageType.InvalidData;
                    result.Info = MessageType.InvalidData.Description();
                    result.Message = validationMessage;

                    return result;
                }

                await Context.Set<T>().AddAsync(entity);
                await SaveAsync();

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.Success;
                result.Info = MessageType.Success.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.Error;
                result.Info = MessageType.Error.Description();
                result.Exception = e;

                return result;
            }
        }

        #endregion

        #region Read By Admin

        /// <summary>
        /// Get all objects even those IsDeleted set to Deleted
        /// </summary>
        /// <returns>
        /// Return objects if those are found else method returns null
        /// </returns>
        public DbResult<IQueryable<T>> GetAllByAdmin()
        {
            var result = new DbResult<IQueryable<T>>();

            try
            {
                var entities = Context.Set<T>();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count();
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Get all objects async even those IsDeleted set to Deleted
        /// </summary>
        /// <returns>
        /// Return objects if those are found else method returns null
        /// </returns>
        public virtual async Task<DbResult<ICollection<T>>> GetAllAsyncByAdmin()
        {
            var result = new DbResult<ICollection<T>>();

            try
            {
                var entities = await Context.Set<T>().ToListAsync();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count;
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find object by id even thats's IsDeleted set to Deleted
        /// </summary>
        /// <param name="id"> object id </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        public virtual DbResult<T> GetByAdmin(int id)
        {
            var result = new DbResult<T>();

            try
            {
                var entity = Context.Set<T>().Find(id);

                if (entity == null)
                {
                    result.Success = true;
                    result.Data = null;
                    result.Count = 0;
                    result.MessageType = MessageType.SingleNotFound;
                    result.Info = MessageType.SingleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find object Async by id even even thats's IsDeleted set to Deleted
        /// </summary>
        /// <param name="id"> object id </param>
        /// <returns>
        /// Return object if that's found else method returns null
        /// </returns>
        public virtual async Task<DbResult<T>> GetAsyncByAdmin(int id)
        {
            var result = new DbResult<T>();

            try
            {
                var entity = await Context.Set<T>().FindAsync(id);

                if (entity == null || entity.Id == 0)
                {
                    result.Success = true;
                    result.Data = entity;
                    result.Count = 0;
                    result.MessageType = MessageType.SingleNotFound;
                    result.Info = MessageType.SingleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find object by some expression even that's IsDeleted set to Deleted
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        public virtual DbResult<T> FindByAdmin(Expression<Func<T, bool>> match)
        {
            var result = new DbResult<T>();

            try
            {
                var entity = Context.Set<T>().FirstOrDefault(match);

                if (entity == null || entity.Id == 0)
                {
                    result.Success = true;
                    result.Data = entity;
                    result.Count = 0;
                    result.MessageType = MessageType.SingleNotFound;
                    result.Info = MessageType.SingleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find object async by some expression even that's IsDeleted set to Deleted
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        public virtual async Task<DbResult<T>> FindAsyncByAdmin(Expression<Func<T, bool>> match)
        {
            var result = new DbResult<T>();

            try
            {
                var entity = await Context.Set<T>().FirstOrDefaultAsync(match);

                if (entity == null || entity.Id == 0)
                {
                    result.Success = true;
                    result.Data = entity;
                    result.Count = 0;
                    result.MessageType = MessageType.SingleNotFound;
                    result.Info = MessageType.SingleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find objects by some expression even those's IsDeleted set to Deleted
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        public DbResult<ICollection<T>> FindAllByAdmin(Expression<Func<T, bool>> match)
        {
            var result = new DbResult<ICollection<T>>();

            try
            {
                var entities = Context.Set<T>().Where(match).ToList();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count;
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find objects async by some expression even those's IsDeleted set to Deleted
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        public async Task<DbResult<ICollection<T>>> FindAllAsyncByAdmin(Expression<Func<T, bool>> match)
        {
            var result = new DbResult<ICollection<T>>();

            try
            {
                var entities = await Context.Set<T>().Where(match).ToListAsync();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count;
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find objects by some expression even those's IsDeleted set to Deleted
        /// </summary>
        /// <param name="predicate"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        public virtual DbResult<IQueryable<T>> FindByByAdmin(Expression<Func<T, bool>> predicate)
        {
            var result = new DbResult<IQueryable<T>>();

            try
            {
                var entities = Context.Set<T>().Where(predicate);

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count();
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find objects async by some expression even those's IsDeleted set to Deleted
        /// </summary>
        /// <param name="predicate"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        public virtual async Task<DbResult<ICollection<T>>> FindByAsyncByAdmin(Expression<Func<T, bool>> predicate)
        {
            var result = new DbResult<ICollection<T>>();

            try
            {
                var entities = await Context.Set<T>().Where(predicate).ToListAsync();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count;
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        //public DbResult<IQueryable<T>> GetAllIncludingByAdmin(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    var result = new DbResult<IQueryable<T>>();

        //    try
        //    {
        //        var getAllResult = GetAllByAdmin();

        //        var entities = getAllResult.Data;

        //        if (!getAllResult.Success)
        //        {
        //            throw new Exception();
        //        }

        //        if (getAllResult.MessageType != MessageType.MultipleSuccess)
        //        {
        //            result.Success = true;
        //            result.Data = entities;
        //            result.Count = 0;
        //            result.MessageType = MessageType.MultipleNotFound;
        //            result.Info = MessageType.MultipleNotFound.Description();

        //            return result;
        //        }

        //        foreach (var includeProperty in includeProperties)
        //        {
        //            entities = entities.Include(includeProperty);
        //        }

        //        result.Success = true;
        //        result.Data = entities;
        //        result.Count = entities.Count();
        //        result.MessageType = MessageType.MultipleSuccess;
        //        result.Info = MessageType.MultipleSuccess.Description();

        //        return result;

        //    }
        //    catch (Exception e)
        //    {
        //        result.Success = false;
        //        result.Data = null;
        //        result.Count = 0;
        //        result.MessageType = MessageType.MultipleError;
        //        result.Info = MessageType.MultipleError.Description();
        //        result.Exception = e;

        //        return result;
        //    }
        //}
        public IQueryable<T> GetAllIncludingByAdmin(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                var getAllResult = GetAllByAdmin();

                var entities = getAllResult.Data;

                if (!getAllResult.Success)
                {
                    throw new Exception();
                }

                return includeProperties.Aggregate(entities, (current, includeProperty) => current.Include(includeProperty));

            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Count objects quentity even those's that IsDeleted set to Deleted
        /// </summary>
        /// <returns>
        /// return objects quentity
        /// </returns>
        public DbResult<int> CountByAdmin()
        {
            var result = new DbResult<int>();

            try
            {
                var count = Context
                    .Set<T>()
                    .Count();

                result.Success = true;
                result.Data = count;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = 0;
                result.Count = 0;
                result.Exception = e;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();

                return result;
            }
        }

        /// <summary>
        /// Count objects quentity async even those's that IsDeleted set to Deleted
        /// </summary>
        /// <returns>
        /// return objects quentity
        /// </returns>
        public async Task<DbResult<int>> CountAsyncByAdmin()
        {
            var result = new DbResult<int>();

            try
            {
                var count = await Context
                    .Set<T>()
                    .CountAsync();

                result.Success = true;
                result.Data = count;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = 0;
                result.Count = 0;
                result.Exception = e;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();

                return result;
            }
        }

        /// <summary>
        /// Check object exists by id even thats's IsDeleted set to Deleted
        /// </summary>
        /// <param name="id">object id</param>
        /// <returns></returns>
        public DbResult<bool> ExistsByAdmin(int id)
        {
            var result = new DbResult<bool>();

            try
            {
                var exists = Context.Set<T>()
                    .Any(t => t.Id == id);

                result.Success = true;
                result.Data = exists;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = false;
                result.Count = 0;
                result.Exception = e;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();

                return result;
            }
        }

        #endregion

        #region Read

        /// <summary>
        /// Get all available objects
        /// </summary>
        /// <returns>
        /// Return objects if those are found else method returns null
        /// </returns>
        public DbResult<IQueryable<T>> GetAll()
        {
            var result = new DbResult<IQueryable<T>>();

            try
            {
                var entities = Context.Set<T>()
                    .Where(e => e.IsDeleted == false);

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count();
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Get all available objects async
        /// </summary>
        /// <returns>
        /// Return objects if those are found else method returns null
        /// </returns>
        public virtual async Task<DbResult<ICollection<T>>> GetAllAsync()
        {
           var result = new DbResult<ICollection<T>>();

            try
            {
                var entities = await Context.Set<T>()
                    .Where(e => e.IsDeleted == false)
                    .ToListAsync();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count;
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find available object by id
        /// </summary>
        /// <param name="id"> object id </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        public virtual DbResult<T> Get(int id)
        {
            var result = new DbResult<T>();

            try
            {
                var entity = Context.Set<T>()
                    .FirstOrDefault(e => e.Id == id && e.IsDeleted == false);

                if (entity == null || entity.Id == 0)
                {
                    result.Success = true;
                    result.Data = entity;
                    result.Count = 0;
                    result.MessageType = MessageType.SingleNotFound;
                    result.Info = MessageType.SingleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find available object async by id
        /// </summary>
        /// <param name="id"> object id </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        public virtual async Task<DbResult<T>> GetAsync(int id)
        {
            var result = new DbResult<T>();

            try
            {
                var entity = await Context.Set<T>()
                    .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);

                if (entity == null || entity.Id == 0)
                {
                    result.Success = true;
                    result.Data = entity;
                    result.Count = 0;
                    result.MessageType = MessageType.SingleNotFound;
                    result.Info = MessageType.SingleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find available object by some expression
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        public virtual DbResult<T> Find(Expression<Func<T, bool>> match)
        {
            var result = new DbResult<T>();

            try
            {
                var entity = Context.Set<T>().FirstOrDefault(match);

                if (entity == null || entity.Id == 0)
                {
                    result.Success = true;
                    result.Data = entity;
                    result.Count = 0;
                    result.MessageType = MessageType.SingleNotFound;
                    result.Info = MessageType.SingleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find available object async by some expression
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        public virtual async Task<DbResult<T>> FindAsync(Expression<Func<T, bool>> match)
        {
            var result = new DbResult<T>();

            try
            {
                var entity = await Context.Set<T>().FirstOrDefaultAsync(match);

                if (entity == null || entity.Id == 0)
                {
                    result.Success = true;
                    result.Data = entity;
                    result.Count = 0;
                    result.MessageType = MessageType.SingleNotFound;
                    result.Info = MessageType.SingleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entity;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find available objects by some expression
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        public DbResult<ICollection<T>> FindAll(Expression<Func<T, bool>> match)
        {
            var result = new DbResult<ICollection<T>>();

            try
            {
                var entities = Context.Set<T>()
                    .Where(match)
                    .Where(e => e.IsDeleted == false)
                    .ToList();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count;
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find available objects async by some expression
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        public async Task<DbResult<ICollection<T>>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            var result = new DbResult<ICollection<T>>();

            try
            {
                var entities = await Context.Set<T>()
                    .Where(match)
                    .Where(e => e.IsDeleted == false)
                    .ToListAsync();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count;
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// Find available objects by some expression
        /// </summary>
        /// <param name="predicate"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        public virtual DbResult<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            var result = new DbResult<IQueryable<T>>();

            try
            {
                var entities = Context.Set<T>()
                    .Where(predicate)
                    .Where(e => e.IsDeleted == false);

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count();
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }

        }

        /// <summary>
        /// Find available objects async by some expression
        /// </summary>
        /// <param name="predicate"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        public virtual async Task<DbResult<ICollection<T>>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            var result = new DbResult<ICollection<T>>();

            try
            {
                var entities = await Context.Set<T>()
                    .Where(predicate)
                    .Where(e => e.IsDeleted == false)
                    .ToListAsync();

                if (!entities.Any())
                {
                    result.Success = true;
                    result.Data = entities;
                    result.Count = 0;
                    result.MessageType = MessageType.MultipleNotFound;
                    result.Info = MessageType.MultipleNotFound.Description();

                    return result;
                }

                result.Success = true;
                result.Data = entities;
                result.Count = entities.Count;
                result.MessageType = MessageType.MultipleSuccess;
                result.Info = MessageType.MultipleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = null;
                result.Count = 0;
                result.MessageType = MessageType.MultipleError;
                result.Info = MessageType.MultipleError.Description();
                result.Exception = e;

                return result;
            }
        }

        //public DbResult<IQueryable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    var result = new DbResult<IQueryable<T>>();

        //    try
        //    {
        //        var getAllResult = GetAll();

        //        var entities = getAllResult.Data;

        //        if (!getAllResult.Success )
        //        {
        //            throw new Exception();
        //        }

        //        if (getAllResult.MessageType != MessageType.MultipleSuccess)
        //        {
        //            result.Success = true;
        //            result.Data = entities;
        //            result.Count = 0;
        //            result.MessageType = MessageType.MultipleNotFound;
        //            result.Info = MessageType.MultipleNotFound.Description();

        //            return result;
        //        }

        //        foreach (var includeProperty in includeProperties)
        //        {
        //            entities = entities.Include(includeProperty);
        //        }

        //        result.Success = true;
        //        result.Data = entities;
        //        result.Count = entities.Count();
        //        result.MessageType = MessageType.MultipleSuccess;
        //        result.Info = MessageType.MultipleSuccess.Description();

        //        return result;

        //    }
        //    catch (Exception e)
        //    {
        //        result.Success = false;
        //        result.Data = null;
        //        result.Count = 0;
        //        result.MessageType = MessageType.MultipleError;
        //        result.Info = MessageType.MultipleError.Description();
        //        result.Exception = e;

        //        return result;
        //    }

        //}
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            //TODO: Check this method

            try
            {
                var getAllResult = GetAllByAdmin();

                var entities = getAllResult.Data;

                if (!getAllResult.Success)
                {
                    throw new Exception();
                }

                var result = includeProperties.Aggregate(entities, (current, includeProperty) => current.Include(includeProperty));

                return result.Where( e => e.IsDeleted == false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Count available objects quentity
        /// </summary>
        /// <returns>
        /// return objects quentity
        /// </returns>
        public DbResult<int> Count()
        {
            var result = new DbResult<int>();

            try
            {
                var count = Context
                    .Set<T>()
                    .Count(e => e.IsDeleted == false);

                result.Success = true;
                result.Data = count;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = 0;
                result.Count = 0;
                result.Exception = e;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();

                return result;
            }
        }

        /// <summary>
        /// Count available objects quentity asunc
        /// </summary>
        /// <returns>
        /// return objects quentity
        /// </returns>
        public async Task<DbResult<int>> CountAsync()
        {
            var result = new DbResult<int>();

            try
            {
                var count = await Context
                    .Set<T>()
                    .CountAsync(e => e.IsDeleted == false);

                result.Success = true;
                result.Data = count;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = 0;
                result.Count = 0;
                result.Exception = e;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();

                return result;
            }
        }

        /// <summary>
        /// Check available object exists by id
        /// </summary>
        /// <param name="id">object id</param>
        /// <returns></returns>
        public DbResult<bool> Exists(int id)
        {
            var result = new DbResult<bool>();

            try
            {
                var exists = Context.Set<T>()
                    .Where(e => e.IsDeleted == false)
                    .Any(t => t.Id == id);

                result.Success = true;
                result.Data = exists;
                result.Count = 1;
                result.MessageType = MessageType.SingleSuccess;
                result.Info = MessageType.SingleSuccess.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Data = false;
                result.Count = 0;
                result.Exception = e;
                result.MessageType = MessageType.SingleError;
                result.Info = MessageType.SingleError.Description();

                return result;
            }
            
        }

        #endregion

        #region Update


        /// <summary>
        /// update an object data
        /// </summary>
        /// <param name="newValue">object must have id</param>
        /// <param name="updatedById">id of user who want to update this object</param>
        /// <returns>
        /// returns updated object
        /// </returns>
        public virtual DbResult<T> Update(T newValue, int updatedById)
        {
            try
            {
                var dbResult = GetByAdmin(newValue.Id);

                if (!dbResult.Success)
                {
                    throw new Exception(dbResult.Message);
                }

                newValue.UpdatedByUserId = updatedById;
                newValue.UpdatedOn = DateTime.Now;

                Context.Update(newValue);
                Save();

                var result = new DbResult<T>
                {
                    Success = true,
                    Data = newValue,
                    Count = 1,
                    MessageType = MessageType.Success,
                    Info = MessageType.Success.Description()
                };

                return result;
            }
            catch (Exception e)
            {
                var result = new DbResult<T>
                {
                    Success = false,
                    Data = null,
                    Count = 0,
                    MessageType = MessageType.Error,
                    Info = MessageType.Error.Description(),
                    Exception = e,
                    Message = e.Message
                };

                return result;
            }
        }

        /// <summary>
        /// update an object data async
        /// </summary>
        /// <param name="newValue">new value object with itself id</param>
        /// <param name="updatedById">id of user who want to update this object</param>
        /// <returns>
        /// returns updated object
        /// </returns>
        public virtual async Task<DbResult<T>> UpdateAsync(T newValue, int updatedById)
        {
            try
            {
                var dbResult = await GetAsyncByAdmin(newValue.Id);

                if (!dbResult.Success)
                {
                    throw new Exception(dbResult.Message);
                }

                newValue.UpdatedByUserId = updatedById;
                newValue.UpdatedOn = DateTime.Now;

                Context.Update(newValue);
                await SaveAsync();

                var result = new DbResult<T>
                {
                    Success = true,
                    Data = newValue,
                    Count = 1,
                    MessageType = MessageType.Success,
                    Info = MessageType.Success.Description()
                };

                return result;
            }
            catch (Exception e)
            {
                var result = new DbResult<T>
                {
                    Success = false,
                    Data = null,
                    Count = 0,
                    MessageType = MessageType.Error,
                    Info = MessageType.Error.Description(),
                    Exception = e,
                    Message = e.Message
                };

                return result;
            }
        }

        /// <summary>
        /// Logicaly delete an object
        /// set object IsDeleted to Deleted
        /// </summary>
        /// <param name="id">object id</param>
        /// <param name="updatedById">id of user who want to disable this object</param>
        public DbResult Disable(int id, int updatedById)
        {
            var result = new DbResult();

            try
            {
                var dbResult = Get(id);
                
                if (!dbResult.Success)
                {
                    result.Success = false;
                    result.Message = dbResult.Message;
                    result.Exception = dbResult.Exception;
                    result.MessageType = MessageType.Error;
                    result.Info = MessageType.Error.Description();
                    result.Count = 0;
                    
                    return result;
                }

                var entity = dbResult.Data;

                entity.IsDeleted = true;
                var updateResult = Update(entity, updatedById);

                if (!updateResult.Success)
                {
                    result.Success = false;
                    result.Message = updateResult.Message;
                    result.Exception = updateResult.Exception;
                    result.MessageType = MessageType.Error;
                    result.Info = MessageType.Error.Description();
                    result.Count = 0;

                    return result;
                }

                result.Success = true;
                result.MessageType = MessageType.Success;
                result.Info = MessageType.Success.Description();
                result.Count = 0;

                return result;

            }
            catch (Exception e)
            {
                result.Success = false;
                result.Exception = e;
                result.MessageType = MessageType.Error;
                result.Info = MessageType.Error.Description();
                result.Count = 0;

                return result;
            }
        }

        /// <summary>
        /// Logicaly delete an object async
        /// set object IsDeleted to Deleted
        /// </summary>
        /// <param name="id">object id</param>
        /// <param name="updatedById">id of user who want to disable this object</param>
        public async Task<DbResult> DisableAsync(int id, int updatedById)
        {
            var result = new DbResult();

            try
            {
                var dbResult = await GetAsync(id);

                if (!dbResult.Success)
                {
                    result.Success = false;
                    result.Message = dbResult.Message;
                    result.Exception = dbResult.Exception;
                    result.MessageType = MessageType.Error;
                    result.Info = MessageType.Error.Description();
                    result.Count = 0;

                    return result;
                }

                var entity = dbResult.Data;

                entity.IsDeleted = true;
                var updateResult = await UpdateAsync(entity, updatedById);

                if (!updateResult.Success)
                {
                    result.Success = false;
                    result.Message = updateResult.Message;
                    result.Exception = updateResult.Exception;
                    result.MessageType = MessageType.Error;
                    result.Info = MessageType.Error.Description();
                    result.Count = 0;

                    return result;
                }

                result.Success = true;
                result.MessageType = MessageType.Success;
                result.Info = MessageType.Success.Description();
                result.Count = 0;

                return result;

            }
            catch (Exception e)
            {
                result.Success = false;
                result.Exception = e;
                result.MessageType = MessageType.Error;
                result.Info = MessageType.Error.Description();
                result.Count = 0;

                return result;
            }
        }

        /// <summary>
        /// Restore an object
        /// set object IsDeleted to Available
        /// </summary>
        /// <param name="id">object id</param>
        /// <param name="updatedById">id of user who want to enable this object</param>
        public DbResult Enable(int id, int updatedById)
        {
            var result = new DbResult();

            try
            {
                var dbResult = GetByAdmin(id);

                if (!dbResult.Success)
                {
                    result.Success = false;
                    result.Message = dbResult.Message;
                    result.Exception = dbResult.Exception;
                    result.MessageType = MessageType.Error;
                    result.Info = MessageType.Error.Description();
                    result.Count = 0;

                    return result;
                }

                var entity = dbResult.Data;

                entity.IsDeleted = false;
                var updateResult = Update(entity, updatedById);

                if (!updateResult.Success)
                {
                    result.Success = false;
                    result.Message = updateResult.Message;
                    result.Exception = updateResult.Exception;
                    result.MessageType = MessageType.Error;
                    result.Info = MessageType.Error.Description();
                    result.Count = 0;

                    return result;
                }

                result.Success = true;
                result.MessageType = MessageType.Success;
                result.Info = MessageType.Success.Description();
                result.Count = 0;

                return result;

            }
            catch (Exception e)
            {
                result.Success = false;
                result.Exception = e;
                result.MessageType = MessageType.Error;
                result.Info = MessageType.Error.Description();
                result.Count = 0;

                return result;
            }
        }

        /// <summary>
        /// Restore an object async
        /// set object IsDeleted to Available
        /// </summary>
        /// <param name="id">object id</param>
        /// <param name="updatedById">id of user who want to enable this object</param>
        public async Task<DbResult> EnableAsync(int id, int updatedById)
        {
            var result = new DbResult();

            try
            {
                var dbResult = await GetAsyncByAdmin(id);

                if (!dbResult.Success)
                {
                    result.Success = false;
                    result.Message = dbResult.Message;
                    result.Exception = dbResult.Exception;
                    result.MessageType = MessageType.Error;
                    result.Info = MessageType.Error.Description();
                    result.Count = 0;

                    return result;
                }

                var entity = dbResult.Data;

                entity.IsDeleted = false;
                var updateResult = Update(entity, updatedById);

                if (!updateResult.Success)
                {
                    result.Success = false;
                    result.Message = updateResult.Message;
                    result.Exception = updateResult.Exception;
                    result.MessageType = MessageType.Error;
                    result.Info = MessageType.Error.Description();
                    result.Count = 0;

                    return result;
                }

                result.Success = true;
                result.MessageType = MessageType.Success;
                result.Info = MessageType.Success.Description();
                result.Count = 0;

                return result;

            }
            catch (Exception e)
            {
                result.Success = false;
                result.Exception = e;
                result.MessageType = MessageType.Error;
                result.Info = MessageType.Error.Description();
                result.Count = 0;

                return result;
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// delete prementaly an object from database
        /// </summary>
        /// <param name="entity">object</param>
        public virtual DbResult Delete(T entity)
        {
            var result = new DbResult();

            try
            {
                if (!Validation.DeleteValidation(entity, out var validationMessage))
                {
                    result.Success = false;
                    result.Count = 0;
                    result.MessageType = MessageType.InvalidData;
                    result.Info = MessageType.InvalidData.Description();
                    result.Message = validationMessage;

                    return result;
                }

                Context.Set<T>().Remove(entity);
                Save();

                result.Success = true;
                result.Count = 0;
                result.MessageType = MessageType.Success;
                result.Info = MessageType.Success.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Count = 0;
                result.MessageType = MessageType.Error;
                result.Info = MessageType.Error.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// delete prementaly an object from database async
        /// </summary>
        /// <param name="entity">object</param>
        public virtual async Task<DbResult> DeleteAsync(T entity)
        {
            var result = new DbResult();

            try
            {
                if (!Validation.DeleteValidation(entity, out var validationMessage))
                {
                    result.Success = false;
                    result.Count = 0;
                    result.MessageType = MessageType.InvalidData;
                    result.Info = MessageType.InvalidData.Description();
                    result.Message = validationMessage;

                    return result;
                }


                Context.Set<T>().Remove(entity);
                await SaveAsync();

                result.Success = true;
                result.Count = 0;
                result.MessageType = MessageType.Success;
                result.Info = MessageType.Success.Description();

                return result;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Count = 0;
                result.MessageType = MessageType.Error;
                result.Info = MessageType.Error.Description();
                result.Exception = e;

                return result;
            }
        }

        /// <summary>
        /// delete prementaly an object from database with objectId
        /// </summary>
        /// <param name="entityId">object Id</param>
        public virtual DbResult Delete(int entityId)
        {
            try
            {
                var entity = GetByAdmin(entityId).Data;

                return Delete(entity);
            }
            catch (Exception e)
            {
                return new DbResult
                {
                    Success = false,
                    Count = 0,
                    MessageType = MessageType.Error,
                    Info = MessageType.Error.Description(),
                    Exception = e
                };
            }
        }

        /// <summary>
        /// delete prementaly an object from database async with objectId
        /// </summary>
        /// <param name="entityId">object Id</param>
        public virtual async Task<DbResult> DeleteAsync(int entityId)
        {
            try
            {
                var dbResult = await GetAsyncByAdmin(entityId);

                return await DeleteAsync(dbResult.Data);
            }
            catch (Exception e)
            {
                return new DbResult
                {
                    Success = false,
                    Count = 0,
                    MessageType = MessageType.Error,
                    Info = MessageType.Error.Description(),
                    Exception = e
                };
            }
        }

        #endregion

        #region Save DB

        /// <summary>
        /// save database changes
        /// </summary>
        public virtual void Save()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// save database changes async
        /// </summary>
        public virtual async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }

                this._disposed = false;
            }
        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Func

        private T FillInsertDefaultProperties(T entity, int? createdById)
        {
            entity.CreatedByUserId = createdById;
            entity.CreatedOn = DateTime.Now;

            entity.IsDeleted = false;

            if (entity.OwnerUserId == 0 && createdById.HasValue)
                entity.OwnerUserId = createdById;

            return entity;
        }

        private T FillUpdateDefaultProperties(T newValue, T oldValue, int updatedById)
        {
            newValue.CreatedByUserId = oldValue.CreatedByUserId;
            newValue.CreatedOn = oldValue.CreatedOn;

            newValue.UpdatedByUserId = updatedById;
            newValue.UpdatedOn = DateTime.Now;

            return newValue;
        }

        #endregion

    }
}