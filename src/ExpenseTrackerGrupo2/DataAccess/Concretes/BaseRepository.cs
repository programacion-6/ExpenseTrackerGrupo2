using System.Reflection;
using System.Text.RegularExpressions;
using Dapper;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Concretes;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly IDbConnectionFactory _dbConnectionFactory;

    public BaseRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    private string ToSnakeCase(string input)
    {
        return Regex.Replace(input, "(?<!^)[A-Z]", "_$0").ToLower();
    }

    private string GetColumnNames()
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        return string.Join(", ", properties.Select(p => ToSnakeCase(p.Name)));
    }

    private string GetColumnParameters()
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        return string.Join(", ", properties.Select(p => "@" + ToSnakeCase(p.Name)));
    }

    private string GetSetClause()
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        return string.Join(", ", properties.Select(p => $"{ToSnakeCase(p.Name)} = @{ToSnakeCase(p.Name)}"));
    }

    public async Task<IList<T>> GetAll()
    {
        var tableName = ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        return (await connection.QueryAsync<T>($"SELECT * FROM {tableName}")).ToList();
    }

    public async Task<T> GetById(Guid id)
    {
        var tableName = ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {tableName} WHERE {ToSnakeCase(typeof(T).Name)}_id = @Id", new { Id = id });
        return result;
    }

    public async Task<int> Create(T entity)
    {
        var tableName = ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = $"INSERT INTO {tableName} ({GetColumnNames()}) VALUES ({GetColumnParameters()})";
        return await connection.ExecuteAsync(query, entity);
    }

    public async Task<int> Update(T entity)
    {
        var tableName = ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        var query = $"UPDATE {tableName} SET {GetSetClause()} WHERE {ToSnakeCase(typeof(T).Name)}_id = @Id";
        return await connection.ExecuteAsync(query, entity);
    }

    public async Task<bool> Delete(Guid id)
    {
        var tableName = ToSnakeCase(typeof(T).Name);
        using var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.ExecuteAsync($"DELETE FROM {tableName} WHERE {ToSnakeCase(typeof(T).Name)}_id = @Id", new { Id = id });
        return result > 0;
    }
}