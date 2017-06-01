namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Providers;

    public class ReportCommand : ICommand
    {
        private readonly IPilotFinder _pilotFinder;

        public ReportCommand(IPilotFinder pilotFinder)
        {
            this._pilotFinder = pilotFinder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var pilot = this._pilotFinder.FindPilot(args.First());

            if (pilot == null)
            {
                return "Pilot with that name does not exist";
            }

            return pilot.Report();
        }
    }
}
