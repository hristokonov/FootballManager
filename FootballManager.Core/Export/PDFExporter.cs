using FM.Core.Contracts;
using FM.Data.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FM.Core.Export
{
    public class PDFExporter : IPDFExporter

    {
        public void GeneratePlayersPDF(IEnumerable<Player> players)
        {
            try
            {
                PdfPTable footer = new PdfPTable(1);
                PdfPTable name = new PdfPTable(1);
                var boldFont = FontFactory.GetFont(FontFactory.TIMES_BOLD, 16);

                
                Chunk c1 = new Chunk("ALL PLAYERS", boldFont);
                footer.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                footer.DefaultCell.Border = 0;
                footer.AddCell(new Phrase(c1));

                var playerTables = new List<PdfPTable>();
                var currentTable = 0;
                playerTables.Add(new PdfPTable(6));
                playerTables[currentTable].AddCell("");
                playerTables[currentTable].AddCell("First Name");
                playerTables[currentTable].AddCell("Last Name");
                playerTables[currentTable].AddCell("Position");
                playerTables[currentTable].AddCell("Rating");
                playerTables[currentTable].AddCell("Price");
                foreach (var player in players.OrderByDescending(p=>p.Rating).ThenBy(p=>p.FirstName))
                {
                    playerTables.Add(new PdfPTable(6));
                    currentTable++;
                    playerTables[currentTable].AddCell($"{currentTable}");
                    playerTables[currentTable].AddCell($"{player.FirstName}");
                    playerTables[currentTable].AddCell($"{player.LastName}");
                    playerTables[currentTable].AddCell($"{player.Position.Name}");
                    playerTables[currentTable].AddCell($"{player.Rating}");
                    playerTables[currentTable].AddCell($"{player.Price}");
                }

                //Set up file name and directory
                string folderPath = ".\\PDF\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                int fileCount = Directory.GetFiles(@".\\PDF").Length;
                string strFileName = "AllPlayers" + (fileCount + 1) + ".pdf";

                using (FileStream stream = new FileStream(folderPath + strFileName, FileMode.Create))
                {
                    Rectangle pageSize = new Rectangle(PageSize.A4);
                    pageSize.BackgroundColor = new BaseColor(135,206,235);
                    Document pdfDoc = new Document(pageSize);

                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(footer);
                    pdfDoc.Add(name);
                    foreach (var table in playerTables)
                    {
                        table.SpacingBefore = 0;
                        pdfDoc.Add(table);
                    }
                    pdfDoc.NewPage();

                    pdfDoc.Close();
                    stream.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Cannot export to PDF");
            }
        }
    }
}
