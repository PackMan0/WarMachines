namespace WarMachines.Factories
{
    using Interfaces;

    public interface ITankFactory
    {
        ITank CreateTank(string name, int attackPoints, int defensePoints);
    }
}
