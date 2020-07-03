using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class InPhonesController : Controller
    {
        // GET: InPhones
        public ActionResult Index()
        {
            IEnumerable<infoPhone> emlist;
            HttpResponseMessage response = GlobalVariables.api.GetAsync("InfoPhones").Result;
            emlist = response.Content.ReadAsAsync<IEnumerable<infoPhone>>().Result;
            return View(emlist);
        }
        public ActionResult add(int id = 0)
        {
            return View(new infoPhone());
        }
        [HttpPost]
        public ActionResult add(infoPhone phone)
        {
            HttpResponseMessage response = GlobalVariables.api.PostAsJsonAsync("InfoPhones", phone).Result;
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new infoPhone());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.api.GetAsync("InfoPhones/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<infoPhone>().Result);
            }
        }
        [HttpPost]
        public ActionResult Edit(infoPhone mcxs)
        {
            if (mcxs.ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.api.PutAsJsonAsync("InfoPhones", mcxs).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.api.PutAsJsonAsync("InfoPhones/" + mcxs.ID, mcxs).Result;
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id = 0)
        {
            HttpResponseMessage response = GlobalVariables.api.DeleteAsync("InfoPhones/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}