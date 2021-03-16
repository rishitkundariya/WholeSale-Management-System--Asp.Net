using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for CityBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{
    public class CityBAL
    {
        #region Constructor
        public CityBAL()
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
        public Boolean Insert(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.Insert(entCity))
            {

                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion

        #region  Update Operation
        public Boolean Update(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.Update(entCity))
            {

                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }

        }
        #endregion

        #region  Delete Operation
        public Boolean Delete(SqlInt32 CityID)
        {
            #region data delete
            CityDAL dalCity = new CityDAL();
            if (dalCity.Delete(CityID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
            #endregion
        }
        #endregion

        #region Select Operation

        #region  Select All
        public DataTable SelectAll()
        {
            #region Select All
            CityDAL dalCity = new CityDAL();
            DataTable dt = new DataTable();
            dt = dalCity.SelectAll();
            if (dt != null)
                return dt;
            else
            {
                Message = dalCity.Message;
                return null;
            }

            #endregion
        }
        #endregion

        #region  Select By PK
        public CityENT SelectByPK(SqlInt32 CityID)
        {
            #region Select By PK
            CityDAL dalCity = new CityDAL();
            CityENT entCity = new CityENT();
            entCity = dalCity.SelectByPK(CityID);
            if (entCity != null)
                return entCity;
            else
            {
                Message = dalCity.Message;
                return null;
            }

            #endregion
        }

        #endregion

        #region  Select For Drop Down
        public DataTable SelectForDropDown()
        {
            #region Select for Drop Down
            CityDAL dalCity = new CityDAL();
            DataTable dt = new DataTable();
            dt = dalCity.SelectForDropDown();
            if (dt != null)
                return dt;
            else
            {
                Message = dalCity.Message;
                return null;
            }

            #endregion
        }
        #endregion

        #endregion


    }
}