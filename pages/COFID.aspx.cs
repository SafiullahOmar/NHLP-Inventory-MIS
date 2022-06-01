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
            FillProvinceDDL();
    }
    public void FillProvinceDDL()
    {
        ddlProvince.DataSource = OCM_UserInfo.GetUserProvinces();
        ddlProvince.DataTextField = "ProvinceEngName";
        ddlProvince.DataValueField = "ProvinceID";
        ddlProvince.DataBind();
        ddlProvince.Items.Insert(0, new ListItem("--Select--", "-1"));
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<Department> GetSubDepartment()
    {
        List<Department> lst = new List<Department>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "shared_getSubDepartment";
        com.Parameters.AddWithValue("@DepartmentId", SqlDbType.Int).Value = -1;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Department p = new Department();
            p.Name = dr["SubDepartment"].ToString();
            p.ID = dr["SubDepartmentID"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }   
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static Asset GetItemStockByCode(int ProvId, string Code)
    {
        
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageCOFID_GetItemsStockBYCode";
        com.Parameters.AddWithValue("@ProvinceId", SqlDbType.Int).Value = ProvId;
        com.Parameters.AddWithValue("@Code", SqlDbType.BigInt).Value = Code;

        SqlParameter p = new SqlParameter();
        p.ParameterName = "@Count";
        p.Direction = ParameterDirection.Output;
        p.SqlDbType = SqlDbType.Float;
        com.Parameters.Add(p);

        SqlParameter p1 = new SqlParameter();
        p1.ParameterName = "@AssetName";
        p1.Direction = ParameterDirection.Output;
        p1.SqlDbType = SqlDbType.VarChar;
        p1.Size = 50;
        com.Parameters.Add(p1);

        SqlParameter p2 = new SqlParameter();
        p2.ParameterName = "@AssetID";
        p2.Direction = ParameterDirection.Output;
        p2.SqlDbType = SqlDbType.VarChar;
        p2.Size = 50;
        com.Parameters.Add(p2);

        con.Open();
        com.ExecuteReader();
        Asset asset = new Asset();
        asset.ID = com.Parameters["@AssetID"].Value.ToString();
        asset.Quantity = com.Parameters["@Count"].Value.ToString();
        asset.Item = com.Parameters["@AssetName"].Value.ToString();

        con.Close();
        return asset;
       
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<ProductSUBCategory> GetSubClassLists(string ClassID)
    {
        List<ProductSUBCategory> lst = new List<ProductSUBCategory>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageSubClass_List";
        com.Parameters.AddWithValue("@ClassID", SqlDbType.Int).Value = ClassID;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            ProductSUBCategory p = new ProductSUBCategory();
            p.Name = dr["Name"].ToString();
            p.ID = dr["SubClassID"].ToString();

            p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? true : false;
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static void SaveFormDetail(formData formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@Dept", SqlDbType.Int) { Value = formDetails.Department };
            p[1] = new SqlParameter("@Prov", SqlDbType.Int) { Value = formDetails.Province };
            p[2] = new SqlParameter("@Code", SqlDbType.BigInt) { Value = formDetails.bC };
            p[3] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = formDetails.Quantity };
            p[4] = new SqlParameter("@IssuedBy", SqlDbType.VarChar) { Value = formDetails.Issuer };
            p[5] = new SqlParameter("@IssuedDate", SqlDbType.VarChar) { Value = formDetails.IssueDate };
            
            p[6] = new SqlParameter("@Position", SqlDbType.NVarChar) { Value = formDetails.Position };
            p[7] = new SqlParameter("@Reciever", SqlDbType.NVarChar) { Value = formDetails.Reciever };
            p[8] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = formDetails.Remarks };
            p[9] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[10] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
            p[11] = new SqlParameter("@ID", SqlDbType.BigInt);
            p[11].Direction = ParameterDirection.Output;
            string ID = dbT.ExecuteTransStoreProcedureReturn("spPageCOFID_Save", p, true, "@ID");

            SqlParameter[] pRD = new SqlParameter[8];
            pRD[0] = new SqlParameter("@SR", SqlDbType.Int) { Value =0 };
            pRD[1] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = ID };
            pRD[2] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = formDetails.bC };
            pRD[3] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = formDetails.Quantity };
            pRD[4] = new SqlParameter("@ProvId", SqlDbType.Int) { Value = formDetails.Province };
            pRD[5] = new SqlParameter("@UpdateType", SqlDbType.Char) { Value = "FAI" };
            pRD[6] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            pRD[7] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = formDetails.IssueDate };
            dbT.ExecuteTransStoreProcedure("UpdateReconcileInfo", pRD, true);

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
    public static List<formData> GetCOFILists(string Prov)
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageCOFID_List";
        com.Parameters.AddWithValue("@prov", SqlDbType.Int).Value = Prov;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.Item = dr["ItmName"].ToString();
            p.Reciever = dr["Reciever"].ToString();
            p.Position = dr["Position"].ToString();
            p.Department = dr["SubDepartment"].ToString();
            p.Quantity = dr["Unit"].ToString();
            p.Serial = dr["Serial"].ToString();
            p.Quantity = dr["Quantity"].ToString();
            p.Unit = dr["Unit"].ToString();
            p.Id = dr["COFIId"].ToString();
            p.bC = dr["Code"].ToString();
            p.ItemId = dr["ItemID"].ToString();
            p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? true : false;
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    
    [WebMethod]
    public static void SetToFalse(string Id, string ItmId, string Reciever)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            if (HttpContext.Current.User.IsInRole("Super User"))
            {
                dbT.BeginTransaction();
                MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@Reciever", SqlDbType.NVarChar) { Value = Reciever };
                p[1] = new SqlParameter("@ItemId", SqlDbType.VarChar) { Value = ItmId };
                p[2] = new SqlParameter("@Id", SqlDbType.BigInt) { Value = Id };
                p[3] = new SqlParameter("@UpdationDate", SqlDbType.NVarChar) { Value =DateTime.Now.ToString() };
                p[4] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                dbT.ExecuteTransStoreProcedure("spPageCOFID_Delete", p, true);
                 dbT.EndTransaction();

            }
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
    public class ProductSUBCategory {
        public string Name { get; set; }
        public string ID { get; set; }
        public string ClassID { get; set; }
        public bool Edit { get; set; }
    }
    public class ItemClass {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class Asset
    {
        public string ID { get; set; }
        public string Item { get; set; }
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }
    }
    public class Items
    {
        public string ID { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }

    }

    public class formData {
        public string  Department { get; set; }
        public string  Province { get; set; }
        public string  Item { get; set; }
        public string ItemId { get; set; }
        public string  Quantity { get; set; }
        public string  IssueDate { get; set; }
        public string  Issuer { get; set; }
        public string Serial { get; set; }
        public string Position { get; set; }
        public string Reciever { get; set; }
        public string Remarks { get; set; }
        public string Unit { get; set; }
        public string Id { get; set; }
        public string bC { get; set; }
        public bool Edit { get; set; }
    }
   

}