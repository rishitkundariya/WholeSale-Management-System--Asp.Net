using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for InvoiceItemDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{

    public class InvoiceItemDAL :DataBaseConfig
    {
        #region Constructor
        public InvoiceItemDAL()
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
        public Boolean Insert(InvoiceItemENT entInvoiceItem)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandText = "PR_InvoiceItem_Insert";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@InvoiceID", entInvoiceItem.InvoiceID);
                        objCmd.Parameters.AddWithValue("@ProductID", entInvoiceItem.ProductID);
                        objCmd.Parameters.AddWithValue("@Quantity", entInvoiceItem.Quantity);
                        objCmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = entInvoiceItem.Price;
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
                        objCmd.CommandText = "PR_InvoiceItem_DeleteByInvoiceID";
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
        public DataTable SelectAll(SqlInt32 InvoiceID)
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
                        objCmd.CommandText = "PR_InvoiceItem_SelectALL";
                        objCmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);
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

        #endregion
    }
}