using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierENT
/// </summary>
/// 
namespace ASPWMS.ENT
{
    
    public class SupplierENT
    {
        #region Constructor
        public SupplierENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region SupplierID
        protected SqlInt32 _SupplierID;
        public SqlInt32 SupplierID
        {
            get
            {
               return _SupplierID;
            }
            set
            {
                _SupplierID = value;
            }
        }
        #endregion

        #region SupplierName
        protected SqlString _SupplierName;
        public SqlString SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
            }
        }
        #endregion 

        #region Number
        protected SqlString _Number;
        public SqlString Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
            }
        }
        #endregion 

        #region BrandID
        protected SqlInt32 _BrandID;
        public SqlInt32 BrandID
        {
            get
            {
                return _BrandID;
            }
            set
            {
                _BrandID = value;
            }
        }
        #endregion

        #region CityID
        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }
        #endregion
    }
}