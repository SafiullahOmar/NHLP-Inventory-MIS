using OCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class pages_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillProvinceDDL();
        }
    }

    public void FillProvinceDDL()
    {

        ddlTProvince.DataSource = new OCM_DbGeneral().SelectRecords("select * from OCM_Province");
        ddlTProvince.DataTextField = "ProvinceEngName";
        ddlTProvince.DataValueField = "ProvinceID";
        ddlTProvince.DataBind();
        ddlTProvince.Items.Insert(0, new ListItem("--Select--", "-1"));
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<Department> GetDepartment()
    {
        List<Department> lst = new List<Department>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageDepartment_List";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Department p = new Department();
            p.Name = dr["Department"].ToString();
            p.ID = dr["DeparmentID"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static void ApproveTransferedItems(List<formData> lst)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);

            if (lst.Count > 0)
            {
                foreach (formData f in lst)
                {
                    SqlParameter[] p = new SqlParameter[9];

                    p[0] = new SqlParameter("@bCode", SqlDbType.VarChar) { Value = f.BCode };
                    p[1] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = f.Quantity };
                    p[2] = new SqlParameter("@TDate", SqlDbType.NVarChar) { Value = f.TDate };
                    p[3] = new SqlParameter("@IssDept", SqlDbType.VarChar) { Value = f.IsDept };
                    p[4] = new SqlParameter("@IssProv", SqlDbType.VarChar) { Value = f.IsProv };
                    p[5] = new SqlParameter("@RecDept", SqlDbType.VarChar) { Value = f.RDept };
                    p[6] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[7] = new SqlParameter("@ApproveDate", SqlDbType.VarChar) { Value = DateTime.Now.ToString() };
                    p[8] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = f.ItemID };
                    dbT.ExecuteTransStoreProcedure("spPageTransferItemsApproval_Approve", p, true);

                    
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
    public static List<formData> getTranIssuedItemsList(string TProv, string TDept, string TMonth)
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageTransferItemsApproval_List";
        com.Parameters.AddWithValue("@TProv", SqlDbType.Int).Value = TProv;
        com.Parameters.AddWithValue("@TDept", SqlDbType.Int).Value = TDept;
        com.Parameters.AddWithValue("@TMonth", SqlDbType.NVarChar).Value = TMonth;
        com.Parameters.AddWithValue("@IsFixedAsset", SqlDbType.Bit).Value = "False";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.TransferedBy = dr["TransferdBy"].ToString();
            p.TDate = dr["TDate"].ToString();
            p.RProv = dr["RecProv"].ToString();
            //  p.Remarks = dr["ProvinceEngName"].ToString();
            p.RDept = dr["RecDept"].ToString();
            p.Quantity = dr["Quantity"].ToString();
            p.IsProv = dr["IsProv"].ToString();
            p.IsDept = dr["IsDept"].ToString();
            p.BCode = dr["bCode"].ToString();
            p.ItemID = dr["ItemID"].ToString();
            p.Name = dr["Name"].ToString();
          
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    public static bool SetToFalse(string bCode, string Qunatity, string IsDept, string IsProv, string RDept, string TDate)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            bool flag = false;
            // if (HttpContext.Current.User.IsInRole("Admin"))
            // {
            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@bCode", SqlDbType.BigInt) { Value = bCode };
            p[1] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = Qunatity };
            p[2] = new SqlParameter("@TDate", SqlDbType.NVarChar) { Value = TDate };
            p[3] = new SqlParameter("@IssDept", SqlDbType.VarChar) { Value = IsDept };
            p[4] = new SqlParameter("@IssProv", SqlDbType.VarChar) { Value = IsProv };
            p[5] = new SqlParameter("@RecDept", SqlDbType.VarChar) { Value = RDept };
            p[6] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[7] = new SqlParameter("@UpdationDate", SqlDbType.VarChar) { Value = DateTime.Now.ToString() };
            p[8] = new SqlParameter("@exist", SqlDbType.Bit);
            p[8].Direction = ParameterDirection.Output;
            flag = Convert.ToBoolean(dbT.ExecuteTransStoreProcedureReturn("spPageTransferItems_Delete", p, true, "@exist"));
            if (flag == true)
            {
                dbT.RollBackTransaction();
                return flag;
            }

            dbT.EndTransaction();

            //}
            return flag;
        }
        catch (Exception)
        {
            dbT.EndTransaction();
            throw;
        }
        finally
        {
            dbT.Connection.Close();
            SqlConnection.ClearPool(dbT.Connection);
        }
    }

    public class Department
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class Items
    {
        public string ID { get; set; }
        public string Item { get; set; }
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }
    }
    public class formData
    {
        public string TDate { get; set; }
        public string IsProv { get; set; }
        public string IsDept { get; set; }
        public string RProv { get; set; }
        public string RDept { get; set; }
        public string BCode { get; set; }
        public string ItemID { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string TransferedBy { get; set; }
        public string Remarks { get; set; }
        public List<Items> Ilst { get; set; }
        public bool Edit { get; set; }
    }

    }