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
                    connectionString = @"Server=191.252.220.13;Database=Construtech;User ID=Dev;Password=%!KZ8xQft2we7xwh3;Encrypt=True;TrustServerCertificate=true;";
                #endif  

                return connectionString;
            }
        }
    }
}
