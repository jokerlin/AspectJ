using aspectJ;
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

        public static string GenerateAspectCode(List<Pointcut> pointcuts, List<Advice> advices, string aspectName) {
            AspectName = aspectName;
            foreach (Pointcut pointcut in pointcuts)
            {
                pointcutCode += pointcut.pointcutString;
            }
            foreach (Advice advice in advices)
            {
                adviceCode += advice.adviceString;
            }
            aspectCode = "public aspect " + aspectName + "() {\n\t" + pointcutCode + adviceCode + "}\n";
            return aspectCode;
        }
    }
}
