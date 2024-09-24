using System.Reflection;
using Dapper;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Utils;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Concretes;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly IDbConnectionFactory _dbConnectionFactory;

    public BaseRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    private string GetColumnNames()
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        return string.Join(", ", properties.Select(p => StringUtils.ToSnakeCase(p.Name)));
    }

    private string GetColumnParameters()
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        return string.Join(", ", properties.Select(p => "@" + StringUtils.ToSnakeCase(p.Name)));
    }

    private string GetSetClause()
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        return string.Join(", ", properties.Select(p => $"{StringUtils.ToSnakeCase(p.Name)} = @{StringUtils.ToSnakeCase(p.Name)}"));
    }

    public async Task<IList<T>> GetAll()
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        return (await connection.QueryAsync<T>($"SELECT * FROM {tableName}")).ToList();
    }

    public async Task<T> GetById(Guid id)
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {tableName} WHERE {StringUtils.ToSnakeCase(typeof(T).Name)}_id = @Id", new { Id = id });
        return result;
    }

    public async Task<int> Create(T entity)
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = $"INSERT INTO {tableName} ({GetColumnNames()}) VALUES ({GetColumnParameters()})";
        return await connection.ExecuteAsync(query, entity);
    }

    public async Task<int> Update(T entity)
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = $"UPDATE {tableName} SET {GetSetClause()} WHERE {StringUtils.ToSnakeCase(typeof(T).Name)}_id = @Id";
        return await connection.ExecuteAsync(query, entity);
    }

    public async Task<bool> Delete(Guid id)
    {
        var tableName = StringUtils.ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.ExecuteAsync($"DELETE FROM {tableName} WHERE {StringUtils.ToSnakeCase(typeof(T).Name)}_id = @Id", new { Id = id });
        return result > 0;
    }
}
