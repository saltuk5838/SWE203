namespace MealOrderCollection.Models
{
    public static class Repository
    {
        private static List<MealOrder> _mealOrders = new();

        static Repository()
        {
            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O001",
                StudentName = "Timur Yurdakan",
                MealName = "Forest Kebab",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 10, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O002",
                StudentName = "Saltuk Buğra",
                MealName = "Padishah Kebab",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O003",
                StudentName = "Mete Çakır",
                MealName = "Forest Kebab",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O004",
                StudentName = "Adem Yılmaz",
                MealName = "Chicken Doner",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O005",
                StudentName = "Yunus Emre",
                MealName = "Beef Doner",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 20, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O006",
                StudentName = "Mustafa Emin",
                MealName = "White Bean Stew with Meat",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O007",
                StudentName = "Furkan Kurnaz",
                MealName = "Plain Pasta",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 25, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O008",
                StudentName = "Köksal Andaç",
                MealName = "Mengen Moussaka",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O009",
                StudentName = "Erdem Efe",
                MealName = "Roast Meatballs with Mashed Potatoes",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O010",
                StudentName = "Adem Yiğit Fidan",
                MealName = "Turmeric Chicken Saute",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 35, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O011",
                StudentName = "Ali Arslan",
                MealName = "Borlotti Beans with Meat",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 40, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O012",
                StudentName = "Alperen Söyler",
                MealName = "Beef Doner",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O013",
                StudentName = "Onur Çınar",
                MealName = "Mengen Moussaka",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O014",
                StudentName = "Deniz Arık",
                MealName = "Padishah Kebab",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 50, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O015",
                StudentName = "Hidayet Sıdar",
                MealName = "Forest Kebab",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O016",
                StudentName = "Mustafa Baki Beyoğlu",
                MealName = "Pasta with Tomato Sauce",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 13, 0, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O017",
                StudentName = "Yasin Ünsal",
                MealName = "Sultan Kebab",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O018",
                StudentName = "Semih Ayata",
                MealName = "Vegetarian White Bean Stew",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 13, 10, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O019",
                StudentName = "Berke Duran",
                MealName = "Stuffed Dried Peppers",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O020",
                StudentName = "Baran Kulaklıoğlu",
                MealName = "Beef Doner",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 13, 20, 0)
            });
        }

        /// <summary>Returns all meal orders.</summary>
        public static List<MealOrder> GetMealOrders()
        {
            return _mealOrders;
        }

        /// <summary>Returns only the collected meal orders.</summary>
        public static List<MealOrder> GetCollectedMealOrders()
        {
            return _mealOrders.Where(o => o.Collected).ToList();
        }

        /// <summary>Finds an order by its Order ID; returns null if not found.</summary>
        public static MealOrder? GetMealOrderById(string? orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                return null;
            }

            return _mealOrders.FirstOrDefault(o =>
                o.OrderID.Equals(orderId.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Marks the order as collected and records the collection time.
        /// Returns false if the order does not exist or has already been collected.
        /// </summary>
        public static bool CollectMealOrder(string? orderId)
        {
            var order = GetMealOrderById(orderId);
            if (order == null || order.Collected)
            {
                return false;
            }

            order.Collected = true;
            order.CollectedAt = DateTime.Now;
            return true;
        }
    }
}
