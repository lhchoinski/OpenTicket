using MySql.Data.MySqlClient;

namespace OpenTicket.Infra.Data.Context
{
    public class DataContext
    {
        public MySqlConnection Connection { get; }
        public DataContext(string connection)
        {
            Connection = new MySqlConnection(connection);
            Connection.Open();
        }
        public void Dispose() => Connection.Dispose();
    }
}
