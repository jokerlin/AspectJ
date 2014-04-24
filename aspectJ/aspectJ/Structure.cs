using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;

namespace aspectJ
{
    public class Piece
    {
        public string className;
        public string functionName;
        public bool status, isChildTreeHidden,isHidden,isHighlight;
        public int depth;

        public Point topLeftCorner;

        public int sonNum;
        public Point sumPoint;

        public Piece()
        {
            sonNum = 0;
            sumPoint = new Point(0, 0);
            topLeftCorner = new Point();
            isChildTreeHidden = false;
            isHidden = false;
            isHighlight = false;
        }
    }
}