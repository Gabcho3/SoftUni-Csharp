using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int Capacity;

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }
        
        public List<Car> Cars { get { return cars; } set { cars = value; } }

        public int Count => Cars.Count;

        public string AddCar(Car car)
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!"; //checked
            }

            if (Cars.Count >= Capacity)
            {
                return "Parking is full!"; //checked
            }

            Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}"; //checked
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!"; //checked
            }

            else
            {
                Car car = Cars.Find(x => x.RegistrationNumber == registrationNumber);
                Cars.Remove(car);
                return $"Successfully removed {car.RegistrationNumber}"; //checked
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = Cars.Find(x => x.RegistrationNumber == registrationNumber);
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                Cars.RemoveAll(x => x.RegistrationNumber == number); //checked
            }
        }
    }
}
