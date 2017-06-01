namespace WarMachines.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Providers;

    public class ManufactureFighterCommand : ICommand
    {
        private readonly IFighterFactory _fighterFactory;
        private readonly IFighterAdder _fighterAdder;

        public ManufactureFighterCommand(IFighterFactory fighterFactory, IFighterAdder fighterAdder)
        {
            this._fighterFactory = fighterFactory;
            this._fighterAdder = fighterAdder;
        }

        public string ExecuteCommand(ICollection<string> args)
        {
            var argsList = args.ToList();
            string name = argsList[0];
            int attackPoint;
            int defensePoints;
            bool initialStealthMode = argsList[3] == "StealthON";

            if (!int.TryParse(argsList[1], out attackPoint))
            {
                return "Attack points are invalid";
            }

            if (!int.TryParse(argsList[2], out defensePoints))
            {
                return "Defense points are invalid";
            }

            var fighter = this._fighterFactory.CreateFighter(name, attackPoint, defensePoints, initialStealthMode);

            if (!this._fighterAdder.AddFighter(fighter))
            {
                return "Fighter with the same name exists";
            }

            return "Fighter " + name + " manufactured - attack: " + attackPoint + "; defense: " + defensePoints + "; stealth: " + (initialStealthMode ? "ON" : "OFF");

        }
    }
}
