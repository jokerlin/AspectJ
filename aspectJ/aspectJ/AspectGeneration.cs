using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspectJ
{
    class AspectGeneration
    {
        public static string aspectCode;
        private static string pointcutCode;
        private static string adviceCode;
        public static string AspectName;

        public static string GenerateAspectCode(List<string> pointcuts, List<string> advices, string aspectName) {
            AspectName = aspectName;
            foreach (string pointcut in pointcuts)
            {
                pointcutCode += pointcut;
            }
            foreach (string advice in advices)
            {
                adviceCode += advice;
            }
            aspectCode = "public aspect " + aspectName + "() {\n\t" + pointcutCode + adviceCode + "}\n";
            return aspectCode;
        }
    }
}
