namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Providers;

    public class DefenseModeCommand : ICommand
    {
        private readonly ITankFinder _tankFinder;

        public DefenseModeCommand(ITankFinder tankFinder)
        {
            this._tankFinder = tankFinder;;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var tank = this._tankFinder.FindTank(args.First());

            if (tank == null)
            {
                return "Tank with that name could not be found.";
            }

            tank.ToggleDefenseMode();

            return "Tank " + tank.Name + " toggled defense mode";

        }
    }
}
