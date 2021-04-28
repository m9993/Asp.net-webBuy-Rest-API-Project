﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webBuy_with_Rest_API.Attributes;
using webBuy_with_Rest_API.Models;
using webBuy_with_Rest_API.Repositories;

namespace webBuy_with_Rest_API.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        UserRepository userRepository = new UserRepository();

        [Route(""), HttpGet, BasicAuthentication]
        public IHttpActionResult Login([FromUri] string email, [FromUri] string password)
        {
            return Ok(userRepository.VerifyLogin(email,password));
        }
    }
}
