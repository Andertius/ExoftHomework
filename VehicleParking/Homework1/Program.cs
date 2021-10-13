namespace Homework1
{
    class Program
    {
        static void Main()
        {
            var park = new Parking
            {
                new Car("Mercedes", 2019, "WRC-12KS"),
                new Car("Lada", 1965, "2304572"),
                new Lorry("MAN", 2014, "ROEKC21"),
                new Car("Fiat", 2004, "FROF-23K7"),
                new Bicycle("Super73", 2021, "LUNAVSD"),
                new Motorcycle("Yamaha", 2018, "GHJFO:FI2")
            };

            park.ListAllVehicles();
        }
    }
}
