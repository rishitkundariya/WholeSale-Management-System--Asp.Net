using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserENT
/// </summary>
/// 

namespace ASPWMS.ENT
{

    public class UserENT
    {
        #region Constructor
        public UserENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region UserID
        private SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        #endregion

        #region UserName
        private SqlString _UserName;
        public SqlString UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        #endregion

        #region Password
        private SqlString _Password;
        public SqlString Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        #endregion

        #region RetailerID
        private SqlInt32 _RetailerID;

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

    }
}