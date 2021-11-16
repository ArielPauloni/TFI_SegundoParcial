using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using BE;
using System.Web.UI.WebControls;
using System.Data;

public class ReportePDF
{
    public static void GuardarPDF(string filePath, string headerText, string subHeaderText,
                           string textoLibre, DataTable dt, string totalACobrar, string pageFormatStr)
    {
        try
        {
            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A4, false);

            document.ShowTextAligned(new Paragraph(String
                   .Format("TFI - Segundo Parcial")),
                    35, 806, 1, TextAlignment.LEFT,
                    VerticalAlignment.TOP, 0);
            document.ShowTextAligned(new Paragraph(String
                   .Format(DateTime.Now.ToString("dd/MM/yyyy"))),
                    559, 806, 1, TextAlignment.RIGHT,
                    VerticalAlignment.TOP, 0);
            //*****************************************************//
            // New line
            Paragraph newline = new Paragraph(new Text("\n"));
            document.Add(newline);
            //*****************************************************//
            //Título:
            Paragraph header = new Paragraph(headerText.ToUpper().Replace('_', ' '))
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(18);
            header.SetBold();
            document.Add(header);
            //*****************************************************//
            //Subtítulo:
            Paragraph subheader = new Paragraph(subHeaderText)
                 .SetTextAlignment(TextAlignment.CENTER)
                 .SetFontSize(13);
            document.Add(subheader);
            //*****************************************************//
            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);
            //*****************************************************//
            // Add paragraph1
            Paragraph paragraph1 = new Paragraph(textoLibre);
            document.Add(paragraph1);
            //*****************************************************//
            // Table
            if (dt.Rows.Count > 0)
            {
                int numCol = dt.Columns.Count;
                string colName = string.Empty;
                iText.Layout.Element.Table table = new iText.Layout.Element.Table(numCol, false);

                //Seteo los encabezados:
                for (int i = 0; i < 1; i++)
                {
                    DataRow myRow = dt.Rows[i];
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Cell cell = new Cell(1, 1)
                           .SetBackgroundColor(ColorConstants.GRAY)
                           .SetTextAlignment(TextAlignment.CENTER)
                           .Add(new Paragraph(dt.Columns[j].ColumnName));
                        table.AddCell(cell);
                    }
                }

                //Seteo los datos:
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow myRow = dt.Rows[i];
                    for (int j = 0; j < dt.Columns.Count; j++) { table.AddCell(myRow.ItemArray[j].ToString()); }
                }

                table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                document.Add(table);
            }

            Paragraph paragraph2 = new Paragraph(totalACobrar);
            document.Add(paragraph2);
            document.Add(newline);
            //*****************************************************//
            // Page numbers
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                   .Format(pageFormatStr, i, n)),
                    559, 15, i, TextAlignment.RIGHT,
                    VerticalAlignment.BOTTOM, 0);
                document.ShowTextAligned(new Paragraph(String
                   .Format("©Ariel Pauloni")),
                    35, 15, i, TextAlignment.LEFT,
                    VerticalAlignment.BOTTOM, 0);
            }
            //*****************************************************//
            document.Close();
            System.Diagnostics.Process.Start("chrome.EXE", filePath);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
