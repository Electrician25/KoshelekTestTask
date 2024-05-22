using Microsoft.AspNetCore.Mvc;

namespace KoshelekClient.ActionResult
{
    public sealed class HtmlResult : ContentResult
    {
        public HtmlResult()
        {

        }

        public HtmlResult(string path)
        {
            Content = File.ReadAllText(path);
            ContentType = "text/html; charset=utf-8";
        }
    }
}