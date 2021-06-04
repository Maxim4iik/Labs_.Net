///Розробити структуру даних для зберігання інформації про автомобілі.
///Для об'єктів зберігається наступна інформація:
///вантажний автомобіль - марка автомобіля, вантажопідйомність, дата випуску, дата капітального ремонту, державний номер, шифр автопарку;
///таксі - марка автомобіля, кількість посадкових місць, дата випуску, державний номер,шифр автопарку;
///автопарк - назва, адреса розміщення, площа для розміщення автомобілів, шифр


using System;
using System.Collections.Generic;
using System.Linq;


namespace Laba4
{
    class Program
    {
        public class CarPark
        {
            public string Name;
            public string Address;
            public float AreaOfCarsLocation;
            public string Code;
            public CarPark(string Name, string Address, float AreaOfCarsLocation, string Code)
            {
                this.Name = Name;
                this.Address = Address;
                this.AreaOfCarsLocation = AreaOfCarsLocation;
                this.Code = Code;
            }
        }

        public class Truck
        {
            public string CarBrand;
            public float LoadCapacity;
            public DateTime DateOfIssue;
            public DateTime DateOfOverhaul;
            public string StateNumber;
            public string VehicleFleetCode;
            public Truck(string CarBrand, float LoadCapacity, DateTime DateOfIssue, DateTime DateOfOverhaul, string StateNumber, string VehicleFleetCode)
            {
                this.CarBrand = CarBrand;
                this.LoadCapacity = LoadCapacity;
                this.DateOfIssue = DateOfIssue;
                this.DateOfOverhaul = DateOfOverhaul;
                this.StateNumber = StateNumber;
                this.VehicleFleetCode = VehicleFleetCode;
            }
        }

        public class Taxi
        {
            public string CarBrand;
            public int NumberOfSeats;
            public DateTime DateOfIssue;
            public string StateNumber;
            public string VehicleFleetCode;

            public Taxi(string CarBrand, int NumberOfSeats, DateTime DateOfIssue, string StateNumber, string VehicleFleetCode)
            {
                this.CarBrand = CarBrand;
                this.NumberOfSeats = NumberOfSeats;
                this.DateOfIssue = DateOfIssue;
                this.StateNumber = StateNumber;
                this.VehicleFleetCode = VehicleFleetCode;
            }
        }

