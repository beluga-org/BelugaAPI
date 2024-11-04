namespace BookingServiceAPI.Common
{
    public class DateString
    {
        public DateTime ToDateTime(string date)
        {
            try
            {
                string strCultureInfo = "pt-BR";
                DateTime dateReturn = DateTime.Parse(date, new System.Globalization.CultureInfo(strCultureInfo));

                return dateReturn;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }
    }
}
