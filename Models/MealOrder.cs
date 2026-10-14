using System.ComponentModel.DataAnnotations;

namespace MealOrderCollection.Models
{
    /// <summary>
    /// Bir yemek siparişini temsil eder.
    /// </summary>
    public class MealOrder
    {
        [Display(Name = "Sipariş ID")]
        public string OrderID { get; set; } = string.Empty;

        [Display(Name = "Öğrenci Adı")]
        public string StudentName { get; set; } = string.Empty;

        [Display(Name = "Yemek Adı")]
        public string MealName { get; set; } = string.Empty;

        [Display(Name = "Teslim Durumu")]
        public bool Collected { get; set; }

        [Display(Name = "Teslim Zamanı")]
        public DateTime? CollectedAt { get; set; }
    }
}
