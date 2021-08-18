using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Services
{
  class DabaseService
  {
    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LocalDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
    
    SqlConnection cnn;

    public DabaseService()
    {
      cnn = new SqlConnection(connectionString);
    }

    public void Request(string sql)
    {
      cnn.Open();

      SqlCommand command = new SqlCommand(sql, cnn);

      SqlDataReader dataReader = command.ExecuteReader();

      List<string> output = new List<string>();
       
      while (dataReader.Read())
      {        
        for(int i = 0; i < dataReader.FieldCount; i++)
        {
          object colName = dataReader.GetName(i);
          object colValue = dataReader.GetValue(i);

          output.Add($"{colName} : {colValue}");
        }
      }
    }    
  }
}
