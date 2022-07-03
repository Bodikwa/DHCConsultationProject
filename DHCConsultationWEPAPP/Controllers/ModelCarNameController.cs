using DHCInterfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHCConsultationWEPAPP.Controllers
{
    public class ModelCarNameController : Controller
    {

        private readonly IModelCarNameRepository _modelCarNameRepository;


        public ModelCarNameController(IModelCarNameRepository modelCarNameRepository)
        {
            _modelCarNameRepository = modelCarNameRepository;
        }

        // GET: ModelCarNameController
        public ActionResult Index()
        {
            return View(_modelCarNameRepository.GetAllModelCarNames());
        }

        // GET: ModelCarNameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModelCarNameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelCarNameController/Create
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

        // GET: ModelCarNameController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModelCarNameController/Edit/5
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

        // GET: ModelCarNameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModelCarNameController/Delete/5
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
