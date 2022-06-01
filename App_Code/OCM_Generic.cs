using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using Telerik.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace OCM
{
    /// <summary>
    /// Summary description for Generic.
    /// </summary>
    public class OCM_Generic
    {
        public DataTable objDTable;

        public OCM_Generic()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void Message(Panel Sourcepnl, MESSAGE_TYPE MessageType, string message)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            if (MessageType == MESSAGE_TYPE.FAILURE)
            {
                div.Attributes.Add("class", "notification failure hideit");
                div.InnerHtml = "<p><strong>" + message + "</strong> </p>";
            }
            else if (MessageType == MESSAGE_TYPE.INFORMATION)
            {
                div.Attributes.Add("class", "notification information hideit");
                div.InnerHtml = "<p><strong>" + message + "</strong> </p>";
            }
            else if (MessageType == MESSAGE_TYPE.SUCCESS)
            {
                div.Attributes.Add("class", "notification success hideit");
                div.InnerHtml = "<p><strong>" + message + "</strong> </p>";
            }
            else if (MessageType == MESSAGE_TYPE.WARNING)
            {
                div.Attributes.Add("class", "notification warning hideit");
                div.InnerHtml = "<p><strong> " + message + "</strong></p>";
            }
            Sourcepnl.Controls.Add(div);
        }
        /// <summary>
        /// ConvertToFirstUCase: Converts the first character to uppercase and all others to lowercase letters.
        /// </summary>
        /// <param name="string"></param>

        public static void deleteSpecificFileFromComputer(string fileVirtualPath)
        {
            string filePhysicalPath = System.Web.HttpContext.Current.Server.MapPath(fileVirtualPath);
            System.IO.File.Delete(filePhysicalPath);
        }

        #region function to convert a datareader in a pivot table
        public static DataTable Pivot(IDataReader dataValues, string keyColumn, string pivotNameColumn, string pivotValueColumn)
        {

            DataTable tmp = new DataTable();

            DataRow r;

            string LastKey = "//dummy//";

            int i, pValIndex, pNameIndex;

            string s;

            bool FirstRow = true;



            // Add non-pivot columns to the data table:



            pValIndex = dataValues.GetOrdinal(pivotValueColumn);

            pNameIndex = dataValues.GetOrdinal(pivotNameColumn);



            for (i = 0; i <= dataValues.FieldCount - 1; i++)

                if (i != pValIndex && i != pNameIndex)

                    tmp.Columns.Add(dataValues.GetName(i), dataValues.GetFieldType(i));



            r = tmp.NewRow();



            // now, fill up the table with the data:

            while (dataValues.Read())
            {

                // see if we need to start a new row

                if (dataValues[keyColumn].ToString() != LastKey)
                {

                    // if this isn't the very first row, we need to add the last one to the table

                    if (!FirstRow)

                        tmp.Rows.Add(r);

                    r = tmp.NewRow();

                    FirstRow = false;

                    // Add all non-pivot column values to the new row:

                    for (i = 0; i <= dataValues.FieldCount - 3; i++)

                        r[i] = dataValues[tmp.Columns[i].ColumnName];

                    LastKey = dataValues[keyColumn].ToString();

                }

                // assign the pivot values to the proper column; add new columns if needed:

                s = dataValues[pNameIndex].ToString();

                if (!tmp.Columns.Contains(s))

                    tmp.Columns.Add(s, dataValues.GetFieldType(pValIndex));

                r[s] = dataValues[pValIndex];

            }



            // add that final row to the datatable:

            tmp.Rows.Add(r);


            // Close the DataReader

            dataValues.Close();


            // and that's it!

            return tmp;

        }
        #endregion
        public static void clearCache()
        {
            System.Web.HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            System.Web.HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            System.Web.HttpContext.Current.Response.Cache.SetNoStore();
            System.Web.HttpContext.Current.Response.AddHeader("Pragma", "no-cache");

        }

        public string ConvertToProper(string A)
        {
            string first = A.Substring(0, 1);
            first = first.ToUpper();
            string second = A.Substring(1, A.Length - 1);
            second = second.ToLower();
            return first + second;
        }
        /// <summary>
        /// Enable controls
        /// </summary>
        /// <param name="ctl"></param>
        public void EnableControls(System.Web.UI.Control ctl)
        {
            //int noOfControls = this.Page.Controls.Count;


            foreach (System.Web.UI.Control pagecont in ctl.Controls)
            {
                if (pagecont.HasControls())
                {
                    EnableControls(pagecont);
                }
                else
                {

                    if (pagecont is TextBox)
                    {

                        ((TextBox)pagecont).ReadOnly = false;
                        ((TextBox)pagecont).Enabled = true;
                        ((TextBox)pagecont).CssClass = "EnabelTextBox";
                        //  ((TextBox)pagecont).EnableTheming = true;
                        ((TextBox)pagecont).EnableViewState = true;
                        ((TextBox)pagecont).BorderColor = System.Drawing.Color.FromArgb(152, 171, 191);
                        ((TextBox)pagecont).BackColor = System.Drawing.Color.White;
                        //  ((TextBox)pagecont).BorderStyle = BorderStyle.NotSet;
                        // ((TextBox)pagecont).BorderWidth = 1; 
                        // ((TextBox)pagecont).TextMode = "textboxdisabled";


                    }
                    //else if (pagecont is CheckBox)
                    //{
                    //    ((CheckBox)pagecont).Enabled = true;
                    //    ((CheckBox)pagecont).CssClass = "Checkbox";
                    //    ((CheckBox)pagecont).BorderColor = System.Drawing.Color.Transparent;
                    //    ((CheckBox)pagecont).BackColor = System.Drawing.Color.Transparent;
                    //    ((CheckBox)pagecont).BorderStyle = BorderStyle.NotSet;
                    //}
                    //else if (pagecont is DropDownList)
                    //{
                    //    ((DropDownList)pagecont).CssClass = "TextBox";
                    //    ((DropDownList)pagecont).Enabled = true;
                    //   // ((DropDownList)pagecont).BorderColor = Color.Transparent;
                    //    ((DropDownList)pagecont).BackColor = System.Drawing.Color.White;
                    //    ((DropDownList)pagecont).BorderStyle = BorderStyle.NotSet;

                    //}

                    //else if (pagecont is RadioButton)
                    //{

                    //    ((RadioButton)pagecont).Enabled = true;
                    //    ((RadioButton)pagecont).BorderColor = System.Drawing.Color.Transparent;
                    //    ((RadioButton)pagecont).BackColor = System.Drawing.Color.Transparent;
                    //    ((RadioButton)pagecont).BorderStyle = BorderStyle.NotSet;
                    //}
                    ////					else if(pagecont is RadGrid)
                    ////					{
                    ////						((RadGrid)pagecont).Enabled=true;
                    ////						((RadGrid)pagecont).BorderColor=Color.Transparent;
                    ////						((RadGrid)pagecont).BackColor=Color.Transparent;
                    ////						((RadGrid)pagecont).BorderStyle=BorderStyle.NotSet;
                    ////
                    ////					}
                    //else if (pagecont is Button)
                    //{
                    //    ((Button)pagecont).Visible = true;
                    //}
                    //else if (pagecont is RequiredFieldValidator)
                    //{
                    //    ((RequiredFieldValidator)pagecont).EnableClientScript = true;
                    //}
                    //else if (pagecont is RegularExpressionValidator)
                    //{
                    //    ((RegularExpressionValidator)pagecont).EnableClientScript = true;
                    //}
                    //else if (pagecont is CompareValidator)
                    //{
                    //    ((CompareValidator)pagecont).EnableClientScript = true;
                    //}
                    //else if (pagecont is HtmlImage)
                    //{
                    //    ((HtmlImage)pagecont).Visible = true;

                    //}
                    //else if (pagecont is HtmlInputButton)
                    //{
                    //    ((HtmlInputButton)pagecont).Visible = true;

                    //}
                    ////else if(pagecont is RadDatePicker)
                    ////{
                    ////    ((RadDatePicker)pagecont).Visible=true;

                    ////}
                    //else if (pagecont is RadioButtonList)
                    //{
                    //    ((RadioButtonList)pagecont).Enabled = true;

                    //}

                }
            }

        }


        /// <summary>
        /// Disable controls
        /// </summary>
        /// <param name="ctl"></param>
      


        public static void DisableControls(System.Web.UI.Control ctl)
        {
            foreach (System.Web.UI.Control pagecont in ctl.Controls)
            {
                if (pagecont is TextBox)
                {
                    ((TextBox)pagecont).ReadOnly = true;


                    ((TextBox)pagecont).CssClass = "disabledProperty";
                }
                else if (pagecont is CheckBox)
                {
                    ((CheckBox)pagecont).Enabled = false;
                    ((CheckBox)pagecont).BorderColor = System.Drawing.Color.Transparent;
                    ((CheckBox)pagecont).BackColor = System.Drawing.Color.Transparent;
                    ((CheckBox)pagecont).BorderStyle = BorderStyle.None;
                    ((CheckBox)pagecont).CssClass = "disableCheckBox";//"TextBox";
                }
                else if (pagecont is CheckBoxList)
                {
                    ((CheckBoxList)pagecont).Enabled = false;
                    ((CheckBoxList)pagecont).BorderColor = System.Drawing.Color.Transparent;
                    ((CheckBoxList)pagecont).BackColor = System.Drawing.Color.Transparent;
                    ((CheckBoxList)pagecont).BorderStyle = BorderStyle.None;
                    ((CheckBoxList)pagecont).CssClass = "disableCheckBox";//"TextBox";
                }
                else if (pagecont is RadioButtonList)
                {
                    ((RadioButtonList)pagecont).Enabled = false;
                    ((RadioButtonList)pagecont).BorderColor = System.Drawing.Color.Transparent;
                    ((RadioButtonList)pagecont).BackColor = System.Drawing.Color.Transparent;
                    ((RadioButtonList)pagecont).BorderStyle = BorderStyle.None;
                }

                else if (pagecont is FileUpload)
                {
                    ((FileUpload)pagecont).Enabled = false;
                }
                else if (pagecont is Button)
                    ((Button)pagecont).Enabled = false;
                else if (pagecont is LinkButton)
                    ((LinkButton)pagecont).Enabled = false;
                if (pagecont.HasControls())
                {
                    DisableControls(pagecont);
                }
            }

        }

        public void enableControls_all(System.Web.UI.Control ctl)
        {
            foreach (System.Web.UI.Control pagecont in ctl.Controls)
            {
                if (pagecont is TextBox)
                {
                    ((TextBox)pagecont).ReadOnly = false;
                    ((TextBox)pagecont).Enabled = true;
                    ((TextBox)pagecont).CssClass = "cssForSamSkin_TextBox";
                }
                else if (pagecont is CheckBox)
                {
                    ((CheckBox)pagecont).Enabled = true;
                    ((CheckBox)pagecont).CssClass = "cssForSamSkin_CheckBox";
                }
                else if (pagecont is CheckBoxList)
                {
                    ((CheckBoxList)pagecont).Enabled = true;
                    ((CheckBoxList)pagecont).CssClass = "cssForSamSkin_CheckBox";
                }

                else if (pagecont is RadioButtonList)
                {

                    ((RadioButtonList)pagecont).Enabled = true;
                    ((RadioButtonList)pagecont).BorderColor = System.Drawing.Color.Transparent;
                    ((RadioButtonList)pagecont).BackColor = System.Drawing.Color.Transparent;
                    ((RadioButtonList)pagecont).BorderStyle = BorderStyle.NotSet;
                }
                //else if (pagecont is Telerik.WebControls.RadComboBox)
                //{
                //    ((Telerik.WebControls.RadComboBox)pagecont).Enabled = true;
                //}
                //else if (pagecont is Telerik.WebControls.RadDatePicker)
                //{
                //    ((Telerik.WebControls.RadDatePicker)pagecont).Enabled = true;
                // }
                else if (pagecont is FileUpload)
                {
                    ((FileUpload)pagecont).Enabled = true;
                }
                if (pagecont.HasControls())
                {
                    enableControls_all(pagecont);
                }
            }
        }

        public string PageFiledDescp()
        {
            string strPageFieldDes = "Fields  marked with <font color=red>*</font> are required.";
            return strPageFieldDes;
        }




        public void FillCheckBoxListGeneric(CheckBoxList objCBoxList, DataTable objDTable, string sCol1, string sCol2)
        {
            objCBoxList.Items.Clear();
            for (int i = 0; i < objDTable.Rows.Count; i++)
            {
                objCBoxList.Items.Insert(i, new ListItem(objDTable.Rows[i][sCol1].ToString(), objDTable.Rows[i][sCol2].ToString()));
            }
        }

        public void FillRadioButtonListGeneric(RadioButtonList objRBtnList, DataTable objDTable, string sCol1, string sCol2)
        {
            objRBtnList.Items.Clear();
            for (int i = 0; i < objDTable.Rows.Count; i++)
            {
                objRBtnList.Items.Insert(i, new ListItem(objDTable.Rows[i][sCol1].ToString(), objDTable.Rows[i][sCol2].ToString()));
            }
        }

        public static void ResetControlsGeneric(System.Web.UI.Control ctl)
        {
            foreach (System.Web.UI.Control pagecont in ctl.Controls)
            {
                if (pagecont is TextBox)
                {
                    ((TextBox)pagecont).Text = "";
                }
                else if (pagecont is CheckBox)
                {
                    ((CheckBox)pagecont).Checked = false;
                }
                else if (pagecont is CheckBoxList)
                {
                    for (int i = 0; i < ((CheckBoxList)pagecont).Items.Count; i++)
                    {
                        ((CheckBoxList)pagecont).Items[i].Selected = false;
                    }


                }

                else if (pagecont is RadioButtonList)
                {

                    ((RadioButtonList)pagecont).Enabled = true;
                    for (int i = 0; i < ((RadioButtonList)pagecont).Items.Count; i++)
                    {
                        ((RadioButtonList)pagecont).Items[i].Selected = false;
                    }
                    if (((RadioButtonList)pagecont).Items.Count > 0)
                    {
                        ((RadioButtonList)pagecont).SelectedIndex = 0;
                    }
                }
                //else if (pagecont is Telerik.WebControls.RadComboBox)
                //{
                //    ((Telerik.WebControls.RadComboBox)pagecont).SelectedIndex = 0;
                //}
                //else if (pagecont is Telerik.WebControls.RadDatePicker)
                //{
                //    ((Telerik.WebControls.RadDatePicker)pagecont).SelectedDate = null;
                //}

                if (pagecont.HasControls())
                {
                    ResetControlsGeneric(pagecont);
                }
            }
        }
    }

  
}
