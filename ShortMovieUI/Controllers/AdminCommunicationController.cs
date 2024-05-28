using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using X.PagedList;

namespace ShortMovieUI.Controllers
{
    public class AdminCommunicationController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IPersonalService _personalService;

        public AdminCommunicationController(IContactService contactService, IPersonalService personalService)
        {
            _contactService = contactService;
            _personalService = personalService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ContactList(string searchString, int page = 1)
        {
            int pageSize = 10;
            var contacts = _contactService.TGetList();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                contacts = contacts.Where(c => c.ContactUserName.ToLower().Contains(searchString) ||
                                                c.ContactSubject.ToLower().Contains(searchString)).ToList();
            }

            var pagedContacts = contacts.ToPagedList(page, pageSize);

            ViewBag.SearchString = searchString;
            return View(pagedContacts);
        }

        public IActionResult ContactSee(int id)
        {
            var contact = _contactService.TGetByID(id);
            return View(contact);
        }

        public IActionResult ContactDelete(int id)
        {
            var contact = _contactService.TGetByID(id);
            _contactService.TDelete(contact);
            return RedirectToAction("ContactList");
        }

        public IActionResult PersonalYunusEmre()
        {
            var personalMessages = _personalService.TPersonalMessage("yunusemre");
            return View(personalMessages);
        }

        public IActionResult PersonalEren()
        {
            var personalMessages = _personalService.TPersonalMessage("eren");
            return View(personalMessages);
        }

        public IActionResult PersonalMessageDetails(int id)
        {
            var personalMessage = _personalService.TGetByID(id);
            return View(personalMessage);
        }

        public IActionResult DeletePersonal(int id)
        {
            var personal = _personalService.TGetByID(id);
            _personalService.TDelete(personal);
            return RedirectToAction("ContactList"); 
        }


    }
}
