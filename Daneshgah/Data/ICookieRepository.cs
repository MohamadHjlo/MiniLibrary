using System.Collections.Generic;
using System.Security.Claims;
using Daneshgah.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Daneshgah.Data
{

    public interface ICookieRepository
    {
        public void SetCookie(bool IsAdmin, User user, HttpContext HC);
    }
    public class CookieRepository : ICookieRepository
    {
        private readonly WebsiteContext _websiteContext;

        public CookieRepository(WebsiteContext websiteContext)
        {
            _websiteContext = websiteContext;
        }

        public void SetCookie(bool IsAdmin, User user, HttpContext HC)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Email),
                new Claim("IsAdmin",IsAdmin.ToString()),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            HC.SignInAsync(principal, properties);
        }

    }
}
