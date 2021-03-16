using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for CityDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{
    public class CityDAL:DataBaseConfig
    {
        #region constuctor
        public CityDAL()
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

        #region  Insert Operation
        public Boolean Insert(CityENT entCity)
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
                        objCmd.CommandText = "PR_City_Insert";
                        objCmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = entCity.CityName;
                        objCmd.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = entCity.Pincode;
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return true;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                   
                }
            }
        }
        #endregion

        #region  Update Operation
        public Boolean Update(CityENT entCity)
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
                        objCmd.CommandText = "PR_City_UpdateByPK";
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entCity.CityID; 
                        objCmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = entCity.CityName;
                        objCmd.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = entCity.Pincode;
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

        #region  Delete Operation
        public Boolean Delete(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_Delete";
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
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

        #region  Select All
        public DataTable SelectAll()
        {
            #region data blind
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();
                    using (SqlCommand objcmd = objConn.CreateCommand())
                    {
                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_City_SelectAll";
                        using (SqlDataReader objSdr = objcmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            if (objSdr.HasRows)
                            {
                                dt.Load(objSdr);
                                return dt;
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
            #endregion
        }
        #endregion

        #region  Select By PK
        public CityENT SelectByPK(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_SelectByPK";
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;

                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            CityENT entCity = new CityENT();
                            if (objSdr.HasRows)
                            {
                                while (objSdr.Read())
                                {
                                    if (objSdr["CityName"] != DBNull.Value)
                                        entCity.CityName = objSdr["CityName"].ToString().Trim();
                                    if (objSdr["Pincode"] != DBNull.Value)
                                        entCity.Pincode = objSdr["Pincode"].ToString().Trim();
                                }
                                return entCity;
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

        #region  Select For Drop Down
        public DataTable SelectForDropDown()
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
                        objCmd.CommandText = "PR_City_SelectForDropDown";

                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            if (objSdr.HasRows)
                            {
                                dt.Load(objSdr);
                                return dt;
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