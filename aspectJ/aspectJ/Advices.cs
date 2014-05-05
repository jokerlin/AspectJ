using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAspect
{
    class Advices
    {
        public List<string> advices;

        public void AddAdvice(string AdviceKind, string pointcutName)
        {
            string AdviceString = AdviceKind + " : " + pointcutName + "() {\n}";
            advices = new List<string>();
            advices.Add(AdviceString);
        }
    }
}
