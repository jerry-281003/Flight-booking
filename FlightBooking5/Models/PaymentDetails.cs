namespace FlightBooking5.Models
{
	public class PaymentDetails
	{
		public int Id { get; set; }
		public string PaymentId { get; set; }
		public String Amount { get; set; }
		public string Status { get; set; }
		public DateTime PaymentDate { get; set; }
	}
}
