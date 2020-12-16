using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerShoppingCart.Web.Utilities
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        const int maxFileSize = 1048576; //Maximum file size set to 4MB

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> Upload(IBrowserFile file)
        {
            string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images", "products");
            
            string uniqueFileName = Guid.NewGuid().ToString() + "-" + file.Name;
            string filePath = Path.Combine(uploadFolder, uniqueFileName);
            using(Stream stream = file.OpenReadStream(maxFileSize))
            {
                using (MemoryStream memoryStream = new())
                {
                    await stream.CopyToAsync(memoryStream);
                    await File.WriteAllBytesAsync(filePath, memoryStream.ToArray());
                }
            }
            return uniqueFileName;
        }
    }
}
