using GenerateAspect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace aspectJ
{
    class GenerateAJFile
    {
        public static void generateAJFile()
        {
            string fileName = AspectGeneration.AspectName + ".aj";
            StreamWriter swWriteFile = File.CreateText(fileName);
            swWriteFile.Write(AspectGeneration.aspectCode);

            swWriteFile.Close();
        }
    }
}
