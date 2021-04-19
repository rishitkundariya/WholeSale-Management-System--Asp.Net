using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for UserBAL
/// </summary>
/// 
namespace ASPWMS.BAL
{

    public class UserBAL
    {
        #region Constructor
        public UserBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Message
        private string _Message;
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

        #region Select User By UserName and Password
        public UserENT selectUser(String UserName, String Password)
        {
            UserDAL dalUser = new UserDAL();
            UserENT entUser = new UserENT();
            entUser = dalUser.selectUser(UserName, Password);
            if (entUser == null)
            {
                Message = dalUser.Message;
                return null;
            }
            else
            {
                return entUser;
            }
        }
        #endregion

        #region Update Password By UserID
        public Boolean changePassword(SqlInt32 UserID, SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
         
            if (dalUser.changePassword(UserID, Password))
            {
                return true;
              
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion

        #region Feacth Password 
        public String fetchPassword(SqlString Username)
        {
            UserDAL dalUser = new UserDAL();
            string Password = dalUser.fetchPassword(Username);
            if (Password==null)
            {
                Message = dalUser.Message;
                return null; 
            }
            else
            {
                return Password;
            }
        }
        #endregion
    }
}