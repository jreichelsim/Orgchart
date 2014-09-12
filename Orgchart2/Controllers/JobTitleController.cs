using System.Web.Mvc;
using Orgchart2.Infrastructure;
using Orgchart2.Models;

namespace Orgchart2.Controllers
{
    public class JobTitleController : Controller
    {
        private readonly IOrgChartRepository<JobTitle> _repository;

        public JobTitleController(IOrgChartRepository<JobTitle> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            SetTitle();
            ViewBag.Heading = "Manage Job Titles";

            return View(_repository.SelectAll());
        }

        public ActionResult Add()
        {
            SetTitle();
            ViewBag.Heading = "Add New Job Title";

            return View();
        }

        [HttpPost]
        public ActionResult Add(JobTitle newJobTitle)
        {
            if (!ModelState.IsValid)
                return View(newJobTitle);

            _repository.Add(newJobTitle);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            SetTitle();
            ViewBag.Heading = "Confirm Job Title Deletion";

            var jobTitle = _repository.Select(id);

            if (jobTitle == null)
                return HttpNotFound();

            return View(jobTitle);
        }

        [HttpPost]
        public ActionResult Delete(int id, string confirm)
        {
            var jobTitle = _repository.Select(id);

            if (jobTitle == null)
                return HttpNotFound();

            _repository.Delete(jobTitle.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var jobTitle = _repository.Select(id);

            if (jobTitle == null)
                return HttpNotFound();

            SetTitle();
            ViewBag.Heading = string.Format("Edit Job Title \"{0}\"", jobTitle.Description);

            return View(jobTitle);
        }

        [HttpPost]
        public ActionResult Edit(JobTitle title)
        {
            if (!ModelState.IsValid)
                return View(title);

            _repository.Update(title);
            return RedirectToAction("Index");
        }

        private void SetTitle()
        {
            ViewBag.Title = "Manage Job Titles";
        }
    }
}