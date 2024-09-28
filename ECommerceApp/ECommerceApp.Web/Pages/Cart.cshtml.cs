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
        public CartModel(IECommerceRepository repository)
        {
            _repository = repository;
        }
        public Cart? Cart { get; set; }
        public void OnGet()
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int Id)
        {
            var product = _repository.Products.FirstOrDefault(i => i.Id == Id);
            if(product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product,1);
                HttpContext.Session.SetJson("cart",Cart);
            }
            return RedirectToPage("/cart");
        }
    }
}
