using System;
using System.IO;
using System.Threading.Tasks;
using BookStore_UI.Contracts;
using Microsoft.AspNetCore.Hosting;

namespace BookStore_UI.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _env;

        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task UploadFile(Stream file, string picName)
        {
            try
            {
                var path = $"{_env.WebRootPath}\\uploads\\{picName}";

                await using FileStream fs = new FileStream(path, FileMode.Create);
                file.Seek(0, SeekOrigin.Begin);
                await file.CopyToAsync(fs);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RemoveFile(string picName)
        {
            var path = $"{_env.WebRootPath}\\uploads\\{picName}";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
