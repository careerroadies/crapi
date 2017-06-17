using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace DataAccessLayer
{
    public interface IMySqlDataAccess
    {
        MySqlConnection GetConnection();
        void CloseConn(MySqlConnection conn);
        int ExecuteNonQuery(string cmdText);
        object ExecuteScalar(string cmdText);
        DataTableReader ExecuteReader(string cmdText, string[,] arrParam, bool IsWithType);
        DataTableReader ExecuteReader(string cmdText);
        DataTable ExecuteDataTable(string cmdText, string[,] arrParam);
        DataSet ExecuteDataSet(string cmdText, string[,] arrParam);
        DataSet ExecuteDataSet(string cmdText);
        
    }
}
