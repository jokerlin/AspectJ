using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAspect
{
    class AspectGeneration
    {
        private string aspectCode;
        private string pointcutCode;
        private string adviceCode;

        public string GenerateAspectCode(List<string> pointcuts, List<string> advices, string aspectName) {
            foreach (string pointcut in pointcuts)
            {
                pointcutCode += pointcut;
            }
            foreach (string advice in advices)
            {
                adviceCode += advice;
            }
            adviceCode = "public aspect " + aspectName + "() {\n\t" + pointcutCode + adviceCode + "}\n";
            return adviceCode;
        }
    }
}
