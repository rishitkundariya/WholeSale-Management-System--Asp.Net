using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for RetailerBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{
    public class RetailerBAL
    {
        #region Consturctor
        public RetailerBAL()
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
        public Boolean Insert(RetailerENT entRetailer)
        {
            RetailerDAL dalRetailer = new RetailerDAL();
            if (dalRetailer.Insert(entRetailer))
            {
                return true;
            }
            else
            {
                Message = dalRetailer.Message;
                return false;
            }
        }
        #endregion

        #region  Update Operation
        public Boolean Update(RetailerENT entRetailer)
        {
            RetailerDAL dalRetailer = new RetailerDAL();
            if (dalRetailer.Update(entRetailer))
            {
                return true;
            }
            else
            {
                Message = dalRetailer.Message;
                return false;
            }
        }
        #endregion

        #region  Delete Operation
        public Boolean Delete(SqlInt32 RetailerID)
        {
            #region data delete
            RetailerDAL dalRetailer = new RetailerDAL();
            if (dalRetailer.Delete(RetailerID))
            {
                return true;
            }
            else
            {
                Message = dalRetailer.Message;
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
            RetailerDAL dalRetailer = new RetailerDAL();
            dt = dalRetailer.SelectAll();
            if (dt!=null)
            {
                return dt;
            }
            else
            {
                Message = dalRetailer.Message;
                return null;
            }
            #endregion
        }
        #endregion

        #region  Select By PK
        public RetailerENT SelectByPK(SqlInt32 RetailerID)
        {
            RetailerENT entRetailer = new RetailerENT();
            RetailerDAL dalRetailer = new RetailerDAL();
            entRetailer = dalRetailer.SelectByPK(RetailerID);
            if (entRetailer != null)
            {
                return entRetailer;
            }
            else
            {
                Message = dalRetailer.Message;
                return null;
            }
        }

        #endregion

        #region  Select For Drop Down
        public DataTable SelectForDropDown()
        {
            #region Select For Drop Down
            DataTable dt = new DataTable();
            RetailerDAL dalRetailer = new RetailerDAL();
            dt = dalRetailer.SelectForDropDown();
            if (dt != null)
            {
                return dt;
            }
            else
            {
                Message = dalRetailer.Message;
                return null;
            }
            #endregion
        }
        #endregion

        #endregion

        #region Reatailer Count
        public Int32 ReatailerCount()
        {
            RetailerDAL dalRetailer = new RetailerDAL();
            int count = dalRetailer.ReatailerCount();
            if (count == -1)
            {
                Message = dalRetailer.Message;
                return -1;
            }
            else
            {
                return count;
            }
        }
        #endregion
    }
}