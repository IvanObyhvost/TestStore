using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TestStore.BLL.Interface;
using TestStore.Core.DTO;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class AdminController : Controller
    {
        SendFormViewModel sendForm;
        private IRealEstateService _realEstateService;
        private IDescriptionService _descriptionService;

        public AdminController(IRealEstateService realEstateService, IDescriptionService descriptionService)
        {
            sendForm = new SendFormViewModel();
            _realEstateService = realEstateService;
            _descriptionService = descriptionService;
        }


        [HttpGet]
        public ActionResult Contact()
        {
            return View(sendForm);
        }
        [HttpPost]
        public ActionResult Contact(SendFormViewModel model)
        {
            GetTime(model);

            if (ModelState.IsValid)
            {
                //SendFormViewModel model = new SendFormViewModel();
                // наш email с заголовком письма
                MailAddress from = new MailAddress(@System.Configuration.ConfigurationManager.AppSettings["Mail"]);
                // кому отправляем
                MailAddress to = new MailAddress(@System.Configuration.ConfigurationManager.AppSettings["Mail"]);
                // создаем объект сообщения
                MailMessage msg = new MailMessage(from, to);
                // тема письма
                msg.Subject = "Letter from site";
                // текст письма
                msg.Body = string.Format("Title: " + model.Title + "\n"
                                         + "Name: " + model.Name + "\n"
                                         + "Best time to contact with me: " + ViewBag.Time + "\n"
                                         + "Phone: " + model.PhoneNumber + "\n\n"
                                         + model.Message);
                msg.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential(@System.Configuration.ConfigurationManager.AppSettings["Mail"], "dfyby[eh3223");
                smtp.EnableSsl = true;
               

                try
                {
                    smtp.Send(msg);
                }

                catch { }
            }
            return View(model);
            
        } 

        public void GetTime(SendFormViewModel model)
        {
            if (model.TimeToContactVieModel.AnyTime)
                ViewBag.Time += "AnyTime";
            if (model.TimeToContactVieModel.MondayAM)
                ViewBag.Time += "Monday AM";
            if (model.TimeToContactVieModel.MondayPM)
                ViewBag.Time += "Monday PM ";
            if (model.TimeToContactVieModel.TuesdayAM)
                ViewBag.Time += "Tuesday AM ";
            if (model.TimeToContactVieModel.TuesdayPM)
                ViewBag.Time += "Tuesday PM ";
            if (model.TimeToContactVieModel.WednesdayAM)
                ViewBag.Time += "Wednesday AM ";
            if (model.TimeToContactVieModel.WednesdayPM)
                ViewBag.Time += "Wednesday PM ";
            if (model.TimeToContactVieModel.ThursdayAM)
                ViewBag.Time += "Thursday AM ";
            if (model.TimeToContactVieModel.ThursdayPM)
                ViewBag.Time += "Thursday PM ";
            if (model.TimeToContactVieModel.FridayAM)
                ViewBag.Time += "Friday AM ";
            if (model.TimeToContactVieModel.FridayPM)
                ViewBag.Time += "Friday PM ";
            if (model.TimeToContactVieModel.SaturdayAM)
                ViewBag.Time += "Saturday AM ";
            if (model.TimeToContactVieModel.SaturdayPM)
                ViewBag.Time += "Saturday PM";
        }

        public ActionResult Description(int id)
        {
            DescriptionDTO description = _descriptionService.GetDescriptionByIdRealEstate(id);
            var photoForGalleryDto = _descriptionService.GetPhotoForGalleryById(id).ToList();
            var model = new EditDescriptionViewModel()
            {
                RealEstateId = description.RealEstateId,
                ShortDescription = description.ShortDescription,
                LongDescription = description.LongDescription,
                PhotosDto = photoForGalleryDto
            };
            ViewBag.Id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Description(EditDescriptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                DescriptionDTO description = _descriptionService.GetDescriptionByIdRealEstate(model.RealEstateId);
                var descriptionDto = new DescriptionDTO()
                {
                    Id = model.Id,
                    RealEstateId = description.RealEstateId,
                    ShortDescription =  model.ShortDescription,
                    LongDescription = model.LongDescription
                };
                _descriptionService.UpdateDescriptionDto(descriptionDto);
                _descriptionService.Save();
                return RedirectToAction("Particulars", "Home", new {id = descriptionDto.RealEstateId});

            }
            
            return View(model);
        }

        public PartialViewResult UploadPhoto(int id)
        {
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = "/Content/Gallery/" + id + "_" + upload.FileName;

                    //сохраняем путь в табличке в базе данных 
                    var photo = new PhotoForGalleryDTO()
                    {
                        RealEstateId = id,
                        UrlImage = fileName,
                    };
                    _descriptionService.AddPhotoForGallery(photo);

                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath(fileName));

                    
                }
            }
            _descriptionService.Save();
            List<PhotoForGalleryDTO> photos = _descriptionService.GetPhotoForGalleryById(id).ToList();
            return PartialView("PhotosList", photos);
          
          }
        [HttpPost]
        public PartialViewResult DeleteImage(string name, int realId)
        {
            string fullpath = Server.MapPath(name);

            try
            {
                System.IO.File.Delete(fullpath);
                _descriptionService.DeletePhoto(name);
                _descriptionService.Save();
                var photos = _descriptionService.GetPhotoForGalleryById(realId);
                return PartialView("PhotosList", photos);
            }
            catch
            {
                return null;
            }

        }
    }

}
