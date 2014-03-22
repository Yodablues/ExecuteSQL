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
    public class ExecuteSQLText : ExecuteSQL
    {
        private string SqlText { get; set; }        

        public ExecuteSQLText(string connectionStringName, string sqlText)
        {
            try
            {                
                this.SqlConnection = this.SetupSQLConnection(connectionStringName);
                this.SqlText = null;
                this.SqlCommand = this.SetupSqlCommand(sqlText, CommandType.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }

        public ExecuteSQLText(string connectionStringName, string sqlText, List<SqlParameter> parameters)
        {
            try
            {
                this.SqlConnection = this.SetupSQLConnection(connectionStringName);
                this.SqlText = sqlText;
                this.SqlCommand = this.SetupSqlCommand(sqlText, CommandType.Text);                
            }
            catch(Exception ex)
            {
                Console.WriteLine
                    ("Catching the {0} exception triggers the finally block.",
                    ex.GetType());
                throw;
            }
        }        
    }
}
