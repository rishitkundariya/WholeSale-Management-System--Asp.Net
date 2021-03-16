using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BrandENT
/// </summary>
/// 
namespace ASPWMS.ENT
{

    public class BrandENT
    {
        #region Constructor
        public BrandENT()
        {
            //
            // TODO: Add constructor logic here
            //
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

        #region BrandName
        protected SqlString _BrandName;
        public SqlString BrandName
        {
            get
            {
                return _BrandName;
            }
            set
            {
                _BrandName = value;
            }
        }


        #endregion

        #region BrandSortName
        protected SqlString _BrandSortName;
        public SqlString BrandSortName
        {
            get
            {
                return _BrandSortName;
            }
            set
            {
                _BrandSortName = value;
            }
        }


        #endregion

     
    }
}
