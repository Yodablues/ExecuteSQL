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
    public class ExecuteStoredProcedure : ExecuteSQL
    {
        private string ProcedureName { get; set; }        

        public ExecuteStoredProcedure(string connectionStringName, string procedureName)
        {
            try
            {                
                this.SqlConnection = this.SetupSQLConnection(connectionStringName);
                this.ProcedureName = null;
                this.SqlCommand = this.SetupSqlCommand(procedureName, CommandType.StoredProcedure);
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
                this.SqlConnection = this.SetupSQLConnection(connectionStringName);
                this.ProcedureName = procedureName;
                this.SqlCommand = this.SetupSqlCommand(procedureName, CommandType.StoredProcedure);
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

        public void SetupSQLParameters(List<SqlParameter> sqlParameters)
        {
            try
            {
                if (sqlParameters.Count > 0)
                {
                    foreach (SqlParameter param in sqlParameters)
                    {
                        this.SqlCommand.Parameters.Add(param);
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
    }
}
