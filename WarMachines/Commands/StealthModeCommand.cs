namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Providers;

    public class StealthModeCommand : ICommand
    {
        private readonly IMachineFinder _machineFinder;

        public StealthModeCommand(IMachineFinder machineFinder)
        {
            this._machineFinder = machineFinder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var fighter = (IFighter)this._machineFinder.FindMachine(args.First());

            if (fighter == null)
            {
                return "Fighter with that name could not be found.";
            }

            fighter.ToggleStealthMode();

            return "Fighter " + fighter.Name + " toggled stealth mode";
        }
    }
}
