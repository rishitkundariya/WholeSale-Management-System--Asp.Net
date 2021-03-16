using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductENT
/// </summary>
/// 
namespace ASPWMS.ENT
{ 
    public class ProductENT
    {
        #region Constructor
        public ProductENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region ProductID
        protected SqlInt32 _ProductID;
        public SqlInt32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }
        #endregion

        #region Product_Name
        protected SqlString _Product_Name;
        public SqlString Product_Name
        {
            get
            {
                return _Product_Name;
            }
            set
            {
                _Product_Name = value;
            }
        }
        #endregion

        #region Product_BrandID
        protected SqlInt32 _Product_BrandID;
        public SqlInt32 Product_BrandID
        {
            get
            {
                return _Product_BrandID;
            }
            set
            {
                _Product_BrandID = value;
            }
        }
        #endregion

        #region Product_Price
        protected SqlDecimal _Product_Price;
        public SqlDecimal Product_Price
        {
            get
            {
                return _Product_Price;
            }
            set
            {
                _Product_Price = value;
            }
        }
        #endregion
    }
}