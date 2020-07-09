using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace TestAppAzureAD.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly ITokenAcquisition _tokenAcquisition;
        public HomeController(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }
        public async Task<IActionResult> Index()
        {
            string[] scopes = new string[] { "user.read" };
            string accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);
            ViewBag.token = accessToken;
            return View();
        }
    }
}
