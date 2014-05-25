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
        public static List<FileInfo> fl = new List<FileInfo>();    //文件列表
        public static FileInfo mainfile;     //main函数所在文件
        public static string curFileNamepath;

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

        //递归遍历文件目录
        public static void list(FileSystemInfo info)
        {
            if (!info.Exists) return;
            DirectoryInfo DirFile = info as DirectoryInfo; 
            FileSystemInfo[] files = DirFile.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                if (file != null)
                {
                    //我改动过
                    if (file.FullName.LastIndexOf(".")>=0 && file.FullName.Substring(file.FullName.LastIndexOf(".")) == ".java")
                    {
                        fl.Add(file);
                        if (HasMain(file)) mainfile = file;
                    }
                }
                else list(files[i]);
            }
        }

        public static void functionlist(string path)
        {
            //将文件目录写入配置文件
            fl.Clear();
            curFileNamepath = path;
            FileStream fi = new FileStream("projectfile.ini", FileMode.OpenOrCreate);//改动过
            StreamWriter sw = new StreamWriter(fi);
            sw.WriteLine(path);
            list(new DirectoryInfo(path));
            sw.WriteLine(mainfile.Name.Substring(0, mainfile.Name.IndexOf(".")));
            sw.Close();
        }

        //根据文件名获取路径
        public static string search(string name)
        {
            for (int i = 0; i < fl.Count; i++)
                if (fl[i].Name.Equals(name)) return fl[i].FullName;
            return "";
        }


        //static void Main(string[] args)
        //{
        //    string path = "E:\\Java_workspace\\FishGame\\src";
        //    functionlist(path);
        //    for (int i = 0; i < fl.Count; i++)
        //        Console.WriteLine(fl[i].Name);
        //    Console.Read();
        //}
    }
}
