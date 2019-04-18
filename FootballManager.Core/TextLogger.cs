using FM.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FM.Core
{
    public class TextLogger : ILogger
    {
        public void Log()
        {
            string folderPath = ".\\Log\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            int fileCount = Directory.GetFiles(@".\\PDF").Length;
            string strFileName = "Logs"+".txt";

            //using (FileStream stream = new FileStream(folderPath + strFileName, FileMode.Create))
            //{
            //    Rectangle pageSize = new Rectangle(PageSize.A4);
            //    pageSize.BackgroundColor = new BaseColor(135, 206, 235);
            //    Document pdfDoc = new Document(pageSize);

            //    PdfWriter.GetInstance(pdfDoc, stream);
            //    pdfDoc.Open();
            //    pdfDoc.Add(footer);
            //    pdfDoc.Add(name);
            //    foreach (var table in playerTables)
            //    {
            //        table.SpacingBefore = 0;
            //        pdfDoc.Add(table);
            //    }
            //    pdfDoc.NewPage();

            //    pdfDoc.Close();
            //    stream.Close();
            //}

            throw new NotImplementedException();
        }
    }
}
