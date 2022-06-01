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
    public static void SaveFormDetail(ProductGCategory formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@ClassName", SqlDbType.NVarChar) { Value = formDetails.Name };            
            p[1] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[2] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
            dbT.ExecuteTransStoreProcedure("spPageClass_Insert", p, true);
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
    public static List<ProductGCategory> GetClassLists()
    {
        List<ProductGCategory> lst = new List<ProductGCategory>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageClass_List";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            ProductGCategory p = new ProductGCategory();
            p.Name = dr["Class"].ToString();
            p.ID = dr["ClassID"].ToString();

            p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? true : false;
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    public static ProductGCategory GetDetailByID(string CID)
    {
        ProductGCategory p = new ProductGCategory();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandText = @"select * from tblINV_Class where ClassID = " + CID + "";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            p.Name = dr["Class"].ToString();
           
        }
        con.Close();
        dr.Close();
        return p;
    }
    [WebMethod]
    public static void UpdateFormDetail(ProductGCategory formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            if (HttpContext.Current.User.IsInRole("Super User"))
            {
                dbT.BeginTransaction();
                MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@ClassName", SqlDbType.NVarChar) { Value = formDetails.Name };
                p[1] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                p[2] = new SqlParameter("@UpdatedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                p[3] = new SqlParameter("@ClassID", SqlDbType.Int) { Value =formDetails.ID };
                dbT.ExecuteTransStoreProcedure("spPageClass_Update", p, true);
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
    public static bool Delete_g_category(string classId)
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
                p[0] = new SqlParameter("@ClassId", SqlDbType.VarChar) { Value =classId };
                p[1] = new SqlParameter("@exist", SqlDbType.Bit);
                p[1].Direction = ParameterDirection.Output;
                flag = Convert.ToBoolean(dbT.ExecuteTransStoreProcedureReturn("spPageClass_Delete", p, true, "@exist"));
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
    public class ProductGCategory {
        public string Name { get; set; }
        public string ID { get; set; }
        public bool Edit { get; set; }
    }
}