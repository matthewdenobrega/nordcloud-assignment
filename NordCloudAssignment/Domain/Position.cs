using System;

namespace NordCloudAssignment.Domain
{
    public class Position
    {
        public double X { get; }
        public double Y { get; }

        #region Constructor
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Public
        public double DistanceFrom(Position position)
        {
            if (position == null) throw new ArgumentException("Position must be supplied to calculate distance");

            return Math.Sqrt(Math.Pow((X - position.X), 2) + Math.Pow((Y - position.Y), 2));
        }
        #endregion
    }
}
