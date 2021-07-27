using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SMK.BAWANG.UI.Controllers
{
    public class BaseController : Controller
    {
        //[AllowAnonymous]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Session["usrTypeLogin"] == null)
                {
                    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    Session["usrTypeLogin"] = ticket.Name.Split('|')[1];
                    Session["usrNama"] = ticket.Name.Split('|')[2];
                    Session["userLogin"] = ticket.Name.Split('|')[0];
                    Session["usrNIS"] = ticket.Name.Split('|')[3];
                    Session["usrKLS"] = ticket.Name.Split('|')[4];
                }
            }
            else
            {
                Response.Redirect("~/Login");
            }



        }
    }
}