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
                    connectionString = @"Server=;Database=Construtech;User ID=Dev;Password=;Encrypt=True;TrustServerCertificate=true;";
                #endif  

                return connectionString;
            }
        }
    }
}
