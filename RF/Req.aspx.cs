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

public partial class pages_Req : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
    public static List<Items> GetItems()
    {
        List<Items> lst = new List<Items>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SharedGetItemList";
        com.Parameters.AddWithValue("@condition", SqlDbType.NVarChar).Value = "0";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Items p = new Items();
            p.ItemID = dr["ItemID"].ToString();
            p.Name = dr["Name"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<UnitDetail> GetUnit()
    {
        List<UnitDetail> lst = new List<UnitDetail>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageProductItems_Unit";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            UnitDetail p = new UnitDetail();
            p.ID = dr["UnitID"].ToString();
            p.Unit = dr["Unit"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<Province> GetProvinces()
    {
        List<Province> lst = new List<Province>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageReq_GetProvinces";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Province p = new Province();
            p.ID = dr["ProvinceID"].ToString();
            p.Name = dr["ProvinceEngName"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<Supervisors> GetSupervisors(string OL,string DP)
    {
        List<Supervisors> lst = new List<Supervisors>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageReq_GetSupervisors";
        com.Parameters.AddWithValue("@OL", SqlDbType.Int).Value = OL;
        com.Parameters.AddWithValue("@DP", SqlDbType.Int).Value = DP;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Supervisors p = new Supervisors();
            p.ID = dr["UserId"].ToString();
            p.Name = dr["UserName"].ToString();
            lst.Add(p);
           
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string SaveFormDetail(formData formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            string ID = "";
            if (formDetails.lst.Count > 0)
            {
                string query = "";
                foreach (ItemDetails itm in formDetails.lst)
                {
                    query += @"  INSERT INTO [dbo].[tblINV_ItemsReqD]([R_Id],[ItemID],[Quantity],[Remarks],[Date]) 
                                VALUES (tey,N'" + itm.Item + "'," + itm.ReqQuantity + ",N'" + (itm.Remarks.Length==0?"":itm.Remarks )+ "',N'" + DateTime.Now.ToString() + "')";

                }
                if (query.Length > 0)
                {
                    SqlParameter[] p = new SqlParameter[10];
                    p[0] = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = formDetails.Name };
                    p[1] = new SqlParameter("@Position", SqlDbType.NVarChar) { Value = formDetails.Position };
                    p[2] = new SqlParameter("@Province", SqlDbType.Int) { Value = formDetails.Province };
                    p[3] = new SqlParameter("@DP", SqlDbType.Int) { Value = formDetails.Department };
                    p[4] = new SqlParameter("@SP", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(formDetails.Supervisor) };
                    p[5] = new SqlParameter("@Email", SqlDbType.NVarChar) { Value = formDetails.Email.Length==0?"":formDetails.Email };
                    p[6] = new SqlParameter("@Date", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    p[7] = new SqlParameter("@sql", SqlDbType.NVarChar) { Value = query };
                    p[8] = new SqlParameter("@ReqType", SqlDbType.Int) { Value = 1 };
                    p[9] = new SqlParameter("@RID", SqlDbType.BigInt);
                    p[9].Direction = ParameterDirection.Output;
                     ID= dbT.ExecuteTransStoreProcedureReturn("spPageReq_Save", p, true,"@RID");
                    dbT.EndTransaction();
                   
                }
            }

            return ID;
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
    public class UnitDetail
    {
        public string ID { get; set; }
        public string Unit { get; set; }
    }
    public class Province {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class Supervisors {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class Items
    {
        public string Name { get; set; }
        public string ItemID { get; set; }
    }
    public class Department
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class formData {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Province { get; set; }
        public string Department { get; set; }
        public string Supervisor { get; set; }
        public string Email { get; set; }
        public List<ItemDetails> lst { get; set; }
    }
    public class ItemDetails {
        public string Item { get; set; }
        public string ReqQuantity { get; set; }
        public string Remarks { get; set; }
    }
}