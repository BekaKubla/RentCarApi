﻿using System.Linq.Expressions;

namespace RentCarApi.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        void Update(T entity);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
    }
}
