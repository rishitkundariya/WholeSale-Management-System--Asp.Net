using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBaseConfig
/// </summary>
/// 
namespace ASPWMS
{

    public class DataBaseConfig
    {
        #region Constructor
        public DataBaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Connection String
        public static String ConnectionString = ConfigurationManager.ConnectionStrings["ASPWMSConnectionString"].ConnectionString;
        #endregion
    }
}