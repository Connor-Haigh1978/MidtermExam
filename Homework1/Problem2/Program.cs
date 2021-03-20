using System;
using System.IO;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give file path");

            string path = Console.ReadLine();

            if (Directory.Exists(path) == false)
            {
                Console.WriteLine("Enter correct path");
                Console.ReadLine();
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach ( var files in directoryInfo.GetFiles())
            {
                Console.WriteLine(files.Name);
            }
        }
    }
}
