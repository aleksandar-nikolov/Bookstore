using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Bookstore_UI.Contracts
{
    public interface IFileUpload
    {
        public Task UploadFile(Stream file, string picName);

        //public Task RemoveFile(string picName);
    }
}
