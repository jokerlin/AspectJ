using aspectJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspectJ
{
    class Pointcuts
    {
        public static List<Pointcut> pointcuts=new List<Pointcut>();
        //public static List<string> pointcutNames;

        //public static void Pointcuts() {
        //    pointcuts = new List<Pointcut>();
        //}
        public static void AddPointcut(string returnValue, string pointcutName, string pointcutKind, string regex) {
            Pointcut newPointcut = new Pointcut();
            newPointcut.returnValue = returnValue;
            newPointcut.pointcutName = pointcutName;
            newPointcut.pointcutKind = pointcutKind;
            newPointcut.regex = regex;
            string pointcutString = returnValue + " pointcut " + pointcutName + "(): " + pointcutKind + "(" + regex + ")\n";
            newPointcut.pointcutString = pointcutString;
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

        public static string getCode(int index)
        {
            string pointcutString = pointcuts[index].returnValue + " pointcut " + pointcuts[index].pointcutName + "(): " + pointcuts[index].pointcutKind + "(" + pointcuts[index].regex + ")\n";
            return pointcutString;
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
