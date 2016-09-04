using System;
using System.IO;

namespace lab41
{
    public class Exec
    {
        private static void SearchFolders(string folderPath, string fileMask, string searchResult)
        {
            StreamWriter sw = new StreamWriter(searchResult, true);

            try
            {
                foreach (string filePath in Directory.GetFiles(folderPath, fileMask))
                {
                    Console.WriteLine(filePath);
                    sw.WriteLine(filePath);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Can't read {0}", folderPath);
                sw.Close();
                return;
            }

            sw.Close();

            foreach (string subFolderPath in Directory.GetDirectories(folderPath))
            {
                SearchFolders(subFolderPath, fileMask, searchResult);
            }
        }

        public static void Search(string searchResult)
        {
            Console.Write("folder: ");
            string folderPath = Console.ReadLine();

            if (folderPath.Length == 0)
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            Console.Write("mask: ");
            string fileMask = Console.ReadLine();

            SearchFolders(folderPath, fileMask, folderPath + "\\" + searchResult);
        }
    }
}

