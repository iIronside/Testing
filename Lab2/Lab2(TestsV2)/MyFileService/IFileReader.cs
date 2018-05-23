using System.Collections.Generic;


namespace MyFileService
{
    public interface IFileReader
    {
        void ReadFileNamesInList(List<string> strList, string path);
    }
}
