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

        ddlProvince.DataSource = OCM_UserInfo.GetUserProvinces();
        ddlProvince.DataTextField = "ProvinceEngName";
        ddlProvince.DataValueField = "ProvinceID";
        ddlProvince.DataBind();
        ddlProvince.Items.Insert(0, new ListItem("--Select--", "-1"));
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
    public static List<Voucher> GetVouchers(string Dept, string Prov)
    {
        List<Voucher> lst = new List<Voucher>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageUploadRecVocuher_GetVoucher";
        com.Parameters.AddWithValue("@Dept", SqlDbType.Int).Value = Dept;
        com.Parameters.AddWithValue("@prov", SqlDbType.Int).Value = Prov;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Voucher p = new Voucher();
            p.GRVID = dr["id"].ToString();
            p.Serial = dr["SerialNo"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static formData[] GetVoucherDetail(string id)
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;

        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        con.Open();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPagerecReqUpload_GetDetail";
        com.Parameters.Clear();
        string[] arr = id.Split('/').ToArray();
        com.Parameters.AddWithValue("@GRVID", SqlDbType.BigInt).Value =arr[0];
        com.Parameters.AddWithValue("@Sr", SqlDbType.Int).Value =arr[1] ;
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.Department = dr["Department"].ToString();
            p.GRVID = dr["GRVID"].ToString();
            p.InspDate = dr["InspectionDate"].ToString();
            p.Invoice = dr["Invoice"].ToString();
            p.Province = dr["ProvinceEngName"].ToString();
            p.RDate = dr["GRVDate"].ToString();
            p.Ref = dr["PurchaseRef"].ToString();
            p.SNo = dr["SerialNo"].ToString();
            p.Sr = dr["Sr"].ToString();
            p.Supplier = dr["Supplier"].ToString();
            p.RBY = dr["UserName"].ToString();
            p.Scanfile = dr["ScanFile"].ToString();
            p.Path = dr["Path"].ToString();
            lst.Add(p);

        }
        dr.Close();
        con.Close();
        return lst.ToArray();
    }

    public class Department
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class Voucher
    {
        public string GRVID { get; set; }
        public string Serial { get; set; }
    }
    public class formData
    {
        public string SNo { get; set; }
        public string Province { get; set; }
        public string Department { get; set; }
        public string RDate { get; set; }
        public string Invoice { get; set; }
        public string Ref { get; set; }
        public string Supplier { get; set; }
        public string InspDate { get; set; }
        public string Sr { get; set; }
        public string GRVID { get; set; }
        public string RBY { get; set; }
        public string Scanfile { get; set; }
        public string Path { get; set; }
    }
}