using aspectJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspectJ
{
    class Advices
    {
        public static List<Advice> advices=new List<Advice>();

        //public void Advices()
        //{
        //    advices = new List<Advice>();
        //}
        public static void AddAdvice(string AdviceKind, string pointcutName, string adviceCode)
        {
            Advice advice = new Advice();
            advice.adviceName = AdviceKind + " : " + pointcutName + "()";
            advice.adviceCode = adviceCode;
            advice.advicePointcutKind = AdviceKind;
            advice.advicePointcutName = pointcutName;
            string AdviceString = advice.adviceName + "{\n" + advice.adviceCode + "\n}\n";
            advice.adviceString = AdviceString;

            advices.Add(advice);

        }

        public static void EditAdvice(int index, string AdviceKind, string pointcutName, string adviceCode)
        {
            advices[index].adviceName = AdviceKind + " : " + pointcutName + "()";
            advices[index].adviceCode = adviceCode;
            advices[index].advicePointcutKind = AdviceKind;
            advices[index].advicePointcutName = pointcutName;
            string AdviceString = advices[index].adviceName + "{\n" + advices[index].adviceCode + "\n}\n";
            advices[index].adviceString = AdviceString;
        }

        public static Advice getAdvices(int index)
        {
            return advices[index];
        }
        public static void delAdviceByIndex(int index)
        {
            advices.RemoveAt(index);
        }
    }
}
