using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityENT
/// </summary>
/// 
namespace ASPWMS.ENT
{

    public class CityENT
    {
        #region Constructor
        public CityENT()
        {
            //
            // TODO: Add constructor logic here
            //
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

        #region CityName
        protected SqlString _CityName;

        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }
        #endregion

        #region Pincode
        protected SqlString _Pincode;

        public SqlString Pincode
        {
            get
            {
                return _Pincode;
            }
            set
            {
                _Pincode = value;
            }
        }
        #endregion
    }

}