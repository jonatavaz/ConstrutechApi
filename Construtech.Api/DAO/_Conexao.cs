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
                    connectionString = @"Server=20.64.251.243;Database=Construtech;User ID=jonatavaz;Password=Claudia1976$;Encrypt=True;TrustServerCertificate=true;";
                #endif  

                return connectionString;
            }
        }
    }
}
