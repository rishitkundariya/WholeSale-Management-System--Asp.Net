using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for SupplierBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{
    public class SupplierBAL
    {
        #region Constructor
        public SupplierBAL()
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
        public Boolean Insert(SupplierENT entSupplier)
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            if (dalSupplier.Insert(entSupplier))
            {
                return true;
            }
            else
            {
                Message = dalSupplier.Message;
                return false;
            }
        }
        #endregion

        #region  Update Operation
        public Boolean Update(SupplierENT entSupplier)
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            if (dalSupplier.Update(entSupplier))
            {
                return true;
            }
            else
            {
                Message = dalSupplier.Message;
                return false;
            }
        }

        #endregion

        #region  Delete Operation
        public Boolean Delete(SqlInt32 SupplierID)
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            if (dalSupplier.Delete(SupplierID))
            {
                return true;
            }
            else
            {
                Message = dalSupplier.Message;
                return false;
            }
        }
        #endregion

        #region  Select Operation

        #region  Select All
        public DataTable SelectAll()
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            DataTable dt = new DataTable();
            dt = dalSupplier.SelectAll();
            if (dt!=null)
            {
                return dt;
            }
            else
            {
                Message = dalSupplier.Message;
                return null;
            }
        }
        #endregion

        #region  Select By PK
        public SupplierENT SelectByPK(SqlInt32 SupplierID)
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            SupplierENT entSupplier = new SupplierENT();
            entSupplier = dalSupplier.SelectByPK(SupplierID);
            if (entSupplier != null)
            {
                return entSupplier;
            }
            else
            {
                Message = dalSupplier.Message;
                return null;
            }
        }

        #endregion

        #region  Select For Drop Down
        public DataTable SelectForDropDown()
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            DataTable dt = new DataTable();
            dt = dalSupplier.SelectForDropDown();
            if (dt != null)
            {
                return dt;
            }
            else
            {
                Message = dalSupplier.Message;
                return null;
            }
        }
        #endregion

        #endregion
    }
}