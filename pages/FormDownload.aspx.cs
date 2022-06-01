using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ionic.Zip;
using System.Web.UI.WebControls;
using System.IO;

public partial class pages_FormDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region IssuedForms
        if (Request.QueryString["fdetailDWstore"] != null)
        {
            #region store
            if (Request.QueryString["fdetailDWstore"].Length >= 5 && Request.QueryString["RTypeId"].ToString()=="2")
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;    


                INVTableAdapters.QRISVDetailTableAdapter ta = new INVTableAdapters.QRISVDetailTableAdapter();
                INV.QRISVDetailDataTable dt = new INV.QRISVDetailDataTable();
                ta.Fill(dt, Convert.ToInt64(Request.QueryString["fdetailDWstore"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                INVTableAdapters.QRISVAppDTableAdapter taAp = new INVTableAdapters.QRISVAppDTableAdapter();
                INV.QRISVAppDDataTable dtAp = new INV.QRISVAppDDataTable();
                taAp.Fill(dtAp, Convert.ToInt64(Request.QueryString["fdetailDWstore"].ToString()));
                ReportDataSource rdsAP = new ReportDataSource();
                rdsAP.Name = "DataSet2";
                rdsAP.Value = dtAp;
                // rds.Value = dtAp;
                // Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                viewer.LocalReport.DataSources.Add(rdsAP);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "pages/Report2.rdlc";
                ReportParameter rp = new ReportParameter("ISID", Request.QueryString["fdetailDWstore"].ToString());
                ReportParameter rp2 = new ReportParameter("ISID2", Request.QueryString["fdetailDWstore"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp, rp2 });

                viewer.ProcessingMode = ProcessingMode.Local;



                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=issueform." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
            #endregion
            #region INV|OFFICE USE
            if (Request.QueryString["fdetailDWstore"].Length >= 5 &&( Request.QueryString["RTypeId"].ToString() == "1"|| Request.QueryString["RTypeId"].ToString() == "3"))
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                INVTableAdapters.QRISVDetail2TableAdapter ta = new INVTableAdapters.QRISVDetail2TableAdapter();
                INV.QRISVDetail2DataTable dt = new INV.QRISVDetail2DataTable();
                ta.Fill(dt, Convert.ToInt64(Request.QueryString["fdetailDWstore"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                INVTableAdapters.QRISVAppDTableAdapter taAp = new INVTableAdapters.QRISVAppDTableAdapter();
                INV.QRISVAppDDataTable dtAp = new INV.QRISVAppDDataTable();
                taAp.Fill(dtAp, Convert.ToInt64(Request.QueryString["fdetailDWstore"].ToString()));
                ReportDataSource rdsAP = new ReportDataSource();
                rdsAP.Name = "DataSet2";
                rdsAP.Value = dtAp;
                // rds.Value = dtAp;
                // Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                viewer.LocalReport.DataSources.Add(rdsAP);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "pages/Report2S.rdlc";
                ReportParameter rp = new ReportParameter("ISID", Request.QueryString["fdetailDWstore"].ToString());
                ReportParameter rp2 = new ReportParameter("ISID2", Request.QueryString["fdetailDWstore"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp, rp2 });

                viewer.ProcessingMode = ProcessingMode.Local;



                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=issueform." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
            #endregion
        }
        #endregion
        #region ReqForms
        if (Request.QueryString["fRdetailAll"] != null)
        {
            if (Request.QueryString["fRdetailAll"].Length >= 3)
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                INVTableAdapters.QRProcReqDTableAdapter ta = new INVTableAdapters.QRProcReqDTableAdapter();
                INV.QRProcReqDDataTable dt = new INV.QRProcReqDDataTable();
                ta.Fill(dt, Convert.ToInt64(Request.QueryString["fRdetailAll"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                INVTableAdapters.QRProcReqAppDTableAdapter taAp = new INVTableAdapters.QRProcReqAppDTableAdapter();
                INV.QRProcReqAppDDataTable dtAp = new INV.QRProcReqAppDDataTable();
                taAp.Fill(dtAp, Convert.ToInt64(Request.QueryString["fRdetailAll"].ToString()));
                ReportDataSource rdsAP = new ReportDataSource();
                rdsAP.Name = "DataSet2";
                rdsAP.Value = dtAp;
                // rds.Value = dtAp;
                // Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                viewer.LocalReport.DataSources.Add(rdsAP);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "pages/rReq.rdlc";
                ReportParameter rp = new ReportParameter("ReqId", Request.QueryString["fRdetailAll"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp });
                viewer.ProcessingMode = ProcessingMode.Local;
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                using (ZipFile zip = new ZipFile())
                {
                    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                    // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                    //Response.Buffer = true;
                    //Response.Clear();
                    //Response.ContentType = mimeType;
                    //Response.AddHeader("content-disposition", "attachment; filename=ReqD-" + Request.QueryString["fRdetailAll"].ToString() + "." + extension);
                    //Response.BinaryWrite(bytes); // create the file
                    //Response.Flush(); // send it to the client to download

                    zip.AddEntry("Requested_File.pdf", bytes);

                    DataTable dtDoc = new OCM.OCM_DbGeneral().SelectRecords("select DocPath from tblINV_ReqDocs where R_Id=" + Request.QueryString["fRdetailAll"].ToString() + "");
                    if (dtDoc.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dtDoc.Rows)
                        {
                            string fileName = rw["DocPath"].ToString();
                            if (fileName != "")
                            {
                                System.IO.FileInfo file = new System.IO.FileInfo(fileName);
                                if (file.Exists)
                                {
                                    zip.AddFile(fileName, "SupportedDocuments");


                                }
                            }
                        }
                    }

                    Response.Clear();
                    Response.BufferOutput = false;
                    string zipName = String.Format("Req_{0}.zip",Request.QueryString["fRdetailAll"].ToString());
                    Response.ContentType = "application/zip";
                    Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                    zip.Save(Response.OutputStream);
                    Response.End();

                }


            }
        }
        #endregion        
        #region brcd
        if (Request.QueryString["brdI"] != null)
        {
            if (Request.QueryString["brdI"].Length >= 1)
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                //INVTableAdapters.QRISVDetailTableAdapter ta = new INVTableAdapters.QRISVDetailTableAdapter();
                //INV.QRISVDetailDataTable dt = new INV.QRISVDetailDataTable();
                //ta.Fill(dt, Convert.ToInt64(Request.QueryString["fdetailDWstore"].ToString()));
                //ReportDataSource rds = new ReportDataSource();
                //rds.Name = "DataSet1";
                //rds.Value = dt;


                //INVTableAdapters.QRISVAppDTableAdapter taAp = new INVTableAdapters.QRISVAppDTableAdapter();
                //INV.QRISVAppDDataTable dtAp = new INV.QRISVAppDDataTable();
                //taAp.Fill(dtAp, Convert.ToInt64(Request.QueryString["fdetailDWstore"].ToString()));
                //ReportDataSource rdsAP = new ReportDataSource();
                //rdsAP.Name = "DataSet2";
                //rdsAP.Value = dtAp;
                // rds.Value = dtAp;
                // Setup the report viewer object and get the array of bytes
                // string asa="120015945";
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                //viewer.LocalReport.DataSources.Add(rds);
                //viewer.LocalReport.DataSources.Add(rdsAP);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "pages/itmbrcd.rdlc";
                ReportParameter rp = new ReportParameter("brcd", Request.QueryString["brdI"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp });

                viewer.ProcessingMode = ProcessingMode.Local;



                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=brcd." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
        }
        #endregion
        #region InspectionDetailReport
        if (Request.QueryString["RDate"] != null && Request.QueryString["Province"] != null && Request.QueryString["Dept"] != null && Request.QueryString["Supplier"] != null)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["RDate"]) && !string.IsNullOrEmpty(Request.QueryString["Invoice"]) && !string.IsNullOrEmpty(Request.QueryString["Contract"]) && !string.IsNullOrEmpty(Request.QueryString["Dept"]))
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                var LoopCount = Request.QueryString["LoopCount"];
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("Inspectors");
                dt.Columns.Add("Position");
                for (int i = 1; i <= Convert.ToInt16(LoopCount.ToString()); i++)
                {
                    System.Data.DataRow rw = dt.NewRow();
                    rw["Inspectors"] = Request.QueryString["name" + i];
                    rw["Position"] = Request.QueryString["pos" + i];
                    dt.Rows.Add(rw);
                }


                ReportDataSource rds = new ReportDataSource("dsInpectionD",dt);
                //dt.TableName = "DataSet1";
                //rds.Name = "dsInpectionD";
                //rds.Value = dt;


                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
               // viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "pages/Inspector.rdlc";
                ReportParameter rp = new ReportParameter("Station", Request.QueryString["Province"].ToString());
                ReportParameter rp2 = new ReportParameter("Dept", Request.QueryString["Dept"].ToString());
                ReportParameter rp3 = new ReportParameter("Supplier", Request.QueryString["Supplier"].ToString());
                ReportParameter rp4 = new ReportParameter("RDate", Request.QueryString["RDate"].ToString());
                ReportParameter rp5 = new ReportParameter("IDate", Request.QueryString["IDate"].ToString());
                ReportParameter rp6 = new ReportParameter("Contract", Request.QueryString["Contract"].ToString());
                ReportParameter rp7 = new ReportParameter("Invoice", Request.QueryString["Invoice"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp, rp2, rp3 ,rp4,rp5,rp6,rp7});
                viewer.ProcessingMode = ProcessingMode.Local;
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=ReqD-Data-ReportThree." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
        }
        #endregion
        #region RecievingVoucher
        if (Request.QueryString["fRecVoucher"] != null)
        {

            if (Request.QueryString["fRecVoucher"].Length >= 1 && !string.IsNullOrEmpty(Request.QueryString["sr"].ToString()) && !string.IsNullOrEmpty(Request.QueryString["grvid"].ToString()))
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                INVTableAdapters.QRReceivingVoucherTableAdapter ta = new INVTableAdapters.QRReceivingVoucherTableAdapter();
                INV.QRReceivingVoucherDataTable dt = new INV.QRReceivingVoucherDataTable();
                ta.Fill(dt, Convert.ToInt64(Request.QueryString["grvid"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                INVTableAdapters.QrRecievingVoucherInspectionDTableAdapter taInsp= new INVTableAdapters.QrRecievingVoucherInspectionDTableAdapter();
                INV.QrRecievingVoucherInspectionDDataTable dtInsp = new INV.QrRecievingVoucherInspectionDDataTable();
                taInsp.Fill(dtInsp, Convert.ToInt16(Request.QueryString["sr"].ToString()), Convert.ToInt64(Request.QueryString["grvid"].ToString()));
                ReportDataSource rdsInsP = new ReportDataSource();
                rdsInsP.Name = "DataSet2";
                rdsInsP.Value = dtInsp;
                // rds.Value = dtAp;
                // Setup the report viewer object and get the array of bytes
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                viewer.LocalReport.DataSources.Add(rdsInsP);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "pages/report-recieve.rdlc";
                ReportParameter rp = new ReportParameter("sr", Request.QueryString["sr"].ToString());
                ReportParameter rp2 = new ReportParameter("grvid", Request.QueryString["grvid"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp, rp2 });

                viewer.ProcessingMode = ProcessingMode.Local;



                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=ReceivingForm." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
           
            
        }
        #endregion

        #region ReportOne
        if (Request.QueryString["data-report"] != null && Request.QueryString["m"] != null && Request.QueryString["y"] != null && Request.QueryString["tp"] != null)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["data-report"]) && Request.QueryString["m"] != "-1" && Request.QueryString["y"] != "-1" && Request.QueryString["tp"] == "1")
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                INVTableAdapters.QRdataReportOneTableAdapter ta = new INVTableAdapters.QRdataReportOneTableAdapter();
                INV.QRdataReportOneDataTable dt = new INV.QRdataReportOneDataTable();
                ta.Fill(dt, Convert.ToString(Request.QueryString["data-report"].ToString()), Convert.ToInt16(Request.QueryString["y"].ToString()), Convert.ToInt16(Request.QueryString["m"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "Reports/data-reportType1.rdlc";
                ReportParameter rp = new ReportParameter("prov", Request.QueryString["data-report"].ToString());
                ReportParameter rp2 = new ReportParameter("year", Request.QueryString["y"].ToString());
                ReportParameter rp3 = new ReportParameter("month", Request.QueryString["m"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp, rp2, rp3 });
                viewer.ProcessingMode = ProcessingMode.Local;
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=ReqD-" + Request.QueryString["y"].ToString() + "Data-ReportOne." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
        }
        #endregion
        #region ReportTwoIssue
        if (Request.QueryString["data-report"] != null && Request.QueryString["m"] != null && Request.QueryString["y"] != null && Request.QueryString["tp"] != null)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["data-report"]) && Request.QueryString["m"] != "-1" && Request.QueryString["y"] != "-1" && Request.QueryString["tp"] == "2")
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                INVTableAdapters.QRdataReportTwoIssueTableAdapter ta = new INVTableAdapters.QRdataReportTwoIssueTableAdapter();
                INV.QRdataReportTwoIssueDataTable dt = new INV.QRdataReportTwoIssueDataTable();
                ta.Fill(dt, Convert.ToString(Request.QueryString["data-report"].ToString()), Convert.ToInt16(Request.QueryString["y"].ToString()), Convert.ToInt16(Request.QueryString["m"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "Reports/data-reportType2.rdlc";
                ReportParameter rp = new ReportParameter("prov", Request.QueryString["data-report"].ToString());
                ReportParameter rp2 = new ReportParameter("year", Request.QueryString["y"].ToString());
                ReportParameter rp3 = new ReportParameter("month", Request.QueryString["m"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp, rp2, rp3 });
                viewer.ProcessingMode = ProcessingMode.Local;
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=ReqD-" + Request.QueryString["y"].ToString() + "Data-ReportTwo." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
        }
        #endregion
        #region ReportThreeIssue
        if (Request.QueryString["data-report"] != null && Request.QueryString["m"] != null && Request.QueryString["y"] != null && Request.QueryString["tp"] != null)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["data-report"]) && Request.QueryString["m"] != "-1" && Request.QueryString["y"] != "-1" && Request.QueryString["tp"] == "3")
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                INVTableAdapters.QRdataReportThreeRecievingTableAdapter ta = new INVTableAdapters.QRdataReportThreeRecievingTableAdapter();
                INV.QRdataReportThreeRecievingDataTable dt = new INV.QRdataReportThreeRecievingDataTable();
                ta.Fill(dt, Convert.ToString(Request.QueryString["data-report"].ToString()), Convert.ToInt16(Request.QueryString["y"].ToString()), Convert.ToInt16(Request.QueryString["m"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "Reports/data-reportType3.rdlc";
                ReportParameter rp = new ReportParameter("prov", Request.QueryString["data-report"].ToString());
                ReportParameter rp2 = new ReportParameter("year", Request.QueryString["y"].ToString());
                ReportParameter rp3 = new ReportParameter("month", Request.QueryString["m"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp, rp2, rp3 });
                viewer.ProcessingMode = ProcessingMode.Local;
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=ReqD-" + Request.QueryString["y"].ToString() + "Data-ReportThree." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
        }
        #endregion
        #region ReportFive
        if (Request.QueryString["data-report"] != null && Request.QueryString["tp"] != null)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["data-report"]) && Request.QueryString["tp"] == "5")
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                INVTableAdapters.QRdataReportFiveTableAdapter ta = new INVTableAdapters.QRdataReportFiveTableAdapter();
                INV.QRdataReportFiveDataTable dt = new INV.QRdataReportFiveDataTable();
                ta.Fill(dt, Convert.ToString(Request.QueryString["data-report"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "Reports/data-reportType5.rdlc";
                ReportParameter rp = new ReportParameter("prov", Request.QueryString["data-report"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp });
                viewer.ProcessingMode = ProcessingMode.Local;
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=ReqD-Data-ReportFive." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
        }
        #endregion
        #region ReportSix
        if (Request.QueryString["data-report"] != null && Request.QueryString["tp"] != null)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["data-report"]) && Request.QueryString["tp"] == "6")
            {
                // Variables
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                INVTableAdapters.QRdataReportSixTableAdapter ta = new INVTableAdapters.QRdataReportSixTableAdapter();
                INV.QRdataReportSixDataTable dt = new INV.QRdataReportSixDataTable();
                ta.Fill(dt, Convert.ToString(Request.QueryString["data-report"].ToString()));
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = dt;


                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(rds);
                //viewer.LocalReport.DataSources.Add(rdsAp);
                viewer.LocalReport.ReportPath = "Reports/data-reportType6.rdlc";
                ReportParameter rp = new ReportParameter("prov", Request.QueryString["data-report"].ToString());
                viewer.LocalReport.SetParameters(new ReportParameter[] { rp });
                viewer.ProcessingMode = ProcessingMode.Local;
                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename=ReqD-Data-ReportSix." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
            }
        }
        #endregion


        #region RecievingVoucherFileDocumentDownoald
        if (Request.QueryString["RvfilePath"] != null)
        {
            if (Request.QueryString["RvfilePath"].Length >= 1)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", "attachment;filename=report.xls");
                Response.Charset = "utf-8";
                Response.Write(System.IO.Path.Combine(Server.MapPath(Request.QueryString["RvfilePath"].ToString())));
                //Response.OutputStream.Write(new byte[] { 0xef, 0xbb, 0xbf }, 0, 3);
                //Response.Write(sw.ToString());
                Response.End();
            }
        }
        #endregion
        #region RecieveVoucherUploadedScanFileDownoald
        if (Request.QueryString["RecVoucherScanFile"].ToString() == "Yes")
        {
            if (Request.QueryString["grvid"].Length >= 1)
            {
                if (Request.QueryString["P"].ToString() != null)
                {
                    string ext = System.IO.Path.GetExtension(Request.QueryString["P"].ToString());
                    switch (ext)
                    {
                        case ".jpg":
                        case ".jpeg":
                            if (File.Exists(Request.QueryString["P"].ToString()))
                            {
                                HttpContext.Current.Response.ClearContent();
                                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=img.jpg");
                                HttpContext.Current.Response.Charset = "";
                                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                HttpContext.Current.Response.ContentType = "application/image";
                                HttpContext.Current.Response.WriteFile(Request.QueryString["P"].ToString());
                                HttpContext.Current.Response.End();
                            }
                            break;


                        case ".png":
                            if (File.Exists(Request.QueryString["P"].ToString()))
                            {
                                HttpContext.Current.Response.ClearContent();
                                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=img.png");
                                HttpContext.Current.Response.Charset = "";
                                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                HttpContext.Current.Response.ContentType = "application/image";
                                HttpContext.Current.Response.WriteFile(Request.QueryString["P"].ToString());
                                HttpContext.Current.Response.End();
                            }
                            break;




                        case ".pdf":
                            if (File.Exists(Request.QueryString["P"].ToString()))
                            {
                                HttpContext.Current.Response.ClearContent();
                                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=pdfdocument.pdf");
                                HttpContext.Current.Response.Charset = "";
                                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                HttpContext.Current.Response.ContentType = "application/acroreader";
                                HttpContext.Current.Response.WriteFile(Request.QueryString["P"].ToString());
                                HttpContext.Current.Response.End();
                            }
                            break;

                    }
                }
            }
        }
        #endregion



    
    
    }
}