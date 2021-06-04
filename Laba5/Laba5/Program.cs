using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Laba5
{
    class Program
    {
        public class VehicleFleet
        {
            public string Name;
            public string Address;
            public float AreaOfCarsLocation;
            public string Code;
            public VehicleFleet(string Name, string Address, float AreaOfCarsLocation, string Code)
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
            IList<VehicleFleet> vehicleFleets = new List<VehicleFleet>()
            {
                new VehicleFleet("Small Feet", "xxx", 160, "123A"),
                new VehicleFleet("Middle Feet", "xxx", 350, "123B"),
                new VehicleFleet("Big Feet", "xxx", 500, "123C"),
                new VehicleFleet("Super big Feet", "xxx", 700, "123D"),
            };

            IList<Truck> trucks = new List<Truck>()
            {
                new Truck ( "Volkswagen", 1, new DateTime(2013, 4, 15), new DateTime(2014, 6, 10), "AI4781ХР", vehicleFleets[1].Code),
                new Truck ( "Volvo", 5, new DateTime(2015, 2, 21), new DateTime(2015, 11, 17), "AA2864КМ", vehicleFleets[2].Code),
                new Truck ( "Scania", 3, new DateTime(2010, 6, 13), new DateTime(2012, 4, 1), "AA5687AB", vehicleFleets[1].Code),
                new Truck ( "Mercedes-Benz", 7, new DateTime(2013, 7, 4), new DateTime(2014, 7, 12), "AA6577HP", vehicleFleets[3].Code),
                new Truck ( "MAZ", 10, new DateTime(2014, 3, 26), new DateTime(2015, 9, 15), "KA5894KA", vehicleFleets[3].Code),
            };

            IList<Taxi> taxis = new List<Taxi>()
            {
                new Taxi ( "Opel", 4, new DateTime(2011, 6, 16), "AM6745BC", vehicleFleets[0].Code),
                new Taxi ( "Ford", 4, new DateTime(2014, 2, 17), "AK7648MD", vehicleFleets[1].Code),
                new Taxi ( "Honda", 1, new DateTime(2012, 10, 4), "KAO897PO", vehicleFleets[0].Code),
                new Taxi ( "Kia", 4, new DateTime(2011, 7, 14), "KA3674KO", vehicleFleets[1].Code),
                new Taxi ( "Hyundai", 4, new DateTime(2013, 8, 27), "KA3543EX", vehicleFleets[0].Code),
            };

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("vehicleFleets.xml", settings))
            {
                writer.WriteStartElement("vehicleFleets");

                foreach (VehicleFleet vehicleFleet in vehicleFleets)
                {
                    writer.WriteStartElement("vehicleFleet");
                    writer.WriteElementString("name", vehicleFleet.Name);
                    writer.WriteElementString("address", vehicleFleet.Address);
                    writer.WriteElementString("areaOfCarsLocation", vehicleFleet.AreaOfCarsLocation.ToString());
                    writer.WriteElementString("code", vehicleFleet.Code.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("trucks.xml", settings))
            {
                writer.WriteStartElement("trucks");

                foreach (Truck truck in trucks)
                {
                    writer.WriteStartElement("truck");
                    writer.WriteElementString("carBrand", truck.CarBrand);
                    writer.WriteElementString("loadCapacity", truck.LoadCapacity.ToString());
                    writer.WriteElementString("dateOfIssue", truck.DateOfIssue.ToString());
                    writer.WriteElementString("dateOfOverhaul", truck.DateOfOverhaul.ToString());
                    writer.WriteElementString("stateNumber", truck.StateNumber);
                    writer.WriteElementString("vehicleFleetCode", truck.VehicleFleetCode);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create("taxis.xml", settings))
            {
                writer.WriteStartElement("taxis");

                foreach (Taxi taxi in taxis)
                {
                    writer.WriteStartElement("taxi");
                    writer.WriteElementString("carBrand", taxi.CarBrand);
                    writer.WriteElementString("numberOfSeats", taxi.NumberOfSeats.ToString());
                    writer.WriteElementString("dateOfIssue", taxi.DateOfIssue.ToString());
                    writer.WriteElementString("stateNumber", taxi.StateNumber);
                    writer.WriteElementString("vehicleFleetCode", taxi.VehicleFleetCode);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            XmlDocument doc_vehicleFleet = new XmlDocument();
            doc_vehicleFleet.Load("vehicleFleets.xml");

            XmlDocument doc_truck = new XmlDocument();
            doc_truck.Load("trucks.xml");

            XmlDocument doc_taxi = new XmlDocument();
            doc_taxi.Load("taxis.xml");

            foreach (XmlNode node in doc_vehicleFleet.DocumentElement)
            {
                string name = node["name"].InnerText;
                string address = node["address"].InnerText;
                float areaOfCarsLocation = float.Parse(node["areaOfCarsLocation"].InnerText);
                string code = node["code"].InnerText;
                Console.WriteLine(string.Format("name = {0}; address = {1}; areaOfCarsLocation = {2}; code = {3};", name, address, areaOfCarsLocation, code)); 
            }

            Console.WriteLine();
            foreach (XmlNode node in doc_truck.DocumentElement)
            {
                string carBrand = node["carBrand"].InnerText;
                string loadCapacity = node["loadCapacity"].InnerText;
                DateTime dateOfIssue = DateTime.Parse(node["dateOfIssue"].InnerText);
                DateTime dateOfOverhaul = DateTime.Parse(node["dateOfOverhaul"].InnerText);
                string stateNumber = node["stateNumber"].InnerText;
                string vehicleFleetCode = node["vehicleFleetCode"].InnerText;
                Console.WriteLine(string.Format("carBrand = {0}; loadCapacity = {1}; dateOfIssue = {2}; dateOfOverhaul = {3}; stateNumber = {4}; vehicleFleetCode = {5};", carBrand, loadCapacity, dateOfIssue, dateOfOverhaul, stateNumber, vehicleFleetCode));
            }

            Console.WriteLine();
            foreach (XmlNode node in doc_taxi.DocumentElement)
            {
                string carBrand = node["carBrand"].InnerText;
                int numberOfSeats = Int32.Parse(node["numberOfSeats"].InnerText);
                DateTime dateOfIssue = DateTime.Parse(node["dateOfIssue"].InnerText);
                string stateNumber = node["stateNumber"].InnerText;
                string vehicleFleetCode = node["vehicleFleetCode"].InnerText;
                Console.WriteLine(string.Format("carBrand = {0}; numberOfSeats = {1}; dateOfIssue = {2}; stateNumber = {3}; vehicleFleetCode = {4};", carBrand, numberOfSeats, dateOfIssue, stateNumber, vehicleFleetCode));
            }

            //    TRUCKS     //
            XDocument xml_trucks = XDocument.Load("trucks.xml");
            foreach (XElement truckElement in
            xml_trucks.Element("trucks").Elements("truck"))
            {
                XElement carBrandAttribute = truckElement.Element("carBrand");
                XElement loadCapacityElement = truckElement.Element("loadCapacity");
                XElement dateOfIssueElement = truckElement.Element("dateOfIssue");
                XElement dateOfOverhaulElement = truckElement.Element("dateOfOverhaul");
                XElement stateNumberElement = truckElement.Element("stateNumber");
                XElement vehicleFleetCodeElement = truckElement.Element("vehicleFleetCode");
            }

            //    VEHICLEFLEET    //
            XDocument xml_vehicleFleets = XDocument.Load("vehicleFleets.xml");
            foreach (XElement vehicleFleetElement in
            xml_vehicleFleets.Element("vehicleFleets").Elements("vehicleFleet"))
            {
                XElement name = vehicleFleetElement.Element("name");
                XElement address = vehicleFleetElement.Element("address");
                XElement areaOfCarsLocation = vehicleFleetElement.Element("areaOfCarsLocation");
                XElement code = vehicleFleetElement.Element("code");
            };

            //    TAXI    //
            XDocument xml_taxis = XDocument.Load("taxis.xml");
            foreach (XElement taxiElement in
            xml_taxis.Element("taxis").Elements("taxi"))
            {
                XElement carBrandAttribute = taxiElement.Element("carBrand");
                XElement numberOfSeatsElement = taxiElement.Element("numberOfSeats");
                XElement dateOfIssueElement = taxiElement.Element("dateOfIssue");
                XElement stateNumberElement = taxiElement.Element("stateNumber");
                XElement vehicleFleetCodeElement = taxiElement.Element("vehicleFleetCode");
            };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Q1//
            Console.WriteLine("Простая выборка грузовиков:");
            var q1 = from xe in xml_trucks.Element("trucks").Elements("truck")
                        select new 
                        {
                            CarBrand = xe.Element("carBrand").Value,
                            LoadCapacity = float.Parse(xe.Element("loadCapacity").Value),
                            DateOfIssue = DateTime.Parse(xe.Element("dateOfIssue").Value),
                            DateOfOverhaul = DateTime.Parse(xe.Element("dateOfOverhaul").Value),
                            StateNumber = xe.Element("stateNumber").Value,
                            VehicleFleetCode = xe.Element("vehicleFleetCode").Value
                        };

            foreach (var item in q1)
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", item.CarBrand, item.LoadCapacity, item.DateOfIssue, item.DateOfOverhaul, item.StateNumber, item.VehicleFleetCode);

            //Q2//
            Console.WriteLine();
            Console.WriteLine("Марки такси, которые начинаются на 'F':");
            var q2 = from x in xml_taxis.Root.Elements("taxi")
                      where x.Element("carBrand").Value.StartsWith("F")
                      select x;

            foreach (var item in q2)
                Console.WriteLine("{0}", item.Element("carBrand").Value);
           
            //Q3//
            Console.WriteLine();
            Console.WriteLine("Название и площадки парковок, отсортированные по площади:");
            var q3 = xml_vehicleFleets.Descendants("vehicleFleet")
                .OrderBy(el => float.Parse(el.Element("areaOfCarsLocation").Value))
                .Select(el => new
                { Name = el.Element("name").Value, AreaOfCarsLocation = el.Element("areaOfCarsLocation").Value });

            foreach(var el in q3)
                Console.WriteLine("{0} - {1}", el.Name, el.AreaOfCarsLocation);

            //Q4//
            Console.WriteLine();
            Console.WriteLine("Вывод количества грузовиков с грузоподъемностью =>10:");
            IEnumerable<XElement> q4 =
            from x in xml_trucks.Root.Elements("truck")
            where (int)x.Element("loadCapacity") == 10
            select x;
            Console.WriteLine(q4.FirstOrDefault().Element("stateNumber").Value);

            //Q5//
            Console.WriteLine();
            Console.WriteLine("Вывод самого маленького количества мест в такси:");
            var q5 = xml_taxis.Descendants("taxi").Min(el => el.Element("numberOfSeats").Value);
            Console.WriteLine(q5);

            //Q6//
            Console.WriteLine();
            Console.WriteLine("Сумма площадей стоянок:");
            var q6 = xml_vehicleFleets.Descendants("vehicleFleet").Sum(el => float.Parse(el.Element("areaOfCarsLocation").Value));
            Console.WriteLine(q6);

            //Q7//
            Console.WriteLine();
            Console.WriteLine("Номера грузовиков, которые начинаются на 'A':");
            var q7 = from x in xml_trucks.Root.Elements("truck")
            where x.Element("stateNumber").Value.StartsWith("A")
            select x;

            foreach (var item in q7)
                Console.WriteLine("{0}", item.Element("stateNumber").Value);

            //Q8//
            Console.WriteLine();
            Console.WriteLine();
            var q8 = xml_taxis.Descendants("taxi").All(x => int.Parse(x.Element("numberOfSeats").Value) > 2);
            if (q8)
                Console.WriteLine("У всех такси > 2 мест.");
            else
                Console.WriteLine("Есть такси, у которых > 2 мест.");

            //Q9//
            Console.WriteLine();
            Console.WriteLine("Максимальная площадь стоянки:");
            var q9 = xml_vehicleFleets.Descendants("vehicleFleet").Max(el => el.Element("areaOfCarsLocation").Value);
            Console.WriteLine(q9);

            //Q10//
            Console.WriteLine();
            Console.WriteLine("Марка авто с последней позиции в списке:");
            var q10 = xml_taxis.Descendants("taxi").Select(el => el.Element("carBrand").Value).Last();
            Console.WriteLine(q10);
        }
    }
}