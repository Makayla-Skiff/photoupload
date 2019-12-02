using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private IHostingEnvironment ihostingEnvironment;

        public string FileName { get; set; }

        public IndexModel(IHostingEnvironment ihostingEnvironment)
        {
            this.ihostingEnvironment = ihostingEnvironment;
        }
        public void OnGet()
        {
        }
        public void OnPost(IFormFile photo)
        {
            var path = Path.Combine(ihostingEnvironment.WebRootPath, "images", photo.FileName);
            var stream = new FileStream(path, FileMode.Create);
            photo.CopyToAsync(stream);
            FileName = photo.FileName;
        }
    }
}