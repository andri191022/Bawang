using SMK.BAWANG.Dta;
using SMK.BAWANG.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SMK.BAWANG.UI.Infrastructure
{
    public class CustomAuthorizeAttribute: AuthorizeAttribute
    {

        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var userLogin = Convert.ToString(httpContext.Session["userLogin"]);
            if (!string.IsNullOrEmpty(userLogin))
            {
                v_Login Item = v_LoginItem.GetByPK(userLogin);

                foreach (var role in allowedroles)
                {
                    if (role == Item.typeUser) return true;
                }
            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Login" },
                    { "action", "Index" }
               });
        }

    }
}