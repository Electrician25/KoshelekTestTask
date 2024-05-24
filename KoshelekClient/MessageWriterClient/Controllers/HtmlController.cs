using KoshelekClient.ActionResult;
using Microsoft.AspNetCore.Mvc;

namespace KoshelekClient.Controllers
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
        [Route("WriteMessage")]
        public IActionResult SendMessage()
        {
            return _htmlResult(@"./wwwroot/html/WriteClientMessageMainPage.html");
        }
    }
}