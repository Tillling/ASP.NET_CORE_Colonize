using System;

namespace Colonize.Website.Data.Entities
{
    public class Voyage
    {
        public int Id { get; protected set; }
        public Destination Destination { get; protected set; }
        public int DestinationId { get; protected set; }
        public Ship Ship { get; protected set; }
        public int ShipId { get; protected set; }
        public DateTime DepartureAt { get; protected set; }
        public DateTime ArrivedAt { get; protected set; }
        public Voyage(Destination destination, Ship ship, DateTime departureAt, DateTime arrivedAt)
        {
            Destination = destination;
            Ship = ship;
            DepartureAt = departureAt;
            ArrivedAt = arrivedAt;
        }
        public Voyage()
        {

        }

        public Voyage(int id, int destinationId, int shipId, DateTime departureAt, DateTime arrivedAt) :this(destinationId, shipId, departureAt, arrivedAt)
        {
            Id = id;
            
        }

        public Voyage(int destinationId, int shipId, DateTime departureAt, DateTime arrivedAt)
        {
            DestinationId = destinationId;
            ShipId = shipId;
            DepartureAt = departureAt;
            ArrivedAt = arrivedAt;
        }
    }
}
