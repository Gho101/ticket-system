using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ticket_system.Services
{
    public class accountsController : Controller
    {
        // GET: accountsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: accountsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: accountsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: accountsController/Create
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

        // GET: accountsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: accountsController/Edit/5
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

        // GET: accountsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: accountsController/Delete/5
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
