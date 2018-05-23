using NUnit.Framework;
using Moq;
using MyFileService;
using System.IO;


namespace MyFileServiceTest.Tests
{
    [TestFixture]
    public class ReportViewerTests
    {
        string dirPath = @"E:\My documents\Тестирование ПО\Lab2\dir";

        private readonly Mock<IFileService> mockIFService = new Mock<IFileService>();
        private readonly Mock<IFileService> stubIFService = new Mock<IFileService>();


        [Test]
        public void Clean_dirPath_CallRemoveTemporaryFiles()
        {
            var reportViewer = new ReportViewer(mockIFService.Object);

            reportViewer.Clean(dirPath);

            mockIFService.Verify(m => m.RemoveTemporaryFiles(dirPath), Times.Once);
        }

        [Test]
        public void Clean_dirPath_SetUsedSize()
        {
            long fakeSize = 9999;
            stubIFService.Setup(s => s.RemoveTemporaryFiles(It.IsAny<string>())).Returns(fakeSize);
            var reportViewer = new ReportViewer(stubIFService.Object);

            reportViewer.Clean(dirPath);

            Assert.That(reportViewer.UsedSize, Is.EqualTo(fakeSize));
        }

        [Test]
        public void Clean_exeption_Stop()
        {
            stubIFService.Setup(s => s.RemoveTemporaryFiles(It.IsAny<string>())).Throws(new DirectoryNotFoundException());
            var reportViewer = new ReportViewer(stubIFService.Object);

            int SIGNAL_CODE = reportViewer.Clean(It.IsAny<string>());

            Assert.That(Is.Equals(SIGNAL_CODE,2));
        }
    }
}
