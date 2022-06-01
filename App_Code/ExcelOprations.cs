using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Diagnostics;
using OfficeOpenXml.Style.XmlAccess;
using System.Data;
using System.IO;
/// <summary>
/// Summary description for ExcelOprations
/// </summary>
public class ExcelOprations
{
	public ExcelOprations()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
    {
        using (var pck = new OfficeOpenXml.ExcelPackage())
        {
            using (var stream = File.OpenRead(path))
            {
                pck.Load(stream);
            }
            var ws = pck.Workbook.Worksheets.First();
            DataTable tbl = new DataTable();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }
            var startRow = hasHeader ? 2 : 1;
            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                DataRow row = tbl.Rows.Add();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
            }
            return tbl;
        }
    }
    public  ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName,bool isRTL,int zoomScale)
    {
        p.Workbook.Worksheets.Add(sheetName);
        ExcelWorksheet ws = p.Workbook.Worksheets[1];
       
        ws.Name = sheetName; //Setting Sheet's name
        ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
        ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet    
        if (isRTL)
        {
            ExcelWorksheetView wv = ws.View;
            wv.ZoomScale = zoomScale;

            wv.RightToLeft = true;
            ws.PrinterSettings.Orientation = eOrientation.Landscape;
            ws.Cells.AutoFitColumns();

        }
        else
        {
            ExcelWorksheetView wv = ws.View;
            wv.ZoomScale = zoomScale;

            wv.RightToLeft = false;
            ws.PrinterSettings.Orientation = eOrientation.Landscape;
            ws.Cells.AutoFitColumns();
        }

        return ws;
    }
    public ExcelWorksheet AddSheet(ExcelPackage p, string sheetName, bool isRTL, int zoomScale)
    {
       ExcelWorksheet ws= p.Workbook.Worksheets.Add(sheetName);        
       // ws.Name = sheetName; //Setting Sheet's name
        ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
        ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet    
        if (isRTL)
        {
            ExcelWorksheetView wv = ws.View;
            wv.ZoomScale = zoomScale;

            wv.RightToLeft = true;
            ws.PrinterSettings.Orientation = eOrientation.Landscape;
            ws.Cells.AutoFitColumns();

        }
        else
        {
            ExcelWorksheetView wv = ws.View;
            wv.ZoomScale = zoomScale;

            wv.RightToLeft = false;
            ws.PrinterSettings.Orientation = eOrientation.Landscape;
            ws.Cells.AutoFitColumns();
        }

        return ws;
    }
    public ExcelRange StyleCells(ExcelRange cells,
        bool merge,
        OfficeOpenXml.Style.ExcelHorizontalAlignment HorizontalAlignment,
        OfficeOpenXml.Style.ExcelVerticalAlignment VertivalAlignment, 
        bool WrapText,
        float fontsize,
        ExcelBorderStyle AllborderStyle,
        System.Drawing.Color borderColor,System.Drawing.Color backgroundColor, bool fontBold)
    {

        cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
        cells.Style.Fill.BackgroundColor.SetColor(backgroundColor);

        cells.Merge=merge;
        cells.Style.HorizontalAlignment=HorizontalAlignment;
        cells.Style.VerticalAlignment=VertivalAlignment;
        cells.Style.WrapText=WrapText;
        cells.Style.Font.Size=fontsize;

        cells.Style.Border.Left.Style = AllborderStyle;
        cells.Style.Border.Left.Color.SetColor(borderColor);
        
         cells.Style.Border.Top.Style = AllborderStyle;
         cells.Style.Border.Top.Color.SetColor(borderColor);

       cells.Style.Border.Right.Style = AllborderStyle;
       cells.Style.Border.Right.Color.SetColor(borderColor);

        cells.Style.Border.Bottom.Style = AllborderStyle;
        cells.Style.Border.Bottom.Color.SetColor(borderColor);
        cells.Style.Font.Bold = fontBold;
        return cells;
    }

    public ExcelRange StyleCells(string cellAddress,
        bool merge,
        OfficeOpenXml.Style.ExcelHorizontalAlignment HorizontalAlignment,
        OfficeOpenXml.Style.ExcelVerticalAlignment VertivalAlignment,
        bool WrapText,
        float fontsize,
        ExcelBorderStyle AllborderStyle,
        System.Drawing.Color borderColor,bool fontBold,ExcelWorksheet ws)
    {
        ExcelRange cells = ws.Cells[cellAddress];
        cells.Address = cellAddress;
        cells.Merge = merge;
        cells.Style.HorizontalAlignment = HorizontalAlignment;
        cells.Style.VerticalAlignment = VertivalAlignment;
        cells.Style.WrapText = WrapText;
        cells.Style.Font.Size = fontsize;
        cells.Style.Font.Bold = fontBold;

        cells.Style.Border.Left.Style = AllborderStyle;
        cells.Style.Border.Left.Color.SetColor(borderColor);

        cells.Style.Border.Top.Style = AllborderStyle;
        cells.Style.Border.Top.Color.SetColor(borderColor);

        cells.Style.Border.Right.Style = AllborderStyle;
        cells.Style.Border.Right.Color.SetColor(borderColor);

        cells.Style.Border.Bottom.Style = AllborderStyle;
        cells.Style.Border.Bottom.Color.SetColor(borderColor);
        return cells;
    }

    public  void AddImage(ExcelWorksheet ws, int columnIndex, int rowIndex, string filePath)
    {
        //How to Add a Image using EP Plus
        Bitmap image = new Bitmap(HttpContext.Current.Server.MapPath(filePath));
        ExcelPicture picture = null;
        if (image != null)
        {
            
            picture = ws.Drawings.AddPicture("pic" + rowIndex.ToString() + columnIndex.ToString(), image);
            picture.From.Column = columnIndex;
            picture.From.Row = rowIndex;

            picture.From.ColumnOff = Pixel2MTU(2); //Two pixel space for better alignment
            picture.From.RowOff = Pixel2MTU(2);//Two pixel space for better alignment
            if (filePath.ToLower() == "../content/images/rptlogoaf.png")
            {
                picture.SetSize(250, 100);
            }
            else
            {
                picture.SetSize(100, 100);
            }
            
        }
    }
    public int Pixel2MTU(int pixels)
    {
        int mtus = pixels * 9525;
        return mtus;
    }
    public static double GetTrueColumnWidth(double width)
    {
        //DEDUCE WHAT THE COLUMN WIDTH WOULD REALLY GET SET TO
        double z = 1d;
        if (width >= (1 + 2 / 3))
        {
            z = Math.Round((Math.Round(7 * (width - 1 / 256), 0) - 5) / 7, 2);
        }
        else
        {
            z = Math.Round((Math.Round(12 * (width - 1 / 256), 0) - Math.Round(5 * width, 0)) / 12, 2);
        }

        //HOW FAR OFF? (WILL BE LESS THAN 1)
        double errorAmt = width - z;

        //CALCULATE WHAT AMOUNT TO TACK ONTO THE ORIGINAL AMOUNT TO RESULT IN THE CLOSEST POSSIBLE SETTING 
        double adj = 0d;
        if (width >= (1 + 2 / 3))
        {
            adj = (Math.Round(7 * errorAmt - 7 / 256, 0)) / 7;
        }
        else
        {
            adj = ((Math.Round(12 * errorAmt - 12 / 256, 0)) / 12) + (2 / 12);
        }

        //RETURN A SCALED-VALUE THAT SHOULD RESULT IN THE NEAREST POSSIBLE VALUE TO THE TRUE DESIRED SETTING
        if (z > 0)
        {
            return width + adj;
        }

        return 0d;
    }

    public void InsertRow(int rowFrom, int rows) { }
    //public void InsertRow(int rowFrom, int rows) { }
}
public class CellStyle:System.IDisposable
{
   
