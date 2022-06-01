using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Security;
using System.Web.Profile;
using System.Data.SqlClient;
namespace OCM
{
    /// <summary>
    /// Summary description for UserInfo
    /// </summary>
    public class OCM_UserInfo
    {
        OCM_DbGeneral db = new OCM_DbGeneral();
        private string  username, provinceid,districtid, email, designation, fullname,age;
        public OCM_UserInfo(string user_name, string province_id, string district_id, string E_mail, string Desig, string full_name)
        {
            user_name = username; provinceid = province_id; districtid=district_id; email = E_mail; Desig = designation; fullname = full_name;
        }
        public OCM_UserInfo()
        {
        }
        public static string GetUserID()
        {
            string UserID = "";
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            UserID = usr.ProviderUserKey.ToString();
            return UserID;
        }
        public static string GetUserName(string userID)
        {
            string toReturn = "";
            if (userID != "")
            {
                DataTable dt = new OCM_DbGeneral().SelectRecords(@"SELECT     aspnet_Users.UserId, aspnet_Users.UserName, aspnet_Users.LoweredUserName, aspnet_Applications.ApplicationName
FROM         aspnet_Users INNER JOIN
                      aspnet_Applications ON aspnet_Users.ApplicationId = aspnet_Applications.ApplicationId
WHERE     (aspnet_Users.UserId = CAST('" + userID + "' AS uniqueIdentifier)) and aspnet_Applications.ApplicationName=N'FC'");
               
                if (dt.Rows.Count > 0)
                    toReturn = dt.Rows[0]["UserName"].ToString();
            }
            return toReturn;
        }
        public static string GetUserEmail(string userID)
        {
            string toReturn = "";
            if (userID != "")
            {
                DataTable dt = new OCM_DbGeneral().SelectRecords(@"SELECT     aspnet_Users.UserId, aspnet_Users.UserName, aspnet_Users.Email
FROM         aspnet_Users INNER JOIN
                      aspnet_Applications ON aspnet_Users.ApplicationId = aspnet_Applications.ApplicationId
WHERE     (aspnet_Users.UserId = CAST('" + userID + "' AS uniqueIdentifier)) and aspnet_Applications.ApplicationName=N'FC'");

                if (dt.Rows.Count > 0)
                    toReturn = dt.Rows[0]["Email"].ToString();
            }
            return toReturn;
        }
        public static string GetApplicationName(string userID)
        {
            string toReturn = "";
            if (userID != "")
            {
                DataTable dt = new OCM_DbGeneral().SelectRecords(@"SELECT     aspnet_Users.UserId, aspnet_Users.UserName, aspnet_Users.LoweredUserName, aspnet_Applications.ApplicationName
FROM         aspnet_Users INNER JOIN
                      aspnet_Applications ON aspnet_Users.ApplicationId = aspnet_Applications.ApplicationId
WHERE     (aspnet_Users.UserId = CAST('" + userID + "' AS uniqueIdentifier)) and aspnet_Applications.ApplicationName=N'FC'");

                if (dt.Rows.Count > 0)
                    toReturn = dt.Rows[0]["ApplicationName"].ToString();
            }
            return toReturn;
        }
        /// <summary>
        /// Return dataTable (ProvinceID,ProvinceName,ProvinceEngName)
        /// </summary>
        /// <returns>Data Table</returns>
        public static DataTable GetUserProvinces()
        {
            SqlParameter[] p=new SqlParameter[1];
            p[0] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value =new System.Data.SqlTypes.SqlGuid(GetUserID()) };
            DataTable dtToreturn = new OCM_DbGeneral().ExecuteSelectStoreProcedure("SharedGetUserProvinces",p,true);
            return dtToreturn;
        }
        public static string GetUserOfficeLocation()
        {
            string Toreturn =string.Empty;
            return Toreturn = new OCM_DbGeneral().ExecuteScaller("select OL from aspnet_Users where UserID='"+GetUserID()+"'");
        }
        public static string GetUserOfficeDepartment()
        {
            string Toreturn = string.Empty;
            return Toreturn = new OCM_DbGeneral().ExecuteScaller("select DepartmentId from aspnet_Users where UserID='" + GetUserID() + "'");
        }

        public static DataTable GetUserLeadFormers() {
            DataTable dtToReturn = new OCM_DbGeneral().SelectRecords(@"SELECT DISTINCT 
                      aspnet_UserProvince.ProvinceID, OCM_Province.ProvinceName, OCM_Province.ProvinceEngName, Tbl_LeadFormerWorker.Name, 
                      Tbl_LeadFormerWorker.ExtWID,Tbl_LeadFormerWorker.ActivityId
FROM         aspnet_UserProvince INNER JOIN
                      OCM_Province ON aspnet_UserProvince.ProvinceID = OCM_Province.ProvinceID INNER JOIN
                      Tbl_LeadFormerWorker ON OCM_Province.ProvinceID = Tbl_LeadFormerWorker.ProvinceID
where  aspnet_UserProvince.UserID=N'" + GetUserID() + "' order by aspnet_UserProvince.ProvinceID");
            return dtToReturn;
        
        }

        public static string GetUserProvincesIDs()
        {
            DataTable dt = GetUserProvinces();
            string toReturn = "(";
            if (dt.Rows.Count == 1)
            {
                toReturn = "("+dt.Rows[0]["ProvinceID"].ToString() + ")";
            }
            else if (dt.Rows.Count > 1)
            {
                int rowCount = dt.Rows.Count;
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (count < rowCount - 1)
                        toReturn += row["ProvinceID"].ToString() + ",";
                    else
                        toReturn += row["ProvinceID"].ToString() + ")";
                    count++;
                }

            }
            return toReturn;
        }
        public OCM_UserInfo GetUserInfo(string username)
        {
            MembershipUser usr = Membership.GetUser(username);
            string UserID = usr.ProviderUserKey.ToString();
            DataTable dt = db.SelectRecords(@"SELECT     aspnet_Users.UserId, aspnet_Users.UserName, aspnet_Users.ProvinceID, aspnet_Users.DistrictID, aspnet_Membership.Email, aspnet_Membership.IsApproved, 
                      aspnet_Membership.IsLockedOut, aspnet_Membership.ApplicationId, aspnet_Applications.ApplicationName
FROM         aspnet_Users INNER JOIN
                      aspnet_Membership ON aspnet_Users.UserId = aspnet_Membership.UserId INNER JOIN
                      aspnet_Applications ON aspnet_Users.ApplicationId = aspnet_Applications.ApplicationId
WHERE     (aspnet_Applications.ApplicationName = N'FC') AND (aspnet_Users.UserId = '"+UserID+"')");
            if (dt.Rows.Count > 0)
            {
                username = dt.Rows[0]["UserName"].ToString();
                provinceid = dt.Rows[0]["ProvinceID"].ToString();
                districtid = dt.Rows[0]["DistrictID"].ToString();
                email = dt.Rows[0]["Email"].ToString();               
                var profile = ProfileBase.Create(username, true);
                fullname = profile.GetPropertyValue("FullName").ToString();
                designation = profile.GetPropertyValue("Designation").ToString();
                age = profile.GetPropertyValue("Age").ToString();
            }
            return new OCM_UserInfo(UserName, ProvinceID, DistrictID, Email, Designation, FullName);
        }
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string ProvinceID
        {
            get
            {
                return provinceid;
            }
            set
            {
                provinceid = value;
            }
        }
        public string DistrictID
        {
            get
            {
                return districtid;
            }
            set
            {
                districtid = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                designation = value;
            }
        }
        public string FullName
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
            }
        }
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}