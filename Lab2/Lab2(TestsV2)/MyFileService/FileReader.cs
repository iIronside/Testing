using System.IO;
using System.Collections.Generic;


namespace MyFileService
{
    public class FileReader : IFileReader
    {
        public void ReadFileNamesInList(List<string> strList, string path)
        {
            StreamReader readFile = new StreamReader(path);

            while (!readFile.EndOfStream)
            {
                strList.Add(readFile.ReadLine());
            }
        }
    }
}
