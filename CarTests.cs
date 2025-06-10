using NUnit.Framework;
using CarLibrary;
using System;

namespace CarLibrary.Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car CreateTestCar()
        {
            return new Car("Toyota", 2020, "XTA123456789", CarBodyType.Sedan, 25000);
        }

        [Test]
        public void Constructor_ValidData_SetsProperties()
        {
            var car = CreateTestCar();
            
            Assert.That(car.Brand, Is.EqualTo("Toyota"));
            Assert.That(car.Year, Is.EqualTo(2020));
            Assert.That(car.VIN, Is.EqualTo("XTA123456789"));
            Assert.That(car.BodyType, Is.EqualTo(CarBodyType.Sedan));
            Assert.That(car.Price, Is.EqualTo(25000));
        }

        [Test]
        public void VIN_ReadOnly_CannotBeChanged()
        {
            var car = CreateTestCar();
            Assert.Throws<InvalidOperationException>(() => 
            {
                var property = car.GetType().GetProperty("VIN");
                property.SetValue(car, "NEWVIN123");
            });
        }

        [Test]
        public void GetInfo_UnsoldCar_ReturnsCorrectInfo()
        {
            var car = CreateTestCar();
            var info = car.GetInfo();

            Assert.That(info[0], Is.EqualTo("Автомобиль: Toyota (2020)"));
            Assert.That(info[2], Is.EqualTo("Не продано"));
        }

        [Test]
        public void GetInfo_SoldCar_IncludesBuyerInfo()
        {
            var car = CreateTestCar();
            car.SaleDate = new DateTime(2023, 5, 15);
            car.BuyerName = "Иванов Иван";

            var info = car.GetInfo();
            StringAssert.Contains("15.05.2023", info[2]);
            StringAssert.Contains("Иванов Иван", info[2]);
        }
    }
}