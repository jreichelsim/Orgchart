using System.Linq;
using System.Web.Mvc;
using Orgchart2.Infrastructure;
using Orgchart2.Models;
using Orgchart2.ViewModels;

namespace Orgchart2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IOrgChartRepository<Employee> _repository;

        public EmployeeController(IOrgChartRepository<Employee> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            SetTitle();
            ViewBag.Heading = "Manage Employees";

            return View(_repository.SelectAll());
        }

        public ActionResult Add()
        {
            SetTitle();
            ViewBag.Heading = "Add New Employee";

            return View(new EmployeeViewModel(new Employee()));
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(new EmployeeViewModel(employee));

            _repository.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            SetTitle();
            ViewBag.Heading = "Confirm Employee Deletion";

            var employee = _repository.Select(id);
            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id, string confirm)
        {
            var employee = _repository.Select(id);

            if (employee == null)
                return HttpNotFound();

            _repository.Delete(employee.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var employee = _repository.Select(id);

            if (employee == null)
                return HttpNotFound();

            SetTitle();
            ViewBag.Heading = string.Format("Edit Employee \"{0} {1}\"", employee.FirstName, employee.LastName);

            return View(new EmployeeViewModel(employee));
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(new EmployeeViewModel(employee));

            _repository.Update(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Filter()
        {
            SetTitle();
            ViewBag.Heading = "Employee Page - Filter results...";

            return RedirectToAction("Index");
        }

        private void SetTitle()
        {
            ViewBag.Title = "Employee Page";
        }
    }
}