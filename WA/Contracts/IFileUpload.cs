﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace WA.Contracts
{
    public interface IFileUpload
    {
        public Task UploadFile(Stream file, string picName);

        public void RemoveFile(string picName);
    }
}