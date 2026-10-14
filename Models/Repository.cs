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
                MealName = "Orman kebabı",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 10, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O002",
                StudentName = "Saltuk buğra ",
                MealName = "Padişah kebabı",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O003",
                StudentName = "Mete Çakır",
                MealName = "Orman kebabı",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O004",
                StudentName = "adem yılmaz ",
                MealName = "Tavuk döner ",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O005",
                StudentName = "yunus emre ",
                MealName = "Et döner",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 20, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O006",
                StudentName = "Mustafa Emin ",
                MealName = "Etli Kuru Fasulye ",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O007",
                StudentName = "Furkan Kurnaz",
                MealName = "Sade Makarna",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 25, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O008",
                StudentName = "Köksal Andaç",
                MealName = "Mengen Musakka",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O009",
                StudentName = "Erdem Efe",
                MealName = "Rosto Köfte Püreli",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O010",
                StudentName = "Adem Yiğit Fidan",
                MealName = "Zerdeçallı tavuk kavurma",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 35, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O011",
                StudentName = "Ali Arslan",
                MealName = "Etli Barbunya ",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 40, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O012",
                StudentName = "Alperen Söyler",
                MealName = "Et Döner",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O013",
                StudentName = "Onur Çınar",
                MealName = "Mengen Musakka",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O014",
                StudentName = "Deniz Arık",
                MealName = "Padişah kebabı",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 12, 50, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O015",
                StudentName = " Hidayet Sıdar",
                MealName = "Orman Kebabı",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O016",
                StudentName = "Mustafa Baki Beyoğlu",
                MealName = "Salçalı Makarna",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 13, 0, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O017",
                StudentName = "Yasin Ünsal",
                MealName = "Sultan  kebabı",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O018",
                StudentName = "Semih Ayata",
                MealName = "Etsiz kuru fasulye",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 13, 10, 0)
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O019",
                StudentName = "Berke Duran",
                MealName = "kuru dolma ",
                Collected = false,
                CollectedAt = null
            });

            _mealOrders.Add(new MealOrder()
            {
                OrderID = "O020",
                StudentName = "Baran Kulaklıoğlu",
                MealName = "Et Döner",
                Collected = true,
                CollectedAt = new DateTime(2026, 10, 5, 13, 20, 0)
            });
        }

        /// <summary>Tüm yemek siparişlerini döndürür.</summary>
        public static List<MealOrder> GetMealOrders()
        {
            return _mealOrders;
        }

        /// <summary>Teslim alınmış yemek siparişlerini döndürür.</summary>
        public static List<MealOrder> GetCollectedMealOrders()
        {
            return _mealOrders.Where(o => o.Collected).ToList();
        }

        /// <summary>Sipariş ID'sine göre siparişi bulur; bulunamazsa null döner.</summary>
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
        /// Siparişi teslim alındı olarak işaretler ve teslim zamanını kaydeder.
        /// Sipariş bulunamazsa veya zaten teslim alınmışsa false döner.
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
