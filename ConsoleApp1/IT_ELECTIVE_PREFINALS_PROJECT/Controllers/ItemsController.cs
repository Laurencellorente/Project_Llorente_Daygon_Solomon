using IT_ELECTIVE_PREFINALS_PROJECT.Models;
using IT_ELECTIVE_PREFINALS_PROJECT.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        
        public IActionResult Index(string searchString)
        {
            var items = string.IsNullOrEmpty(searchString)
                ? _itemRepository.GetAll()
                : _itemRepository.SearchByName(searchString);

            ViewData["CurrentFilter"] = searchString;
            return View(items);
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var item = _itemRepository.GetById(id.Value);
            if (item == null) return NotFound();

            return View(item);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price,Quantity")] Item item)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.Add(item);
                _itemRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = _itemRepository.GetById(id.Value);
            if (item == null) return NotFound();

            return View(item);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,Quantity")] Item item)
        {
            if (id != item.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _itemRepository.Update(item);
                _itemRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var item = _itemRepository.GetById(id.Value);
            if (item == null) return NotFound();

            return View(item);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _itemRepository.GetById(id);
            if (item != null)
            {
                _itemRepository.Delete(item);
                _itemRepository.Save();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}