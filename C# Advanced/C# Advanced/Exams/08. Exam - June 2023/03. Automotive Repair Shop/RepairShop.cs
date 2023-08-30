using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            this.Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; }

        public List<Vehicle> Vehicles { get; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (this.Vehicles.Count < this.Capacity)
            {
                this.Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicleToRemove = this.Vehicles.Find(v => v.VIN == vin);
            return this.Vehicles.Remove(vehicleToRemove);
        }

        public int GetCount() => this.Vehicles.Count;

        public Vehicle GetLowestMileage()
        {
            int lowestMileage = this.Vehicles.Select(v => v.Mileage).Min();

            return this.Vehicles.Find(v => v.Mileage == lowestMileage);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");

            foreach (var vehicle in this.Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
