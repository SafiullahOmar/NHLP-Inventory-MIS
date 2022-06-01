using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
namespace OCM
{
    /// <summary>
    /// Summary description for SMS_Validation
    /// </summary>
    public class OCM_Validation
    {
        public OCM_Validation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Add Digit validations to the TextBox
        /// </summary>
        /// <param name="txt">TextBox ID</param>
        public static void AddNumberValidate(TextBox txt)
        {

            txt.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) || (event.keyCode == 190) || (event.keyCode == 110) ){return true;}else{return false;}");

        }
        public static void AddNullValidate(TextBox txt)
        {

            txt.Attributes.Add("onKeyDown", "return false;");

        }
        public static void AddBoundryValidation(TextBox txt, int boundry)
        {

            StringBuilder sb=new StringBuilder();
            sb.Append("function ValidateBoundry() {");
            sb.Append(" var txt1 = document.getElementById('"+txt.ClientID+"');");
            sb.Append(" var b = 0;");
            sb.Append(" if (txt1.value != \"\")   b = parseInt(txt1.value);   var bo = parseInt("+boundry+");");
            sb.Append(" if (b > bo)   txt1.value = bo;}");
            txt.Attributes.Add("onchange",sb.ToString());
        }
        public static  string formate(TextBox txt, SqlDbType tp)
        {
            string v = "";
            if (tp == SqlDbType.Int)
                v = (txt.Text.Trim() == "") ? "NULL" : "'" + txt.Text + "'";
            else if (tp == SqlDbType.VarChar)
                v = (txt.Text.Trim() == "") ? "NULL" : "'" + txt.Text + "'";
            else if (tp == SqlDbType.NVarChar)
                v = (txt.Text.Trim() == "") ? "NULL" : "N'" + txt.Text + "'";
            return v;
        }
    }
}