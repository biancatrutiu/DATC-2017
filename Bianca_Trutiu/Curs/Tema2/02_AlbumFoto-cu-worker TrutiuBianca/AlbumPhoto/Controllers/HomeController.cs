﻿using AlbumPhoto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbumPhoto.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var service = new AlbumFotoService();
            return View(service.GetPoze());
        }

        [HttpPost]
        public ActionResult IncarcaPoza(HttpPostedFileBase file)
        {
            var service = new AlbumFotoService();
            if (file!=null && file.ContentLength > 0)
            {
                service.IncarcaPoza("guest", file.FileName, file.InputStream);
            }

            return View("Index", service.GetPoze());
        }
        [HttpPost]
        public ActionResult IncarcaComment()
        {
            var service = new AlbumFotoService();
            var poza = Request["Picture"].ToString();
            var commNou = Request["ComentariuPozaNou"].ToString();
            service.IncarcaComentariu("adminUser", poza, commNou);
            return View("Index", service.GetPoze());
        }

        [HttpPost]
        public ActionResult PrimesteLinkAcces()
        {
            var service = new AlbumFotoService();
            var poza = Request["Picture"].ToString();
            service.GetLinkTemporar(poza);
            return View("Index", service.GetPoze());
        }
    }
}
