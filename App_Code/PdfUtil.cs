using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
/// <summary>
/// Summary description for PdfUtil
/// </summary>
namespace PdfUtility
{
   public enum PdfFontStyle
    {
        NORMAL,
        BOLD,
        BOLDITALIC,
        ITALIC,
        HELVITICA,
        COURIER,
        TIMESROMAN
    };
    public class PdfUtil
    {
        public PdfUtil()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Pokhto pdfp Methods
        public iTextSharp.text.Font PokhtoFont(float FontSize, PdfFontStyle fontstyle, iTextSharp.text.Color fontColor)
        {
            try
            {
                FontSelector fs = new FontSelector();
               
                BaseFont bf = null;
                //if (File.Exists("c:\\windows\\fonts\\artro.ttf"))
                //    bf = BaseFont.CreateFont("c:\\windows\\fonts\\simpo.ttf", BaseFont.IDENTITY_H, true);
                //else

                bf = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                //bf = BaseFont.CreateFont("c:\\windows\\fonts\\pokhto.ttf", BaseFont.IDENTITY_H, true);
               // bf.DirectTextToByte = true;
                bf.CorrectArabicAdvance();
                //bf.SetCharAdvance('ښ', 4);
                //bf.SetKerning('ښ','و',-2);
                //bf = BaseFont.CreateFont("c:\\windows\\fonts\\trado.ttf", BaseFont.IDENTITY_H, true);
                iTextSharp.text.Font f2 = null;
                if (fontstyle == PdfFontStyle.BOLD)
                    f2 = new iTextSharp.text.Font(bf, FontSize, iTextSharp.text.Font.BOLD, fontColor);
                else if (fontstyle == PdfFontStyle.NORMAL)
                    f2 = new iTextSharp.text.Font(bf, FontSize, iTextSharp.text.Font.NORMAL, fontColor);
                else if (fontstyle == PdfFontStyle.BOLDITALIC)
                    f2 = new iTextSharp.text.Font(bf, FontSize, iTextSharp.text.Font.BOLDITALIC, fontColor);
                else if (fontstyle == PdfFontStyle.COURIER)
                    f2 = new iTextSharp.text.Font(bf, FontSize, iTextSharp.text.Font.COURIER, fontColor);
                else if (fontstyle == PdfFontStyle.HELVITICA)
                    f2 = new iTextSharp.text.Font(bf, FontSize, iTextSharp.text.Font.HELVETICA, fontColor);
                else if (fontstyle == PdfFontStyle.ITALIC)
                    f2 = new iTextSharp.text.Font(bf, FontSize, iTextSharp.text.Font.ITALIC, fontColor);
                else if (fontstyle == PdfFontStyle.TIMESROMAN)
                    f2 = new iTextSharp.text.Font(bf, FontSize, iTextSharp.text.Font.TIMES_ROMAN, fontColor);
                return f2;
            }
            catch (Exception)
            {
                throw new Exception("Font Not Found");
            }
        }
        public iTextSharp.text.Image DrawImagePushto(string Text)
        {
            Bitmap bm = new Bitmap(120, 20);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(System.Drawing.Color.White);
            StringFormat sf = new StringFormat();
            //  sf.FormatFlags = StringFormatFlags.di;
            sf.Alignment = StringAlignment.Center;
            System.Drawing.Font fnt = new System.Drawing.Font("Pokhto", 14.0f, FontStyle.Bold, GraphicsUnit.Pixel, 8, true);
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, 120, 20);
            //Brush brGradient = new LinearGradientBrush(r, System.Drawing.Color.White, System.Drawing.Color.White, 150.0f, false);        
            g.DrawRectangle(Pens.White, 0, 0, 120, 20);
            g.DrawString(Text, fnt, new SolidBrush(System.Drawing.Color.Black), r, sf);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bm, ImageFormat.Jpeg);
            img.BorderColor = iTextSharp.text.Color.WHITE;
            bm.Dispose();
            return img;
        }
        public iTextSharp.text.Image DrawImagePushto(string Text, int width, int height, float fontsize)
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(System.Drawing.Color.White);
            StringFormat sf = new StringFormat();
            //  sf.FormatFlags = StringFormatFlags.di;
            sf.Alignment = StringAlignment.Center;
            System.Drawing.Font fnt = new System.Drawing.Font("Pokhto", fontsize, FontStyle.Bold, GraphicsUnit.Pixel, 8, true);
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(1, 1, width, height);
            //Brush brGradient = new LinearGradientBrush(r, System.Drawing.Color.White, System.Drawing.Color.White, 150.0f, false);        
            g.DrawRectangle(Pens.White, 1, 1, width, height);
            g.DrawString(Text, fnt, new SolidBrush(System.Drawing.Color.Black), r, sf);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bm, ImageFormat.Jpeg);
            bm.Dispose();
            return img;
        }
        public PdfPCell PdfpTextCell(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign)
        {
            Paragraph para = new Paragraph(value, PokhtoFont(FontSize, fontstyle, ForeColor));
            PdfPCell txtCell = new PdfPCell(para);
            txtCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    para.SetAlignment("center");
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }
        public PdfPCell PdfpTextCell(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign, int colspan)
        {
            Paragraph para = new Paragraph(value, PokhtoFont(FontSize, fontstyle, ForeColor));
            PdfPCell txtCell = new PdfPCell(para);
            txtCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Colspan = colspan;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    // para.SetAlignment("center");
                    para.Alignment = Element.ALIGN_CENTER;
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }

        public PdfPCell PdfpCheckBoxCell( iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign)
        {
           
            PdfPCell txtCell = new PdfPCell();
            txtCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
          
            PdfPTable tbl = PdfpPokhtoTable(1, 80);
            tbl.AddCell(PdfpTextCell(" ", iTextSharp.text.Color.BLACK, iTextSharp.text.Color.WHITE, PdfFontStyle.NORMAL, iTextSharp.text.Color.BLACK, 8, "center"));
            txtCell.AddElement(tbl);
            return txtCell;
        }
        public PdfPCell PdfpCheckBoxCell(iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign,float perWidth, int columnSpan=1, bool isChecked=false)
        {

            PdfPCell txtCell = new PdfPCell();
            txtCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Colspan = columnSpan;
            PdfPTable tbl = PdfpPokhtoTable(1, perWidth);
            if (isChecked)
            {
                tbl.AddCell(PdfpTextCell(" ", iTextSharp.text.Color.BLACK, iTextSharp.text.Color.GRAY, PdfFontStyle.NORMAL, iTextSharp.text.Color.BLACK, 8, "center"));
                //ZapfDingbatsList list = new ZapfDingbatsList(52, checkIdent);
                //list.IndentationLeft = 10f;
                //list.Add(" ");
                //list.Alignindent = true;
                //list.Autoindent = true;
                //PdfPCell ce = new PdfPCell();
                //ce.BorderColor = iTextSharp.text.Color.BLACK;
                //ce.HorizontalAlignment = Element.ALIGN_CENTER;
                //ce.VerticalAlignment = Element.ALIGN_MIDDLE;
                //ce.AddElement(list);
                //tbl.AddCell(ce);
            }
            else
            tbl.AddCell(PdfpTextCell(" ", iTextSharp.text.Color.BLACK, iTextSharp.text.Color.WHITE, PdfFontStyle.NORMAL, iTextSharp.text.Color.BLACK, 8, "center"));
            txtCell.AddElement(tbl);
            return txtCell;
        }
        public PdfPCell PdfpTextCell(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign,int RotationAngle,bool Rotate)
        {
            Paragraph para = new Paragraph(value, PokhtoFont(FontSize, fontstyle, ForeColor));
            PdfPCell txtCell = new PdfPCell(para);
            txtCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Rotation = RotationAngle;
            txtCell.Rotate();
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    para.SetAlignment("center");
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }
        public PdfPCell PdfpTextCell(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign, int colspan,int RotationAngle,bool Rotate)
        {
            Paragraph para = new Paragraph(value, PokhtoFont(FontSize, fontstyle, ForeColor));
            PdfPCell txtCell = new PdfPCell(para);
            txtCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Colspan = colspan;
            txtCell.Rotation = RotationAngle;
            txtCell.Rotate();
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    // para.SetAlignment("center");
                    para.Alignment = Element.ALIGN_CENTER;
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }
       



        public PdfPCell Pdfp_Cell(iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, string TextAlign, int colspan)
        {
           
            PdfPCell txtCell = new PdfPCell();
            txtCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Colspan = colspan;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    // para.SetAlignment("center");
                   
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                  
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                  
                    break;
            }
            return txtCell;
        }
        public PdfPCell Pdfp_Cell(iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, string TextAlign)
        {

            PdfPCell txtCell = new PdfPCell();
            txtCell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
           
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    // para.SetAlignment("center");

                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;

                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                    break;
            }
            return txtCell;
        }
        public Paragraph GetParaGraph(string value,float FontSize,PdfFontStyle fontstyle,iTextSharp.text.Color ForeColor)
        {
            Paragraph para = new Paragraph(value, PokhtoFont(FontSize, fontstyle, ForeColor));
            return para;
        }

        public PdfPCell PdfpVerticalTextCell(string value,int imageWidth,int ImageHeight, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, System.Drawing.Color ForeColor, float FontSize, int colspan)
        {
            Bitmap bm = new Bitmap(80, 136);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(System.Drawing.Color.Transparent);
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionVertical;
            sf.Alignment = StringAlignment.Center;
            
            System.Drawing.Font fnt = new System.Drawing.Font("Times New Roman", FontSize, FontStyle.Bold, GraphicsUnit.Pixel, 8, true);
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(1, 1, 75, 135);
            //Brush brGradient = new LinearGradientBrush(r, System.Drawing.Color.White, System.Drawing.Color.White, 150.0f, false);

            //g.FillRectangle(brGradient, 1, 1, imageWidth, ImageHeight);
            g.DrawRectangle(Pens.Black, 1, 1, imageWidth, ImageHeight);
            Brush b=new SolidBrush(ForeColor);
            g.DrawString(value, fnt, b, 0, 0, sf);
            g.TranslateTransform(40, 136);
            g.RotateTransform(180.0f);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bm, ImageFormat.Png);
            PdfPCell c = new PdfPCell(img);
            c.BorderColor = BorderColor;
            c.BackgroundColor = backcolor;
            c.BorderWidth = 0.3f;
            c.Colspan = colspan;
            bm.Dispose();
            return c;

        }
        public PdfPCell PdfpVerticalTextCell(string value, int imageWidth, int ImageHeight, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, System.Drawing.Color ForeColor, float FontSize)
        {
            //string stFileName = Toolbox.GetMD5String(stText);
            //string stFullFilePath = this._baseImagePath + stFileName + ".jpg";
            //if (!File.Exists(stFullFilePath))
            //{
                Graphics _graphics=null;
                StringFormat stringFormat = new StringFormat();
                stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                System.Drawing.Image img1 = (System.Drawing.Image)new Bitmap(1000, 1000);
                _graphics = Graphics.FromImage(img1);

                SizeF imageSize = _graphics.MeasureString(value,new System.Drawing.Font("times",FontSize,FontStyle.Regular), 25, stringFormat);
                System.Drawing.Image i = (System.Drawing.Image)new Bitmap((int)imageSize.Width, (int)imageSize.Height);
                Graphics g = Graphics.FromImage(i);
                g.Clear(System.Drawing.Color.Transparent);
                g.FillRectangle(Brushes.White, 0, 0, i.Width, i.Height);

                //flip the image 180 degrees
                g.TranslateTransform(i.Width, i.Height);
                g.RotateTransform(180.0F);

                g.DrawString(value, new System.Drawing.Font(FontFamily.GenericSansSerif, FontSize, FontStyle.Regular), Brushes.Black, 0, 0, stringFormat);

                //i.Save(stFullFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(i,ImageFormat.Png);
            PdfPCell c = new PdfPCell(img);
            c.BorderColor = BorderColor;
            c.BackgroundColor = backcolor;
            c.BorderWidth = 0.3f;
           // c.Colspan = colspan;
            i.Save(HttpContext.Current.Server.MapPath("~/Images/Ver.png"));
            i.Dispose();
            return c;

        }

        public PdfPCell PdfpEmptyCell(iTextSharp.text.Color BorderColor, float fontSize)
        {
            Paragraph para = new Paragraph("\n", new iTextSharp.text.Font(1, fontSize, 1));
            PdfPCell ECell = new PdfPCell(para);
            ECell.BorderColor = BorderColor;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public PdfPCell PdfpEmptyCell(iTextSharp.text.Color BorderColor, float fontSize, int colspan)
        {
            Paragraph para = new Paragraph("\n", new iTextSharp.text.Font(1, fontSize, 1));
            PdfPCell ECell = new PdfPCell(para);
            ECell.BorderColor = BorderColor;
            ECell.BorderWidth = 0.3f;
            ECell.Colspan = colspan;
            return ECell;
        }
        public PdfPTable PdfpEmptyTable(int columns,int rows,iTextSharp.text.Color bordercolor,int width)
        {
            PdfPTable TEmpty = new PdfPTable(columns);
            TEmpty.WidthPercentage = width;
            Paragraph PEmpty = new Paragraph("\n\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    PdfPCell CEmpty = new PdfPCell(PEmpty);
                   
                        CEmpty.BorderColor = iTextSharp.text.Color.WHITE;
                        CEmpty.BorderWidth = 0.3f;
                    
                    TEmpty.AddCell(CEmpty);
                }

               

            }
            return TEmpty;
        }
        public PdfPTable PdfpPokhtoTable(int columns, float tablewidthPercentage)
        {
            PdfPTable table = new PdfPTable(columns);
            table.WidthPercentage = tablewidthPercentage;
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            return table;
        }
        public PdfPTable PdfpPokhtoTable(int columns, float tablewidthPercentage,bool lefttoright)
        {
            PdfPTable table = new PdfPTable(columns);
            table.WidthPercentage = tablewidthPercentage;
            
            return table;
        }
        private Cell DrawPushtoCell(string Text, int width, int height, float fontSize, iTextSharp.text.Color BorderColor)
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(System.Drawing.Color.White);
            StringFormat sf = new StringFormat();
            //  sf.FormatFlags = StringFormatFlags.di;
            sf.Alignment = StringAlignment.Center;
            System.Drawing.Font fnt = new System.Drawing.Font("Pokhto", fontSize, FontStyle.Bold, GraphicsUnit.Pixel, 8, true);
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(1, 1, width, height);
            //Brush brGradient = new LinearGradientBrush(r, System.Drawing.Color.White, System.Drawing.Color.White, 150.0f, false);        
            g.DrawRectangle(Pens.White, 1, 1, width, height);
            g.DrawString(Text, fnt, new SolidBrush(System.Drawing.Color.Black), r, sf);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bm, ImageFormat.Jpeg);
            bm.Dispose();


            Cell c = new Cell();
            c.BorderColor = BorderColor;
            c.BorderWidth = 0.3f;

            c.Add(img);
            return c;

        }
       
        #endregion
      
        #region Eng PdfpMethods
        public PdfPCell PdfpTextCellEng(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign)
        {
            Paragraph para = new Paragraph(value, new iTextSharp.text.Font(1, FontSize, 1, ForeColor));
            PdfPCell txtCell = new PdfPCell(para);
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    para.SetAlignment("center");
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }
        public PdfPCell PdfpTextCellEng(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign, int colspan)
        {
            Paragraph para = new Paragraph(value, new iTextSharp.text.Font(1, FontSize, 1, ForeColor));
            PdfPCell txtCell = new PdfPCell(para);
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Colspan = colspan;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    para.SetAlignment("center");
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }
        public PdfPCell PdfpTextCellEng(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, PdfFontStyle fontstyle, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign, int colspan)
        {
            Paragraph para = new Paragraph(value, new iTextSharp.text.Font(1, FontSize, 1, ForeColor));
            PdfPCell txtCell = new PdfPCell(para);
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Colspan = colspan;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    para.SetAlignment("center");
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }
        public PdfPCell PdfpTextCellEng(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor,PdfFontStyle fontstyle, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign)
        {
            Paragraph para = new Paragraph(value, new iTextSharp.text.Font(1, FontSize, 1, ForeColor));
            PdfPCell txtCell = new PdfPCell(para);
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    para.SetAlignment("center");
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }
        #endregion


        #region English Methods


        public Cell EmptyCell(iTextSharp.text.Color BorderColor, float fontSize)
        {
            Paragraph para = new Paragraph("\n", new iTextSharp.text.Font(1, fontSize, 1));
            Cell ECell = new Cell(para);
            ECell.BorderColor = BorderColor;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public iTextSharp.text.Table EmptyTable(int columns, bool border, bool autofillemptyCell)
        {
            iTextSharp.text.Table TEmpty = new iTextSharp.text.Table(columns);
            if (border)
            {
                TEmpty.BorderColor = iTextSharp.text.Color.BLUE;
                TEmpty.BorderWidth = 0.3f;
            }
            else
            {
                TEmpty.BorderColor = iTextSharp.text.Color.WHITE;
                TEmpty.BorderWidth = 0.3f;
            }
            Paragraph PEmpty = new Paragraph("\n\n");
            for (int i = 0; i < columns; i++)
            {
                Cell CEmpty = new Cell(PEmpty);
                TEmpty.AddCell(CEmpty, 0, i);
            }
            return TEmpty;
        }
        public Cell TextCell(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign)
        {
            Paragraph para = new Paragraph(value, new iTextSharp.text.Font(1, FontSize, 1, ForeColor));
            Cell txtCell = new Cell(para);
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;                  
                    para.Alignment = 2;
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;                  
                    para.Alignment = Element.ALIGN_LEFT;
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;                  
                    para.Alignment = Element.ALIGN_RIGHT;
                    break;
            }
            return txtCell;
        }
        public Cell TextCell(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign, int colspan)
        {
            Paragraph para = new Paragraph(value, new iTextSharp.text.Font(1, FontSize, 1, ForeColor));
            Cell txtCell = new Cell(para);
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Colspan = colspan;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    para.Alignment = Element.ALIGN_CENTER;
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.Alignment = Element.ALIGN_LEFT;
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.Alignment = Element.ALIGN_RIGHT;
                    break;
            }
            return txtCell;
        }
        public Cell TextCell(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign, int colspan, int rowspan)
        {
            
            Paragraph para = new Paragraph(value, new iTextSharp.text.Font(1, FontSize, 1, ForeColor));
            Cell txtCell = new Cell(para);
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;
            txtCell.Colspan = colspan;
            txtCell.Rowspan = rowspan;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    para.Alignment = Element.ALIGN_CENTER;
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    para.Alignment = Element.ALIGN_LEFT;
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    para.Alignment = Element.ALIGN_RIGHT;
                    break;
            }
            return txtCell;
        }
        public Cell TextCellRowSpan(string value, iTextSharp.text.Color BorderColor, iTextSharp.text.Color backcolor, iTextSharp.text.Color ForeColor, float FontSize, string TextAlign, int rowspan)
        {
            Paragraph para = new Paragraph(value, new iTextSharp.text.Font(1, FontSize, 1, ForeColor));
            Cell txtCell = new Cell(para);
            txtCell.BackgroundColor = backcolor;
            txtCell.BorderColor = BorderColor;

            txtCell.Rowspan = rowspan;
            switch (TextAlign)
            {
                case "center":
                case "Center":
                case "CENTER":
                    txtCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    txtCell.VerticalAlignment = Element.ALIGN_CENTER;
                    para.Alignment = Element.ALIGN_CENTER;
                    break;
                case "left":
                case "Left":
                case "LEFT":
                    txtCell.SetHorizontalAlignment("left");
                    para.SetAlignment("left");
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    txtCell.SetHorizontalAlignment("right");
                    para.SetAlignment("right");
                    break;
            }
            return txtCell;
        }
        public Cell EmptyCell(iTextSharp.text.Color BorderColor, float fontSize, int colspan)
        {
            Paragraph para = new Paragraph("\n", new iTextSharp.text.Font(1, fontSize, 1));
            Cell ECell = new Cell(para);
            ECell.BorderColor = BorderColor;
            ECell.Colspan = colspan;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public Cell EmptyCell(iTextSharp.text.Color BorderColor, float fontSize, int colspan, int rowspan)
        {
            Paragraph para = new Paragraph("\n", new iTextSharp.text.Font(1, fontSize, 1));
            Cell ECell = new Cell(para);
            ECell.Rowspan = rowspan;
            ECell.BorderColor = BorderColor;
            ECell.Colspan = colspan;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public Cell EmptyCellRowSpan(iTextSharp.text.Color BorderColor, float fontSize, int rowspan)
        {
            Paragraph para = new Paragraph("\n", new iTextSharp.text.Font(1, fontSize, 1));
            Cell ECell = new Cell(para);
            ECell.Rowspan = rowspan;
            ECell.BorderColor = BorderColor;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public System.Drawing.Image  DrawImageText(string txt, System.Drawing.Color color)
        {
            System.Drawing.Bitmap bmp = new Bitmap(15, 7);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            try
            {
                // System.Drawing.RectangleF rect = new System.Drawing.RectangleF(30, 30, 35, 35);
                Pen p = new Pen(System.Drawing.Color.Blue, 3.0f);
                g.Clear(color);
                g.FillRectangle(new SolidBrush(color),g.ClipBounds);
                //g.DrawRectangle(p, 0, 0, bmp.Width, bmp.Height);

                ////SizeF siz= g.MeasureString(txt, new System.Drawing.Font(FontFamily.GenericSansSerif, 10));
                //StringFormat sf = new StringFormat();
                //sf.Alignment = StringAlignment.Center;
                //sf.LineAlignment = StringAlignment.Center;
                //g.DrawString(txt, new System.Drawing.Font("Verdana", 10), new SolidBrush(System.Drawing.Color.Blue), new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), sf);
                //bmp.Save(HttpContext.Current.Server.MapPath(fileName));
                return bmp;

            }
            catch
            {
                throw new Exception("Drawing an Image Exception");
            }
            finally
            {
                g.Dispose();
            }



        }
        public System.Drawing.Image DrawImageText(string txt, System.Drawing.Color color,int width,int height)
        {
            System.Drawing.Bitmap bmp = new Bitmap(width, height);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            try
            {
                // System.Drawing.RectangleF rect = new System.Drawing.RectangleF(30, 30, 35, 35);
                Pen p = new Pen(System.Drawing.Color.Blue, 3.0f);
                g.Clear(color);
                g.FillRectangle(new SolidBrush(color), g.ClipBounds);
                //g.DrawRectangle(p, 0, 0, bmp.Width, bmp.Height);

                ////SizeF siz= g.MeasureString(txt, new System.Drawing.Font(FontFamily.GenericSansSerif, 10));
                //StringFormat sf = new StringFormat();
                //sf.Alignment = StringAlignment.Center;
                //sf.LineAlignment = StringAlignment.Center;
                //g.DrawString(txt, new System.Drawing.Font("Verdana", 10), new SolidBrush(System.Drawing.Color.Blue), new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), sf);
                //bmp.Save(HttpContext.Current.Server.MapPath(fileName));
                return bmp;

            }
            catch
            {
                throw new Exception("Drawing an Image Exception");
            }
            finally
            {
                g.Dispose();
            }



        }
        public void DrawEmptyCheckBox(string fileName)
        {
            System.Drawing.Bitmap bmp = new Bitmap(20, 20);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            try
            {
                // System.Drawing.RectangleF rect = new System.Drawing.RectangleF(30, 30, 35, 35);
                Pen p = new Pen(System.Drawing.Color.Blue, 3.0f);
                g.Clear(System.Drawing.Color.White);
                g.DrawRectangle(p, 0, 0, bmp.Width, bmp.Height);

                //SizeF siz= g.MeasureString(txt, new System.Drawing.Font(FontFamily.GenericSansSerif, 10));
                bmp.Save(fileName);
                //return g;

            }
            catch
            {
                throw new Exception("Drawing an Image Exception");
            }
            finally
            {
                g.Dispose();
            }



        }
        public void saveImageText(string Text, string cat)
        {
            Bitmap bm = new Bitmap(80, 136);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(System.Drawing.Color.White);
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionVertical;
            sf.Alignment = StringAlignment.Center;
            System.Drawing.Font fnt = new System.Drawing.Font("Verdana", 11.0f, FontStyle.Bold, GraphicsUnit.Pixel, 8, true);
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(1, 1, 75, 135);
            Brush brGradient = new LinearGradientBrush(r, System.Drawing.Color.White, System.Drawing.Color.White, 150.0f, false);

            g.FillRectangle(brGradient, 1, 1, 80, 136);
            g.DrawRectangle(Pens.Black, 1, 1, 80, 136);
            g.TranslateTransform(40, 136);
            g.RotateTransform(180.0f);

            g.DrawString(Text, fnt, new SolidBrush(System.Drawing.Color.Black), r, sf);
            bm.Save(HttpContext.Current. Server.MapPath("~/Images/img" + cat + ".jpg"), ImageFormat.Jpeg);
            bm.Dispose();


        }
        public Cell ImageCellRowSpan(string imagepath, float imageWidth, float ImageHeight, iTextSharp.text.Color BorderColor, float fontSize, int rowspan)
        {
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagepath));
            img.BorderWidth = 0;
            img.BackgroundColor = iTextSharp.text.Color.WHITE;
            img.BorderColor = BorderColor;
            img.ScaleToFit(imageWidth, ImageHeight);

            Cell ECell = new Cell(img);
            ECell.Rowspan = rowspan;
            ECell.BorderColor = BorderColor;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public Cell ImageCell(string imagepath, float imageWidth, float ImageHeight, iTextSharp.text.Color BorderColor, float fontSize, int ColSpan)
        {
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagepath));
            img.BorderWidth = 0;
            img.BackgroundColor = iTextSharp.text.Color.WHITE;
            img.BorderColor = BorderColor;
            img.ScaleToFit(imageWidth, ImageHeight);

            Cell ECell = new Cell(img);
            ECell.Colspan = ColSpan;
            ECell.BorderColor = BorderColor;
            ECell.VerticalAlignment = Element.ALIGN_MIDDLE;
            ECell.HorizontalAlignment = Element.ALIGN_CENTER;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public Cell ImageCell(string imagepath, float imageWidth, float ImageHeight, iTextSharp.text.Color BorderColor, float fontSize)
        {
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagepath));
            img.BorderWidth = 0;
            img.BackgroundColor = iTextSharp.text.Color.WHITE;
            img.BorderColor = BorderColor;
            img.ScaleToFit(imageWidth, ImageHeight);

            Cell ECell = new Cell(img);

            ECell.BorderColor = BorderColor;
            ECell.VerticalAlignment = Element.ALIGN_MIDDLE;
            ECell.HorizontalAlignment = Element.ALIGN_CENTER;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public Cell ImageCell(string imagepath, float imageWidth, float ImageHeight, iTextSharp.text.Color BorderColor, float fontSize, int RowSpan, int ColSpan)
        {
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagepath));
            img.BorderWidth = 0;
            img.BackgroundColor = iTextSharp.text.Color.WHITE;
            img.BorderColor = BorderColor;
            img.ScaleToFit(imageWidth, ImageHeight);

            Cell ECell = new Cell(img);
            ECell.Colspan = ColSpan;
            ECell.Rowspan = RowSpan;
            ECell.VerticalAlignment = Element.ALIGN_MIDDLE;
            ECell.HorizontalAlignment = Element.ALIGN_CENTER;

            ECell.BorderColor = BorderColor;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public Cell ImageCellColSpan(string imagepath, float imageWidth, float ImageHeight, iTextSharp.text.Color BorderColor, float fontSize, int ColSpan)
        {
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagepath));
            img.BorderWidth = 0;
            img.BackgroundColor = iTextSharp.text.Color.WHITE;
            img.BorderColor = BorderColor;
            img.ScaleToFit(imageWidth, ImageHeight);

            Cell ECell = new Cell(img);
            ECell.Colspan = ColSpan;
            //ECell.Rowspan = RowSpan;
            ECell.VerticalAlignment = Element.ALIGN_MIDDLE;
            ECell.HorizontalAlignment = Element.ALIGN_CENTER;

            ECell.BorderColor = BorderColor;
            ECell.BorderWidth = 0.3f;
            return ECell;
        }
        public iTextSharp.text.Table EmptyTable(int columns, int rows, iTextSharp.text.Color bordercolor, float width)
        {
            iTextSharp.text.Table TEmpty = new iTextSharp.text.Table(columns);
            TEmpty.WidthPercentage = width;
            TEmpty.BorderColor = bordercolor;
            Paragraph PEmpty = new Paragraph("\n\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cell CEmpty = new Cell(PEmpty);

                    CEmpty.BorderColor = iTextSharp.text.Color.WHITE;
                    CEmpty.BorderWidth = 0.3f;

                    TEmpty.AddCell(CEmpty);
                }



            }
            return TEmpty;
        }
        public iTextSharp.text.Table Table(int columns, float tablewidthPercentage,iTextSharp.text.Color bordercolor)
        {
            iTextSharp.text.Table table = new iTextSharp.text.Table(columns);
            table.WidthPercentage = tablewidthPercentage;
            table.BorderWidth = 1;
            table.BorderColor = bordercolor;
            return table;
        }


#endregion
    }
}
