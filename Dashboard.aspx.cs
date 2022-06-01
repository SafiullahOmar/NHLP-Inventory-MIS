using OCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           DataTable dt = OCM.OCM_UserInfo.GetUserProvinces().Select("ProvinceId in (35,1,24,14,8,7,20,16,3,13)").CopyToDataTable();
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
            if (dt.Rows.Contains(35))
            {
                dt.Rows.Add(new object[] { 36, "All Duty Stations" });
            }
            ddlProvince.DataSource = dt;
            ddlProvince.DataTextField = "ProvinceEngName";
            ddlProvince.DataValueField = "ProvinceId";
            ddlProvince.DataBind();
            ddlProvince.SelectedValue = ddlProvince.Items[ddlProvince.Items.Count - 1].Value;
        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static ItemG ItemGTotalInfo(string year, string provincId)
    {
        ItemG itmP = null;
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandText = "spPageDashboard_GetAllTypeItemsDG";
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@year", SqlDbType.Int).Value = year;
        com.Parameters.AddWithValue("@prov", SqlDbType.Int).Value = provincId;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            itmP = new ItemG()
             {
                 OpeningBQ = float.Parse(dr["OPeningQ"].ToString()),
                 IssueQ = float.Parse(dr["IssueQ"].ToString()),
                 Transfrm4rmQ = float.Parse(dr["Transfer4rmQ"].ToString()),
                 TransfrmToQ = float.Parse(dr["TransferToQ"].ToString()),
                 BalanceQ = float.Parse(dr["balance"].ToString())
             };
        }
        dr.Close();
        con.Close();
        return itmP;
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static MultiQueryR ItemsMultiInfo(string year, string provincId)
    {
        DataTable dt = new DataTable();
        MultiQueryR obj = new MultiQueryR();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        con.Open();
        com.CommandText = "spPageDashboard_GetMultQueryResult";
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@year", SqlDbType.Int).Value = year;
        com.Parameters.AddWithValue("@prov", SqlDbType.Int).Value = provincId;
        
        using (SqlDataReader dr = com.ExecuteReader())
        {
          
            while (dr.Read())
            {
                obj.WR = dr["WR"].ToString();
            }
            int ReadCnt = 0;
            while (dr.NextResult())
            {
                if (ReadCnt == 0)
                {
                    while (dr.Read())
                    {
                        obj.AR = dr["AR"].ToString();
                        ReadCnt++;
                    }
                }
                else if (ReadCnt == 1)
                {
                    List<GReqTypeD> GReqDlst = new List<GReqTypeD>();
                    while (dr.Read())
                    {
                        GReqTypeD P = new GReqTypeD();
                        P.ReqType = dr["R_Type"].ToString();
                        P.Count = dr["cnt"].ToString();
                        GReqDlst.Add(P);
                    }
                    obj.GReqDlst = GReqDlst;
                    ReadCnt++;
                }
                else if (ReadCnt == 2)
                {
                    List<IssueItemsD> IssueItmlst = new List<IssueItemsD>();
                    while (dr.Read())
                    {
                        IssueItemsD I = new IssueItemsD();
                        I.Prov = dr["ProvinceEngName"].ToString();
                        I.CT = float.Parse(dr["Contribution TOOLS"].ToString());
                        I.OFF = float.Parse(dr["Office Use"].ToString());
                        I.Store = float.Parse(dr["Store"].ToString());
                        IssueItmlst.Add(I);
                    }
                    obj.IssueItmlst = IssueItmlst;
                    ReadCnt++;
                }
                else if (ReadCnt == 3)
                {
                    List<COFA> COFAlst = new List<COFA>();
                    while (dr.Read())
                    {
                        COFA A = new COFA();
                        A.Prov = dr["ProvinceEngName"].ToString();
                        A.QU = float.Parse(dr["cnt"].ToString());                        
                        COFAlst.Add(A);
                    }
                    obj.COFAlst = COFAlst;
                    ReadCnt++;
                }
            }

        }
        con.Close();
        return obj;
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static int numberOfNoty(string year)
    {
        int noty = 0;
        if (HttpContext.Current.User.IsInRole("Supervisor"))
        {
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = con.CreateCommand();
            com.CommandText = "getNOfWRequest_SuperVisor";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@year", SqlDbType.Int).Value = year;
            com.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = usr.ProviderUserKey.ToString();
            con.Open();
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    noty = Convert.ToInt16(dr["cnt"].ToString());
                }
            }
            con.Close();
        }
        if (HttpContext.Current.User.IsInRole("RC"))
        {
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = con.CreateCommand();
            com.CommandText = "getNOfWRequest_RC";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@year", SqlDbType.Int).Value = year;
            com.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = usr.ProviderUserKey.ToString();
            con.Open();
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    noty = Convert.ToInt16(dr["cnt"].ToString());
                }
            }
            con.Close();
        }
        if (HttpContext.Current.User.IsInRole("CH"))
        {
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = con.CreateCommand();
            com.CommandText = "getNOfWRequest_CH";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@year", SqlDbType.Int).Value = year;
            com.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = usr.ProviderUserKey.ToString();
            con.Open();
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    noty = Convert.ToInt16(dr["cnt"].ToString());
                }
            }
            con.Close();
        }
        if (HttpContext.Current.User.IsInRole("SCH"))
        {
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = con.CreateCommand();
            com.CommandText = "getNOfWRequest_SCH";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@year", SqlDbType.Int).Value = year;
            com.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = usr.ProviderUserKey.ToString();
            con.Open();
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    noty = Convert.ToInt16(dr["cnt"].ToString());
                }
            }
            con.Close();
        }
        if (HttpContext.Current.User.IsInRole("Logistic Officer"))
        {
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = con.CreateCommand();
            com.CommandText = "getNOfWRequest_SL";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@year", SqlDbType.Int).Value = year;
            com.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = usr.ProviderUserKey.ToString();
            con.Open();
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    noty = Convert.ToInt16(dr["cnt"].ToString());
                }
            }
            con.Close();
        }

        if (HttpContext.Current.User.IsInRole("Operation Manager"))
        {
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = con.CreateCommand();
            com.CommandText = "getNOfWRequest_OM";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@year", SqlDbType.Int).Value = year;
            com.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = usr.ProviderUserKey.ToString();
            con.Open();
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    noty = Convert.ToInt16(dr["cnt"].ToString());
                }
            }
            con.Close();
        }
        return noty;
    }
    public class ItemG
    {
        public float OpeningBQ { get; set; }
        public float IssueQ { get; set; }
        public float Transfrm4rmQ { get; set; }
        public float TransfrmToQ { get; set; }
        public float BalanceQ { get; set; }
    }
    public class GReqTypeD
    {
        public string ReqType { get; set; }
        public string Count { get; set; }
    }
    public class IssueItemsD
    {
        public float CT { get; set; }
        public string Prov { get; set; }
        public float OFF { get; set; }
        public float Store { get; set; }
    }
    public class COFA
    {
        public string Prov { get; set; }
        public float QU { get; set; }
    }
    public class MultiQueryR
    {
        public string WR { get; set; }
        public string AR { get; set; }
        public List<GReqTypeD> GReqDlst { get; set; }
        public List<IssueItemsD> IssueItmlst { get; set; }
        public List<COFA> COFAlst { get; set; }
    }
}