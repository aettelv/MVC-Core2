using Microsoft.AspNetCore.Mvc;

namespace Labor.Controllers
{
    public class TestController : Controller
    {
        public string Getstring()
        {
            return "Hello world!";
        }
    }
}