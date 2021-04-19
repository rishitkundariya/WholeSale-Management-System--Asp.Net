using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using ASPWMS;
using ASPWMS.ENT;

/// <summary>
/// Summary description for UserDAL
/// </summary>
/// 
namespace ASPWMS.DAL
{
    public class UserDAL : DataBaseConfig
    {
        #region constructor
        public UserDAL()
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

        #region Select User By UserName and Password
        public UserENT selectUser(String UserName,String Password)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_SelectUserByUsernameAndPassword";
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSdr = objCmd.ExecuteReader())
                        {
                            if (objSdr.HasRows)
                            {
                                while (objSdr.Read())
                                {
                                    if (objSdr["UserID"] != DBNull.Value)
                                        entUser.UserID = Convert.ToInt32(objSdr["UserID"].ToString());
                                    if (objSdr["UserName"] != DBNull.Value)
                                        entUser.UserName = objSdr["UserName"].ToString();
                                    if (objSdr["Password"] != DBNull.Value)
                                        entUser.Password = objSdr["Password"].ToString();
                                    if (objSdr["RetailerID"] != DBNull.Value)
                                        entUser.RetailerID = Convert.ToInt32(objSdr["RetailerID"].ToString());


                                }
                                return entUser;
                            }
                            else
                               return  null ;
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region Update Password By UserID
        public Boolean changePassword(SqlInt32 UserID,SqlString Password)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_UpdatePasswordByUserID";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value =Password;
                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();

                }
            }
        }
        #endregion

        #region Feacth Password 
        public String fetchPassword(SqlString Username)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_ResetPasswordByUsername";
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Username;
                        String Password = objCmd.ExecuteScalar().ToString();
                        if (Password == null)
                            return null;
                        else
                            return Password;
                     
                    }
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();

                }
            }
        }
        #endregion
    }
}