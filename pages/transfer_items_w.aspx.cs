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
        ddlTProvince.DataSource = OCM_UserInfo.GetUserProvinces();
        ddlTProvince.DataTextField = "ProvinceEngName";
        ddlTProvince.DataValueField = "ProvinceID";
        ddlTProvince.DataBind();
        ddlTProvince.Items.Insert(0, new ListItem("--Select--", "-1"));

        ddlRProvince.DataSource = new OCM_DbGeneral().SelectRecords("select * from OCM_Province");
        ddlRProvince.DataTextField = "ProvinceEngName";
        ddlRProvince.DataValueField = "ProvinceID";
        ddlRProvince.DataBind();
        ddlRProvince.Items.Insert(0, new ListItem("--Select--", "-1"));
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
    public static Items GetWItems(string Code)
    {
        Items p = new Items();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        //same as with Admin section ,get data from items table
        com.CommandText = "spPageIssueStoreInv_GetItemInfo4rmBarcode";
        com.Parameters.AddWithValue("@Code", SqlDbType.BigInt).Value = Code;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            p.ID = dr["ItemID"].ToString();
            p.Item = dr["Name"].ToString();
            p.Code = dr["Code"].ToString();
        }
        dr.Close();
        con.Close();
        return p;
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
            p.ID = dr["ItemID"].ToString();
            p.Item = dr["Name"].ToString();
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GeItemsNumbersInStock(string ItmID,string DeptId,string ProvinceId)
    {
        List<Items> lst = new List<Items>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageIssueAdmin_GetStoredItemCount2";
        com.Parameters.AddWithValue("@ItemId", SqlDbType.VarChar).Value = ItmID;
        com.Parameters.AddWithValue("@ProvinceId", SqlDbType.Int).Value = ProvinceId;
        com.Parameters.AddWithValue("@DeptId", SqlDbType.Int).Value = DeptId;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        string NumberOfItems = "";
        while (dr.Read())
        {
            NumberOfItems = dr["cnt"].ToString();
        }
        dr.Close();
        con.Close();
        return NumberOfItems;
    }
    #region 11
    //[WebMethod]
    //[System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public static List<Items> GetRecievedItems(string SubClassID)
    //{
    //    List<Items> lst = new List<Items>();
    //    string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
    //    SqlConnection con = new SqlConnection(constr);
    //    SqlCommand com = con.CreateCommand();
    //    com.CommandType = CommandType.StoredProcedure;
    //    com.CommandText = "spPageRecievingVoucher_ItemList";
    //    com.Parameters.AddWithValue("@SubClassID", SqlDbType.VarChar).Value = SubClassID;
    //    con.Open();
    //    SqlDataReader dr = com.ExecuteReader();
    //    while (dr.Read())
    //    {
    //        Items p = new Items();
    //        p.ID = dr["ItemID"].ToString();
    //        p.Item = dr["Name"].ToString();
    //        lst.Add(p);
    //    }
    //    dr.Close();
    //    con.Close();
    //    return lst;
    //}
    #endregion
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static void SaveFormDetail(formData formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);

            if (formDetails.Ilst.Count > 0)
            {
                foreach (Items itm in formDetails.Ilst)
                {
                    SqlParameter[] p = new SqlParameter[12];
                    p[0] = new SqlParameter("@bCode", SqlDbType.BigInt) { Value = 0 };
                    p[1] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = itm.Quantity };
                    p[2] = new SqlParameter("@TransferBy", SqlDbType.NVarChar) { Value = formDetails.TransferedBy };
                    p[3] = new SqlParameter("@TDate", SqlDbType.NVarChar) { Value = formDetails.TDate };
                    p[4] = new SqlParameter("@IsProv", SqlDbType.Int) { Value = formDetails.IsProv };

                    p[5] = new SqlParameter("@IsDept", SqlDbType.Int) { Value = formDetails.IsDept };
                    p[6] = new SqlParameter("@RecProv", SqlDbType.Int) { Value = formDetails.RProv };
                    p[7] = new SqlParameter("@RecDept", SqlDbType.Int) { Value = formDetails.RDept };

                    p[8] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = formDetails.Remarks };
                    p[9] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[10] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    p[11] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = itm.Code };
                    dbT.ExecuteTransStoreProcedure("spPageTransferItems_Save", p, true);

                    SqlParameter[] pRD = new SqlParameter[8];
                    pRD[0] = new SqlParameter("@SR", SqlDbType.Int) { Value =formDetails.RProv };
                    pRD[1] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = 0 };
                    pRD[2] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = itm.Code };
                    pRD[3] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = itm.Quantity };
                    pRD[4] = new SqlParameter("@ProvId", SqlDbType.Int) { Value = formDetails.IsProv };
                    pRD[5] = new SqlParameter("@UpdateType", SqlDbType.Char) { Value = "T" };
                    pRD[6] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    pRD[7] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    dbT.ExecuteTransStoreProcedure("UpdateReconcileInfo", pRD, true);

                }
                   
                
            }
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
    public static List<formData> GetWTransferItemsList(string TProv,string TDept)
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageTransferItems_List";
        com.Parameters.AddWithValue("@TProv", SqlDbType.Int).Value =TProv ;
        com.Parameters.AddWithValue("@TDept", SqlDbType.Int).Value =TDept;
        com.Parameters.AddWithValue("@IsFixedAsset", SqlDbType.Bit).Value ="False";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.TransferedBy = dr["TransferdBy"].ToString();
            p.TDate = dr["TDate"].ToString();
            p.RProv = dr["RecProv"].ToString();
          //  p.Remarks = dr["ProvinceEngName"].ToString();
            p.RDept = dr["RecDept"].ToString();
            p.Quantity = dr["Quantity"].ToString();
            p.IsProv = dr["IsProv"].ToString();
            p.IsDept = dr["IsDept"].ToString();
            p.Name = dr["Name"].ToString();
            p.Code = dr["ItemId"].ToString();
           
            p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? true : false;
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    public static bool SetToFalse(string bCode, string Qunatity, string IsDept, string IsProv, string RDept, string TDate)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {
            bool flag = false;
            // if (HttpContext.Current.User.IsInRole("Admin"))
            // {
            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@bCode", SqlDbType.VarChar) { Value = bCode };
            p[1] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = Qunatity };
            p[2] = new SqlParameter("@TDate", SqlDbType.NVarChar) { Value = TDate };
            p[3] = new SqlParameter("@IssDept", SqlDbType.VarChar) { Value = IsDept };
            p[4] = new SqlParameter("@IssProv", SqlDbType.VarChar) { Value = IsProv };
            p[5] = new SqlParameter("@RecDept", SqlDbType.VarChar) { Value = RDept };
            p[6] = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
            p[7] = new SqlParameter("@UpdationDate", SqlDbType.VarChar) { Value = DateTime.Now.ToString() };
            p[8] = new SqlParameter("@exist", SqlDbType.Bit);
            p[8].Direction = ParameterDirection.Output;
            flag = Convert.ToBoolean(dbT.ExecuteTransStoreProcedureReturn("spPageTransferItems_Delete", p, true, "@exist"));
            if (flag == true)
            {
                dbT.RollBackTransaction();
                return flag;
            }

            dbT.EndTransaction();

            //}
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
 
  
    public class Department
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class Items
    {
        public string ID { get; set; }
        public string Item { get; set; }
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }
    }
    public class formData
    {
        public string TDate { get; set; }
        public string IsProv { get; set; }
        public string IsDept { get; set; }
        public string RProv { get; set; }
        public string Name { get; set; }
        public string RDept { get; set; }
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string TransferedBy { get; set; }
        public string Remarks { get; set; }
        public List<Items> Ilst { get; set; }
        public bool Edit { get; set; }
    }
    


}