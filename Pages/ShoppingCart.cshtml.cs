using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission_7_Assignment.Infrastructure;
using Mission_7_Assignment.Models;

namespace Mission_7_Assignment.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public ShoppingCartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
            Basket.AddItem(b, 1);

            HttpContext.Session.SetJson("Basket", Basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
