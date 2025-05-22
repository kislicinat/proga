using System;

namespace CarLibrary
{
    public class Car
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public string VIN { get; }
        public CarBodyType BodyType { get; set; }
        public decimal Price { get; set; }
        public DateTime? SaleDate { get; set; }
        public string BuyerName { get; set; }

        public Car(string brand, int year, string vin, CarBodyType bodyType, decimal price)
        {
            Brand = brand;
            Year = year;
            VIN = vin ?? throw new ArgumentNullException(nameof(vin));
            BodyType = bodyType;
            Price = price >= 0 ? price : throw new ArgumentException("Цена не может быть отрицательной");
        }

        public string[] GetInfo()
        {
            var info = new string[3];
            info[0] = $"Автомобиль: {Brand} ({Year})";
            info[1] = $"VIN: {VIN}, Кузов: {BodyType}, Цена: {Price:C}";
            info[2] = SaleDate.HasValue 
                ? $"Продано: {SaleDate:d} покупателю: {BuyerName}"
                : "Не продано";
            return info;
        }
    }
}
