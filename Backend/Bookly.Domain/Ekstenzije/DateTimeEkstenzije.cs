namespace Bookly.Domain.Ekstenzije
{
    internal static class DateTimeEkstenzije
    {
        internal static bool DatumUOpsegu(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            if (dateToCheck.Date >= startDate.Date && dateToCheck.Date <= endDate.Date) return true;
            else return false;
        }
    }
}
