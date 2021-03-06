﻿using System.Data;
using System.Data.SqlClient;
namespace ks.Models
{
    interface IDataAccess
    {
        SqlConnection GetConnection();
        void CloseConn(SqlConnection conn);
        int ExecuteNonQuery(string cmdText);
        object ExecuteScalar(string cmdText);
        DataTableReader ExecuteReader(string cmdText, string[,] arrParam, bool IsWithType);
        DataTableReader ExecuteReader(string cmdText);
        DataTable ExecuteDataTable(string cmdText, string[,] arrParam);
        DataSet ExecuteDataSet(string cmdText, string[,] arrParam);
        DataSet ExecuteDataSet(string cmdText);
    }
}
