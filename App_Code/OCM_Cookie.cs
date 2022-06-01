using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CBE_Cookie
/// </summary>
namespace OCM
{
    public class OCM_Cookie
    {

        public OCM_Cookie()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string SMS_SchoolID
        {
            get
            {
                HttpCookie SCookie = null;
                string schoolID = "";
                if (HttpContext.Current.Request.Cookies["SMSSchoolInfo"] != null)
                {
                    SCookie = HttpContext.Current.Request.Cookies["SMSSchoolInfo"];
                    schoolID = SCookie["SMSSchoolID"];
                }
                else
                    schoolID = "-1";
                return schoolID;
            }
            set
            {
                HttpCookie SCookie = new HttpCookie("SMSSchoolInfo");
                // CBECookie.Expires = DateTime.Now.AddDays(1);
                SCookie["SMSSchoolID"] = value;
                HttpContext.Current.Response.Cookies.Add(SCookie);
            }
        }
        public string SMS_ProvinceID
        {
            get
            {
                HttpCookie Pcokie = null;
                string ProvinceID = "";
                if (HttpContext.Current.Request.Cookies["SMSProvince"] != null)
                {
                    Pcokie = HttpContext.Current.Request.Cookies["SMSProvince"];
                    ProvinceID = Pcokie["SMSProvinceID"];
                }
                else
                    ProvinceID = "-1";
                return ProvinceID;
            }
            set
            {
                HttpCookie Pcokie = new HttpCookie("SMSProvince");
                //ProvinceCookie.Expires = DateTime.Now.AddDays(1);
                Pcokie["SMSProvinceID"] = value;
                HttpContext.Current.Response.Cookies.Add(Pcokie);
            }
        }
        public string SMS_DistrictID
        {
            get
            {
                HttpCookie DistrictCo = null;
                string DistrictID = "";
                if (HttpContext.Current.Request.Cookies["SMSDistrict"] != null)
                {
                    DistrictCo = HttpContext.Current.Request.Cookies["SMSDistrict"];
                    DistrictID = DistrictCo["SMSDistrictID"];
                }
                else
                    DistrictID = "-1";
                return DistrictID;
            }
            set
            {
                HttpCookie DistrictCo = new HttpCookie("SMSDistrict");
                //DistrictCookie.Expires = DateTime.Now.AddDays(1);
                DistrictCo["SMSDistrictID"] = value;
                HttpContext.Current.Response.Cookies.Add(DistrictCo);
            }
        }
        public string SMS_SchoolType
        {
            get
            {
                HttpCookie SchoolType = null;
                string SchoolTypeID = "";
                if (HttpContext.Current.Request.Cookies["SMSSchoolType"] != null)
                {
                    SchoolType = HttpContext.Current.Request.Cookies["SMSSchoolType"];
                    SchoolTypeID = SchoolType["SMSSchoolTypeID"];
                }
                else
                    SchoolTypeID = "1";
                return SchoolTypeID;
            }
            set
            {
                HttpCookie SchoolType = new HttpCookie("SMSSchoolType");              
                SchoolType["SMSSchoolTypeID"] = value;
                HttpContext.Current.Response.Cookies.Add(SchoolType);
            }
        }
        public string SMS_SchoolStage
        {
            get
            {
                HttpCookie SchoolStage = null;
                string schoolSatge = "";
                if (HttpContext.Current.Request.Cookies["SMSSchoolStage"] != null)
                {
                    SchoolStage = HttpContext.Current.Request.Cookies["SMSSchoolStage"];
                    schoolSatge = SchoolStage["SMSSchoolStageID"];
                }
                else
                    schoolSatge = "-1";
                return schoolSatge;
            }
            set
            {
                HttpCookie SchoolStage = new HttpCookie("SMSSchoolStage");
                SchoolStage["SMSSchoolStageID"] = value;
                HttpContext.Current.Response.Cookies.Add(SchoolStage);
            }
        }
        public string SMS_Year
        {
            get
            {
                HttpCookie Mcookie = null;
                string YearID = "";
                if (HttpContext.Current.Request.Cookies["Year"] != null)
                {
                    Mcookie = HttpContext.Current.Request.Cookies["Year"];
                    YearID = Mcookie["YearID"];
                }
                else
                    YearID = "1391";
                return YearID;
            }
            set
            {
                HttpCookie YearID = new HttpCookie("Year");
                // YearID.Expires = DateTime.Now.AddDays(1);
                YearID["YearID"] = value;
                HttpContext.Current.Response.Cookies.Add(YearID);
            }
        }
    }
}