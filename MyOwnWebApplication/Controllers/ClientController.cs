using Microsoft.AspNetCore.Mvc;
using MyOwnWebApplication.Data;
using MyOwnWebApplication.Models;

namespace MyOwnWebApplication.Controllers
{
    public class ClientController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Client> objClientsList = _db.Clients.ToList();
            return View(objClientsList);
        }

        //CREATE
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(Client obj, int value)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Add(obj);
                _db.SaveChanges();
                Console.WriteLine(value);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var client = _db.Clients.Find(id);

            if(client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Client obj)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();    
            }

            var client = _db.Clients.Find(id);

            if(client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Client obj)
        {
            _db.Clients.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
