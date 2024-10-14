namespace Ecommerce.Domain.IRepositories.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Returns all elements of the specified type <typeparamref name="TEntity"/> from the database entity.
        /// The user must specify the type <typeparamref name="TEntity"/> when calling this method.
        /// </summary>
        /// <typeparam name="TEntity">The type of the elements to be retrieved.</typeparam>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation, containing a list of elements of type <typeparamref name="TEntity"/>.</returns>
        public Task<List<TEntity>> GetAllPaginatedAsync(int pageNumber, int pageSize);


        /// <summary>
        /// Returns all elements of the specified type <typeparamref name="DTO"/> from the database level projection.
        /// The user must specify the type <typeparamref name="DTO"/> when calling this method.
        /// </summary>
        /// <typeparam name="DTO">The type of the elements to be retrieved.</typeparam>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation, containing a list of elements of type <typeparamref name="DTO"/>.</returns>
        public Task<List<DTO>> GetAllPaginatedAsync<DTO>(int pageNumber, int pageSize);


        /// <summary>
        /// Queries the database to find an element by its primary key, using the specified type <typeparamref name="TEntity"/> as the database entity.
        /// The user must specify the type <typeparamref name="TEntity"/> when calling this method.
        /// </summary>
        /// <param name="Id">The primary key of the entity to be retrieved.</param>
        /// <typeparam name="TEntity">The type of the entity to be retrieved.</typeparam>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation, containing the element of type <typeparamref name="TEntity"/> if found, or null if not.</returns>
        public Task<TEntity?> GetById(int Id);


        /// <summary>
        /// Queries the database to find a projection element by its primary key, using the specified type <typeparamref name="DTO"/>.
        /// The user must specify the type <typeparamref name="DTO"/> when calling this method.
        /// </summary>
        /// <param name="Id">The primary key of the projection entity to be retrieved.</param>
        /// <typeparam name="DTO">The type of the projection entity to be retrieved.</typeparam>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation, containing the element of type <typeparamref name="DTO"/> if found.</returns>
        public Task<DTO?> GetById<DTO>(int Id);


        /// <summary>
        /// Updates an entity in the database using its primary key.
        /// </summary>
        /// <param name="entity">The updated entity.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation, returning true if the update was successful, otherwise false.</returns>
        public Task<bool> Update(TEntity entity);


        /// <summary>
        /// Deletes an entity from the database using its primary key.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation, returning true if the deletion was successful, otherwise false.</returns>
        public Task<bool> Delete(TEntity entity);


        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">entity to be added.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation, returning the primary key of the newly added entity.</returns>
        public Task<int> Add(TEntity entity);

    }
}
