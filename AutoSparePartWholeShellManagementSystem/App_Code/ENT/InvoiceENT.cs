using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InvoiceENT
/// </summary>
/// 
namespace ASPWMS.ENT
{

    public class InvoiceENT
    {
        #region Constructor
        public InvoiceENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region InvoiceID
        private SqlInt32 _InvoiceID;
        public SqlInt32 InvoiceID
        {
            get
            {
                return _InvoiceID;
            }
            set
            {
               _InvoiceID= value;
            }
        }
        #endregion

        #region CustomerID

        private SqlInt32 _CoustomerID;
        public SqlInt32 CoustomerID
        {
            get
            {
                return _CoustomerID;
            }
            set
            {
                _CoustomerID = value;
            }
        }
        #endregion
        
        #region Date
        private SqlString _Date;
        public SqlString Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }
        #endregion


    }
}