//----------------------------------------------------------------
//	Author:					Abhilash Rana
// 	Last Modifier :			Abhilash Rana
//	Date Created:			23-August-2010
//	Last Modified Date:		30-August-2010
//	---------------------------------------------------------------


using System;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Threading;
using LogManager;
using log4net;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace DataAccessLayer
{
    /// <summary>
    /// Summary description for SqlDataAccess.
    /// </summary>
    public class MySqlDataAccess : IMySqlDataAccess
    {
        ILogManager logger = new LogManager.LogManager();
        public MySqlDataAccess()
        {
           logger.createLogger();
        }

        /**********************************************************
        Function:			ExecuteNonQuery	
        Created By:			Abhilash Rana
        Created On:			23-August-2010
        Modified By:		NIL
        Modified On:		NIL
        Purpose:			This method is used to execute the sql query
        No of Arguments:    1
        Returns:			int
        Notes:			    NIL
        ***********************************************************/
        public int ExecuteNonQuery(string cmdText)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            DataSet dsDataSet = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.Text;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                DateTime dtStart = DateTime.Now;

                Int32 iReturn = oCmd.ExecuteNonQuery();

                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);  

                return iReturn;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public int ExecuteNonQuery(string cmdText, string[,] arrParam)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            DataSet dsDataSet = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                for (Int16 i = 0; i < arrParam.GetLength(0); i++)
                    oCmd.Parameters.AddWithValue(arrParam[i, 0], arrParam[i, 1]);

                DateTime dtStart = DateTime.Now;

                Int32 iReturn = oCmd.ExecuteNonQuery();
                        
                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);

                return iReturn;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void ExecuteNonQuery(string cmdText, string[,] arrParam, out string ref_id, out string user_id )
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            DataSet dsDataSet = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                for (Int16 i = 0; i < arrParam.GetLength(0); i++)
                    oCmd.Parameters.AddWithValue(arrParam[i, 0], arrParam[i, 1]);


                oCmd.Parameters.Add(new MySqlParameter("?_ownrefferalid", MySqlDbType.String));
                oCmd.Parameters["?_ownrefferalid"].Direction = ParameterDirection.Output;

                oCmd.Parameters.Add(new MySqlParameter("?_userid", MySqlDbType.String));
                oCmd.Parameters["?_userid"].Direction = ParameterDirection.Output;

                oCmd.ExecuteNonQuery();

                ref_id = oCmd.Parameters["?_ownrefferalid"].Value.ToString();
                user_id = oCmd.Parameters["?_userid"].Value.ToString();

                DateTime dtStart = DateTime.Now;
                
                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void ExecuteNonQuery(string cmdText, string[,] arrParam, List<string> arrParamOut, out List<KeyValuePair<string, string>> output)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            DataSet dsDataSet = new DataSet();
            output = new List<KeyValuePair<string, string>>();
            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                for (Int16 i = 0; i < arrParam.GetLength(0); i++)
                    oCmd.Parameters.AddWithValue(arrParam[i, 0], arrParam[i, 1]);

                foreach(var item in arrParamOut)
                {
                    oCmd.Parameters.Add(new MySqlParameter("?" + item + "", MySqlDbType.String));
                    oCmd.Parameters["?" + item + ""].Direction = ParameterDirection.Output;
                }

                oCmd.ExecuteNonQuery();
                foreach (var item in arrParamOut)
                {
                    output.Add(new KeyValuePair<String, String>(item, oCmd.Parameters["?" + item + ""].Value.ToString()));
                }
                DateTime dtStart = DateTime.Now;

                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /**********************************************************
       Function:			ExecuteScalar	
       Created By:			Abhilash Rana
       Created On:			23-August-2010
       Modified By:		    NIL
       Modified On:		    NIL
       Purpose:			    This method is used to run the sql query and return the result in a DataTable.
       No of Arguments:     1
       Returns:			    DataTable
       Notes:			    NIL
       ***********************************************************/
        public object ExecuteScalar(string cmdText)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            DataSet dsDataSet = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.Text;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                DateTime dtStart = DateTime.Now;
                object oReturn = oCmd.ExecuteScalar();

                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);  

                return oReturn;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public object ExecuteScalar(string cmdText, string[,] arrParam)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            DataSet dsDataSet = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                for (Int16 i = 0; i < arrParam.GetLength(0); i++)
                    oCmd.Parameters.AddWithValue(arrParam[i, 0], arrParam[i, 1]);

                DateTime dtStart = DateTime.Now;
                object oReturn = oCmd.ExecuteScalar();

                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);

                return oReturn;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /**********************************************************
      Function:			    ExecuteReader	
      Created By:			Abhilash Rana
      Created On:			23-August-2010
      Modified By:		    NIL
      Modified On:		    NIL
      Purpose:			    This method is used to execute Stored Proc and return in a DataReader.
      No of Arguments:      2
      Returns:			    DataReader
      Notes:			    NIL
      ***********************************************************/
      
        public DataTableReader ExecuteReader(string cmdText, string[,] arrParam, bool IsWithType)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            MySqlDataReader dsReader = null;
            DataTable dtTable = new DataTable();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                if (IsWithType)
                {
                    for (Int16 i = 0; i < arrParam.GetLength(0); i++)
                        if (arrParam[i, 2].ToLower() == "string")
                            oCmd.Parameters.AddWithValue(arrParam[i, 0], arrParam[i, 1]);
                        else
                            oCmd.Parameters.AddWithValue(arrParam[i, 0], Convert.ToInt32(arrParam[i, 1]));
                   
                }
                else
                {
                    for (Int16 i = 0; i < arrParam.GetLength(0); i++)
                        oCmd.Parameters.AddWithValue(arrParam[i, 0], Convert.ToInt32(arrParam[i, 1]));
                }
                DateTime dtStart = DateTime.Now;

                dsReader = oCmd.ExecuteReader();

                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);

                int iNumber = dsReader.FieldCount;

                for (int i = 0; i < iNumber; i++)
                {
                    dtTable.Columns.Add(dsReader.GetName(i));
                }

                while (dsReader.Read())
                {
                    DataRow dr = dtTable.NewRow();
                    for (int i = 0; i < iNumber; i++)
                    {
                        dr[i] = dsReader[i];
                    }
                    dtTable.Rows.Add(dr);
                }

                return dtTable.CreateDataReader();

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        /**********************************************************
    Function:			    ExecuteReader	
    Created By:			Abhilash Rana
    Created On:			23-August-2010
    Modified By:		    NIL
    Modified On:		    NIL
    Purpose:			    This method is used to execute Stored Proc and return in a DataReader.
    No of Arguments:      2
    Returns:			    DataReader
    Notes:			    NIL
    ***********************************************************/
        public DataTableReader ExecuteReader(string cmdText)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            MySqlDataReader dsReader = null;
            DataTable dtTable = new DataTable();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.Text;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                DateTime dtStart = DateTime.Now;

                dsReader = oCmd.ExecuteReader();
                
                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime (oCmd.CommandText, dtStart.Second);  
                
                int iNumber = dsReader.FieldCount;

                for (int i = 0; i < iNumber; i++)
                {
                    dtTable.Columns.Add(dsReader.GetName(i));
                }

                while (dsReader.Read())
                {
                    DataRow dr = dtTable.NewRow();
                    for (int i = 0; i < iNumber; i++)
                    {
                        dr[i] = dsReader[i];
                    }
                    dtTable.Rows.Add(dr);
                }

                return dtTable.CreateDataReader();

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        /**********************************************************
       Function:			ExecuteDataSet	
       Created By:			Abhilash Rana
       Created On:			23-August-2010
       Modified By:		    NIL
       Modified On:		    NIL
       Purpose:			    This method is used to execute Stored Proc and return first DataTable in a DataSet.
       No of Arguments:     2
       Returns:			    DataTable
       Notes:			    NIL
       ***********************************************************/
        public DataTable ExecuteDataTable(string cmdText, string[,] arrParam)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();           
            DataSet ds = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]); 

                for (Int16 i = 0; i < arrParam.GetLength(0); i++)
                    oCmd.Parameters.AddWithValue(arrParam[i, 0], arrParam[i, 1]);

                DateTime dtStart = DateTime.Now;

                MySqlDataAdapter daDataAdapter = new MySqlDataAdapter(oCmd);
                daDataAdapter.Fill(ds);
                
                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);  

                if (ds != null)
                    return ds.Tables[0];
                else
                    return null;

            }


            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        public DataTable ExecuteDataTable(string cmdText)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            DataSet ds = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.Text;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                DateTime dtStart = DateTime.Now;

                MySqlDataAdapter daDataAdapter = new MySqlDataAdapter(oCmd);
                daDataAdapter.Fill(ds);

                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                //logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);

                if (ds != null)
                    return ds.Tables[0];
                else
                    return null;

            }


            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        /**********************************************************
       Function:			ExecuteDataSet	
       Created By:			Abhilash Rana
       Created On:			23-August-2010
       Modified By:		    NIL
       Modified On:		    NIL
       Purpose:			    This method is used to execute Stored Proc and return results in a DataSet.
       No of Arguments:     2
       Returns:			    DataSet
       Notes:			    NIL
       ***********************************************************/
        public DataSet ExecuteDataSet(string cmdText, string[,] arrParam)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();                       
            DataSet ds = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]); 

                for (Int16 i = 0; i < arrParam.GetLength(0); i++)
                    oCmd.Parameters.AddWithValue(arrParam[i, 0], Convert.ToInt32(arrParam[i, 1]));

                DateTime dtStart = DateTime.Now;

                MySqlDataAdapter daDataAdapter = new MySqlDataAdapter(oCmd);
                daDataAdapter.Fill(ds);

                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);  

                return ds;

            }


            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /**********************************************************
      Function:			    ExecuteDataSet	
      Created By:			Abhilash Rana
      Created On:			23-August-2010
      Modified By:		    NIL
      Modified On:		    NIL
      Purpose:			    This method is used to execute Stored Proc and return results in a DataSet.
      No of Arguments:      1
      Returns:			    DataSet
      Notes:			    NIL
      ***********************************************************/
        public DataSet ExecuteDataSet(string cmdText)
        {
            MySqlConnection conn = new MySqlConnection();
            conn = GetConnection();
            DataSet ds = new DataSet();

            try
            {
                MySqlCommand oCmd = new MySqlCommand(cmdText, conn);
                oCmd.CommandType = CommandType.Text;
                oCmd.CommandTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["MySqlCommandTimeout"]);

                DateTime dtStart = DateTime.Now;

                MySqlDataAdapter daDataAdapter = new MySqlDataAdapter(oCmd);
                daDataAdapter.Fill(ds);

                TimeSpan tsTime = DateTime.Now.Subtract(dtStart);
                logger.writeDBQueryTime(oCmd.CommandText, dtStart.Second);  

                return ds;

            }


            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /**********************************************************
       Function:			CloseConn	
       Created By:			Abhilash Rana
       Created On:			23-August-2010
       Modified By:		    NIL
       Modified On:		    NIL
       Purpose:			    This method is used to close SQL connection
       No of Arguments:     1
       Returns:			    NIL
       Notes:			    NIL
       ***********************************************************/
        public void CloseConn(MySqlConnection conn)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /**********************************************************
       Function:			GetConnection	
       Created By:			Abhilash Rana
       Created On:			23-August-2010
       Modified By:		    NIL
       Modified On:		    NIL
       Purpose:			    This method is used establish connection with SQL DB
       No of Arguments:     0
       Returns:			    MySqlConnection
       Notes:			    NIL
       ***********************************************************/
        public MySqlConnection GetConnection()
        {
            try
            {
                string str;
                str = ConfigurationSettings.AppSettings["constr"];
                MySqlConnection conn = new MySqlConnection(str);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
          
      
    }
}
