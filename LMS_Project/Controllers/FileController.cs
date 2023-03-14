using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Principal;
using File = BOL.Data.File;

namespace LMS_Project.Controllers
{
    
    public class FileController : Controller
    {
        private readonly IFileData _fileData;

        public FileController(IFileData fileData)
        {
            _fileData = fileData;

        }
        // GET: FileController
        public ActionResult Index()
        {
            return View(_fileData.GetAllFiles());
        }

        // GET: FileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileController/Create
        [HttpPost]
        
        public ActionResult Create(File file, IFormFile filepdf)
        {
            try
            {
                if (filepdf.ContentType == "file/pdf" || filepdf.ContentType == "file/docx")
                {
                    var ext = Path.GetExtension(file.Path);
                    using (FileStream fs =
                        new FileStream("./wwwroot/files/" + getEmpInfo().Id + ext, FileMode.Create))
                    {
                        filepdf.CopyTo(fs);
                        file.Id = getEmpInfo().Id;
                        file.Name = getEmpInfo().Id + ext;

                    }
                    _fileData.Add(file);
                    

                    return RedirectToAction("Details", new { id = file.Id });
                }
                else
                {
                    ModelState.AddModelError("", "pdf or docx only Allowed");
                    return View();
                }
                catch
            {
                return View();
            }
        }

        // GET: FileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public User getEmpInfo()
        {
            var sesuser = HttpContext.Session.GetString("ses");
            var userinfo = JsonConvert.DeserializeObject<User>(sesuser);
            return userinfo;
        }
    }
}
