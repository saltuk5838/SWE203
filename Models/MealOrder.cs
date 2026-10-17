using System.ComponentModel.DataAnnotations;

namespace MealOrderCollection.Models
{
    /// <summary>
    /// Represents a single meal order.
    /// </summary>
    public class MealOrder
    {
        [Display(Name = "Order ID")]
        public string OrderID { get; set; } = string.Empty;

        [Display(Name = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "Meal Name")]
        public string MealName { get; set; } = string.Empty;

        [Display(Name = "Collection Status")]
        public bool Collected { get; set; }

        [Display(Name = "Collected At")]
        public DateTime? CollectedAt { get; set; }
    }
}
