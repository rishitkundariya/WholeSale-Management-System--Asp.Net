using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for SupplierDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{
    public class SupplierDAL:DataBaseConfig
    {
        #region constructor
        public SupplierDAL()
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
        public Boolean Insert(SupplierENT entSupplier)
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
                        objCmd.CommandText = "PR_Supplier_Insert";

                        objCmd.Parameters.Add("@SupplierName", SqlDbType.VarChar).Value = entSupplier.SupplierName;
                        objCmd.Parameters.Add("@Number", SqlDbType.VarChar).Value = entSupplier.Number;
                        objCmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = entSupplier.BrandID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entSupplier.CityID;
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
        public Boolean Update(SupplierENT entSupplier)
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
                        objCmd.CommandText = "PR_Supplier_UpdateByPK";
                        objCmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = entSupplier.SupplierID;
                       
                        objCmd.Parameters.Add("@SupplierName", SqlDbType.VarChar).Value = entSupplier.SupplierName;
                        objCmd.Parameters.Add("@Number", SqlDbType.VarChar).Value = entSupplier.Number;
                        objCmd.Parameters.Add("@BrandID", SqlDbType.Int).Value = entSupplier.BrandID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entSupplier.CityID;
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
        public Boolean Delete(SqlInt32 SupplierID)
        {
            #region data delete
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();
                    using (SqlCommand objcmd = objConn.CreateCommand())
                    {
                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_Supplier_Delete";
                        objcmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = SupplierID;
                        objcmd.ExecuteNonQuery();
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
                        objCmd.CommandText = "PR_Supplier_SelectAll";
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            if (objSdr.HasRows)
                            {
                                dt.Load(objSdr);
                            }
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
            #endregion
        }
        #endregion

        #region  Select By PK
        public SupplierENT SelectByPK(SqlInt32 SupplierID)
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
                        objCmd.CommandText = "PR_Supplier_SelectByPK";
                        objCmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = SupplierID;
                        SupplierENT entSupplier = new SupplierENT();
                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            if (objSdr.HasRows)
                            {
                                while (objSdr.Read())
                                {
                                    if (objSdr["SupplierName"] != DBNull.Value)
                                        entSupplier.SupplierName = objSdr["SupplierName"].ToString();
                                    if (objSdr["Number"] != DBNull.Value)
                                        entSupplier.Number = objSdr["Number"].ToString();
                                    if (objSdr["BrandID"] != DBNull.Value)
                                        entSupplier.BrandID = Convert.ToInt32(objSdr["BrandID"].ToString());
                                    if (objSdr["CityID"] != DBNull.Value)
                                        entSupplier.CityID =Convert.ToInt32(objSdr["CityID"].ToString());


                                }
                            }
                            return entSupplier;
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
                        objCmd.CommandText = "PR_Supplier_SelectForDropDown";
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            if (objSdr.HasRows)
                            {
                                dt.Load(objSdr);
                            }
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