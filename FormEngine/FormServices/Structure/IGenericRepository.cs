using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FormEngine.Database.Common.Interface;
using FormEngine.Services.Common;

namespace FormEngine.Services.Structure
{
    public interface IGenericRepository<T> where T : Auditable
    {
        #region Create

        /// <summary>
        /// Insert object to database
        /// </summary>
        /// <param name="entity">object</param>
        /// <param name="createdById">id of user who want to insert this object</param>
        /// <returns>
        /// return inserted object with id
        /// </returns>
        DbResult<T> Add(T entity, Guid? createdById);

        /// <summary>
        /// Insert object to database async
        /// </summary>
        /// <param name="entity">object</param>
        /// <param name="createdById">id of user who want to insert this object</param>
        /// <returns>
        /// return inserted object with id
        /// </returns>
        Task<DbResult<T>> AddAsync(T entity, Guid? createdById);

        #endregion

        #region Read By Admin

        /// <summary>
        /// Find object by id even thats's ViewState set to Deleted
        /// </summary>
        /// <param name="id"> object id </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        DbResult<T> GetByAdmin(Guid id);

        /// <summary>
        /// Find object Async by id even even thats's ViewState set to Deleted
        /// </summary>
        /// <param name="id"> object id </param>
        /// <returns>
        /// Return object if that's found else method returns null
        /// </returns>
        Task<DbResult<T>> GetAsyncByAdmin(Guid id);

        /// <summary>
        /// Get all objects even those ViewState set to Deleted
        /// </summary>
        /// <returns>
        /// Return objects if those are found else method returns null
        /// </returns>
        DbResult<IQueryable<T>> GetAllByAdmin();

        /// <summary>
        /// Get all objects async even those ViewState set to Deleted
        /// </summary>
        /// <returns>
        /// Return objects if those are found else method returns null
        /// </returns>
        Task<DbResult<ICollection<T>>> GetAllAsyncByAdmin();

        /// <summary>
        /// Find object by some expression even that's ViewState set to Deleted
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        DbResult<T> FindByAdmin(Expression<Func<T, bool>> match);

        /// <summary>
        /// Find object async by some expression even that's ViewState set to Deleted
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        Task<DbResult<T>> FindAsyncByAdmin(Expression<Func<T, bool>> match);

        /// <summary>
        /// Find objects by some expression even those's ViewState set to Deleted
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        DbResult<ICollection<T>> FindAllByAdmin(Expression<Func<T, bool>> match);

        /// <summary>
        /// Find objects async by some expression even those's ViewState set to Deleted
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        Task<DbResult<ICollection<T>>> FindAllAsyncByAdmin(Expression<Func<T, bool>> match);

        /// <summary>
        /// Find objects by some expression even those's ViewState set to Deleted
        /// </summary>
        /// <param name="predicate"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        DbResult<IQueryable<T>> FindByByAdmin(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find objects async by some expression even those's ViewState set to Deleted
        /// </summary>
        /// <param name="predicate"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        Task<DbResult<ICollection<T>>> FindByAsyncByAdmin(Expression<Func<T, bool>> predicate);

        //DbResult<IQueryable<T>> GetAllIncludingByAdmin(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAllIncludingByAdmin(params Expression<Func<T, object>>[] includeProperties);


        /// <summary>
        /// Count objects quantity even those's that ViewState set to Deleted
        /// </summary>
        /// <returns>
        /// return objects quantity
        /// </returns>
        DbResult<int> CountByAdmin();

        /// <summary>
        /// Count objects quantity async even those's that ViewState set to Deleted
        /// </summary>
        /// <returns>
        /// return objects quantity
        /// </returns>
        Task<DbResult<int>> CountAsyncByAdmin();

        /// <summary>
        /// Check object exists by id even thats's ViewState set to Deleted
        /// </summary>
        /// <param name="id">object id</param>
        /// <returns></returns>
        DbResult<bool> ExistsByAdmin(Guid id);

        #endregion

        #region Read

        /// <summary>
        /// Find available object by some expression
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        DbResult<T> Find(Expression<Func<T, bool>> match);

        /// <summary>
        /// Find available object async by some expression
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        Task<DbResult<T>> FindAsync(Expression<Func<T, bool>> match);

        /// <summary>
        /// Find available objects by some expression
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        DbResult<ICollection<T>> FindAll(Expression<Func<T, bool>> match);

        /// <summary>
        /// Find available objects async by some expression
        /// </summary>
        /// <param name="match"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        Task<DbResult<ICollection<T>>> FindAllAsync(Expression<Func<T, bool>> match);

