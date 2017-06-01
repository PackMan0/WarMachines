namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Providers;

    public class HirePilotCommand : ICommand
    {
        private readonly IPilotFactory _pilotFactory;
        private readonly IPilotAdder _pilotAdder;

        public HirePilotCommand(IPilotFactory pilotFactory, IPilotAdder pilotAdder)
        {
            this._pilotFactory = pilotFactory;
            this._pilotAdder = pilotAdder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var pilot = this._pilotFactory.CreatePilot(args.First());

            if (this._pilotAdder.AddPilot(pilot))
            {
                return "Pilot " + pilot.Name + " hired";
            }

            return "Pilot with same name exists";
        }
    }
}
