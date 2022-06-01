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
    public static formData[] GetPReqDetail()
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        
        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        con.Open();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "PReq_d_GetDetail";
        com.Parameters.Clear();
        if(usr!=null)
        com.Parameters.AddWithValue("@UID", SqlDbType.UniqueIdentifier).Value =new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
        
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.TIssuedItems = dr["TIssueItems"].ToString();
            p.Position = dr["R_Position"].ToString();
            p.RBY = dr["R_Name"].ToString();
            p.RID = dr["R_Id"].ToString();
            p.TReqItems = dr["TReqItems"].ToString();
            p.Dept = dr["SubDepartment"].ToString();
            p.ProId = dr["R_ProvinceId"].ToString();
            p.DeptId = dr["R_SubDepartmentId"].ToString();
            p.ISID = dr["ISSUID"].ToString();
            p.Dept = dr["SubDepartment"].ToString();
            p.Prov = dr["ProvinceEngName"].ToString();
            p.RType = dr["ReqTypeD"].ToString();
            p.ReqTypeId = dr["R_TypeId"].ToString();
            //p.Edit = Convert.ToInt16(dr["AllowEdit"].ToString());
            p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? 1: 0;
            lst.Add(p);

        }
        dr.Close();
        con.Close();
        return lst.ToArray();
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
        com.CommandText = "spPageRequestApprovalSRC_GetItemsDetail";//OLd Ones
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
    public static List<Items> GetIssuedItemDetail(string ReqId,string IssueId)
    {
        List<Items> lst = new List<Items>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "PReq_d_GetIssuedItemDetail";//OLd Ones
        com.Parameters.AddWithValue("@R_Id", SqlDbType.BigInt).Value = ReqId;
        com.Parameters.AddWithValue("@I_Id", SqlDbType.BigInt).Value = IssueId;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Items p = new Items();
            p.Item = dr["Name"].ToString();
            p.Quantity = dr["QU"].ToString();
            p.Remarks = "";
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static void SetToFalseIssuedReq(string ReqId, string IssueId)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@UpdatedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
            p[1] = new SqlParameter("@R_Id", SqlDbType.BigInt) { Value = ReqId };
            p[2] = new SqlParameter("@UID", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[3] = new SqlParameter("@I_Id", SqlDbType.BigInt) { Value = IssueId };
            dbT.ExecuteTransStoreProcedure("PReq_d_SetReqToFalse", p, true);
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
        public string ISID { get; set; }
        public string TIssuedItems { get; set; }
        public string TReqItems { get; set; }
        public string VStep { get; set; }
        public string Dept { get; set; }
        public string Prov { get; set; }
        public string DeptId { get; set; }
        public string ProId { get; set; }
        public string RC_By { get; set; }
        public string IS_By { get; set; }
        public string ReqTypeId { get; set; }
        public string MyProperty { get; set; }
        public int Edit { get; set; }
    }
    public class Items
    {
        public string ID { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }

    }
    public class IssuedItems
    {
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