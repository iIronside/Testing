using NUnit.Framework;
using Moq;
using MyFileService;
using System.IO;
using System.Collections.Generic;


namespace MyFileServiceTest.Tests
{
    [TestFixture]
    public class FileServiceTests
    {   // проверить с "падающими" классами чтения и удаления
        long size = 40000;

        string removFile = @"ToRemove.txt";
        string fakeRemovFile = @"FakeToRemove.txt";

        string dirPath = @"E:\My documents\Тестирование ПО\Lab2\dir";
        string fakeDirPath = @"E:\My documents\Тестирование ПО\Lab2\dir2222222222";

        private readonly Mock<IFileRemover> stubFRemover = new Mock<IFileRemover>();

        private readonly Mock<IFileReader> dummyFReader = new Mock<IFileReader>();
        private readonly Mock<IFileRemover> dummyFRemover = new Mock<IFileRemover>();


        [Test]
        public void RemoveTemporaryFiles_dirPath_ReturnValue()
        {
            stubFRemover.Setup(s => s.DeleteFiles(new List<string>(), It.IsAny<string>())).Returns(40000);
            FileService fileService = new FileService(removFile, dummyFReader.Object, stubFRemover.Object);

            long useSize = fileService.RemoveTemporaryFiles(dirPath);

            Assert.AreEqual(useSize, size);
        }

        [Test]
        public void RemoveTemporaryFiles_fakeDirPath_Exception()
        {
            Assert.Throws<DirectoryNotFoundException>(() =>
            {
                FileService fileService = new FileService(removFile, dummyFReader.Object, dummyFRemover.Object);

                fileService.RemoveTemporaryFiles(fakeDirPath);
            });
        }

        [Test]
        public void RemoveTemporaryFiles_fakeSearchedFile_exception()
        {
            Assert.Throws<FileNotFoundException>(() =>
            {
                FileService fileService = new FileService(fakeRemovFile, dummyFReader.Object, dummyFRemover.Object);

                fileService.RemoveTemporaryFiles(dirPath);
            });
        }
    }
}