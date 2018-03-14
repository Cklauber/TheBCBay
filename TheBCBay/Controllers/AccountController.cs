using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheBCBay.Services;

namespace TheBCBay.Controllers
{
    public class AccountController : Controller
    {

        private IItemData _itemData;
        public AccountController(IItemData itemData)
        {
            _itemData = itemData;

        }


        public IActionResult ManageItems()
        {
            //This will tell the database who is the current user.
            var user = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            var model = _itemData.GetUsersItems(user);
            return View(model);
        }


        public IActionResult Logout()
        {
            //When we sign out, we go to the sign out page, which follows the MVC pattern for this method.
            var callbackUrl = Url.Page("");
            if (User.Identity.IsAuthenticated)
            {
                    return SignOut(
                        new AuthenticationProperties { RedirectUri = callbackUrl },
                        // remove cookie that authenticates user
                        CookieAuthenticationDefaults.AuthenticationScheme
            );
            }
            return View();
        }


        public IActionResult Register()
        {
            //We are going to return to the page the user was previously.
            var redirectUrl = Request.Headers["Referer"].ToString();
            return Challenge(
                new AuthenticationProperties { RedirectUri = redirectUrl },
                // challenge the user by logging in with OIDC server
                OpenIdConnectDefaults.AuthenticationScheme
            );
        }
        public IActionResult Login()
        {
            //We are going to return to the page the user was previously.
            var redirectUrl = Request.Headers["Referer"].ToString();
            return Challenge(
                new AuthenticationProperties { RedirectUri = redirectUrl },
                // challenge the user by logging in with OIDC server
                OpenIdConnectDefaults.AuthenticationScheme
            );
        }

    }
}