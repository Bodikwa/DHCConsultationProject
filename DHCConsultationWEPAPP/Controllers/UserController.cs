using DHC.DAL.Models;
using DHCInterfaces.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHCConsultationWEPAPP.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly IModelCarCodeRepository _modelCarCodeRepository;
        private readonly IModelCarNameRepository _modelCarNameRepository;
        private readonly ICarRepository _carRepository;
        private readonly IManagerRepository _managerRepository;

        public UserController(IUserRepository userRepository, 
            ICarRepository carRepository, IManagerRepository managerRepository,
        IModelCarCodeRepository modelCarCodeRepository,
            IModelCarNameRepository modelCarNameRepository)
        {
            _userRepository = userRepository;

          
            _modelCarCodeRepository = modelCarCodeRepository;
            _modelCarNameRepository = modelCarNameRepository;
            _carRepository = carRepository;
            _managerRepository = managerRepository;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(_userRepository.GetAllUsers());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View(_userRepository.GetUserById(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            CodeModelViewbag();
            NameModelViewbag();
            CarViewbag();
            ManagerViewbag();
            return View();
        }
        private void CodeModelViewbag()
        {
            var codeModels = _modelCarCodeRepository.GetAllModelCarCodes().OrderBy(x => x.ModelCode);

            List<SelectListItem> CodeModelsOption = new List<SelectListItem>();
            foreach (var c in codeModels)
            {
                CodeModelsOption.Add(new SelectListItem(c.ModelCode, c.ModelCodeId.ToString()));
            }
            ViewBag.codeViewbag = CodeModelsOption;
        }

        private void NameModelViewbag()
        {
            var nameModels = _modelCarNameRepository.GetAllModelCarNames().OrderBy(x => x.ModelName);

            List<SelectListItem> NameModelOption = new List<SelectListItem>();
            foreach (var c in nameModels)
            {
                NameModelOption.Add(new SelectListItem(c.ModelName, c.ModelNameId.ToString()));
            }
            ViewBag.nameViewbag = NameModelOption;
        }

        private void CarViewbag()
        {
            var cars = _carRepository.GetAllCars().OrderBy(x => x.CarName);

            List<SelectListItem> CarOption = new List<SelectListItem>();
            foreach (var c in cars)
            {
                CarOption.Add(new SelectListItem(c.CarName, c.CarId.ToString()));
            }
            ViewBag.carViewbag = CarOption;
        }

        private void ManagerViewbag()
        {
            var managesrs = _managerRepository.GetAllManagers().OrderBy(x => x.ManagerName);

            List<SelectListItem> managerOption = new List<SelectListItem>();
            foreach (var c in managesrs)
            {
                managerOption.Add(new SelectListItem(c.ManagerName, c.ManagerId.ToString()));
            }
            ViewBag.managerViewbag = managerOption;
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] User user )
        {
            try
            {
                _userRepository.InsertUser(user);
                _userRepository.SaveUser();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CodeModelViewbag();
                NameModelViewbag();
                CarViewbag();
                ManagerViewbag();
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            CodeModelViewbag();
            NameModelViewbag();
            CarViewbag();
            ManagerViewbag();
            return View(_userRepository.GetUserById(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] User user)
        {
            try
            {
                _userRepository.InsertUser(user);
                _userRepository.SaveUser();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CodeModelViewbag();
                NameModelViewbag();
                CarViewbag();
                ManagerViewbag();
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            CodeModelViewbag();
            NameModelViewbag();
            CarViewbag();
            ManagerViewbag();
            return View(_userRepository.GetUserById(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] User user)
        {
            try
            {
                _userRepository.DeleteUser(user.UserId);
                _userRepository.SaveUser();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CodeModelViewbag();
                NameModelViewbag();
                CarViewbag();
                ManagerViewbag();
                return View();
            }
        }
    }
}