    ExcelWorksheet ws;
    ExcelRange cellrng;
    ExcelBorderStyle arroundborder= ExcelBorderStyle.None;
    private bool disposed = false;
    public CellStyle(ExcelWorksheet ws, ExcelRange cellrange)
    {
        this.ws = ws;
        cellrng = cellrange;
    }
    public CellStyle(ExcelWorksheet ws, string cellAdress)
    {
        this.ws = ws;
        cellrng = this.ws.Cells[cellAdress];
       // ExcelColor exc = new ExcelColor();      
        
    }
    public System.Drawing.Color BackgroundColor
    {       
        set
        {
            cellrng.Style.Fill.BackgroundColor.SetColor(value);
        }
    }
    public System.Drawing.Color PatternColor
    {
      
        set
        {
            cellrng.Style.Fill.PatternColor.SetColor(value);
        }
    }
    public ExcelFillStyle PatterFillType
    {
       
        set
        {
            cellrng.Style.Fill.PatternType = value;
        }
    }
    public ExcelFillStyle FillStyle
    {
       
        set { cellrng.Style.Fill.PatternType = value; }
    }
    public bool Hidden
    {
       
        set { cellrng.Style.Hidden = value; }
    }
    public ExcelBorderStyle AllBordersStyle
    {
       
        set
        {
            cellrng.Style.Border.Bottom.Style = value;
            cellrng.Style.Border.Left.Style = value;
            cellrng.Style.Border.Right.Style = value;
            cellrng.Style.Border.Top.Style = value;
        }
    }
    public ExcelBorderStyle BottomBorder
    {
      
        set { cellrng.Style.Border.Bottom.Style = value; }
    }
    public ExcelBorderStyle TopBorder
    {
      
        set { cellrng.Style.Border.Top.Style = value; }
    }
    public ExcelBorderStyle LeftBorder
    {
       
        set { cellrng.Style.Border.Left.Style = value; }
    }
    public ExcelBorderStyle RightBorder
    {
      
        set { cellrng.Style.Border.Right.Style = value; }
    }
    public System.Drawing.Color AllBordersColor
    {
      
        set
        {
            cellrng.Style.Border.Bottom.Color.SetColor(value);
            cellrng.Style.Border.Left.Color.SetColor(value);
            cellrng.Style.Border.Right.Color.SetColor(value);
            cellrng.Style.Border.Top.Color.SetColor(value);
        }
    }
    public System.Drawing.Color BottomBorderColor
    {
       
        set { cellrng.Style.Border.Bottom.Color.SetColor(value); }
    }
    public System.Drawing.Color TopBorderColor
    {
     
        set { cellrng.Style.Border.Top.Color.SetColor(value); }
    }
    public System.Drawing.Color LeftBorderColor
    {
      
        set { cellrng.Style.Border.Left.Color.SetColor(value); }
    }
    public System.Drawing.Color RightBorderColor
    {
       
        set { cellrng.Style.Border.Right.Color.SetColor(value); }
    }
    public float FontSize
    {
      
        set { cellrng.Style.Font.Size = value; }
    }
    public bool FontBold
    {
       
        set { cellrng.Style.Font.Bold = value; }
    }
    public bool WrapText
    {
        set { cellrng.Style.WrapText = value; }
    }
    public bool Merge
    {
      
        set { cellrng.Merge = value; }
    }
    public ExcelHorizontalAlignment HorizontalAlign
    {
      
        set {cellrng.Style.HorizontalAlignment = value; }
    }
    public ExcelVerticalAlignment VerticalAlign
    {
      
        set { cellrng.Style.VerticalAlignment = value; }
    }
    public ExcelFont CellFont
    {
       
        set { cellrng.Style.Font = value; }
    }
    public ExcelBorderStyle BorderArroundStyle
    {
        get{return arroundborder;}
        set { cellrng.Style.Border.BorderAround(value); arroundborder=value;}
    }
    public System.Drawing.Color BorderArroundColor
    {
        set { cellrng.Style.Border.BorderAround(BorderArroundStyle, value); }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                if (cellrng != null)
                {
                    cellrng.Dispose();
                }
            }

            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
