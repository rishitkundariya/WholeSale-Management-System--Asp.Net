using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using ASPWMS.BAL;
using ASPWMS.DAL;
using ASPWMS.ENT;

/// <summary>
/// Summary description for Email
/// </summary>
/// 


public class Email
{
    #region  Constructor
    public Email()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    #region Send Email Of Regiatration
    public static void sendEmailOfRegiatration(RetailerENT entRetailer)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("wms.p2r@gmail.com", "ASPWMS123");
        smtp.EnableSsl = true;
        String Password = entRetailer.RetailerName.ToString().Substring(0, 2) + entRetailer.MobileNumber.ToString().Substring(5);
        MailMessage msg = new MailMessage();
        msg.Subject = "Your Account successfully Created ";
        msg.Body = "Thank you for choosing WMS. We hope you had a smooth experience. \n\n" + "Dear , " + entRetailer.RetailerName.ToString() + " welcome in the WMS  Community \n" + "login Cedencial for our WMS is below \n" + "Username  : " + entRetailer.MobileNumber.ToString() +
            " \nPassword :  " + Password + "\n\nIf you have any query contact us at wms.p2r@gmail.com. \n\n\n\n" + " \n This is system Generated email.";
        msg.To.Add(entRetailer.Email.ToString());
        msg.From = new MailAddress("WMS(p2r) <wms.p2r@gmail.com>");
        try
        {
            smtp.Send(msg);

        }
        catch (Exception ex)
        {

        }
    }
    #endregion

    #region Send Email Of Invoice
    public static void sendEmailOfInvoice(int InvoiceID,int Total)
    {
        InvoiceENT entInvoice = new InvoiceENT();
        InvoiceBAL balInvoice = new InvoiceBAL();
        entInvoice = balInvoice.SelectByPK(InvoiceID);
        RetailerENT entRetailer = new RetailerENT();
        RetailerBAL dalRetailer = new RetailerBAL();
        entRetailer = dalRetailer.SelectByPK(entInvoice.CoustomerID);
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("wms.p2r@gmail.com", "ASPWMS123");
        smtp.EnableSsl = true;
        MailMessage msg = new MailMessage();
        msg.Subject = "Invoice is Generated at WMS";
        msg.Body = "Thank you for choosing WMS. We hope you had a smooth experience. \n\n" + "Dear, " + entRetailer.RetailerName.ToString() + " Thank you for your order. Order details are below \n\n" + "InvoiceID : "+entInvoice.InvoiceID.ToString()  + "\nDate  :  " + entInvoice.Date.ToString() +
            "\nAmount  :  " + Total.ToString() + "\n\n If you have any query contact us at wms.p2r@gmail.com. \n\n\n" + " \n This is system Generated email.";
        msg.To.Add(entRetailer.Email.ToString().Trim());
        msg.From = new MailAddress("WMS(p2r) <wms.p2r@gmail.com>");
        try
        {
            smtp.Send(msg);

        }
        catch (Exception ex)
        {

        }
    }
    #endregion

    #region Send Email Of Forget Password
    public static void sendEmailOfForgetPassword(UserENT entUser)
    {
        RetailerENT entRetailer = new RetailerENT();
        RetailerBAL dalRetailer = new RetailerBAL();
        entRetailer = dalRetailer.SelectByPK(entUser.RetailerID);
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("wms.p2r@gmail.com", "ASPWMS123");
        smtp.EnableSsl = true;
        MailMessage msg = new MailMessage();
        msg.Subject = "Forget Password ";
        msg.Body = "Thank you for choosing WMS. We hope you had a smooth experience. \n\n" + "Dear, " + entRetailer.RetailerName.ToString() + " Your Password is "  + entUser.Password.ToString() +
              ". \n\n If you have any query contact us at wms.p2r@gmail.com. \n\n\n" + " \n This is system Generated email.";
        msg.To.Add(entRetailer.Email.ToString());
        msg.From = new MailAddress("WMS(p2r) <wms.p2r@gmail.com>");
        try
        {
            smtp.Send(msg);

        }
        catch (Exception ex)
        {

        }
    }
    #endregion
}