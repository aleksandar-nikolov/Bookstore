using System.Threading.Tasks;
using BlazorInputFile;

namespace Bookstore_UI.Contracts
{
    public interface IFileUpload
    {
        public Task UploadFile(IFileListEntry file, string picName);
    }
}
