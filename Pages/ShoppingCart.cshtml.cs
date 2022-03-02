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
        //private double price;

        private IBookstoreRepository repo { get; set; }
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        public ShoppingCartModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            Basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            double p = repo.Books.FirstOrDefault(x => x.BookId == bookId).Price;

            Basket.AddItem(b, 1, p);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            Basket.RemoveItem(Basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
