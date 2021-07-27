using SMK.BAWANG.Dta;
using SMK.BAWANG.Dto;
using SMK.BAWANG.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SMK.BAWANG.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }

                return View();
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var userName = Request.Form["username"];
                    var password = Request.Form["password"];
                    Security.MD5Hash(password.Trim());
                    v_Login Item = v_LoginItem.GetByPK(userName);
                    if (Item != null && Item.Password == password)
                    {
                        FormsAuthentication.SetAuthCookie(Item.Username + "|" + Item.typeUser + "|" + Item.Nama + "|" + Item.NIS + "|" + Item.Kelas, false);

                        Session["userLogin"] = userName;

                        if (Item.typeUser == "GBK")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else if (Item.typeUser == "SWA")
                        {
                            return RedirectToAction("Index", "HomeSWA");
                        }
                        else if (Item.typeUser == "WKL")
                        {
                            return RedirectToAction("Index", "HomeWKL");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Login");
                        }
                    }
                }

                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
            catch (Exception err)
            {
                return View();
            }

        }

        public ActionResult Forgot()
        {
            try
            {
                return View();
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}