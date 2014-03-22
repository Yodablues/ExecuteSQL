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
    public class ExecuteStoredProcedure
    {
        private SqlConnection SqlConnection { get; set; }
        private string ConnectionStringName { get; set; }
        private string ProcedureName { get; set; }
        private SqlCommand SqlCommand { get; set; }

        public ExecuteStoredProcedure(string connectionStringName, string procedureName)
        {
            try
            {
                SqlConnection = SetupSQLConnection(connectionStringName);
                ProcedureName = null;
                SqlCommand = SetupSqlCommand(procedureName);
            }
            catch(Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }

        public ExecuteStoredProcedure(string connectionStringName, string procedureName, List<SqlParameter> parameters)
        {
            try
            {
                SqlConnection = SetupSQLConnection(connectionStringName);
                ProcedureName = procedureName;
                SqlCommand = SetupSqlCommand(procedureName);
                SetupSQLParameters(parameters);
            }
            catch(Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }

        private SqlConnection SetupSQLConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                return connection;
            }
            catch(Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }

        private SqlConnection SetupSQLConnection(string connectionStringName)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                return connection;
            }
            catch(Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }

        private SqlCommand SetupSqlCommand()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Connection = SqlConnection;
                return sqlCommand;
            }
            catch(Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;                
            }
        }

        public void SetupSQLParameters(List<SqlParameter> sqlParameters)
        {
            try
            {
                if (sqlParameters.Count > 0)
                {
                    foreach (SqlParameter param in sqlParameters)
                    {
                        SqlCommand.Parameters.Add(param);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }

        private SqlCommand SetupSqlCommand(string procedureName)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = procedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = SqlConnection;
                return sqlCommand;
            }
            catch(Exception ex)
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
                SqlConnection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SqlCommand);
                dataAdapter.Fill(dataSet, "procedureResults");
                SqlConnection.Close();
                return dataSet;
            }
            catch(Exception ex)
            {
                SqlConnection.Close();
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;  
            }
        }

    }
}
