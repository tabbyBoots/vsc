namespace mvcdebugdemo.Controllers
{
    public class TitleController : Controller
    {
        // 建立資料庫物件
        dbEntities db = new dbEntities();

        // 列出職稱資料
        [HttpGet]
        public ActionResult Index()
        {
            using var title = new z_sqlTitles();
            var model = title.GetDataList();
            return View(model);
        }

        // 新增或修改職稱資料
        [HttpGet]
        public ActionResult CreateEdit(int id = 0)
        {
            using var title = new z_sqlTitles();
            var model = title.GetData(id);
            return View(model);
        }

        // 新增或修改職稱資料
        [HttpPost]
        public ActionResult CreateEdit(Titles model)
        {
            using var title = new z_sqlTitles();
            title.CreateEdit(model);
            return RedirectToAction("Index");
        }

        // 新增或修改職稱資料
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            using var title = new z_sqlTitles();
            var model = title.Delete(id);
            return View(model);
        }
    }
}
