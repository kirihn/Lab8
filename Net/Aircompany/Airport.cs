using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();

            foreach (var plane in Planes)
            {
                if (plane is PassengerPlane passengerPlane)
                {
                    passengerPlanes.Add(passengerPlane);
                }
            }

            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();

            foreach (var plane in Planes)
            {
                if (plane is MilitaryPlane militaryPlane)
                {
                    militaryPlanes.Add(militaryPlane);
                }
            }

            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            List<PassengerPlane> passengerPlanes = GetPassengersPlanes(); // w, x
            return passengerPlanes.Aggregate((planeWithMaxCapacity, currentPlane) => planeWithMaxCapacity
            .GetPassengersPlaneCapacity() > currentPlane.GetPassengersPlaneCapacity() ? planeWithMaxCapacity : currentPlane);             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();
            return militaryPlanes.Where(plane => plane.GetPlaneType() == MilitaryType.Transport).ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(plane => plane.GetMaxFlightDistance())); // w
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(plane => plane.GetMaxSpeed())); // w
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(plane => plane.GetMaxLoadCapacity())); // w
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return Planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}
