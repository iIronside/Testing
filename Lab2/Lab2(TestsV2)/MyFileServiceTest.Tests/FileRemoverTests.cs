using NUnit.Framework;
using MyFileService;
using System.IO;
using System.Collections.Generic;


namespace MyFileServiceTest.Tests
{
    [TestFixture]
    public class FileRemoverTests
    {
        List<string> delFiles = new List<string>();
        List<string> fakeFilesList = new List<string>();
        List<string> errorStr = new List<string>();

        string file1 = "Text1.txt";
        string file2 = "Text2.txt";
        string file3 = "Text3.txt";

        string fakeFile1 = "Text101.txt";
        string fakeFile2 = "Text102.txt";
        string fakeFile3 = "Text103.txt";

        string dirPath = @"E:\My documents\Тестирование ПО\Lab2\dir";


        [OneTimeSetUp]
        public void CreatesFile()
        {
            File.Delete(Path.Combine(dirPath, "error.log"));

            File.Create(Path.Combine(dirPath, file1)).Close();
            File.Create(Path.Combine(dirPath, file2)).Close();
            File.Create(Path.Combine(dirPath, file3)).Close();

            delFiles.Add(file1);
            delFiles.Add(file2);
            delFiles.Add(file3);

            fakeFilesList.Add(fakeFile1);
            fakeFilesList.Add(fakeFile2);
            fakeFilesList.Add(fakeFile3);

            errorStr.Add("Файл " + fakeFile1 + " не был найден».");
            errorStr.Add("Файл " + fakeFile2 + " не был найден».");
            errorStr.Add("Файл " + fakeFile3 + " не был найден».");
        }

        [Test]
        public void DeleteFiles_fileNamesListAndDirPath_filesDeletedAndReturnSize()
        {
            FileRemover fileRemover = new FileRemover();

            long fSize = fileRemover.DeleteFiles(delFiles, dirPath);

            Assert.Multiple(() =>
            {
                FileAssert.DoesNotExist(Path.Combine(dirPath, file1));
                FileAssert.DoesNotExist(Path.Combine(dirPath, file2));
                FileAssert.DoesNotExist(Path.Combine(dirPath, file3));

                Assert.GreaterOrEqual(fSize, 0);
            });
        }

        [Test]
        public void DeleteFiles_fakeFileNamesListAndDirPath_createErrorFile()
        {
            FileRemover fileRemover = new FileRemover();

            fileRemover.DeleteFiles(fakeFilesList, dirPath);
            string[] errStr = File.ReadAllLines(Path.Combine(dirPath, "error.log"));

            Assert.Multiple(() =>
            {
                FileAssert.Exists(Path.Combine(dirPath, "error.log"));
                CollectionAssert.AreEqual(errStr, errorStr);
            });
        }
    }
}
