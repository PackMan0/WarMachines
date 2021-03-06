﻿namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using Models;
    using Providers;

    public class AttackCommand : ICommand
    {
        private readonly IMachineFinder _machineFinder;

        public AttackCommand(IMachineFinder machineFinder)
        {
            this._machineFinder = machineFinder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var attacker = this._machineFinder.FindMachine(args.First());
            var defender = this._machineFinder.FindMachine(args.Last());

            if (attacker == null)
            {
                return "Machine with that name could not be found.";
            }
            else if (defender == null)
            {
                return "Machine with that name could not be found.";
            }
            else if (attacker is ITank && defender is IFighter && ((IFighter)defender).StealthMode)
            {
                return "Machine" + attacker.Name + " cannot attack stealth fighter " + defender.Name;
            }
            else if (defender is ITank && ((ITank)defender).DefenseMode)
            {
                return "Machine" + attacker.Name + " cannot attack stealth fighter " + defender.Name;
            }
            else
            {
                defender.HealthPoints -= attacker.AttackPoints;

                return "Machine " + defender.Name + " was attacked by machine " + attacker.Name + " - current health: " + defender.HealthPoints;
            }

        }
    }
}
