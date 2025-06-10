using System;

namespace AutoSalonLibrary
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

        public Car(string brand, int year, string vin, CarBodyType bodyType)
        {
            Brand = brand;
            Year = year;
            VIN = vin ?? throw new ArgumentNullException(nameof(vin));
            BodyType = bodyType;
        }

        public virtual string[] GetInfo()
        {
            return new string[]
            {
                $"{Brand}, {Year} год выпуска",
                $"VIN: {VIN}, Тип кузова: {BodyType}, Цена: {Price:C}",
                SaleDate.HasValue 
                    ? $"Продано {SaleDate.Value:d} покупателю: {BuyerName}"
                    : "Автомобиль доступен для покупки"
            };
        }
    }

    public enum CarBodyType
    {
        Sedan,
        Hatchback,
        StationWagon,
        Convertible
    }
}