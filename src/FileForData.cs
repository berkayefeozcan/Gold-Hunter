using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altın_Toplama_Oyunu
{
    public class FileForData
    {

        static string fileName = "data.txt";
        static string path = Path.Combine(Environment.CurrentDirectory, fileName);


        // Write file using StreamWriter 
        public FileForData()
        {

        }

        public static void writeToFile(string pathToWrite)
        {


            if (!File.Exists(path))
            {
                var myFile = File.Create(path);
                myFile.Close();
            }


            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(pathToWrite);
            }
        }

        internal static void clearFile()
        {
            if (File.Exists(path))
            {
                using (var writer = new StreamWriter(path))
                {

                    writer.WriteLine("");

                }
            }

        }
    }
}
