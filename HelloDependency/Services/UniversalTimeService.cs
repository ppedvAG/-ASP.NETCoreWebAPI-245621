using HelloDependency.Services;

namespace HelloDependency
{
    internal partial class Program
    {
        public class UniversalTimeService : ITimeService
        {
            public string ShowTime()
            {
                return "UTC time: " + DateTime.UtcNow.ToString();
            }
        }
    }
}
