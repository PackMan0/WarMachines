namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Providers;

    public class StealthModeCommand : ICommand
    {
        private readonly IFighterFinder _fighterFinder;

        public StealthModeCommand(IFighterFinder fighterFinder)
        {
            this._fighterFinder = fighterFinder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var fighter = this._fighterFinder.FindFighter(args.First());

            if (fighter == null)
            {
                return "Fighter with that name could not be found.";
            }

            fighter.ToggleStealthMode();

            return "Fighter " + fighter.Name + " toggled stealth mode";
        }
    }
}
