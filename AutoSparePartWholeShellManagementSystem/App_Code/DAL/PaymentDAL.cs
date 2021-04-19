using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for PaymentDAL
/// </summary>
/// \
/// 
namespace ASPWMS.DAL
{

    public class PaymentDAL : DataBaseConfig
    {
        #region Constructor
        public PaymentDAL()
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
        public Boolean Insert(PaymentENT entPayment)
        {
            using(SqlConnection objCon=new SqlConnection(ConnectionString))
            {
                if (objCon.State != ConnectionState.Open)
                    objCon.Open();
                try
                {
                    using(SqlCommand objCmd = objCon.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Payment_Insert";
                        objCmd.Parameters.AddWithValue("@Payment_Type", entPayment.Payment_Type);
                        objCmd.Parameters.AddWithValue("@Payment_PersonID", entPayment.Payment_PersonID);
                        objCmd.Parameters.AddWithValue("@Payment_Amount", entPayment.Payment_Amount);
                        objCmd.Parameters.AddWithValue("@Payment_Date", entPayment.Payment_Date);
                        objCmd.Parameters.AddWithValue("@Payment_Description", entPayment.Payment_Description);
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch(Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objCon.State == ConnectionState.Open)
                        objCon.Close();
                }
            }
        }
        #endregion

        #region  Update Operation
        public Boolean Update(PaymentENT entPayment)
        {
            using (SqlConnection objCon = new SqlConnection(ConnectionString))
            {
                if (objCon.State != ConnectionState.Open)
                    objCon.Open();
                try
                {
                    using (SqlCommand objCmd = objCon.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Payment_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@PaymentID", entPayment.PaymentID);
                        objCmd.Parameters.AddWithValue("@Payment_Type", entPayment.Payment_Type);
                        objCmd.Parameters.AddWithValue("@Payment_PersonID", entPayment.Payment_PersonID);
                        objCmd.Parameters.AddWithValue("@Payment_Amount", entPayment.Payment_Amount);
                        objCmd.Parameters.AddWithValue("@Payment_Date", entPayment.Payment_Date);
                        objCmd.Parameters.AddWithValue("@Payment_Description", entPayment.Payment_Description);
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
                    if (objCon.State == ConnectionState.Open)
                        objCon.Close();
                }
            }
        }
        #endregion

        #region  Delete Operation
        public Boolean Delete(SqlInt32 PaymentID)
        {
            #region data delete
            using (SqlConnection objCon = new SqlConnection(ConnectionString))
            {
                if (objCon.State != ConnectionState.Open)
                    objCon.Open();
                try
                {
                    using (SqlCommand objCmd = objCon.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Payment_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@PaymentID", PaymentID);   
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
                    if (objCon.State == ConnectionState.Open)
                        objCon.Close();
                }
            }
            #endregion
        }
        #endregion

        #region Select Operation

        #region  Select All
        public DataTable SelectAll()
        {
            #region Select All
           
            using (SqlConnection objCon = new SqlConnection(ConnectionString))
            {
                if (objCon.State != ConnectionState.Open)
                    objCon.Open();
                try
                {
                    using (SqlCommand objCmd = objCon.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Payment_Select";
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                dt.Load(objSDR);
                            }
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
                    if (objCon.State == ConnectionState.Open)
                        objCon.Close();
                }
            }
           
            #endregion
        }
        #endregion

        #region  Select By PK
        public PaymentENT SelectByPK(SqlInt32 PaymentID)
        {
            #region Select By PK

            using (SqlConnection objCon = new SqlConnection(ConnectionString))
            {
                if (objCon.State != ConnectionState.Open)
                    objCon.Open();
                try
                {
                    using (SqlCommand objCmd = objCon.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Payment_SelectByPK";
                        objCmd.Parameters.AddWithValue("@PaymentID", PaymentID);
                        PaymentENT entPayment = new PaymentENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (objSDR["Payment_Type"] != DBNull.Value)
                                        entPayment.Payment_Type = objSDR["Payment_Type"].ToString().Trim();
                                    if (objSDR["Payment_PersonID"] != DBNull.Value)
                                        entPayment.Payment_PersonID = Convert.ToInt32(objSDR["Payment_PersonID"].ToString().Trim());
                                    if (objSDR["Payment_Amount"] != DBNull.Value)
                                        entPayment.Payment_Amount =Convert.ToInt32(objSDR["Payment_Amount"].ToString().Trim());
                                    if (objSDR["Payment_Date"] != DBNull.Value)
                                        entPayment.Payment_Date =Convert.ToString(objSDR["Payment_Date"].ToString().Trim());
                                    if (objSDR["Payment_Description"] != DBNull.Value)
                                        entPayment.Payment_Description = objSDR["Payment_Description"].ToString().Trim();

                                }
                            }
                        }

                        return entPayment;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objCon.State == ConnectionState.Open)
                        objCon.Close();
                }
            }

            #endregion
        }

        #endregion

        #region  Select By UserID
        public DataTable SelectByUserID(SqlInt32 UserID)
        {
            #region Select By UserID

            using (SqlConnection objCon = new SqlConnection(ConnectionString))
            {
                if (objCon.State != ConnectionState.Open)
                    objCon.Open();
                try
                {
                    using (SqlCommand objCmd = objCon.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Payment_SelectByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                dt.Load(objSDR);
                            }
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
                    if (objCon.State == ConnectionState.Open)
                        objCon.Close();
                }
            }

            #endregion
        }
        #endregion

        #endregion

        #region NetBalance
        public Int32 NetBalance()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandText = "PR_PaymentTotal";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader ObjSdr=objCmd.ExecuteReader())
                        {
                            Int32 Sum = 0;
                            while (ObjSdr.Read())
                            {
                                Sum = Sum + Convert.ToInt32(ObjSdr["Total"].ToString());
                            }
                            return Sum;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return -99999;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();

                }
            }
        }
        #endregion
    }
}