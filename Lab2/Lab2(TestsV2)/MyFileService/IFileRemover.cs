using System.Collections.Generic;


namespace MyFileService
{
    public interface IFileRemover
    {
        long DeleteFiles(List<string> delFileNameList, string dirPath);
    }
}
