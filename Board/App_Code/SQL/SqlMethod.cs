using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace application
{
    public class SqlMethod
    {
        /// <summary>データベース接続文字列</summary>
        string CONNECTION_STR = ConfigurationManager.AppSettings["ConnectionString"];
        protected string Get(string sqlQuery,string columnName)
        {
            string result="";
            try
            {
                using (var sc = new SqlConnection(CONNECTION_STR))
                {
                    //Debug.WriteLine("d");
                    sc.Open();
                    var sCommand = new SqlCommand(sqlQuery, sc);
                    using (var reader=sCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (string)reader[columnName];
                        }
                    }
                        sc.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("実行に失敗しました");
                Debug.WriteLine("sqlError:" + e);
            }
            return result;
        }

        protected DataTable Display(string sqlQuery)
        {
            Debug.WriteLine("display:"+ sqlQuery);
            var dt = new DataTable();
            using (var connection = new SqlConnection(CONNECTION_STR))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var cmd = new SqlCommand()
                {
                    Connection = connection,
                    Transaction = transaction
                })
                {
                    try
                    {
                        cmd.CommandText = sqlQuery;
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.Message);
                        throw;
                    }

                }
                
            }
            return dt;
        }

        protected void Exec(string sqlQuery)
        {
            try
            {
                using (var sc = new SqlConnection(CONNECTION_STR))
                {
                    sc.Open();
                    var sCommand = new SqlCommand(sqlQuery, sc);
                    sCommand.ExecuteNonQuery();
                    sc.Close();

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("実行に失敗しました");
                Debug.WriteLine("sqlError:"+e);
            }
            

        }

    }
}