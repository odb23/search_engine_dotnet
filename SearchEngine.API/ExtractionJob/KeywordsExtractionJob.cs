using Quartz;
using SearchEngine.API.Interfaces;

namespace SearchEngine.API.ExtractionJob
{
    public class FileContentExtractorJob : IJob
    {
        private readonly ILogger<FileContentExtractorJob> _logger;
        private readonly string _directoryPath;
        private readonly IIndexer indexer;

        public FileContentExtractorJob(ILogger<FileContentExtractorJob> logger, IIndexer ind)
        {
            _logger = logger;
            _directoryPath = Path.Join(GetDataSourcePath(), "Files");
            indexer = ind;
        }

        private string GetDataSourcePath()
        {
            var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

            string? confDSPath = configuration.GetValue<string>("Database");

            if (!string.IsNullOrEmpty(confDSPath))
            {
                return confDSPath;
            }
            string dir = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");

            _logger.LogInformation("projDir: ", dir);
            return Path.Join(dir, "Database");
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogInformation("Starting File Extraction at " + _directoryPath);
                var files = Directory.GetFiles(_directoryPath);
                foreach (var filePath in files)
                {
                    var fileName = Path.GetFileName(filePath);
                    try
                    {
                        indexer.IndexDocument(filePath);
                    }
                    catch (Exception _ex)
                    {
                        _logger.LogError(_ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Task.FromResult(false);
            }
            finally
            {
                _logger.LogInformation("Ends File Extraction at.");
            }

            return Task.FromResult(true);
        }
    }
}