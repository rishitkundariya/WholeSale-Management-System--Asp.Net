using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BikeENT
/// </summary>
/// 
namespace ASPWMS.ENT
{

    public class BikeENT
    {
        #region constructor 
        public BikeENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region BikeID
        protected SqlInt32 _BikeID;

        public SqlInt32 BikeID
        {
            get
            {
                return _BikeID;
            }
            set
            {
                _BikeID = value;
                
            }
        }

        #endregion

        #region BikeName
        protected SqlString _BikeName;
        public SqlString BikeName
        {
            get
            {
                return _BikeName;
            }
            set
            {
                _BikeName = value;
            }
        }

        #endregion

        #region CompanyName
        protected SqlString _CompanyName;
        public SqlString CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }

        #endregion

        #region BikeModelNumber
        protected SqlString _BikeModelNumber;
        public SqlString BikeModelNumber
        {
            get
            {
                return _BikeModelNumber;
            }
            set
            {
                _BikeModelNumber = value;
            }
        }

        #endregion

        #region BikeModelYear
        protected SqlString _BikeModelYear;
        public SqlString BikeModelYear
        {
            get
            {
                return _BikeModelYear;
            }
            set
            {
                _BikeModelYear = value;
            }
        }

        #endregion
   
    }
}
