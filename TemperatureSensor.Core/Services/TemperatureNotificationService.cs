using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Upload;
using Newtonsoft.Json;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.Interfaces;
using TemperatureSensor.Core.InternalModels;
using File = Google.Apis.Drive.v3.Data.File;

namespace TemperatureSensor.Core.Services
{
    internal class TemperatureNotificationService : ITemperatureNotificationService
    {
        private readonly string PathToServiceAccountKey = "../key.json";

        private readonly string AccountEmail = "temperaturesensorservice@avid-theme-352412.iam.gserviceaccount.com";
        private readonly string Directory = "1kMzODBDotvTLaei_Ci01LltJAxetSDL3";

        private DriveService _service;
        ITemperatureSensorRepository _temperatureSensorRepository;
        public TemperatureNotificationService(ITemperatureSensorRepository temperatureSensorRepository)
        {
            _temperatureSensorRepository = temperatureSensorRepository;
            _service ??= CreateDriveService();
        }

        public async Task SendNotificationToDrive()
        {
            var sensorsReport = await CreateTemperatureSensorReport();

            var fileName = CreateLocalFile(sensorsReport);

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = $"{DateTime.UtcNow.ToShortDateString()}-{DateTime.UtcNow.ToShortTimeString()}",
                Parents = new List<string>(){ $"{Directory}" },
            };

            await UploadFileToDrive(fileName, fileMetadata);

            RemoveLocalFile(fileName);
        }

        private DriveService CreateDriveService()
        {
            var creditential = GoogleCredential.FromFile(PathToServiceAccountKey)
                .CreateScoped(DriveService.ScopeConstants.Drive);

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creditential
            });
        }

        private async Task<string> CreateTemperatureSensorReport()
        {
            var temperatureSensors = await _temperatureSensorRepository.GetTemperatureSensorsAsync(new GetTemperatureSensorsModel());

            return JsonConvert.SerializeObject(temperatureSensors, Formatting.Indented);
        }

        private string CreateLocalFile(string sensorsReport)
        {
            var localFileName = $"{DateTime.UtcNow.ToShortTimeString()}-report.json";
            using (var x = System.IO.File.Create($"{localFileName}"))
            {
                byte[] bytes = Encoding.ASCII.GetBytes(sensorsReport);
                x.Write(bytes);
            };
            return localFileName;
        }

        private async Task UploadFileToDrive(string fileName, File fileMetadata)
        {
            using (var fsSource = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var request = _service.Files.Create(fileMetadata, fsSource, "text/plain");
                var results = await request.UploadAsync(CancellationToken.None);

                if (results.Status == UploadStatus.Failed)
                {
                    Console.WriteLine($"Error uploading file: {results.Exception.Message}");
                }
            }
        }

        private void RemoveLocalFile(string fileName) => System.IO.File.Delete(fileName);
    }
}
