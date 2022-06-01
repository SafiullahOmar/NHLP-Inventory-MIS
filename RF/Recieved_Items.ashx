<%@ WebHandler Language="C#" Class="file" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Security;
using System.Data;
public class file : IHttpHandler
{

    public void ProcessRequest(HttpContext context) 
    {
        switch (context.Request["action"])
        {
            case "SAVE":
                Save(context);
                break;
            case "UPDATE":
                Update(context);
                break;
            case "SAVEFILE":
                SAVEFILE(context);
                break;
        }


    }
    public void Save(HttpContext context)
    {
        OCM.OCM_DbGeneral dbT = new OCM.OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            var LoopCount = context.Request["ItemsLoopCount"];
            var InspLoopCount = context.Request["InspLoopCount"];
            string query = "", InspQuery = "";
            
            //if (query.Length > 0 && InspQuery.Length > 0)
            //{
                
                SqlParameter[] p = new SqlParameter[13];
                p[0] = new SqlParameter("@GRVDate", SqlDbType.NVarChar) { Value = context.Request["RecieveDate"]??(object)DBNull.Value };
                p[1] = new SqlParameter("@Invoice", SqlDbType.NVarChar) { Value = context.Request["Invoice"] };
                p[2] = new SqlParameter("@Supplier", SqlDbType.NVarChar) { Value = context.Request["Supplier"] };
                p[3] = new SqlParameter("@Department", SqlDbType.Int) { Value = context.Request["Department"] };
                p[4] = new SqlParameter("@ProvinceID", SqlDbType.Int) { Value = context.Request["Province"] };

                p[5] = new SqlParameter("@PurchaseRef", SqlDbType.NVarChar) { Value = context.Request["PurchaseRef"] };
                p[6] = new SqlParameter("@StoreRecievedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                //p[7] = new SqlParameter("@InspectedBy", SqlDbType.NVarChar) { Value = formDetails.InspectedBy };

                p[7] = new SqlParameter("@InspectionDate", SqlDbType.NVarChar) { Value = context.Request["InspectionDate"] };
                p[8] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = context.Request["Remarks"] };
                //p[9] = new SqlParameter("@sql", SqlDbType.NVarChar) { Value = query };
                //p[10] = new SqlParameter("@InsSql", SqlDbType.NVarChar) { Value = InspQuery };
               
                p[9] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                p[10] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                p[11] = new SqlParameter("@ID", SqlDbType.BigInt);
                p[11].Direction = ParameterDirection.Output;
                p[12] = new SqlParameter("@SrR", SqlDbType.BigInt);
                p[12].Direction = ParameterDirection.Output;
                string[] outparm = new string[2];
                outparm[0] = "@ID";
                outparm[1] = "@SrR";
                string[] arr = new string[2];
                arr = dbT.ExecuteTransStoreProcedureReturnArray("spPageRecievingVoucher_Save", p, true, outparm);
                for (int i = 1; i <= Convert.ToInt16(LoopCount); i++)
                {

                    SqlParameter[] pRD = new SqlParameter[11];
                    pRD[0] = new SqlParameter("@SR", SqlDbType.Int) { Value = arr[1]};
                    pRD[1] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value =arr[0] };
                    pRD[2] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = context.Request["ItemID" + i] };
                    pRD[3] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = context.Request["Quantity" + i] };
                    pRD[4] = new SqlParameter("@INVQuantity", SqlDbType.Float) { Value = context.Request["InvoiceQuantity" + i] };
                    pRD[5] = new SqlParameter("@Price", SqlDbType.Float) { Value = context.Request["Price" + i] };
                    pRD[6] = new SqlParameter("@Modal", SqlDbType.NVarChar) { Value = context.Request["Modal" + i] };
                    pRD[7] = new SqlParameter("@Serail", SqlDbType.NVarChar) { Value = context.Request["Serial" + i] };
                    pRD[8] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = context.Request["ItemRemarks" + i] };
                    pRD[9] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    pRD[10] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    dbT.ExecuteTransStoreProcedure("spPageRecievingVoucher_SaveRecievingDParam", pRD, true);

                    pRD = new SqlParameter[8];
                    pRD[0] = new SqlParameter("@SR", SqlDbType.Int) { Value = arr[1] };
                    pRD[1] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = arr[0] };
                    pRD[2] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = context.Request["ItemID" + i] };
                    pRD[3] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = context.Request["Quantity" + i] };
                    pRD[4] = new SqlParameter("@ProvId", SqlDbType.Int) { Value = context.Request["Province"] };
                    pRD[5] = new SqlParameter("@UpdateType", SqlDbType.Char) { Value ="R" };
                    pRD[6] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    pRD[7] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = context.Request["RecieveDate"] };
                    dbT.ExecuteTransStoreProcedure("UpdateReconcileInfo", pRD, true);

                    //                query += @"  INSERT INTO [dbo].[tblINV_ReceivingVoucherDetail]([Sr],[IsDeleted],[GRVID] ,[ItemID] ,[Quantity] ,[InvoiceQuantity],[Price],[Modal],[Serial],[Remarks]  ,[InsertedBy] ,[InsertedDate])
                    //                                VALUES (*,0,tey,N''" + context.Request["ItemID" + i] + "''," + context.Request["Quantity" + i] + "," + context.Request["InvoiceQuantity" + i] + "," + context.Request["Price" + i] + ",N''" + context.Request["Modal" + i] + "'',N''" + context.Request["Serial" + i] + "'',N''" + context.Request["ItemRemarks" + i] + "'',''" + usr.ProviderUserKey.ToString() + "'',N''" + DateTime.Now.ToString() + "'')";

                }
                for (int i = 1; i <= Convert.ToInt16(InspLoopCount); i++)
                {
                    SqlParameter[] pID = new SqlParameter[4];
                    pID[0] = new SqlParameter("@SR", SqlDbType.Int) { Value = arr[1]};
                    pID[1] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = arr[0] };
                    pID[2] = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = context.Request["InspN" + i] };
                    pID[3] = new SqlParameter("@Position", SqlDbType.NVarChar) { Value = context.Request["Pos" + i] };
                    dbT.ExecuteTransStoreProcedure("spPageRecievingVoucher_SaveInspDParam", pID, true);

                    //InspQuery += @" INSERT INTO [dbo].[tblINV_ReceivingVoucherInspD] ([Sr],[IsDeleted],[GRVID],[InspName],[Position]) VALUES (*,0,tey,N''" + context.Request["InspN" + i] + "'',N''" + context.Request["Pos" + i] + "'')";

                }
                
                formData f = new formData();
                context.Response.Write(arr[0] + "," + arr[1]);
                dbT.EndTransaction();
                //if (context.Request.Files.Count > 0)
                //{
                //    HttpFileCollection files = context.Request.Files;
                //    for (int i = 0; i < files.Count; i++)
                //    {
                //        HttpPostedFile file = files[i];
                //        string fname;
                //        fname = ID + i + System.IO.Path.GetExtension(file.FileName).ToLower(); 
                //        fname = System.IO.Path.Combine(context.Server.MapPath("~/InspDocs/"), fname);
                //        System.Data.SqlClient.SqlParameter[] D = new SqlParameter[2];
                //        D[0] = new SqlParameter("@GRVID", System.Data.SqlDbType.BigInt) { Value = Convert.ToInt64(ID) };
                //        D[1] = new SqlParameter("@path", System.Data.SqlDbType.NVarChar) { Value = fname };
                //        dbT.ExecuteTransStoreProcedure("spPageRecievingVoucher_SaveDoc", D, true);
                //        file.SaveAs(fname);
                //    }
                //}

            //}

        }
        catch (Exception e)
        {
            dbT.RollBackTransaction();
            throw e.InnerException.InnerException;
        }
        finally
        {
            dbT.Connection.Close();
            SqlConnection.ClearPool(dbT.Connection);
        }
    }

    public void Update(HttpContext context)
    {
        OCM.OCM_DbGeneral dbT = new OCM.OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            var LoopCount = context.Request["ItemsLoopCount"];
            var InspLoopCount = context.Request["InspLoopCount"];
            string query = "", InspQuery = "";
           
           // if (query.Length > 0 && InspQuery.Length > 0)
            //{

                SqlParameter[] p = new SqlParameter[16];
                p[0] = new SqlParameter("@GRVDate", SqlDbType.NVarChar) { Value = context.Request["RecieveDate"] };
                p[1] = new SqlParameter("@Invoice", SqlDbType.NVarChar) { Value = context.Request["Invoice"] };
                p[2] = new SqlParameter("@Supplier", SqlDbType.NVarChar) { Value = context.Request["Supplier"] };
                p[3] = new SqlParameter("@Department", SqlDbType.Int) { Value = context.Request["Department"] };
                p[4] = new SqlParameter("@ProvinceID", SqlDbType.Int) { Value = context.Request["Province"] };

                p[5] = new SqlParameter("@PurchaseRef", SqlDbType.NVarChar) { Value = context.Request["PurchaseRef"] };
                p[6] = new SqlParameter("@StoreRecievedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                //p[7] = new SqlParameter("@InspectedBy", SqlDbType.NVarChar) { Value = formDetails.InspectedBy };

                p[7] = new SqlParameter("@InspectionDate", SqlDbType.NVarChar) { Value = context.Request["InspectionDate"] };
                p[8] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = context.Request["Remarks"] };
                //p[9] = new SqlParameter("@sql", SqlDbType.NVarChar) { Value = query };
                //p[10] = new SqlParameter("@InsSql", SqlDbType.NVarChar) { Value = InspQuery };
                p[9] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                p[10] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                p[11] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = context.Request["GRVID"] };
                p[12] = new SqlParameter("@Sr", SqlDbType.Int) { Value = context.Request["Sr"] };
                p[13] = new SqlParameter("@SerialNumber", SqlDbType.BigInt) { Value = context.Request["SerialNumber"] };
                p[14] = new SqlParameter("@ID", SqlDbType.BigInt);
                p[14].Direction = ParameterDirection.Output;
                p[15] = new SqlParameter("@SrRN", SqlDbType.Int);
                p[15].Direction = ParameterDirection.Output;
                string[] outparm = new string[2];
                outparm[0] = "@ID";
                outparm[1] = "@SrRN";
                string[] arr = new string[2];
                arr = dbT.ExecuteTransStoreProcedureReturnArray("spPageRecievingVoucher_Update", p, true, outparm);

                for (int i = 1; i <= Convert.ToInt16(LoopCount); i++)
                {
                    SqlParameter[] pRD = new SqlParameter[11];
                    pRD[0] = new SqlParameter("@SR", SqlDbType.Int) { Value = arr[1] };
                    pRD[1] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = arr[0] };
                    pRD[2] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = context.Request["ItemID" + i] };
                    pRD[3] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = context.Request["Quantity" + i] };
                    pRD[4] = new SqlParameter("@INVQuantity", SqlDbType.Float) { Value = context.Request["InvoiceQuantity" + i] };
                    pRD[5] = new SqlParameter("@Price", SqlDbType.Float) { Value = context.Request["Price" + i] };
                    pRD[6] = new SqlParameter("@Modal", SqlDbType.NVarChar) { Value = context.Request["Modal" + i] };
                    pRD[7] = new SqlParameter("@Serail", SqlDbType.NVarChar) { Value = context.Request["Serial" + i] };
                    pRD[8] = new SqlParameter("@Remarks", SqlDbType.NVarChar) { Value = context.Request["ItemRemarks" + i] };
                    pRD[9] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    pRD[10] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                    dbT.ExecuteTransStoreProcedure("spPageRecievingVoucher_SaveRecievingDParam", pRD, true);

                    pRD = new SqlParameter[8];
                    pRD[0] = new SqlParameter("@SR", SqlDbType.Int) { Value = arr[1] };
                    pRD[1] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = arr[0] };
                    pRD[2] = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = context.Request["ItemID" + i] };
                    pRD[3] = new SqlParameter("@Quantity", SqlDbType.Float) { Value = context.Request["Quantity" + i] };
                    pRD[4] = new SqlParameter("@ProvId", SqlDbType.Int) { Value = context.Request["Province"] };
                    pRD[5] = new SqlParameter("@UpdateType", SqlDbType.Char) { Value = "R" };
                    pRD[6] = new SqlParameter("@InsertedBy", SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(usr.ProviderUserKey.ToString()) };
                    pRD[7] = new SqlParameter("@InsertedDate", SqlDbType.NVarChar) { Value = context.Request["RecieveDate"] };
                    dbT.ExecuteTransStoreProcedure("UpdateReconcileInfo", pRD, true);
                    
