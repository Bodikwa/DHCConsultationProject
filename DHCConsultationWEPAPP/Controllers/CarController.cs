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
    public class CarController : Controller
    {

        private readonly ICarRepository _carRepository;
        private readonly IModelCarCodeRepository _modelCarCodeRepository;
        private readonly IModelCarNameRepository _modelCarNameRepository;


        public CarController(ICarRepository carRepository, 
            IModelCarCodeRepository modelCarCodeRepository,
            IModelCarNameRepository modelCarNameRepository)
        {
            _carRepository = carRepository;
            _modelCarCodeRepository = modelCarCodeRepository;
            _modelCarNameRepository = modelCarNameRepository;
        }


        // GET: CarController
        public ActionResult Index()
        {
            return View(_carRepository.GetAllCars());
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)


        {
            CodeModelViewbag();
            NameModelViewbag();
            return View(_carRepository.GetCarById(id));
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            CodeModelViewbag();
            NameModelViewbag();
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


        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Car car)
        {
            try
            {
                _carRepository.InsertCar(car);
                _carRepository.SaveCar();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CodeModelViewbag();
                NameModelViewbag();
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            CodeModelViewbag();
            NameModelViewbag();
            return View(_carRepository.GetCarById(id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Car car)
        {
            try
            {
                _carRepository.UpdateCar(car);
                _carRepository.SaveCar();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CodeModelViewbag();
                NameModelViewbag();
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            CodeModelViewbag();
            NameModelViewbag();
            return View(_carRepository.GetCarById(id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Car car)
        {
            try
            {
                _carRepository.DeleteCar(car.CarId);
                _carRepository.SaveCar();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                CodeModelViewbag();
                NameModelViewbag();
                return View();
            }
        }
    }
}
