using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RetailerENT
/// </summary>
/// 
namespace ASPWMS.ENT
{
    
    public class RetailerENT
    {
        #region Constructor
        public RetailerENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region RetailerID
        protected SqlInt32 _RetailerID;
        public SqlInt32 RetailerID
        {
            get
            {
                return _RetailerID;
            }
            set
            {
                _RetailerID = value;
            }
        }
        #endregion

        #region RetailerName
        protected SqlString _RetailerName;
        public SqlString RetailerName
        {
            get
            {
                return _RetailerName;
            }
            set
            {
                _RetailerName = value;
            }
        }
        #endregion

        #region MobileNumber
        protected SqlString _MobileNumber;
        public SqlString MobileNumber
        {
            get
            {
                return _MobileNumber;
            }
            set
            {
                _MobileNumber = value;
            }
        }
        #endregion

        #region ShopName
        protected SqlString _ShopName;
        public SqlString ShopName
        {
            get
            {
                return _ShopName;
            }
            set
            {
                _ShopName = value;
            }
        }
        #endregion

        #region ShopAddress
        protected SqlString _ShopAddress;
        public SqlString ShopAddress
        {
            get
            {
                return _ShopAddress;
            }
            set
            {
                _ShopAddress = value;
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

        #region TransportName
        protected SqlString _TransportName;
        public SqlString TransportName
        {
            get
            {
                return _TransportName;
            }
            set
            {
                _TransportName = value;
            }
        }
        #endregion

        #region Email
        protected SqlString _Email;
        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        #endregion
    }
}