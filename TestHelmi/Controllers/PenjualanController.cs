using Microsoft.AspNetCore.Mvc;
using TestHelmi.Data;
using TestHelmi.Models;

namespace TestHelmi.Controllers
{
    public class PenjualanController : Controller
    {
        private readonly MySqlContext _context;
        public PenjualanController(MySqlContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortOrder)
        {
            List<Penjualan> none = _context.market.ToList();
            switch (sortOrder)
            {
                case "name_desc":
                    none = none.OrderByDescending(x => x.NamaBarang).ToList();
                    break;
                case "name":
                    none = none.OrderBy(x => x.NamaBarang).ToList();
                    break;
                default:
                    none = none.ToList();
                    break;
            }
            return View(none);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] Penjualan penjualan)
        {
            _context.market.Add(penjualan);
            _context.SaveChanges();
            return RedirectToAction("Index", "Penjualan");
        }

        public IActionResult Edit(int id)
        {
            var edit = _context.market.Where(x => x.Id == id).FirstOrDefault();
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit([FromForm] Penjualan penjualan)
        {
            _context.market.Update(penjualan);
            _context.SaveChanges();
            return RedirectToAction("Index", "Penjualan");
        }
        public IActionResult Delete(int id)
        {
            var remove = _context.market.Where(x => x.Id == id).FirstOrDefault();
            _context.market.Remove(remove);
            _context.SaveChanges();
            return RedirectToAction("Index", "Penjualan");
        }


        [HttpPost]
        public IActionResult Search(string data)
        {
            var products = _context.market.Where(p => p.NamaBarang.ToLower().Contains(data.ToLower())).ToList();
            return View("Index", products);
        }

        [HttpPost]
        public IActionResult SearchByDate(DateTime? awal, DateTime? akhir)
        {
            var data = _context.market.Where(x => x.TanggalTransaksi >= awal).Where(x => x.TanggalTransaksi <= akhir);

            return View("SearchByDate", data);
        }


    }
}
