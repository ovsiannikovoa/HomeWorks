namespace Task03_01_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cartService = new ShoppingCartService();

            Console.WriteLine("=== Пример 1: Корзина с списком цен ===");

            var itemPrices = new List<decimal> { 100.50m, 200.25m, 50.75m, 300.00m };

            decimal total1 = cartService.CalculateTotalPrice("Regular", itemPrices);
            Console.WriteLine($"Итог для Regular: {total1}\n");

            decimal total2 = cartService.CalculateTotalPrice("New", itemPrices);
            Console.WriteLine($"Итог для неизвестного типа: {total2}\n");

            Console.WriteLine("=== Пример 2: Корзина с количеством товаров ===");

            var itemsWithQuantities = new Dictionary<decimal, int>
        {
            { 100.0m, 2 },   // 2 товара по 100
            { 50.0m, 4 },    // 4 товара по 50
            { 200.0m, 1 }    // 1 товар по 200
        };

            decimal total3 = cartService.CalculateTotalPriceWithQuantities("Regular", itemsWithQuantities);
            Console.WriteLine($"Итог с количествами для Regular: {total3}\n");

            Console.WriteLine("=== Пример 3: Пустая корзина ===");
            decimal total4 = cartService.CalculateTotalPrice("Regular", new List<decimal>());
            Console.WriteLine($"Итог для пустой корзины: {total4}\n");

            Console.WriteLine("=== Пример 4: Один товар ===");
            decimal total5 = cartService.CalculateTotalPrice("Regular", new List<decimal> { 1000m });
            Console.WriteLine($"Итог для одного товара: {total5}");
            Console.ReadKey();
        }
    }

    public class ShoppingCartService
    {
        public decimal CalculateTotalPrice(string customerType, List<decimal> itemPrices)
        {
            decimal baseTotal = CalculateBaseTotal(itemPrices);
            decimal discount = CalculateDiscount(baseTotal, customerType);
            decimal finalPrice = baseTotal - discount;

            PrintSummary(baseTotal, discount, finalPrice);
            return finalPrice;
        }

        public decimal CalculateTotalPriceWithQuantities(string customerType, Dictionary<decimal, int> itemsWithQuantities)
        {
            var itemPrices = itemsWithQuantities
            .SelectMany(item => Enumerable.Repeat(item.Key, item.Value))
            .ToList();

            return CalculateTotalPrice(customerType, itemPrices);
        }

        private decimal CalculateBaseTotal(List<decimal> prices)
        {
            return prices.Sum();
        }

        private decimal CalculateDiscount(decimal baseTotal, string customerType)
        {
            // Реализуем только необходимый функционал для "Regular"
            if (customerType == "Regular")
            {
                return baseTotal * 0.05m;
            }
            return 0;
        }

        private void PrintSummary(decimal baseTotal, decimal discount, decimal finalPrice)
        {
            Console.WriteLine($"Base: {baseTotal}, Discount: {discount}, Final: {finalPrice}");
        }
    }
}
