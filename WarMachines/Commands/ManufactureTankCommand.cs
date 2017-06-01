namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Providers;

    class ManufactureTankCommand : ICommand
    {
        private readonly ITankFactory _tankFactory;
        private readonly ITankAdder _tankAdder;

        public ManufactureTankCommand(ITankFactory _tankFactory, ITankAdder _tankAdder)
        {
            this._tankFactory = _tankFactory;
            this._tankAdder = _tankAdder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var argsList = args.ToList();
            string name = argsList[0];
            int attackPoint;
            int defensePoints;

            if (!int.TryParse(argsList[1], out attackPoint))
            {
                return "Attack points are invalid";
            }

            if (!int.TryParse(argsList[2], out defensePoints))
            {
                return "Defense points are invalid";
            }

            var tank = this._tankFactory.CreateTank(name, attackPoint, defensePoints);

            if (!this._tankAdder.AddTank(tank))
            {
                return "Fighter with the same name exists";
            }

            return "Tank " + name + " manufactured - attack: " + attackPoint + "; defense: " + defensePoints;

        }
    }
}
