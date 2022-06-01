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

public partial class pages_ReqApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static formData[] GetStoreReqDetail()
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        con.Open();

        if (HttpContext.Current.User.IsInRole("Store"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageIssueStore_GetReqDetail";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["Department"].ToString();
                p.ProId = dr["R_ProvinceId"].ToString();
                p.DeptId = dr["R_DepartmentId"].ToString();
                p.Prov = dr["ProvinceEngName"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }

        if (HttpContext.Current.User.IsInRole("INV"))
        {
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "spPageIssueInv_GetReqDetail";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                formData p = new formData();
                p.DaysLast = dr["TdayslastfromRequested"].ToString();
                p.Position = dr["R_Position"].ToString();
                p.RBY = dr["R_Name"].ToString();
                p.RID = dr["R_Id"].ToString();
                p.TItems = dr["TotalItems"].ToString();
                p.Dept = dr["SubDepartment"].ToString();
                p.ProId = dr["R_ProvinceId"].ToString();
                p.DeptId = dr["R_SubDepartmentId"].ToString();
                p.Prov = dr["ProvinceEngName"].ToString();
                lst.Add(p);

            }
            dr.Close();
        }


        con.Close();
        return lst.ToArray();
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<ProductSUBCategory> GetSubClass()
    {
        List<ProductSUBCategory> lst = new List<ProductSUBCategory>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageSubClass_List";
        com.Parameters.AddWithValue("@ClassID", SqlDbType.Int).Value = -10;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            ProductSUBCategory p = new ProductSUBCategory();
            p.Name = dr["Name"].ToString();
            p.ID = dr["SubClassID"].ToString();

            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<Items> GetReqItemDetail(string ReqId)
    {
        List<Items> lst = new List<Items>();
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
            Items p = new Items();
            p.Item = dr["Name"].ToString();
            p.Quantity = dr["Quantity"].ToString();
            p.Remarks = dr["Remarks"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<Items> GetStoreItems(string SubClassID)
    {
        List<Items> lst = new List<Items>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageRecievingVoucher_ItemList";
        com.Parameters.AddWithValue("@SubClassID", SqlDbType.VarChar).Value = SubClassID;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Items p = new Items();
            p.ID = dr["ItemID"].ToString();
            p.Item = dr["Name"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GeItemsNumbersInStock(string ItmID)
    {
        List<Items> lst = new List<Items>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageIssueAdmin_GetStoredItemCount2";
        com.Parameters.AddWithValue("@ItemId", SqlDbType.VarChar).Value = ItmID;
        com.Parameters.AddWithValue("@ProvinceId", SqlDbType.Int).Value = OCM_UserInfo.GetUserOfficeLocation();
        com.Parameters.AddWithValue("@DeptId", SqlDbType.Int).Value = OCM_UserInfo.GetUserOfficeDepartment();
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        string NumberOfItems = "";
        while (dr.Read())
        {
            NumberOfItems = dr["cnt"].ToString();
        }
        dr.Close();
        con.Close();
        return NumberOfItems;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static void SaveFormDetail(IssuedItems formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);

            if (formDetails.IList.Count > 0)
            {
                string query = "";
                foreach (Items itm in formDetails.IList)
                {
                    query += @"  INSERT INTO [dbo].[tblINV_IISUVD] ([ISSUID],[It_ID] ,[QU]  ,[UserId] ,[InsertedDate])
                                VALUES (tey,N'" + itm.ID + "'," + itm.Quantity + ",'" + usr.ProviderUserKey.ToString() + "',N'" + DateTime.Now.ToString() + "')";

                }
                if (query.Length > 0)
                {
                    SqlParameter[] p = new SqlParameter[11];
                    p[0] = new SqlParameter("@IS_D", SqlDbType.NVarChar) { Value = formDetails.IS_D };
                    p[1] = new SqlParameter("@IS_By", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[2] = new SqlParameter("@RC_By", SqlDbType.NVarChar) { Value = formDetails.RC_By };
                    p[3] = new SqlParameter("@DeptId", SqlDbType.Int) { Value =  OCM_UserInfo.GetUserOfficeDepartment()};
                    p[4] = new SqlParameter("@ProId", SqlDbType.Int) { Value = OCM_UserInfo.GetUserOfficeLocation() };


                    p[5] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = formDetails.Remarks };
                    p[6] = new SqlParameter("@Sql", SqlDbType.NVarChar) { Value = query };

                    p[7] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[8] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    p[9] = new SqlParameter("@Req_Id", SqlDbType.BigInt) { Value = formDetails.Req_Id };
                    p[10] = new SqlParameter("@ID", SqlDbType.BigInt);
                    p[10].Direction = ParameterDirection.Output;
                    dbT.ExecuteTransStoreProcedure("spPageAdminIssueItemV_Save", p, true);
                    dbT.EndTransaction();
                }
            }
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
        public string DeptId { get; set; }
        public string ProId { get; set; }
        public string Prov { get; set; }
    }
   
    public class ProductSUBCategory
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string ClassID { get; set; }
    }
    public class Items
    {
        public string ID { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }

    }
    public class IssuedItems {
        public string Req_Id { get; set; }
        public string IS_D { get; set; }
        public string DeptId { get; set; }
        public string ProId { get; set; }
        public string IS_By { get; set; }
        public string RC_By { get; set; }
        public string Remarks { get; set; }
        public string InsertedDate { get; set; }
        public List<Items> IList { get; set; }
    }
}