using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            for (int i=0; i < planes.Count; i++)
            {
                if (planes[i].GetType() == typeof(PassengerPlane))
                {
                    passengerPlanes.Add((PassengerPlane)planes[i]);
                }
            }
            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i].GetType() == typeof(MilitaryPlane))
                {
                    militaryPlanes.Add((MilitaryPlane)planes[i]);
                }
            }
            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            List<PassengerPlane> passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((current, next) => current.GetPassengersCapacity() > next.GetPassengersCapacity() ? current : next);             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            List<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();
            for (int i = 0; i < militaryPlanes.Count; i++)
            {
                MilitaryPlane plane = militaryPlanes[i];
                if (plane.GetPlaneType() == MilitaryTypes.TRANSPORT)
                {
                    transportMilitaryPlanes.Add(plane);
                }
            }

            return transportMilitaryPlanes;
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(planes.OrderBy(plane => plane.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(planes.OrderBy(plane => plane.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(planes.OrderBy(plane => plane.GetMaxLoadCapacity()));
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", planes.Select(plane => plane.GetModel())) +
                    '}';
        }
    }
}
