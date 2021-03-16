using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for InvoiceBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{

    public class InvoiceBAL
    {
        #region Constructor
        public InvoiceBAL()
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
        public Boolean Insert(InvoiceENT entInvoice)
        {
            InvoiceDAL dalInvoice = new InvoiceDAL();
            if (dalInvoice.Insert(entInvoice))
            {
                return true;
            }
            else
            {
                Message = dalInvoice.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(InvoiceENT entInvoice)
        {
            InvoiceDAL dalInvoice = new InvoiceDAL();
            if (dalInvoice.Update(entInvoice))
            {
                return true;
            }
            else
            {
                Message = dalInvoice.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 InvoiceID)
        {
            InvoiceDAL dalInvoice = new InvoiceDAL();
            if (dalInvoice.Delete(InvoiceID))
            {
                return true;
            }
            else
            {
                Message = dalInvoice.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region Select All
        public DataTable SelectAll()
        {
            #region Select all
            DataTable dt = new DataTable();
            InvoiceDAL dalInvoice = new InvoiceDAL();
            dt = dalInvoice.SelectAll();
            if (dt == null)
            {
                Message = dalInvoice.Message;
                return null;
            }
            else
            {
                return dt;
            }
            #endregion
        }

        #endregion

        #region Select By PK

        public InvoiceENT SelectByPK(SqlInt32 InvoiceID)
        {
            InvoiceDAL dalInvoice = new InvoiceDAL();
            InvoiceENT entInvoice = new InvoiceENT();
            entInvoice = dalInvoice.SelectByPK(InvoiceID);
            if (entInvoice == null)
            {
                Message = dalInvoice.Message;
                return null;
            }
            else
            {
                return entInvoice;
            }
        }

        #endregion

        #endregion 

        #region Set Total 
        public Boolean setAmount(SqlInt32 InvoiceID, Decimal Total)
        {
            InvoiceDAL dalInvoice = new InvoiceDAL();
            if (dalInvoice.setAmount(InvoiceID, Total))
            {
                return true;
            }
            else
            {
                Message = dalInvoice.Message;
                return false;
            }
        }
        #endregion
    }
}