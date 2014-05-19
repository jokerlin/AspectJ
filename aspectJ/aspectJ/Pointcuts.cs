using aspectJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAspect
{
    class Pointcuts
    {
        public static List<Pointcut> pointcuts;
        //public static List<string> pointcutNames;

        public static void Pointcuts() {
            pointcuts = new List<Pointcut>();
        }
        public static void AddPointcut(string returnValue, string pointcutName, string pointcutKind, string regex) {
            Pointcut newPointcut = new Pointcut();
            newPointcut.returnValue = returnValue;
            newPointcut.pointcutName = pointcutName;
            newPointcut.pointcutKind = pointcutKind;
            newPointcut.regex = regex;
            string pointcutString = returnValue + " pointcut " + pointcutName + "(): " + pointcutKind + "(" + regex + ")\n";
            pointcuts.Add(newPointcut);
        }

        public static void EditPointcut(int index, string returnValue, string pointcutName, string pointcutKind, string regex)
        {
            Pointcut newPointcut = new Pointcut();
            newPointcut = pointcuts[index];
            newPointcut.returnValue = returnValue;
            newPointcut.pointcutName = pointcutName;
            newPointcut.pointcutKind = pointcutKind;
            newPointcut.regex = regex;
        }
        public static Pointcut getPointcuts(int index)
        {
            return pointcuts[index];
        }

        public static string getPointcutName(int index)
        {
            return pointcuts[index].pointcutName;
        }

        public static void delPointcutByIndex(int index)
        {
            pointcuts.RemoveAt(index);
        }
    }
}
