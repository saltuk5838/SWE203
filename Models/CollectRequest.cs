using System.ComponentModel.DataAnnotations;

namespace MealOrderCollection.Models
{
    /// <summary>
    /// Receives the data posted from the collection form via model binding.
    /// </summary>
    public class CollectRequest
    {
        [Required(ErrorMessage = "Please enter an Order ID.")]
        [Display(Name = "Order ID")]
        public string OrderID { get; set; } = string.Empty;
    }
}
