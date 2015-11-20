using Newtonsoft.Json.Linq;
using SOFEMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SOFEMVC.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            WebRequest _WebRequest = WebRequest.Create("http://api.mylist.io/v1/todos");
            _WebRequest.Method = "GET";
            _WebRequest.ContentType = "application/json; charset=utf-8";
            HttpWebResponse msg = (HttpWebResponse) _WebRequest.GetResponse();
            string body;
            using(var sr = new StreamReader(msg.GetResponseStream()))
            {
                body = sr.ReadToEnd();
            }
            List<SofeItem> list = new List<SofeItem>();

            JObject json = JObject.Parse(body);
            JArray array = (JArray)json["todos"];
            
            foreach(JToken token in array)
            {
                list.Add(new SofeItem { _id=(string)token["_id"], title=(string)token["title"], isCompleted=(bool)token["isCompleted"] });
            }

            ViewBag.Items = list;
            return View();
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                WebRequest _WebRequest = WebRequest.Create("http://api.mylist.io/v1/todos/" + id);
                _WebRequest.Method = "DELETE";
                _WebRequest.ContentType = "application/json; charset=utf-8";
                _WebRequest.GetResponse();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error al intentar eliminar registro";
                return RedirectToAction("Index");
            }
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                WebRequest _WebRequest = WebRequest.Create("http://api.mylist.io/v1/todos/" + id);
                _WebRequest.Method = "DELETE";
                _WebRequest.ContentType = "application/json; charset=utf-8";
                _WebRequest.GetResponse();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error al intentar eliminar registro";
                return RedirectToAction("Index");
            }
        }
    }
}
