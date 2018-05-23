using System;
using System.IO;
using System.Collections.Generic;


namespace MyFileService
{
    public class FileRemover : IFileRemover
    {
        List<string> fileNemes = new List<string>();
        string logFile = @"error.log";

        public long DeleteFiles(List<string> delFileNameList, string dirPath)
        {
            long sizeDelFiles = 0;
            string bufPath;

            foreach (var fileName in delFileNameList)
            {
                bufPath = Path.Combine(dirPath, fileName);
                if (File.Exists(bufPath))
                {
                    sizeDelFiles += new FileInfo(bufPath).Length;
                    File.Delete(bufPath);
                }
                else
                {
                    fileNemes.Add(fileName);
                }
            }
            if (fileNemes.Count != 0)
            {
                WriteLogInFile(dirPath);
            }
            return sizeDelFiles;
        }

        void WriteLogInFile(string path)
        {
            StreamWriter writeFile = null;
            try
            {
                writeFile = File.CreateText(Path.Combine(path, logFile));
                foreach (var fileName in fileNemes)
                {
                    writeFile.WriteLine("Файл " + fileName + " не был найден».");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                if (writeFile != null)
                    writeFile.Close();
            }
        }
    }
}
