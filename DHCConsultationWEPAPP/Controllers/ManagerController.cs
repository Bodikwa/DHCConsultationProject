using DHC.DAL.Models;
using DHCInterfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHCConsultationWEPAPP.Controllers
{
    public class ManagerController : Controller
    {

        private readonly IManagerRepository _managerRepository;


        public ManagerController(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }
        // GET: ManagerController
        public ActionResult Index()
        {
            return View(_managerRepository.GetAllManagers());
        }

        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View(_managerRepository.GetManagerById(id));
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Manager manager)
        {
            try
            {
                _managerRepository.InsertManager(manager);
                _managerRepository.SaveManager();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_managerRepository.GetManagerById(id));
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Manager manager)
        {
            try
            {
                _managerRepository.UpdateManager(manager);
                _managerRepository.SaveManager();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_managerRepository.GetManagerById(id));
        }

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Manager manager)
        {
            try
            {
                _managerRepository.DeleteManager(manager.ManagerId);
                _managerRepository.SaveManager();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