//                    query += @"  INSERT INTO [dbo].[tblINV_ReceivingVoucherDetail]([Sr],[IsDeleted],[GRVID] ,[ItemID] ,[Quantity] ,[InvoiceQuantity],[Price],[Modal],[Serial],[Remarks]  ,[InsertedBy] ,[InsertedDate])
//                                VALUES (*,0,tey,N' + CHAR(39) + '" + context.Request["ItemID" + i] + "' + CHAR(39) + '," + context.Request["Quantity" + i] + "," + context.Request["InvoiceQuantity" + i] + "," + context.Request["Price" + i] + ",N' + CHAR(39) + '" + context.Request["Modal" + i] + "' + CHAR(39) + ',N' + CHAR(39) + '" + context.Request["Serial" + i] + "' + CHAR(39) + ',N' + CHAR(39) + '" + context.Request["ItemRemarks" + i] + "' + CHAR(39) + ',' + CHAR(39) + '" + usr.ProviderUserKey.ToString() + "' + CHAR(39) + ',N' + CHAR(39) + '" + DateTime.Now.ToString() + "' + CHAR(39) + ')";

                }
                for (int i = 1; i <= Convert.ToInt16(InspLoopCount); i++)
                {
                    SqlParameter[] pID = new SqlParameter[4];
                    pID[0] = new SqlParameter("@SR", SqlDbType.Int) { Value = arr[1] };
                    pID[1] = new SqlParameter("@GRVID", SqlDbType.BigInt) { Value = arr[0] };
                    pID[2] = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = context.Request["InspN" + i] };
                    pID[3] = new SqlParameter("@Position", SqlDbType.NVarChar) { Value = context.Request["Pos" + i] };
                    dbT.ExecuteTransStoreProcedure("spPageRecievingVoucher_SaveInspDParam", pID, true);
                    
                    //InspQuery += @" INSERT INTO [dbo].[tblINV_ReceivingVoucherInspD] ([Sr],[IsDeleted],[GRVID],[InspName],[Position]) VALUES (*,0,tey,N' + CHAR(39) + '" + context.Request["InspN" + i] + "' + CHAR(39) + ',N' + CHAR(39) + '" + context.Request["Pos" + i] + "' + CHAR(39) + ')";

                }
            
                //if (context.Request.Files.Count > 0)
                //{
                //    HttpFileCollection files = context.Request.Files;
                //    for (int i = 0; i < files.Count; i++)
                //    {
                //        HttpPostedFile file = files[i];
                //        string fname;
                //        fname = ID + "U" + i + System.IO.Path.GetExtension(file.FileName).ToLower(); ;
                //        fname = System.IO.Path.Combine(context.Server.MapPath("~/InspDocs/"), fname);
                //        System.Data.SqlClient.SqlParameter[] D = new SqlParameter[2];
                //        D[0] = new SqlParameter("@GRVID", System.Data.SqlDbType.BigInt) { Value = Convert.ToInt64(ID) };
                //        D[1] = new SqlParameter("@path", System.Data.SqlDbType.NVarChar) { Value = fname };
                //        dbT.ExecuteTransStoreProcedure("spPageRecievingVoucher_SaveDoc", D, true);
                //        file.SaveAs(fname);


                //    }
                //}
            
                dbT.EndTransaction();
           // }

        }
        catch (Exception e)
        {
            dbT.RollBackTransaction();
            throw e.InnerException.InnerException;
        }
        finally
        {
            dbT.Connection.Close();
            SqlConnection.ClearPool(dbT.Connection);
        }
    }


    public void SAVEFILE(HttpContext context)
    {
        OCM.OCM_DbGeneral dbT = new OCM.OCM_DbGeneral();
        try
        {

            dbT.BeginTransaction();
            bool flag = false;
            MembershipUser usr = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string[] arr = context.Request["GRVID"].Split('/');
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 1; i <=files.Count; i++)
                {
                    HttpPostedFile file = files[i-1];
                    string fname;
                    fname = arr[0]+"-" + i + System.IO.Path.GetExtension(file.FileName).ToLower();
                    fname = System.IO.Path.Combine(context.Server.MapPath("~/InspDocs/"), fname);
                    System.Data.SqlClient.SqlParameter[] D = new SqlParameter[3];
                    D[0] = new SqlParameter("@GRVID", System.Data.SqlDbType.BigInt) { Value = Convert.ToInt64(arr[0]) };
                    D[1] = new SqlParameter("@path", System.Data.SqlDbType.NVarChar) { Value = fname };
                    D[2] = new SqlParameter("@exists", System.Data.SqlDbType.Bit);
                    D[2].Direction = ParameterDirection.Output;
                    flag = Convert.ToBoolean(dbT.ExecuteTransStoreProcedureReturn("spPageRecievingVoucher_SaveDoc", D, true, "@exists"));
                    if (!flag && i == 1)
                        file.SaveAs(fname);
                    else if (i > 1 && flag==false)
                        file.SaveAs(fname);
                }
            }

            dbT.EndTransaction();
            context.Response.Write(flag);
        }
        catch (Exception e)
        {
            dbT.RollBackTransaction();
            throw e.InnerException.InnerException;
        }
        finally
        {
            dbT.Connection.Close();
            SqlConnection.ClearPool(dbT.Connection);
        }
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
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
        public System.Collections.Generic.List<Goods> ItemsList { get; set; }
        public string TotalItems { get; set; }
        public string TotalCost { get; set; }
        public string Sr { get; set; }
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

}