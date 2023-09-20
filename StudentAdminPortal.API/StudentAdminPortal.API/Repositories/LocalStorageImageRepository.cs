namespace StudentAdminPortal.API.Repositories
{
    public class LocalStorageImageRepository : IImageRepository

    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            //created to merge paths
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images", fileName);
            {
                //created a path by setting the mode to create
                using Stream fileStream = new FileStream(filePath, FileMode.Create);

                //copies the path
                await file.CopyToAsync(fileStream);
                return GetServerRelativePath(fileName);
            }

        }

        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }

    }
}
