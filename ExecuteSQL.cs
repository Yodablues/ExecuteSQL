using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ExecuteSQL
{
    public class ExecuteSQL
    {
        protected SqlCommand SqlCommand { get; set; }
        protected SqlConnection SqlConnection { get; set; }
        protected string ConnectionStringName { get; set; }

        protected SqlCommand SetupSqlCommand(string procedureName, CommandType commandType)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = procedureName;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = SqlConnection;
                return sqlCommand;
            }
            catch (Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }

        protected SqlConnection SetupSQLConnection(string connectionStringName)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }

        public DataSet Execute()
        {
            try
            {
                DataSet dataSet = new DataSet();
                this.SqlConnection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SqlCommand);
                dataAdapter.Fill(dataSet, "results");     
                return dataSet;
            }
            catch (Exception ex)
            {
                this.SqlConnection.Close();
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }            
        }
    }
}
