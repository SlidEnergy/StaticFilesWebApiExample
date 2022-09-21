namespace StaticFilesWebApiExample
{
    public class File
    {
        public string FileName { get; set; }

        public string Token { get; set; }

        public DateTime Created { get; set; }
    }

    public class FilesRepository
    {
        public File FindFileByToken(string token)
        {
            return new File()
            {
                FileName = @"test.jpg",
                Token = token
            };
        }

        public File FindFileByFileName(string fileName)
        {
            var token = Guid.NewGuid().ToString();

            return new File()
            {
                FileName = fileName,
                Token = token
            };
        }

        public File SaveFile(string fileName)
        {
            var token = Guid.NewGuid().ToString();

            return new File()
            {
                FileName = @"test.png",
                Token = token
            };
        }

        public IEnumerable<File> GetAllFiles()
        {
            var token = Guid.NewGuid().ToString();

            return new List<File>()
            {
                new File()
                {
                    FileName = @"test.png",
                    Token = token
                }
            };
        }

        public void DeleteFile(File file)
        {

        }

        public void ClearFiles(TimeSpan fileLifeTime)
        {
            var files = GetAllFiles();

            foreach (var file in files)
            {
                var age = DateTime.UtcNow - file.Created;

                if (age >= fileLifeTime)
                {
                    DeleteFile(file);
                }
            }
        }
    }
}