        static void Main(string[] args)
        {
            List<CarPark> vehicleFleets = new List<CarPark>()
            {
                new CarPark("Small Feet", "xxx", 160, "123A"),
                new CarPark("Middle Feet", "xxx", 350, "123B"),
                new CarPark("Big Feet", "xxx", 500, "123C"),
                new CarPark("Super big Feet", "xxx", 700, "123D"),
            };

            List<Truck> trucks = new List<Truck>()
            {
                new Truck ( "Volkswagen", 1, new DateTime(2013, 4, 15), new DateTime(2014, 6, 10), "AI4781ХР", vehicleFleets[1].Code),
                new Truck ( "Volvo", 5, new DateTime(2015, 2, 21), new DateTime(2015, 11, 17), "AA2864КМ", vehicleFleets[2].Code),
                new Truck ( "Scania", 3, new DateTime(2010, 6, 13), new DateTime(2012, 4, 1), "AA5687AB", vehicleFleets[1].Code),
                new Truck ( "Mercedes-Benz", 7, new DateTime(2013, 7, 4), new DateTime(2014, 7, 12), "AA6577HP", vehicleFleets[3].Code),
                new Truck ( "MAZ", 10, new DateTime(2014, 3, 26), new DateTime(2015, 9, 15), "KA5894KA", vehicleFleets[3].Code),
            };

            List<Taxi> taxis = new List<Taxi>()
            {
                new Taxi ( "Opel", 4, new DateTime(2011, 6, 16), "AM6745BC", vehicleFleets[0].Code),
                new Taxi ( "Ford", 4, new DateTime(2014, 2, 17), "AK7648MD", vehicleFleets[1].Code),
                new Taxi ( "Honda", 1, new DateTime(2012, 10, 4), "KAO897PO", vehicleFleets[0].Code),
                new Taxi ( "Kia", 4, new DateTime(2011, 7, 14), "KA3674KO", vehicleFleets[1].Code),
                new Taxi ( "Hyundai", 4, new DateTime(2013, 8, 27), "KA3543EX", vehicleFleets[0].Code),
            };

            Console.WriteLine("Простая выборка грузовиков:");
            var q1 = from x in trucks
                     select x;
            foreach (var x in q1)
                Console.WriteLine("Марка:" + x.CarBrand + " Дата выпуска:" + x.DateOfIssue + " Госномер:" + x.StateNumber);

            Console.WriteLine();
            Console.WriteLine("Выборка марок такси:");
            var q2 = from x in taxis
                     select x.CarBrand;
            foreach (var x in q2)
                Console.WriteLine(x);

            Console.WriteLine();
            Console.WriteLine("Выборка автопарков, у которых площадь > 300:");
            var q3 = from x in vehicleFleets
                     where x.AreaOfCarsLocation > 300
                     select x;
            foreach (var x in q3)
                Console.WriteLine(x.Name);

            Console.WriteLine();
            Console.WriteLine("Грузоподъемность по уменьшению:");
            var q4 = from x in trucks
                     orderby x.LoadCapacity descending
                     select x.LoadCapacity;
            foreach (var x in q4)
                Console.WriteLine(x);

            Console.WriteLine();
            Console.WriteLine("Элемент с заданной позиции (3):");
            var q5 = (from x in vehicleFleets select x).ElementAt(3);
            Console.WriteLine(q5.Name);

            Console.WriteLine();
            Console.WriteLine("Марка и госномер первого такси из выборки:");
            var q6 = (from x in taxis select x).First();
            Console.WriteLine(q6.CarBrand + " " + q6.StateNumber);

            Console.WriteLine();
            Console.WriteLine("Марка и госномер такси, номер которых начинается на 'К'");
            var q7 = from x in taxis
                     where x.StateNumber.StartsWith("K")
                     select x;
            foreach (var x in q7)
                Console.WriteLine(x.CarBrand + " " + x.StateNumber);

            Console.WriteLine();
            Console.WriteLine("Превратим результат выборки грузовиков в Dictionary:");
            var q8 = (from x in trucks select x).ToDictionary(x => x.CarBrand);
            Console.WriteLine(q8.GetType().Name);
            foreach (var x in q8)
                Console.WriteLine(x);

            Console.WriteLine();
            Console.WriteLine("Самая большая грузоподъемность:");
            var q9 = trucks.Max(n => n.LoadCapacity);
            Console.WriteLine(q9);

            Console.WriteLine();
            Console.WriteLine("Номера такси, по номеру автопарка:");
            var q10 = from x in taxis
                      group x by x.VehicleFleetCode;
            foreach (IGrouping<string, Taxi> t in q10)
            {
                Console.WriteLine(t.Key);
                foreach (var x in t)
                    Console.WriteLine(x.StateNumber);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Проверим соответсвия между допущением и правдой на счет грузовиков:");
            var q11 = trucks.All(x => x.LoadCapacity > 5);
            if (q11)
                Console.WriteLine("У всех грузовиков грузоподъемность 5+ тонн.");
            else
                Console.WriteLine("Есть грузовики с грузоподъемностью <5 тонн.");

            var q12 = trucks.All(x => x.CarBrand.StartsWith("M"));
            if (q12)
                Console.WriteLine("Марки всех грузовиков начинаются на 'M'.");
            else
                Console.WriteLine("Марки не всех грузовиков начинаются на 'M'.");

            Console.WriteLine();
            Console.WriteLine("Коды автопарков, которые начинаются с '1'");
            var q13 = vehicleFleets.Any(x => x.Code.StartsWith("1"));
            if (q13)
                Console.WriteLine("Есть коды автопарков, которые начинаются с 1");

            Console.WriteLine();
            Console.WriteLine("Создание нового обьекта грузовиков анонимного типа:");
            var q14 = from x in trucks
                      select new { IDENTIFIER = x.CarBrand, VALUE = x.StateNumber };
            foreach (var x in q14)
                Console.WriteLine(x);

            Console.WriteLine();
            Console.WriteLine("Результат выборки такси в массив:");
            var q15 = (from x in taxis select x).ToArray();
            foreach (var x in q15)
                Console.WriteLine(x.CarBrand);
        }
    }
}
