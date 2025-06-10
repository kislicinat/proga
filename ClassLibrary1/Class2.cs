using System;

namespace AutoSalonLibrary
{
    public class UsedCar : Car
    {
        public int Mileage { get; set; }
        public string Condition { get; set; }

        public UsedCar(string brand, int year, string vin, CarBodyType bodyType,
                      int mileage, string condition)
            : base(brand, year, vin, bodyType)
        {
            Mileage = mileage;
            Condition = condition;
        }

        public override string[] GetInfo()
        {
            var info = base.GetInfo();
            return new string[]
            {
                info[0],
                info[1],
                $"Подержанное авто. Пробег: {Mileage} км, Состояние: {Condition}",
                info[2]
            };
        }
    }

    public class CommissionedCar : UsedCar
    {
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string ContractNumber { get; set; }

        public CommissionedCar(string brand, int year, string vin, CarBodyType bodyType,
                              int mileage, string condition, string ownerName,
                              string ownerAddress, string contractNumber)
            : base(brand, year, vin, bodyType, mileage, condition)
        {
            OwnerName = ownerName;
            OwnerAddress = ownerAddress;
            ContractNumber = contractNumber;
        }

        public override string[] GetInfo()
        {
            var info = base.GetInfo();
            return new string[]
            {
                info[0],
                info[1],
                info[2],
                $"Комиссионный авто. Владелец: {OwnerName}, Адрес: {OwnerAddress}",
                $"Номер договора: {ContractNumber}"
            };
        }
    }
}