﻿using aspectJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAspect
{
    class Advices
    {
        public static List<Advice> advices;

        public void Advices()
        {
            advices = new List<Advice>();
        }
        public static void AddAdvice(string AdviceKind, string pointcutName, string adviceCode)
        {
            Advice advice = new Advice();
            advice.adviceName = AdviceKind + " : " + pointcutName + "()";
            advice.adviceCode = adviceCode;
            string AdviceString = advice.adviceName + "{\n" + advice.adviceCode + "\n}\n";
            advice.adviceString = AdviceString;

            advices.Add(advice);

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
