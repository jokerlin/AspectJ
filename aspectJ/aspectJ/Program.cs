using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace aspectJ
{
    class Program
    {
        public static List<String> fl = new List<string>();    //文件列表
        public static String mainfile;     //main函数所在文件名

        //搜索是否含有main函数
        private static bool HasMain(FileInfo file)
        {
            FileStream fi = new FileStream(file.FullName, FileMode.Open);
            StreamReader sr = new StreamReader(fi);
            String tmp;

            while (sr.Peek() != -1)
            {
                tmp = sr.ReadLine();
                if (tmp.Contains("public static void main")) return true;
            }
            return false;
        }

        public static void functionlist(String path)
        {
            DirectoryInfo DirFile = new DirectoryInfo(path);

            //将文件目录写入配置文件
          // FileStream fi = new FileStream(path+"/projectfile.ini", FileMode.OpenOrCreate);
           FileStream fi = new FileStream("./projectfile.ini", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fi);
            sw.WriteLine(path);

            //遍历文件
            FileSystemInfo[] files = DirFile.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                if (file != null)
                {
                    if (file.FullName.Substring(file.FullName.LastIndexOf(".")) == ".java")
                    {
                        fl.Add(file.Name);
                        if (HasMain(file)) sw.WriteLine(file.Name.Substring(0,file.Name.IndexOf(".")));
                    }
                }
            }
            sw.Close();
        }


        //static void Main(string[] args)
        //{
        //    String path = "E:\\Java_workspace\\Network\\src";
        //    functionlist(path);
        //    for (int i = 0; i < fl.Count; i++)
        //        Console.WriteLine(fl[i]);
        //    Console.Read();
        //}
    }
}
