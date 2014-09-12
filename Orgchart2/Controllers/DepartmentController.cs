using System.Linq;
using System.Web.Mvc;
using Orgchart2.Infrastructure;
using Orgchart2.Models;
using Orgchart2.ViewModels;

namespace Orgchart2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IOrgChartRepository<Department> _repository;

        public DepartmentController(IOrgChartRepository<Department> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            SetTitle();
            ViewBag.Heading = "Manage Departments";

            return View(_repository.SelectAll());
        }

        public ActionResult Add()
        {
            SetTitle();
            ViewBag.Heading = "Add New Department";
            return View(new DepartmentViewModel(new Department()));
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {
            if (!ModelState.IsValid)
                return View(new DepartmentViewModel(department));

            _repository.Add(department);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            SetTitle();
            ViewBag.Heading = "Confirm Department Deletion";

            var department = _repository.Select(id);

            if (department == null)
                return HttpNotFound();

            return View(department);
        }

        [HttpPost]
        public ActionResult Delete(int id, string confirm)
        {
            var department = _repository.Select(id);

            if (department == null)
                return HttpNotFound();

            _repository.Delete(department.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var department = _repository.Select(id);

            SetTitle();
            ViewBag.Heading = string.Format("Edit Department \"{0}\"", department.Name);

            return View(new DepartmentViewModel(department));
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (!ModelState.IsValid)
                return View(new DepartmentViewModel(department));

            _repository.Update(department);
            return RedirectToAction("Index");
        }

        private void SetTitle()
        {
            ViewBag.Title = "Department Page";
        }
    }
}