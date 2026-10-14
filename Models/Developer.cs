namespace MealOrderCollection.Models
{
    /// <summary>
    /// Alt bilgide (footer) gösterilen geliştirici bilgileri.
    /// </summary>
    public class Developer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StudentNumber { get; set; } = string.Empty;
    }

    public static class DeveloperInfo
    {
        // Geliştirici bilgilerini buradan güncelleyebilirsiniz.
        // İkinci bir grup üyesi varsa listeye yeni bir Developer ekleyin.
        public static readonly List<Developer> Developers = new()
        {
            new Developer { FirstName = "Saltuk Buğra", LastName = "Danişment", StudentNumber = "B241202023" }
        };
    }
}
