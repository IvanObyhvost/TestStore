using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestStore.BLL.Interface;
using TestStore.Core.DTO;
using TestStore.Models;
using TestStore.Enums;
using PagedList;
using PagedList.Mvc;

namespace TestStore.Controllers
{
    public class HomeController : Controller
    {
        private IRealEstateService _realEstateService;
        private IPersonService _personService;
        private IDescriptionService _descriptionService;

        public HomeController(IRealEstateService realEstateService, IPersonService personService, IDescriptionService descriptionService)
        {
            _realEstateService = realEstateService;
            _personService = personService;
            _descriptionService = descriptionService;
        }

        public ActionResult Index(int? pageNumber, int pageSize = 3)
        {
            ViewBag.PageSize = pageSize;
            int page = (pageNumber ?? 1);
            var realEstateDto = _realEstateService.GetRealEstates().ToList();


            var model = new List<EditRealEstateViewModel>();
            foreach(var item in realEstateDto)
            {
                model.Add(new EditRealEstateViewModel()
                {
                    RealEstateDto = item,
                });
            }

            if(Request.IsAjaxRequest())
            {
                return PartialView("RealEstatePartialList", model.ToPagedList(page, pageSize));
            }
            return View(model.ToPagedList(page, pageSize));

        }
        public ActionResult Add()
        {
            ViewBag.DataImage = null;

            return View("Edit", new EditRealEstateViewModel());
        }

        [HttpPost]
        public ActionResult Add(EditRealEstateViewModel realEstate)
        {
            RealEstateDTO real = realEstate.RealEstateDto;

            if (real.Id == 0)
            {
                _realEstateService.AddRealEstateDto(real);
                _realEstateService.Save();

                return RedirectToAction("Index");
            }
            return View(real);
        }
        [HttpPost]
        public void AddImage(int id, string imagePath, string imageMimeType)
        {
           if (id != 0)
           {
               _realEstateService.AddImage(id, imagePath, imageMimeType);
           }
           else
           {
               var realEstateDto = new RealEstateDTO();
               realEstateDto.ImagePath = imagePath;
               realEstateDto.ImageMimeType = imageMimeType;
               _realEstateService.AddRealEstateDto(realEstateDto);
               _realEstateService.Save();
           }
        }

        public ActionResult Edit(int id)
        {
            RealEstateDTO realEstate = _realEstateService.GetRealEstateById(id);

            var model = new EditRealEstateViewModel();

            model.RealEstateDto = realEstate;
            ViewBag.ImagePath = model.RealEstateDto.ImagePath;
            ViewBag.Id = model.RealEstateDto.Id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditRealEstateViewModel realEstate, HttpPostedFileBase image)
        {
            RealEstateDTO real = realEstate.RealEstateDto;
            if (image != null)
            {
                real.ImageMimeType = image.ContentType;
                real.ImagePath = "/Content/Files/" + real.Id + "_" + image.FileName;
            }
            if (real.Id == 0)
            {
                return Add(realEstate);
            }


            if (ModelState.IsValid)
            {
                _realEstateService.UpdateRealEstateDto(real);
                _realEstateService.Save();
                return RedirectToAction("Index");
            }
            return View(real);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            RealEstateDTO realEstate = _realEstateService.GetRealEstateById(id);
            return View(realEstate);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _realEstateService.DeleteRealEstateDto(id);
            _realEstateService.Save();
            return RedirectToAction("Index");
        }

        public FilePathResult GetImage(int id)
        {
            RealEstateDTO real = _realEstateService.GetRealEstateById(id);
            if (real.ImagePath != null)
            {
                string fullpath = Server.MapPath(real.ImagePath);
                ViewBag.ImagePath = fullpath;
                return File(real.ImagePath, real.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public JsonResult Upload(int id = 0)
        {
            string path = "/Content/Files/";
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    path += id.ToString()+"_"+fileName;

                    AddImage(id, path, upload.ContentType);
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath(path));

                    return Json(path);
                }
            }
            return Json("Файл не загружен");
        }
        [HttpPost]
        public JsonResult DeleteImage(string name, int realId)
        {
            string fullpath = Server.MapPath(name);

            try
            {
                System.IO.File.Delete(fullpath);
                
            }
            catch
            {
                _realEstateService.DeleteImage(realId);
                _realEstateService.Save();
            }

            return null;

        }

        public ActionResult AutocompleteSearch(string term)
        {
            var ten = Enum.GetNames(typeof(Tenure)).Where(a => a.Contains(term)).ToList().Select(a => new { value = a }).Distinct();
            return Json(ten, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RealEstatePartialList(IPagedList<EditRealEstateViewModel> real)
        {
            return PartialView(real);
        }
        public ActionResult Particulars(int id)
        {
            RealEstateDTO real = _realEstateService.GetRealEstateById(id);

            DescriptionDTO description = _descriptionService.GetDescriptionByIdRealEstate(real.Id);
            if (description == null)
            {
                _descriptionService.AddDescriptionDto(real.Id);
                _descriptionService.Save();
                description = _descriptionService.GetDescriptionByIdRealEstate(real.Id);
            }

            var photos = new List<PhotoForGalleryDTO>();
            int count = 0;
            foreach (var item in _descriptionService.GetPhotoForGalleryById(id).ToList())
            {
                if (count < 4)
                {
                    photos.Add(new PhotoForGalleryDTO()
                    {
                        RealEstateId = item.RealEstateId,
                        UrlImage = item.UrlImage,
                    });
                    count++;
                }
                else
                {
                    break;
                }
            }

            var model = new DescriptionViewModel()
            {
                Id = description.Id,
                Price = real.Price,
                Tenure = real.Tenure,
                Location = real.Location,
                RealEstateId = description.RealEstateId,
                ShortDescription = description.ShortDescription,
                LongDescription = description.LongDescription,
                PhotoForGalleryDto = photos
            };

            ViewBag.LongDescription = description.LongDescription;
            return View(model);
        }



    }
}