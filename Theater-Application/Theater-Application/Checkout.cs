namespace Theater_Application
{
    public struct Ticket
    {
        public  TicketType ticketType;
    }

    public enum TicketType
    {
        Child, Adult, Military, Senior
    }

    public struct Card
    {
        public CardType cardType;
    }

    public enum CardType
    {
        Visa, Mastercard, American_Express, Discover
    }
}
