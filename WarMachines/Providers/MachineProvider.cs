namespace WarMachines.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Models;

    public class MachineProvider : IFighterAdder, IPilotAdder, ITankAdder, IPilotFinder, IFighterFinder, ITankFinder, IMachineFinder
    {
        private readonly IDictionary<string, IFighter> _fighters;
        private readonly IDictionary<string, ITank> _tanks;
        private readonly IDictionary<string, IPilot> _pilots;

        public MachineProvider()
        {
            this._fighters = new Dictionary<string, IFighter>();
            this._tanks = new Dictionary<string, ITank>();
            this._pilots = new Dictionary<string, IPilot>();
        }

        public bool AddFighter(IFighter fighter)
        {
            if (!this._fighters.ContainsKey(fighter.Name))
            {
                this._fighters.Add(fighter.Name, fighter);

                return true;
            }

            return false;
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

        public bool AddTank(ITank tank)
        {
            if (!this._tanks.ContainsKey(tank.Name))
            {
                this._tanks.Add(tank.Name, tank);

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

        public IFighter FindFighter(string name)
        {
            if (this._fighters.ContainsKey(name))
            {
                return this._fighters[name];
            }

            return null;
        }

        public ITank FindTank(string name)
        {
            if (this._tanks.ContainsKey(name))
            {
                return this._tanks[name];
            }

            return null;
        }

        public IMachine FindMachine(string name)
        {
            return (IMachine) this.FindFighter(name) ?? this.FindTank(name);
        }
    }
}
