<%@ WebHandler Language="C#" Class="file" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public class file : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        switch (context.Request["action"])
        {
            case "SAVE":
                SaveData(context);
                break;
        }
    }
    public void SaveData(HttpContext context)
    {
        OCM.OCM_DbGeneral db = new OCM.OCM_DbGeneral();
        try
        {

            db.BeginTransaction();
            string ID = "";
            string query = "";
            var LoopCount = context.Request["LoopCount"];
            for (int i = 1; i <= Convert.ToInt16(LoopCount); i++)
            {
                query += @"  INSERT INTO [dbo].[tblINV_ItemsReqD]([R_Id],[ItemID],[Quantity],[Remarks],[Date]) 
                                VALUES (tey,N'" + context.Request["item" + i] + "'," + context.Request["rQ" + i] + ",N'" + (context.Request["Remarks" + i].Length == 0 ? "" : context.Request["Remarks" + i]) + "',N'" + DateTime.Now.ToString() + "')";

            }
            if (query.Length > 0)
            {
                System.Data.SqlClient.SqlParameter[] p = new SqlParameter[10];
                p[0] = new SqlParameter("@Name", System.Data.SqlDbType.NVarChar) { Value = context.Request["Name"] };
                p[1] = new SqlParameter("@Position", System.Data.SqlDbType.NVarChar) { Value = context.Request["Position"] };
                p[2] = new SqlParameter("@Province", System.Data.SqlDbType.Int) { Value = context.Request["Province"] };
                p[3] = new SqlParameter("@SDP", System.Data.SqlDbType.Int) { Value = context.Request["SubDepartment"] };
                p[4] = new SqlParameter("@SP", System.Data.SqlDbType.UniqueIdentifier) { Value = new System.Data.SqlTypes.SqlGuid(context.Request["Supervisor"]) };
                p[5] = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar) { Value = context.Request["LoopCount"].Length == 0 ? "" : context.Request["Email"] };
                p[6] = new SqlParameter("@Date", System.Data.SqlDbType.NVarChar) { Value = DateTime.Now.ToString() };
                p[7] = new SqlParameter("@sql", System.Data.SqlDbType.NVarChar) { Value = query };
                p[8] = new SqlParameter("@ReqType", System.Data.SqlDbType.Int) { Value = 3 };
                p[9] = new SqlParameter("@RID", System.Data.SqlDbType.BigInt);
                p[9].Direction = System.Data.ParameterDirection.Output;
                ID = db.ExecuteTransStoreProcedureReturn("spPageReq_Save", p, true, "@RID");

                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string fname;
                        fname = ID + i + System.IO.Path.GetExtension(file.FileName).ToLower(); ;
                        fname = System.IO.Path.Combine(context.Server.MapPath("~/RDocs/"), fname);
                        System.Data.SqlClient.SqlParameter[] D = new SqlParameter[2];
                        D[0] = new SqlParameter("@ReqId", System.Data.SqlDbType.BigInt) { Value = ID };
                        D[1] = new SqlParameter("@path", System.Data.SqlDbType.NVarChar) { Value = fname };
                        db.ExecuteTransStoreProcedure("spPageReq_SaveInvDoc", D, true);                        
                        file.SaveAs(fname);
                    }
                }


                // string strExtension = System.IO.Path.GetExtension(context.Request.Files["Image"].FileName).ToLower();
                // StudentIPath = "../Docs/" + ID + strExtension;
                // string strSaveLocation = context.Server.MapPath(StudentIPath);
                // file.SaveAs(strSaveLocation);

                db.EndTransaction();
                context.Response.Write(ID);
            }



            // System.Web.Script.Serialization.JavaScriptSerializer json=new System.Web.Script.Serialization.JavaScriptSerializer();
            //System.Collections.Generic.List<ItemDetails> lst =(System.Collections.Generic.List<ItemDetails>) json.Deserialize(k, typeof(System.Collections.Generic.List<ItemDetails>));

            //string strExtension = System.IO.Path.GetExtension(context.Request.Files["stdImage"].FileName).ToLower();
            //StudentIPath = "../StudentImages/" + 12 + strExtension;
            //string strSaveLocation = context.Server.MapPath(StudentIPath);
            //file.SaveAs(strSaveLocation);

            //OCM.OCM_DbGeneral db = new OCM.OCM_DbGeneral();

            //string[] p = { "@Name", "@FatherName", "@FamilyName", "@ENDate", "@DOB", "@Gender", "@Nationlity", "@TazkiraNo", "@CProvince", "@PProvince", "@Religion", "@Email", "@ContactNo", "@RegNo", "@BatchNo", "@AcademicYear", "@Program", "@Semester", "@Section", "@Path", "@Exist" };
            //string[] v = { context.Request["Name"], context.Request["FatherName"], context.Request["FamilyName"], context.Request["EDate"], context.Request["DOB"], context.Request["Gender"], context.Request["Nationality"], context.Request["Tazkira"], context.Request["CProvince"], context.Request["PProvince"], context.Request["Religion"], context.Request["Email"], context.Request["ContactNo"], context.Request["RegNo"], context.Request["Batch"], context.Request["AYear"], context.Request["Program"], context.Request["Semester"], context.Request["Section"], StudentIPath };

        }
        catch (Exception)
        {
            db.RollBackTransaction();
            throw;
        }
        finally
        {
            db.Connection.Close();
            SqlConnection.ClearPool(db.Connection);
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
        public string Name { get; set; }
        public string Position { get; set; }
        public string Province { get; set; }
        public string Department { get; set; }
        public string Supervisor { get; set; }
        public string Email { get; set; }
        public System.Collections.Generic.List<ItemDetails> lst { get; set; }
    }
    public class ItemDetails
    {
        public string Item { get; set; }
        public string ReqQuantity { get; set; }
        public string Remarks { get; set; }
    }

}