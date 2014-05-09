using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAspect
{
    class Pointcuts
    {
        public static List<string> pointcuts;

        public static void AddPointcut(string returnValue, string pointcutName, string pointcutKind, string regex) {
            string pointcutString = returnValue + " pointcut " + pointcutName + "(): " + pointcutKind + "(" + regex + ")\n";
            pointcuts = new List<string>();
            pointcuts.Add(pointcutString);
        }
        public static string getPointcuts(int index)
        {
            return pointcuts[index];
        }

        public static void delPointcutByIndex(int index)
        {
            pointcuts.RemoveAt(index);
        }
    }
}
