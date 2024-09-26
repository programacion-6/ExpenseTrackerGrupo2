using Dapper;
using ExpenseTrackerGrupo2.Persistence.Database;
using ExpenseTrackerGrupo2.Utils;

namespace ExpenseTrackerGrupo2.DataAccess.Concretes;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly IDbConnectionFactory _dbConnectionFactory;

    public BaseRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IList<T>> GetAll()
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        return (await connection.QueryAsync<T>($"SELECT * FROM {tableName}")).ToList();
    }

    public async Task<T> GetById(Guid id)
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {tableName} WHERE {StringUtils.ToSnakeCase(typeof(T).Name)}_id = @Id", new { Id = id });
        return result;
    }

    public async Task<int> Create(T entity)
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        var query = $"INSERT INTO {tableName} ({StringUtils.GetColumnNames<T>()}) VALUES ({StringUtils.GetColumnParameters<T>()})";
        return await connection.ExecuteAsync(query, entity);
    }

    public async Task<int> Update(T entity)
{
    var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
    using var connection = await _dbConnectionFactory.CreateConnectionAsync();
    var query = $"UPDATE {tableName} SET {StringUtils.GetSetClause<T>()} WHERE {StringUtils.ToSnakeCase(typeof(T).Name)}_id = @Expense_Id";
    return await connection.ExecuteAsync(query, entity);
}

    public async Task<bool> Delete(Guid id)
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync($"DELETE FROM {tableName} WHERE {StringUtils.ToSnakeCase(typeof(T).Name)}_id = @Id", new { Id = id });
        return result > 0;
    }
}
