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
    public static List<formData> getReqRequestD(string Code, string Prov, string Dep)
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageRequestedRequest_getList";
        com.Parameters.AddWithValue("@ReqId", SqlDbType.BigInt).Value = Code;
        com.Parameters.AddWithValue("@Prov", SqlDbType.Int).Value = Prov;
        com.Parameters.AddWithValue("@Dep", SqlDbType.Int).Value = Dep;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.BCode = dr["R_Id"].ToString();
            p.Dept = dr["SubDepartment"].ToString();
            p.Name = dr["R_Name"].ToString();
            p.Pos = dr["R_Position"].ToString();
            p.Prov = dr["ProvinceEngName"].ToString();
            p.RDate = dr["R_Date"].ToString();
            p.RType = dr["R_Type"].ToString();
            p.TItems = dr["TotalItems"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }

    public class Department
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    
    public class formData
    {
        public string RType { get; set; }
        public string Name { get; set; }
        public string Pos { get; set; }
        public string Prov { get; set; }
        public string Dept { get; set; }
        public string BCode { get; set; }
        public string RDate { get; set; }
        public string TItems { get; set; }
    }



}