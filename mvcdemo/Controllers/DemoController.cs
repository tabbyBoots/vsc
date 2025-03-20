using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using mvcdemo.Filters;

namespace mvcdemo.Controllers
{
    public class DemoController : Controller
    {
        [HttpGet]
        [TypeFilter(typeof(AuthorizationFilter))]
        
        // [TypeFilter(typeof(ActionFilter))]
        //因為已經繼承Attribute 所以就不用寫 TypeFileter....
        [AuthorizationFilter]
        //Index頁面因為有加上AuthorizationFilter
        //所以不能直接存取
        public IActionResult Index()
        {
            return View();
        }

        private readonly IWebHostEnvironment Environment;
        public DemoController(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        [HttpGet]
        //About頁面沒有加上 AuthorizationFilter
        //所以可以直接存取
        public ViewResult About()
        {
            ViewBag.Message = "這是關於我們的網頁內容";
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialViewDemo()
        {
            return PartialView("_PartialHelloWorld");
        }
        [HttpGet]
        public RedirectResult RedirectDemo()
        {
            return Redirect("https://tw.yahoo.com/");
        }
        [HttpGet]
        public ActionResult RedirectAcionDemo()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public RedirectToRouteResult RedirectRouteDemo()
        {
            return RedirectToRoute("Remark");
        }
        [HttpGet]
        public ContentResult Remark()
        {
            return Content("這是備註的網頁內容!!");
        }
        [HttpGet]
        public JsonResult JsonDemo()
        {
            var persons = new List<Person>()
            {
                new Person() { Id = 1 , PersonNo = "P001" , PersonName = "王小明"},
                new Person() { Id = 2 , PersonNo = "P002" , PersonName = "王小華"}
            };
            return Json(persons);
        }
        [HttpGet]
        public FileResult DownloadFile()
        {
            //設定檔案名稱
            string fileName = "110.pdf";
            //設定檔案相對路徑名稱
            string str_file = $"/files/{fileName}";
            //設定檔案類型
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            //下載檔案
            return File(str_file, contentType);
        }
        [HttpGet]
        public FileContentResult DownloadSiteCss()
        {
            //設定檔案名稱
            string fileName = "site.css";
            //設定檔案類型
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            //設定檔案相對路徑名稱
            string path = Path.Combine(Environment.WebRootPath, "css/") + fileName;
            //讀取檔案資料到 Byte 陣列.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //下載檔案
            return new FileContentResult(bytes, contentType);
        }
        [HttpGet]
        public FileStreamResult DownloadCreateFile()
        {
            //設定檔案名稱
            string fileName = "test.txt";
            //設定檔案類型
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            //設定文件資料內容字串
            string str_data = "Boots 你好，這是文件的資料內容!!";
            //將文件資料內容字串轉換成 Stream 形式
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str_data));
            //下載檔案
            return new FileStreamResult(stream, new Microsoft.Net.Http.Headers.MediaTypeHeaderValue(contentType))
            {
                FileDownloadName = fileName
            };
        }

        [HttpGet]
        public VirtualFileResult DownloadVirtualFile()
        {
            //設定檔案名稱
            string fileName = "site.css";
            //設定檔案相對路徑名稱
            string str_file = $"/css/{fileName}";
            //設定檔案類型
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            //下載檔案
            return new VirtualFileResult(str_file, contentType);
        }

        [HttpGet]
        public PhysicalFileResult DownloadPhysicalFile()
        {
            //設定檔案名稱
            string fileName = "site.css";
            //設定檔案相對路徑名稱
            string str_file = $"/wwwroot/css/{fileName}";
            //設定檔案類型
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            //設定檔案相對路徑名稱
            string path = Environment.ContentRootPath + str_file;
            //下載檔案
            return new PhysicalFileResult(path, contentType);
        }
        [HttpGet]
        public ContentResult ContentDemo1()
        {
            string html = "哈囉!! <span style=\"font-style:italic;\">王大明</span> , 你好嗎?";
            return Content(html, "text/html;charset=utf-8");
        }

        [HttpGet]
        public ContentResult ContentDemo2()
        {
            string html = "<script>alert('歡迎您光臨本網站!!');</script>";
            return Content(html, "text/html;charset=utf-8");
        }

        [HttpGet]
        public ContentResult ContentDemo3()
        {
            string html = @"
            <table border=""1"">
                <tr>
                    <th>公司名稱</th>
                    <th>連絡人</th>
                    <th>國家</th>
                </tr>
                <tr>
                    <td>英俊傢具行</td>
                    <td>李大明</td>
                    <td>德國</td>
                </tr>
                <tr>
                    <td>美麗眼鏡行</td>
                    <td>王美麗</td>
                    <td>美國</td>
                </tr>
            </table>
                ";
            return Content(html, "text/html;charset=utf-8");
        }
    }
}