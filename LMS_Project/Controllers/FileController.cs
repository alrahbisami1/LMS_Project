using BOL;
using BOL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;
using File = BOL.Data.File;

namespace LMS_Project.Controllers
{

    public class FileController : Controller
    {
        private readonly IFileData _fileData;
        private readonly ILecture _lecture;

        public FileController(IFileData fileData, ILecture lecture)
        {
            _fileData = fileData;
            _lecture = lecture;

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
            ViewBag.LectureID = new SelectList(_lecture.GetAllLectures(), "Id", "Title");
            return View();
        }

        // POST: FileController/Create
        [HttpPost]

        public ActionResult Create(File file, IFormFile filepdf)
        {
            try
            {

                if (filepdf.ContentType == "application/pdf" || filepdf.ContentType == "application/docx")
                {
                    var ext = Path.GetExtension(file.Path);
                    using (FileStream fs =
                        new FileStream("./wwwroot/files/" + filepdf.FileName, FileMode.Create))
                    {
                        filepdf.CopyTo(fs); //local
                                            //file.Id = getuserInfo().Id;
                        file.Path = filepdf.FileName; // db

                }
                _fileData.Add(file);


                    return RedirectToAction("Details", new { id = file.Id });
                }

                else
                {
                    ModelState.AddModelError("", "pdf or docx only Allowed");
                    return View();
                }
            }
            catch
            {
                return View();
            } }
        }

        // GET: FileController/Edit/5
        public ActionResult Edit(int id)
        {
            //return old account record
            var fle = _fileData.GetFileById(id);
            return View(fle);
        }

        // POST: FileController/Edit/5
        [HttpPost]
        public ActionResult Edit(File file, IFormFile filepdf)
        {
            try
            {
                if (filepdf != null) //check user if browse an image
                {
                    if (filepdf.ContentType == "application/pdf" || filepdf.ContentType == "application/docx")
                    {
                        var ext = Path.GetExtension(file.Path);
                        using (FileStream fs =
                            new FileStream("./wwwroot/files/" + filepdf.FileName, FileMode.Create))
                        {
                            filepdf.CopyTo(fs); //local

                            file.Path = filepdf.FileName; // db

                        }

                    }


                }
                _fileData.Update(file);
                return RedirectToAction("Details", new { id = file.Id });
            }

            catch
            {
                return View();
            }
        }

        // GET: FileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_fileData.GetFileById(id));
        }

        // POST: FileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var fle = _fileData.GetFileById(id);
                System.IO.File.Delete("./wwwroot/images/" + fle.Path);
                _fileData.Delete(fle);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public User getuserInfo()
        {
            var sesuser = HttpContext.Session.GetString("ses");
            var userinfo = JsonConvert.DeserializeObject<User>(sesuser);
            return userinfo;
        }
    }
}
