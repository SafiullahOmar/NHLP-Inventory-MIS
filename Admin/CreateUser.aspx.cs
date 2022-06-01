using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OCM;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Admin_Default : System.Web.UI.Page
{
    OCM_DbGeneral db = new OCM_DbGeneral();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "fnOnUpdateValidators();");

        if (!IsPostBack)
        {
            fillDll();
        }
    }
    private void fillDll()
    {
        DropDownList ddlProvince = CreateUserWizardStep1.ContentTemplateContainer.FindControl("ddlLocation") as DropDownList;
        if (ddlProvince != null)
        {
            DataTable dt = db.SelectRecords(@"Select '-1' as ProvinceID,N'--Select--' as ProvinceEngName union SELECT [ProvinceID] ,[ProvinceEngName] FROM  [OCM_Province]");
            ddlProvince.DataSource = dt;
            ddlProvince.DataValueField = "ProvinceID";
            ddlProvince.DataTextField = "ProvinceEngName";
            ddlProvince.DataBind();
        }
        DropDownList ddlDepartment = CreateUserWizardStep1.ContentTemplateContainer.FindControl("ddlDepartment") as DropDownList;
        if (ddlDepartment != null)
        {
            DataTable dt = db.SelectRecords(@"Select '-1' as DeparmentID,N'--Select--' as Department union SELECT [DeparmentID] ,[Department] FROM  [tblINV_Department]");
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataValueField = "DeparmentID";
            ddlDepartment.DataTextField = "Department";
            ddlDepartment.DataBind();
        }
    }
    [System.Web.Services.WebMethod]
    public static string CheckAvailability(string userName)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["INVCon"].ConnectionString);
        string returnval = string.Empty;
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT     aspnet_Users.UserId, aspnet_Users.UserName, aspnet_Applications.ApplicationName
FROM         aspnet_Applications INNER JOIN
                      aspnet_Users ON aspnet_Applications.ApplicationId = aspnet_Users.ApplicationId
WHERE     (aspnet_Applications.ApplicationName = N'INV' and aspnet_Users.UserName=N'" + userName + "')", con);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                returnval = "true";
            else
                returnval = "false";
        }
        catch
        {
            returnval = "erorr";
        }
        return returnval;
    }
    [System.Web.Services.WebMethod]
    public static string CheckEmailAvailability(string email)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["INVCon"].ConnectionString);
        string returnval = string.Empty;
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM [aspnet_Membership] where [Email]='" + email + "'", con);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                returnval = "true";
            else
                returnval = "false";
        }
        catch
        {
            returnval = "erorr";
        }
        return returnval;
    } 
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {

        ProfileCommon p = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName);
        p.FullName = ((TextBox)(CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtFullName"))).Text;
        p.Age = ((TextBox)(CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtAge"))).Text;
        p.Designation = ((TextBox)(CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtDesignation"))).Text;
        
        p.Save();

        MembershipUser usr = Membership.GetUser(CreateUserWizard1.UserName);
        string UserID = usr.ProviderUserKey.ToString();
        db.ExecuteQuery("Update aspnet_Users set DepartmentId=" + ((DropDownList)(CreateUserWizardStep1.ContentTemplateContainer.FindControl("ddlDepartment"))).SelectedValue + " , OL=" + ((DropDownList)(CreateUserWizardStep1.ContentTemplateContainer.FindControl("ddlLocation"))).SelectedValue + " where UserId=N'" + UserID + "'");
    }
  
}