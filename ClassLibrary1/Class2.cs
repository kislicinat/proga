using System;

namespace AutoSalonLibrary
{
    public class Car
    {
        // Свойства
        public string Brand { get; set; }          // Марка автомобиля
        public int Year { get; set; }              // Год выпуска
        public string VIN { get; }                 // VIN-номер (только для чтения)
        public CarBodyType BodyType { get; set; }  // Тип кузова
        public decimal Price { get; set; }         // Цена
        public DateTime? SaleDate { get; set; }    // Дата продажи (может быть null)
        public string BuyerName { get; set; }      // ФИО покупателя

        // Конструктор
        public Car(string brand, int year, string vin, CarBodyType bodyType)
        {
            Brand = brand;
            Year = year;
            VIN = vin ?? throw new ArgumentNullException(nameof(vin), "VIN не может быть null");
            BodyType = bodyType;
        }

        // Метод для получения информации об автомобиле
        public virtual string[] GetInfo()
        {
            var info = new string[3];
            info[0] = $"{Brand}, {Year} год выпуска";
            
            string bodyTypeStr;
            switch (BodyType)
            {
                case CarBodyType.Sedan: bodyTypeStr = "седан"; break;
                case CarBodyType.Hatchback: bodyTypeStr = "хэтчбэк"; break;
                case CarBodyType.StationWagon: bodyTypeStr = "универсал"; break;
                case CarBodyType.Convertible: bodyTypeStr = "кабриолет"; break;
                default: bodyTypeStr = "неизвестный тип"; break;
            }
            
            info[1] = $"VIN: {VIN}, Тип кузова: {bodyTypeStr}, Цена: {Price:C}";
            
            info[2] = SaleDate.HasValue 
                ? $"Продано {SaleDate.Value:d} покупателю: {BuyerName}"
                : "Автомобиль доступен для покупки";
            
            return info;
        }
    }
}