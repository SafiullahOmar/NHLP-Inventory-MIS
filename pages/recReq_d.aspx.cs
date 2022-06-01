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
    public static formData[] GetRecItemsReqDetail()
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        
        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        con.Open();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPagerecReq_d_GetDetail";
        com.Parameters.Clear();
        if(usr!=null)
            com.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
        
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
            lst.Add(p);

        }
        dr.Close();
        con.Close();
        return lst.ToArray();
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
    }
}