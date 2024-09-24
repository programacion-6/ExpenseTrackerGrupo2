using System.Data;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;

public interface IDbConnectionFactory
{
     Task<IDbConnection> CreateConnection();
}
