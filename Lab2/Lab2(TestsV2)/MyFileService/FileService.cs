using System.IO;
using System.Collections.Generic;


namespace MyFileService
{
    public class FileService : IFileService
    {
        private readonly IFileReader fileReader;
        private readonly IFileRemover fileRemover;

        string searchedFile;
        long sizeDeletedFiles;
        List<string> fileNamesList = new List<string>();

        public FileService(string filePath, IFileReader iFileReader, IFileRemover iFileRemover)
        {
            fileReader = iFileReader;
            fileRemover = iFileRemover;

            this.searchedFile = filePath; 
            sizeDeletedFiles = -1;
        }

        public long RemoveTemporaryFiles(string dir)
        {
            if (Directory.Exists(dir))
            {
                string path = Path.Combine(dir, searchedFile);
                if (File.Exists(path))
                {
                    fileReader.ReadFileNamesInList(fileNamesList, path);
                    sizeDeletedFiles = fileRemover.DeleteFiles(fileNamesList, dir);
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            else
            {
                throw new DirectoryNotFoundException();
            }

            return sizeDeletedFiles;
        }
    }
}
