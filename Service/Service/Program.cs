using System;
using System.IO;
using System.ServiceProcess;

namespace Service
{
    class Program
    {
        private static readonly string filename = @"C:\Users\Public\Documents\service.txt";

        static void Main(string[] args)
        {
            CreateFile();
            using (var service = new LoggerService(filename))
            {
                ServiceBase.Run(service);
            }
        }

        private static void CreateFile()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename);
            }
        }
    }
}
