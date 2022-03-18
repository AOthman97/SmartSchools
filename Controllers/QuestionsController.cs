using Microsoft.AspNetCore.Mvc;

namespace SmartSchools.Controllers
{
    public class QuestionsController : Controller
    {
        private IWebHostEnvironment hostingEnv;

        public QuestionsController(IWebHostEnvironment env)
        {
            this.hostingEnv = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload(IFormFile file)

        {
            string x = HttpContext.Session.GetString("IsMain");
            var FileDic = "Temp";
            string SubFileDic = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SubFolderName")))
            {
                SubFileDic = HttpContext.Session.GetString("SubFolderName").ToString();
            }
            else
            {
                HttpContext.Session.SetString("SubFolderName", SubFileDic);
            }

            string FilePath = Path.Combine(hostingEnv.WebRootPath, FileDic);

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
            string SubFilePath = Path.Combine(FilePath, SubFileDic);
            if (!Directory.Exists(SubFilePath))
                Directory.CreateDirectory(SubFilePath);
            var fileName = file.FileName;

            if (x == "yes")
                fileName = $"Main_{fileName}";

            string filePath = Path.Combine(SubFilePath, fileName);
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
            }



            return RedirectToAction("Index");




            //delete Folder
            //string path = @"D:\Workarea\Test\Code";
            //Directory.Delete(path);


            //Move Folder from source to destination
            //string source = @"D:\Workarea\Test\Code";
            //string destination = @"D:\Workarea\Test\NewDirectory";

            //try
            //{
            //    // First, you should ensure that the
            //    // source directory exists
            //    if (Directory.Exists(source))
            //    {
            //        // You should eEnsure the destination
            //        // directory doesn't already exist
            //        if (!Directory.Exists(destination))
            //        {
            //            // Move the source directory
            //            // to the new location
            //            Directory.Move(source, destination);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Destination directory" +
            //                        " already exists...");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Source directory " +
            //                "does not exist...");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        [HttpPost]
        public IActionResult SetIsMain(string IsMain)
        {
            HttpContext.Session.SetString("IsMain", IsMain);
            string x = HttpContext.Session.GetString("IsMain");
            return Json(HttpContext.Session.GetString("IsMain"));
        }

    }
}
