using InventoryManagement.Entity;
using InventoryManagement.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace InventoryManagement.Repository
{
    internal class GenericRepository<TType, TEntity> : IGenericRepository<TType, TEntity> where TEntity : BaseEntity<TType> where TType : struct
    {
        private readonly CIDBContext _dbContext;

        public GenericRepository(CIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(TEntity entity, Guid userId)
        {
            entity.IsDeleted = false;
            entity.IsActive = true;
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = userId;
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task MarkDeleteAsync(TType id, Guid userId)
        {
            var entity = await GetByIdAsync(id, enableTracking: true);
            entity.IsDeleted = true;
            Update(entity, userId);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        public IQueryable<TEntity> GetAll(bool includeDeleted = false, bool enableTracking = false)
        {
            var entities = _dbContext.Set<TEntity>().AsQueryable();
            //if (!enableTracking)
            //    entities = entities.AsNoTracking();
            if (!includeDeleted)
                return entities.Where(e => !e.IsDeleted);
            return entities;
        }

        public Task<TEntity> GetByIdAsync(TType id, bool enableTracking = false)
        {
            return GetAll().FirstOrDefaultAsync(e => e.Id.Equals(id));
            //if (enableTracking)
            //else
            //            return GetAll().AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task HardDeleteAsync(TType id)
        {
            var entity = await GetByIdAsync(id, enableTracking: true);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity, Guid userId)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = userId;
            _dbContext.Set<TEntity>().Update(entity);
        }

        public Task<TEntity> SingleOrDefaultAsync(TType id, bool enableTracking = false)
        {
            return GetAll().SingleOrDefaultAsync(e => e.Id.Equals(id));
            //if (enableTracking)
            //else
            //            return GetAll().AsNoTracking().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }
        public async Task<List<TEntity>> ExecWithStoreProcedure(string storedProcedureName)
        {
            var result = await _dbContext.Set<TEntity>().FromSqlRaw($"{storedProcedureName}").ToListAsync();
            return result;
        }

        public void ExecStoreProcedure(string storedProcedureName)
        {
            _dbContext.Database.ExecuteSqlRaw(storedProcedureName);
        }

        public async Task<List<TEntity>> ExecWithStoreProcedureWithFilter(string storedProcedureName, object parameters)
        {
            List<SqlParameter> sqlParams = GetSqlParameters(parameters);
            //var result =  _dbContext.Set<TEntity>().FromSqlRaw($"{storedProcedureName}");
            var result = await _dbContext.Set<TEntity>().FromSqlRaw($"{storedProcedureName} {sqlParams.ToArray()}").ToListAsync();
            return result;
        }

        private List<SqlParameter> GetSqlParameters(object params1)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            Type myType = params1.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(params1, null);

                sqlParameters.Add(new SqlParameter { ParameterName = $"@{prop.Name}", Value = propValue });
            }
            return sqlParameters;
        }

        public DataTable ToDataTable<T>(List<T> data, string name)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new(name);
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);
            }
            return table;
        }
    }
}
