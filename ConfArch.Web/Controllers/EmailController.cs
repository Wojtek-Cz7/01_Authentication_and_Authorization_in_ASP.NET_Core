using ConfArch.Web.Areas.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ConfArch.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly ITestEmailSender _emailSender;

        public EmailController(ITestEmailSender emailSender)
        {

            _emailSender = emailSender;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> SendTestEmail()
        {
            await _emailSender.SendTestEmailAsync();

            return Redirect("Index");

            //return View("Index");
        }
    }
}
