using NUnit.Framework;
using AutoSalonLibrary;
using System;

namespace AutoSalonLibrary.UnitTests
{
    [TestFixture]
    public class CarUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            
            var testCar = CreateTestCar();
            
            
            Assert.That(testCar.Brand, Is.EqualTo("Toyota"));
            Assert.That(testCar.Year, Is.EqualTo(2020));
            Assert.That(testCar.VIN, Is.EqualTo("XTA21099765432101"));
            Assert.That(testCar.BodyType, Is.EqualTo(CarBodyType.Sedan));
            Assert.That(testCar.Price, Is.EqualTo(0)); 
            Assert.That(testCar.SaleDate, Is.Null);    
            Assert.That(testCar.BuyerName, Is.Null);   
        }

        [Test]
        public void GetInfoTest_NotSold()
        {
            
            var testCar = CreateTestCar();
            testCar.Price = 1500000m;
            
            
            var info = testCar.GetInfo();
            
            
            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Toyota, 2020 год выпуска"));
            Assert.That(info[1], Is.EqualTo("VIN: XTA21099765432101, Тип кузова: седан, Цена: 1 500 000,00 ₽"));
            Assert.That(info[2], Is.EqualTo("Автомобиль доступен для покупки"));
        }

        [Test]
        public void GetInfoTest_Sold()
        {
            
            var testCar = CreateTestCar();
            testCar.Price = 1500000m;
            testCar.SaleDate = new DateTime(2023, 5, 15);
            testCar.BuyerName = "Иванов Иван Иванович";
            
            
            var info = testCar.GetInfo();
            
            
            Assert.That(info[2], Is.EqualTo("Продано 15.05.2023 покупателю: Иванов Иван Иванович"));
        }

        [Test]
        public void VinNullTest()
        {
            
            Assert.Throws<ArgumentNullException>(() => 
                new Car("Toyota", 2020, null, CarBodyType.Sedan));
        }

        private Car CreateTestCar()
        {
            return new Car("Toyota", 2020, "XTA21099765432101", CarBodyType.Sedan);
        }
    }
}