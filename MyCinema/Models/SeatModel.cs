namespace MyCinema.Models
{
    public class SeatModel
    {
        public uint Id { get; set; }
        public uint Movie_Id { get; set; }
        public uint Seat_Row { get; set; }
        public uint Seat_Number { get; set; }
        public uint Seat_Status { get; set; }
    }
}