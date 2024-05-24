using KoshelekMessageHistoryClient.ActionResult;
using Microsoft.AspNetCore.Mvc;

namespace KoshelekMessageHistoryClient.Controller
{
    [ApiController]
    [Route("/api/{controller}")]
    public class HtmlController : ControllerBase
    {
        private readonly Func<string, HtmlResult> _htmlResult;

        public HtmlController(Func<string, HtmlResult> htmlResult)
        {
            _htmlResult = htmlResult;
        }

        [HttpGet]
        [Route("GetHisoryMessage")]
        public IActionResult GetHistoryMessage()
        {
            return _htmlResult(@"./wwwroot/html/MessageHistoryMainPage.html");
        }
    }
}