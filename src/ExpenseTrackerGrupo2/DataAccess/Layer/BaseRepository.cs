using Dapper;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Layer;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly IDbConnectionFactory _dbConnectionFactory;

    public BaseRepository(IDbConnectionFactory IDbConnectionFactory)
    {
        _dbConnectionFactory = IDbConnectionFactory;
    }

    public async Task<IList<T>> GetAll()
    {
        var connection = await _dbConnectionFactory.CreateConnection();
        return (await connection.QueryAsync<T>("SELECT * FROM " + typeof(T).Name)).ToList();
    }

    public async Task<T> GetById(Guid id)
    {
        var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.QuerySingleOrDefaultAsync<T>("SELECT * FROM " + typeof(T).Name + " WHERE Id = @Id", new { Id = id });
        return result;
    }

    public async Task<int> Create(T entity)
    {
        var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.ExecuteAsync("INSERT INTO " + typeof(T).Name + " VALUES (@Entity)", new { Entity = entity });
        return result;
    }

    public async Task<int> Update(T entity)
    {
        var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.ExecuteAsync("UPDATE " + typeof(T).Name + " SET @Entity WHERE Id = @Id", new { Entity = entity });
        return result;
    }

    public async Task<bool> Delete(Guid id)
    {
        var connection = await _dbConnectionFactory.CreateConnection();
        var result = await connection.ExecuteAsync("DELETE FROM " + typeof(T).Name + " WHERE Id = @Id", new { Id = id });
        return result > 0;
    }
}
