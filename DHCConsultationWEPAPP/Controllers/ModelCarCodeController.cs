using DHCInterfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHCConsultationWEPAPP.Controllers
{
    public class ModelCarCodeController : Controller
    {


        private readonly IModelCarCodeRepository _modelCarCodeRepository;


        public ModelCarCodeController(IModelCarCodeRepository modelCarCodeRepository)
        {
            _modelCarCodeRepository = modelCarCodeRepository;
        }


        // GET: ModelCarCodeController
        public ActionResult Index()
        {
            return View(_modelCarCodeRepository.GetAllModelCarCodes());
        }

        // GET: ModelCarCodeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModelCarCodeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelCarCodeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ModelCarCodeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModelCarCodeController/Edit/5
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

        // GET: ModelCarCodeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModelCarCodeController/Delete/5
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
    }
}
