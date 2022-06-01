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
    public static void SaveFormDetail(ProductSUBCategory formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = formDetails.Name };
            p[1] = new SqlParameter("@ClassID", SqlDbType.Int) { Value = formDetails.ClassID }; 
            p[2] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[3] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
            dbT.ExecuteTransStoreProcedure("spPageSubClass_Insert", p, true);
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
    public static ProductSUBCategory GetDetailByID(string SCID)
    {
        ProductSUBCategory p = new ProductSUBCategory();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandText = @"select * from tblINV_SubClass where SubClassID = '" + SCID + "'";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            p.Name = dr["Name"].ToString();
           
        }
        con.Close();
        dr.Close();
        return p;
    }
    [WebMethod]
    public static void UpdateFormDetail(ProductSUBCategory formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            if (HttpContext.Current.User.IsInRole("Super User"))
            {
                dbT.BeginTransaction();
                MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = formDetails.Name };
                p[1] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                p[2] = new SqlParameter("@UpdatedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                p[3] = new SqlParameter("@ClassID", SqlDbType.Int) { Value =formDetails.ClassID };
                p[4] = new SqlParameter("@SubClassID", SqlDbType.VarChar) { Value = formDetails.ID };
                dbT.ExecuteTransStoreProcedure("spPageSubClass_Update", p, true);
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
    public static bool DeleteSubClass(string subclassId)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            bool flag = false;
            if (HttpContext.Current.User.IsInRole("Super User"))
            {
                dbT.BeginTransaction();
                MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@SubClassId", SqlDbType.VarChar) { Value =subclassId };
                p[1] = new SqlParameter("@exist", SqlDbType.Bit);
                p[1].Direction = ParameterDirection.Output;
                flag = Convert.ToBoolean(dbT.ExecuteTransStoreProcedureReturn("spPageSubClass_Delete", p, true, "@exist"));
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
}