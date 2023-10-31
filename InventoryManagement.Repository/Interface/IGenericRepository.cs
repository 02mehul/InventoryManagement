using InventoryManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.Interface
{
    public interface IGenericRepository<TType, TEntity> where TEntity : BaseEntity<TType> where TType : struct
    {
        IQueryable<TEntity> GetAll(bool includeDeleted = false, bool enableTracking = false);

        Task<TEntity> GetByIdAsync(TType id, bool enableTracking = false);

        Task<TEntity> SingleOrDefaultAsync(TType id, bool enableTracking = false);

        Task CreateAsync(TEntity entity, Guid userId);

        void Update(TEntity entity, Guid userId);

        Task MarkDeleteAsync(TType id, Guid userId);

        Task HardDeleteAsync(TType id);

        Task SaveAsync();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        //Task<IEnumerable<TEntity>> ExecWithStoreProcedure(string storedProcedureName);
        Task<List<TEntity>> ExecWithStoreProcedure(string storedProcedureName);
        Task<List<TEntity>> ExecWithStoreProcedureWithFilter(string storedProcedureName, object parameters);

        DataTable ToDataTable<T>(List<T> data, string name);
        void ExecStoreProcedure(string storedProcedureName);
    }
}



