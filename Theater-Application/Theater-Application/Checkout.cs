namespace Theater_Application
{
	public readonly struct Ticket
	{
		public readonly TicketType ticketType;
		public readonly decimal ticketPrice;

		public Ticket(TicketType ticketType)
		{
			this.ticketType = ticketType;
			switch (ticketType)
			{
				case TicketType.Child: ticketPrice = 10.69M; break;
				case TicketType.Senior: ticketPrice = 12.69M; break;
				case TicketType.Military: ticketPrice = 12.69M; break;
				case TicketType.Student: ticketPrice = 12.69M; break;
				default: ticketPrice = 13.69M; break;
			}
		}
	}

	public enum TicketType
	{
		Child, Adult, Military, Senior, Student
	}

	public enum CardType
	{
		Visa, Mastercard, American_Express, Discover
	}
}