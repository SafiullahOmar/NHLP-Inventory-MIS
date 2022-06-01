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

    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<ItemClass> GetClass()
    {
        List<ItemClass> lst = new List<ItemClass>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageClass_List";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            ItemClass p = new ItemClass();
            p.Name = dr["Class"].ToString();
            p.ID = dr["ClassID"].ToString();
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
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = formDetails.Name };
            p[1] = new SqlParameter("@SubClassID", SqlDbType.VarChar) { Value = formDetails.SubClassID }; 
            p[2] = new SqlParameter("@UnitID", SqlDbType.Int) { Value = formDetails.UnitID };
            p[3] = new SqlParameter("@AssetType", SqlDbType.Int) { Value = formDetails.AssetType }; 
            p[4] = new SqlParameter("@ItemKeepingId", SqlDbType.Int) { Value = formDetails.KeepingType };
            p[5] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[6] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
            dbT.ExecuteTransStoreProcedure("spPageProductItems_Insert", p, true);
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
    public static List<formData> GetItemsLists(string ClassID)
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageProductItems_List";
        com.Parameters.AddWithValue("@ClassID", SqlDbType.Int).Value = ClassID;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.Name = dr["Name"].ToString();
            p.AssetType = dr["AssestType"].ToString();
            p.KeepingType = dr["ItemsKeepingType"].ToString();
            p.SubClassID = dr["SubClass"].ToString();
            p.UnitID = dr["Unit"].ToString();
            p.ItemID = dr["ItemID"].ToString();
            p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? true : false;
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    public static formData GetDetailByID(string ItemID)
    {
        formData p = new formData();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandText = @"select * from tblINV_Items where ItemID = '" + ItemID + "'";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            p.Name = dr["Name"].ToString();
            p.AssetType = dr["AssetTypeID"].ToString();
            p.KeepingType = dr["ItemKeepingTypeID"].ToString();
            p.SubClassID = dr["SubClassID"].ToString();
            p.UnitID = dr["UnitID"].ToString();
        }
        con.Close();
        dr.Close();
        return p;
    }
    [WebMethod]
    public static void UpdateFormDetail(formData formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            if (HttpContext.Current.User.IsInRole("Super User"))
            {
                dbT.BeginTransaction();
                MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                SqlParameter[] p = new SqlParameter[8];
                p[0] = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = formDetails.Name };
                p[1] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                p[2] = new SqlParameter("@UpdatedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                p[3] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = formDetails.ItemID };
                p[4] = new SqlParameter("@ItemKeepingTypeID", SqlDbType.Int) { Value = formDetails.KeepingType };
                p[5] = new SqlParameter("@AssetTypeID", SqlDbType.Int) { Value = formDetails.AssetType };
                p[6] = new SqlParameter("@UnitID", SqlDbType.Int) { Value = formDetails.UnitID };
                p[7] = new SqlParameter("@SubClassID", SqlDbType.VarChar) { Value = formDetails.SubClassID };
                dbT.ExecuteTransStoreProcedure("spPageProductItems_Update", p, true);
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
    [WebMethod]
    public static bool DeleteItem(formData formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            bool flag = false;
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                dbT.BeginTransaction();
                MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = formDetails.ItemID };
                p[1] = new SqlParameter("@exist", SqlDbType.Bit);
                p[1].Direction = ParameterDirection.Output;
                flag = Convert.ToBoolean(dbT.ExecuteTransStoreProcedureReturn("spPageProductItem_Delete", p, true, "@exist"));
                if (flag == true)
                {
                    dbT.RollBackTransaction();
                    return flag;
                }

                dbT.EndTransaction();

            }
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
    public class UnitDetail {
        public string  ID { get; set; }
        public string Unit { get; set; }
    }

    public class formData {
        public string ItemID { get; set; }
        public string Name { get; set; }
        public string SubClassID { get; set; }
        public string UnitID { get; set; }
        public string AssetType { get; set; }
        public string KeepingType { get; set; }
        public bool Edit { get; set; }
    }
   

}