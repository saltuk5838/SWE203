namespace MealOrderCollection.Models
{
    /// <summary>
    /// Developer information shown in the footer.
    /// </summary>
    public class Developer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StudentNumber { get; set; } = string.Empty;
    }

    public static class DeveloperInfo
    {
        // Update the developer information here.
        // If there is a second group member, add another Developer to the list.
        public static readonly List<Developer> Developers = new()
        {
            new Developer { FirstName = "Saltuk Buğra", LastName = "Danişment", StudentNumber = "B241202023" },
            new Developer { FirstName = "Mustafa Timur", LastName = "Yurdakan", StudentNumber = "B241202018" }
        };
    }
}
