using System;
using System.Collections.Generic;
using System.Linq;

namespace NordCloudAssignment.Domain
{
    public class PowerGrid
    {
        private ICollection<LinkStation> _linkStations;

        #region Constructor
        public PowerGrid(List<List<double>> gridConfiguration)
        {
            if (gridConfiguration == null) throw new ArgumentException("Grid configuration must be supplied");

            if (gridConfiguration.Any(gf => gf.Count != 3)) throw new ArgumentException("Each link station must have three parameters");

            _linkStations = gridConfiguration.Select(ls => new LinkStation(new Position(ls[0], ls[1]), ls[2])).ToList();
        }
        #endregion

        #region Public
        public string BestLinkStationForPositionMessage(Position position)
        {
            if (position == null) throw new ArgumentException("Position must be supplied to calculate best link station");

            var linkStationWithPower = IdentifyMostSuitableLinkStationForPosition(position);

            return linkStationWithPower != null ?
                $"Best link station for point {position.X}, {position.Y} is {linkStationWithPower.Item1.Position.X}, {linkStationWithPower.Item1.Position.Y} with power {linkStationWithPower.Item2}" :
                $"No link station within reach for point {position.X}, {position.Y}";
        }

        public Tuple<LinkStation, double> IdentifyMostSuitableLinkStationForPosition(Position position)
        {
            if (position == null) throw new ArgumentException("Position must be supplied to calculate best link station");

            var bestLinkStation = _linkStations.OrderByDescending(ls => ls.PowerAtPosition(position)).FirstOrDefault();
            var powerOfBestLinkStation = bestLinkStation.PowerAtPosition(position);

            return powerOfBestLinkStation > 0 ? Tuple.Create(bestLinkStation, bestLinkStation.PowerAtPosition(position)) : null;
        }

        public int NumberOfLinkStations()
        {
            return _linkStations?.Count ?? 0;
        }
        #endregion
    }
}
