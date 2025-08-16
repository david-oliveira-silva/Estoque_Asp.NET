using FirebirdSql.Data.FirebirdClient;

namespace ProjetoWeb.Data
{
    public class FirebirdConnection
    {

        private static readonly string conexaoString =
               @"User=SYSDBA;
      Password=masterkey;
      Database=C:\Users\Darve\OneDrive\Documentos\C#\Banco de dados\BANCO_TESTE.FDB;
      DataSource=localhost;
      Port=3050;
      Dialect=3;
      Charset=UTF8;";


        public static FbConnection GetFbConnection()
        {

            return new FbConnection(conexaoString);
        }


        public static void OpenConnection(FbConnection fbConnection)
        {

            try
            {
                fbConnection.Open();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void CloseConnection(FbConnection fbConnection)
        {

            try
            {
                fbConnection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
