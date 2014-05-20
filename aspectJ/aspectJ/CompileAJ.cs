using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace aspectJ
{
    class CompileAJ
    {
        string filename;
        GetCalls getcalls = new GetCalls();
        public CompileAJ(string filename)
        {
            this.filename = filename + ".aj";
           // filename = "HelloAspect.aj";
        }

        public int CompileAndRun()
        {
            int re = WriteCompileFile();  //生成bat文件
            if (re == 0)
            {
                getcalls.RunCmd(@"compile.bat");  //运行compile.bat文件ajc编译
                getcalls.RunCmd(@"excution.bat");  //运行excution.bat文件java执行
                string projectpath = getcalls.ReadProjectFile().Item1;
                getcalls.Movefile(projectpath + "\\" + filename, filename);
            }
            else
            {
                return -1;
            }
            return 0;
        }
        public int WriteCompileFile()
        {
            string ins_ajc;
            string ins_java;
            try
            {
                string classpath = getcalls.ReadAJCProFile();
                string path = getcalls.ReadJavaProFile();
                string projectpath = getcalls.ReadProjectFile().Item1;
                string projectMain = getcalls.ReadProjectFile().Item2;

                //移动文件
                getcalls.Movefile(filename, projectpath + "\\" + filename);

                ins_ajc = @"ajc -1.7 -classpath " + classpath + @"\lib\aspectjrt.jar """ + projectpath + @"\*.aj"" """ + projectpath + @"\*.java""";
                //string ins_java = "\"" + path + "\\java.exe\"  -classpath " + classpath + @"\lib\aspectjrt.jar;""" + projectpath + @"\"" " + projectMain;
                ins_java = "\"" + path + "\\java.exe\"  -classpath " + classpath + @"\lib\aspectjrt.jar;""" + projectpath + @""" " + projectMain + " > log.txt";

                string strWriteFilePath = (@"compile.bat");
                StreamWriter srWriteFile = new StreamWriter(strWriteFilePath);
                string strWriteFilePath2 = (@"excution.bat");
                StreamWriter srWriteFile2 = new StreamWriter(strWriteFilePath2);
                srWriteFile.WriteLine(projectpath.Substring(0, 2));
                srWriteFile.WriteLine(@"cd " + projectpath);
                srWriteFile.WriteLine(ins_ajc);
                srWriteFile2.WriteLine(projectpath.Substring(0, 2));
                srWriteFile2.WriteLine(@"cd " + projectpath);
                srWriteFile2.WriteLine(ins_java);

                //srWriteFile2.WriteLine("pause");
                srWriteFile.Close();
                srWriteFile2.Close();


                return 0;
            }
            catch
            {
                return -1;
            }
        }

    }
}
