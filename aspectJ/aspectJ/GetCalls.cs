using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspectJ
{
    class GetCalls
    {
        /// <summary>
        /// Enterance
        /// </summary>
        /// <returns>0==>Success,-1==>Fail</returns>
        public int Run()
        {
            int re = WriteCompileFile();  //生成bat文件
            if (re == 0)
            {
                RunCmd(@"compile.bat");  //运行compile.bat文件ajc编译
                RunCmd(@"excution.bat");  //运行excution.bat文件java执行
                string projectpath = ReadProjectFile().Item1;
                Movefile(projectpath + @"\CallInterceptor.aj", "CallInterceptor.aj");
                Movefile(projectpath + @"\CallLogger.java", "CallLogger.java");
                Movefile(projectpath + @"\calls.txt", "calls.txt");
                Movefile(projectpath + @"\sources.list", "sources.list");
            }
            else
            {
                return -1;
            }
            //RunCmd(@"compile.bat");
            //Process p = new Process();
            //p.StartInfo.FileName = @"C:\Users\linheng\Documents\aspectJ\aspectJ\bin\Debug\excution.bat"; //bat文件路径
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.CreateNoWindow = false;
            //p.StartInfo.RedirectStandardInput = true;
            //p.StartInfo.RedirectStandardOutput = true;
            //p.Start();
            //Console.ReadKey();
            return 0;
        }
        /// <summary>
        /// 读取ajcprofile.ini
        /// </summary>
        /// <returns></returns>
        public string ReadAJCProFile()
        {
            string strReadFilePath = @"ajcprofile.ini";
            StreamReader srReadFile = new StreamReader(strReadFilePath);
            string strReadLine = srReadFile.ReadLine();
            srReadFile.Close();
            return strReadLine;
        }
        /// <summary>
        /// 读取javaprofile.ini
        /// </summary>
        /// <returns></returns>
        public string ReadJavaProFile()
        {
            string strReadFilePath = @"javaprofile.ini";
            StreamReader srReadFile = new StreamReader(strReadFilePath);
            string strReadLine = srReadFile.ReadLine();
            srReadFile.Close();
            return strReadLine;
        }
        /// <summary>
        /// 读取projectprofile.ini
        /// </summary>
        /// <returns></returns>
        public Tuple<string, string> ReadProjectFile()
        {
            string strReadFilePath = (@"projectfile.ini");
            StreamReader srReadFile = new StreamReader(strReadFilePath);
            string projectFilePath = srReadFile.ReadLine();
            string projectMain = srReadFile.ReadLine();
            srReadFile.Close();
            var project = new Tuple<string, string>(projectFilePath, projectMain);
            return project;
        }

        /// <summary>
        /// 生成bat文件
        /// </summary>
        /// <returns>0==>Success,-1==>Fail</returns>
        public int WriteCompileFile()
        {
            string ins_ajc;
            string ins_java;
            try
            {
                string classpath = ReadAJCProFile();
                string path = ReadJavaProFile();
                string projectpath = ReadProjectFile().Item1;
                string projectMain = ReadProjectFile().Item2;
                
                if (projectpath.IndexOf("Fish") > -1)
                {
                    //移动文件
                    Movefile("CallInterceptor.aj", projectpath + @"\CallInterceptor.aj");
                    Movefile("CallLogger.java", projectpath + @"\CallLogger.java");
                    Movefile("sources.list", projectpath + @"\sources.list");

                    ins_ajc = @"ajc -d tmp @sources.list -cp ""lib\dom4j-1.6.1.jar;lib\kxml2.jar;lib\xmlpull_1_1_3_4c.jar;lib\jl1.0.jar;lib\jogg-0.0.7.jar;lib\jorbis-0.0.15.jar;lib\mp3spi1.9.4.jar;lib\tritonus_jorbis-0.3.6.jar;lib\tritonus_share.jar;C:\aspectj1.7\lib\aspectjrt.jar"" -1.7";
                    ins_java = @"java -cp tmp;lib\dom4j-1.6.1.jar;lib\kxml2.jar;lib\xmlpull_1_1_3_4c.jar;lib\jl1.0.jar;lib\jogg-0.0.7.jar;lib\jorbis-0.0.15.jar;lib\mp3spi1.9.4.jar;lib\tritonus_jorbis-0.3.6.jar;lib\tritonus_share.jar;C:\aspectj1.7\lib\aspectjrt.jar com.mypro.basecomponet.AwtMainComponet";

                }
                else if (projectpath.IndexOf("RaidenLite") > -1)
                {
                    Movefile("CallInterceptor.aj", projectpath + @"\CallInterceptor.aj");
                    Movefile("CallLogger.java", projectpath + @"\CallLogger.java");
                    Movefile("sources.list", projectpath + @"\sources.list");

                    ins_ajc = @"ajc -d src @sources.list -cp ""C:\aspectj1.7\lib\aspectjrt.jar"" -1.7";
                    ins_java = @"java -cp src;C:\aspectj1.7\lib\aspectjrt.jar cqu.GameFrame";
                }
                else if (projectpath.IndexOf("jsizer") > -1)
                {
                    Movefile("CallInterceptor.aj", projectpath + @"\CallInterceptor.aj");
                    Movefile("CallLogger.java", projectpath + @"\CallLogger.java");
                    Movefile("sources.list", projectpath + @"\sources.list");

                    ins_ajc = @"ajc -d tmp @sources.list -cp ""external_libs\asm-3.2.jar;external_libs\asm-commons-3.2.jar;external_libs\itext-2.0.4.jar;external_libs\batik-awt-util.jar;external_libs\batik-dom.jar;external_libs\batik-svggen.jar;external_libs\batik-util.jar;external_libs\batik-xml.jar;C:\aspectj1.7\lib\aspectjrt.jar"" -1.7";
                    ins_java = @"java -cp ""tmp;external_libs\asm-3.2.jar;external_libs\asm-commons-3.2.jar;external_libs\itext-2.0.4.jar;external_libs\batik-awt-util.jar;external_libs\batik-dom.jar;external_libs\batik-svggen.jar;external_libs\batik-util.jar;external_libs\batik-xml.jar;C:\aspectj1.7\lib\aspectjrt.jar"" org.khelekore.jsizer.Run";
                }
                else
                {
                    //移动文件
                    Movefile("CallInterceptor.aj", projectpath + @"\CallInterceptor.aj");
                    Movefile("CallLogger.java", projectpath + @"\CallLogger.java");

                    ins_ajc = @"ajc -1.7 -classpath " + classpath + @"\lib\aspectjrt.jar """ + projectpath + @"\*.aj"" """ + projectpath + @"\*.java""";
                    //string ins_java = "\"" + path + "\\java.exe\"  -classpath " + classpath + @"\lib\aspectjrt.jar;""" + projectpath + @"\"" " + projectMain;
                    ins_java = "\"" + path + "\\java.exe\"  -classpath " + classpath + @"\lib\aspectjrt.jar;""" + projectpath + @""" " + projectMain;
                }
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
        /// <summary>
        /// 执行bat
        /// </summary>
        /// <param name="command"></param>
        public void RunCmd(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.CreateNoWindow = true;//不显示dos命令行窗口
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.FileName = command;
            // Start the process
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);
            //proc.WaitForExit();
            // Attach the output for reading
            System.IO.StreamReader sOut = proc.StandardOutput;
            proc.Close();
            // Read the sOut to a string.
            string results = sOut.ReadToEnd().Trim();
            sOut.Close();
            //proc.Close();
            //return results;
        }

        public void Movefile(string sourceFile, string destinationFile)
        {
            try
            {
                System.IO.File.Move(sourceFile, destinationFile);
            }
            catch { }
        }
    }
}
