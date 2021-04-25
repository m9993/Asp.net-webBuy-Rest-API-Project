using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using webBuy_with_Rest_API.Models;
using webBuy_with_Rest_API.Repositories;

namespace webBuy_with_Rest_API.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        UserRepository userRepository = new UserRepository();
        
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encoded = actionContext.Request.Headers.Authorization.Parameter;
                string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
                string[] splittedText = decoded.Split(new char[] { ':' });
                string email = splittedText[0];
                string password = splittedText[1];

                User userProfile=userRepository.VerifyLogin(email, password);
                if (userProfile!=null)
                {
                    if (userProfile.userStatus == 1)
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(email), null);
                        //actionContext.Response = actionContext.Request.CreateResponse(userProfile);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                    }

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}