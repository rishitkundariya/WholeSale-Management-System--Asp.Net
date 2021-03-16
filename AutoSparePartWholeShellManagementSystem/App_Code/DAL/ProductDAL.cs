using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.ENT;

/// <summary>
/// Summary description for ProductDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{
    public class ProductDAL:DataBaseConfig
    {
        #region Constructor
        public ProductDAL()
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
        public Boolean Insert(ProductENT entProduct)
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
                        objCmd.CommandText = "PR_Product_Insert";
                        objCmd.Parameters.AddWithValue("@Product_Name", entProduct.Product_Name);
                        objCmd.Parameters.AddWithValue("@Product_BrandID", entProduct.Product_BrandID);
                        objCmd.Parameters.AddWithValue("@Product_Price", entProduct.Product_Price);
                       
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

        #region  Update Operation
        public Boolean Update(ProductENT entProduct)
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
                        objCmd.CommandText = "PR_Product_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@ProductID", entProduct.ProductID);
                        objCmd.Parameters.AddWithValue("@Product_Name", entProduct.Product_Name);
                        objCmd.Parameters.AddWithValue("@Product_BrandID", entProduct.Product_BrandID);
                        objCmd.Parameters.AddWithValue("@Product_Price", entProduct.Product_Price);

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
        public Boolean Delete(SqlInt32 ProductID)
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
                            objCmd.CommandText = "PR_Product_DeleteByPK";
                            objCmd.Parameters.AddWithValue("@ProductID", ProductID);
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
                        objCmd.CommandText = "PR_Product_SelectAll";
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

        #region  Select By PK
        public ProductENT SelectByPK(SqlInt32 ProductID)
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
                        objCmd.CommandText = "PR_Product_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
                        ProductENT entProduct = new ProductENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (objSDR["Product_Name"] != DBNull.Value)
                                        entProduct.Product_Name = objSDR["Product_Name"].ToString().Trim();
                                    if (objSDR["Product_BrandID"] != DBNull.Value)
                                        entProduct.Product_BrandID = Convert.ToInt32(objSDR["Product_BrandID"].ToString().Trim());
                                    if (objSDR["Product_Price"] != DBNull.Value)
                                        entProduct.Product_Price = Convert.ToDecimal(objSDR["Product_Price"].ToString().Trim());
                                   
                                }
                            }
                        }

                        return entProduct;
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

        #region  Select for Drop Down
        public DataTable SelectForDropDown()
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
                        objCmd.CommandText = "PR_Product_SelectForDropDown";
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

        #region  Select for Drop Down
        public decimal SelectProductPriceByProductID(SqlInt32 ProductID)
        {

            #region SelectProductPriceByProductID

            using (SqlConnection objCon = new SqlConnection(ConnectionString))
            {
                if (objCon.State != ConnectionState.Open)
                    objCon.Open();
                try
                {
                    using (SqlCommand objCmd = objCon.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Product_SelectPriceByProductID";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
                        
                        return (decimal)objCmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return -1;
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

    }
}