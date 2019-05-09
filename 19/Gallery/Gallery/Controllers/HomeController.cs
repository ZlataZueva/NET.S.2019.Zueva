using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gallery.Controllers
{
    public class HomeController : Controller
    {
        GalleryDb galleryDb = new GalleryDb();

        public ActionResult Index(string filter = null, int page = 1, int pageSize = 20)
        {
            var records = new PagedList<Photo>();
            ViewBag.filter = filter;
            records.Content = galleryDb.Photos
                        .Where(x => filter == null || (x.Description.Contains(filter)))
                        .OrderByDescending(x => x.Id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            records.TotalRecords = records.Content.Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            if(Request.IsAjaxRequest())
            {
                return PartialView("_ImagesView", records);
            }

            return View(records);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Photo photo, IEnumerable<HttpPostedFileBase> files)
        {
            if (files.Count() == 0 || files.FirstOrDefault() == null)
            {
                ViewBag.error = "Please choose a file";
                return View(photo);
            }
            if (ModelState.IsValid)
            {
                Photo model = new Photo();

                foreach (var file in files)
                {
                    model.Description = photo.Description;
                    var fileName = Guid.NewGuid().ToString();
                    var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

                    model.ThumbPath = string.Format("/Content/images/thumbnail/{0}{1}", fileName, extension);
                    model.ImagePath = string.Format("/Content/images/{0}{1}", fileName, extension);

                    using (var img = System.Drawing.Image.FromStream(file.InputStream))
                    {
                        // Save thumbnail size image, 100 x 100
                        SaveToFolder(img, fileName, extension, new Size(100, 100), model.ThumbPath);

                        // Save large size image, 800 x 800
                        SaveToFolder(img, fileName, extension, new Size(800, 800), model.ImagePath);
                    }

                    galleryDb.Photos.Add(model);
                    galleryDb.SaveChanges();
                }
            }
            return RedirectPermanent("/home");
        }

        //public ActionResult Index()
        //{
        //    //var model = new List<Photo>();
        //    return View(model);
        //}

        public ActionResult Carusel()
        {
            return View(galleryDb.Photos.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
                finalSize = imageSize; // image is already small size

            return finalSize;
        }

        private void SaveToFolder(Image img, string fileName, string extension, Size newSize, string pathToSave)
        {

            // Get new resolution
            Size imgSize = NewImageSize(img.Size, newSize);
            using (Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
            {
                newImg.Save(Server.MapPath(pathToSave), img.RawFormat);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if(galleryDb != null)
            {
                galleryDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}