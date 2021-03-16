using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for InvoiceDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{

    public class InvoiceDAL :DataBaseConfig
    {
        #region Constructor
        public InvoiceDAL()
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
        public Boolean Insert(InvoiceENT entInvoice)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandText = "PR_Invoice_Insert";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Direction = ParameterDirection.Output;         
                        objCmd.Parameters.AddWithValue("@CoustomerID", entInvoice.CoustomerID);
                        objCmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = entInvoice.Date;
                        objCmd.ExecuteNonQuery();
                        entInvoice.InvoiceID = (int)objCmd.Parameters["@InvoiceID"].Value;
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
        public Boolean Update(InvoiceENT entInvoice)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {

                        objCmd.CommandText = "PR_Invoice_UpdateByPK";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.Add("@CoustomerID", SqlDbType.Int).Value = entInvoice.CoustomerID;
                        objCmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = entInvoice.Date;
                        objCmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = entInvoice.InvoiceID;
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
        public Boolean Delete(SqlInt32 InvoiceID)
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
                        objCmd.CommandText = "PR_Invoice_DeleteByPK";
                        objCmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID;
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
                        objCmd.CommandText = "PR_Invoice_SelectALL";

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
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

        public InvoiceENT SelectByPK(SqlInt32 InvoiceID)
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
                        objCmd.CommandText = "PR_Invoice_SelectByPK";
                        objCmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID;

                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            if (objSdr.HasRows)
                            {
                                InvoiceENT entInvoice = new InvoiceENT();
                                while (objSdr.Read())
                                {
                                    if (objSdr["InvoiceID"] != DBNull.Value)
                                        entInvoice.InvoiceID =Convert.ToInt32(objSdr["InvoiceID"].ToString().Trim());
                                    if (objSdr["CoustomerID"] != DBNull.Value)
                                        entInvoice.CoustomerID = Convert.ToInt32(objSdr["CoustomerID"].ToString().Trim());
                                    if (objSdr["Date"] != DBNull.Value)
                                        entInvoice.Date = objSdr["Date"].ToString().Trim();
                                  
                                }
                                return entInvoice;
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

        #region Set Total 
        public Boolean setAmount(SqlInt32 InvoiceID,Decimal Total)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandText = "PR_Invoice_UpdateAmountByInvoiceID";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = InvoiceID;
                        objCmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Total;
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
    }
}