using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for InvoiceItemBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{

    public class InvoiceItemBAL
    {
        #region Constructor
        public InvoiceItemBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Message
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion

        #region Inset Operation
        public Boolean Insert(InvoiceItemENT entInvoiceItem)
        {
            InvoiceItemDAL dalInvoiceItem = new InvoiceItemDAL();
            if (dalInvoiceItem.Insert(entInvoiceItem))
            {
                return true;
            }
            else
            {
                Message = dalInvoiceItem.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 InvoiceID)
        {
            #region data delete
            InvoiceItemDAL dalInvoiceItem = new InvoiceItemDAL();
            if (dalInvoiceItem.Delete(InvoiceID))
            {
                return true;
            }
            else
            {
                Message = dalInvoiceItem.Message;
                return false;
            }
            #endregion
        }
        #endregion

        #region Select Operation

        #region Select All
        public DataTable SelectAll(SqlInt32 InvoiceID)
        {
            #region Select all
            DataTable dt = new DataTable();
            InvoiceItemDAL dalInvoiceItem = new InvoiceItemDAL();
            dt = dalInvoiceItem.SelectAll(InvoiceID);
            if (dt==null)
            {
                Message = dalInvoiceItem.Message;
                return null;
            }
            else
            {
                return dt;
            }
            #endregion
        }
        #endregion

        #endregion
    }
}