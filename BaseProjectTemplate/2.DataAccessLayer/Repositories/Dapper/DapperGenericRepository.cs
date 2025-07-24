using BaseProjectTemplate._2.DataAccessLayer.Abstract;
using Dapper;
using Npgsql;
using System.Data;
using System.Reflection;

namespace BaseProjectTemplate._2.DataAccessLayer.Repositories.Dapper
{
    public class DapperGenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly string _tableName;
        private readonly string _connectionString;

        public DapperGenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");

            var tableAttr = typeof(T).GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.TableAttribute>();
            _tableName = tableAttr?.Name ?? typeof(T).Name;  // Önce attribute, yoksa class adı
        }

        private IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var sql = $"SELECT * FROM \"{_tableName}\" WHERE \"isDeleted\" = FALSE";
            using var connection = CreateConnection();
            return await connection.QueryAsync<T>(sql);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var sql = $"SELECT * FROM \"{_tableName}\" WHERE \"Id\" = @Id AND \"isDeleted\" = FALSE";
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
        }

        public async Task InsertAsync(T entity, string userId)
        {
            using var connection = CreateConnection();
            SetAuditFieldsIfNeeded(entity, "Insert", userId);
            var sql = GenerateInsertSql(entity);
            await connection.ExecuteAsync(sql, entity);
        }

        public async Task UpdateAsync(T entity, string userId)
        {
            using var connection = CreateConnection();
            SetAuditFieldsIfNeeded(entity, "Update", userId);
            var sql = GenerateUpdateSql(entity);
            await connection.ExecuteAsync(sql, entity);
        }

        public async Task DeleteAsync(Guid id, string userId)
        {
            using var connection = CreateConnection();

            // 1. Kayıt var mı, çek
            var entity = await GetByIdAsync(id);
            if (entity == null) return;

            // 2. Audit alanlarını doldur
            SetAuditFieldsIfNeeded(entity, "Delete", userId);

            // 3. Update SQL'ini hazırla
            var sql = GenerateUpdateSql(entity);

            // 4. Update et (soft delete)
            await connection.ExecuteAsync(sql, entity);
        }


        private string GenerateInsertSql(T entity)
        {
            var props = typeof(T).GetProperties(); // "Id" hariç bırakma!
            var columns = string.Join(", ", props.Select(p => $"\"{p.Name}\""));
            var values = string.Join(", ", props.Select(p => $"@{p.Name}"));
            return $"INSERT INTO \"{_tableName}\" ({columns}) VALUES ({values})";
        }


        private string GenerateUpdateSql(T entity)
        {
            var props = typeof(T).GetProperties().Where(p => p.Name != "Id");
            var setClause = string.Join(", ", props.Select(p => $"\"{p.Name}\" = @{p.Name}"));
            return $"UPDATE \"{_tableName}\" SET {setClause} WHERE \"Id\" = @Id";
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            var sql = $"SELECT * FROM \"{_tableName}\" WHERE \"Id\" = @Id AND \"isDeleted\" = FALSE";
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
        }

        private void SetAuditFieldsIfNeeded(T entity, string operationType, string userId)
        {
            var type = typeof(T);
            var now = DateTime.UtcNow;

            switch (operationType)
            {
                case "Insert":
                    if (type.GetProperty("CreatedAt") is { } prop1 && prop1.CanWrite)
                        prop1.SetValue(entity, now);

                    if (type.GetProperty("CreatedBy") is { } prop2 && prop2.CanWrite)
                        prop2.SetValue(entity, ParseUserId(userId, prop2.PropertyType));

                    if (type.GetProperty("OwnerId") is { } prop3 && prop3.CanWrite)
                        prop3.SetValue(entity, ParseUserId(userId, prop3.PropertyType));

                    if (type.GetProperty("isDeleted") is { } prop4 && prop4.CanWrite)
                        prop4.SetValue(entity, false);
                    break;

                case "Update":
                    if (type.GetProperty("UpdatedAt") is { } prop5 && prop5.CanWrite)
                        prop5.SetValue(entity, now);

                    if (type.GetProperty("UpdatedBy") is { } prop6 && prop6.CanWrite)
                        prop6.SetValue(entity, ParseUserId(userId, prop6.PropertyType));
                    break;

                case "Delete":
                    if (type.GetProperty("DeletedAt") is { } prop7 && prop7.CanWrite)
                        prop7.SetValue(entity, now);

                    if (type.GetProperty("DeletedBy") is { } prop8 && prop8.CanWrite)
                        prop8.SetValue(entity, ParseUserId(userId, prop8.PropertyType));

                    if (type.GetProperty("isDeleted") is { } prop9 && prop9.CanWrite)
                        prop9.SetValue(entity, true);
                    break;
            }
        }

        private object ParseUserId(string userId, Type propertyType)
        {
            if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                return Guid.Parse(userId);

            // Eğer string tutuyorsan doğrudan dön
            return userId;
        }

    }
}
