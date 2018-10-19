using System;

namespace NordCloudAssignment.Domain
{
    public class LinkStation
    {
        public Position Position { get; }
        public double Reach { get; }

        #region Constructor
        public LinkStation(Position position, double reach)
        {
            Position = position ?? throw new ArgumentException();
            Reach = reach;
        }
        #endregion

        #region Public
        public double PowerAtPosition(Position position)
        {
            if (position == null) throw new ArgumentException("Position must be supplied to calculate power");

            return Math.Pow(Math.Max(0, Reach - Position.DistanceFrom(position)), 2);
        }
        #endregion
    }
}
