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
        public static List<string> pointcutNames;

        public static void Pointcuts() {
            pointcuts = new List<string>();
            pointcutNames = new List<string>();
        }
        public static void AddPointcut(string returnValue, string pointcutName, string pointcutKind, string regex) {
            string pointcutString = returnValue + " pointcut " + pointcutName + "(): " + pointcutKind + "(" + regex + ")\n";
            pointcutNames.Add(pointcutName);
            pointcuts.Add(pointcutString);
        }
        public static string getPointcuts(int index)
        {
            return pointcuts[index];
        }

        public static string getPointcutName(int index)
        {
            return pointcutNames[index];
        }

        public static void delPointcutByIndex(int index)
        {
            pointcuts.RemoveAt(index);
        }

        public static List<string> getPointcutNames()
        {
            return pointcutNames;
        }
    }
}
