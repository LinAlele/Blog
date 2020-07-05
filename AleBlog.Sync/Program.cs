using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AleBlog.Sync
{
    class Program
    {
        public static Dictionary<string, string> dic { get; set; } = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            //同步文件夹内md文件到博客
            var watcher = new FileSystemWatcher(@"D:\代码库\文档\test");
            watcher.EnableRaisingEvents = true; //启用FileSystemWatcher
            watcher.Filter = "*.md";
            Console.WriteLine(watcher.NotifyFilter);

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
           
            Console.ReadKey();

        }

        private static void OnNotifyFilter(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0}:{1}", e.ChangeType, e.Name);
        }

        /// <summary>
        ///   //文章被修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileDisplayAction(action: () =>
            {
               
                FileInfo file = new FileInfo(e.FullPath);
                string WriteDate =  file.LastWriteTime.ToString("yyyyMMddHHmmss");
                if(!dic.ContainsKey(file.Name))
                    dic.Add(e.Name, WriteDate);
                if (dic[file.Name] == WriteDate)
                {
                    //重复文件
                    return;
                }
                else
                {
                    dic[file.Name] = WriteDate;
                }
                Console.WriteLine("{0}:{1}:{2}", e.ChangeType, e.Name, WriteDate);
                FileStream file_Page = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader sr = new StreamReader(file_Page, Encoding.UTF8))
                {
                    Console.WriteLine( sr.ReadToEndAsync().Result);
                    sr.Close();
                    sr.Dispose();
                }
                
            }, fileName: (e.Name));
        }
        /// <summary>
        ///    //文章被删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            FileDisplayAction(action: () =>
            {
                Console.WriteLine("{0}:{1}", e.ChangeType, e.Name);
            }, fileName: (e.Name));
        }
        /// <summary>
        /// //文章被创建但未写文章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            FileDisplayAction(action: () =>
            {
                Console.WriteLine("{0}:{1}", e.ChangeType, e.Name);
            }, fileName: (e.Name));
        }
        /// <summary>
        /// //文章名修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            FileDisplayAction(action: () =>
            {
                Console.WriteLine("{0}:原文件名{1},新文件名{2}", e.ChangeType, e.OldName, e.Name);
            }, fileName: (e.Name));
        }
        public static void FileDisplayAction(Action action,string fileName)
        {
            if(fileName.First()!='.')
                action();
        }

    }
}
