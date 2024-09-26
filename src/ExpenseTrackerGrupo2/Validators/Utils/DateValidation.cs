public class DateValidation
{
    public static bool Validate (DateTime date)
    {
        return date != default(DateTime);
    }
}