using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for BrandBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{
    public class BrandBAL
    {
        #region Constructor
        public BrandBAL()
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
        public Boolean Insert(BrandENT entBrand)
        {
            BrandDAL dalBrand = new BrandDAL();
            if (dalBrand.Insert(entBrand))
            {
                return true;
            }
            else
            {
                Message = dalBrand.Message;
                return false;
            }
        }
        #endregion

        #region  Update Operation
        public Boolean Update(BrandENT entBrand)
        {
            BrandDAL dalBrand = new BrandDAL();
            if (dalBrand.Update(entBrand))
            {
                return true;
            }
            else
            {
                Message = dalBrand.Message;
                return false;
            }

        }
        #endregion

        #region  Delete Operation
        public Boolean Delete(SqlInt32 BrandID)
        {
            BrandDAL dalBrand = new BrandDAL();
            if (dalBrand.Delete(BrandID))
            {
                return true;
            }
            else
            {
                Message = dalBrand.Message;
                return false;
            }
        }
        #endregion

        #region  Select Operation

        #region  Select All
        public DataTable SelectAll()
        {
            BrandDAL dalBrand = new BrandDAL();
            DataTable dtBrand = new DataTable();
            dtBrand = dalBrand.SelectAll();
            if (dtBrand != null)
                return dtBrand;
            else
            {
                Message = dalBrand.Message;
                return null;
            }
        }
        #endregion

        #region  Select By PK
        public BrandENT SelectByPK(SqlInt32 BrandID)
        {
            BrandDAL dalBrand = new BrandDAL();
            BrandENT entBrand = new BrandENT();
            entBrand = dalBrand.SelectByPK(BrandID);
            if (entBrand != null)
                return entBrand;
            else
            {
                Message = dalBrand.Message;
                return null;
            }
        }

        #endregion

        #region  Select For Drop Down
        public DataTable SelectForDropDown()
        {
            BrandDAL dalBrand = new BrandDAL();
         
            DataTable dtBrandDDL = new DataTable();
            dtBrandDDL = dalBrand.SelectForDropDown();
            if (dtBrandDDL != null)
                return dtBrandDDL;
            else
            {
                Message = dalBrand.Message;
                return null;
            }
        }
        #endregion

        #endregion
    }
}