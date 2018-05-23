using System;


namespace MyFileService
{
    public class ReportViewer
    {
        public const int SIGNAL_OK = 1;
        public const int SIGNAL_STOP = SIGNAL_OK + 1;

        public long UsedSize;
        private readonly IFileService _fileService;

        public ReportViewer(IFileService fileService)
        {
            _fileService = fileService;
            UsedSize = -1;
        }

        public int Clean(string dirPath)
        {
            try
            {
                UsedSize = _fileService.RemoveTemporaryFiles(dirPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                return SIGNAL_STOP;
            }
            return SIGNAL_STOP;
        }
    }
}
