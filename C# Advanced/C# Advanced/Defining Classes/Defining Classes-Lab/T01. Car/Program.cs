namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "BMW";
            car.Model = "BMW";
            car.Year = 2020;

            Console.WriteLine("Make: {0}\nModel: {1}\nYear: {2}", car.Make, car.Model, car.Year);
        }
    }
}