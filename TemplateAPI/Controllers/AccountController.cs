﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            return result;

        }

        //[HttpGet]
        //[Route("api/GetUserClaims")]
        //public AccountModel GetUserClaims()
        //{
        //    var identityClaims = (ClaimsIdentity)User.Identity;
        //    IEnumerable<Claim> claims = identityClaims.Claims;
        //    AccountModel model = new AccountModel()
        //    {
        //        UserName = identityClaims.FindFirst("Username").Value,
        //        Email = identityClaims.FindFirst("Email").Value,
        //        FirstName = identityClaims.FindFirst("FirstName").Value,
        //        LastName = identityClaims.FindFirst("LastName").Value,
        //        LoggedOn = identityClaims.FindFirst("LoggedOn").Value
        //    };
        //    return model;
        //}
    }
}
