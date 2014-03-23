ExecuteSQL
==========

.NET Class that simplifies the process of executing a stored procedure and sql text. Returns a dataset.
Example usage:
Executing a stored procedure:
  List<SqlParameter> sqlParameters = new List<SqlParameter>();
  sqlParameters.Add(new SqlParameter("@Id", 1));
  ExecuteStoredProcedure execute = new ExecuteStoredProcedure("NameOFConnectionString", "nameOfStoredProcedure", sqlParameters);
  DataSet dataSetProcedure = execute.Execute();

Executing a inline sql:
  var sqltext = "select * from dbo.table1";
  ExecuteSQLText executetext = new ExecuteSQLText("NameOFConnectionString", sqltext);
  DataSet dataSetText = executetext.Execute();


Files:
ExecuteSQL.cs
  -Main Class File. 
  Methods:
    - SetupSQLConnection(string connectionStringName)
      Takes the connection nameto retrieve from the config and 
      sets up the SqlConnection object and returns it to the calling method.
    - SetupSQLCommand (string procedureName, CommandType commandType)
      Sets up the SqlCommand Object and returns it to the calling method.
    -Execute()
      Executes the sql command (text or stored procedure) and returns a dataset to the calling method.
      
ExecuteSQLText.cs
  -Class file for executing inline sql statements; inherits from ExecuteSQL
    - ExecuteSQLText(string connectionStringName, string sqlText, [List<SqlParameters> parameters])
      Constructor; takes the connectionStringName you want retrieved from the app/web config and the sql to be executed.
      Sets up the sqlcommand object. Overloaded constructoer also sets up any sqlParameters
      
ExecuteStoredProcedure.cs
  -Class file for executing inline sql statements; inherits from ExecuteSQL
    - ExecuteStoredProcedure(string connectionStringName, string procedureName, [List<SqlParameters> parameters])
