namespace lab3;

public interface IDateTimeService
{
    string Period {get; }
}

public class DateTimeService : IDateTimeService
{
    private string period = "";
    
    public DateTimeService()
    {
        GetDateTime();
    }
    
    public void GetDateTime()
    {
        var currentTime = DateTime.Now.Hour;

        if (currentTime >= 12 && currentTime <= 17)
        {
            period = "Afternoon";
        }
        if (currentTime >= 17 || currentTime < 6)
        {
            period = "Evening";
        }
        if (currentTime >= 6 && currentTime < 12)
        {
            period = "Morning";
        }
        else
        {
            period =  "Night";
        }
    }

    public string Period
    {
        get => period;
    }
}