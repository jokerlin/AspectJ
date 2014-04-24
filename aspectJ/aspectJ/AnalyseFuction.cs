using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aspectJ
{
    class AnalyseFuction
    {
        private List<Piece> pieceVer;
        private string filePath;

        public AnalyseFuction(string filePath)
        {
            this.filePath = filePath;
            pieceVer = new List<Piece>();
        }
        public void readFile()
        {
            // 读取文件的源路径及其读取流
            StreamReader srReadFile = new StreamReader(filePath);
            // 读取流直至文件末尾结束
            while (!srReadFile.EndOfStream)
            {
                string strReadLine = srReadFile.ReadLine(); //读取每行数据
                analyse(strReadLine);
                Console.WriteLine(strReadLine); //屏幕打印每行数据
            }
            // 关闭读取流文件
            srReadFile.Close();
        }
        public void analyse(string line)
        {
            string regClassName = @"(?<ClassName>[A-Z][A-Za-z0-9_]*).";
            string regFucName = @"(?<FucName>[A-Za-z_][A-Za-z0-9_]*)\s+";
            string regBool = @"(?<Bool>(1|0))";
            string regArg = @"";
            string regString = regClassName + regFucName + regBool + regArg;
            if (Regex.IsMatch(line, regString))
            {
                Match mc = Regex.Match(line, regString);
                string className = mc.Groups["ClassName"].Value.ToString();
                string fucName = mc.Groups["FucName"].Value.ToString();
                string binNumber = mc.Groups["Bool"].Value.ToString();
                Piece piece = new Piece();
                piece.className = className;
                piece.functionName = fucName;

                if (Int16.Parse(binNumber) == 0)
                {
                    piece.status = false;
                }
                if (Int16.Parse(binNumber) == 1)
                {
                    piece.status = true;
                }

                pieceVer.Add(piece);
            }
        }
        public List<Piece> getPieceList()
        {
            return pieceVer;
        }
    }
}
