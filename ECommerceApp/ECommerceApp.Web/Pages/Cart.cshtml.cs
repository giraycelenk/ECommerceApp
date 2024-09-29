using ECommerceApp.Data.Abstract;
using ECommerceApp.Web.Helpers;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceApp.Web.Pages
{
    public class CartModel : PageModel
    {
        private IECommerceRepository _repository;
        public CartModel(IECommerceRepository repository,Cart cartservice)
        {
            _repository = repository;
            Cart = cartservice;
        }
        public Cart? Cart { get; set; }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost(int Id)
        {
            var product = _repository.Products.FirstOrDefault(i => i.Id == Id);
            if(product != null)
            {
                Cart?.AddItem(product,1);
            }
            return RedirectToPage("/");
        }

        public IActionResult OnPostRemove(int Id)
        {
            Cart?.RemoveItem(Cart.Items.First(p => p.Product.Id == Id).Product);
            return RedirectToPage("/Cart");
        }
        public IActionResult OnGetClear()
        {
            Cart?.Clear();
            return RedirectToPage("/");
        }
    }
}
