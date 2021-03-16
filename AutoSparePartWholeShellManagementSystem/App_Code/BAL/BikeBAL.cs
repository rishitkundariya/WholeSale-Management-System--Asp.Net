using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for BikeBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{

    public class BikeBAL
    {
        #region Constructor
        public BikeBAL()
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
        public Boolean Insert(BikeENT entBike)
        {
            BikeDAL dalBike = new BikeDAL();
            if (dalBike.Insert(entBike))
            {
                return true;
            }
            else
            {
                Message = dalBike.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(BikeENT entBike)
        {
            BikeDAL dalBike = new BikeDAL();
            if (dalBike.Update(entBike))
            {
                return true;
            }
            else
            {
                Message = dalBike.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 BikeID)
        {
            BikeDAL dalBike = new BikeDAL();
            if (dalBike.Delete(BikeID))
            {
                return true;
            }
            else
            {
                Message = dalBike.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region Select All

        public DataTable SelectAll()
        {
            BikeDAL dalBike = new BikeDAL();
            DataTable dtBike = new DataTable();
            dtBike = dalBike.SelectAll();
            if (dtBike == null)
            {
                Message = dalBike.Message;
                return null;
            }
            else
            {
                return dtBike;
            }
        }
        #endregion

        #region Select By PK

        public BikeENT SelectByPK(SqlInt32 BikeID)
        {
            BikeDAL dalBike = new BikeDAL();
            BikeENT entBike = new BikeENT();
            entBike = dalBike.SelectByPK(BikeID);
            if (entBike == null)
            {
                Message = dalBike.Message;
                return null;
            }
            else
            {
                return entBike;
            }
        }
        #endregion

        #endregion
    }
}