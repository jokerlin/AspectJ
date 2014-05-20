using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace aspectJ
{
    class GetFlowDocument
    {
        public static FlowDocument getFlowDocument(string path)
        {
            FlowDocument flowDocument = new FlowDocument();
            
            StreamReader srReadFile = new StreamReader(path,Encoding.GetEncoding("GBK") );

            while (!srReadFile.EndOfStream)
            {
                string strReadLine = srReadFile.ReadLine();
                var p = new Paragraph();
                var r = new Run(strReadLine);
                p.Inlines.Add(r);
                flowDocument.Blocks.Add(p);
            }
            srReadFile.Close();
            return flowDocument;
        }
    }
}
