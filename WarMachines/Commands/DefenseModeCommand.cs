﻿namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Providers;

    public class DefenseModeCommand : ICommand
    {
        private readonly IMachineFinder _machineFinder;

        public DefenseModeCommand(IMachineFinder machineFinder)
        {
            this._machineFinder = machineFinder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var machine = this._machineFinder.FindMachine(args.First());

            if (machine == null)
            {
                return "Machine with that name could not be found.";
            }

            return "Tank " + machine.Name + " toggled defense mode";

        }
    }
}