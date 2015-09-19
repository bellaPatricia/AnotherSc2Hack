namespace Utilities.Events
{
    public delegate void DownloadManagerProgressHandler(object sender, DownloadManagerProgressChangedEventArgs e);

    public class DownloadManagerProgressChangedEventArgs
    {
        public long TotalBytes { get; set; }
        public long ReceivedBytes { get; set; }
        public int PercentageCompleted { get; set; }
        public string FileName { get; set; }

        public DownloadManagerProgressChangedEventArgs(string fileName, long totalBytes, long receivedBytes,
            int percentageCompleted)
        {
            TotalBytes = totalBytes;
            FileName = fileName;
            ReceivedBytes = receivedBytes;
            PercentageCompleted = percentageCompleted;
        }
    }
}
