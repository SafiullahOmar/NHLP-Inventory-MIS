using Microsoft.Reporting.WebForms;
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
    public static List<Items> GetRecievedItems(string SubClassID)
    {
        List<Items> lst = new List<Items>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageRecievingVoucher_ItemList";
        com.Parameters.AddWithValue("@SubClassID", SqlDbType.VarChar).Value = SubClassID;
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
    public static List<ProductSUBCategory> GetSubClass(string ClassID)
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

            if (formDetails.ItemsList.Count > 0)
            {
                string query = "";
                foreach (Goods itm in formDetails.ItemsList)
                {
                    query += @"  INSERT INTO [dbo].[tblINV_ReceivingVoucherDetail]([Sr],[IsDeleted],[GRVID] ,[ItemID] ,[Quantity] ,[InvoiceQuantity],[Price],[Modal],[Serial],[Remarks]  ,[InsertedBy] ,[InsertedDate])
                                VALUES (*,0,tey,N'" + itm.ItemID + "'," + itm.Quantity + "," + itm.InvoiceQuantity + "," + itm.Price + ",N'" + itm.Modal + "',N'" + itm.Serial + "',N'" + itm.ItemRemarks + "','" + usr.ProviderUserKey.ToString() + "',N'" + DateTime.Now.ToString() + "')";

                }
                if (query.Length > 0)
                {
                    SqlParameter[] p = new SqlParameter[13];
                    p[0] = new SqlParameter("@GRVDate", SqlDbType.NVarChar) { Value = formDetails.RecieveDate };
                    p[1] = new SqlParameter("@Invoice", SqlDbType.NVarChar) { Value = formDetails.Invoice };
                    p[2] = new SqlParameter("@Supplier", SqlDbType.NVarChar) { Value = formDetails.Supplier };
                    p[3] = new SqlParameter("@Department", SqlDbType.Int) { Value = formDetails.Department };
                    p[4] = new SqlParameter("@ProvinceID", SqlDbType.Int) { Value = formDetails.Province };

                    p[5] = new SqlParameter("@PurchaseRef", SqlDbType.NVarChar) { Value = formDetails.PurchaseRef };
                    p[6] = new SqlParameter("@StoreRecievedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[7] = new SqlParameter("@InspectedBy", SqlDbType.NVarChar) { Value = formDetails.InspectedBy };

                    p[8] = new SqlParameter("@InspectionDate", SqlDbType.NVarChar) { Value = formDetails.InspectionDate };
                    p[9] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = formDetails.Remarks };
                    p[10] = new SqlParameter("@sql", SqlDbType.NVarChar) { Value = query };

                    p[11] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[12] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    dbT.ExecuteTransStoreProcedure("spPageRecievingVoucher_Save", p, true);
                    dbT.EndTransaction();
                }
            }
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
    public static List<formData> GetReceivingVoucherList()
    {
        List<formData> lst = new List<formData>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageRecievingVoucher_List";
        int Cond = HttpContext.Current.User.IsInRole("Super User") == true ? 0 : 1;
        com.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString());
        com.Parameters.AddWithValue("@Cond", SqlDbType.Int).Value = Cond;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            formData p = new formData();
            p.Invoice = dr["Invoice"].ToString();
            p.Supplier = dr["Supplier"].ToString();
            p.Department = dr["Department"].ToString();
            p.Province = dr["ProvinceEngName"].ToString();
            p.RecieveDate = dr["GRVDate"].ToString();
            p.TotalItems = dr["TotalItems"].ToString();
            p.TotalCost = dr["TotalPrice"].ToString();
            p.GRVID = dr["GRVID"].ToString();
            p.Sr = dr["Sr"].ToString();
            p.Edit = HttpContext.Current.User.IsInRole("Super User") == true ? true : false;
            lst.Add(p);
        }
        dr.Close();
        con.Close();
        return lst;
    }
    [WebMethod]
    public static formData GetRVDetailByID(string GRVID, string Sr)
    {
        formData p = new formData();
        List<Goods> lst = new List<Goods>();
        List<Inspectors> Insplst = new List<Inspectors>();
        string constr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["INVCon"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = con.CreateCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "spPageRevievedVoucher_Edit";
        com.Parameters.AddWithValue("@GRVID", SqlDbType.BigInt).Value = GRVID;
        com.Parameters.AddWithValue("@Sr", SqlDbType.Int).Value = Sr;
        com.Parameters.AddWithValue("@IsExistInBrcd", SqlDbType.Int);
        com.Parameters["@IsExistInBrcd"].Direction = ParameterDirection.Output;
        con.Open();
        using (SqlDataReader dr = com.ExecuteReader())
        {
            int count = 1;
            while (dr.Read())
            {
                Goods G = new Goods();
                G.ExpireDate = dr["ExpirationDate"].ToString();
                G.InvoiceQuantity = dr["InvoiceQuantity"].ToString();
                G.ItemID = dr["ItemID"].ToString();
                G.Modal = dr["Modal"].ToString();
                G.Price = dr["Price"].ToString();
                G.Quantity = dr["Quantity"].ToString();
                G.Serial = dr["Serial"].ToString();
                G.Warrenty = dr["Warrenty"].ToString();
                G.ItemName = dr["Name"].ToString();
                lst.Add(G);
                if (count == 1)
                {
                    p.Invoice = dr["Invoice"].ToString();
                    p.Department = dr["DepartmentID"].ToString();
                    p.Province = dr["ProvinceID"].ToString();
                    // p.InspectedBy = dr["InspecetedBy"].ToString();
                    p.InspectionDate = dr["InspectionDate"].ToString();

                    p.PurchaseRef = dr["PurchaseRef"].ToString();
                    p.RecieveDate = dr["GRVDate"].ToString();
                    p.Remarks = dr["Remarks"].ToString();
                    p.Supplier = dr["Supplier"].ToString();
                    p.SerialNumber = dr["SerialNo"].ToString();
                }
                count++;
            }
            int ResultCount = 0;
            while (dr.NextResult())
            {
                if (ResultCount == 0)
                {
                    while (dr.Read())
                    {
                        Inspectors inspectors = new Inspectors();
                        inspectors.Name = dr["InspName"].ToString();
                        inspectors.Position = dr["Position"].ToString();
                        Insplst.Add(inspectors);

                    }
                    ResultCount++;
                }
                //else if (ResultCount == 1)
                //{
                //    while (dr.Read())
                //    {
                //        p.Path = dr["path"].ToString();
                //        ResultCount++;
                //    }
                //}
            }
        }

        p.ItemsList = lst;
        p.InspectosList = Insplst;
        
       // p.IsExisInBrcd = Convert.ToBoolean(com.Parameters["@IsExistInBrcd"].Value.ToString());
        con.Close();
        return p;
    }
    [WebMethod]
    public static void UpdateFormDetail(formData formDetails)
    {
        OCM_DbGeneral dbT = new OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);

            if (formDetails.ItemsList.Count > 0)
            {
                string query = "";
                foreach (Goods itm in formDetails.ItemsList)
                {
                    query += @"  INSERT INTO [dbo].[tblINV_ReceivingVoucherDetail]([Sr],[IsDeleted],[GRVID] ,[ItemID] ,[Quantity] ,[InvoiceQuantity],[Price],[Modal],[Serial]  ,[InsertedBy] ,[InsertedDate])
                                VALUES (*,0,tey,N'" + itm.ItemID + "'," + itm.Quantity + "," + itm.InvoiceQuantity + "," + itm.Price + ",N'" + itm.Modal + "',N'" + itm.Serial + "','" + usr.ProviderUserKey.ToString() + "',N'" + DateTime.Now.ToString() + "')";
                }
                if (query.Length > 0)
                {
                    SqlParameter[] p = new SqlParameter[15];
                    p[0] = new SqlParameter("@GRVDate", SqlDbType.NVarChar) { Value = formDetails.RecieveDate };
                    p[1] = new SqlParameter("@Invoice", SqlDbType.NVarChar) { Value = formDetails.Invoice };
                    p[2] = new SqlParameter("@Supplier", SqlDbType.NVarChar) { Value = formDetails.Supplier };
                    p[3] = new SqlParameter("@Department", SqlDbType.Int) { Value = formDetails.Department };
                    p[4] = new SqlParameter("@ProvinceID", SqlDbType.Int) { Value = formDetails.Province };

                    p[5] = new SqlParameter("@PurchaseRef", SqlDbType.NVarChar) { Value = formDetails.PurchaseRef };
                    p[6] = new SqlParameter("@StoreRecievedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[7] = new SqlParameter("@InspectedBy", SqlDbType.NVarChar) { Value = formDetails.InspectedBy };

                    p[8] = new SqlParameter("@InspectionDate", SqlDbType.NVarChar) { Value = formDetails.InspectionDate };
                    p[9] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = formDetails.Remarks };
                    p[10] = new SqlParameter("@sql", SqlDbType.NVarChar) { Value = query };

                    p[11] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    p[12] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    p[13] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = formDetails.GRVID };
                    p[14] = new SqlParameter("@Sr", SqlDbType.Int) { Value = formDetails.Sr };
                    dbT.ExecuteTransStoreProcedure("spPageRecievingVoucher_Update", p, true);
                    dbT.EndTransaction();
                }
            }
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
    public class ProductSUBCategory
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string ClassID { get; set; }
    }
    public class ItemClass
    {
        public string ID { get; set; }
        public string Name { get; set; }
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
    }

    public class formData
    {
        public string GRVID { get; set; }
        public string RecieveDate { get; set; }
        public string Province { get; set; }
        public string Department { get; set; }
        public string Invoice { get; set; }
        public string PurchaseRef { get; set; }
        public string Supplier { get; set; }
        public string InspectedBy { get; set; }
        public string InspectionDate { get; set; }
        public string Remarks { get; set; }
        public List<Goods> ItemsList { get; set; }
        public List<Inspectors> InspectosList { get; set; }
        public string TotalItems { get; set; }
        public string TotalCost { get; set; }
        public string Sr { get; set; }
        public string Path { get; set; }
        public string SerialNumber { get; set; }
        public bool IsExisInBrcd { get; set; }
        public bool Edit { get; set; }
    }
    public class Goods
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string InvoiceQuantity { get; set; }
        public string Modal { get; set; }
        public string Serial { get; set; }
        public string ExpireDate { get; set; }
        public string Warrenty { get; set; }
        public string Price { get; set; }
        public string ItemRemarks { get; set; }
    }
    public class Inspectors
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }


}