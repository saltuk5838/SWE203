using System.ComponentModel.DataAnnotations;

namespace MealOrderCollection.Models
{
    /// <summary>
    /// Teslim alma formundan gelen veriyi model binding ile karşılayan sınıf.
    /// </summary>
    public class CollectRequest
    {
        [Required(ErrorMessage = "Lütfen bir Sipariş ID giriniz.")]
        [Display(Name = "Sipariş ID")]
        public string OrderID { get; set; } = string.Empty;
    }
}
