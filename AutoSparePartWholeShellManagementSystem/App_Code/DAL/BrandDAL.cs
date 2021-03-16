using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for BrandDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{

    public class BrandDAL:DataBaseConfig
    {
        #region Constructor
        public BrandDAL()
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
        public Boolean Insert(BrandENT entBrand)
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
                        objCmd.CommandText = "PR_Brand_Insert";
                        objCmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = entBrand.BrandName;
                        objCmd.Parameters.Add("@BrandSortName", SqlDbType.VarChar).Value =entBrand.BrandSortName;
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
        public Boolean Update(BrandENT entBrand)
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
                        objCmd.CommandText = "PR_Brand_UpdateByPK";
                        objCmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = entBrand.BrandID;
                        objCmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = entBrand.BrandName;
                        objCmd.Parameters.Add("@BrandSortName", SqlDbType.VarChar).Value = entBrand.BrandSortName;
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
        public Boolean Delete(SqlInt32 BrandID)
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
                        objCmd.CommandText = "PR_Brand_Delete";
                        objCmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;
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

        #region 

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
                        objCmd.CommandText = "PR_Brand_SelectAll";
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
            #endregion
        }
        #endregion

        #region  Select By PK
        public BrandENT SelectByPK(SqlInt32 BrandID)
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
                        objCmd.CommandText = "PR_Brand_SelectByPK";
                        objCmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = BrandID;

                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            BrandENT entBrand = new BrandENT();
                            if (objSdr.HasRows)
                            {
                                while (objSdr.Read())
                                {
                                    if (objSdr["BrandName"] != DBNull.Value)
                                        entBrand.BrandName = objSdr["BrandName"].ToString().Trim();
                                    if (objSdr["BrandSortName"] != DBNull.Value)
                                        entBrand.BrandSortName = objSdr["BrandSortName"].ToString().Trim();
                                }
                            }
                            return entBrand;
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
                        objCmd.CommandText = "PR_Brand_SelectForDropDown";

                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(objSdr);
                            return dt;
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