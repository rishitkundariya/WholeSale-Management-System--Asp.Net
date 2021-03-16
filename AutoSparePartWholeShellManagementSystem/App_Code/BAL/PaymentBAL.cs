using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for PaymentBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{

    public class PaymentBAL
    {
        #region constructor
        public PaymentBAL()
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

        #region  Insert Operation
        public Boolean Insert(PaymentENT entPayment)
        {
            PaymentDAL dalPayment= new PaymentDAL();
            if (dalPayment.Insert(entPayment))
            {
                return true;
            }
            else
            {
                Message = dalPayment.Message;
                return false;
            }
        }
        #endregion

        #region  Update Operation
        public Boolean Update(PaymentENT entPayment)
        {
            PaymentDAL dalPayment = new PaymentDAL();
            if (dalPayment.Update(entPayment))
            {
                return true;
            }
            else
            {
                Message = dalPayment.Message;
                return false;
            }
        }
        #endregion

        #region  Delete Operation
        public Boolean Delete(SqlInt32 PaymentID)
        {
            #region data delete
            PaymentDAL dalPayment = new PaymentDAL();
            if (dalPayment.Delete(PaymentID))
            {
                return true;
            }
            else
            {
                Message = dalPayment.Message;
                return false;
            }
            #endregion
        }
        #endregion

        #region  Select Operation

        #region  Select All
        public DataTable SelectAll()
        {
            #region Select All
            DataTable dt = new DataTable();
            PaymentDAL dalPayment = new PaymentDAL();
            dt = dalPayment.SelectAll();
            if (dt!=null)
            {
                return dt; ;
            }
            else
            {
                Message = dalPayment.Message;
                return null;
            }
            #endregion
        }
        #endregion

        #region  Select By PK
        public PaymentENT SelectByPK(SqlInt32 PaymentID)
        {
            PaymentENT entPayment = new PaymentENT();
            PaymentDAL dalPayment = new PaymentDAL();
            entPayment = dalPayment.SelectByPK(PaymentID);
            if (entPayment != null)
            {
                return entPayment; ;
            }
            else
            {
                Message = dalPayment.Message;
                return null;
            }
        }

        #endregion

      

        #endregion

    }
}