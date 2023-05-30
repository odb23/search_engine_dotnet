using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;
using System.Reflection;
using System.Text.Json;

namespace SearchEngine.API
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration Configuration;
        private readonly string dbPath = "db.json";
        public DbDocument DbDocument { get; private set; }

        public DbContext(IConfiguration configuration)
        {
            this.Configuration = configuration;

            var _dbDoc = LoadDatabase();

            if (_dbDoc != null)
            {
                this.DbDocument = _dbDoc;
            }
            else
            {
                this.InitDbDocument();
            }

        }

        private string GetSerializedDbDocument
        {
            get
            {
                return JsonSerializer.Serialize<DbDocument>(this.DbDocument, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
        }

        public void InitDbDocument()
        {
            this.DbDocument = new DbDocument();
            this.SaveDatabase();
        }
        private string GetDataSourcePath()
        {
            var confDSPath = this.Configuration["Database"];

            if (!string.IsNullOrEmpty(confDSPath))
            {
                return confDSPath;
            }

            return Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!;
        }

        public DbDocument LoadDatabase()
        {
            string directoryPath = Path.Join(GetDataSourcePath(), dbPath);
            string jsonString = File.ReadAllText(directoryPath);

            // Deserialize the JSON to an object
            return JsonSerializer.Deserialize<DbDocument>(jsonString)!;
        }
        public void SaveDatabase()
        {
            string directoryPath = Path.Join(GetDataSourcePath(), dbPath);
            File.WriteAllText(directoryPath, this.GetSerializedDbDocument);
        }

    }
}
