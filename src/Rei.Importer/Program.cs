using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Rei.Importer
{
    class Program
    {
        /// <summary>
        /// http://rei.to/random.html
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            string sourceDir = Path.Combine(currentDirectory, args[0]);
            string destDir = Path.Combine(currentDirectory, args[1]);

            Console.WriteLine("Source directory: {0}", sourceDir);
            Console.WriteLine("Destination directory: {0}", destDir);

            var files = new List<string>(ConfigurationManager.AppSettings["sourceFiles"].Split(','));

            foreach (var file in files)
            {
                Console.WriteLine("Copying {0}", file);

                using (var inStream = new FileStream(Path.Combine(sourceDir, file), FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(inStream, Encoding.GetEncoding(932)))
                using (var outStream = File.Open(Path.Combine(destDir, file), FileMode.Create, FileAccess.Write))
                using (var writer = new StreamWriter(outStream, Encoding.Unicode))
                {
                    while (!reader.EndOfStream)
                    {
                        writer.WriteLine(reader.ReadLine());
                    }
                }
            }
        }
    }
}
