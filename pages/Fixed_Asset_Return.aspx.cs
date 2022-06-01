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
    public static List<string> GetRecievers(string ProvId,string SubCompId)
    {
        List<string> lst = new List<string>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageAssetReturn_getAssetRecivers";
        com.Parameters.AddWithValue("@ProvId", SqlDbType.Int).Value = ProvId;
        com.Parameters.AddWithValue("@SubCompId", SqlDbType.Int).Value =SubCompId;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            lst.Add(dr["Reciever"].ToString());
            
        }
        dr.Close();
        con.Close();
        return lst ;
    }   
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<Asset> GetIssuedItemDetail(int ProvId, string Reciever,string SubCompId)
    {
        
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageAssetReturn_getAssetDetails";
        com.Parameters.AddWithValue("@ProvId", SqlDbType.Int).Value = ProvId;
        com.Parameters.AddWithValue("@Reciever", SqlDbType.VarChar).Value = Reciever;
        com.Parameters.AddWithValue("@SubCompId", SqlDbType.Int).Value = SubCompId;
        List<Asset> lst = new List<Asset>();
        
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            lst.Add(new Asset() { ID = dr["Code"].ToString(), Name = dr["Name"].ToString(), COFID = dr["COFIId"].ToString() });
            
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<string> GetIssuedItemQuantity(int ProvId, string Reciever, string SubCompId,string Code)
    {

        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageAssetReturn_getAssetQuantity";
        com.Parameters.AddWithValue("@ProvId", SqlDbType.Int).Value = ProvId;
        com.Parameters.AddWithValue("@Reciever", SqlDbType.VarChar).Value = Reciever;
        com.Parameters.AddWithValue("@SubCompId", SqlDbType.Int).Value = SubCompId;
        com.Parameters.AddWithValue("@Code", SqlDbType.BigInt).Value = Code;
        List<string> lst = new List<string>();
        SqlParameter p = new SqlParameter();
        p.ParameterName = "@Count";
        p.Direction = ParameterDirection.Output;
        p.SqlDbType = SqlDbType.Float;
        com.Parameters.Add(p);
        SqlParameter p1 = new SqlParameter();
        p1.ParameterName = "@COFIId";
        p1.Direction = ParameterDirection.Output;
        p1.SqlDbType = SqlDbType.Float;
        com.Parameters.Add(p1);

        con.Open();
        com.ExecuteReader();
        lst.Add(com.Parameters["@Count"].Value.ToString());
        lst.Add(com.Parameters["@COFIId"].Value.ToString());
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
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@Code", SqlDbType.BigInt) { Value = formDetails.Code };
            p[1] = new SqlParameter("@COFID", SqlDbType.BigInt) { Value = formDetails.COFID };
            p[2] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = formDetails.Quantity };
            p[3] = new SqlParameter("@QualityId", SqlDbType.Int) { Value = formDetails.Quality };
            p[4] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = formDetails.Remarks };
            p[5] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[6] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
            p[7] = new SqlParameter("@Rdate", SqlDbType.NVarChar) { Value = formDetails.Rdate };
            dbT.ExecuteTransStoreProcedure("spPageAssetReturn_Save", p, true);
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
    public static List<formData> GetCOFILists(string Dept,string Prov)
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageCOFID_List";
        com.Parameters.AddWithValue("@Dept", SqlDbType.Int).Value = Dept;
        com.Parameters.AddWithValue("@prov", SqlDbType.Int).Value = Prov;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
           // formData p = new formData();
           // p.Item = dr["ItmName"].ToString();
           // p.Reciever = dr["Reciever"].ToString();
           //// p.Modal = dr["Modal"].ToString();
           //// p.Price = dr["Price"].ToString();
           // p.Quantity = dr["Unit"].ToString();
           // p.Serial = dr["Serial"].ToString();
           // p.Quantity = dr["Quantity"].ToString();
           // p.Unit = dr["Unit"].ToString();
           // p.Id = dr["COFIId"].ToString();
           // p.bC = dr["Code"].ToString();
           // p.ItemId = dr["ItemID"].ToString();
           // p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? true : false;
           // lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    
    [WebMethod]
    public static void SetToFalse(string Id, string ItmId, string Dept, string Prov)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            if (HttpContext.Current.User.IsInRole("Super User"))
            {
                dbT.BeginTransaction();
                MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@Dept", SqlDbType.Int) { Value = Dept };
                p[1] = new SqlParameter("@ItemId", SqlDbType.VarChar) { Value = ItmId };
                p[2] = new SqlParameter("@Prov", SqlDbType.Int) { Value = Prov };
                p[3] = new SqlParameter("@Id", SqlDbType.BigInt) { Value = Id };
                p[4] = new SqlParameter("@UpdationDate", SqlDbType.NVarChar) { Value =DateTime.Now.ToString() };
                p[5] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
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
    public class Asset  
    {
        public string ID { get; set; }
        public string Name{ get; set; }
        public string COFID { get; set; }
    }
 
    public class Items
    {
        public string ID { get; set; }
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }

    }

    public class formData {
        public string  Code { get; set; }
        public string  COFID { get; set; }
        public string  Quality{ get; set; }
        public string Remarks { get; set; }
        public string  Quantity { get; set; }
        public string Rdate { get; set; }
        public bool Edit { get; set; }
    }
   

}