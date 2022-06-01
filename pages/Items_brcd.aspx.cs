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
    //[WebMethod]
    //[System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public static List<ItemClass> GetClass()
    //{
    //    List<ItemClass> lst = new List<ItemClass>();
    //    string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
    //    SqlConnection con = new SqlConnection(constr);
    //    SqlCommand com = con.CreateCommand();
    //    com.CommandType = CommandType.StoredProcedure;
    //    com.CommandText = "spPageClass_List";
    //    con.Open();
    //    SqlDataReader dr = com.ExecuteReader();
    //    while (dr.Read())
    //    {
    //        ItemClass p = new ItemClass();
    //        p.Name = dr["Class"].ToString();
    //        p.ID = dr["ClassID"].ToString();
    //        lst.Add(p);
    //    }
    //    dr.Close();
    //    con.Close();
    //    return lst;
    //}
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<GRV> GetSupplier(string ProvinceID, string GRVDate)
    {
        List<GRV> lst = new List<GRV>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageItemBarcode_Supplier";
        com.Parameters.AddWithValue("@GRVDate", SqlDbType.NVarChar).Value = GRVDate;
        com.Parameters.AddWithValue("@ProvinceID", SqlDbType.Int).Value = ProvinceID;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            GRV p = new GRV();
            p.GRVID = dr["GRVID"].ToString();
            p.Supplier = dr["Supplier"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<formData> GetBrcdItemsList(string GRVID, string Supplier, string GRVDate, string Prov)
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageItemBarcode_List";
        com.Parameters.AddWithValue("@GRVID", SqlDbType.BigInt).Value = GRVID;
        com.Parameters.AddWithValue("@Supplier", SqlDbType.NVarChar).Value = Supplier;
        com.Parameters.AddWithValue("@GRVDate", SqlDbType.NVarChar).Value = GRVDate;
        com.Parameters.AddWithValue("@ProId", SqlDbType.Int).Value = Prov;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.GVRID = dr["GRVID"].ToString();
            p.ItemID = dr["ItemID"].ToString();
            p.ItemName = dr["Name"].ToString();
            p.Modal = dr["Modal"].ToString();
            p.Price = dr["Price"].ToString();
            p.RecievedDate = dr["GRVDate"].ToString();
            p.Serial = dr["Serial"].ToString();
            p.SubClass = dr["subclass"].ToString();
            p.Unit = dr["Unit"].ToString();
            p.IsDeleted =Convert.ToBoolean(dr["IsDeleted"].ToString());
            p.Sr = dr["Sr"].ToString();
            p.Quantity = dr["Quantity"].ToString();
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
            string Code = "";
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@Sr", SqlDbType.Int) { Value = formDetails.Sr };
            p[1] = new SqlParameter("@IsDeleted", SqlDbType.Bit) { Value = formDetails.IsDeleted };
            p[2] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = formDetails.GVRID };
            p[3] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = formDetails.ItemID };
            p[4] = new SqlParameter("@Serial", SqlDbType.NVarChar) { Value = formDetails.Serial };
            p[5] = new SqlParameter("@Modal", SqlDbType.NVarChar) { Value = formDetails.Modal };
            p[6] = new SqlParameter("@Seq", SqlDbType.Int) { Value = formDetails.Seq };
            p[7] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[8] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
            p[9] = new SqlParameter("@RCode", SqlDbType.BigInt);
            p[9].Direction = ParameterDirection.Output;
            Code =dbT.ExecuteTransStoreProcedureReturn("spPageItemBarcode_Save", p, true, "@RCode");
            dbT.EndTransaction();
            return Code;
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
    //[WebMethod]
    //[System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public static List<formData> GetItemsLists(string ClassID)
    //{
    //    List<formData> lst = new List<formData>();
    //    string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
    //    SqlConnection con = new SqlConnection(constr);
    //    SqlCommand com = con.CreateCommand();
    //    com.CommandType = CommandType.StoredProcedure;
    //    com.CommandText = "spPageProductItems_List";
    //    com.Parameters.AddWithValue("@ClassID", SqlDbType.Int).Value = ClassID;
    //    con.Open();
    //    SqlDataReader dr = com.ExecuteReader();
    //    while (dr.Read())
    //    {
    //        formData p = new formData();
    //        p.Name = dr["Name"].ToString();
    //        p.AssetType = dr["AssestType"].ToString();
    //        p.KeepingType = dr["ItemsKeepingType"].ToString();
    //        p.SubClassID = dr["SubClass"].ToString();
    //        p.UnitID = dr["Unit"].ToString();
    //        p.ItemID = dr["ItemID"].ToString();
    //        p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? true : false;
    //        lst.Add(p);
    //    }
    //    dr.Close();
    //    con.Close();
    //    return lst;
    //}
    //[WebMethod]
    //public static formData GetDetailByID(string ItemID)
    //{
    //    formData p = new formData();
    //    string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
    //    SqlConnection con = new SqlConnection(constr);
    //    SqlCommand com = con.CreateCommand();
    //    com.CommandText = @"select * from tblINV_Items where ItemID = '" + ItemID + "'";
    //    con.Open();
    //    SqlDataReader dr = com.ExecuteReader();
    //    while (dr.Read())
    //    {
    //        p.Name = dr["Name"].ToString();
    //        p.AssetType = dr["AssetTypeID"].ToString();
    //        p.KeepingType = dr["ItemKeepingTypeID"].ToString();
    //        p.SubClassID = dr["SubClassID"].ToString();
    //        p.UnitID = dr["UnitID"].ToString();
    //    }
    //    con.Close();
    //    dr.Close();
    //    return p;
    //}
    //[WebMethod]
    //public static void UpdateFormDetail(formData formDetails)
    //{
    //    OCM_DbGeneral dbT = new OCM_DbGeneral();
    //    try
    //    {
    //        if (HttpContext.Current.User.IsInRole("Super User"))
    //        {
    //            dbT.BeginTransaction();
    //            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
    //            SqlParameter[] p = new SqlParameter[8];
    //            p[0] = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = formDetails.Name };
    //            p[1] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
    //            p[2] = new SqlParameter("@UpdatedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
    //            p[3] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = formDetails.ItemID };
    //            p[4] = new SqlParameter("@ItemKeepingTypeID", SqlDbType.Int) { Value = formDetails.KeepingType };
    //            p[5] = new SqlParameter("@AssetTypeID", SqlDbType.Int) { Value = formDetails.AssetType };
    //            p[6] = new SqlParameter("@UnitID", SqlDbType.Int) { Value = formDetails.UnitID };
    //            p[7] = new SqlParameter("@SubClassID", SqlDbType.VarChar) { Value = formDetails.SubClassID };
    //            dbT.ExecuteTransStoreProcedure("spPageProductItems_Update", p, true);
    //            dbT.EndTransaction();
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        dbT.EndTransaction();
    //        throw;
    //    }
    //    finally
    //    {
    //        dbT.Connection.Close();
    //        SqlConnection.ClearPool(dbT.Connection);
    //    }

    //}
    //[WebMethod]
    //public static bool DeleteItem(formData formDetails)
    //{
    //    OCM_DbGeneral dbT = new OCM_DbGeneral();
    //    try
    //    {
    //        bool flag = false;
    //        if (HttpContext.Current.User.IsInRole("Admin"))
    //        {
    //            dbT.BeginTransaction();
    //            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
    //            SqlParameter[] p = new SqlParameter[2];
    //            p[0] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = formDetails.ItemID };
    //            p[1] = new SqlParameter("@exist", SqlDbType.Bit);
    //            p[1].Direction = ParameterDirection.Output;
    //            flag = Convert.ToBoolean(dbT.ExecuteTransStoreProcedureReturn("spPageProductItem_Delete", p, true, "@exist"));
    //            if (flag == true)
    //            {
    //                dbT.RollBackTransaction();
    //                return flag;
    //            }

    //            dbT.EndTransaction();

    //        }
    //        return flag;
    //    }
    //    catch (Exception)
    //    {
    //        dbT.EndTransaction();
    //        throw;
    //    }
    //    finally
    //    {
    //        dbT.Connection.Close();
    //        SqlConnection.ClearPool(dbT.Connection);
    //    }
    //}
  
    public class GRV {
        public string  Supplier { get; set; }
        public string GRVID { get; set; }
    }

    public class formData {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string SubClass { get; set; }
        public string RecievedDate { get; set; }
        public string GVRID { get; set; }
        public string Modal { get; set; }
        public string Serial { get; set; }
        public string Price { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public string Sr { get; set; }
        public string Seq { get; set; }
    }
   

}