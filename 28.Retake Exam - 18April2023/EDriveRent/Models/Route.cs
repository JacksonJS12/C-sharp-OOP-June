using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double lenght;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Length = length;
            this.RouteId = routeId;
        }
        public string StartPoint
        {
            get
            {
                return this.startPoint;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }
                this.startPoint = value;
            }
        }
        public string EndPoint
        {
            get
            {
                return this.endPoint;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }
                this.endPoint = value;
            }
        }
        public double Length
        {
            get
            {
                return this.lenght;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }
                this.lenght = value;
            }
        }
        public int RouteId { get; private set; }
        public bool IsLocked { get; private set; }
        public void LockRoute()
        {
            if (this.IsLocked == false)
            {
                this.IsLocked = true;
                return;
            }
        }
    }
}
