namespace StaticFilesWebApiExample
{
    public class ClearFilesBackgroundService: BackgroundService
    {
        private FilesRepository repository = new FilesRepository();

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            repository.ClearFiles(TimeSpan.FromHours(24));    

            return Task.CompletedTask;
        }
    }
}
