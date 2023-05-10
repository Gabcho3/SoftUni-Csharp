using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDriveRent.Models.Routes
{
    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double length;
        private bool isLocked;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Length = length;
            RouteId = routeId;
            isLocked = false;
        }

        public string StartPoint
        {
            get { return startPoint; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }
                startPoint = value;
            }
        }

        public string EndPoint
        {
            get { return endPoint; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }
                endPoint = value;
            }
        }

        public double Length
        {
            get { return length; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }
                length = value;
            }
        }

        public int RouteId { get; }

        public bool IsLocked => isLocked;

        public void LockRoute()
        {
            isLocked = true;
        }
    }
}
