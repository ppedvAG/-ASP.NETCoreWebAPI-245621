using HelloDependency.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelloDependency
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var provider = RegisterTypes();

            // Hier nur als Beispiel: In der Praxis werden wir nie mit dem Provider arbeiten
            var timeService = provider.GetRequiredService<ITimeService>();
            Console.WriteLine(timeService.ShowTime());

            provider.GetRequiredService<ClockService>().Run();

            Console.ReadKey(true);
        }

        private static ServiceProvider RegisterTypes()
        {
            // Wie ein Lookup fuer alle registrierten Dienste
            var serviceContainer = new ServiceCollection();

            // Wir registrieren die konkrete Implementierung des Service gegen das Interface ITimeService
            serviceContainer.AddTransient<ITimeService, CurrentTimeService>();

            // Hier wird die vorherige Registrierung ueberschrieben
            serviceContainer.AddTransient<ITimeService, UniversalTimeService>();

            serviceContainer.AddSingleton<ClockService>();

            return serviceContainer.BuildServiceProvider();
        }

        public class ClockService
        {
            private readonly ITimeService timeService;

            public ClockService(ITimeService timeService)
            {
                this.timeService = timeService;
            }

            public void Run()
            {
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += (sender, e) => Console.WriteLine(timeService.ShowTime());
                timer.Start();
            }
        }
    }
}
