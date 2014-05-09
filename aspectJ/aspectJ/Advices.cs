using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAspect
{
    class Advices
    {
        public static List<string> advices;

        public static void AddAdvice(string AdviceKind, string pointcutName)
        {
            string AdviceString = AdviceKind + " : " + pointcutName + "() {\n}";
            advices = new List<string>();
            advices.Add(AdviceString);

        }

        public static string getAdvices(int index)
        {
            return advices[index];
        }
        public static void delAdviceByIndex(int index)
        {
            advices.RemoveAt(index);
        }
    }
}
