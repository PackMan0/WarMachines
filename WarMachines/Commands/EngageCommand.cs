namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Providers;

    public class EngageCommand : ICommand
    {
        private readonly IMachineFinder _machineFinder;
        private readonly IPilotFinder _pilotFinder;
        public EngageCommand(IMachineFinder machineFinder, IPilotFinder pilotFinder)
        {
            this._machineFinder = machineFinder;
            this._pilotFinder = pilotFinder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var pilot = this._pilotFinder.FindPilot(args.First());
            var machine = this._machineFinder.FindMachine(args.Last());

            if (pilot == null)
            {
                return "Pilot with that name could not be found.";
            }
            else if (machine == null)
            {
                return "Machine with that name could not be found.";
            }
            else if(machine.Pilot != null)
            {
                return "Machine " + machine.Name + " is already occupied.";
            }
            else
            {
                pilot.AddMachine(machine);
                machine.Pilot = pilot;

                return "Machine " + pilot.Name + " engaged machine  " + machine.Name;
            }

        }
    }
}
