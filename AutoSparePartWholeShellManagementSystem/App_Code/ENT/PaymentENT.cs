using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentENT
/// </summary>
/// 
namespace ASPWMS.ENT
{

    public class PaymentENT
    {
        #region Constructor
        public PaymentENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region PaymentID
        protected SqlInt32 _PaymentID;
        public SqlInt32 PaymentID
        {
            get
            {
                return _PaymentID;
            }
            set
            {
                _PaymentID = value;
            }
        }
        #endregion

        #region Payment_Type
        protected SqlString _Payment_Type;

        public SqlString Payment_Type
        {
            get
            {
                return _Payment_Type;
            }
            set
            {
                _Payment_Type = value;
            }
        }
        #endregion

        #region Payment_Description
        protected SqlString _Payment_Description;

        public SqlString Payment_Description
        {
            get
            {
                return _Payment_Description;
            }
            set
            {
                _Payment_Description = value;
            }
        }
        #endregion

        #region Payment_PersonID
        protected SqlInt32 _Payment_PersonID;
        public SqlInt32 Payment_PersonID
        {
            get
            {
                return _Payment_PersonID;
            }
            set
            {
                _Payment_PersonID = value;
            }
        }
        #endregion

        #region Payment_Amount
        protected SqlInt32 _Payment_Amount;
        public SqlInt32 Payment_Amount
        {
            get
            {
                return _Payment_Amount;
            }
            set
            {
                _Payment_Amount = value;
            }
        }
        #endregion

        #region Payment_Date
        protected string _Payment_Date;
        public string Payment_Date
        {
            get
            {
                return _Payment_Date;
            }
            set
            {
                _Payment_Date = value;
            }
        }
        #endregion
    }
}