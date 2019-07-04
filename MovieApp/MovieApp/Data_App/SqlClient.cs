using System;
using System.Data.SqlClient;
using System.Data;

namespace MovieApp
{
    public class SqlClient : IDisposable
    {
        private SqlConnection conn = new SqlConnection(@"Server=tcp:dudgnl23.database.windows.net,1433;Initial Catalog=diaryApp;Persist Security Info=False;User ID=dudgnl23;Password=mk232312!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


        private SqlCommand Command;

        public SqlClient()
        {
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public DataTable ExecuteDataTable()
        {
            DataTable table = new DataTable();

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Command);
                sqlDataAdapter.Fill(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Command.Dispose();
            }

            return table;
        }

        public DataSet ExecuteDataSet()
        {
            DataSet table = new DataSet();

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Command);
                sqlDataAdapter.Fill(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Command.Dispose();
            }

            return table;
        }
        public void SetQuery(string aSql, CommandType aCommandType)
        {
            Command = new SqlCommand(aSql, conn);
            Command.CommandType = aCommandType;

        }
        public void AddParameter(string aName, object aValue)
        {
            Command.Parameters.Add(new SqlParameter(aName, aValue));
        }
        ~SqlClient()
        {
            //conn.Close();
            //  Dispose();
        }
        public int ExcuteNonQuery()
        {
            return Command.ExecuteNonQuery();
        }
        public void Dispose()
        {
            conn.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
