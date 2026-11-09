using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhamBaTuanTu_241230880.Models;

namespace PhamBaTuanTu_241230880.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _context;

        public HomeController(QlhangHoaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var query = _context.HangHoas.Where(h => h.Gia >= 100);
            if (MaLoai.HasValue)
            {
                query = query.Where(h => h.MaLoai == MaLoai.Value);
                ViewData["TieuDe"] = "New Products";
            }
            else
            {
                ViewData["TieuDe"] = "Pham Ba Tuan Tu";
            }
            var danhSach = await query.ToListAsync();
            return View(danhSach);
        }
        public async Task<IActionResult> Loc(int? id)
        {
            var query = _context.HangHoas.Where(h => h.Gia >= 100);
            if (id.HasValue)
            {
                query = query.Where(h => h.MaLoai == id.Value);
                ViewData["TieuDe"] = "New Products";
            }
            else
            {
                ViewData["TieuDe"] = "Pham Ba Tuan Tu";
            }
            var danhSach = await query.ToListAsync();
            return PartialView("PhamBaTuanTu_MainContent", danhSach);
        }
    }
}