using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAspect
{
    class Pointcuts
    {
        public List<string> pointcuts;

        public void AddPointcut(string returnValue, string pointcutName, string pointcutKind, string regex) {
            string pointcutString = returnValue + " pointcut " + pointcutName + "(): " + pointcutKind + "(" + regex + ")\n";
            pointcuts = new List<string>();
            pointcuts.Add(pointcutString);
        }
        public string getPointcuts(int index)
        {
            return pointcuts[index];
        }

        public void delPointcutByIndex(int index)
        {
            pointcuts.RemoveAt(index);
        }
    }
}
