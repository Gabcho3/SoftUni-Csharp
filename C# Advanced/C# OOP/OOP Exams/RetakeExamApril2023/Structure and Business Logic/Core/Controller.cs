using EDriveRent.Core.Contracts;
using EDriveRent.Models.Contracts;
using EDriveRent.Models.Routes;
using EDriveRent.Models.Users;
using EDriveRent.Models.Vehicles;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users = new UserRepository();
        private VehicleRepository vehicles = new VehicleRepository();
        private RouteRepository routes = new RouteRepository();
        private List<string> vehiclesTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "EDriveRent.Models.Vehicles").Select(t => t.Name).ToList();

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if (routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length))
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }

            if (routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length <= length))
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint, length);
            }

            IRoute routeToLock = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);
            routeToLock?.LockRoute();

            IRoute route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            routes.AddModel(route);
            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            IRoute route = routes.FindById(routeId);

            if (user.IsBlocked)
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);

            if (vehicle.IsDamaged)
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);

            if (route.IsLocked)
                return string.Format(OutputMessages.RouteLocked, routeId);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }

            else
                user.IncreaseRating();

            vehicle.Drive(route.Length);
            return vehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.FindById(drivingLicenseNumber) != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);
            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string RepairVehicles(int count)
        {
            List<IVehicle> damagedVehicles = vehicles.GetAll().Where(v => v.IsDamaged)
                .OrderBy(v => v.Brand).ThenBy(v => v.Model).Take(count).ToList();

            foreach(var vehicle in damagedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            return string.Format(OutputMessages.RepairedVehicles, damagedVehicles.Count);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (!vehiclesTypes.Contains(vehicleType))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (vehicles.FindById(licensePlateNumber) != null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == vehicleType).First();
            IVehicle vehicle = Activator.CreateInstance(type, new object[] { brand, model, licensePlateNumber }) as IVehicle;
            vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string UsersReport()
        {
            List<IUser> users = this.users.GetAll().OrderByDescending(u => u.Rating).ThenBy(u => u.LastName).ThenBy(u => u.FirstName).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var user in users)
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
