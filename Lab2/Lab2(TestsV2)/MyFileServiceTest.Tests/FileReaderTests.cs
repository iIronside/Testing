using NUnit.Framework;
using MyFileService;
using System.Collections.Generic;


namespace MyFileServiceTest.Tests
{
    [TestFixture]
    public class FileReaderTests
    {
        string filePath = @"E:\My documents\Тестирование ПО\Lab2\dir\ToRemove.txt";

        List<string> controlList = new List<string>();


        [OneTimeSetUp]
        public void Init()
        {
            controlList.Add("FakeText10.txt");
            controlList.Add("FakeText11.txt");
            controlList.Add("FakeText12.txt");
        }

        [Test]
        public void ReadFileNamesInList_pathAndList_writeInList()
        {
            List<string> fileNames = new List<string>();
            FileReader fReader = new FileReader();

            fReader.ReadFileNamesInList(fileNames, filePath);

            Assert.That(fileNames, Is.EqualTo(controlList));
        }
    }
}
