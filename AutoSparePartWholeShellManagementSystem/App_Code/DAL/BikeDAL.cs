using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for BikeDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{

    public class BikeDAL:DataBaseConfig
    {
        #region constructor
        public BikeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Message
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion

        #region Inset Operation
        public Boolean Insert(BikeENT entBike)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandText = "PR_Bike_Insert";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@BikeName", entBike.BikeName);
                        objCmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = entBike.CompanyName;
                        objCmd.Parameters.Add("@BikeModelNumber", SqlDbType.VarChar).Value = entBike.BikeModelNumber;
                        objCmd.Parameters.Add("@BikeModelYear", SqlDbType.VarChar).Value = entBike.BikeModelYear;
                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                   
                }
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(BikeENT entBike)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        
                        objCmd.CommandText = "PR_Bike_UpdateByPK";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.Add("@BikeID", SqlDbType.Int).Value = entBike.BikeID;
                        objCmd.Parameters.Add("@BikeName", SqlDbType.VarChar).Value = entBike.BikeName;
                        objCmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = entBike.CompanyName;
                        objCmd.Parameters.Add("@BikeModelNumber", SqlDbType.VarChar).Value = entBike.BikeModelNumber;
                        objCmd.Parameters.Add("@BikeModelYear", SqlDbType.VarChar).Value = entBike.BikeModelYear;
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                   
                }
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 BikeID)
        {
            #region data delete
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Bike_Delete";
                        objCmd.Parameters.Add("@BikeID", SqlDbType.Int).Value = BikeID;
                        objCmd.ExecuteNonQuery();
                        return true;

                    }

                }
                catch (Exception e)
                {
                    Message = e.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                   
                }
            }
            #endregion
        }
        #endregion

        #region Select Operation

        #region Select All
        public DataTable SelectAll()
        {
            #region Select all
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Bike_SelectAll";

                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            DataTable dtBike = new DataTable();
                            if (objSDR.HasRows)
                            {
                                dtBike.Load(objSDR);
                                return dtBike;
                            }
                            else
                                return null;

                        }
                       
                    }

                }
                catch (Exception e)
                {
                    Message = e.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                   
                }
            }
            #endregion
        }
        
        #endregion

        #region Select By PK

        public BikeENT SelectByPK(SqlInt32 BikeID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Bike_SelectByPK";
                        objCmd.Parameters.Add("@BikeID", SqlDbType.Int).Value = BikeID;

                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            if (objSdr.HasRows)
                            {
                                BikeENT entBike = new BikeENT();
                                while (objSdr.Read())
                                {
                                    if (objSdr["BikeName"] != DBNull.Value)
                                        entBike.BikeName = objSdr["BikeName"].ToString().Trim();
                                    if (objSdr["CompanyName"] != DBNull.Value)
                                        entBike.CompanyName = objSdr["CompanyName"].ToString().Trim();
                                    if (objSdr["BikeModelNumber"] != DBNull.Value)
                                        entBike.BikeModelNumber = objSdr["BikeModelNumber"].ToString().Trim();
                                    if (objSdr["BikeModelYear"] != DBNull.Value)
                                        entBike.BikeModelYear = objSdr["BikeModelYear"].ToString().Trim();
                                }
                                return entBike;
                            }
                            else
                                return null;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }

        #endregion

        #endregion
    }
}