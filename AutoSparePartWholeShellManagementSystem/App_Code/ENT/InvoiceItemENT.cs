using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InvoiceItemENT
/// </summary>
/// 
namespace ASPWMS.ENT
{

    public class InvoiceItemENT
    {
        #region Costructor
        public InvoiceItemENT()
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
                _InvoiceID = value;
            }
        }
        #endregion

        #region Quantity
        private SqlInt32 _Quantity;
        public SqlInt32 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }
        #endregion

        #region ProductID
        private SqlInt32 _ProductID;
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

        #region Price
        private SqlDecimal _Price;
        public SqlDecimal Price
        {
            get
            {
                return _Price;
            }
            set
            {    
                _Price = value;
            }
        }
        #endregion


    }
}