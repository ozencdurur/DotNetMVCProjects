using AutoMapper;
using BookStoreProject.Models;
using BookStoreProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProject.Controllers
{
    public class BookController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly BookRepository _bookRepository;

        public BookController(AppDbContext context, IMapper mapper)
        {
            _bookRepository = new BookRepository();
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Books()
        {
            var books = _context.Books.ToList();

            return View(_mapper.Map<List<BookViewModel>>(books));
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Remove(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookViewModel newBook)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(_mapper.Map<Book>(newBook));
                _context.SaveChanges();
                TempData["status"] = "The book has been successfully added.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var book = _context.Books.Find(id);
            return View(_mapper.Map<BookViewModel>(book));
        }
        [HttpPost]
        public IActionResult Update(BookViewModel updateBook)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(_mapper.Map<Book>(updateBook));
                _context.SaveChanges();
                TempData["status"] = "The book has been successfully updated.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        [AcceptVerbs("GET","POST")]
        public IActionResult HasBookName(string Name)
        {
            var anyBook = _context.Books.Any(x=>x.Name.ToLower() == Name);
            if (anyBook)
            {
                return Json("This book already exists.");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
