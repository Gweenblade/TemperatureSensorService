using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using TemperatureSensor.Core.Interfaces;

namespace TemperatureSensor.Core.Services
{
    internal class TemperatureNotificationService : ITemperatureNotificationService
    {
        private readonly string PathToServiceAccountKey =
            "C:\\Users\\kryst\\OneDrive\\Desktop\\Predica\\TemperatureSensorService\\TemperatureSensor.Core\\key.json";

        private readonly string AccountEmail = "temperaturesensorservice@avid-theme-352412.iam.gserviceaccount.com";

        private readonly string Message = "Hello from TempSensor";
        private readonly string Directory = "1kMzODBDotvTLaei_Ci01LltJAxetSDL3";
        private readonly string FilePath = "../TestFile.txt";
        public async Task<bool> SendNotificationToDrive()
        {
            var creditential = GoogleCredential.FromFile(PathToServiceAccountKey)
                .CreateScoped(DriveService.ScopeConstants.Drive);

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creditential
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "TestFile",
                Parents = new List<string>(){ "1kMzODBDotvTLaei_Ci01LltJAxetSDL3" },
            };
            var x = service.Files.List();
            var y = await x.ExecuteAsync();
            string uploadedFileId;
            using (var fsSource = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                // Create a new file, with metadata and stream.
                var request = service.Files.Create(fileMetadata, fsSource, "text/plain");
                request.Fields = "*";
                var results = await request.UploadAsync(CancellationToken.None);

                if (results.Status == UploadStatus.Failed)
                {
                    Console.WriteLine($"Error uploading file: {results.Exception.Message}");
                }

                // the file id of the new file we created
                uploadedFileId = request.ResponseBody?.Id;
            }
            throw new NotImplementedException();
        }
    }
}
