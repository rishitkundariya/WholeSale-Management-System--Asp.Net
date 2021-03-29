using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for ProductBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{
    public class ProductBAL
    {
        #region Constructor
        public ProductBAL()
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
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Insert(entProduct))
                return true;
            else
            {
                Message = dalProduct.Message;
                return false;
            }
        }
        #endregion

        #region  Update Operation
        public Boolean Update(ProductENT entProduct)
        {
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Update(entProduct))
                return true;
            else
            {
                Message = dalProduct.Message;
                return false;
            }
        }
        #endregion

        #region  Delete Operation
        public Boolean Delete(SqlInt32 ProductID)
        {
            #region data delete
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Delete(ProductID))
                return true;
            else
            {
                Message = dalProduct.Message;
                return false;
            }
            #endregion
        }
        #endregion

        #region Select operation

        #region  Select All
        public DataTable SelectAll()
        {
            #region Select All
            ProductDAL dalProduct = new ProductDAL();
            DataTable dt = new DataTable();
            dt = dalProduct.SelectAll();
            if (dt != null)
                return dt;
            else
            {
                Message = dalProduct.Message;
                return null;
            }
            #endregion
        }
        #endregion

        #region  Select By PK
        public ProductENT SelectByPK(SqlInt32 ProductID)
        {
            
            ProductDAL dalProduct = new ProductDAL();
            ProductENT entProduct = new ProductENT();
            entProduct = dalProduct.SelectByPK(ProductID);
            if (entProduct != null)
                return entProduct;
            else
            {
                Message = dalProduct.Message;
                return null;
            }
            
        }
        #endregion

        #region  Select For Drop Down
        public DataTable SelectForDropDown()
        {
            #region Select All
            ProductDAL dalProduct = new ProductDAL();
            DataTable dt = new DataTable();
            dt = dalProduct.SelectAll();
            if (dt != null)
                return dt;
            else
            {
                Message = dalProduct.Message;
                return null;
            }
            #endregion
        }
        #endregion

        #region  Select for Price By Product
        public decimal SelectProductPriceByProductID(SqlInt32 ProductID)
        {
            #region Select All
            ProductDAL dalProduct = new ProductDAL();
            decimal Price = dalProduct.SelectProductPriceByProductID(ProductID);
            if (Price == -1)
            {
                Message = dalProduct.Message;
                return -1;
            }
            else
            {
               
                return Price;
            }
            #endregion
        }

        #endregion

        #endregion

        #region Product Count
        public Int32 ProductCount()
        {
            ProductDAL dalProduct = new ProductDAL();
            int count = dalProduct.ProductCount();
            if (count == -1)
            {
                Message = dalProduct.Message;
                return -1;
            }
            else
            {
                return count;
            }
        }
        #endregion

    }
}

  