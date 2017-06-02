namespace WarMachines.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Models;

    public class MachineProvider : IFighterAdder, IMachineFinder, IPilotAdder, IPilotFinder, ITankAdder
    {
        private readonly IDictionary<string, IMachine> _machines;
        private readonly IDictionary<string, IPilot> _pilots;

        public MachineProvider()
        {
            this._machines = new Dictionary<string, IMachine>();
            this._pilots = new Dictionary<string, IPilot>();
        }

        private bool AddMachine(IMachine machine)
        {
            if (!this._machines.ContainsKey(machine.Name))
            {
                this._machines.Add(machine.Name, machine);

                return true;
            }

            return false;
        }

        public bool AddFighter(IFighter fighter)
        {
            return this.AddMachine(fighter);
        }

        public IMachine FindMachine(string name)
        {
            if (this._machines.ContainsKey(name))
            {
                return this._machines[name];
            }

            return null;
        }

        public bool AddPilot(IPilot pilot)
        {
            if (!this._pilots.ContainsKey(pilot.Name))
            {
                this._pilots.Add(pilot.Name, pilot);

                return true;
            }

            return false;
        }

        public IPilot FindPilot(string name)
        {
            if (this._pilots.ContainsKey(name))
            {
                return this._pilots[name];
            }

            return null;
        }

        public bool AddTank(ITank tank)
        {
            return this.AddMachine(tank);
        }

    }
}
