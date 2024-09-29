using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECommerceApp.Web.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Phone { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string AddressLine { get; set; } = null!;
        [BindNever]
        public Cart? Cart { get; set; } = null!;
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpireMonth { get; set; }
        public string? ExpireYear { get; set; }
        public string? Cvc { get; set; }
    }
}