using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ShortMovieUI.Controllers
{
    [Authorize]
    public class AdminDirectorController : Controller
    {
        private readonly IDirectorService _directorService;

        public AdminDirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        public IActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 10;
            var directors = _directorService.TGetList();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                directors = directors.Where(d => d.DirectorNameSurname.ToLower().Contains(searchString)).ToList();
            }

            var pagedDirectors = directors.ToPagedList(page, pageSize);

            ViewBag.SearchString = searchString;
            return View(pagedDirectors);
        }

        [HttpGet]
        public IActionResult AddDirector()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDirector(Director director, IFormFile DirectorImage)
        {
            if (DirectorImage != null && DirectorImage.Length > 0)
            {
                var fileName = Path.GetFileName(DirectorImage.FileName);
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/directors");

                // Klasörün varlığını kontrol et ve gerekirse oluştur
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    DirectorImage.CopyTo(stream);
                }

                director.DirectorImage = "/images/directors/" + fileName; // Yeni resim dosya yolunu kaydet
            }

            _directorService.TAdd(director);
            return RedirectToAction("Index", "AdminDirector");
        }

        public IActionResult DeleteDirector(int id)
        {
            var director = _directorService.TGetByID(id);
            if (director != null)
            {
                // Mevcut resim dosyasını silme
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", director.DirectorImage.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _directorService.TDelete(director);
            }
            return RedirectToAction("Index", "AdminDirector");
        }

        [HttpGet]
        public IActionResult UpdateDirector(int id)
        {
            var director = _directorService.TGetByID(id);
            return View(director);
        }

        [HttpPost]
        public IActionResult UpdateDirector(Director director, IFormFile DirectorImage)
        {
            var existingDirector = _directorService.TGetByID(director.DirectorID);

            if (DirectorImage != null && DirectorImage.Length > 0)
            {
                var fileName = Path.GetFileName(DirectorImage.FileName);
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/directors");

                // Klasörün varlığını kontrol et ve gerekirse oluştur
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    DirectorImage.CopyTo(stream);
                }

                // Mevcut resmi sil
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingDirector.DirectorImage.TrimStart('/'));
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

                director.DirectorImage = "/images/directors/" + fileName; // Yeni resim dosya yolunu kaydet
            }
            else
            {
                // Yeni resim yüklenmediyse mevcut resmi koru
                director.DirectorImage = existingDirector.DirectorImage;
            }

            _directorService.TUpdate(director);
            return RedirectToAction("Index", "AdminDirector");
        }
    }
}
