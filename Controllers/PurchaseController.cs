using Microsoft.AspNetCore.Mvc;
using Mission_7_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_7_Assignment.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Basket Basket { get; set; }

        public PurchaseController (IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            Basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (Basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = Basket.Items.ToArray();
                repo.SavePurchase(purchase);
                Basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
