using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using OCM;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

public partial class pages_ReqApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static formData[] GetRequestedDetail()
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageRequestApprovalSRC_ApprovePU";
        com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.DaysLast = dr["TdayslastfromRequested"].ToString();
            p.Position = dr["R_Position"].ToString();
            p.RBY = dr["R_Name"].ToString();
            p.RID = dr["R_Id"].ToString();
            p.RType = dr["R_Type"].ToString();
            p.TItems = dr["TotalItems"].ToString();
            p.Dept = dr["SubDepartment"].ToString();
            p.prov = dr["ProvinceEngName"].ToString();
            p.Email = dr["R_Email"].ToString();
            lst.Add(p);

        }
        dr.Close();

        if (HttpContext.Current.User.IsInRole("RC"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageRequestApprovalSRC_ApproveRC_region";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.RType = dr["R_Type"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["SubDepartment"].ToString();
                p.prov = dr["ProvinceEngName"].ToString();
                p.Email = dr["R_Email"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }
        //Type 2
        if (HttpContext.Current.User.IsInRole("Logistic Officer"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageRequestApprovalSRC_ApproveSL_2";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.RType = dr["R_Type"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["Department"].ToString();
                p.prov = dr["ProvinceEngName"].ToString();
                p.Email = dr["R_Email"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }

        //Type 3
        if (HttpContext.Current.User.IsInRole("Logistic Officer"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageRequestApprovalSRC_ApproveSL_3";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.RType = dr["R_Type"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["SubDepartment"].ToString();
                p.prov = dr["ProvinceEngName"].ToString();
                p.Email = dr["R_Email"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }
        //Type 2
        if (HttpContext.Current.User.IsInRole("Operation Manager"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageRequestApprovalSRC_ApproveOM_2";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.RType = dr["R_Type"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["Department"].ToString();
                p.prov = dr["ProvinceEngName"].ToString();
                p.Email = dr["R_Email"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }

        //Type 3
        if (HttpContext.Current.User.IsInRole("Operation Manager"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageRequestApprovalSRC_ApproveOM_3";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.RType = dr["R_Type"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["SubDepartment"].ToString();
                p.prov = dr["ProvinceEngName"].ToString();
                p.Email = dr["R_Email"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }

        //Type 3
        if (HttpContext.Current.User.IsInRole("CH"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageRequestApprovalSRC_ApproveCH_3";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.RType = dr["R_Type"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["SubDepartment"].ToString();
                p.prov = dr["ProvinceEngName"].ToString();
                p.Email = dr["R_Email"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }


        //Type 3
        if (HttpContext.Current.User.IsInRole("SCH"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageRequestApprovalSRC_ApproveSCH_3";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.RType = dr["R_Type"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["SubDepartment"].ToString();
                p.prov = dr["ProvinceEngName"].ToString();
                p.Email = dr["R_Email"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }

        //Type 3
        //if (HttpContext.Current.User.IsInRole("PD"))
        //{
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.CommandText = "spPageRequestApprovalSRC_ApproveCH_3";
        //    com.Parameters.Clear();
        //    com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
        //    dr = com.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        formData p = new formData();
        //        p.DaysLast = dr["TdayslastfromRequested"].ToString();
        //        p.Position = dr["R_Position"].ToString();
        //        p.RBY = dr["R_Name"].ToString();
        //        p.RID = dr["R_Id"].ToString();
        //        p.RType = dr["R_Type"].ToString();
        //        p.TItems = dr["TotalItems"].ToString();
        //        p.Dept = dr["Department"].ToString();
        //        lst.Add(p);

        //    }
        //    dr.Close();
        //}

        con.Close();
        return lst.ToArray();
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static void SaveFormDetail(List<formData> lst)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            float vstep = 0; string role = "";

            if (lst.Count > 0)
            {
                foreach (formData f in lst)
                {
                    SqlParameter[] p = new SqlParameter[5];
                    if (f.RType == "Office Use")
                    {
                        vstep = 1;
                    }
                    else if (f.RType == "Store")
                    {
                        if (HttpContext.Current.User.IsInRole("Supervisor") || HttpContext.Current.User.IsInRole("CH"))
                        {

                            vstep = 1;
                            if (HttpContext.Current.User.IsInRole("Supervisor"))
                                role = "91db283a-4b18-4595-8dfc-0a049099296d";
                            else
                                role = "538fee35-b9c0-4d00-bb49-f7ce1e41f9f6";
                        }
                        else if (HttpContext.Current.User.IsInRole("RC") || HttpContext.Current.User.IsInRole("Logistic Officer"))
                        {
                            vstep = 2;
                            if (HttpContext.Current.User.IsInRole("RC"))
                                role = "db4a76a3-3f92-4c35-b5c2-1cdfc2e13430";
                            else
                                role = "fd5d5f40-69f0-47be-9ebb-00e9a5bb8a44";
                        }
                        else if (HttpContext.Current.User.IsInRole("Operation Manager"))
                        {
                            vstep = 3;
                            role = "07da40cd-9e3b-479b-ad5f-4e1da175169b";
                        }
                    }
                    else if (f.RType == "Contribution TOOLS")
                    {
                        if (HttpContext.Current.User.IsInRole("Supervisor"))
                        {
                            vstep = 1;
                            role = "91db283a-4b18-4595-8dfc-0a049099296d";
                        }
                        if (HttpContext.Current.User.IsInRole("SCH"))
                        {
                            vstep = 2.5f;
                            role = "809a03ad-aa2a-4037-83e6-21b74a830b3f";
                        }
                        else if (HttpContext.Current.User.IsInRole("RC"))
                        {
                            vstep = 2;
                            role = "db4a76a3-3f92-4c35-b5c2-1cdfc2e13430";
                        }

                        else if (HttpContext.Current.User.IsInRole("CH"))
                        {
                            vstep = 3;
                            role = "538fee35-b9c0-4d00-bb49-f7ce1e41f9f6";
                        }
                        else if (HttpContext.Current.User.IsInRole("Logistic Officer"))
                        {
                            vstep = 4;
                            role = "fd5d5f40-69f0-47be-9ebb-00e9a5bb8a44";
                        }
                        else if (HttpContext.Current.User.IsInRole("Operation Manager"))
                        {
                            vstep = 5;
                            role = "07da40cd-9e3b-479b-ad5f-4e1da175169b";
                        }
                        else if (HttpContext.Current.User.IsInRole("PD"))
                        {
                            vstep = 6;
                            role = "d93b2590-4c24-418c-89db-bd11e3c0ff41";
                        }
                    }
                    p[0] = new SqlParameter("@RID", SqlDbType.BigInt) { Value = f.RID };
                    p[1] = new SqlParameter("@Vstep", SqlDbType.Float) { Value = vstep };
                    p[2] = new SqlParameter("@UID", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[3] = new SqlParameter("@URole", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(role) };
                    p[4] = new SqlParameter("@VDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    dbT.ExecuteTransStoreProcedure("spPageRequestApprovalSRC_Accept", p, true);

                    p = new SqlParameter[1];
                    p[0] = new SqlParameter("@R_Id", SqlDbType.BigInt) { Value = f.RID };
                    DataTable dtEmails = dbT.ExecuteTransStoreProcedureReturnTable("sharedGetRequestEmails", p, true);
                    string Emails = null;
                    foreach (DataRow rw in dtEmails.Rows)
                    {
                        Emails += rw["Email"].ToString() + ",";
                    }
                    Emails = Emails.Substring(0, Emails.LastIndexOf(','));
                    Emails += " Naveed.khan06@outlook.com";

                    //if (!string.IsNullOrEmpty(f.Email))
                    //{

                    //    using (MailMessage mm = new MailMessage())
                    //    {

                    //        mm.From = new MailAddress("fcmis.nhlp@gmail.com", "NHLP MIS");
                    //        mm.To.Add(new MailAddress(f.Email, ""));
                    //        if (!string.IsNullOrEmpty(Emails))
                    //            mm.CC.Add(Emails);
                    //        mm.Subject = "INV-MIS:Request Approval Alert for ( INV-REQ-" + f.RID + " )";

                    //        string body = "<br/><div style='background-color:#EFEFF4;'>Your Request has been Verified from your Supervisor ( " + HttpContext.Current.User.Identity.Name + ") .</div> <br/> Please waite for more notification while  your request Verified by other supervisors or follow up the procedures to issue your requests.";

                    //        body += "<br/><strong style='color:blue;'> Please do not reply to this Email . This is Automatically created by NHLP MIS System</strong><br/>For more information contact NHLP MIS";
                    //        mm.Body = body;
                    //        mm.IsBodyHtml = false;
                    //        SmtpClient smtp = new SmtpClient();
                    //        smtp.Host = "smtp.gmail.com";
                    //        smtp.EnableSsl = true;
                    //        NetworkCredential NetworkCred = new NetworkCredential("fcmis.nhlp@gmail.com", "safi_khan123");
                    //        smtp.UseDefaultCredentials = true;
                    //        smtp.Credentials = NetworkCred;
                    //        smtp.Port = 587;
                    //        mm.BodyEncoding = System.Text.Encoding.UTF8;
                    //        mm.SubjectEncoding = System.Text.Encoding.Default;
                    //        mm.IsBodyHtml = true;
                    //        smtp.Send(mm);
                    //    }
                    //}

                }
            }
            dbT.EndTransaction();
        }
        catch (Exception)
        {
            dbT.RollBackTransaction();
            throw;
        }
        finally
        {
            dbT.Connection.Close();
            SqlConnection.ClearPool(dbT.Connection);
        }
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static void RejectFormDetail(List<formData> lst)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            int vstep = 0;

            if (lst.Count > 0)
            {
                foreach (formData f in lst)
                {
                    SqlParameter[] p = new SqlParameter[4];
                    if (f.RType == "Office Use")
                    {
                        vstep = 1;
                    }
                    else if (f.RType == "Store")
                    {
                        if (HttpContext.Current.User.IsInRole("Supervisor") || HttpContext.Current.User.IsInRole("CH"))
                        {
                            vstep = 1;
                        }
                        else if (HttpContext.Current.User.IsInRole("RC") || HttpContext.Current.User.IsInRole("Logistic Officer"))
                        {
                            vstep = 2;
                        }
                        else if (HttpContext.Current.User.IsInRole("Operation Manager"))
                        {
                            vstep = 3;
                        }
                    }
                    else if (f.RType == "Contribution TOOLS")
                    {
                        if (HttpContext.Current.User.IsInRole("Supervisor"))
                        {
                            vstep = 1;
                        }
                        else if (HttpContext.Current.User.IsInRole("RC"))
                        {
                            vstep = 2;
                        }
                        else if (HttpContext.Current.User.IsInRole("CH"))
                        {
                            vstep = 3;
                        }
                        else if (HttpContext.Current.User.IsInRole("Logistic Officer"))
                        {
                            vstep = 4;
                        }
                        else if (HttpContext.Current.User.IsInRole("Operation Manager"))
                        {
                            vstep = 5;
                        }
                        else if (HttpContext.Current.User.IsInRole("PD"))
                        {
                            vstep = 6;
                        }
                    }
                    p[0] = new SqlParameter("@RID", SqlDbType.BigInt) { Value = f.RID };
                    p[1] = new SqlParameter("@Vstep", SqlDbType.NVarChar) { Value = vstep };
                    p[2] = new SqlParameter("@UID", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[3] = new SqlParameter("@VDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    dbT.ExecuteTransStoreProcedure("spPageRequestApprovalSRC_Reject", p, true);

                }
            }
            dbT.EndTransaction();
        }
        catch (Exception)
        {
            dbT.RollBackTransaction();
            throw;
        }
        finally
        {
            dbT.Connection.Close();
            SqlConnection.ClearPool(dbT.Connection);
        }
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<ItemsInfo> GetItemDetail(string ReqId)
    {
        List<ItemsInfo> lst = new List<ItemsInfo>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageRequestApprovalSRC_GetItemsDetail";
        com.Parameters.AddWithValue("@R_Id", SqlDbType.BigInt).Value = ReqId;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            ItemsInfo p = new ItemsInfo();
            p.Name = dr["Name"].ToString();
            p.Quantity = dr["Quantity"].ToString();
            p.Remarks = dr["Remarks"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    public class formData
    {
        public string RType { get; set; }
        public string RBY { get; set; }
        public string Position { get; set; }
        public string RID { get; set; }
        public string DaysLast { get; set; }
        public string TItems { get; set; }
        public string VStep { get; set; }
        public string Dept { get; set; }
        public string prov { get; set; }
        public string Email { get; set; }
    }
    public class ItemsInfo
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }
    }

}