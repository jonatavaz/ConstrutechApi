namespace DAO
{
    public class _Conexao
    {
        public static string StringDeConexao
        {
            get
            {
                string connectionString;

                #if DEBUG
                    connectionString = @"Server=sqldb-climimed-dev.database.windows.net;Database=Construtech;User ID=U_Desenvolvimento;Password=Claudia1976$;Encrypt=True;TrustServerCertificate=true;";
                #endif  

                return connectionString;
            }
        }
    }
}
