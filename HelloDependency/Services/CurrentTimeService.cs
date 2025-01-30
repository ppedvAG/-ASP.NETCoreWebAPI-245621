namespace HelloDependency.Services
{
    public class CurrentTimeService : ITimeService
    {
        public string ShowTime()
        {
            var now = DateTime.Now.ToString();
            return now;
        }
    }
}
