using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for RetailerDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{

    public class RetailerDAL:DataBaseConfig
    {
        #region Constructor
        public RetailerDAL()
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
        public Boolean Insert(RetailerENT entRetailer)
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
                        objCmd.CommandText = "PR_Retailer_Insert";

                        objCmd.Parameters.Add("@RetailerName", SqlDbType.VarChar).Value = entRetailer.RetailerName;
                        objCmd.Parameters.Add("@ShopName", SqlDbType.VarChar).Value = entRetailer.ShopName;
                        objCmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = entRetailer.MobileNumber;
                        objCmd.Parameters.Add("@ShopAddress", SqlDbType.VarChar).Value = entRetailer.ShopAddress;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entRetailer.CityID;
                        objCmd.Parameters.Add("@TransportName", SqlDbType.VarChar).Value = entRetailer.TransportName;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entRetailer.Email;

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

        #region  Update Operation
        public Boolean Update(RetailerENT entRetailer)
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
                        
                        objCmd.CommandText = "PR_Retailer_UpdateByPK";
                        objCmd.Parameters.Add("@RetailerID", SqlDbType.Int).Value = entRetailer.RetailerID;
                        objCmd.Parameters.Add("@RetailerName", SqlDbType.VarChar).Value = entRetailer.RetailerName;
                        objCmd.Parameters.Add("@ShopName", SqlDbType.VarChar).Value = entRetailer.ShopName;
                        objCmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = entRetailer.MobileNumber;
                        objCmd.Parameters.Add("@ShopAddress", SqlDbType.VarChar).Value = entRetailer.ShopAddress;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entRetailer.CityID;
                        objCmd.Parameters.Add("@TransportName", SqlDbType.VarChar).Value = entRetailer.TransportName;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entRetailer.Email;

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
        public Boolean Delete(SqlInt32 RetailerID)
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
                        objCmd.CommandText = "PR_Retailer_Delete";
                        objCmd.Parameters.Add("@RetailerID", SqlDbType.Int).Value = RetailerID;
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
            #endregion
        }
        #endregion

        #region  Select Operation

        #region  Select All
        public DataTable SelectAll()
        {
            #region Select All
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Retailer_SelectAll";
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            dt.Load(objSdr);
                        }
                        return dt;
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
        public RetailerENT SelectByPK(SqlInt32 RetailerID)
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
                        objCmd.CommandText = "PR_Retailer_SelectByPK";
                        objCmd.Parameters.Add("@RetailerID", SqlDbType.Int).Value = RetailerID;
                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            RetailerENT entRetailer = new RetailerENT();
                            if (objSdr.HasRows)
                            {
                                while (objSdr.Read())
                                {
                                    if (objSdr["RetailerName"] != DBNull.Value)
                                        entRetailer.RetailerName = objSdr["RetailerName"].ToString();
                                    if (objSdr["ShopName"] != DBNull.Value)
                                        entRetailer.ShopName = objSdr["ShopName"].ToString();
                                    if (objSdr["MobileNumber"] != DBNull.Value)
                                        entRetailer.MobileNumber = objSdr["MobileNumber"].ToString();
                                    if (objSdr["ShopAddress"] != DBNull.Value)
                                        entRetailer.ShopAddress = objSdr["ShopAddress"].ToString();
                                    if (objSdr["TransportName"] != DBNull.Value)
                                        entRetailer.TransportName = objSdr["TransportName"].ToString();
                                    if (!objSdr["Email"].Equals(DBNull.Value))
                                        entRetailer.Email = objSdr["Email"].ToString().Trim();
                                    if (objSdr["CityID"] != DBNull.Value)
                                        entRetailer.CityID = Convert.ToInt32(objSdr["CityID"].ToString());
                                }
                            }
                            return entRetailer;
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
            #region Select For Drop Down
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Retailer_SelectForDropDown";
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            dt.Load(objSdr);
                        }
                        return dt;
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

        #endregion


    }
}