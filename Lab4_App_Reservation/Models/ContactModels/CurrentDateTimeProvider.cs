namespace Lab4_App_Reservation.Models.ContactModels
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
