using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BlazorInputFile;
using Bookstore_UI.Contracts;
using Microsoft.AspNetCore.Hosting;

namespace Bookstore_UI.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _env;

        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task UploadFile(IFileListEntry file, string picName)
        {
            try
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);

                var path = $"{_env.WebRootPath}\\uploads\\{picName}";

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    ms.WriteTo(fs);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