        /// <summary>
        /// Find available objects by some expression
        /// </summary>
        /// <param name="predicate"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        DbResult<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find available objects async by some expression
        /// </summary>
        /// <param name="predicate"> expression </param>
        /// <returns>
        /// return objects if that's found else method returns null
        /// </returns>
        Task<DbResult<ICollection<T>>> FindByAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find available object by id
        /// </summary>
        /// <param name="id"> object id </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        DbResult<T> Get(Guid id);

        /// <summary>
        /// Find available object async by id
        /// </summary>
        /// <param name="id"> object id </param>
        /// <returns>
        /// return object if that's found else method returns null
        /// </returns>
        Task<DbResult<T>> GetAsync(Guid id);

        /// <summary>
        /// Get all available objects
        /// </summary>
        /// <returns>
        /// Return objects if those are found else method returns null
        /// </returns>
        DbResult<IQueryable<T>> GetAll();

        /// <summary>
        /// Get all available objects async
        /// </summary>
        /// <returns>
        /// Return objects if those are found else method returns null
        /// </returns>
        Task<DbResult<ICollection<T>>> GetAllAsync();

        //DbResult<IQueryable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Count available objects quantity
        /// </summary>
        /// <returns>
        /// return objects quantity
        /// </returns>
        DbResult<int> Count();

        /// <summary>
        /// Count available objects quantity async
        /// </summary>
        /// <returns>
        /// return objects quantity
        /// </returns>
        Task<DbResult<int>> CountAsync();

        /// <summary>
        /// Check available object exists by id
        /// </summary>
        /// <param name="id">object id</param>
        /// <returns></returns>
        DbResult<bool> Exists(Guid id);

        #endregion

        #region Update

        /// <summary>
        /// update an object data
        /// </summary>
        /// <param name="entity">object must have id</param>
        /// <param name="updatedById">id of user who want to update this object</param>
        /// <returns>
        /// returns updated object
        /// </returns>
        DbResult<T> Update(T entity, Guid updatedById);

        /// <summary>
        /// update an object data async
        /// </summary>
        /// <param name="entity">new value object with itself id</param>
        /// <param name="updatedById">id of user who want to update this object</param>
        /// <returns>
        /// returns updated object
        /// </returns>
        Task<DbResult<T>> UpdateAsync(T entity, Guid updatedById);

        /// <summary>
        /// Logically delete an object
        /// set object view state to Deleted
        /// </summary>
        /// <param name="id">object id</param>
        /// <param name="deletedById">id of user who want to disable this object</param>
        DbResult Disable(Guid id, Guid deletedById);

        /// <summary>
        /// Logically delete an object async
        /// set object view state to Deleted
        /// </summary>
        /// <param name="id">object id</param>
        /// <param name="deletedById">id of user who want to disable this object</param>
        Task<DbResult> DisableAsync(Guid id, Guid deletedById);

        /// <summary>
        /// Restore an object
        /// set object view state to Available
        /// </summary>
        /// <param name="id">object id</param>
        /// <param name="updatedById">id of user who want to enable this object</param>
        DbResult Enable(Guid id, Guid updatedById);

        /// <summary>
        /// Restore an object async
        /// set object view state to Available
        /// </summary>
        /// <param name="id">object id</param>
        /// <param name="updatedById">id of user who want to enable this object</param>
        Task<DbResult> EnableAsync(Guid id, Guid updatedById);

        #endregion

        #region Delete

        /// <summary>
        /// delete prementaly an object from database
        /// </summary>
        /// <param name="entity">object</param>
        DbResult Delete(T entity);

        /// <summary>
        /// delete prementaly an object from database async
        /// </summary>
        /// <param name="entity">object</param>
        Task<DbResult> DeleteAsync(T entity);

        /// <summary>
        /// delete prementaly an object from database with objectId
        /// </summary>
        /// <param name="entityId">object Id</param>
        DbResult Delete(Guid entityId);

        /// <summary>
        /// delete prementaly an object from database async with objectId
        /// </summary>
        /// <param name="entityId">object Id</param>
        Task<DbResult> DeleteAsync(Guid entityId);

        #endregion

        #region Save DB

        /// <summary>
        /// save database changes
        /// </summary>
        void Save();

        /// <summary>
        /// save database changes async
        /// </summary>
        Task SaveAsync();

        #endregion

        #region Dispose

        void Dispose();

        #endregion
    }
}