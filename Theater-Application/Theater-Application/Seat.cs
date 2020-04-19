namespace Theater_Application
{
    public struct Seat
    {
        public SeatStatus seatStatus;
    }

    public enum SeatStatus
    {
        Available, Reserved, Purchased, Null
    }
}
