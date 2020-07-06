using Microsoft.AspNetCore.Mvc;

namespace YURent.Controllers
{
    public partial class DateTimePickerController : Controller
    {
        public ActionResult RangeSelection()
        {
            return View();
        }
    }
}